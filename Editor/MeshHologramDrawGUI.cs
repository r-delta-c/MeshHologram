#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;


namespace DeltaField.Shaders.MeshHologram.Editor
{
    public partial class MeshHologramInspector : ShaderGUI
    {
        private void DrawTitle()
        {
            current_lang = (LANG)EditorGUILayout.EnumPopup(LocalizationSystem.GetLocalizeText("label.language"), current_lang, new GUIStyle("miniPullDown"));
        }

        private void DrawRenderings()
        {
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._RENDERING_MODE);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._CULL);

            using (new EditorGUI.DisabledScope(true))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._Z_WRITE);
            }
            using (new EditorGUI.DisabledScope(
                GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._RENDERING_MODE) != 0))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._CUSTOM_RENDER_QUEUE_T);
            }
            using (new EditorGUI.DisabledScope(
                GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._RENDERING_MODE) == 0))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._CUSTOM_RENDER_QUEUE_C);
            }

            EditorGUILayout.Space(16);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._BILLBOARD_ENABLE);
            using (new EditorGUI.DisabledScope(
                !Convert.ToBoolean(GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._BILLBOARD_ENABLE))
            ))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._FORCED_Z_SCALE_ZERO);
            }

            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._FWIDTH_ENABLE);
            using (new EditorGUI.DisabledScope(
                !Convert.ToBoolean(GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._FWIDTH_ENABLE))
            ))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._DISTANCE_INFLUENCE);
            }
            EditorGUILayout.Space(16);


            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._DIRECTIONAL_LIGHT_INFLUENCE_ENABLE);
                if (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._DIRECTIONAL_LIGHT_INFLUENCE_ENABLE) == 1)
                {
                    DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._DIRECTIONAL_LIGHT_INFLUENCE);
                }
            }

            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._AMBIENT_INFLUENCE_ENABLE);
                using (new EditorGUI.DisabledGroupScope(Convert.ToBoolean(GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._LIGHTVOLUMES_INFLUENCE_ENABLE))))
                {
                    if (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._AMBIENT_INFLUENCE_ENABLE) == 1)
                    {
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._AMBIENT_INFLUENCE);
                    }
                }
            }

            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._LIGHTVOLUMES_INFLUENCE_ENABLE);
                if (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._LIGHTVOLUMES_INFLUENCE_ENABLE) == 1)
                {
                    DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._LIGHTVOLUMES_INFLUENCE);
                }
            }

            EditorGUILayout.Space(16);

            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                DrawOtherRendering();
            }

            EditorGUILayout.Space(16);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._PREVIEW_ENABLE);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ANTI_ALIASING_ENABLE);
            EditorGUILayout.Space(16);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._MAIN_TEX);
        }

        private void DrawOtherRendering()
        {
            if (FoldoutList.MenuFoldout(FOLDOUT.RENDERING_OTHER, false))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._Z_CLIP);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._Z_TEST);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._COLOR_MASK);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._OFFSET_FACTOR);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._OFFSET_UNITS);

                using (new EditorGUI.DisabledScope(
                    GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._RENDERING_MODE) != 0))
                {
                    DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ALPHA_TO_MASK);
                }

                EditorGUILayout.Space(16);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._STEREO_MERGE_MODE);
                EditorGUILayout.Space(16);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._BLEND_OP);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._SRC_BLEND);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._DST_BLEND);
                EditorGUILayout.Space(16);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._BLEND_OP_ALPHA);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._SRC_BLEND_ALPHA);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._DST_BLEND_ALPHA);
                editor.EnableInstancingField();
                editor.DoubleSidedGIField();
            }

        }

        private void DrawStencil()
        {
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._STENCIL_REF);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._STENCIL_READ_MASK);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._STENCIL_WRITE_MASK);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._STENCIL_COMP);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._STENCIL_PASS);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._STENCIL_FAIL);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._STENCIL_Z_FAIL);
        }

        private void DrawAudioLink()
        {
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._AUDIOLINK_ENABLE);
            if (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._AUDIOLINK_ENABLE) == 1)
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._AUDIOLINK_THEME_COLOR_BAND);
            }
        }

        private void DrawFragment()
        {
            using (new EditorGUILayout.VerticalScope(MainGUIOption))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._FRAGMENT_FILL);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._FRAGMENT_TRIANGLE_COMPRESSION);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._FRAGMENT_LINE_WIDTH);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._FRAGMENT_LINE_GRADIENT_BIAS);
                EditorGUILayout.Space(16);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MANUAL_LINE_SCALING);
                using (new EditorGUI.DisabledScope(
                    GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MANUAL_LINE_SCALING) == 0))
                {
                    DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._FRAGMENT_LINE_SCALE);
                }
                EditorGUILayout.Space(16);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._FRAGMENT_LINE_ANIMATION_MODE);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._FRAGMENT_PARTITION_MODE);
            }

            DrawPartitionLine(4);

            DrawHeaderButtonCommons();
            SubIndex = GUILayout.Toolbar(SubIndex, SubLabels);
            DrawHeaderButtonCommon();
            DrawSubMenu(
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_FIXED_VALUE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_OFFSET0,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_SCALE0,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_OFFSET1,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_SCALE1,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_OFFSET_BEFORE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_SPACE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_SEED,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_TIME_SPEED,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_TIME_PHASE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_VALUE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_VU_BAND,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_VU_SMOOTHING,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_VU_PANNING,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_VU_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_BAND,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_MODE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_SPECTRUM_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_SPECTRUM_MIRROR,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_OFFSET_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_OFFSET_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_PHASE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MID_MUL,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MID_ADD,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_EASE_MODE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_EASE_CURVE
            );
        }

        private void DrawColor()
        {
            using (new EditorGUILayout.VerticalScope(MainGUIOption))
            {
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._COLOR_SOURCE);
                switch (targetMat.GetInt(MeshHologramProps[MESHHOLOGRAM_PROP_ENUM._COLOR_SOURCE].property))
                {
                    case 0:
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._COLOR0);
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._COLOR1);
                        break;
                    case 1:
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._COLOR0);
                        break;
                    case 2:
                        EditorGUILayout.GradientField("Gradient Field", gradient);
                        using (new EditorGUILayout.HorizontalScope())
                        {
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._COLOR_GRADIENT_TEX);
                            using (new EditorGUILayout.VerticalScope())
                            {
                                if (GUILayout.Button(LocalizationSystem.GetLocalizeText("label.color.preview")))
                                {
                                    targetMat.SetTexture("_ColorGradientTex", gradientMapManager.CreateTexture(gradient));
                                }
                                if (GUILayout.Button(LocalizationSystem.GetLocalizeText("label.color.export")))
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
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._AUDIOLINK_THEME_COLOR_BAND);
                        break;
                    default:
                        break;
                }
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._EMISSION);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._COLORING_PARTITION_MODE);
            }

            DrawPartitionLine(4);

            DrawHeaderButtonCommons();
            SubIndex = GUILayout.Toolbar(SubIndex, SubLabels);
            DrawHeaderButtonCommon();
            DrawSubMenu(
                MESHHOLOGRAM_PROP_ENUM._COLORING_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_FIXED_VALUE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_OFFSET0,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_SCALE0,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_OFFSET1,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_SCALE1,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_OFFSET_BEFORE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_SPACE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_SEED,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_TIME_SPEED,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_TIME_PHASE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_VALUE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_VU_BAND,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_VU_SMOOTHING,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_VU_PANNING,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_VU_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_CHRONO_TENSITY_BAND,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_CHRONO_TENSITY_MODE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_SPECTRUM_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_SPECTRUM_MIRROR,
                MESHHOLOGRAM_PROP_ENUM._COLORING_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._COLORING_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._COLORING_OFFSET_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._COLORING_OFFSET_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._COLORING_PHASE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_MID_MUL,
                MESHHOLOGRAM_PROP_ENUM._COLORING_MID_ADD,
                MESHHOLOGRAM_PROP_ENUM._COLORING_EASE_MODE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_EASE_CURVE
            );
        }

        private void DrawGeometry()
        {
            using (new EditorGUILayout.VerticalScope(MainGUIOption))
            {
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_SCALE_ENABLE);
                    if (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._GEOMETRY_SCALE_ENABLE) == 1)
                    {
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_SCALE_BOUNDS);
                    }
                }
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_PUSHPULL_ENABLE);
                    if (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._GEOMETRY_PUSHPULL_ENABLE) == 1)
                    {
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_PUSHPULL_BOUNDS);
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_PUSHPULL_PARTITION_BIAS);
                    }
                }
                using (new EditorGUILayout.VerticalScope("HelpBox"))
                {
                    DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_ROTATION_ENABLE);
                    if (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._GEOMETRY_ROTATION_ENABLE) == 1)
                    {
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_ROTATION_STRENGTH);
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_ROTATION_INVERT);
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_ROTATION_NOISE_REPEAT);
                    }
                }
                EditorGUILayout.Space(16);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_PIXELIZATION_SPACE);
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._GEOMETRY_PIXELIZATION);
            }

            DrawPartitionLine(4);

            DrawHeaderButtonCommons();
            SubIndex = GUILayout.Toolbar(SubIndex, SubLabels);
            DrawHeaderButtonCommon();
            DrawSubMenu(
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_FIXED_VALUE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_OFFSET0,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_SCALE0,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_OFFSET1,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_SCALE1,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_OFFSET_BEFORE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_SPACE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_SEED,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_TIME_SPEED,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_TIME_PHASE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_VALUE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_VU_BAND,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_VU_SMOOTHING,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_VU_PANNING,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_VU_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_BAND,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_MODE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_SPECTRUM_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_SPECTRUM_MIRROR,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_OFFSET_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_OFFSET_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_PHASE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_MID_MUL,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_MID_ADD,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_EASE_MODE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_EASE_CURVE
            );
        }

        private void DrawMainOrbit()
        {
            using (new EditorGUILayout.VerticalScope(MainGUIOption))
            {
                OrbitIndex = GUILayout.Toolbar(OrbitIndex, OrbitLabels);
                GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
                DrawHeader(OrbitLabels[OrbitIndex].text);
                DrawHeaderButtonOrbitBlock();
                GUILayout.EndHorizontal();
                UpdateSubTabLabels();
                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ENABLE);
                if (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._ORBIT_ENABLE) == 1)
                {
                    switch (OrbitIndex)
                    {
                        case 0:
                            DrawOrbit();
                            break;
                        case 1:
                            DrawOrbitRotation();
                            break;
                        case 2:
                            DrawOrbitWave();
                            break;
                        case 3:
                            DrawOrbitRotationOffset();
                            break;
                        default:
                            break;
                    }
                }
            }

            DrawPartitionLine(4);
            DrawHeaderButtonOrbitCommons();
            SubIndex = GUILayout.Toolbar(SubIndex, SubLabels);
            DrawHeaderButtonOrbitCommon();

            if (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._ORBIT_ENABLE) == 1)
            {
                switch (OrbitIndex)
                {
                    case 0:
                        DrawOrbitSub();
                        break;
                    case 1:
                        DrawOrbitRotationSub();
                        break;
                    case 2:
                        DrawOrbitWaveSub();
                        break;
                    case 3:
                        DrawOrbitRotationOffsetSub();
                        break;
                }
            }
        }

        private void DrawOrbit()
        {
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_OFFSET);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_SCALE);
        }

        private void DrawOrbitSub()
        {
            if (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._ORBIT_ENABLE) == 1)
            {
                switch (SubIndex)
                {
                    case 0:
                        DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_SOURCE);
                        switch (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._ORBIT_SOURCE))
                        {
                            case 0:
                                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_FIXED_VALUE);
                                break;
                            case 1:
                                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_SEED);
                                DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_PRIMITIVE_RATIO);
                                break;
                            case 2:
                                DrawNoiseProps(
                                    MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_OFFSET0,
                                    MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_SCALE0,
                                    MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_OFFSET1,
                                    MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_SCALE1,
                                    MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_OFFSET_BEFORE_SCALE,
                                    MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_SPACE,
                                    MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_SEED,
                                    MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_TIME_SPEED,
                                    MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_TIME_PHASE,
                                    MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_VALUE_SCALE
                                );
                                break;
                            default:
                                break;
                        }
                        break;
                    case 1:
                        DrawAudioLinkSource(
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_SOURCE,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_VU_BAND,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_VU_SMOOTHING,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_VU_PANNING,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_VU_STRENGTH,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_CHRONO_TENSITY_BAND,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_CHRONO_TENSITY_MODE,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_SPECTRUM_STRENGTH,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_SPECTRUM_MIRROR
                        );
                        break;
                    case 2:
                        DrawMaskOffsetTex(
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_MASK_CONTROL_TEX,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_MASK_CONTROL,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_OFFSET_CONTROL_TEX,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_OFFSET_CONTROL,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_MASK_CONTROL_TEX,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_MASK_CONTROL
                        );
                        break;
                    case 3:
                        DrawModifiers(
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_PHASE_SCALE,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_LOOP_MODE,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_MID_MUL,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_MID_ADD,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_EASE_MODE,
                            MESHHOLOGRAM_PROP_ENUM._ORBIT_EASE_CURVE
                        );
                        break;
                    default:
                        break;
                }
            }
        }

        private void DrawOrbitRotation()
        {
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_SPREAD);
        }

        private void DrawOrbitRotationSub()
        {
            switch (SubIndex)
            {
                case 0:
                    DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_SOURCE);
                    switch (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_SOURCE))
                    {
                        case 0:
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_FIXED_VALUE);
                            break;
                        case 1:
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_SEED);
                            break;
                        case 2:
                            DrawOrbitRotationNoise();
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    DrawMaskOffsetTex(
                        MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_MASK_CONTROL_TEX,
                        MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_MASK_CONTROL,
                        MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_CONTROL_TEX,
                        MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_CONTROL
                    );
                    break;
                default:
                    break;
            }
        }

        private void DrawOrbitWave()
        {
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_STRENGTH);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_FREQUENCY);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_PHASE);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_SPEED);
        }

        private void DrawOrbitWaveSub()
        {
            switch (SubIndex)
            {
                case 1:
                    DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_SOURCE);
                    switch (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_SOURCE))
                    {
                        case 1:
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_VU_BAND);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_VU_SMOOTHING);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_VU_PANNING);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_VU_STRENGTH);
                            break;
                        case 2:
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_MODE);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_BAND);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_STRENGTH);
                            break;
                        case 3:
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_SPECTRUM_STRENGTH);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_SPECTRUM_MIRROR);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_SPECTRUM_MODE);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_SPECTRUM_BOUNDS);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void DrawOrbitRotationOffset()
        {
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_ANGLE);
            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_SPEED);
        }

        private void DrawOrbitRotationOffsetSub()
        {
            switch (SubIndex)
            {
                case 1:
                    DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE);
                    switch (GetPropertyFloat(targetMat, MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE))
                    {
                        case 1:
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_BAND);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_SMOOTHING);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_PANNING);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_STRENGTH);
                            break;
                        case 2:
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_BAND);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_MODE);
                            DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_STRENGTH);
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    DrawMaskOffsetTex(
                        MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_MASK_CONTROL_TEX,
                        MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_MASK_CONTROL,
                        MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL_TEX,
                        MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL
                    );
                    break;
                default:
                    break;
            }
        }

        private void DrawOthers()
        {
            cleanup_tool = new CleanupTools(targetMat);
            EditorGUILayout.Space(16);
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button(LocalizationSystem.GetLocalizeText("label.mesh_bounds_editor.button")))
                {
                    MeshBoundsEditor.Window();
                }
            }
            EditorGUILayout.Space(16);
            current_title_skin = (TITLE_SKINS)EditorGUILayout.EnumPopup(LocalizationSystem.GetLocalizeText("label.title_skin"), current_title_skin);
        }

        private void DrawEasterEgg()
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.richText = true;
            style.wordWrap = true;
            string text = "<color=#ffffff><size=12><i>" + LocalizationSystem.GetLocalizeText("label.easter_egg_text") + "</i></size></color>";
            EditorGUILayout.LabelField(text, style);
        }

    }
}

#endif