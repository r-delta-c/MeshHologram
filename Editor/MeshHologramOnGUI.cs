#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;
using static DeltaField.Shaders.MeshHologram.Editor.Initializer;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public partial class MeshHologramInspector : ShaderGUI
    {
        static MeshHologramInspector()
        {
            if (IsInitialized) Init();
            else OnInitialized += Init;
        }
        private static void Init()
        {
            if (!File.Exists(ConfigManager.path)) ConfigManager.SaveConfig();
            UpdateTabLabels();
            FoldoutList = new FoldoutManager();
        }
        public override void OnGUI(MaterialEditor editor, MaterialProperty[] props)
        {
            if (IsInitialized == false) return;

            if (lang != ConfigManager.lang)
            {
                UpdateTabLabels();
                FoldoutList.UpdateLocalization();
                lang = ConfigManager.lang;
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();
                RichTitle.DrawTitle();
                GUILayout.FlexibleSpace();
            }

            foreach (MESHHOLOGRAM_PROP_ENUM key in MeshHologramProps.Keys)
            {
                if (key == MESHHOLOGRAM_PROP_ENUM._DUMMY) continue;
                MeshHologramProps[key].var = FindProperty(MeshHologramProps[key].property, props);
            }

            if (InspectorInitialize == false)
            {
                this.editor = editor;
                targetMat = editor.target as Material;
                targetMats = new Material[editor.targets.Length];
                for(int i = 0; i < editor.targets.Length; i++) targetMats[i] = editor.targets[i] as Material;
                CheckNoiseLiteMode(-1);
                CheckToggleKeyword(ref EnableAudioLinkState);
                CheckToggleKeyword(ref EnableDirectionalLightInfluenceState);
                CheckToggleKeyword(ref EnableAmbientInfluenceState);
                CheckToggleKeyword(ref EnableLightVolumesState);
                InspectorInitialize = true;
            }

            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.Space(16);
                UpdateSubTabLabels();
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    LocalizationManager.DrawLanguageEnumPopup();
                }
                MenuIndex = GUILayout.Toolbar(MenuIndex, MenuLabels);
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
                    DrawHeader(MenuLabels[MenuIndex].text);
                    switch (MenuIndex)
                    {
                        case 0:
                            DrawHeaderButtonGeneral();
                            GUILayout.EndHorizontal();
                            DrawPartitionLine(4);
                            GeneralIndex = GUILayout.Toolbar(GeneralIndex, GeneralLabels);
                            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
                            DrawHeader(GeneralLabels[GeneralIndex].text);
                            switch (GeneralIndex)
                            {
                                case 0:
                                    DrawHeaderButtonRendering();
                                    GUILayout.EndHorizontal();
                                    DrawRenderings();
                                    break;
                                case 1:
                                    DrawHeaderButtonStencil();
                                    GUILayout.EndHorizontal();
                                    DrawStencil();
                                    break;
                                case 2:
                                    DrawHeaderButtonAudioLink();
                                    GUILayout.EndHorizontal();
                                    DrawAudioLink();
                                    break;
                            }
                            break;
                        case 1:
                            DrawHeaderButtonMain();
                            GUILayout.EndHorizontal();
                            DrawPartitionLine(4);
                            MainIndex = GUILayout.Toolbar(MainIndex, MainLabels);
                            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
                            DrawHeader(MainLabels[MainIndex].text);
                            switch (MainIndex)
                            {
                                case 0:
                                    DrawHeaderButtonFragment();
                                    GUILayout.EndHorizontal();
                                    DrawFragment();
                                    break;
                                case 1:
                                    DrawHeaderButtonColor();
                                    GUILayout.EndHorizontal();
                                    DrawColor();
                                    break;
                                case 2:
                                    DrawHeaderButtonGeometry();
                                    GUILayout.EndHorizontal();
                                    DrawGeometry();
                                    break;
                                case 3:
                                    DrawHeaderButtonOrbit();
                                    GUILayout.EndHorizontal();
                                    DrawMainOrbit();
                                    break;
                            }
                            break;
                        case 2:
                            DrawHeaderButtonOthers();
                            GUILayout.EndHorizontal();
                            DrawPartitionLine(4);
                            DrawOthers();
                            break;
                    }
                }

                if (changeCheckScope.changed)
                {
                    EditorApplication.delayCall += () =>
                    {
                        editor.RegisterPropertyChangeUndo("Property");
                        int render_queue;
                        foreach (Material mat in targetMats)
                        {
                            switch (GetPropertyFloat(mat, MESHHOLOGRAM_PROP_ENUM._RENDERING_MODE))
                            {
                                default:
                                    mat.SetShaderPassEnabled("SHADOWCASTER", false);
                                    mat.SetShaderPassEnabled("FORWARDBASE", true);
                                    render_queue = Math.Clamp((int)GetPropertyFloat(mat, MESHHOLOGRAM_PROP_ENUM._CUSTOM_RENDER_QUEUE_T), 3000, 5000);
                                    mat.renderQueue = render_queue;
                                    mat.SetFloat("_AlphaToMask", GetPropertyFloat(mat, MESHHOLOGRAM_PROP_ENUM._ALPHA_TO_MASK));
                                    mat.SetInt("_ZWrite", 0);
                                    break;
                                case 1:
                                    mat.SetShaderPassEnabled("SHADOWCASTER", true);
                                    mat.SetShaderPassEnabled("FORWARDBASE", true);
                                    render_queue = Math.Clamp((int)GetPropertyFloat(mat, MESHHOLOGRAM_PROP_ENUM._CUSTOM_RENDER_QUEUE_C), 2001, 2499);
                                    mat.renderQueue = render_queue;
                                    mat.SetFloat("_AlphaToMask", 1);
                                    mat.SetInt("_ZWrite", 1);
                                    break;
                                case 2:
                                    mat.SetShaderPassEnabled("SHADOWCASTER", true);
                                    mat.SetShaderPassEnabled("FORWARDBASE", false);
                                    render_queue = Math.Clamp((int)GetPropertyFloat(mat, MESHHOLOGRAM_PROP_ENUM._CUSTOM_RENDER_QUEUE_C), 2001, 2499);
                                    mat.renderQueue = render_queue;
                                    mat.SetFloat("_AlphaToMask", GetPropertyFloat(mat, MESHHOLOGRAM_PROP_ENUM._ALPHA_TO_MASK));
                                    mat.SetInt("_ZWrite", 1);
                                    break;
                            }

                            switch(GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._STEREO_MERGE_MODE))
                            {
                                default:
                                    mat.EnableKeyword("_STEREOMERGEMODE_NONE");
                                    mat.DisableKeyword("_STEREOMERGEMODE_POSITION");
                                    mat.DisableKeyword("_STEREOMERGEMODE_ROTATION");
                                    mat.DisableKeyword("_STEREOMERGEMODE_POSITION_ROTATION");
                                    break;
                                case 1:
                                    mat.DisableKeyword("_STEREOMERGEMODE_NONE");
                                    mat.EnableKeyword("_STEREOMERGEMODE_POSITION");
                                    mat.DisableKeyword("_STEREOMERGEMODE_ROTATION");
                                    mat.DisableKeyword("_STEREOMERGEMODE_POSITION_ROTATION");
                                    break;
                                case 2:
                                    mat.DisableKeyword("_STEREOMERGEMODE_NONE");
                                    mat.DisableKeyword("_STEREOMERGEMODE_POSITION");
                                    mat.EnableKeyword("_STEREOMERGEMODE_ROTATION");
                                    mat.DisableKeyword("_STEREOMERGEMODE_POSITION_ROTATION");
                                    break;
                                case 3:
                                    mat.DisableKeyword("_STEREOMERGEMODE_NONE");
                                    mat.DisableKeyword("_STEREOMERGEMODE_POSITION");
                                    mat.DisableKeyword("_STEREOMERGEMODE_ROTATION");
                                    mat.EnableKeyword("_STEREOMERGEMODE_POSITION_ROTATION");
                                    break;
                            }

                            if (ChangeNoiseLiteMode!=null) ApplyNoiseLiteMode(mat,(int)ChangeNoiseLiteMode);
                            EnableAudioLinkState.ApplyToggle(mat);
                            EnableDirectionalLightInfluenceState.ApplyToggle(mat);
                            EnableAmbientInfluenceState.ApplyToggle(mat);
                            EnableLightVolumesState.ApplyToggle(mat);
                            EditorUtility.SetDirty(targetMat);
                        }
                        if(ChangeNoiseLiteMode!=null)
                        {
                            CheckNoiseLiteMode(-1);
                            ChangeNoiseLiteMode = null;
                        }
                        CheckToggleKeyword(ref EnableAudioLinkState);
                        CheckToggleKeyword(ref EnableDirectionalLightInfluenceState);
                        CheckToggleKeyword(ref EnableAmbientInfluenceState);
                        CheckToggleKeyword(ref EnableLightVolumesState);
                    };
                }
            }
            EditorGUILayout.Space(640);
            DrawEasterEgg();
        }
    }
}

#endif