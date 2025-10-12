#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public partial class MeshHologramInspector : ShaderGUI
    {
        private void UpdateLocalization()
        {
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
        }

        private float GetPropertyFloat(Material mat, SHADER_PROPERTY key)
        {
            return mat.GetFloat(Shader.PropertyToID(ShaderProperties[key].property));
        }

        private void PreviewGraph(float phase_scale, uint loop_mode, float mul, float add, uint ease_mode, float curve)
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                PreviewGraph0 = new PreviewGraph(phase_scale, loop_mode, mul, add, ease_mode, curve);
            }
        }

        private void DrawShaderProperty(SHADER_PROPERTY key)
        {
            ShaderProperties[key].var = FindProperty(ShaderProperties[key].property, props);
            editor.ShaderProperty(ShaderProperties[key].var, ShaderProperties[key].display);
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

        private void DrawHeaderLabel(string label, GUIStyle style)
        {
            EditorGUILayout.LabelField("<color=silver>" + label + "</color>", style);
        }

        private void DrawControlTex(int owner, SHADER_PROPERTY tex0, SHADER_PROPERTY strength0, SHADER_PROPERTY tex1, SHADER_PROPERTY strength1)
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.MASK_OFFSET, false, owner);
                if (foldout_bool)
                {
                    DrawShaderProperty(tex0);
                    DrawShaderProperty(strength0);
                    DrawPartitionLine(4);
                    DrawShaderProperty(tex1);
                    DrawShaderProperty(strength1);
                    EditorGUILayout.Space(4);
                }
            }
        }

        private void DrawControlTex(int owner, SHADER_PROPERTY tex0, SHADER_PROPERTY strength0, SHADER_PROPERTY tex1, SHADER_PROPERTY strength1, SHADER_PROPERTY tex2, SHADER_PROPERTY strength2)
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.MASK_OFFSET, false, owner);
                if (foldout_bool)
                {
                    DrawShaderProperty(tex0);
                    DrawShaderProperty(strength0);
                    DrawPartitionLine(4);
                    DrawShaderProperty(tex1);
                    DrawShaderProperty(strength1);
                    DrawPartitionLine(4);
                    DrawShaderProperty(tex2);
                    DrawShaderProperty(strength2);
                    EditorGUILayout.Space(4);
                }
            }
        }

        private void DrawAudioLinkSource(
            int owner,
            SHADER_PROPERTY SOURCE,
            SHADER_PROPERTY VU_BAND,
            SHADER_PROPERTY VU_SMOOTHING,
            SHADER_PROPERTY VU_PANNING,
            SHADER_PROPERTY VU_STRENGTH,
            SHADER_PROPERTY CHRONO_TENSITY_BAND,
            SHADER_PROPERTY CHRONO_TENSITY_MODE,
            SHADER_PROPERTY CHRONO_TENSITY_STRENGTH,
            SHADER_PROPERTY SPECTRUM_STRENGTH,
            SHADER_PROPERTY SPECTRUM_MIRROR
        )
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.AUDIOLINK_SOURCE, false, owner);
                if (foldout_bool)
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
            }
        }

        private void DrawModifier(
            int owner,
            SHADER_PROPERTY PHASE_SCALE,
            SHADER_PROPERTY LOOP_MODE,
            SHADER_PROPERTY THRESHOLD_MUL,
            SHADER_PROPERTY THRESHOLD_ADD,
            SHADER_PROPERTY EASE_MODE,
            SHADER_PROPERTY EASE_CURVE
        )
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.MODIFIER, false, owner);
                if (foldout_bool)
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
            }
        }

        private void DrawNoiseProps(
            SHADER_PROPERTY OFFSET0,
            SHADER_PROPERTY SCALE0,
            SHADER_PROPERTY OFFSET1,
            SHADER_PROPERTY SCALE1,
            SHADER_PROPERTY OFFSET_BEFORE_SCALE,
            SHADER_PROPERTY SPACE,
            SHADER_PROPERTY SEED,
            SHADER_PROPERTY TIME_MULTI,
            SHADER_PROPERTY TIME_PHASE,
            SHADER_PROPERTY PHASE_SCALE
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

        private void DrawFragmentNoise()
        {
            DrawNoiseProps(
                SHADER_PROPERTY._FRAGMENT_NOISE_OFFSET0,
                SHADER_PROPERTY._FRAGMENT_NOISE_SCALE0,
                SHADER_PROPERTY._FRAGMENT_NOISE_OFFSET1,
                SHADER_PROPERTY._FRAGMENT_NOISE_SCALE1,
                SHADER_PROPERTY._FRAGMENT_NOISE_OFFSET_BEFORE_SCALE,
                SHADER_PROPERTY._FRAGMENT_NOISE_SPACE,
                SHADER_PROPERTY._FRAGMENT_NOISE_SEED,
                SHADER_PROPERTY._FRAGMENT_NOISE_TIME_SPEED,
                SHADER_PROPERTY._FRAGMENT_NOISE_TIME_PHASE,
                SHADER_PROPERTY._FRAGMENT_NOISE_VALUE_SCALE
            );
        }

        private void DrawColoringNoise()
        {
            DrawNoiseProps(
                SHADER_PROPERTY._COLORING_NOISE_OFFSET0,
                SHADER_PROPERTY._COLORING_NOISE_SCALE0,
                SHADER_PROPERTY._COLORING_NOISE_OFFSET1,
                SHADER_PROPERTY._COLORING_NOISE_SCALE1,
                SHADER_PROPERTY._COLORING_NOISE_OFFSET_BEFORE_SCALE,
                SHADER_PROPERTY._COLORING_NOISE_SPACE,
                SHADER_PROPERTY._COLORING_NOISE_SEED,
                SHADER_PROPERTY._COLORING_NOISE_TIME_SPEED,
                SHADER_PROPERTY._COLORING_NOISE_TIME_PHASE,
                SHADER_PROPERTY._COLORING_NOISE_VALUE_SCALE
            );
        }

        private void DrawGeometryNoise()
        {
            DrawNoiseProps(
                SHADER_PROPERTY._GEOMETRY_NOISE_OFFSET0,
                SHADER_PROPERTY._GEOMETRY_NOISE_SCALE0,
                SHADER_PROPERTY._GEOMETRY_NOISE_OFFSET1,
                SHADER_PROPERTY._GEOMETRY_NOISE_SCALE1,
                SHADER_PROPERTY._GEOMETRY_NOISE_OFFSET_BEFORE_SCALE,
                SHADER_PROPERTY._GEOMETRY_NOISE_SPACE,
                SHADER_PROPERTY._GEOMETRY_NOISE_SEED,
                SHADER_PROPERTY._GEOMETRY_NOISE_TIME_SPEED,
                SHADER_PROPERTY._GEOMETRY_NOISE_TIME_PHASE,
                SHADER_PROPERTY._GEOMETRY_NOISE_VALUE_SCALE
            );
        }

        private void DrawOrbitNoise()
        {
            DrawNoiseProps(
                SHADER_PROPERTY._ORBIT_NOISE_OFFSET0,
                SHADER_PROPERTY._ORBIT_NOISE_SCALE0,
                SHADER_PROPERTY._ORBIT_NOISE_OFFSET1,
                SHADER_PROPERTY._ORBIT_NOISE_SCALE1,
                SHADER_PROPERTY._ORBIT_NOISE_OFFSET_BEFORE_SCALE,
                SHADER_PROPERTY._ORBIT_NOISE_SPACE,
                SHADER_PROPERTY._ORBIT_NOISE_SEED,
                SHADER_PROPERTY._ORBIT_NOISE_TIME_SPEED,
                SHADER_PROPERTY._ORBIT_NOISE_TIME_PHASE,
                SHADER_PROPERTY._ORBIT_NOISE_VALUE_SCALE
            );
        }

        private void DrawOrbitRotationNoise()
        {
            DrawNoiseProps(
                SHADER_PROPERTY._ORBIT_ROTATION_NOISE_OFFSET0,
                SHADER_PROPERTY._ORBIT_ROTATION_NOISE_SCALE0,
                SHADER_PROPERTY._ORBIT_ROTATION_NOISE_OFFSET1,
                SHADER_PROPERTY._ORBIT_ROTATION_NOISE_SCALE1,
                SHADER_PROPERTY._ORBIT_ROTATION_NOISE_OFFSET_BEFORE_SCALE,
                SHADER_PROPERTY._ORBIT_ROTATION_NOISE_SPACE,
                SHADER_PROPERTY._ORBIT_ROTATION_NOISE_SEED,
                SHADER_PROPERTY._ORBIT_ROTATION_NOISE_TIME_SPEED,
                SHADER_PROPERTY._ORBIT_ROTATION_NOISE_TIME_PHASE,
                SHADER_PROPERTY._ORBIT_ROTATION_NOISE_VALUE_SCALE
            );
        }
    }
}

#endif