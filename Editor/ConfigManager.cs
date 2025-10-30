#if UNITY_EDITOR
using System.IO;
using System;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramInspector;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramConstant;
using static DeltaField.Shaders.MeshHologram.Editor.Initializer;

namespace DeltaField.Shaders.MeshHologram.Editor{
    public static class ConfigManager{
        private const string lang_key = "[LANGUAGE]|";
        private const string title_skin_key = "[TITLESKIN]|";

        public static string path { get; private set; }
        public static LANG lang;
        public static TITLE_SKINS title_skin;

        static ConfigManager()
        {
            if (IsInitialized) Init();
            else OnInitialized += Init;
        }

        private static void Init()
        {
            path = resolve_path + "/Editor/config.ini";
            GetLanguage();
            GetTitleSkin();
        }

        private static void GetLanguage()
        {
            if (path==null) return;
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
        }
        private static void GetTitleSkin(){
            if (path==null) return;
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
        }
        public static void SaveConfig()
        {
            if (path==null) return;
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