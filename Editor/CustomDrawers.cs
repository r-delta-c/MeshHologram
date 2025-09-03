#if UNITY_EDITOR

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
        public DFVectorDrawer()
        {
            Init(new int[] { 4 });
        }
        public DFVectorDrawer(float c0)
        {
            Init(new int[] { (int)c0 });
        }
        public DFVectorDrawer(float c0, float c1)
        {
            Init(new int[] { (int)c0, (int)c1 });
        }
        public DFVectorDrawer(float c0, float c1, float c2)
        {
            Init(new int[] { (int)c0, (int)c1, (int)c2 });
        }
        public DFVectorDrawer(float c0, float c1, float c2, float c3)
        {
            Init(new int[] { (int)c0, (int)c1, (int)c2, (int)c3 });
        }

        private void Init(int[] ints)
        {
            int t = 0;
            foreach (int i in ints)
            {
                t += Mathf.Clamp(i, 0, 4);
            }
            total = t;
            if (4 < total)
            {
                Debug.LogWarning("The attribute argument is out of range of the Vector sum element.");
                total = Mathf.Clamp(total, 0, 4);
            }
            if (0 < ints.Length) vertical_field0 = new uint[ints[0]];
            if (1 < ints.Length) vertical_field1 = new uint[ints[1]];
            if (2 < ints.Length) vertical_field2 = new uint[ints[2]];
            if (3 < ints.Length) vertical_field3 = new uint[ints[3]];
        }

        private float[] VerticalFieldDraw(uint[] vertical_field, int count, Rect position)
        {
            if (vertical_field == null) return null;
            if (0 < count) EditorGUILayout.Space(24);
            using (new EditorGUILayout.HorizontalScope())
            {
                int row = vertical_field.Length;
                float[] field_values = new float[vertical_field.Length];
                GUIContent[] contents = new GUIContent[vertical_field.Length];
                for (int i = 0; i < vertical_field.Length; i++)
                {
                    field_values[i] = values[i + count];
                    contents[i] = label_contents[i + count];
                }
                EditorGUI.MultiFloatField(position, contents, field_values);
                return field_values;
            }
        }

        private int AssignValues(float[] source, int count)
        {
            if (source == null) return count;
            int count_r = count;
            for (int i = 0; i < source.Length; i++)
            {
                values[i + count] = source[i];
                count_r++;
            }
            return count_r;
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
                        Rect field_rect = EditorGUI.PrefixLabel(label_rect, new GUIContent(labels[0]));
                        field_rect.width += position.width - label_rect.width;
                        using (new EditorGUILayout.VerticalScope())
                        {
                            EditorGUI.showMixedValue = prop.hasMixedValue;
                            int count = 0;
                            count = AssignValues(VerticalFieldDraw(vertical_field0, count, field_rect), count);
                            field_rect.y += 24;
                            count = AssignValues(VerticalFieldDraw(vertical_field1, count, field_rect), count);
                            field_rect.y += 24;
                            count = AssignValues(VerticalFieldDraw(vertical_field2, count, field_rect), count);
                            field_rect.y += 24;
                            count = AssignValues(VerticalFieldDraw(vertical_field3, count, field_rect), count);
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
        public DFColorMask()
        { }

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
}

#endif