#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DeltaField.Shaders.MeshHologram.Editor {
    public partial class MeshHologramInspector : ShaderGUI
    {
        [MenuItem("Assets/Create/DeltaField/MeshHologram", priority = 0)]
        private static void CreateMaterial()
        {
            Material m = new Material(MeshHologramManager.shader);
            ProjectWindowUtil.CreateAsset(m, $"New MeshHologram.mat");
        }

        private Material targetMat;
        private MaterialEditor editor;
        private MaterialProperty[] props;
        static private ConfigManager Config;

        static internal LocalizationManager LocalizationSystem;
        static private FoldoutManager FoldoutList;
        static private RichTitle ShaderTitle = new RichTitle();
        static private int MenuIndex,GeneralIndex,MainIndex,SubIndex,OrbitIndex;
        static private GUIContent[]
            MenuLabels = new GUIContent[3]{new GUIContent(),new GUIContent(),new GUIContent()},
            GeneralLabels = new GUIContent[3]{new GUIContent(),new GUIContent(),new GUIContent()},
            MainLabels = new GUIContent[4]{new GUIContent(),new GUIContent(),new GUIContent(),new GUIContent()},
            SubLabels = new GUIContent[4]{new GUIContent(),new GUIContent(),new GUIContent(),new GUIContent()},
            OrbitLabels = new GUIContent[4]{new GUIContent(),new GUIContent(),new GUIContent(),new GUIContent()};
        static private GUILayoutOption MainGUIOption = GUILayout.MinHeight(240);
        static private LANG lang;
        static private LANG current_lang;
        static private TITLE_SKINS current_title_skin;
        private CleanupTools cleanup_tool;

        private GradientMapManager gradientMapManager = new GradientMapManager();
        private Gradient gradient = new Gradient();

        private PreviewGraph PreviewGraph0;

        static private bool Initialize = false;
        private bool InspectorInitialize = false;
    }
}
#endif