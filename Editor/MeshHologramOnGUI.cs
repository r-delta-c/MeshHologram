#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DeltaField.Shaders.MeshHologram.Editor {
    public partial class MeshHologramInspector : ShaderGUI
    {
        private void DrawTitle()
        {
            current_lang = (LANG)EditorGUILayout.EnumPopup(LocalizationSystem.PropLangDic["label.language"], current_lang, new GUIStyle("miniPullDown"));
        }

        private void DrawRenderings()
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
                    !Convert.ToBoolean(GetPropertyFloat(targetMat, SHADER_PROPERTY._BILLBOARD_MODE))
                ))
                {
                    DrawShaderProperty(SHADER_PROPERTY._FORCED_Z_SCALE_ZERO);
                }

                DrawShaderProperty(SHADER_PROPERTY._USE_FWIDTH);
                using (new EditorGUI.DisabledScope(
                    !Convert.ToBoolean(GetPropertyFloat(targetMat, SHADER_PROPERTY._USE_FWIDTH))
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
                    using (new EditorGUI.DisabledGroupScope(Convert.ToBoolean(GetPropertyFloat(targetMat, SHADER_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE))))
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
                    if (GetPropertyFloat(targetMat, SHADER_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE) == 1)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._LIGHTVOLUMES_INFLUENCE);
                    }
                }

                EditorGUILayout.Space(16);

                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawOtherRendering();
                }

                EditorGUILayout.Space(16);
                DrawShaderProperty(SHADER_PROPERTY._PREVIEW_MODE);
                DrawShaderProperty(SHADER_PROPERTY._ANTI_ALIASING);
                EditorGUILayout.Space(16);
                DrawShaderProperty(SHADER_PROPERTY._MAIN_TEX);

            }

        }

        private void DrawOtherRendering()
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
                    GetPropertyFloat(targetMat, SHADER_PROPERTY._RENDERING_MODE) != 0))
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

        private void DrawStencil()
        {
            foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.STENCIL, true);
            if (foldout_bool)
            {
                EditorGUILayout.Space(4);
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
        }

        private void DrawAudioLink()
        {
            foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.AUDIOLINK, true);
            if (foldout_bool)
            {
                EditorGUILayout.Space(4);
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawShaderProperty(SHADER_PROPERTY._USE_AUDIOLINK);
                    if (GetPropertyFloat(targetMat, SHADER_PROPERTY._USE_AUDIOLINK) == 1)
                    {
                        DrawPartitionLine(4);
                        DrawHeaderLabel(LocalizationSystem.PropLangDic["label.vu"],CustomDictionary.gui[CUSTOM_GUI.HEADER1]);
                        DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_VU_BAND);
                        DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_VU_SMOOTH);
                        DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_VU_PANNING);
                        DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_VU_GAIN_MUL);
                        DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_VU_GAIN_ADD);
                        DrawPartitionLine(4);
                        DrawHeaderLabel(LocalizationSystem.PropLangDic["label.chronotensity"],CustomDictionary.gui[CUSTOM_GUI.HEADER1]);
                        DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_SCALE);
                        DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_TYPE);
                        DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_BAND);
                        DrawPartitionLine(4);
                        DrawHeaderLabel(LocalizationSystem.PropLangDic["label.theme_color"],CustomDictionary.gui[CUSTOM_GUI.HEADER1]);
                        DrawShaderProperty(SHADER_PROPERTY._AUDIOLINK_THEME_COLOR_BAND);
                    }
                }
            }

        }

        private void DrawFragment()
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
                    GetPropertyFloat(targetMat, SHADER_PROPERTY._MANUAL_LINE_SCALING) == 0))
                {
                    DrawShaderProperty(SHADER_PROPERTY._LINE_SCALE);
                }
                EditorGUILayout.Space(16);
                DrawShaderProperty(SHADER_PROPERTY._LINE_FADE_MODE);
                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_PARTITION_TYPE);
                EditorGUILayout.Space(16);
                DrawSource(
                    0,
                    SHADER_PROPERTY._FRAGMENT_SOURCE,
                    SHADER_PROPERTY._FRAGMENT_VALUE
                );
                DrawAudioLinkSource(
                    0,
                    SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SOURCE,
                    SHADER_PROPERTY._FRAGMENT_AUDIOLINK_VU_STRENGTH,
                    SHADER_PROPERTY._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                    SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_STRENGTH,
                    SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_MIRROR,
                    SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_TYPE
                );
                DrawControlTex(
                    0,
                    SHADER_PROPERTY._FRAGMENT_MASK_CONTROL_TEX,
                    SHADER_PROPERTY._FRAGMENT_MASK_CONTROL,
                    SHADER_PROPERTY._FRAGMENT_OFFSET_CONTROL_TEX,
                    SHADER_PROPERTY._FRAGMENT_OFFSET_CONTROL,
                    SHADER_PROPERTY._FRAGMENT_AUDIOLINK_MASK_CONTROL_TEX,
                    SHADER_PROPERTY._FRAGMENT_AUDIOLINK_MASK_CONTROL
                );
                DrawModifier(
                    0,
                    SHADER_PROPERTY._FRAGMENT_PHASE_SCALE,
                    SHADER_PROPERTY._FRAGMENT_LOOP_MODE,
                    SHADER_PROPERTY._FRAGMENT_THRESHOLD_MUL,
                    SHADER_PROPERTY._FRAGMENT_THRESHOLD_ADD,
                    SHADER_PROPERTY._FRAGMENT_EASE_MODE,
                    SHADER_PROPERTY._FRAGMENT_EASE_CURVE
                );
            }
        }

        private void DrawColor()
        {
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
                DrawSource(
                    1,
                    SHADER_PROPERTY._COLORING_SOURCE,
                    SHADER_PROPERTY._COLORING_VALUE
                );
                DrawAudioLinkSource(
                    1,
                    SHADER_PROPERTY._COLORING_AUDIOLINK_SOURCE,
                    SHADER_PROPERTY._COLORING_AUDIOLINK_VU_STRENGTH,
                    SHADER_PROPERTY._COLORING_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                    SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_STRENGTH,
                    SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_MIRROR,
                    SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_TYPE
                );
                DrawControlTex(
                    1,
                    SHADER_PROPERTY._COLORING_MASK_CONTROL_TEX,
                    SHADER_PROPERTY._COLORING_MASK_CONTROL,
                    SHADER_PROPERTY._COLORING_OFFSET_CONTROL_TEX,
                    SHADER_PROPERTY._COLORING_OFFSET_CONTROL,
                    SHADER_PROPERTY._COLORING_AUDIOLINK_MASK_CONTROL_TEX,
                    SHADER_PROPERTY._COLORING_AUDIOLINK_MASK_CONTROL
                );
                DrawModifier(
                    1,
                    SHADER_PROPERTY._COLORING_PHASE_SCALE,
                    SHADER_PROPERTY._COLORING_LOOP_MODE,
                    SHADER_PROPERTY._COLORING_THRESHOLD_MUL,
                    SHADER_PROPERTY._COLORING_THRESHOLD_ADD,
                    SHADER_PROPERTY._COLORING_EASE_MODE,
                    SHADER_PROPERTY._COLORING_EASE_CURVE
                );
            }
        }

        private void DrawGeometry()
        {
            foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.GEOMETRY, true);
            if (foldout_bool)
            {
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_SCALE);
                    if (GetPropertyFloat(targetMat, SHADER_PROPERTY._GEOMETRY_SCALE) == 1)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_SCALE_RANGE);
                    }
                }
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_EXTRUDE);
                    if (GetPropertyFloat(targetMat, SHADER_PROPERTY._GEOMETRY_EXTRUDE) == 1)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_EXTRUDE_RANGE);
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_PARTITION_BIAS);
                    }
                }
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_ROTATION);
                    if (GetPropertyFloat(targetMat, SHADER_PROPERTY._GEOMETRY_ROTATION) == 1)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_ROTATION_INFLUENCE);
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_ROTATION_REVERSE);
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_ROTATION_NOISE_REPEAT);
                    }
                }

                EditorGUILayout.Space(16);
                DrawShaderProperty(SHADER_PROPERTY._PIXELIZATION_SPACE);
                DrawShaderProperty(SHADER_PROPERTY._PIXELIZATION);
                EditorGUILayout.Space(16);

                DrawSource(
                    2,
                    SHADER_PROPERTY._GEOMETRY_SOURCE,
                    SHADER_PROPERTY._GEOMETRY_VALUE
                );
                DrawAudioLinkSource(
                    2,
                    SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SOURCE,
                    SHADER_PROPERTY._GEOMETRY_AUDIOLINK_VU_STRENGTH,
                    SHADER_PROPERTY._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                    SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_STRENGTH,
                    SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_MIRROR,
                    SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_TYPE
                );
                DrawControlTex(
                    2,
                    SHADER_PROPERTY._GEOMETRY_MASK_CONTROL_TEX,
                    SHADER_PROPERTY._GEOMETRY_MASK_CONTROL,
                    SHADER_PROPERTY._GEOMETRY_OFFSET_CONTROL_TEX,
                    SHADER_PROPERTY._GEOMETRY_OFFSET_CONTROL,
                    SHADER_PROPERTY._GEOMETRY_AUDIOLINK_MASK_CONTROL_TEX,
                    SHADER_PROPERTY._GEOMETRY_AUDIOLINK_MASK_CONTROL
                );
                DrawModifier(
                    2,
                    SHADER_PROPERTY._GEOMETRY_PHASE_SCALE,
                    SHADER_PROPERTY._GEOMETRY_LOOP_MODE,
                    SHADER_PROPERTY._GEOMETRY_THRESHOLD_MUL,
                    SHADER_PROPERTY._GEOMETRY_THRESHOLD_ADD,
                    SHADER_PROPERTY._GEOMETRY_EASE_MODE,
                    SHADER_PROPERTY._GEOMETRY_EASE_CURVE
                );
            }
        }

        private void DrawOrbit()
        {
            foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.ORBIT, true);
            if (foldout_bool)
            {
                DrawShaderProperty(SHADER_PROPERTY._ACTIVATE_ORBIT);
                if (GetPropertyFloat(targetMat, SHADER_PROPERTY._ACTIVATE_ORBIT) == 1)
                {
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_OFFSET);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_SCALE);
                    using (new EditorGUILayout.VerticalScope("HelpBox"))
                    {
                        foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.SOURCE, false, 3);
                        if (foldout_bool)
                        {
                            DrawShaderProperty(SHADER_PROPERTY._ORBIT_SOURCE);
                            switch (GetPropertyFloat(targetMat, SHADER_PROPERTY._ORBIT_SOURCE))
                            {
                                case 0:
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_VALUE);
                                    break;
                                case 1:
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_SEED);
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_PRIMITIVE_THRESHOLD);
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
                        }
                    }
                    DrawAudioLinkSource(
                        3,
                        SHADER_PROPERTY._ORBIT_AUDIOLINK_SOURCE,
                        SHADER_PROPERTY._ORBIT_AUDIOLINK_VU_STRENGTH,
                        SHADER_PROPERTY._ORBIT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                        SHADER_PROPERTY._ORBIT_AUDIOLINK_SPECTRUM_STRENGTH,
                        SHADER_PROPERTY._ORBIT_AUDIOLINK_SPECTRUM_MIRROR,
                        SHADER_PROPERTY._ORBIT_AUDIOLINK_SPECTRUM_TYPE
                    );
                    DrawControlTex(
                        3,
                        SHADER_PROPERTY._ORBIT_MASK_CONTROL_TEX,
                        SHADER_PROPERTY._ORBIT_MASK_CONTROL,
                        SHADER_PROPERTY._ORBIT_OFFSET_CONTROL_TEX,
                        SHADER_PROPERTY._ORBIT_OFFSET_CONTROL,
                        SHADER_PROPERTY._ORBIT_AUDIOLINK_MASK_CONTROL_TEX,
                        SHADER_PROPERTY._ORBIT_AUDIOLINK_MASK_CONTROL
                    );
                    DrawModifier(
                        3,
                        SHADER_PROPERTY._ORBIT_PHASE_SCALE,
                        SHADER_PROPERTY._ORBIT_LOOP_MODE,
                        SHADER_PROPERTY._ORBIT_THRESHOLD_MUL,
                        SHADER_PROPERTY._ORBIT_THRESHOLD_ADD,
                        SHADER_PROPERTY._ORBIT_EASE_MODE,
                        SHADER_PROPERTY._ORBIT_EASE_CURVE
                    );

                    DrawPartitionLine(8);
                    DrawHeaderLabel(LocalizationSystem.GetLocalizeText("label.orbit_rotation"),CustomDictionary.gui[CUSTOM_GUI.HEADER1]);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_VARIANCE);
                    using (new EditorGUILayout.VerticalScope("HelpBox"))
                    {
                        foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.SOURCE, false, 4);
                        if (foldout_bool)
                        {
                            DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_SOURCE);
                            switch (GetPropertyFloat(targetMat, SHADER_PROPERTY._ORBIT_ROTATION_SOURCE))
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
                        }
                    }
                    DrawControlTex(
                        4,
                        SHADER_PROPERTY._ORBIT_ROTATION_MASK_CONTROL_TEX,
                        SHADER_PROPERTY._ORBIT_ROTATION_MASK_CONTROL,
                        SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_CONTROL_TEX,
                        SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_CONTROL
                    );

                    DrawPartitionLine(8);
                    DrawHeaderLabel(LocalizationSystem.PropLangDic["label.orbit_wave"],CustomDictionary.gui[CUSTOM_GUI.HEADER1]);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_STRENGTH);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_FREQUENCY);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_PHASE);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_TIME_MULTIPLIER);
                    using (new EditorGUILayout.VerticalScope("HelpBox"))
                    {
                        DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SOURCE);
                        switch (GetPropertyFloat(targetMat, SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SOURCE))
                        {
                            case 1:
                                DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_VU_STRENGTH);
                                break;
                            case 2:
                                DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_CHRONOTENSITY_STRENGTH);
                                break;
                            case 3:
                                DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_STRENGTH);
                                DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_MIRROR);
                                DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_TYPE);
                                DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_RANGE);
                                break;
                            default:
                                break;
                        }
                    }

                    DrawPartitionLine(8);
                    DrawHeaderLabel(LocalizationSystem.GetLocalizeText("label.orbit_rotation_offset"),CustomDictionary.gui[CUSTOM_GUI.HEADER1]);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_TIME_MULTIPLIER);
                    using (new EditorGUILayout.VerticalScope("HelpBox"))
                    {
                        foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.AUDIOLINK_SOURCE, false, 5);
                        if (foldout_bool)
                        {
                            DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE);
                            switch (GetPropertyFloat(targetMat, SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE))
                            {
                                case 1:
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_STRENGTH);
                                    break;
                                case 2:
                                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_STRENGTH);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    DrawControlTex(
                        5,
                        SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_MASK_CONTROL_TEX,
                        SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_MASK_CONTROL,
                        SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL_TEX,
                        SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL
                    );
                }
            }
        }

        private void DrawOthers()
        {
            foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.OTHERS, true);
            if (foldout_bool)
            {
                RemoveProp = new RemoveProperties(targetMat);
                EditorGUILayout.Space(16);
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button(LocalizationSystem.PropLangDic["label.mesh_bounds_editor.button"]))
                    {
                        MeshBoundsEditor.Window();
                    }
                }
                EditorGUILayout.Space(16);
                current_title_skin = (TITLE_SKINS)EditorGUILayout.EnumPopup(LocalizationSystem.PropLangDic["label.title_skin"], current_title_skin);
            }
        }

        private void DrawEasterEgg()
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.richText = true;
            style.wordWrap = true;
            string text = "<color=#ffffff><size=12><i>" + LocalizationSystem.PropLangDic["label.easter_egg_text"] + "</i></size></color>";
            EditorGUILayout.LabelField(text, style);
        }

        public override void OnGUI(MaterialEditor editor, MaterialProperty[] Properties)
        {
            if (Initialize == false)
            {
                string resolve_path = UnityEditor.PackageManager.PackageInfo.FindForAssetPath("Packages/com.deltafield.meshhologram").resolvedPath;

                Config = new ConfigManager(resolve_path);
                LocalizationSystem = new LocalizationManager(resolve_path);

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
                this.editor = editor;
                targetMat = this.editor.target as Material;
                props = Properties;
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
                    DrawTitle();
                }

                EditorGUILayout.Space(16);
                EditorGUILayout.LabelField("<color=white>General</color>", CustomDictionary.gui[CUSTOM_GUI.HEADER0]);
                EditorGUILayout.Space(6);
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawRenderings();
                    DrawLine();
                    DrawStencil();
                    DrawLine();
                    DrawAudioLink();
                }

                EditorGUILayout.Space(16);
                EditorGUILayout.LabelField("<color=white>Main</color>", CustomDictionary.gui[CUSTOM_GUI.HEADER0]);
                EditorGUILayout.Space(6);

                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawFragment();
                    DrawLine();
                    DrawColor();
                    DrawLine();
                    DrawGeometry();
                    DrawLine();
                    DrawOrbit();
                }

                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawOthers();
                }

                if (changeCheckScope.changed)
                {
                    editor.RegisterPropertyChangeUndo("Property");
                    int render_queue;
                    foreach (Material mat in editor.targets)
                    {
                        switch (GetPropertyFloat(targetMat, SHADER_PROPERTY._RENDERING_MODE))
                        {
                            case 0:
                                targetMat.SetShaderPassEnabled("SHADOWCASTER", false);
                                targetMat.SetShaderPassEnabled("FORWARDBASE", true);
                                render_queue = Math.Clamp((int)GetPropertyFloat(targetMat, SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_T), 3000, 5000);
                                targetMat.renderQueue = render_queue;
                                targetMat.SetFloat("_AlphaToMask", GetPropertyFloat(targetMat, SHADER_PROPERTY._ALPHA_TO_MASK));
                                targetMat.SetInt("_ZWrite", 0);
                                break;
                            case 1:
                                targetMat.SetShaderPassEnabled("SHADOWCASTER", true);
                                targetMat.SetShaderPassEnabled("FORWARDBASE", true);
                                render_queue = Math.Clamp((int)GetPropertyFloat(targetMat, SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C), 2001, 2499);
                                targetMat.renderQueue = render_queue;
                                targetMat.SetFloat("_AlphaToMask", 1);
                                targetMat.SetInt("_ZWrite", 1);
                                break;
                            case 2:
                                targetMat.SetShaderPassEnabled("SHADOWCASTER", true);
                                targetMat.SetShaderPassEnabled("FORWARDBASE", false);
                                render_queue = Math.Clamp((int)GetPropertyFloat(targetMat, SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C), 2001, 2499);
                                targetMat.renderQueue = render_queue;
                                targetMat.SetFloat("_AlphaToMask", GetPropertyFloat(targetMat, SHADER_PROPERTY._ALPHA_TO_MASK));
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