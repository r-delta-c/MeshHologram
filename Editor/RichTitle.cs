#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static class RichTitle
    {
        private static TITLE_SKINS title_skin = ConfigManager.title_skin;
        public static TITLE_SKINS current_title_skin = ConfigManager.title_skin;
        private static Texture2D bomb = InitBomb();
        private static int[] CharTimeLimit = new int[13];

        public static Texture2D InitBomb()
        {
            Texture2D r = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/com.deltafield.meshhologram/Editor/resources/bomb.png");
            if (r == null)
            {
                r = new Texture2D(1, 1);
                r.SetPixel(1, 1, Color.magenta);
                r.Apply();
            }
            return r;
        }

        public static void DrawTitle()
        {
            switch (ConfigManager.title_skin)
            {
                case TITLE_SKINS.NORMAL:
                    SkinNORMAL();
                    break;
                case TITLE_SKINS.RAINBOW:
                    SkinRAINBOW();
                    break;
                case TITLE_SKINS.SPREAD:
                    SkinSMASH();
                    break;
                case TITLE_SKINS.DAY_AND_NIGHT:
                    SkinDayAndNight();
                    break;
            }
        }

        public static void DrawTitleSkinPopup()
        {
            title_skin = (TITLE_SKINS)EditorGUILayout.EnumPopup(LocalizationManager.GetLocalizeText("label.title_skin"), current_title_skin, new GUIStyle("miniPullDown"));
            if (title_skin != current_title_skin)
            {
                current_title_skin = title_skin;
                ConfigManager.title_skin = current_title_skin;
                ConfigManager.SaveConfig();
                ResetTimeLimit();
            }
        }

        private static void SkinNORMAL()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                char[] str = "Mesh Hologram".ToArray();
                List<int> state = new List<int>();
                for (int i = 0; i < 13; i++)
                {
                    if (CharTimeLimit[i] > 2)
                    {
                        state.Add(i);
                    }
                }
                GUILayout.FlexibleSpace();

                if (state.Count >= 12)
                {
                    int size = 128;
                    DrawBomb(size);
                }
                else
                {
                    int count = 0;
                    int impact = 0;
                    foreach (char text in str)
                    {
                        if (state.Contains(count) || impact > 0 && text.ToString() == " ")
                        {
                            impact++;
                        }
                        else
                        {
                            if (impact != 0)
                            {
                                int size = 24 + impact * impact / 2;
                                DrawBomb(size);
                                impact = 0;
                            }
                            if (GUILayout.Button("<color=#ffffff>" + text + "</color>", CustomGUIStyle[GUI_STYLE.TITLE1]) && text.ToString() != " ")
                            {
                                CharTimeLimit[count]++;
                            }
                        }
                        if (state.Contains(count) && text.ToString() == "m")
                        {
                            int size = 24 + impact * impact / 2;
                            DrawBomb(size);
                        }
                        count++;
                    }
                }

                GUILayout.FlexibleSpace();
            }
        }
        public static void ResetTimeLimit()
        {
            CharTimeLimit = new int[13];
        }
        public static void DrawBomb(int size)
        {
            GUI.DrawTexture(GUILayoutUtility.GetRect(size, size), bomb);
        }

        private static void SkinRAINBOW()
        {
            string epic_header = "<b><i>" + "<color=#" + ColorUtility.ToHtmlStringRGB(new Color() { r = Random.value, g = Random.value, b = Random.value, a = 1.0f }) + ">" + "Mesh Hologram" + "</color></i></b>";
            EditorGUILayout.LabelField(epic_header, CustomGUIStyle[GUI_STYLE.TITLE1]);
        }
        private static void SkinSMASH()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                char[] str = "Mesh Hologram".ToArray();
                foreach (char text in str)
                {
                    Vector2 wh = new Vector2(Random.Range(0.6f, 2.0f), Random.Range(0.6f, 2.0f));
                    Vector2 offset = new Vector2(1.0f, 1.0f) - (wh * 0.5f);
                    GUI.matrix = Matrix4x4.TRS(new Vector3(offset.x, offset.y, 0.0f), Quaternion.identity, new Vector3(wh.x, wh.y, 1.0f));
                    GUI.Label(GUILayoutUtility.GetRect(42, 42), "<color=#ffffff>" + text + "</color>", CustomGUIStyle[GUI_STYLE.TITLE1]);
                    GUI.matrix = Matrix4x4.identity;
                }
            }
        }
        private static void SkinDayAndNight()
        {
            float mul = 2.5f;
            DateTime dt = DateTime.Now;
            float t = (float)dt.Hour / (float)24;
            t = Mathf.Clamp01(Mathf.Abs(t * 2.0f % 2.0f * mul - mul) - mul * 0.5f + 0.5f);
            string epic_header = "<b><i>" + "<color=#" + ColorUtility.ToHtmlStringRGB(Color.Lerp(new Color(1.0f, 0.5f, 0.0f), new Color(0.0f, 0.5f, 1.0f), t)) + ">" + "Mesh Hologram" + "</color></i></b>";
            EditorGUILayout.LabelField(epic_header, CustomGUIStyle[GUI_STYLE.TITLE1]);
        }
    }
}

#endif