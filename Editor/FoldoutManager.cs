#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramInspector;

namespace DeltaField.Shaders.MeshHologram.Editor {
    internal class FoldoutManager
    {
        private Dictionary<FOLDOUT, FoldoutState> FoldoutList = new Dictionary<FOLDOUT, FoldoutState>();
        internal FoldoutManager()
        {
            FoldoutList.Add(FOLDOUT.RENDERING_OTHER, new FoldoutState(new string[1] { "label.other_renderings" }));
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
                display[i] = LocalizationSystem.GetLocalizeText(text);
            }
        }
    }
}

#endif