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
            Material m = new Material(Shader.Find("DeltaField/shaders/MeshHologram"));
            ProjectWindowUtil.CreateAsset(m, $"New MeshHologram.mat");
        }

        private Material targetMat;
        private MaterialEditor editor;
        private MaterialProperty[] props;
        static private ConfigManager Config;

        static internal LocalizationManager LocalizationSystem;
        static private Dictionary<SHADER_PROPERTY, ShaderPropertyState> ShaderProperties;
        static private FoldoutManager FoldoutList;
        static private RichTitle ShaderTitle = new RichTitle();
        static private LANG lang;
        static private LANG current_lang;
        static private TITLE_SKINS current_title_skin;
        private CleanupTools RemoveProp;

        private GradientMapManager gradientMapManager = new GradientMapManager();
        private Gradient gradient = new Gradient();

        private PreviewGraph PreviewGraph0;

        static private bool Initialize = false;
        private bool InspectorInitialize = false;

        private bool foldout_bool;
    }
}
#endif