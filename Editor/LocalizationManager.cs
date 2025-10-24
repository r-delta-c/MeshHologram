#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Codice.CM.Common;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramConstant;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static class LocalizationManager
    {
        private static LANG lang = ConfigManager.lang;
        public static LANG current_lang = ConfigManager.lang;
        private static Dictionary<string, string> PropLocalizeDic = LoadLangFiles();

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

        public static string GetLocalizeText(string key)
        {
            if (PropLocalizeDic.ContainsKey(key))
            {
                return PropLocalizeDic[key];
            }
            else
            {
                Debug.LogWarning("Could not get localized text. -> " + key);
                return key;
            }
        }
        internal static Dictionary<string, string> LoadLangFiles()
        {
            int index = (int)lang;
            Dictionary<string, string> r = new Dictionary<string, string>();
            LoadText(resolve_path + "/Editor/", "text.lang");
            LoadText(resolve_path + "/Editor/", "properties.lang");

            return r;

            void LoadText(string path, string file_name)
            {
                path += file_name;
                if (!File.Exists(path))
                {
                    Debug.LogWarning(file_name + " does not exist.");
                }
                else
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        int column = 0;
                        while (!reader.EndOfStream)
                        {
                            column++;
                            string line = reader.ReadLine();
                            if (line == "") continue;
                            string[] values = line.Split("||");
                            if (values.Length >= index + 1)
                            {
                                if (r.ContainsKey(values[0])) Debug.LogWarning("There are multiple localized text. -> Column:" + column + " - " + line);
                                else r.Add(values[0], values[index]);
                            }
                            else Debug.LogWarning("Could not get localized text. -> Column:" + column + " | " + line);
                        }
                    }
                }
            }
        }
    }
}


#endif