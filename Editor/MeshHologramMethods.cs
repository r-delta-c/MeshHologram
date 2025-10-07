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

        private void DrawSource(int owner,SHADER_PROPERTY SOURCE,SHADER_PROPERTY VALUE)
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                foldout_bool = FoldoutList.MenuFoldout(FOLDOUT.SOURCE, false, owner);
                if (foldout_bool)
                {
                    DrawShaderProperty(SOURCE);
                    switch (GetPropertyFloat(targetMat, SOURCE))
                    {
                        case 0:
                            DrawShaderProperty(VALUE);
                            break;
                        case 1:
                            InsertNoise1stProps(owner);
                            break;
                        case 2:
                            InsertNoise2ndProps(owner);
                            break;
                        case 3:
                            InsertNoise3rdProps(owner);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void DrawAudioLinkSource(
            int owner,
            SHADER_PROPERTY SOURCE,
            SHADER_PROPERTY VU_ADD,
            SHADER_PROPERTY CHRONO,
            SHADER_PROPERTY SPECTRUM,
            SHADER_PROPERTY MIRROR,
            SHADER_PROPERTY MODE
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
                            DrawShaderProperty(VU_ADD);
                            break;
                        case 2:
                            break;
                        case 3:
                            DrawShaderProperty(CHRONO);
                            break;
                        case 4:
                            DrawShaderProperty(SPECTRUM);
                            DrawShaderProperty(MIRROR);
                            if(MODE!=SHADER_PROPERTY._EMPTY) DrawShaderProperty(MODE);
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
            int order,
            FOLDOUT foldout,
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
            foldout_bool = FoldoutList.MenuFoldout(foldout, false, order);
            if (foldout_bool)
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
        }

        private void InsertNoise1stProps(int order = -1)
        {
            Color32 c = GUI.backgroundColor;
            GUI.backgroundColor = new Color32(128, 0, 0, 255);
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                GUI.backgroundColor = c;
                DrawNoiseProps(
                    order,
                    FOLDOUT.NOISE1ST,
                    SHADER_PROPERTY._NOISE1ST_OFFSET0,
                    SHADER_PROPERTY._NOISE1ST_SCALE0,
                    SHADER_PROPERTY._NOISE1ST_OFFSET1,
                    SHADER_PROPERTY._NOISE1ST_SCALE1,
                    SHADER_PROPERTY._NOISE1ST_OFFSET_BEFORE_SCALE,
                    SHADER_PROPERTY._NOISE1ST_SPACE,
                    SHADER_PROPERTY._NOISE1ST_SEED,
                    SHADER_PROPERTY._NOISE1ST_TIME_SPEED,
                    SHADER_PROPERTY._NOISE1ST_TIME_PHASE,
                    SHADER_PROPERTY._NOISE1ST_VALUE_SCALE
                );
            }
        }

        private void InsertNoise2ndProps(int order = -1)
        {
            Color32 c = GUI.backgroundColor;
            GUI.backgroundColor = new Color32(0, 255, 0, 255);
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                GUI.backgroundColor = c;
                DrawNoiseProps(
                    order,
                    FOLDOUT.NOISE2ND,
                    SHADER_PROPERTY._NOISE2ND_OFFSET0,
                    SHADER_PROPERTY._NOISE2ND_SCALE0,
                    SHADER_PROPERTY._NOISE2ND_OFFSET1,
                    SHADER_PROPERTY._NOISE2ND_SCALE1,
                    SHADER_PROPERTY._NOISE2ND_OFFSET_BEFORE_SCALE,
                    SHADER_PROPERTY._NOISE2ND_SPACE,
                    SHADER_PROPERTY._NOISE2ND_SEED,
                    SHADER_PROPERTY._NOISE2ND_TIME_SPEED,
                    SHADER_PROPERTY._NOISE2ND_TIME_PHASE,
                    SHADER_PROPERTY._NOISE2ND_VALUE_SCALE
                );
            }
        }

        private void InsertNoise3rdProps(int order = -1)
        {
            Color32 c = GUI.backgroundColor;
            GUI.backgroundColor = new Color32(0, 0, 32, 255);
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                GUI.backgroundColor = c;
                DrawNoiseProps(
                    order,
                    FOLDOUT.NOISE3RD,
                    SHADER_PROPERTY._NOISE3RD_OFFSET0,
                    SHADER_PROPERTY._NOISE3RD_SCALE0,
                    SHADER_PROPERTY._NOISE3RD_OFFSET1,
                    SHADER_PROPERTY._NOISE3RD_SCALE1,
                    SHADER_PROPERTY._NOISE3RD_OFFSET_BEFORE_SCALE,
                    SHADER_PROPERTY._NOISE3RD_SPACE,
                    SHADER_PROPERTY._NOISE3RD_SEED,
                    SHADER_PROPERTY._NOISE3RD_TIME_SPEED,
                    SHADER_PROPERTY._NOISE3RD_TIME_PHASE,
                    SHADER_PROPERTY._NOISE3RD_VALUE_SCALE
                );
            }
        }
    }
}

#endif