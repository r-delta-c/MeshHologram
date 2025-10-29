#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public partial class MeshHologramInspector : ShaderGUI
    {
        private void UpdateTabLabels()
        {
            MenuLabels[0].text = LocalizationManager.GetLocalizeText("label.general");
            MenuLabels[1].text = LocalizationManager.GetLocalizeText("label.main");
            MenuLabels[2].text = LocalizationManager.GetLocalizeText("label.others");

            GeneralLabels[0].text = LocalizationManager.GetLocalizeText("label.rendering");
            GeneralLabels[1].text = LocalizationManager.GetLocalizeText("label.stencil");
            GeneralLabels[2].text = LocalizationManager.GetLocalizeText("label.audiolink");

            MainLabels[0].text = LocalizationManager.GetLocalizeText("label.fragment");
            MainLabels[1].text = LocalizationManager.GetLocalizeText("label.color");
            MainLabels[2].text = LocalizationManager.GetLocalizeText("label.geometry");
            MainLabels[3].text = LocalizationManager.GetLocalizeText("label.orbit");

            UpdateSubTabLabels();

            OrbitLabels[0].text = LocalizationManager.GetLocalizeText("label.orbit");
            OrbitLabels[1].text = LocalizationManager.GetLocalizeText("label.orbit_rotation");
            OrbitLabels[2].text = LocalizationManager.GetLocalizeText("label.orbit_wave");
            OrbitLabels[3].text = LocalizationManager.GetLocalizeText("label.orbit_rotation_offset");
        }

        private void UpdateSubTabLabels()
        {
            switch (OrbitIndex)
            {
                case 0:
                    SubLabels[0].text = LocalizationManager.GetLocalizeText("label.source");
                    SubLabels[1].text = LocalizationManager.GetLocalizeText("label.audiolink_source");
                    SubLabels[2].text = LocalizationManager.GetLocalizeText("label.mask_offset");
                    SubLabels[3].text = LocalizationManager.GetLocalizeText("label.modifiers");
                    break;
                case 1:
                    SubLabels[0].text = LocalizationManager.GetLocalizeText("label.source");
                    SubLabels[1].text = "---";
                    SubLabels[2].text = LocalizationManager.GetLocalizeText("label.mask_offset");
                    SubLabels[3].text = "---";
                    break;
                case 2:
                    SubLabels[0].text = "---";
                    SubLabels[1].text = LocalizationManager.GetLocalizeText("label.audiolink_source");
                    SubLabels[2].text = "---";
                    SubLabels[3].text = "---";
                    break;
                case 3:
                    SubLabels[0].text = "---";
                    SubLabels[1].text = LocalizationManager.GetLocalizeText("label.audiolink_source");
                    SubLabels[2].text = LocalizationManager.GetLocalizeText("label.mask_offset");
                    SubLabels[3].text = "---";
                    break;
                default:
                    SubLabels[0].text = "---";
                    SubLabels[1].text = "---";
                    SubLabels[2].text = "---";
                    SubLabels[3].text = "---";
                    break;
            }
        }

        private void PreviewGraph(float phase_scale, uint loop_mode, float mul, float add, uint ease_mode, float curve)
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                PreviewGraph0 = new PreviewGraph(phase_scale, loop_mode, mul, add, ease_mode, curve);
            }
        }

        private void DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM key)
        {
            editor.ShaderProperty(MeshHologramProps[key].var, MeshHologramProps[key].property);
        }

        private void DrawLine()
        {
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));
        }

        private void DrawPartitionLine(int space)
        {
            EditorGUILayout.Space(space);
            DrawLine();
            EditorGUILayout.Space(space);
        }

        private void DrawHeader(string text)
        {
            GUILayout.Label("<color=white>" + text + "</color>", CustomGUIStyle[GUI_STYLE.HEADER0], GUILayout.ExpandWidth(false));
        }

        private void DrawHeaderLabel(string label, GUIStyle style)
        {
            EditorGUILayout.LabelField("<color=silver>" + label + "</color>", style);
        }

        private void DrawSubMenu(
            MESHHOLOGRAM_PROP_ENUM SOURCE,
            MESHHOLOGRAM_PROP_ENUM FIXED_VALUE,
            MESHHOLOGRAM_PROP_ENUM NOISE_OFFSET0,
            MESHHOLOGRAM_PROP_ENUM NOISE_SCALE0,
            MESHHOLOGRAM_PROP_ENUM NOISE_OFFSET1,
            MESHHOLOGRAM_PROP_ENUM NOISE_SCALE1,
            MESHHOLOGRAM_PROP_ENUM NOISE_OFFSET_BEFORE_SCALE,
            MESHHOLOGRAM_PROP_ENUM NOISE_SPACE,
            MESHHOLOGRAM_PROP_ENUM NOISE_SEED,
            MESHHOLOGRAM_PROP_ENUM NOISE_TIME_SPEED,
            MESHHOLOGRAM_PROP_ENUM NOISE_TIME_PHASE,
            MESHHOLOGRAM_PROP_ENUM NOISE_VALUE_SCALE,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_SOURCE,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_VU_BAND,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_VU_SMOOTHING,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_VU_PANNING,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_VU_STRENGTH,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_CHRONO_TENSITY_BAND,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_CHRONO_TENSITY_MODE,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_CHRONO_TENSITY_STRENGTH,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_SPECTRUM_STRENGTH,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_SPECTRUM_MIRROR,
            MESHHOLOGRAM_PROP_ENUM MASK_CONTROL_TEX,
            MESHHOLOGRAM_PROP_ENUM MASK_CONTROL_TEX_ST,
            MESHHOLOGRAM_PROP_ENUM MASK_CONTROL,
            MESHHOLOGRAM_PROP_ENUM OFFSET_CONTROL_TEX,
            MESHHOLOGRAM_PROP_ENUM OFFSET_CONTROL_TEX_ST,
            MESHHOLOGRAM_PROP_ENUM OFFSET_CONTROL,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_MASK_CONTROL_TEX,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_MASK_CONTROL_TEX_ST,
            MESHHOLOGRAM_PROP_ENUM AUDIOLINK_MASK_CONTROL,
            MESHHOLOGRAM_PROP_ENUM PHASE_SCALE,
            MESHHOLOGRAM_PROP_ENUM LOOP_MODE,
            MESHHOLOGRAM_PROP_ENUM MID_MUL,
            MESHHOLOGRAM_PROP_ENUM MID_ADD,
            MESHHOLOGRAM_PROP_ENUM EASE_MODE,
            MESHHOLOGRAM_PROP_ENUM EASE_CURVE
        )
        {
            switch (SubIndex)
            {
                case 0:
                    DrawShaderProperty(SOURCE);
                    switch(GetPropertyFloat(targetMat, SOURCE))
                    {
                        case 0:
                            DrawShaderProperty(FIXED_VALUE);
                            break;
                        case 1:
                            DrawShaderProperty(NOISE_OFFSET0);
                            DrawShaderProperty(NOISE_SCALE0);
                            if (GetPropertyFloat(targetMat, NOISE_SPACE) == 4)
                            {
                                DrawShaderProperty(NOISE_OFFSET1);
                                DrawShaderProperty(NOISE_SCALE1);
                            }
                            DrawShaderProperty(NOISE_OFFSET_BEFORE_SCALE);
                            DrawShaderProperty(NOISE_SPACE);
                            EditorGUILayout.Space(16);
                            DrawShaderProperty(NOISE_SEED);
                            EditorGUILayout.Space(16);
                            DrawShaderProperty(NOISE_TIME_SPEED);
                            DrawShaderProperty(NOISE_TIME_PHASE);
                            DrawShaderProperty(NOISE_VALUE_SCALE);
                            break;
                        default:
                            break;
                    }
                    break;
                case 1:
                    DrawAudioLinkSource(
                        AUDIOLINK_SOURCE,
                        AUDIOLINK_VU_BAND,
                        AUDIOLINK_VU_SMOOTHING,
                        AUDIOLINK_VU_PANNING,
                        AUDIOLINK_VU_STRENGTH,
                        AUDIOLINK_CHRONO_TENSITY_BAND,
                        AUDIOLINK_CHRONO_TENSITY_MODE,
                        AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                        AUDIOLINK_SPECTRUM_STRENGTH,
                        AUDIOLINK_SPECTRUM_MIRROR
                    );
                    break;
                case 2:
                    DrawMaskOffsetTex(
                        MASK_CONTROL_TEX,
                        MASK_CONTROL_TEX_ST,
                        MASK_CONTROL,
                        OFFSET_CONTROL_TEX,
                        OFFSET_CONTROL_TEX_ST,
                        OFFSET_CONTROL,
                        AUDIOLINK_MASK_CONTROL_TEX,
                        AUDIOLINK_MASK_CONTROL_TEX_ST,
                        AUDIOLINK_MASK_CONTROL
                    );
                    break;
                case 3:
                    DrawModifiers(
                        PHASE_SCALE,
                        LOOP_MODE,
                        MID_MUL,
                        MID_ADD,
                        EASE_MODE,
                        EASE_CURVE
                    );
                    break;
                default:
                    break;
            }
        }

        private void DrawMaskOffsetTex(
            MESHHOLOGRAM_PROP_ENUM tex0, MESHHOLOGRAM_PROP_ENUM st0, MESHHOLOGRAM_PROP_ENUM strength0,
            MESHHOLOGRAM_PROP_ENUM tex1, MESHHOLOGRAM_PROP_ENUM st1, MESHHOLOGRAM_PROP_ENUM strength1)
        {
            DrawShaderProperty(tex0);
            CheckSRGBTexture(tex0);
            DrawShaderProperty(strength0);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
            DrawShaderProperty(st0);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight*3.0f);
            DrawPartitionLine(4);
            DrawShaderProperty(tex1);
            CheckSRGBTexture(tex1);
            DrawShaderProperty(strength1);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
            DrawShaderProperty(st1);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight*3.0f);
        }

        private void DrawMaskOffsetTex(
            MESHHOLOGRAM_PROP_ENUM tex0, MESHHOLOGRAM_PROP_ENUM st0, MESHHOLOGRAM_PROP_ENUM strength0,
            MESHHOLOGRAM_PROP_ENUM tex1, MESHHOLOGRAM_PROP_ENUM st1, MESHHOLOGRAM_PROP_ENUM strength1,
            MESHHOLOGRAM_PROP_ENUM tex2, MESHHOLOGRAM_PROP_ENUM st2, MESHHOLOGRAM_PROP_ENUM strength2)
        {
            DrawShaderProperty(tex0);
            CheckSRGBTexture(tex0);
            DrawShaderProperty(strength0);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
            DrawShaderProperty(st0);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight*3.0f);
            DrawPartitionLine(4);
            DrawShaderProperty(tex1);
            CheckSRGBTexture(tex1);
            DrawShaderProperty(strength1);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
            DrawShaderProperty(st1);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight*3.0f);
            DrawPartitionLine(4);
            DrawShaderProperty(tex2);
            CheckSRGBTexture(tex2);
            DrawShaderProperty(strength2);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
            DrawShaderProperty(st2);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight*3.0f);
        }

        private void CheckSRGBTexture(MESHHOLOGRAM_PROP_ENUM tex)
        {
            Texture2D texture = targetMat.GetTexture(MeshHologramProps[tex].property) as Texture2D;
            if (texture == null) return;
            string path = AssetDatabase.GetAssetPath(texture);
            if (string.IsNullOrEmpty(path)) return;
            TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
            if (importer.sRGBTexture)
            {
                EditorGUILayout.HelpBox(LocalizationManager.GetLocalizeText("label.warning.texture_importer_srgb"), MessageType.Warning);
            }
        }

        private void DrawAudioLinkSource(
            MESHHOLOGRAM_PROP_ENUM SOURCE,
            MESHHOLOGRAM_PROP_ENUM VU_BAND,
            MESHHOLOGRAM_PROP_ENUM VU_SMOOTHING,
            MESHHOLOGRAM_PROP_ENUM VU_PANNING,
            MESHHOLOGRAM_PROP_ENUM VU_STRENGTH,
            MESHHOLOGRAM_PROP_ENUM CHRONO_TENSITY_BAND,
            MESHHOLOGRAM_PROP_ENUM CHRONO_TENSITY_MODE,
            MESHHOLOGRAM_PROP_ENUM CHRONO_TENSITY_STRENGTH,
            MESHHOLOGRAM_PROP_ENUM SPECTRUM_STRENGTH,
            MESHHOLOGRAM_PROP_ENUM SPECTRUM_MIRROR
        )
        {
            DrawShaderProperty(SOURCE);
            switch (GetPropertyFloat(targetMat, SOURCE))
            {
                case 1:
                    DrawShaderProperty(VU_BAND);
                    DrawShaderProperty(VU_SMOOTHING);
                    DrawShaderProperty(VU_PANNING);
                    DrawShaderProperty(VU_STRENGTH);
                    break;
                case 2:
                    DrawShaderProperty(VU_BAND);
                    DrawShaderProperty(VU_SMOOTHING);
                    DrawShaderProperty(VU_PANNING);
                    break;
                case 3:
                    DrawShaderProperty(CHRONO_TENSITY_BAND);
                    DrawShaderProperty(CHRONO_TENSITY_MODE);
                    DrawShaderProperty(CHRONO_TENSITY_STRENGTH);
                    break;
                case 4:
                    DrawShaderProperty(SPECTRUM_MIRROR);
                    DrawShaderProperty(SPECTRUM_STRENGTH);
                    break;
                default:
                    break;
            }
        }

        private void DrawModifiers(
            MESHHOLOGRAM_PROP_ENUM PHASE_SCALE,
            MESHHOLOGRAM_PROP_ENUM LOOP_MODE,
            MESHHOLOGRAM_PROP_ENUM THRESHOLD_MUL,
            MESHHOLOGRAM_PROP_ENUM THRESHOLD_ADD,
            MESHHOLOGRAM_PROP_ENUM EASE_MODE,
            MESHHOLOGRAM_PROP_ENUM EASE_CURVE
        )
        {
            DrawShaderProperty(PHASE_SCALE);
            DrawShaderProperty(LOOP_MODE);
            DrawShaderProperty(THRESHOLD_MUL);
            DrawShaderProperty(THRESHOLD_ADD);
            DrawShaderProperty(EASE_MODE);
            DrawShaderProperty(EASE_CURVE);
            PreviewGraph(
                GetPropertyFloat(targetMat, PHASE_SCALE),
                (uint)GetPropertyFloat(targetMat, LOOP_MODE),
                GetPropertyFloat(targetMat, THRESHOLD_MUL),
                GetPropertyFloat(targetMat, THRESHOLD_ADD),
                (uint)GetPropertyFloat(targetMat, EASE_MODE),
                GetPropertyFloat(targetMat, EASE_CURVE)
            );
        }

        private void DrawNoiseProps(
            MESHHOLOGRAM_PROP_ENUM OFFSET0,
            MESHHOLOGRAM_PROP_ENUM SCALE0,
            MESHHOLOGRAM_PROP_ENUM OFFSET1,
            MESHHOLOGRAM_PROP_ENUM SCALE1,
            MESHHOLOGRAM_PROP_ENUM OFFSET_BEFORE_SCALE,
            MESHHOLOGRAM_PROP_ENUM SPACE,
            MESHHOLOGRAM_PROP_ENUM SEED,
            MESHHOLOGRAM_PROP_ENUM TIME_MULTI,
            MESHHOLOGRAM_PROP_ENUM TIME_PHASE,
            MESHHOLOGRAM_PROP_ENUM PHASE_SCALE
            )
        {
            DrawShaderProperty(OFFSET0);
            DrawShaderProperty(SCALE0);
            if (GetPropertyFloat(targetMat, SPACE) == 4)
            {
                DrawShaderProperty(OFFSET1);
                DrawShaderProperty(SCALE1);
            }
            DrawShaderProperty(OFFSET_BEFORE_SCALE);
            DrawShaderProperty(SPACE);
            EditorGUILayout.Space(16);
            DrawShaderProperty(SEED);
            EditorGUILayout.Space(16);
            DrawShaderProperty(TIME_MULTI);
            DrawShaderProperty(TIME_PHASE);
            DrawShaderProperty(PHASE_SCALE);
        }

        private void DrawOrbitRotationNoise()
        {
            DrawNoiseProps(
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_OFFSET0,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_SCALE0,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_OFFSET1,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_SCALE1,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_OFFSET_BEFORE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_SPACE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_SEED,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_TIME_SPEED,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_TIME_PHASE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_VALUE_SCALE
            );
        }
    }
}

#endif