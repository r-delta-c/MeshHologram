#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;

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
        private Material[] targetMats;
        private MaterialEditor editor;
        private MaterialProperty[] props;

        private static FoldoutManager FoldoutList;
        private static int MenuIndex,GeneralIndex,MainIndex,SubIndex,OrbitIndex;
        private static GUIContent[]
            MenuLabels = new GUIContent[3]{new GUIContent(),new GUIContent(),new GUIContent()},
            GeneralLabels = new GUIContent[3]{new GUIContent(),new GUIContent(),new GUIContent()},
            MainLabels = new GUIContent[4]{new GUIContent(),new GUIContent(),new GUIContent(),new GUIContent()},
            SubLabels = new GUIContent[4]{new GUIContent(),new GUIContent(),new GUIContent(),new GUIContent()},
            OrbitLabels = new GUIContent[4]{new GUIContent(),new GUIContent(),new GUIContent(),new GUIContent()};
        private static string[] MainCatsName = new string[5]{"_FRAGMENT","_COLORING","_GEOMETRY","_ORBIT","_ORBITROTATION"};

        private static GUILayoutOption MainGUIOption = GUILayout.MinHeight(240);
        private static LANG lang;

        private GradientMapManager gradientMapManager = new GradientMapManager();
        private Gradient gradient = new Gradient();

        private PreviewGraph PreviewGraph0;
        private bool InspectorInitialize = false;

        private MeshHologramToggleState EnableDirectionalLightInfluenceState = 
            new MeshHologramToggleState("_DIRECTIONALLIGHT_INFLUENCE_ENABLE","test");
        private MeshHologramToggleState EnableAmbientInfluenceState = 
            new MeshHologramToggleState("_AMBIENT_INFLUENCE_ENABLE","test");
        private MeshHologramToggleState EnableAudioLinkState = 
            new MeshHologramToggleState("_AUDIOLINK_ENABLE","test");
        private MeshHologramToggleState EnableLightVolumesState = 
            new MeshHologramToggleState("_LIGHTVOLUMES_ENABLE","test");
        private STEREO_MERGE_MODE[] StereoMergeMode = new STEREO_MERGE_MODE[2];
        private int[] NoiseLiteMode = new int[5], _NoiseLiteMode = new int[5];
        private bool[] ResetNoiseLiteMap = new bool[5];
        private int? ChangeNoiseLiteMode = null;
    }
}
#endif