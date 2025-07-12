#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public sealed class MeshBoundsEditor : EditorWindow
    {
        private static MeshFilter Target;
        private Mesh Source;
        private Mesh mesh_before;
        private Mesh mesh_preview;
        private GameObject Guide;

        private Bounds bounds;
        private static Vector3 center;
        private static Vector3 size;

        private bool update_preview = false;

        [MenuItem("Tools/DeltaField/Mesh Bounds Editor")]
        public static void Window()
        {
            MeshBoundsEditor window = GetWindow<MeshBoundsEditor>();
            window.Show();
        }

        private void OnGUI()
        {
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.Space(16);
                MeshFilter ChangeTarget = (MeshFilter)EditorGUILayout.ObjectField("Target", Target, typeof(MeshFilter), true);
                if (Target != ChangeTarget)
                {
                    if (Target != null && Source != null)
                    {
                        if (EditorUtility.DisplayDialog(
                            "Changing Target",
                            "Changing the Target will reset the Bounds",
                            "OK",
                            "Cancel"))
                        {
                            update_preview = true;
                        }
                        else
                        {
                            ChangeTarget = Target;
                        }
                    }
                    Target = ChangeTarget;
                }

                EditorGUILayout.Space(16);
                Mesh ChangeSource = (Mesh)EditorGUILayout.ObjectField("Mesh", Source, typeof(Mesh), false);
                if (Source != ChangeSource)
                {
                    if (Target != null && Source != null)
                    {
                        if (EditorUtility.DisplayDialog(
                            "Changing Source",
                            "Changing the Source will reset the Bounds",
                            "OK",
                            "Cancel"))
                        {
                            update_preview = true;
                        }
                        else
                        {
                            ChangeSource = Source;
                        }
                    }
                    Source = ChangeSource;
                }

                if (mesh_preview == null && Target != null && Source != null)
                {
                    update_preview = true;
                }
                else if (mesh_preview != null && (Target == null || Source == null))
                {
                    update_preview = false;
                    OnDestroy();
                }

                if (update_preview == true)
                {
                    Preview();
                    update_preview = false;
                }

                EditorGUILayout.Space(16);

                if (mesh_preview != null)
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("Bounds");
                        using (new EditorGUILayout.VerticalScope())
                        {
                            bounds.center = mesh_preview.bounds.center;
                            bounds.size = mesh_preview.bounds.size;
                            if (GUILayout.Button("Reset Default"))
                            {
                                bounds.center = Source.bounds.center;
                                bounds.size = Source.bounds.size;
                            }
                            using (new EditorGUILayout.HorizontalScope())
                            {
                                if (GUILayout.Button("Size x2")) bounds.size *= 2.0f;
                                if (GUILayout.Button("Size x0.5")) bounds.size *= 0.5f;
                            }
                            bounds.center = EditorGUILayout.Vector3Field("Center", bounds.center);
                            bounds.size = EditorGUILayout.Vector3Field("Size", bounds.size);
                        }
                    }
                    if (GUILayout.Button("Export"))
                    {
                        if (EditorUtility.DisplayDialog(
                            "Export Mesh",
                            "Save the mesh you have set.",
                            "OK",
                            "Cancel"
                        ))
                        {
                            string path = EditorUtility.SaveFilePanel("Create Mesh", "", mesh_preview.name, "mesh");

                            if (!string.IsNullOrEmpty(path))
                            {
                                path = path.Replace("\\", "/").Replace(Application.dataPath, "Assets");
                                AssetDatabase.CreateAsset(mesh_preview, path);
                                AssetDatabase.Refresh();
                                mesh_before = AssetDatabase.LoadAssetAtPath<Mesh>(path);
                                EditorUtility.SetDirty(mesh_before);
                                Target.sharedMesh = mesh_before;
                                Source = mesh_before;
                                mesh_preview = null;
                                DestroyImmediate(Guide);
                            }
                        }
                    }
                }

                if (changeCheckScope.changed)
                {
                    if (mesh_preview != null)
                    {
                        Undo.RecordObjects(new Object[] { mesh_preview, Guide.transform }, "Mesh Bounds Editor Bounds");
                        mesh_preview.bounds = bounds;
                        Guide.transform.localPosition = bounds.center;
                        Guide.transform.localScale = bounds.size;
                    }
                }
            }
        }

        private void Preview()
        {
            if (Guide != null) DestroyImmediate(Guide);
            if (mesh_before == null) mesh_before = Target.sharedMesh;
            mesh_preview = Instantiate(Source);
            Target.sharedMesh = mesh_preview;
            bounds = mesh_preview.bounds;

            Guide = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Guide.name = "BoundGuide(DON'T DELETE!)";
            Guide.transform.SetParent(Target.transform);
            Material guide_m = new Material(Shader.Find("DeltaField/shaders/MeshHologram/bounds_guide"));
            guide_m.renderQueue = 3999;
            Guide.GetComponent<Renderer>().sharedMaterial = guide_m;
            Guide.transform.localPosition = bounds.center;
            Guide.transform.localScale = bounds.size;

        }

        private void OnEnable()
        {
            Undo.undoRedoPerformed += Repaint;
        }

        private void OnDestroy()
        {
            if (mesh_before != null)
            {
                if (Target != null) Target.mesh = mesh_before;
                mesh_before = null;
            }
            if (Guide != null) DestroyImmediate(Guide);
            mesh_preview = null;
            Undo.undoRedoPerformed -= Repaint;
        }
    }
}

#endif