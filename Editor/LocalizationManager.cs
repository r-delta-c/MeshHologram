#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor{
    internal class LocalizationManager
    {
        private string resolve_path;
        internal Dictionary<string, string> PropLangDic;
        internal LocalizationManager(string resolve_path)
        {
            this.resolve_path = resolve_path;
        }
        public void LoadLangFiles(LANG lang = LANG.ENGLISH)
        {
            int index = (int)lang;
            PropLangDic = new Dictionary<string, string>();
            LoadText(resolve_path + "/Editor/", "text.lang");
            LoadText(resolve_path + "/Editor/", "properties.lang");

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
                        int column = 0;
                        while (!reader.EndOfStream)
                        {
                            column++;
                            string line = reader.ReadLine();
                            if (line == "") continue;
                            string[] values = line.Split("||");
                            if (values.Length >= index + 1)
                            {
                                if (PropLangDic.ContainsKey(values[0]))
                                {
                                    Debug.LogWarning("There are multiple localized text. -> Column:" + column + " - " + line);
                                }
                                else
                                {
                                    PropLangDic.Add(values[0], values[index]);
                                }
                            }
                            else
                            {
                                Debug.LogWarning("Could not get localized text. -> Column:" + column + " | " + line);
                            }
                        }
                    }
                }
            }
        }
    }
}


#endif