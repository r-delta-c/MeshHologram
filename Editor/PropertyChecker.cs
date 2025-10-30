#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramInspector;
using static DeltaField.Shaders.MeshHologram.Editor.Initializer;
using System;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public sealed class PropertyChecker : EditorWindow
    {
        private static Material targetMat;
        private static bool refresh_list;
        private static bool checked_material;
        private static bool out_of_supported_shader;
        static private LANG lang;
        private static Dictionary<MESHHOLOGRAM_PROP_ENUM, ShaderPropertyState> TargetProps = MeshHologramManager.MeshHologramProps;
        private static List<Tuple<MessageType,string>> InfoList = new List<Tuple<MessageType, string>>();
        private Vector2 scroll = Vector2.zero;


        [MenuItem("Tools/DeltaField/Property Checker")]
        public static void Window()
        {
            PropertyChecker window = GetWindow<PropertyChecker>();
            window.Show();
        }

        public static void SetMaterial(Material m)
        {
            targetMat = m;
            checked_material = false;
        }

        private void OnGUI()
        {
            if (IsInitialized == false) return;
            LocalizationManager.DrawLanguageEnumPopup();
            EditorGUILayout.Space(16);
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                targetMat = (Material)EditorGUILayout.ObjectField(LocalizationManager.GetLocalizeText("text.target"), targetMat, typeof(Material), true);
                if (targetMat == null)
                {
                    checked_material = false;
                    return;
                }
                string button_l = "";
                if (checked_material) button_l = LocalizationManager.GetLocalizeText("label.recheck");
                else button_l = LocalizationManager.GetLocalizeText("label.check");
                if (refresh_list == false) refresh_list = GUILayout.Button(button_l);
                EditorGUILayout.Space(16);

                if (changeCheckScope.changed)
                {
                    refresh_list = true;
                }

                if (refresh_list)
                {
                    InfoList.Clear();
                    foreach (MESHHOLOGRAM_PROP_ENUM key in TargetProps.Keys)
                    {
                        if (key == MESHHOLOGRAM_PROP_ENUM._DUMMY) continue;
                        TargetProps[key].var = MaterialEditor.GetMaterialProperty(new UnityEngine.Object[] { targetMat }, TargetProps[key].property);
                        TargetProps[key].display = LocalizationManager.GetLocalizeText(TargetProps[key].property);
                    }
                    refresh_list = false;
                    out_of_supported_shader = false;
                    checked_material = true;
                    CheckProperty();
                }

                if (!checked_material) return; 
                using (var scrollView = new EditorGUILayout.ScrollViewScope(scroll))
                {
                    scroll = scrollView.scrollPosition;
                    if (InfoList.Count == 0 && checked_material && !out_of_supported_shader) EditorGUILayout.HelpBox(new GUIContent(LocalizationManager.GetLocalizeText("property_check.no_problem.text")));
                    else if (out_of_supported_shader) EditorGUILayout.HelpBox(new GUIContent(LocalizationManager.GetLocalizeText("property_check.out_of_supported_shader.text")));
                    else
                    {
                        foreach (Tuple<MessageType, string> info in InfoList)
                        {
                            EditorGUILayout.HelpBox(info.Item2, info.Item1);
                        }
                    }
                }
            }
        }

        private void CheckProperty()
        {
            if (targetMat.shader.name != "DeltaField/shaders/MeshHologram")
            {
                out_of_supported_shader = true;
                return;
            }
            if (TargetProps[MESHHOLOGRAM_PROP_ENUM._COLOR_MASK].var.floatValue != 15)
            {
                InfoList.Add(new Tuple<MessageType, string>(MessageType.Warning,
                    String.Format(LocalizationManager.GetLocalizeText("property_check.colormask_not_all.text"),
                    TargetProps[MESHHOLOGRAM_PROP_ENUM._COLOR_MASK].display)
                ));
            }

            if (CheckBlendProperties()) InfoList.Add(new Tuple<MessageType, string>(MessageType.Warning,
                LocalizationManager.GetLocalizeText("property_check.unique_blend.text")+"\n" +
                "Blend OP: Add\nSrc Blend: SrcAlpha\nDst Blend: OneMinusSrcAlpha\n" +
                "Blend OP Alpha: Add\nSrc Blend Alpha: SrcAlpha\nDst Blend Alpha: OneMinusSrcAlpha"
                ));

            if (TargetProps[MESHHOLOGRAM_PROP_ENUM._STENCIL_COMP].var.floatValue != 0) InfoList.Add(new Tuple<MessageType, string>(MessageType.Info,
                    String.Format(LocalizationManager.GetLocalizeText("text.category")+": {0}",LocalizationManager.GetLocalizeText("label.stencil"))+"\n"+
                    LocalizationManager.GetLocalizeText("label.stencil")+" "+String.Format(LocalizationManager.GetLocalizeText("property_check.stencil_enabled.text"),
                    TargetProps[MESHHOLOGRAM_PROP_ENUM._STENCIL_COMP].display,
                    LocalizationManager.GetLocalizeText("label.stencil")
                )));

            CheckModifierLoopMode(
                LocalizationManager.GetLocalizeText("label.fragment"),
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_SOURCE
            );

            CheckModifierLoopMode(
                LocalizationManager.GetLocalizeText("label.color"),
                MESHHOLOGRAM_PROP_ENUM._COLORING_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_SOURCE
            );

            CheckModifierLoopMode(
                LocalizationManager.GetLocalizeText("label.geometry"),
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_SOURCE
            );

            CheckModifierLoopMode(
                LocalizationManager.GetLocalizeText("label.orbit"),
                MESHHOLOGRAM_PROP_ENUM._ORBIT_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_SOURCE
            );
        }

        private bool CheckBlendProperties()
        {
            if (TargetProps[MESHHOLOGRAM_PROP_ENUM._BLEND_OP].var.floatValue != 0) return true;
            if (TargetProps[MESHHOLOGRAM_PROP_ENUM._SRC_BLEND].var.floatValue != 5) return true;
            if (TargetProps[MESHHOLOGRAM_PROP_ENUM._DST_BLEND].var.floatValue != 10) return true;
            if (TargetProps[MESHHOLOGRAM_PROP_ENUM._BLEND_OP_ALPHA].var.floatValue != 0) return true;
            if (TargetProps[MESHHOLOGRAM_PROP_ENUM._SRC_BLEND_ALPHA].var.floatValue != 5) return true;
            if (TargetProps[MESHHOLOGRAM_PROP_ENUM._DST_BLEND_ALPHA].var.floatValue != 10) return true;
            return false;
        }
        
        private void CheckModifierLoopMode(string block, MESHHOLOGRAM_PROP_ENUM loop_mode, MESHHOLOGRAM_PROP_ENUM source, MESHHOLOGRAM_PROP_ENUM audiolink_source)
        {
            string loop_mode_label = TargetProps[loop_mode].display;
            string source_label = TargetProps[source].display;
            string audiolink_source_label = TargetProps[audiolink_source].display;
            if (TargetProps[loop_mode].var.floatValue == 0)
            {
                if (TargetProps[source].var.floatValue == 1 || TargetProps[audiolink_source].var.floatValue == 3) InfoList.Add(new Tuple<MessageType, string>(MessageType.Warning,
                String.Format(LocalizationManager.GetLocalizeText("text.category")+": {0}",block)+"\n"+
                String.Format(LocalizationManager.GetLocalizeText("property_check.loop_mode_clip.text"),
                loop_mode_label,
                source_label,
                audiolink_source_label)));
            }
            else
            {
                if(TargetProps[source].var.floatValue != 1 && TargetProps[audiolink_source].var.floatValue != 3) InfoList.Add(new Tuple<MessageType, string>(MessageType.Warning,
                String.Format(LocalizationManager.GetLocalizeText("text.category")+": {0}",block)+"\n"+
                String.Format(LocalizationManager.GetLocalizeText("property_check.loop_mode_repeat.text"),
                loop_mode_label,
                source_label,
                audiolink_source_label)));
            }
        }
    }
}

#endif