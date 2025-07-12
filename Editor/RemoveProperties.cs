#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor{
    public class RemoveProperties
    {
        public RemoveProperties(Material m)
        {
            SerializedObject mat = new SerializedObject(m);
            mat.Update();
            SerializedProperty props = mat.FindProperty("m_SavedProperties");

            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField(MeshHologramInspector.LocalizationSystem.PropLangDic["label.remove_unused_properties"]);
                using (new EditorGUILayout.VerticalScope())
                {
                    if (GUILayout.Button(MeshHologramInspector.LocalizationSystem.PropLangDic["label.texture_properties"], new GUIStyle("miniButton")))
                    {
                        if (EditorUtility.DisplayDialog(
                            MeshHologramInspector.LocalizationSystem.PropLangDic["label.remove_unused_properties"],
                            MeshHologramInspector.LocalizationSystem.PropLangDic["text.remove_texture_properties_text"],
                            MeshHologramInspector.LocalizationSystem.PropLangDic["text.remove"],
                            MeshHologramInspector.LocalizationSystem.PropLangDic["text.cancel"]))
                        {
                            RemoveTextures();
                            mat.ApplyModifiedProperties();
                        }
                    }
                    if (GUILayout.Button(MeshHologramInspector.LocalizationSystem.PropLangDic["label.all_properties"], new GUIStyle("miniButton")))
                    {
                        if (EditorUtility.DisplayDialog(
                            MeshHologramInspector.LocalizationSystem.PropLangDic["label.remove_unused_properties"],
                            MeshHologramInspector.LocalizationSystem.PropLangDic["text.remove_all_properties_text"],
                            MeshHologramInspector.LocalizationSystem.PropLangDic["text.remove"],
                            MeshHologramInspector.LocalizationSystem.PropLangDic["text.cancel"]))
                        {
                            RemoveTextures();
                            RemoveVariableProperties();
                            mat.ApplyModifiedProperties();
                        }
                    }
                }
            }
            void RemoveTextures()
            {
                RemoveUnusedProperties(props.FindPropertyRelative("m_TexEnvs"));

            }
            void RemoveVariableProperties()
            {
                RemoveUnusedProperties(props.FindPropertyRelative("m_Floats"));
                RemoveUnusedProperties(props.FindPropertyRelative("m_Colors"));
            }
            void RemoveUnusedProperties(SerializedProperty props)
            {
                for (int i = props.arraySize - 1; i >= 0; i--)
                {
                    string name = props.GetArrayElementAtIndex(i).FindPropertyRelative("first").stringValue;
                    if (!m.HasProperty(name))
                    {
                        props.DeleteArrayElementAtIndex(i);
                    }
                }
            }
        }
    }
}

#endif