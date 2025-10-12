#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public class DFVectorDrawer : MaterialPropertyDrawer
    {
        private uint count;
        private int total;
        private float[] values = new float[4];
        private string[] labels;
        private GUIContent[] label_contents;
        private uint[] vertical_field0, vertical_field1, vertical_field2, vertical_field3;
        private Rect field_rect;
        private int drawing_count;
        public DFVectorDrawer()
        {
            Init(new uint[] { 1, 1, 1, 1 });
        }
        public DFVectorDrawer(float c0)
        {
            Init(new uint[] { (uint)c0 });
        }
        public DFVectorDrawer(float c0, float c1)
        {
            Init(new uint[] { (uint)c0, (uint)c1 });
        }
        public DFVectorDrawer(float c0, float c1, float c2)
        {
            Init(new uint[] { (uint)c0, (uint)c1, (uint)c2 });
        }
        public DFVectorDrawer(float c0, float c1, float c2, float c3)
        {
            Init(new uint[] { (uint)c0, (uint)c1, (uint)c2, (uint)c3 });
        }

        private void Init(uint[] ints)
        {
            vertical_field0 = ExtractEqualRow(ints,1);
            vertical_field1 = ExtractEqualRow(ints,2);
            vertical_field2 = ExtractEqualRow(ints,3);
            vertical_field3 = ExtractEqualRow(ints,4);
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
            if (drawing_count == 0)
            {
                EditorGUILayout.Space(4);
                field_rect.y += 4;
            }
            else
            {
                EditorGUILayout.Space(24);
                field_rect.y += 24;
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

        public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
        {
            if (prop.type == MaterialProperty.PropType.Vector)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = prop.vectorValue[i];
                }
                string[] split = label.Split("/");
                labels = new string[5];
                for (int i = 0; i < labels.Length; i++)
                {
                    if (i < split.Length)
                    {
                        labels[i] = split[i];
                    }
                    else
                    {
                        labels[i] = "";
                    }
                }

                label_contents = new GUIContent[4]{
                    new GUIContent(labels[1]),
                    new GUIContent(labels[2]),
                    new GUIContent(labels[3]),
                    new GUIContent(labels[4])
                };

                using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        Rect label_rect = new Rect(position);
                        label_rect.width = EditorGUIUtility.labelWidth;
                        field_rect = EditorGUI.PrefixLabel(label_rect, new GUIContent(labels[0]));
                        field_rect.width += position.width - label_rect.width;
                        using (new EditorGUILayout.VerticalScope())
                        {
                            drawing_count = 0;
                            EditorGUI.showMixedValue = prop.hasMixedValue;
                            if (0 < vertical_field0.Length) VerticalFieldDraw(vertical_field0);
                            if (0 < vertical_field1.Length) VerticalFieldDraw(vertical_field1);
                            if (0 < vertical_field2.Length) VerticalFieldDraw(vertical_field2);
                            if (0 < vertical_field3.Length) VerticalFieldDraw(vertical_field3);
                            EditorGUI.showMixedValue = false;
                        }
                    }
                    if (changeCheckScope.changed)
                    {
                        prop.vectorValue = new Vector4(values[0], values[1], values[2], values[3]);
                    }
                }
            }
            else
            {
                EditorGUILayout.LabelField("WARNING! Invalid property attachment attribute.");
            }
        }
    }

    public class DFToggleDrawer : MaterialPropertyDrawer
    {
        bool toggle_left_side;
        string keyword;
        public DFToggleDrawer(string keyword, float b = 0)
        {
            this.keyword = keyword;
            this.toggle_left_side = b != 0;
        }
        public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor) => 0;
        public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
        {
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                bool value = prop.floatValue != 0.0f;
                EditorGUI.showMixedValue = prop.hasMixedValue;
                if (toggle_left_side)
                {
                    value = EditorGUILayout.ToggleLeft(label, value);
                }
                else
                {
                    value = EditorGUILayout.Toggle(label, value);
                }
                EditorGUI.showMixedValue = false;
                if (changeCheckScope.changed)
                {
                    prop.floatValue = value ? 1.0f : 0.0f;
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
        public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor) => 0;

        public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
        {
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                ColorWriteMask value = (ColorWriteMask)(int)prop.floatValue;
                EditorGUI.showMixedValue = prop.hasMixedValue;
                value = (ColorWriteMask)EditorGUILayout.EnumFlagsField(label, value);
                EditorGUI.showMixedValue = false;
                if (changeCheckScope.changed)
                {
                    if ((int)value == -1)
                    {
                        prop.floatValue = 15.0f;
                    }
                    else
                    {
                        prop.floatValue = (float)value;
                    }
                }
            }
        }
    }
    public class DFLineAnimationMode : MaterialPropertyDrawer
    {
        public DFLineAnimationMode() { }
        public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor) => 0;

        enum LINE_ANIMATION_MODE
        {
            NORMAL,
            ZOOM_IN,
            ZOOM_OUT,
            POWER_ZOOM_IN,
            COLLAPSE,
            BREAK,
            OUT_WIDE,
            OUT_THIN,
            VANISHING,
            JOIN_1,
            JOIN_2,
            JOIN_3
        };

        public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
        {
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                LINE_ANIMATION_MODE mode = (LINE_ANIMATION_MODE)(int)prop.floatValue;
                EditorGUI.showMixedValue = prop.hasMixedValue;
                mode = (LINE_ANIMATION_MODE)EditorGUILayout.EnumPopup(label, mode);
                EditorGUI.showMixedValue = false;
                if (changeCheckScope.changed)
                {
                    prop.floatValue = (float)mode;
                }
            }
        }
    }
    public class DFChronoTensityMode : MaterialPropertyDrawer
    {
        public DFChronoTensityMode() { }
        public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor) => 0;

        enum CHRONOTENSITY_MODE
        {
            NUDGING,
            FILTERED_NUDGING,
            DYNAMICS,
            FILTERED_DYNAMICS,
            HOLD,
            FILTERED_HOLD,
            INCREASES_WITH_LOUDER,
            INCREASES_WITH_QUITE
        };

        public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
        {
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                CHRONOTENSITY_MODE mode = (CHRONOTENSITY_MODE)(int)prop.floatValue;
                EditorGUI.showMixedValue = prop.hasMixedValue;
                mode = (CHRONOTENSITY_MODE)EditorGUILayout.EnumPopup(label, mode);
                EditorGUI.showMixedValue = false;
                if (changeCheckScope.changed)
                {
                    prop.floatValue = (float)mode;
                }
            }
        }
    }
}

#endif