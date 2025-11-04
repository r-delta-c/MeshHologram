#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static class MeshHologramConstant
    {
        public static string resolve_path { get; private set; }
        public static UnityEditor.PackageManager.PackageInfo packageInfo { get; private set; }

        [InitializeOnLoadMethod]
        private static void WaitForPackage()
        {
            EditorApplication.update += CheckPackageInfo;
        }

        private static void CheckPackageInfo()
        {
            packageInfo = UnityEditor.PackageManager.PackageInfo.FindForAssetPath("Packages/com.deltafield.meshhologram");
            if (packageInfo != null)
            {
                resolve_path = packageInfo.resolvedPath.Replace("\\","/");
                EditorApplication.update -= CheckPackageInfo;
            }
        }
    }
}

#endif