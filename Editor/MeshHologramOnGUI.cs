#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public partial class MeshHologramInspector : ShaderGUI
    {
        public override void OnGUI(MaterialEditor editor, MaterialProperty[] Properties)
        {
            if (Initialize == false)
            {
                if (!File.Exists(ConfigManager.path)) ConfigManager.SaveConfig();
                UpdateLocalization();
                FoldoutList = new FoldoutManager();
                Initialize = true;
            }

            if (lang != ConfigManager.lang)
            {
                UpdateLocalization();
                FoldoutList.UpdateLocalization();
                lang = ConfigManager.lang;
            }

            if (InspectorInitialize == false)
            {
                this.editor = editor;
                targetMat = this.editor.target as Material;
                props = Properties;
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



            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.Space(16);
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
                    editor.RegisterPropertyChangeUndo("Property");
                    int render_queue;
                    foreach (Material mat in editor.targets)
                    {
                        switch (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._RENDERING_MODE))
                        {
                            case 0:
                                targetMat.SetShaderPassEnabled("SHADOWCASTER", false);
                                targetMat.SetShaderPassEnabled("FORWARDBASE", true);
                                render_queue = Math.Clamp((int)GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._CUSTOM_RENDER_QUEUE_T), 3000, 5000);
                                targetMat.renderQueue = render_queue;
                                targetMat.SetFloat("_AlphaToMask", GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._ALPHA_TO_MASK));
                                targetMat.SetInt("_ZWrite", 0);
                                break;
                            case 1:
                                targetMat.SetShaderPassEnabled("SHADOWCASTER", true);
                                targetMat.SetShaderPassEnabled("FORWARDBASE", true);
                                render_queue = Math.Clamp((int)GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._CUSTOM_RENDER_QUEUE_C), 2001, 2499);
                                targetMat.renderQueue = render_queue;
                                targetMat.SetFloat("_AlphaToMask", 1);
                                targetMat.SetInt("_ZWrite", 1);
                                break;
                            case 2:
                                targetMat.SetShaderPassEnabled("SHADOWCASTER", true);
                                targetMat.SetShaderPassEnabled("FORWARDBASE", false);
                                render_queue = Math.Clamp((int)GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._CUSTOM_RENDER_QUEUE_C), 2001, 2499);
                                targetMat.renderQueue = render_queue;
                                targetMat.SetFloat("_AlphaToMask", GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._ALPHA_TO_MASK));
                                targetMat.SetInt("_ZWrite", 1);
                                break;
                        }
                        EditorUtility.SetDirty(targetMat);
                    }
                }
            }
            EditorGUILayout.Space(640);
            DrawEasterEgg();
        }
    }
}

#endif