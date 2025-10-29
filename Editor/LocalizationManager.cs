#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramConstant;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static class LocalizationManager
    {
        private static LANG lang = ConfigManager.lang;
        public static LANG current_lang = ConfigManager.lang;
        private static Dictionary<string, string[]> PropLocalizeDic = LoadLangFiles();

        public static bool DrawLanguageEnumPopup()
        {
            lang = (LANG)EditorGUILayout.EnumPopup(GetLocalizeText("label.language"), ConfigManager.lang, new GUIStyle("miniPullDown"));
            if (lang != current_lang)
            {
                PropLocalizeDic = LoadLangFiles();
                current_lang = lang;
                ConfigManager.lang = lang;
                ConfigManager.SaveConfig();
                return true;
            }
            else return false;
        }

        public static string GetLocalizeText(string key, int index = 0)
        {
            if (!PropLocalizeDic.ContainsKey(key))
            {
                Debug.LogWarning("Could not get localized text. -> " + key);
                return key;
            }
            string[] values = PropLocalizeDic[key];
            if (values.Length < index)
            {
                Debug.LogWarning("Argument index is out of range.");
                index = 0;
            }
                return PropLocalizeDic[key][index];
        }

        public static string[] GetLocalizeTexts(string key)
        {
            if (!PropLocalizeDic.ContainsKey(key))
            {
                Debug.LogWarning("Could not get localized text. -> " + key);
                return new string[5];
            }
            return PropLocalizeDic[key];
        }

        internal static Dictionary<string, string[]> LoadLangFiles()
        {
            int index = (int)lang;
            Dictionary<string, string[]> r = new Dictionary<string, string[]>();
            LoadText(resolve_path + "/Editor/", "text.lang");
            LoadText(resolve_path + "/Editor/", "properties.lang");

            return r;

            void LoadText(string path, string file_name)
            {
                path += file_name;
                if (!File.Exists(path))
                {
                    Debug.LogWarning(file_name + " does not exist.");
                    return;
                }

                using (StreamReader reader = new StreamReader(path))
                {
                    int column = 0;
                    while (!reader.EndOfStream)
                    {
                        column++;
                        string line = reader.ReadLine();
                        if (line == "") continue;
                        string[] langs = line.Split("||");
                        if (langs.Length > index)
                        {
                            if (r.ContainsKey(langs[0]))
                            {
                                Debug.LogWarning("There are multiple localized text. -> Column:" + column + " - " + line);
                                continue;
                            }

                            r.Add(langs[0], langs[index].Split('/'));
                        }
                        else Debug.LogWarning("Could not get localized text. -> Column:" + column + " | " + line);
                    }
                }
            }
        }
    }
}


#endif