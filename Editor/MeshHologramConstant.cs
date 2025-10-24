#if UNITY_EDITOR
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static class MeshHologramConstant{
        public static readonly string resolve_path = UnityEditor.PackageManager.PackageInfo.FindForAssetPath("Packages/com.deltafield.meshhologram").resolvedPath;
    }
}

#endif