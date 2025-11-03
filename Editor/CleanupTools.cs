#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramInspector;
using static DeltaField.Shaders.MeshHologram.Editor.Initializer;

namespace DeltaField.Shaders.MeshHologram.Editor{
    public static class CleanupTools
    {
        private static SerializedObject serialized_mat;
        private static SerializedProperty props;
        public static void DrawCleanupTools(Material[] materials)
        {
            if (IsInitialized == false) return;

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
                            foreach(Material m in materials)
                            {
                                SerializationMaterial(m);
                                RemoveTextures(m);
                                serialized_mat.ApplyModifiedProperties();
                            }
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
                            foreach (Material m in materials)
                            {
                                SerializationMaterial(m);
                                RemoveTextures(m);
                                RemoveVariableProperties(m);
                                serialized_mat.ApplyModifiedProperties();
                            }
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
                            foreach(Material m in materials)
                            {
                                Undo.RecordObject(m, "Remove Unused Keywords");
                                RemoveUnusedKeywords(m);
                                EditorUtility.SetDirty(m);
                            }
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                        }
                    }
                }
            }
            void SerializationMaterial(Material m)
            {
                serialized_mat = new SerializedObject(m);
                serialized_mat.Update();
                props = serialized_mat.FindProperty("m_SavedProperties");
            }
            void RemoveTextures(Material m)
            {
                RemoveUnusedProperties(props.FindPropertyRelative("m_TexEnvs"),m);

            }
            void RemoveVariableProperties(Material m)
            {
                RemoveUnusedProperties(props.FindPropertyRelative("m_Floats"),m);
                RemoveUnusedProperties(props.FindPropertyRelative("m_Colors"),m);
            }
            void RemoveUnusedProperties(SerializedProperty props, Material m)
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
            void RemoveUnusedKeywords(Material m)
            {
                LocalKeyword[] LocalKeywords = m.shader.keywordSpace.keywords;
                List<string> keywords = m.shaderKeywords.ToList();
                List<string> apply_keyword = new List<string>();
                foreach (LocalKeyword valid_keyword in LocalKeywords)
                {
                    foreach(string keyword in keywords)
                    {
                        if (valid_keyword.name == keyword) apply_keyword.Add(keyword);
                    }
                }
                m.shaderKeywords = apply_keyword.ToArray();
            }
        }
    }
}

#endif