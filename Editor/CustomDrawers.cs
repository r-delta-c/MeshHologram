#if UNITY_EDITOR

using System;
using System.Reflection.Emit;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public class DFNumber : MaterialPropertyDrawer
    {
        private bool is_int;
        public DFNumber(float b)
        {
            is_int = b == 1;
        }
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            string text = LocalizationManager.GetLocalizeTexts(prop)[0];
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                float value = mp.floatValue;
                EditorGUI.showMixedValue = mp.hasMixedValue;
                switch (mp.type)
                {
                    case MaterialProperty.PropType.Float:
                        value = EditorGUILayout.FloatField(text, value);
                        break;
                    case MaterialProperty.PropType.Range:
                        ShaderPropertyState state = GetStringToPropertyState(prop);
                        if (is_int) value = EditorGUILayout.IntSlider(text, (int)value, (int)state.minValue, (int)state.maxValue);
                        else value = EditorGUILayout.Slider(text, value, state.minValue, state.maxValue);
                        break;
                    default:
                        break;
                }
                EditorGUI.showMixedValue = false;
                if (changeCheckScope.changed) mp.floatValue = value;
            }
        }
    }

    public class DFColor : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            string text = LocalizationManager.GetLocalizeTexts(prop)[0];
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                Color value = mp.colorValue;
                EditorGUI.showMixedValue = mp.hasMixedValue;
                value = EditorGUILayout.ColorField(text, value);
                EditorGUI.showMixedValue = false;
                if (changeCheckScope.changed) mp.colorValue = value;
            }
        }
    }

    public class DFTexture : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            string text = LocalizationManager.GetLocalizeTexts(prop)[0];
            Texture2D tex;

            float line_height = EditorGUIUtility.singleLineHeight + 2.0f;
            rect.y += 4.0f;
            EditorGUI.LabelField(EditorGUILayout.GetControlRect(), text);
            rect.y += line_height;
            rect.height = EditorGUIUtility.singleLineHeight;
            Rect tex_rect = new Rect(rect);
            int tex_width = 64;
            tex_rect.width -= rect.width - tex_width;
            tex_rect.height *= 3.5f;

            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                EditorGUI.showMixedValue = mp.hasMixedValue;
                tex = (Texture2D)EditorGUI.ObjectField(tex_rect, mp.textureValue, typeof(Texture), false);
                EditorGUI.showMixedValue = false;

                if (changeCheckScope.changed) mp.textureValue = tex;
            }
        }
    }

    public class DFTextureST : MaterialPropertyDrawer
    {
        private bool two_elements = false;
        public DFTextureST(float i = 0)
        {
            two_elements = i == 1;
        }

        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            float[] tiling = new float[2] { mp.vectorValue.x, mp.vectorValue.y };
            float[] offset = new float[2] { mp.vectorValue.z, mp.vectorValue.w };
            float[] tiling_f;
            float[] offset_f;
            if (two_elements)
            {
                tiling_f = new float[1] { tiling[0] };
                offset_f = new float[1] { offset[0] };
            }
            else
            {
                tiling_f = new float[2] { tiling[0], tiling[1] };
                offset_f = new float[2] { offset[0], offset[1] };
            }

            float line_height = EditorGUIUtility.singleLineHeight + 2.0f;
            rect.y = rect.y + 4.0f;
            rect.height = EditorGUIUtility.singleLineHeight;
            int tex_width = 64 + 4;
            int st_label_width = 60;
            rect.width -= tex_width;
            rect.x += tex_width;
            Rect st_label_rect = new Rect(rect);
            Rect st_rect = new Rect(rect);
            st_rect.x += st_label_width;
            st_rect.width -= st_label_width;
            st_label_rect.width -= st_rect.width;

            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                EditorGUI.showMixedValue = mp.hasMixedValue;

                GUIContent[] tes = new GUIContent[] { new GUIContent("X"), new GUIContent("Y") };
                EditorGUI.LabelField(st_label_rect, "Tiling");
                EditorGUI.MultiFloatField(st_rect, tes, tiling_f);
                st_label_rect.y += line_height;
                st_rect.y += line_height;
                EditorGUI.LabelField(st_label_rect, "Offset");
                EditorGUI.MultiFloatField(st_rect, tes, offset_f);

                EditorGUI.showMixedValue = false;

                tiling[0] = tiling_f[0];
                offset[0] = offset_f[0];
                if (!two_elements)
                {
                    tiling[1] = tiling_f[1];
                    offset[1] = offset_f[1];
                }

                if (changeCheckScope.changed)
                {
                    mp.vectorValue = new Vector4(tiling[0], tiling[1], offset[0], offset[1]);
                }
            }
        }
    }

    public class DFTextureStrength : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            string text = LocalizationManager.GetLocalizeTexts(prop)[0];
            float value;
            ShaderPropertyState state = GetStringToPropertyState(prop);

            float line_height = EditorGUIUtility.singleLineHeight + 2.0f;
            rect.height = EditorGUIUtility.singleLineHeight;
            int tex_width = 64 + 4;
            int label_width = 60;
            rect.width -= tex_width;
            rect.x += tex_width;
            Rect label_rect = new Rect(rect);
            Rect slider_rect = new Rect(rect);
            slider_rect.x += label_width;
            slider_rect.width -= label_width;
            label_rect.width -= slider_rect.width;

            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                EditorGUI.showMixedValue = mp.hasMixedValue;
                EditorGUI.LabelField(label_rect, text);
                value = EditorGUI.Slider(slider_rect, mp.floatValue, state.minValue, state.maxValue);
                EditorGUI.showMixedValue = false;

                if (changeCheckScope.changed) mp.floatValue = value;
            }
        }
    }

    public class DFVector : MaterialPropertyDrawer
    {
        private uint count;
        private int total;
        private float[] values = new float[4];
        private string[] texts;
        private GUIContent[] label_contents;
        private uint[] vertical_field0, vertical_field1, vertical_field2, vertical_field3;
        private Rect field_rect;
        private int drawing_count;
        public DFVector()
        {
            Init(new uint[] { 1, 1, 1, 1 });
        }
        public DFVector(float c0)
        {
            Init(new uint[] { (uint)c0 });
        }
        public DFVector(float c0, float c1)
        {
            Init(new uint[] { (uint)c0, (uint)c1 });
        }
        public DFVector(float c0, float c1, float c2)
        {
            Init(new uint[] { (uint)c0, (uint)c1, (uint)c2 });
        }
        public DFVector(float c0, float c1, float c2, float c3)
        {
            Init(new uint[] { (uint)c0, (uint)c1, (uint)c2, (uint)c3 });
        }

        private void Init(uint[] ints)
        {
            vertical_field0 = ExtractEqualRow(ints, 1);
            vertical_field1 = ExtractEqualRow(ints, 2);
            vertical_field2 = ExtractEqualRow(ints, 3);
            vertical_field3 = ExtractEqualRow(ints, 4);
        }

        private uint[] ExtractEqualRow(uint[] ints, uint row)
        {
            uint[] r = new uint[0];
            for (uint i = 0; i < ints.Length; i++)
            {
                if (ints[i] == row)
                {
                    Array.Resize(ref r, r.Length + 1);
                    r[r.Length - 1] = i;
                }
            }
            return r;
        }

        private float[] VerticalFieldDraw(uint[] vertical_field)
        {
            if (drawing_count != 0)
            {
                EditorGUILayout.Space(EditorGUIUtility.singleLineHeight + 4.0f);
                field_rect.y += EditorGUIUtility.singleLineHeight + 4.0f;
            }
            drawing_count++;
            using (new EditorGUILayout.HorizontalScope())
            {
                float[] field_values = new float[vertical_field.Length];
                GUIContent[] contents = new GUIContent[vertical_field.Length];
                for (int i = 0; i < vertical_field.Length; i++)
                {
                    field_values[i] = values[vertical_field[i]];
                    contents[i] = label_contents[vertical_field[i]];
                }
                EditorGUI.MultiFloatField(field_rect, contents, field_values);
                for (int i = 0; i < vertical_field.Length; i++)
                {
                    values[vertical_field[i]] = field_values[i];
                }
                return field_values;
            }
        }

        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            if (mp.type == MaterialProperty.PropType.Vector)
            {
                for (int i = 0; i < values.Length; i++) values[i] = mp.vectorValue[i];

                texts = new string[5];
                for (int i = 0; i < texts.Length; i++)
                {
                    string[] localize_texts = LocalizationManager.GetLocalizeTexts(prop);
                    if (i < localize_texts.Length) texts[i] = LocalizationManager.GetLocalizeText(prop, i);
                    else texts[i] = "";
                }

                label_contents = new GUIContent[4]{
                    new GUIContent(texts[1]),
                    new GUIContent(texts[2]),
                    new GUIContent(texts[3]),
                    new GUIContent(texts[4])
                };

                using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        Rect label_rect = new Rect(rect);
                        label_rect.width = EditorGUIUtility.labelWidth;
                        field_rect = EditorGUI.PrefixLabel(label_rect, new GUIContent(texts[0]));
                        field_rect.width += rect.width - label_rect.width;
                        using (new EditorGUILayout.VerticalScope())
                        {
                            drawing_count = 0;
                            EditorGUI.showMixedValue = mp.hasMixedValue;
                            if (0 < vertical_field0.Length) VerticalFieldDraw(vertical_field0);
                            if (0 < vertical_field1.Length) VerticalFieldDraw(vertical_field1);
                            if (0 < vertical_field2.Length) VerticalFieldDraw(vertical_field2);
                            if (0 < vertical_field3.Length) VerticalFieldDraw(vertical_field3);
                            EditorGUI.showMixedValue = false;
                        }
                    }
                    if (changeCheckScope.changed)
                    {
                        mp.vectorValue = new Vector4(values[0], values[1], values[2], values[3]);
                    }
                }
            }
            else
            {
                EditorGUILayout.LabelField("WARNING! Invalid property attachment attribute.");
            }
        }
    }

    public class DFToggle : MaterialPropertyDrawer
    {
        bool toggle_left_side;
        string keyword;
        public DFToggle(string keyword, float b = 0)
        {
            this.keyword = keyword;
            this.toggle_left_side = b != 0;
        }
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            string text = LocalizationManager.GetLocalizeTexts(prop)[0];
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                bool value = mp.floatValue != 0.0f;
                EditorGUI.showMixedValue = mp.hasMixedValue;
                if (toggle_left_side)
                {
                    value = EditorGUILayout.ToggleLeft(text, value);
                }
                else
                {
                    value = EditorGUILayout.Toggle(text, value);
                }
                EditorGUI.showMixedValue = false;
                if (changeCheckScope.changed)
                {
                    mp.floatValue = value ? 1.0f : 0.0f;
                    if (keyword == "") return;
                    editor.RegisterPropertyChangeUndo("Refresh Material Keyword");
                    foreach (Material material in editor.targets)
                    {
                        if (value)
                        {
                            material.EnableKeyword(keyword);
                        }
                        else
                        {
                            material.DisableKeyword(keyword);
                        }
                    }
                }
            }
        }
    }
    public class DFColorMask : MaterialPropertyDrawer
    {
        public DFColorMask() { }
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;

        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            string text = LocalizationManager.GetLocalizeTexts(prop)[0];
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                ColorWriteMask value = (ColorWriteMask)(int)mp.floatValue;
                EditorGUI.showMixedValue = mp.hasMixedValue;
                value = (ColorWriteMask)EditorGUILayout.EnumFlagsField(text, value);
                EditorGUI.showMixedValue = false;
                if (changeCheckScope.changed)
                {
                    if ((int)value == -1)
                    {
                        mp.floatValue = 15.0f;
                    }
                    else
                    {
                        mp.floatValue = (float)value;
                    }
                }
            }
        }
    }

    public class DFRenderingMode : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_RENDERING_MODE>(mp, prop);
        }
    }
    public class DFCull : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_CULL>(mp, prop);
        }
    }
    public class DFCompare : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_COMPARE>(mp, prop);
        }
    }
    public class DFStereoMergeMode : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_STEREO_MERGE_MODE>(mp, prop);
        }

    }

    public class DFBlendOp : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_BLEND_OP>(mp, prop);
        }
    }
    public class DFBlendMode : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_BLEND_MODE>(mp, prop);
        }
    }
    public class DFStencilOp : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_STENCIL_OP>(mp, prop);
        }
    }

    public class DFAudioLinkBand : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_AUDIOLINK_BAND>(mp, prop);
        }
    }
    public class DFAudioLinkBandExpanded : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_AUDIOLINK_BAND_EXPANDED>(mp, prop);
        }
    }

    public class DFLineAnimationMode : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_LINE_ANIMATION_MODE>(mp, prop);
        }
    }
    public class DFPartitionMode : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_PARTITION_MODE>(mp, prop);
        }
    }
    public class DFColorSource : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_COLOR_SOURCE>(mp, prop);
        }
    }
    public class DFPixelizationSpace : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_PIXELIZATION_SPACE>(mp, prop);
        }
    }
    public class DFNoiseSpace : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_NOISE_SPACE>(mp, prop);
        }
    }

    public class DFSource : MaterialPropertyDrawer
    {
        public DFSource(float f)
        {
            orbit_source = f == 1;
        }

        private bool orbit_source = false;

        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;

        private bool CheckOrbitSource(Enum e)
        {
            if ((DF_ENUM_SOURCE)e == DF_ENUM_SOURCE.PRIMITIVE && !orbit_source) return false;
            else return true;
        }

        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_SOURCE>(mp, prop, CheckOrbitSource);
        }
    }
    public class DFAudioLinkSource : MaterialPropertyDrawer
    {
        public DFAudioLinkSource(float f)
        {
            block_type = (int)f;
        }

        private int block_type = 0;

        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;

        private bool CheckAudioLinkSource(Enum e)
        {
            if (block_type == 1 && (DF_ENUM_AUDIOLINK_SOURCE)e == DF_ENUM_AUDIOLINK_SOURCE.VU_ADD) return false;
            else if (block_type == 2 && (DF_ENUM_AUDIOLINK_SOURCE)e == DF_ENUM_AUDIOLINK_SOURCE.VU_MUL) return false;
            else if (block_type == 2 && (DF_ENUM_AUDIOLINK_SOURCE)e == DF_ENUM_AUDIOLINK_SOURCE.SPECTRUM) return false;
            else return true;
        }

        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_AUDIOLINK_SOURCE>(mp, prop, CheckAudioLinkSource);
        }
    }
    public class DFAudioLinkChronoTensityMode : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_AUDIOLINK_CHRONOTENSITY_MODE>(mp, prop);
        }
    }
    public class DFLoopMode : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_LOOP_MODE>(mp, prop);
        }
    }
    public class DFEaseMode : MaterialPropertyDrawer
    {
        public override float GetPropertyHeight(MaterialProperty mp, string prop, MaterialEditor editor) => 0;
        public override void OnGUI(Rect rect, MaterialProperty mp, string prop, MaterialEditor editor)
        {
            DFEnumDrawer.DrawEnumPopup<DF_ENUM_EASE_MODE>(mp, prop);
        }
    }

    public static class DFEnumDrawer
    {
        public static void DrawEnumPopup<T>(MaterialProperty mp, string prop, Func<Enum, bool> func = null)
        where T : Enum
        {
            string text = LocalizationManager.GetLocalizeTexts(prop)[0];
            if (func == null) func = (e) => true;
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                T mode = (T)Enum.ToObject(typeof(T),(int)mp.floatValue);
                EditorGUI.showMixedValue = mp.hasMixedValue;
                mode = (T)EditorGUILayout.EnumPopup(new GUIContent(text), mode, func, false);
                EditorGUI.showMixedValue = false;
                if (changeCheckScope.changed)
                {
                    mp.floatValue = Convert.ToInt32(mode);
                }
            }
        }
    }
}


#endif