#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor{
    public class LocalizationManager
    {
        public Dictionary<string, string> PropLangDic;
        public LocalizationManager()
        {
        }
        public void LoadLangFiles(LANG lang = LANG.ENGLISH)
        {
            int index = (int)lang;
            PropLangDic = new Dictionary<string, string>();
            LoadText(MeshHologramInspector.info.resolvedPath + "/Editor/", "text.lang");
            LoadText(MeshHologramInspector.info.resolvedPath + "/Editor/", "properties.lang");

            void LoadText(string path, string file_name)
            {
                path += file_name;
                if (!File.Exists(path))
                {
                    Debug.LogWarning(file_name+" does not exist.");
                }
                else
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            if (line == "") continue;
                            string[] values = line.Split("||");
                            if (values.Length >= index + 1)
                            {
                                PropLangDic.Add(values[0], values[index]);
                            }
                            else
                            {
                                Debug.LogWarning("Could not get localized text. -> " + line);
                            }
                        }
                    }
                }
            }
        }
    }
}


#endif