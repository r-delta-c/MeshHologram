#if UNITY_EDITOR
using System.IO;
using System;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramInspector;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramConstant;
using static DeltaField.Shaders.MeshHologram.Editor.Initializer;
using System.Collections.Generic;

namespace DeltaField.Shaders.MeshHologram.Editor{
    public static class ConfigManager{
        public static string path { get; private set; }

        private static Dictionary<CONFIG, Enum> ConfigStates = new Dictionary<CONFIG, Enum>()
        {
            {CONFIG.LANGUAGE,new LANG()},
            {CONFIG.TITLE_SKIN,new TITLE_SKINS()},
            {CONFIG.PIPELINE,new PIPELINE()},
        };

        static ConfigManager()
        {
            if (IsInitialized) Init();
            else OnInitialized += Init;
        }

        private static void Init()
        {
            path = resolve_path + "/Editor/config.ini";
            LoadConfigStates();
        }

        private static void LoadConfigStates()
        {
            if (path==null) return;
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string r = null;
                    Type type = null;
                    string[] key_pairs = reader.ReadLine().Split('|');
                    key_pairs[0] = key_pairs[0].TrimStart('[').TrimEnd(']');
                    if(!Enum.IsDefined(typeof(CONFIG), key_pairs[0])) return;
                    CONFIG config = (CONFIG)Enum.Parse(typeof(CONFIG), key_pairs[0]);
                    if (ConfigStates.ContainsKey(config))
                    {
                        type = ConfigStates[config].GetType();
                        if(Enum.IsDefined(type, key_pairs[1])) ConfigStates[config] = (Enum)Enum.Parse(type, key_pairs[1]);
                        else r = Enum.GetName(type, 0);
                    }
                    if (r==null) continue;
                    ConfigStates[config] = (Enum)Enum.Parse(type, r);
                }
            }
        }

        public static void SaveConfig()
        {
            if (path==null) return;
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach(CONFIG config in ConfigStates.Keys) writer.WriteLine("["+config+"]|" + ConfigStates[config].ToString());
            }
        }

        public static Enum GetState(CONFIG c)
        {
            return ConfigStates[c];
        }

        internal static void SetLanguageState(LANG lang)
        {
            ConfigStates[CONFIG.LANGUAGE] = lang;
            SaveConfig();
        }
        internal static void SetTitleSkinState(TITLE_SKINS title_skin)
        {
            ConfigStates[CONFIG.TITLE_SKIN] = title_skin;
            SaveConfig();
        }
        internal static void SetPipelineState(PIPELINE pipeline)
        {
            ConfigStates[CONFIG.PIPELINE] = pipeline;
            SaveConfig();
        }
    }
}
#endif