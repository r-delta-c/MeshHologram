#if UNITY_EDITOR
using System;
using UnityEditor;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramConstant;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static class Initializer{
        public static bool IsInitialized { get; private set; }
        public static event Action OnInitialized;

        [InitializeOnLoadMethod]
        internal static void WaitForInit()
        {
            EditorApplication.update += Init;
        }

        private static void Init()
        {
            if (packageInfo != null)
            {
                IsInitialized = true;
                EditorApplication.update -= Init;
                OnInitialized?.Invoke();
            }
        }
    }
}

#endif