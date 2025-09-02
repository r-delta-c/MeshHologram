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
            FoldoutList.Add(FOLDOUT.RENDERING, new FoldoutState("label.rendering"));
            FoldoutList.Add(FOLDOUT.RENDERING_OTHER, new FoldoutState("label.other_renderings"));
            FoldoutList.Add(FOLDOUT.STENCIL, new FoldoutState("label.stencil"));
            FoldoutList.Add(FOLDOUT.AUDIOLINK, new FoldoutState("label.audiolink"));
            FoldoutList.Add(FOLDOUT.FRAGMENT, new FoldoutState("label.fragment"));
            FoldoutList.Add(FOLDOUT.COLOR, new FoldoutState("label.color"));
            FoldoutList.Add(FOLDOUT.GEOMETRY, new FoldoutState("label.geometry"));
            FoldoutList.Add(FOLDOUT.ORBIT, new FoldoutState("label.orbit"));
            FoldoutList.Add(FOLDOUT.NOISE1ST, new FoldoutState("label.noise1st_properties", 5));
            FoldoutList.Add(FOLDOUT.NOISE2ND, new FoldoutState("label.noise2nd_properties", 5));
            FoldoutList.Add(FOLDOUT.NOISE3RD, new FoldoutState("label.noise3rd_properties", 5));
            FoldoutList.Add(FOLDOUT.OTHERS, new FoldoutState("label.others"));
            UpdateLocalization();
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
            GUI.Label(rec, AttributeText(FoldoutList[foldout].localized_text), style);
            return b;
        }
        internal void UpdateLocalization()
        {
            foreach (FOLDOUT foldout in FoldoutList.Keys)
            {
                string text = FoldoutList[foldout].text;
                if (MeshHologramInspector.LocalizationSystem.PropLangDic.ContainsKey(text))
                {
                    FoldoutList[foldout].localized_text = MeshHologramInspector.LocalizationSystem.PropLangDic[text];
                }
                else
                {
                    Debug.LogWarning("Could not get localized text. -> " + text);
                    FoldoutList[foldout].localized_text = text;
                }
            }
        }
    }
    public class FoldoutState
    {
        public readonly string text;
        public string localized_text;
        public List<bool> is_open = new List<bool>();
        public FoldoutState(string t, int order = 1)
        {
            text = t;
            for (int i = 0; i < order; i++)
            {
                is_open.Add(false);
            }
        }
    }
}

#endif