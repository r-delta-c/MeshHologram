#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DeltaField.Shaders.MeshHologram.Editor {
    public class MeshHologramInspector : ShaderGUI
    {
        [MenuItem("Assets/Create/DeltaField/MeshHologram", priority = 0)]
        private static void CreateMaterial()
        {
            Material m = new Material(Shader.Find("DeltaField/shaders/MeshHologram"));
            ProjectWindowUtil.CreateAsset(m, $"New MeshHologram.mat");
        }

        public Material targetMat;
        static protected ConfigManager Config;

        static public LocalizationManager LocalizationSystem = new LocalizationManager();
        protected Dictionary<string, bool> KeywordsDic;
        static public UnityEditor.PackageManager.PackageInfo info;
        static protected Dictionary<CUSTOM_PROPERTY, CustomPropertyState> CustomProperties;
        static protected Dictionary<SHADER_PROPERTY, ShaderPropertyState> ShaderProperties;
        static protected FoldoutManager FoldoutList;
        static protected RichTitle ShaderTitle = new RichTitle();
        static protected LANG lang;
        static protected LANG current_lang;
        static protected TITLE_SKINS current_title_skin;
        protected RemoveProperties RemoveProp;

        protected GradientMapManager gradientMapManager = new GradientMapManager();
        protected Gradient gradient = new Gradient();

        protected PreviewGraph PreviewGraph0;

        static protected bool Initialize = false;
        protected bool InspectorInitialize = false;

        private bool foldout_bool;

        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
        {
            if (Initialize == false)
            {
                info = UnityEditor.PackageManager.PackageInfo.FindForAssetPath("Packages/com.deltafield.meshhologram");
                Config = new ConfigManager();

                CustomProperties = new CustomDictionary().GetCustomProperties();
                ShaderProperties = new CustomDictionary().GetShaderProperties();
                current_lang = (LANG)Enum.Parse(typeof(LANG), Config.GetLanguage());
                UpdateLocalization();
                lang = current_lang;
                current_title_skin = (TITLE_SKINS)Enum.Parse(typeof(TITLE_SKINS), Config.GetTitleSkin());
                FoldoutList = new FoldoutManager();
                Initialize = true;
            }

            if (lang != current_lang)
            {
                UpdateLocalization();
                FoldoutList.UpdateLocalization();
            }

            if (ShaderTitle.title_skin != current_title_skin)
            {
                ShaderTitle.title_skin = current_title_skin;
                ShaderTitle.ResetTimeLimit();
                Config.SaveConfig(current_lang, current_title_skin);
            }

            if (InspectorInitialize == false)
            {
                targetMat = materialEditor.target as Material;
                foreach (CUSTOM_PROPERTY key in CustomProperties.Keys)
                {
                    Material m = materialEditor.target as Material;
                    CustomProperties[key].value = m.GetInt(CustomProperties[key].property);
                }
            }

            void UpdateLocalization()
            {
                LocalizationSystem.LoadLangFiles(current_lang);
                foreach (CUSTOM_PROPERTY i in CustomProperties.Keys)
                {
                    if (LocalizationSystem.PropLangDic.ContainsKey(CustomProperties[i].property))
                    {
                        CustomProperties[i].display = LocalizationSystem.PropLangDic[CustomProperties[i].property];
                    }
                }
                foreach (SHADER_PROPERTY i in ShaderProperties.Keys)
                {
                    if (LocalizationSystem.PropLangDic.ContainsKey(ShaderProperties[i].property))
                    {
                        ShaderProperties[i].display = LocalizationSystem.PropLangDic[ShaderProperties[i].property];
                    }
                }
                lang = current_lang;

                Config.SaveConfig(current_lang, current_title_skin);
            }

            void DrawCustomProperty(Material targetMat, CUSTOM_PROPERTY key, bool toggle_pos = false)
            {
                CustomProperties[key].value = targetMat.GetInt(CustomProperties[key].property);
                if (CustomProperties[key].keywords.Count > 2)
                {
                    CustomProperties[key].var = FindProperty(CustomProperties[key].property, props);
                    materialEditor.ShaderProperty(CustomProperties[key].var, CustomProperties[key].display);
                    CustomProperties[key].value = targetMat.GetInt(CustomProperties[key].property);
                }
                else
                {
                    if (toggle_pos)
                    {
                        CustomProperties[key].value = Convert.ToInt16(EditorGUILayout.ToggleLeft(CustomProperties[key].display, Convert.ToBoolean(CustomProperties[key].value)));
                    }
                    else
                    {
                        CustomProperties[key].value = Convert.ToInt16(EditorGUILayout.Toggle(CustomProperties[key].display, Convert.ToBoolean(CustomProperties[key].value)));
                    }
                }
            }

            void DrawShaderProperty(SHADER_PROPERTY key)
            {
                ShaderProperties[key].var = FindProperty(ShaderProperties[key].property, props);
                materialEditor.ShaderProperty(ShaderProperties[key].var, ShaderProperties[key].display);
            }

            void InsertNoise1stProps(int order = -1)
            {
                Color32 c = GUI.backgroundColor;
                GUI.backgroundColor = new Color32(128, 0, 0, 255);
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    GUI.backgroundColor = c;
                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.NOISE1ST, false, order);
                    if (foldout_bool)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_OFFSET_CONTROL_TEX);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_OFFSET_CONTROL);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_OFFSET0);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_SCALE0);
                        if (CustomProperties[CUSTOM_PROPERTY._NOISE1ST_SPACE].value == 4)
                        {
                            DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_OFFSET1);
                            DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_SCALE1);
                        }
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_OFFSET_BEFORE_SCALE);
                        DrawCustomProperty(targetMat, CUSTOM_PROPERTY._NOISE1ST_SPACE);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_SEED);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_VALUE_CURVE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_CURVE_TYPE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_THRESHOLD_MUL);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_THRESHOLD_ADD);
                        EditorGUILayout.Space(16);
                        PreviewNoiseGraph(
                            targetMat.GetFloat(ShaderProperties[SHADER_PROPERTY._NOISE1ST_THRESHOLD_MUL].property),
                            targetMat.GetFloat(ShaderProperties[SHADER_PROPERTY._NOISE1ST_THRESHOLD_ADD].property),
                            targetMat.GetFloat(ShaderProperties[SHADER_PROPERTY._NOISE1ST_VALUE_CURVE].property),
                            Convert.ToBoolean(targetMat.GetInt(ShaderProperties[SHADER_PROPERTY._NOISE1ST_CURVE_TYPE].property))
                            );
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_TIME_MULTI);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_TIME_PHASE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_PHASE_SCALE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_PHASE_REF_AUDIOLINK);
                    }
                }
            }

            void InsertNoise2ndProps(int order = -1)
            {
                Color32 c = GUI.backgroundColor;
                GUI.backgroundColor = new Color32(0, 255, 0, 255);
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    GUI.backgroundColor = c;
                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.NOISE2ND, false, order);
                    if (foldout_bool)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_OFFSET_CONTROL_TEX);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_OFFSET_CONTROL);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_OFFSET0);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_SCALE0);
                        if (CustomProperties[CUSTOM_PROPERTY._NOISE2ND_SPACE].value == 4)
                        {
                            DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_OFFSET1);
                            DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_SCALE1);
                        }
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_OFFSET_BEFORE_SCALE);
                        DrawCustomProperty(targetMat, CUSTOM_PROPERTY._NOISE2ND_SPACE);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_SEED);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_VALUE_CURVE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_CURVE_TYPE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_THRESHOLD_MUL);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_THRESHOLD_ADD);
                        EditorGUILayout.Space(16);
                        PreviewNoiseGraph(
                            targetMat.GetFloat(ShaderProperties[SHADER_PROPERTY._NOISE2ND_THRESHOLD_MUL].property),
                            targetMat.GetFloat(ShaderProperties[SHADER_PROPERTY._NOISE2ND_THRESHOLD_ADD].property),
                            targetMat.GetFloat(ShaderProperties[SHADER_PROPERTY._NOISE2ND_VALUE_CURVE].property),
                            Convert.ToBoolean(targetMat.GetInt(ShaderProperties[SHADER_PROPERTY._NOISE2ND_CURVE_TYPE].property))
                            );
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_TIME_MULTI);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_TIME_PHASE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_PHASE_SCALE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_PHASE_REF_AUDIOLINK);
                    }
                }
            }

            void InsertNoise3rdProps(int order = -1)
            {
                Color32 c = GUI.backgroundColor;
                GUI.backgroundColor = new Color32(0, 0, 32, 255);
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    GUI.backgroundColor = c;
                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.NOISE3RD, false, order);
                    if (foldout_bool)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_OFFSET_CONTROL_TEX);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_OFFSET_CONTROL);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_OFFSET0);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_SCALE0);
                        if (CustomProperties[CUSTOM_PROPERTY._NOISE3RD_SPACE].value == 4)
                        {
                            DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_OFFSET1);
                            DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_SCALE1);
                        }
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_OFFSET_BEFORE_SCALE);
                        DrawCustomProperty(targetMat, CUSTOM_PROPERTY._NOISE3RD_SPACE);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_SEED);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_VALUE_CURVE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_CURVE_TYPE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_THRESHOLD_MUL);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_THRESHOLD_ADD);
                        EditorGUILayout.Space(16);
                        PreviewNoiseGraph(
                            targetMat.GetFloat(ShaderProperties[SHADER_PROPERTY._NOISE3RD_THRESHOLD_MUL].property),
                            targetMat.GetFloat(ShaderProperties[SHADER_PROPERTY._NOISE3RD_THRESHOLD_ADD].property),
                            targetMat.GetFloat(ShaderProperties[SHADER_PROPERTY._NOISE3RD_VALUE_CURVE].property),
                            Convert.ToBoolean(targetMat.GetInt(ShaderProperties[SHADER_PROPERTY._NOISE3RD_CURVE_TYPE].property))
                            );
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_TIME_MULTI);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_TIME_PHASE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_PHASE_SCALE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_PHASE_REF_AUDIOLINK);
                    }
                }
            }

            void PreviewNoiseGraph(float mul, float add, float curve, bool curve_type)
            {
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    PreviewGraph0 = new PreviewGraph(mul, add, curve, curve_type);
                }
            }

            using (new EditorGUILayout.HorizontalScope())
            {

                GUILayout.FlexibleSpace();
                ShaderTitle.Draw();
                GUILayout.FlexibleSpace();

            }

            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.Space(16);
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    current_lang = (LANG)EditorGUILayout.EnumPopup(LocalizationSystem.PropLangDic["label.language"], current_lang, new GUIStyle("miniPullDown"));
                }
                EditorGUILayout.Space(16);
                EditorGUILayout.LabelField("<color=#ffffff><b>General</b></color>", CustomDictionary.gui[CUSTOM_GUI.HEADER0]);
                EditorGUILayout.Space(6);

                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.RENDERING, true);
                    if (foldout_bool)
                    {
                        DrawCustomProperty(targetMat, CUSTOM_PROPERTY._RENDERING_MODE);
                        DrawShaderProperty(SHADER_PROPERTY._CULL);

                        using (new EditorGUI.DisabledScope(
                            true))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._Z_WRITE);
                        }
                        using (new EditorGUI.DisabledScope(
                            targetMat.GetInt(CustomProperties[CUSTOM_PROPERTY._RENDERING_MODE].property) != 0))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_T);
                        }
                        using (new EditorGUI.DisabledScope(
                            targetMat.GetInt(CustomProperties[CUSTOM_PROPERTY._RENDERING_MODE].property) == 0))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C);
                        }

                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._BILLBOARD_MODE);
                        using (new EditorGUI.DisabledScope(
                            !Convert.ToBoolean(targetMat.GetInt(ShaderProperties[SHADER_PROPERTY._BILLBOARD_MODE].property))
                        ))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._FORCED_Z_SCALE_ZERO);
                        }

                        DrawShaderProperty(SHADER_PROPERTY._USE_FWIDTH);
                        using (new EditorGUI.DisabledScope(
                            !Convert.ToBoolean(targetMat.GetInt(ShaderProperties[SHADER_PROPERTY._USE_FWIDTH].property))
                        ))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._DISTANCE_INFLUENCE);
                        }
                        EditorGUILayout.Space(16);


                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._ACTIVATE_DIRECTIONAL_LIGHT_INFLUENCE, true);
                            if (CustomProperties[CUSTOM_PROPERTY._ACTIVATE_DIRECTIONAL_LIGHT_INFLUENCE].value == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._DIRECTIONAL_LIGHT_INFLUENCE);
                            }
                        }

                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._ACTIVATE_AMBIENT_INFLUENCE, true);
                            using (new EditorGUI.DisabledGroupScope(Convert.ToBoolean(CustomProperties[CUSTOM_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE].value)))
                            {
                                if (CustomProperties[CUSTOM_PROPERTY._ACTIVATE_AMBIENT_INFLUENCE].value == 1)
                                {
                                    DrawShaderProperty(SHADER_PROPERTY._AMBIENT_INFLUENCE);
                                }
                            }
                        }

                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE, true);
                            if (CustomProperties[CUSTOM_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE].value == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._LIGHTVOLUMES_INFLUENCE);
                            }
                        }

                        EditorGUILayout.Space(16);

                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.RENDERING_OTHER, false);
                    if (foldout_bool)
                            {
                                DrawCustomProperty(targetMat, CUSTOM_PROPERTY._Z_CLIP);
                                DrawShaderProperty(SHADER_PROPERTY._Z_TEST);
                                DrawShaderProperty(SHADER_PROPERTY._COLOR_MASK);
                                DrawShaderProperty(SHADER_PROPERTY._OFFSET_FACTOR);
                                DrawShaderProperty(SHADER_PROPERTY._OFFSET_UNITS);

                                using (new EditorGUI.DisabledScope(
                                    targetMat.GetInt(CustomProperties[CUSTOM_PROPERTY._RENDERING_MODE].property) != 0))
                                {
                                    DrawCustomProperty(targetMat, CUSTOM_PROPERTY._ALPHA_TO_MASK);
                                }

                                EditorGUILayout.Space(16);
                                DrawShaderProperty(SHADER_PROPERTY._STEREO_MERGE_MODE);
                                EditorGUILayout.Space(16);
                                DrawShaderProperty(SHADER_PROPERTY._BLEND_OP);
                                DrawShaderProperty(SHADER_PROPERTY._SRC_BLEND);
                                DrawShaderProperty(SHADER_PROPERTY._DST_BLEND);
                                EditorGUILayout.Space(16);
                                DrawShaderProperty(SHADER_PROPERTY._BLEND_OP_ALPHA);
                                DrawShaderProperty(SHADER_PROPERTY._SRC_BLEND_ALPHA);
                                DrawShaderProperty(SHADER_PROPERTY._DST_BLEND_ALPHA);
                                materialEditor.EnableInstancingField();
                                materialEditor.DoubleSidedGIField();
                            }
                        }

                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._PREVIEW_MODE);
                        DrawShaderProperty(SHADER_PROPERTY._ANTI_ALIASING);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._MAIN_TEX);

                    }

                    GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));

                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.STENCIL, true);
                    if (foldout_bool)
                    {
                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._STENCIL_REF);
                            DrawShaderProperty(SHADER_PROPERTY._STENCIL_READ_MASK);
                            DrawShaderProperty(SHADER_PROPERTY._STENCIL_WRITE_MASK);
                            DrawShaderProperty(SHADER_PROPERTY._STENCIL_COMP);
                            DrawShaderProperty(SHADER_PROPERTY._STENCIL_PASS);
                            DrawShaderProperty(SHADER_PROPERTY._STENCIL_FAIL);
                            DrawShaderProperty(SHADER_PROPERTY._STENCIL_Z_FAIL);
                        }
                    }

                    GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));

                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.AUDIOLINK, true);
                    if (foldout_bool)
                    {
                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._USE_AUDIOLINK);
                            if (CustomProperties[CUSTOM_PROPERTY._USE_AUDIOLINK].value == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_MASK_CONTROL_TEX);
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_MASK_CONTROL);
                                EditorGUILayout.Space(16);
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_VU_BAND);
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_VU_SMOOTH);
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_VU_PANNING);
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_VU_GAIN_MUL);
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_VU_GAIN_ADD);
                                EditorGUILayout.Space(16);
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_SCALE);
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_TYPE);
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_BAND);
                                EditorGUILayout.Space(16);
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_THEME_COLOR_BAND);
                            }
                        }
                    }
                }

                EditorGUILayout.Space(16);
                EditorGUILayout.LabelField("<color=#ffffff><b>Main</b></color>", CustomDictionary.gui[CUSTOM_GUI.HEADER0]);
                EditorGUILayout.Space(6);

                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {

                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.FRAGMENT, true);
                    if (foldout_bool)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._FILL);
                        DrawShaderProperty(SHADER_PROPERTY._TRIANGLE_COMP);
                        DrawShaderProperty(SHADER_PROPERTY._LINE_WIDTH);
                        DrawShaderProperty(SHADER_PROPERTY._LINE_GRADIENT_BIAS);
                        EditorGUILayout.Space(16);
                        DrawCustomProperty(targetMat, CUSTOM_PROPERTY._MANUAL_LINE_SCALING);
                        using (new EditorGUI.DisabledScope(
                            targetMat.GetInt(CustomProperties[CUSTOM_PROPERTY._MANUAL_LINE_SCALING].property) == 0))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._LINE_SCALE);
                        }
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._LINE_FADE_MODE);
                        DrawShaderProperty(SHADER_PROPERTY._PARTITION_TYPE);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_MASK_CONTROL_TEX);
                        DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_MASK_CONTROL);
                        EditorGUILayout.Space(16);

                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._FRAGMENT_AUDIOLINK_NOISE_WAVE, true);
                            if (CustomProperties[CUSTOM_PROPERTY._FRAGMENT_AUDIOLINK_NOISE_WAVE].value == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_STRENGTH);
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_WAVE_MIRROR);
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_WAVE_TYPE);
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_WAVE_0);
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_WAVE_1);
                            }
                        }

                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_INVERSE);
                        DrawCustomProperty(targetMat, CUSTOM_PROPERTY._FRAGMENT_SOURCE);
                        switch (CustomProperties[CUSTOM_PROPERTY._FRAGMENT_SOURCE].value)
                        {
                            case 0:
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_VALUE);
                                break;
                            case 1:
                                InsertNoise1stProps(0);
                                break;
                            case 2:
                                InsertNoise2ndProps(0);
                                break;
                            case 3:
                                InsertNoise3rdProps(0);
                                break;
                        }
                    }

                    GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));

                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.COLOR, true);
                    if (foldout_bool)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._COLOR_SOURCE);
                        switch (targetMat.GetInt(ShaderProperties[SHADER_PROPERTY._COLOR_SOURCE].property))
                        {
                            case 0:
                                DrawShaderProperty(SHADER_PROPERTY._COLOR0);
                                DrawShaderProperty(SHADER_PROPERTY._COLOR1);
                                break;
                            case 1:
                                DrawShaderProperty(SHADER_PROPERTY._COLOR0);
                                break;
                            case 2:
                                EditorGUILayout.GradientField("Gradient Field", gradient);
                                using (new EditorGUILayout.HorizontalScope())
                                {
                                    DrawShaderProperty(SHADER_PROPERTY._COLOR_GRADIENT_TEX);
                                    using (new EditorGUILayout.VerticalScope())
                                    {
                                        if (GUILayout.Button(LocalizationSystem.PropLangDic["label.color.preview"]))
                                        {
                                            targetMat.SetTexture("_ColorGradientTex", gradientMapManager.CreateTexture(gradient));
                                        }
                                        if (GUILayout.Button(LocalizationSystem.PropLangDic["label.color.export"]))
                                        {
                                            Texture2D GenTex = gradientMapManager.Export(gradient);
                                            if (GenTex != null)
                                            {
                                                targetMat.SetTexture("_ColorGradientTex", GenTex);
                                            }
                                        }
                                    }
                                }
                                break;
                            case 5:
                                DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_THEME_COLOR_BAND);
                                break;
                            default:
                                break;
                        }
                        DrawShaderProperty(SHADER_PROPERTY._EMISSION);
                        DrawShaderProperty(SHADER_PROPERTY._COLORING_PARTITION_TYPE);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._COLORING_MASK_CONTROL_TEX);
                        DrawShaderProperty(SHADER_PROPERTY._COLORING_MASK_CONTROL);
                        EditorGUILayout.Space(16);

                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._COLORING_AUDIOLINK_NOISE_WAVE, true);
                            if (CustomProperties[CUSTOM_PROPERTY._COLORING_AUDIOLINK_NOISE_WAVE].value == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_STRENGTH);
                                DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_WAVE_MIRROR);
                                DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_WAVE_TYPE);
                                DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_WAVE_0);
                                DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_WAVE_1);
                            }
                        }

                        EditorGUILayout.Space(16);
                        DrawCustomProperty(targetMat, CUSTOM_PROPERTY._COLORING_SOURCE);
                        switch (CustomProperties[CUSTOM_PROPERTY._COLORING_SOURCE].value)
                        {
                            case 0:
                                DrawShaderProperty(SHADER_PROPERTY._COLOR_VALUE);
                                break;
                            case 1:
                                InsertNoise1stProps(1);
                                break;
                            case 2:
                                InsertNoise2ndProps(1);
                                break;
                            case 3:
                                InsertNoise3rdProps(1);
                                break;
                        }
                    }

                    GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));

                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.GEOMETRY, true);
                    if (foldout_bool)
                    {
                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._GEOMETRY_SCALE, true);
                            if (CustomProperties[CUSTOM_PROPERTY._GEOMETRY_SCALE].value == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_SCALE0);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_SCALE1);
                            }
                        }
                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._GEOMETRY_EXTRUDE, true);
                            if (CustomProperties[CUSTOM_PROPERTY._GEOMETRY_EXTRUDE].value == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_EXTRUDE0);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_EXTRUDE1);
                            }
                        }
                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._GEOMETRY_ROTATION, true);
                            if (CustomProperties[CUSTOM_PROPERTY._GEOMETRY_ROTATION].value == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_ROTATION_REVERSE);
                                DrawCustomProperty(targetMat, CUSTOM_PROPERTY._GEOMETRY_ROTATION_NOISE_REPEAT);
                            }
                        }

                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_MASK_CONTROL_TEX);
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_MASK_CONTROL);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_PARTITION_BIAS);
                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._PIXELIZATION_SPACE);
                        DrawShaderProperty(SHADER_PROPERTY._PIXELIZATION);
                        EditorGUILayout.Space(16);

                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawCustomProperty(targetMat, CUSTOM_PROPERTY._GEOMETRY_AUDIOLINK_NOISE_WAVE, true);
                            if (CustomProperties[CUSTOM_PROPERTY._GEOMETRY_AUDIOLINK_NOISE_WAVE].value == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_STRENGTH);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_WAVE_MIRROR);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_WAVE_TYPE);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_WAVE_0);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_WAVE_1);
                            }
                        }

                        EditorGUILayout.Space(16);
                        DrawCustomProperty(targetMat, CUSTOM_PROPERTY._GEOMETRY_SOURCE);
                        switch (CustomProperties[CUSTOM_PROPERTY._GEOMETRY_SOURCE].value)
                        {
                            case 0:
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_VALUE);
                                break;
                            case 1:
                                InsertNoise1stProps(2);
                                break;
                            case 2:
                                InsertNoise2ndProps(2);
                                break;
                            case 3:
                                InsertNoise3rdProps(2);
                                break;
                        }
                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                        foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.ORBIT, false);
                        if (foldout_bool)
                            {
                                DrawCustomProperty(targetMat, CUSTOM_PROPERTY._ACTIVATE_ORBIT, true);
                                if (CustomProperties[CUSTOM_PROPERTY._ACTIVATE_ORBIT].value == 1)
                                {
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_MASK_CONTROL_TEX);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_MASK_CONTROL);
                                    EditorGUILayout.Space(16);

                                    DrawCustomProperty(targetMat, CUSTOM_PROPERTY._ORBIT_SOURCE);
                                    switch (CustomProperties[CUSTOM_PROPERTY._ORBIT_SOURCE].value)
                                    {
                                        case 0:
                                            DrawShaderProperty(SHADER_PROPERTY._ORBIT_VALUE);
                                            break;
                                        case 1:
                                            DrawShaderProperty(SHADER_PROPERTY._ORBIT_SEED);
                                            break;
                                        case 2:
                                            InsertNoise1stProps(3);
                                            break;
                                        case 3:
                                            InsertNoise2ndProps(3);
                                            break;
                                        case 4:
                                            InsertNoise3rdProps(3);
                                            break;
                                    }

                                    DrawCustomProperty(targetMat, CUSTOM_PROPERTY._ORBIT_ROTATION_SOURCE);
                                    switch (CustomProperties[CUSTOM_PROPERTY._ORBIT_ROTATION_SOURCE].value)
                                    {
                                        case 0:
                                            DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_VALUE);
                                            break;
                                        case 1:
                                            DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_SEED);
                                            break;
                                        case 2:
                                            InsertNoise1stProps(4);
                                            break;
                                        case 3:
                                            InsertNoise2ndProps(4);
                                            break;
                                        case 4:
                                            InsertNoise3rdProps(4);
                                            break;
                                    }

                                    EditorGUILayout.Space(16);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_FORWARD);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_RIGHT);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_PHASE);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_TIME_MULTIPLIER);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_VARIANCE);
                                    EditorGUILayout.Space(16);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_OFFSET);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_SCALE_Y);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_SCALE_Z);
                                    EditorGUILayout.Space(16);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_XY_STRENGTH);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_XY_FREQUENCY);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_XY_PHASE);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_XY_TIME_MULTIPLIER);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_Z_STRENGTH);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_Z_FREQUENCY);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_Z_PHASE);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_Z_TIME_MULTIPLIER);
                                    EditorGUILayout.Space(16);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_REF_AUDIOLINK);
                                    EditorGUILayout.Space(16);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_AUDIOLINK_STRENGTH);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_REF_AUDIOLINK);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_STRENGTH);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_WAVE_MIRROR);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_WAVE_TYPE);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_WAVE_0);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_WAVE_1);
                                }
                            }
                        }
                    }
                }

                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.OTHERS, true);
                    if (foldout_bool)
                    {
                        RemoveProp = new RemoveProperties(targetMat);
                        EditorGUILayout.Space(16);
                        using (new EditorGUILayout.HorizontalScope())
                        {
                            if (GUILayout.Button(LocalizationSystem.PropLangDic["label.meshboundseditor.button"]))
                            {
                                MeshBoundsEditor.Window();
                            }
                        }
                        EditorGUILayout.Space(16);
                        current_title_skin = (TITLE_SKINS)EditorGUILayout.EnumPopup("Title Skin", current_title_skin);
                    }

                }

                if (changeCheckScope.changed)
                {

                    materialEditor.RegisterPropertyChangeUndo("Property");
                    foreach (CUSTOM_PROPERTY key in CustomProperties.Keys)
                    {
                        string prop = CustomProperties[key].property;
                        List<string> keywords = CustomProperties[key].keywords;
                        int i = 0;
                        foreach (string keyword in keywords)
                        {
                            if (i == CustomProperties[key].value)
                            {
                                targetMat.EnableKeyword(CustomProperties[key].keywords[i]);
                            }
                            else
                            {
                                targetMat.DisableKeyword(CustomProperties[key].keywords[i]);
                            }
                            i++;
                        }
                        targetMat.SetInt(prop, Convert.ToInt16(CustomProperties[key].value));
                    }

                    int render_queue;
                    switch (targetMat.GetInt(CustomProperties[CUSTOM_PROPERTY._RENDERING_MODE].property))
                    {
                        case 0:
                            targetMat.SetShaderPassEnabled("SHADOWCASTER", false);
                            targetMat.SetShaderPassEnabled("FORWARDBASE", true);
                            render_queue = Math.Clamp(targetMat.GetInt(ShaderProperties[SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_T].property), 3000, 5000);
                            targetMat.renderQueue = render_queue;
                            targetMat.SetInt("_AlphaToMask", CustomProperties[CUSTOM_PROPERTY._ALPHA_TO_MASK].value);
                            targetMat.SetInt("_ZWrite", 0);
                            break;
                        case 1:
                            targetMat.SetShaderPassEnabled("SHADOWCASTER", true);
                            targetMat.SetShaderPassEnabled("FORWARDBASE", true);
                            render_queue = Math.Clamp(targetMat.GetInt(ShaderProperties[SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C].property), 2001, 2499);
                            targetMat.renderQueue = render_queue;
                            targetMat.SetInt("_AlphaToMask", 1);
                            targetMat.SetInt("_ZWrite", 1);
                            break;
                        case 2:
                            targetMat.SetShaderPassEnabled("SHADOWCASTER", true);
                            targetMat.SetShaderPassEnabled("FORWARDBASE", false);
                            render_queue = Math.Clamp(targetMat.GetInt(ShaderProperties[SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C].property), 2001, 2499);
                            targetMat.renderQueue = render_queue;
                            targetMat.SetInt("_AlphaToMask", CustomProperties[CUSTOM_PROPERTY._ALPHA_TO_MASK].value);
                            targetMat.SetInt("_ZWrite", 1);
                            break;
                    }

                    EditorUtility.SetDirty(targetMat);
                }
            }
        }
    }
}
#endif