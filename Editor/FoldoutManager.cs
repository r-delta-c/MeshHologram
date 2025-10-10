#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor {
    internal class FoldoutManager
    {
        private Dictionary<FOLDOUT, FoldoutState> FoldoutList = new Dictionary<FOLDOUT, FoldoutState>();
        internal FoldoutManager()
        {
            FoldoutList.Add(FOLDOUT.RENDERING, new FoldoutState(new string[1] { "label.rendering" }));
            FoldoutList.Add(FOLDOUT.RENDERING_OTHER, new FoldoutState(new string[1] { "label.other_renderings" }));
            FoldoutList.Add(FOLDOUT.STENCIL, new FoldoutState(new string[1] { "label.stencil" }));
            FoldoutList.Add(FOLDOUT.AUDIOLINK, new FoldoutState(new string[1] { "label.audiolink" }));
            FoldoutList.Add(FOLDOUT.FRAGMENT, new FoldoutState(new string[1] { "label.fragment" }));
            FoldoutList.Add(FOLDOUT.COLOR, new FoldoutState(new string[1] { "label.color" }));
            FoldoutList.Add(FOLDOUT.GEOMETRY, new FoldoutState(new string[1] { "label.geometry" }));
            FoldoutList.Add(FOLDOUT.ORBIT, new FoldoutState(new string[1] { "label.orbit" }));
            FoldoutList.Add(FOLDOUT.MASK_OFFSET, new FoldoutState(new string[6]{
                "label.fragment.mask_offset",
                "label.coloring.mask_offset",
                "label.geometry.mask_offset",
                "label.orbit.mask_offset",
                "label.orbit_rotation.mask_offset",
                "label.orbit_rotation_offset.mask_offset"
            }, 6));
            FoldoutList.Add(FOLDOUT.SOURCE, new FoldoutState(new string[6]{
                "label.fragment.source",
                "label.coloring.source",
                "label.geometry.source",
                "label.orbit.source",
                "label.orbit_rotation.source",
                "label.orbit_rotation_offset.source"
            }, 6));
            FoldoutList.Add(FOLDOUT.AUDIOLINK_SOURCE, new FoldoutState(new string[6]{
                "label.fragment.audiolink_source",
                "label.coloring.audiolink_source",
                "label.geometry.audiolink_source",
                "label.orbit.audiolink_source",
                "label.orbit_rotation.audiolink_source",
                "label.orbit_rotation_offset.audiolink_source"
            }, 6));
            FoldoutList.Add(FOLDOUT.MODIFIER, new FoldoutState(new string[6]{
                "label.fragment.modifier",
                "label.coloring.modifier",
                "label.geometry.modifier",
                "label.orbit.modifier",
                "label.orbit_rotation.modifier",
                "label.orbit_rotation_offset.modifier"
            }, 6));
            FoldoutList.Add(FOLDOUT.OTHERS, new FoldoutState(new string[1] { "label.others" }));
        }

        internal bool MenuFoldout(FOLDOUT foldout, bool bold = true, int owner = 0)
        {
            string AttributeText(string text)
            {
                if (bold)
                {
                    return "<b><color=#ffffff>" + text + "</color></b>";
                }
                else
                {
                    return "<color=#ffffff>" + text + "</color>";
                }
            }
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.MiddleLeft;
            style.richText = true;
            string head;
            style.padding = new RectOffset(1, 0, 0, 2);

            Rect rec = GUILayoutUtility.GetRect(new GUIContent(), style);
            EditorGUI.DrawRect(rec, Color.clear);

            bool b = FoldoutList[foldout].is_open[owner];

            if (Event.current.type == EventType.MouseDown && rec.Contains(Event.current.mousePosition))
            {
                b = !b;
                FoldoutList[foldout].is_open[owner] = b;
                GUI.changed = true;
                Event.current.Use();
            }

            if (bold)
            {
                style.fontSize = 16;
                head = b ? "v" : "<b>></b>";
            }
            else
            {
                style.fontSize = 12;
                head = b ? "v" : ">";
            }

            GUI.Label(rec, "<color=#ffffff>" + head + "</color>", style);
            style.fontSize = 12;
            style.padding = new RectOffset(18, 0, 0, 0);
            GUI.Label(rec, AttributeText(FoldoutList[foldout].display[owner]), style);
            return b;
        }
        internal void UpdateLocalization()
        {
            foreach (KeyValuePair<FOLDOUT,FoldoutState> f in FoldoutList)
            {
                f.Value.UpdateLocalization();
            }
        }
    }
    internal class FoldoutState
    {
        internal string[] display;
        internal readonly List<string> localized_text = new List<string>();
        internal List<bool> is_open = new List<bool>();
        internal FoldoutState(string[] t, int order = 1)
        {
            for (int i = 0; i < order; i++)
            {
                is_open.Add(false);
                int text_index;
                if (i < t.Length)
                {
                    text_index = i;
                }
                else
                {
                    text_index = t.Length - 1;
                }
                localized_text.Add(t[text_index]);
            }
            display = new string[localized_text.Count];
            UpdateLocalization();
        }
        internal void UpdateLocalization()
        {
            for (int i = 0; i < localized_text.Count; i++)
            {
                string text = localized_text[i];
                if (MeshHologramInspector.LocalizationSystem.PropLangDic.ContainsKey(text))
                {
                    display[i] = MeshHologramInspector.LocalizationSystem.PropLangDic[text];
                }
                else
                {
                    Debug.LogWarning("Could not get localized text. -> " + text);
                    display[i] = text;
                }
            }
        }
    }
}

#endif