#if UNITY_EDITOR
using System.IO;
using System;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramInspector;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramConstant;

namespace DeltaField.Shaders.MeshHologram.Editor{
    public static class ConfigManager{
        public static readonly string path = resolve_path + "/Editor/config.ini";

        private const string lang_key = "[LANGUAGE]|";
        private const string title_skin_key = "[TITLESKIN]|";

        public static LANG lang = GetLanguage();
        public static TITLE_SKINS title_skin = GetTitleSkin();

        public static LANG GetLanguage()
        {
            string r = null;
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.StartsWith(lang_key))
                    {
                        r = line.Replace(lang_key, "");
                        if (!Enum.IsDefined(typeof(LANG), r))
                        {
                            r = LANG.ENGLISH.ToString();
                        }
                        break;
                    }
                }
            }
            LANG r_e = ParseEnum<LANG>(r);
            lang = r_e;
            return r_e;
        }
        public static TITLE_SKINS GetTitleSkin(){
            string r = null;
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.StartsWith(title_skin_key))
                    {
                        r = line.Replace(title_skin_key, "");
                        break;
                    }
                }
            }
            TITLE_SKINS r_e = ParseEnum<TITLE_SKINS>(r);
            title_skin = r_e;
            return r_e;
        }
        public static void SaveConfig()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(lang_key + lang.ToString());
                writer.WriteLine(title_skin_key + title_skin.ToString());
            }
        }
        private static T ParseEnum<T>(string s)
            where T : Enum
        {
            return (T)Enum.Parse(typeof(T), s);
        }
    }
}
#endif