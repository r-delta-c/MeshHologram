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

        public override void OnGUI(MaterialEditor editor, MaterialProperty[] props)
        {
            if (Initialize == false)
            {
                info = UnityEditor.PackageManager.PackageInfo.FindForAssetPath("Packages/com.deltafield.meshhologram");
                Config = new ConfigManager();

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
                targetMat = editor.target as Material;
            }

            void UpdateLocalization()
            {
                LocalizationSystem.LoadLangFiles(current_lang);
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

            void DrawShaderProperty(SHADER_PROPERTY key)
            {
                ShaderProperties[key].var = FindProperty(ShaderProperties[key].property, props);
                editor.ShaderProperty(ShaderProperties[key].var, ShaderProperties[key].display);
            }

            float GetPropertyFloat(Material mat, SHADER_PROPERTY key)
            {
                return mat.GetFloat(Shader.PropertyToID(ShaderProperties[key].property));
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
                        if (GetPropertyFloat(targetMat,SHADER_PROPERTY._NOISE1ST_SPACE) == 4)
                        {
                            DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_OFFSET1);
                            DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_SCALE1);
                        }
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_OFFSET_BEFORE_SCALE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE1ST_SPACE);
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
                        if (GetPropertyFloat(targetMat,SHADER_PROPERTY._NOISE2ND_SPACE) == 4)
                        {
                            DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_OFFSET1);
                            DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_SCALE1);
                        }
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_OFFSET_BEFORE_SCALE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE2ND_SPACE);
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
                        if (GetPropertyFloat(targetMat,SHADER_PROPERTY._NOISE3RD_SPACE) == 4)
                        {
                            DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_OFFSET1);
                            DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_SCALE1);
                        }
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_OFFSET_BEFORE_SCALE);
                        DrawShaderProperty(SHADER_PROPERTY._NOISE3RD_SPACE);
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
                        DrawShaderProperty(SHADER_PROPERTY._RENDERING_MODE);
                        DrawShaderProperty(SHADER_PROPERTY._CULL);

                        using (new EditorGUI.DisabledScope(
                            true))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._Z_WRITE);
                        }
                        using (new EditorGUI.DisabledScope(
                            GetPropertyFloat(targetMat, SHADER_PROPERTY._RENDERING_MODE) != 0))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_T);
                        }
                        using (new EditorGUI.DisabledScope(
                            GetPropertyFloat(targetMat, SHADER_PROPERTY._RENDERING_MODE) == 0))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C);
                        }

                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._BILLBOARD_MODE);
                        using (new EditorGUI.DisabledScope(
                            !Convert.ToBoolean(GetPropertyFloat(targetMat,SHADER_PROPERTY._BILLBOARD_MODE))
                        ))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._FORCED_Z_SCALE_ZERO);
                        }

                        DrawShaderProperty(SHADER_PROPERTY._USE_FWIDTH);
                        using (new EditorGUI.DisabledScope(
                            !Convert.ToBoolean(GetPropertyFloat(targetMat,SHADER_PROPERTY._USE_FWIDTH))
                        ))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._DISTANCE_INFLUENCE);
                        }
                        EditorGUILayout.Space(16);


                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._ACTIVATE_DIRECTIONAL_LIGHT_INFLUENCE);
                            if (GetPropertyFloat(targetMat, SHADER_PROPERTY._ACTIVATE_DIRECTIONAL_LIGHT_INFLUENCE) == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._DIRECTIONAL_LIGHT_INFLUENCE);
                            }
                        }

                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._ACTIVATE_AMBIENT_INFLUENCE);
                            using (new EditorGUI.DisabledGroupScope(Convert.ToBoolean(GetPropertyFloat(targetMat,SHADER_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE))))
                            {
                                if (GetPropertyFloat(targetMat, SHADER_PROPERTY._ACTIVATE_AMBIENT_INFLUENCE) == 1)
                                {
                                    DrawShaderProperty(SHADER_PROPERTY._AMBIENT_INFLUENCE);
                                }
                            }
                        }

                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE);
                            if (GetPropertyFloat(targetMat,SHADER_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE) == 1)
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
                                DrawShaderProperty(SHADER_PROPERTY._Z_CLIP);
                                DrawShaderProperty(SHADER_PROPERTY._Z_TEST);
                                DrawShaderProperty(SHADER_PROPERTY._COLOR_MASK);
                                DrawShaderProperty(SHADER_PROPERTY._OFFSET_FACTOR);
                                DrawShaderProperty(SHADER_PROPERTY._OFFSET_UNITS);

                                using (new EditorGUI.DisabledScope(
                                    GetPropertyFloat(targetMat,SHADER_PROPERTY._RENDERING_MODE) != 0))
                                {
                                    DrawShaderProperty(SHADER_PROPERTY._ALPHA_TO_MASK);
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
                                editor.EnableInstancingField();
                                editor.DoubleSidedGIField();
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
                            DrawShaderProperty(SHADER_PROPERTY._USE_AUDIOLINK);
                            if (GetPropertyFloat(targetMat,SHADER_PROPERTY._USE_AUDIOLINK) == 1)
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
                        DrawShaderProperty(SHADER_PROPERTY._MANUAL_LINE_SCALING);
                        using (new EditorGUI.DisabledScope(
                            GetPropertyFloat(targetMat,SHADER_PROPERTY._MANUAL_LINE_SCALING) == 0))
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
                            DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_NOISE_SPECTROGRAM);
                            if (GetPropertyFloat(targetMat,SHADER_PROPERTY._FRAGMENT_AUDIOLINK_NOISE_SPECTROGRAM) == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_STRENGTH);
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTROGRAM_MIRROR);
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTROGRAM_TYPE);
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTROGRAM_0);
                                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTROGRAM_1);
                            }
                        }

                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_INVERSE);
                        DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_SOURCE);
                        switch (GetPropertyFloat(targetMat,SHADER_PROPERTY._FRAGMENT_SOURCE))
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
                            DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_NOISE_SPECTROGRAM);
                            if (GetPropertyFloat(targetMat,SHADER_PROPERTY._COLORING_AUDIOLINK_NOISE_SPECTROGRAM) == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_STRENGTH);
                                DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTROGRAM_MIRROR);
                                DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTROGRAM_TYPE);
                                DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTROGRAM_0);
                                DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTROGRAM_1);
                            }
                        }

                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._COLORING_SOURCE);
                        switch (GetPropertyFloat(targetMat,SHADER_PROPERTY._COLORING_SOURCE))
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
                            DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_SCALE);
                            if (GetPropertyFloat(targetMat,SHADER_PROPERTY._GEOMETRY_SCALE) == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_SCALE0);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_SCALE1);
                            }
                        }
                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_EXTRUDE);
                            if (GetPropertyFloat(targetMat,SHADER_PROPERTY._GEOMETRY_EXTRUDE) == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_EXTRUDE0);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_EXTRUDE1);
                            }
                        }
                        using (new EditorGUILayout.VerticalScope("HelpBox"))
                        {
                            DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_ROTATION);
                            if (GetPropertyFloat(targetMat,SHADER_PROPERTY._GEOMETRY_ROTATION) == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_ROTATION_REVERSE);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_ROTATION_NOISE_REPEAT);
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
                            DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_NOISE_SPECTROGRAM);
                            if (GetPropertyFloat(targetMat,SHADER_PROPERTY._GEOMETRY_AUDIOLINK_NOISE_SPECTROGRAM) == 1)
                            {
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_STRENGTH);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTROGRAM_MIRROR);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTROGRAM_TYPE);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTROGRAM_0);
                                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTROGRAM_1);
                            }
                        }

                        EditorGUILayout.Space(16);
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_SOURCE);
                        switch (GetPropertyFloat(targetMat,SHADER_PROPERTY._GEOMETRY_SOURCE))
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
                                DrawShaderProperty(SHADER_PROPERTY._ACTIVATE_ORBIT);
                                if (GetPropertyFloat(targetMat, SHADER_PROPERTY._ACTIVATE_ORBIT)==1)
                                {
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_MASK_CONTROL_TEX);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_MASK_CONTROL);
                                    EditorGUILayout.Space(16);

                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_SOURCE);
                                    switch (GetPropertyFloat(targetMat,SHADER_PROPERTY._ORBIT_SOURCE))
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

                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_SOURCE);
                                    switch (GetPropertyFloat(targetMat,SHADER_PROPERTY._ORBIT_ROTATION_SOURCE))
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
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTROGRAM_MIRROR);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTROGRAM_TYPE);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTROGRAM_0);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTROGRAM_1);
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
                    editor.RegisterPropertyChangeUndo("Property");
                    int render_queue;
                    foreach (Material mat in editor.targets)
                    {
                        switch (GetPropertyFloat(targetMat,SHADER_PROPERTY._RENDERING_MODE))
                        {
                            case 0:
                                targetMat.SetShaderPassEnabled("SHADOWCASTER", false);
                                targetMat.SetShaderPassEnabled("FORWARDBASE", true);
                                render_queue = Math.Clamp((int)GetPropertyFloat(targetMat,SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_T), 3000, 5000);
                                targetMat.renderQueue = render_queue;
                                targetMat.SetFloat("_AlphaToMask", GetPropertyFloat(targetMat,SHADER_PROPERTY._ALPHA_TO_MASK));
                                targetMat.SetInt("_ZWrite", 0);
                                break;
                            case 1:
                                targetMat.SetShaderPassEnabled("SHADOWCASTER", true);
                                targetMat.SetShaderPassEnabled("FORWARDBASE", true);
                                render_queue = Math.Clamp((int)GetPropertyFloat(targetMat,SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C), 2001, 2499);
                                targetMat.renderQueue = render_queue;
                                targetMat.SetFloat("_AlphaToMask", 1);
                                targetMat.SetInt("_ZWrite", 1);
                                break;
                            case 2:
                                targetMat.SetShaderPassEnabled("SHADOWCASTER", true);
                                targetMat.SetShaderPassEnabled("FORWARDBASE", false);
                                render_queue = Math.Clamp((int)GetPropertyFloat(targetMat,SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C), 2001, 2499);
                                targetMat.renderQueue = render_queue;
                                targetMat.SetFloat("_AlphaToMask", GetPropertyFloat(targetMat,SHADER_PROPERTY._ALPHA_TO_MASK));
                                targetMat.SetInt("_ZWrite", 1);
                                break;
                            }
                        EditorUtility.SetDirty(targetMat);
                    }
                }
            }
        }
    }
}
#endif