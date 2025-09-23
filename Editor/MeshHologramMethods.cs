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

        private void PreviewNoiseGraph(float mul, float add, float curve, bool curve_type)
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                PreviewGraph0 = new PreviewGraph(mul, add, curve, curve_type);
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

        private void DrawControlTex(SHADER_PROPERTY tex, SHADER_PROPERTY strength)
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                DrawShaderProperty(tex);
                DrawShaderProperty(strength);
            }
        }

        private void DrawControlTex(SHADER_PROPERTY tex, SHADER_PROPERTY strength, SHADER_PROPERTY al_mask_tex, SHADER_PROPERTY al_mask_strength)
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                DrawShaderProperty(tex);
                DrawShaderProperty(strength);
                DrawPartitionLine(4);
                DrawShaderProperty(al_mask_tex);
                DrawShaderProperty(al_mask_strength);
                EditorGUILayout.Space(4);
            }
        }

        private void DrawNoiseProps(
            int order,
            FOLDOUT foldout,
            SHADER_PROPERTY OFFSET_CONTROL_TEX,
            SHADER_PROPERTY OFFSET_CONTROL,
            SHADER_PROPERTY AL_MASK_CONTROL_TEX,
            SHADER_PROPERTY AL_MASK_CONTROL,
            SHADER_PROPERTY OFFSET0,
            SHADER_PROPERTY SCALE0,
            SHADER_PROPERTY OFFSET1,
            SHADER_PROPERTY SCALE1,
            SHADER_PROPERTY OFFSET_BEFORE_SCALE,
            SHADER_PROPERTY SPACE,
            SHADER_PROPERTY SEED,
            SHADER_PROPERTY VALUE_CURVE,
            SHADER_PROPERTY CURVE_TYPE,
            SHADER_PROPERTY THRESHOLD_MUL,
            SHADER_PROPERTY THRESHOLD_ADD,
            SHADER_PROPERTY TIME_MULTI,
            SHADER_PROPERTY TIME_PHASE,
            SHADER_PROPERTY PHASE_SCALE,
            SHADER_PROPERTY PHASE_REF_AUDIOLINK
            )
        {
            foldout_bool = FoldoutList.MenuFoldout(foldout, false, order);
            if (foldout_bool)
            {
                DrawControlTex(
                    OFFSET_CONTROL_TEX,
                    OFFSET_CONTROL,
                    AL_MASK_CONTROL_TEX,
                    AL_MASK_CONTROL
                );
                EditorGUILayout.Space(16);
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
                DrawShaderProperty(VALUE_CURVE);
                DrawShaderProperty(CURVE_TYPE);
                DrawShaderProperty(THRESHOLD_MUL);
                DrawShaderProperty(THRESHOLD_ADD);
                EditorGUILayout.Space(16);
                PreviewNoiseGraph(
                    GetPropertyFloat(targetMat, THRESHOLD_MUL),
                    GetPropertyFloat(targetMat, THRESHOLD_ADD),
                    GetPropertyFloat(targetMat, VALUE_CURVE),
                    Convert.ToBoolean(GetPropertyFloat(targetMat, CURVE_TYPE))
                    );
                EditorGUILayout.Space(16);
                DrawShaderProperty(TIME_MULTI);
                DrawShaderProperty(TIME_PHASE);
                DrawShaderProperty(PHASE_SCALE);
                DrawShaderProperty(PHASE_REF_AUDIOLINK);
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
                    SHADER_PROPERTY._NOISE1ST_OFFSET_CONTROL_TEX,
                    SHADER_PROPERTY._NOISE1ST_OFFSET_CONTROL,
                    SHADER_PROPERTY._NOISE1ST_AL_MASK_CONTROL_TEX,
                    SHADER_PROPERTY._NOISE1ST_AL_MASK_CONTROL,
                    SHADER_PROPERTY._NOISE1ST_OFFSET0,
                    SHADER_PROPERTY._NOISE1ST_SCALE0,
                    SHADER_PROPERTY._NOISE1ST_OFFSET1,
                    SHADER_PROPERTY._NOISE1ST_SCALE1,
                    SHADER_PROPERTY._NOISE1ST_OFFSET_BEFORE_SCALE,
                    SHADER_PROPERTY._NOISE1ST_SPACE,
                    SHADER_PROPERTY._NOISE1ST_SEED,
                    SHADER_PROPERTY._NOISE1ST_VALUE_CURVE,
                    SHADER_PROPERTY._NOISE1ST_CURVE_TYPE,
                    SHADER_PROPERTY._NOISE1ST_THRESHOLD_MUL,
                    SHADER_PROPERTY._NOISE1ST_THRESHOLD_ADD,
                    SHADER_PROPERTY._NOISE1ST_TIME_MULTI,
                    SHADER_PROPERTY._NOISE1ST_TIME_PHASE,
                    SHADER_PROPERTY._NOISE1ST_PHASE_SCALE,
                    SHADER_PROPERTY._NOISE1ST_PHASE_REF_AUDIOLINK
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
                    SHADER_PROPERTY._NOISE2ND_OFFSET_CONTROL_TEX,
                    SHADER_PROPERTY._NOISE2ND_OFFSET_CONTROL,
                    SHADER_PROPERTY._NOISE2ND_AL_MASK_CONTROL_TEX,
                    SHADER_PROPERTY._NOISE2ND_AL_MASK_CONTROL,
                    SHADER_PROPERTY._NOISE2ND_OFFSET0,
                    SHADER_PROPERTY._NOISE2ND_SCALE0,
                    SHADER_PROPERTY._NOISE2ND_OFFSET1,
                    SHADER_PROPERTY._NOISE2ND_SCALE1,
                    SHADER_PROPERTY._NOISE2ND_OFFSET_BEFORE_SCALE,
                    SHADER_PROPERTY._NOISE2ND_SPACE,
                    SHADER_PROPERTY._NOISE2ND_SEED,
                    SHADER_PROPERTY._NOISE2ND_VALUE_CURVE,
                    SHADER_PROPERTY._NOISE2ND_CURVE_TYPE,
                    SHADER_PROPERTY._NOISE2ND_THRESHOLD_MUL,
                    SHADER_PROPERTY._NOISE2ND_THRESHOLD_ADD,
                    SHADER_PROPERTY._NOISE2ND_TIME_MULTI,
                    SHADER_PROPERTY._NOISE2ND_TIME_PHASE,
                    SHADER_PROPERTY._NOISE2ND_PHASE_SCALE,
                    SHADER_PROPERTY._NOISE2ND_PHASE_REF_AUDIOLINK
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
                    SHADER_PROPERTY._NOISE3RD_OFFSET_CONTROL_TEX,
                    SHADER_PROPERTY._NOISE3RD_OFFSET_CONTROL,
                    SHADER_PROPERTY._NOISE3RD_AL_MASK_CONTROL_TEX,
                    SHADER_PROPERTY._NOISE3RD_AL_MASK_CONTROL,
                    SHADER_PROPERTY._NOISE3RD_OFFSET0,
                    SHADER_PROPERTY._NOISE3RD_SCALE0,
                    SHADER_PROPERTY._NOISE3RD_OFFSET1,
                    SHADER_PROPERTY._NOISE3RD_SCALE1,
                    SHADER_PROPERTY._NOISE3RD_OFFSET_BEFORE_SCALE,
                    SHADER_PROPERTY._NOISE3RD_SPACE,
                    SHADER_PROPERTY._NOISE3RD_SEED,
                    SHADER_PROPERTY._NOISE3RD_VALUE_CURVE,
                    SHADER_PROPERTY._NOISE3RD_CURVE_TYPE,
                    SHADER_PROPERTY._NOISE3RD_THRESHOLD_MUL,
                    SHADER_PROPERTY._NOISE3RD_THRESHOLD_ADD,
                    SHADER_PROPERTY._NOISE3RD_TIME_MULTI,
                    SHADER_PROPERTY._NOISE3RD_TIME_PHASE,
                    SHADER_PROPERTY._NOISE3RD_PHASE_SCALE,
                    SHADER_PROPERTY._NOISE3RD_PHASE_REF_AUDIOLINK
                );
            }
        }
    }
}

#endif