#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace DeltaField.Shaders.MeshHologram.Editor{
    public class CleanupTools
    {
        public CleanupTools(Material m)
        {
            SerializedObject mat = new SerializedObject(m);
            mat.Update();
            SerializedProperty props = mat.FindProperty("m_SavedProperties");

            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField(MeshHologramInspector.LocalizationSystem.GetLocalizeText("label.data_cleanup"));
                using (new EditorGUILayout.VerticalScope())
                {
                    if (GUILayout.Button(MeshHologramInspector.LocalizationSystem.GetLocalizeText("label.texture_properties"), new GUIStyle("miniButton")))
                    {
                        if (EditorUtility.DisplayDialog(
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("label.data_cleanup"),
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("text.remove_unused_textures_text"),
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("text.remove"),
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("text.cancel")))
                        {
                            RemoveTextures();
                            mat.ApplyModifiedProperties();
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                        }
                    }
                    if (GUILayout.Button(MeshHologramInspector.LocalizationSystem.GetLocalizeText("label.all_properties"), new GUIStyle("miniButton")))
                    {
                        if (EditorUtility.DisplayDialog(
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("label.data_cleanup"),
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("text.remove_unused_properties_text"),
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("text.remove"),
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("text.cancel")))
                        {
                            RemoveTextures();
                            RemoveVariableProperties();
                            mat.ApplyModifiedProperties();
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                        }
                    }
                    if (GUILayout.Button(MeshHologramInspector.LocalizationSystem.GetLocalizeText("label.unused_keywords"), new GUIStyle("miniButton")))
                    {
                        if (EditorUtility.DisplayDialog(
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("label.data_cleanup"),
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("text.remove_unused_keywords_text"),
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("text.remove"),
                            MeshHologramInspector.LocalizationSystem.GetLocalizeText("text.cancel")))
                        {
                            RemoveUnusedKeywords(m);
                            mat.ApplyModifiedProperties();
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
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
            void RemoveUnusedKeywords(Material mat)
            {
                LocalKeyword[] LocalKeywords = mat.shader.keywordSpace.keywords;
                List<string> keywords = mat.shaderKeywords.ToList();
                List<string> apply_keyword = new List<string>();
                foreach (LocalKeyword valid_keyword in LocalKeywords)
                {
                    foreach(string keyword in keywords)
                    {
                        if (valid_keyword.name == keyword)
                        {
                            apply_keyword.Add(keyword);
                        }
                    }
                }
                mat.shaderKeywords = apply_keyword.ToArray();
            }
        }
    }
}

#endif