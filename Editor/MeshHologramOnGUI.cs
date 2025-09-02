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
                        DrawControlTex(
                            SHADER_PROPERTY._AUDIOLINK_MASK_CONTROL_TEX,
                            SHADER_PROPERTY._AUDIOLINK_MASK_CONTROL
                        );
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
                DrawShaderProperty(SHADER_PROPERTY._PARTITION_TYPE);
                EditorGUILayout.Space(16);
                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_MASK_CONTROL_TEX);
                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_MASK_CONTROL);
                EditorGUILayout.Space(16);

                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_NOISE_SPECTRUM);
                    if (GetPropertyFloat(targetMat, SHADER_PROPERTY._FRAGMENT_AUDIOLINK_NOISE_SPECTRUM) == 1)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_STRENGTH);
                        DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_MIRROR);
                        DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_TYPE);
                        DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_RANGE);
                    }
                }

                EditorGUILayout.Space(16);
                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_INVERSE);
                DrawShaderProperty(SHADER_PROPERTY._FRAGMENT_SOURCE);
                switch (GetPropertyFloat(targetMat, SHADER_PROPERTY._FRAGMENT_SOURCE))
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
                DrawShaderProperty(SHADER_PROPERTY._COLORING_MASK_CONTROL_TEX);
                DrawShaderProperty(SHADER_PROPERTY._COLORING_MASK_CONTROL);
                EditorGUILayout.Space(16);

                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_NOISE_SPECTRUM);
                    if (GetPropertyFloat(targetMat, SHADER_PROPERTY._COLORING_AUDIOLINK_NOISE_SPECTRUM) == 1)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_STRENGTH);
                        DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_MIRROR);
                        DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_TYPE);
                        DrawShaderProperty(SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_RANGE);
                    }
                }

                EditorGUILayout.Space(16);
                DrawShaderProperty(SHADER_PROPERTY._COLORING_SOURCE);
                switch (GetPropertyFloat(targetMat, SHADER_PROPERTY._COLORING_SOURCE))
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
                    }
                }
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_ROTATION);
                    if (GetPropertyFloat(targetMat, SHADER_PROPERTY._GEOMETRY_ROTATION) == 1)
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
                    DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_NOISE_SPECTRUM);
                    if (GetPropertyFloat(targetMat, SHADER_PROPERTY._GEOMETRY_AUDIOLINK_NOISE_SPECTRUM) == 1)
                    {
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_STRENGTH);
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_MIRROR);
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_TYPE);
                        DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_RANGE);
                    }
                }

                EditorGUILayout.Space(16);
                DrawShaderProperty(SHADER_PROPERTY._GEOMETRY_SOURCE);
                switch (GetPropertyFloat(targetMat, SHADER_PROPERTY._GEOMETRY_SOURCE))
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
                    DrawOrbit();
                }
            }
        }

        private void DrawOrbit()
        {
            foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.ORBIT, false);
            if (foldout_bool)
            {
                DrawShaderProperty(SHADER_PROPERTY._ACTIVATE_ORBIT);
                if (GetPropertyFloat(targetMat, SHADER_PROPERTY._ACTIVATE_ORBIT) == 1)
                {
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_MASK_CONTROL_TEX);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_MASK_CONTROL);
                    EditorGUILayout.Space(16);

                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_SOURCE);
                    switch (GetPropertyFloat(targetMat, SHADER_PROPERTY._ORBIT_SOURCE))
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
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_OFFSET);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_SCALE);

                    DrawPartitionLine(8);
                    DrawHeaderLabel(LocalizationSystem.PropLangDic["label.orbit_rotation"],CustomDictionary.gui[CUSTOM_GUI.HEADER1]);
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

                    EditorGUILayout.Space(16);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_FORWARD);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_RIGHT);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_PHASE);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_TIME_MULTIPLIER);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_VARIANCE);
                    DrawPartitionLine(8);
                    DrawHeaderLabel(LocalizationSystem.PropLangDic["label.orbit_wave"],CustomDictionary.gui[CUSTOM_GUI.HEADER1]);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_XY_STRENGTH);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_XY_FREQUENCY);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_XY_PHASE);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_XY_TIME_MULTIPLIER);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_Z_STRENGTH);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_Z_FREQUENCY);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_Z_PHASE);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_Z_TIME_MULTIPLIER);
                    DrawPartitionLine(8);
                    DrawHeaderLabel(LocalizationSystem.PropLangDic["label.orbit_audiolink"],CustomDictionary.gui[CUSTOM_GUI.HEADER1]);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_REF_AUDIOLINK);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_STRENGTH);
                    if (GetPropertyFloat(targetMat, SHADER_PROPERTY._ORBIT_WAVE_REF_AUDIOLINK)==2) {
                        DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_MIRROR);
                        DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_TYPE);
                        DrawShaderProperty(SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_RANGE);
                    }
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_REF_AUDIOLINK);
                    DrawShaderProperty(SHADER_PROPERTY._ORBIT_ROTATION_AUDIOLINK_STRENGTH);
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
        }
    }
}

#endif