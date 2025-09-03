#if UNITY_EDITOR
using System.IO;
using System;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor{
    public class ConfigManager{
        private string path;
        private string lang_key = "[LANGUAGE]|";
        private string title_skin_key = "[TITLESKIN]|";
        public ConfigManager(string resolve_path){
            path = resolve_path + "/Editor/config.ini";
            if (!File.Exists(path))
            {
                SaveConfig();
            }

        }
        public string GetLanguage(){
            string r = null;
            using(StreamReader reader = new StreamReader(path)){
                while(!reader.EndOfStream){
                    string line = reader.ReadLine();
                    if (line.StartsWith(lang_key))
                    {
                        r = line.Replace(lang_key, "");
                        if (!Enum.IsDefined(typeof(LANG),r))
                        {
                            r = LANG.ENGLISH.ToString();
                        }
                        break;
                    }
                }
            }
            return r;
        }
        public string GetTitleSkin(){
            string r = null;
            using(StreamReader reader = new StreamReader(path)){
                while(!reader.EndOfStream){
                    string line = reader.ReadLine();
                    if (line.StartsWith(title_skin_key))
                    {
                        r = line.Replace(title_skin_key, "");
                        break;
                    }
                }
            }
            return r;
        }
        public void SaveConfig(LANG lang = LANG.ENGLISH, TITLE_SKINS title_skin = TITLE_SKINS.NORMAL){
            using(StreamWriter writer = new StreamWriter(path)){
                writer.WriteLine(lang_key+lang.ToString());
                writer.WriteLine(title_skin_key+title_skin.ToString());
            }
        }
    }
}
#endif