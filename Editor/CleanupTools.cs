#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramInspector;

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
                EditorGUILayout.LabelField(LocalizationManager.GetLocalizeText("label.data_cleanup"));
                using (new EditorGUILayout.VerticalScope())
                {
                    if (GUILayout.Button(LocalizationManager.GetLocalizeText("label.texture_properties"), new GUIStyle("miniButton")))
                    {
                        if (EditorUtility.DisplayDialog(
                            LocalizationManager.GetLocalizeText("label.data_cleanup"),
                            LocalizationManager.GetLocalizeText("dialog.remove_unused_textures.text"),
                            LocalizationManager.GetLocalizeText("dialog.remove"),
                            LocalizationManager.GetLocalizeText("dialog.cancel")))
                        {
                            RemoveTextures();
                            mat.ApplyModifiedProperties();
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                        }
                    }
                    if (GUILayout.Button(LocalizationManager.GetLocalizeText("label.all_properties"), new GUIStyle("miniButton")))
                    {
                        if (EditorUtility.DisplayDialog(
                            LocalizationManager.GetLocalizeText("label.data_cleanup"),
                            LocalizationManager.GetLocalizeText("dialog.remove_unused_properties.text"),
                            LocalizationManager.GetLocalizeText("dialog.remove"),
                            LocalizationManager.GetLocalizeText("dialog.cancel")))
                        {
                            RemoveTextures();
                            RemoveVariableProperties();
                            mat.ApplyModifiedProperties();
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                        }
                    }
                    if (GUILayout.Button(LocalizationManager.GetLocalizeText("label.unused_keywords"), new GUIStyle("miniButton")))
                    {
                        if (EditorUtility.DisplayDialog(
                            LocalizationManager.GetLocalizeText("label.data_cleanup"),
                            LocalizationManager.GetLocalizeText("dialog.remove_unused_keywords.text"),
                            LocalizationManager.GetLocalizeText("dialog.remove"),
                            LocalizationManager.GetLocalizeText("dialog.cancel")))
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