#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Internal;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static partial class PropertyBlockManager
    {
        public class PropertyBlock
        {
            public readonly string name;
            public readonly MESHHOLOGRAM_PROP_ENUM[] MainEnums;
            public readonly MESHHOLOGRAM_PROP_ENUM[] SourceEnums;
            public readonly MESHHOLOGRAM_PROP_ENUM[] AudioLinkEnums;
            public readonly MESHHOLOGRAM_PROP_ENUM[] MaskOffsetEnums;
            public readonly MESHHOLOGRAM_PROP_ENUM[] ModifierEnums;
            public PropertyBlock(string s, MESHHOLOGRAM_PROP_ENUM[] main, MESHHOLOGRAM_PROP_ENUM[] source = null, MESHHOLOGRAM_PROP_ENUM[] audiolink = null, MESHHOLOGRAM_PROP_ENUM[] mask_offset = null, MESHHOLOGRAM_PROP_ENUM[] modifier = null)
            {
                name = s;
                MainEnums = main;
                SourceEnums = source;
                AudioLinkEnums = audiolink;
                MaskOffsetEnums = mask_offset;
                ModifierEnums = modifier;
            }
            public Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string> GetMainBlock()
            {
                return new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>(name, MainEnums, null);
            }
            public Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string> GetCommonBlock(PROPERTY_BLOCK block)
            {
                Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string> tuple = block switch
                {
                    PROPERTY_BLOCK.SOURCE => new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>("Source", SourceEnums, name),
                    PROPERTY_BLOCK.AUDIOLINK_SOURCE => new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>("AudioLinkSource", AudioLinkEnums, name),
                    PROPERTY_BLOCK.MASK_OFFSET => new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>("MaskOffset", MaskOffsetEnums, name),
                    PROPERTY_BLOCK.MODIFIER => new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>("Modifier", ModifierEnums, name),
                    _ => throw new ArgumentException()
                };
                return tuple;
            }
            public Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[] GetFullCommonBlock(bool remove_prefix = true)
            {
                string prefix_name = null;
                string source, audiolink_source, mask_offset, modifier;
                if (remove_prefix)
                {
                    prefix_name = name;
                    source = "Source";
                    audiolink_source = "AudioLinkSource";
                    mask_offset = "MaskOffset";
                    modifier = "Modifier";
                }
                else
                {
                    source = name;
                    audiolink_source = name;
                    mask_offset = name;
                    modifier = name;
                }
                int block_count = CommonEnumCount();
                Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[] blocks = new Tuple<string, MESHHOLOGRAM_PROP_ENUM[],string>[block_count];
                int current_index = 0;
                ReplaceElement(source, SourceEnums, ref blocks, ref current_index, prefix_name);
                ReplaceElement(audiolink_source, AudioLinkEnums, ref blocks, ref current_index, prefix_name);
                ReplaceElement(mask_offset, MaskOffsetEnums, ref blocks, ref current_index, prefix_name);
                ReplaceElement(modifier, ModifierEnums, ref blocks, ref current_index, prefix_name);

                return blocks;
            }
            public Tuple<string, MESHHOLOGRAM_PROP_ENUM[],string> GetFullBlock()
            {
                int total_index = MainEnums.Length;
                if (SourceEnums != null) total_index += SourceEnums.Length;
                if (AudioLinkEnums != null) total_index += AudioLinkEnums.Length;
                if (MaskOffsetEnums != null) total_index += MaskOffsetEnums.Length;
                if (ModifierEnums != null) total_index += ModifierEnums.Length;

                int current_index = 0;
                MESHHOLOGRAM_PROP_ENUM[] props = new MESHHOLOGRAM_PROP_ENUM[total_index];
                current_index += ArrayCopy(MainEnums);
                if (SourceEnums != null) current_index += ArrayCopy(SourceEnums);
                if (AudioLinkEnums != null) current_index += ArrayCopy(AudioLinkEnums);
                if (MaskOffsetEnums != null) current_index += ArrayCopy(MaskOffsetEnums);
                if (ModifierEnums != null) current_index += ArrayCopy(ModifierEnums);
                return new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>(name, props, null);

                int ArrayCopy(MESHHOLOGRAM_PROP_ENUM[] source)
                {
                    Array.Copy(source, 0, props, current_index, source.Length);
                    return source.Length;
                }
            }
            public Tuple<string, MESHHOLOGRAM_PROP_ENUM[],string>[] GetFullBlocks(bool remove_prefix = true)
            {
                string prefix_name = null;
                if(remove_prefix) prefix_name = name;
                int block_count = 1 + CommonEnumCount();
                Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[] blocks = new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[block_count];
                int current_index = 0;
                ReplaceElement(name, MainEnums, ref blocks, ref current_index, null);
                ReplaceElement("Source", SourceEnums, ref blocks, ref current_index, prefix_name);
                ReplaceElement("AudioLinkSource", AudioLinkEnums, ref blocks, ref current_index, prefix_name);
                ReplaceElement("MaskOffset", MaskOffsetEnums, ref blocks, ref current_index, prefix_name);
                ReplaceElement("Modifier", ModifierEnums, ref blocks, ref current_index, prefix_name);
                return blocks;
            }

            private void ReplaceElement(string name, MESHHOLOGRAM_PROP_ENUM[] block, ref Tuple<string, MESHHOLOGRAM_PROP_ENUM[],string>[] blocks, ref int current_index, string prefix_name)
            {
                if (block != null)
                {
                    blocks[current_index] = new Tuple<string, MESHHOLOGRAM_PROP_ENUM[],string>(name, block, prefix_name);
                    current_index++;
                }
            }

            private int CommonEnumCount()
            {
                return (SourceEnums == null ? 0 : 1) +
                    (AudioLinkEnums == null ? 0 : 1) +
                    (MaskOffsetEnums == null ? 0 : 1) +
                    (ModifierEnums == null ? 0 : 1);
            }

            public MESHHOLOGRAM_PROP_ENUM[] JoinBlocks(MESHHOLOGRAM_PROP_ENUM[][] blocks)
            {
                int elements_count = 0;
                foreach (MESHHOLOGRAM_PROP_ENUM[] keys in blocks) elements_count += keys.Length;
                MESHHOLOGRAM_PROP_ENUM[] r = new MESHHOLOGRAM_PROP_ENUM[elements_count];
                int current_index = 0;
                foreach (MESHHOLOGRAM_PROP_ENUM[] keys in blocks)
                {
                    Array.Copy(keys, 0, r, current_index, keys.Length);
                    current_index += keys.Length;
                }
                return r;
            }
        }

        private static bool dialog_flag = false;
        private static List<string> FailedPasteProperty = new List<string>();
        private static List<string> FailedPastePropertyBlock = new List<string>();
        private static List<string> TypeMismatchPasteProperty = new List<string>();
        private static List<string> OutOfRangePasteProperty = new List<string>();

        private static void DisplayInfoDialog()
        {
            EditorUtility.DisplayDialog(
                LocalizationManager.GetLocalizeText("dialog.property_paste.information"),
                LocalizationManager.GetLocalizeText("dialog.property_paste_failed.text"),
                LocalizationManager.GetLocalizeText("dialog.ok")
            );
            string log;
            if (FailedPasteProperty.Count > 0)
            {
                log = LocalizationManager.GetLocalizeText("log.property_paste.not_exist_properties.text")+"\n";
                foreach (string context in FailedPasteProperty)
                {
                    log += "* "+context+"\n";
                }
                Debug.LogWarning(log);
            }

            if (FailedPastePropertyBlock.Count > 0)
            {
                log = LocalizationManager.GetLocalizeText("log.property_paste.not_exist_categories.text")+"\n";
                foreach (string context in FailedPastePropertyBlock)
                {
                    log += "* "+context+"\n";
                }
                Debug.LogWarning(log);
            }

            if (TypeMismatchPasteProperty.Count > 0)
            {
                log = LocalizationManager.GetLocalizeText("log.property_paste.type_mismatch.text")+"\n";
                foreach (string context in TypeMismatchPasteProperty)
                {
                    log += "* "+context + "\n";
                }
                Debug.LogWarning(log);
            }

            if (OutOfRangePasteProperty.Count > 0)
            {
                log = LocalizationManager.GetLocalizeText("log.property_paste.out_of_range.text")+"\n";
                foreach (string context in OutOfRangePasteProperty)
                {
                    log += "* "+context + "\n";
                }
                Debug.LogWarning(log);
            }

            FailedPasteProperty.Clear();
            FailedPastePropertyBlock.Clear();
            TypeMismatchPasteProperty.Clear();
            OutOfRangePasteProperty.Clear();
            dialog_flag = false;
        }

        public static string PropertyToJoinString(Material m, MESHHOLOGRAM_PROP_ENUM[] keys, string name = null)
        {
            string[] props = new string[keys.Length];
            for (int i = 0; i < props.Length; i++)
            {
                MESHHOLOGRAM_PROP_ENUM key = keys[i];
                string prop = MeshHologramProps[key].property;
                if (name != null) prop = prop.Remove(0, 1 + name.Length);
                props[i] = prop + ":" + GetPropertyValueToString(m, key);
            }
            return String.Join(",", props);
        }

        public static void CopyBuffer(string s)
        {
            GUIUtility.systemCopyBuffer = "{" + s + "}";
        }
        public static void CopyBuffer(string[] s)
        {
            CopyBuffer(String.Join(',', s));
        }

        public static string CopyBlock(Material m, Tuple<string, MESHHOLOGRAM_PROP_ENUM[],string>[] tuples)
        {
            string[] r = new string[tuples.Length];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = tuples[i].Item1 + ":{" + PropertyToJoinString(m, tuples[i].Item2, tuples[i].Item3) + "}";
            }
            return string.Join(',',r);
        }

        public static void ParseBlock(Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[] tuples)
        {
            string[] buffer = ParseBuffer();
            foreach(Tuple<string,MESHHOLOGRAM_PROP_ENUM[],string> tuple in tuples)
            {
                Dictionary<string, string> data_dic = TextComponentToDictionary(buffer, tuple.Item1, tuple.Item3);
                SetPropertyFromDictionary(tuple.Item1, tuple.Item2, data_dic);
            }
            if(dialog_flag) DisplayInfoDialog();
        }

        private static string[] ParseBuffer()
        {
            return GUIUtility.systemCopyBuffer.Trim('{', '}').Split("},");
        }

        private static Dictionary<string, string> TextComponentToDictionary(string[] input, string comp_name, string prefix_name)
        {
            foreach (string comp in input)
            {
                if (!comp.StartsWith(comp_name + ":{")) continue;
                string comp_text = comp.Remove(0, comp_name.Length + 2).TrimEnd('}');
                List<string> comp_data = SplitComponent(comp_text);
                Dictionary<string, string> data_dic = new Dictionary<string, string>();
                foreach (string data in comp_data)
                {
                    string[] pair = data.Split(':');
                    if (pair.Length < 2) continue;
                    if (prefix_name != null) pair[0] = "_" + prefix_name + pair[0];
                    data_dic.Add(pair[0], pair[1]);
                }
                return data_dic;
            }
            return null;
        }
        private static void SetPropertyFromDictionary(string block_name, MESHHOLOGRAM_PROP_ENUM[] block, Dictionary<string, string> data_dic)
        {
            if (data_dic == null)
            {
                FailedPastePropertyBlock.Add(block_name);
                dialog_flag = true;
                return;
            }
            foreach (MESHHOLOGRAM_PROP_ENUM e in block)
            {
                string prop = MeshHologramProps[e].property;
                if (!data_dic.ContainsKey(prop))
                {
                    FailedPasteProperty.Add(prop);
                    dialog_flag = true;
                    continue;
                }

                bool type_mismatch_flag = false;
                bool source_enum = false;
                bool audiolink_source_enum = false;
                source_enum =
                    (e == MESHHOLOGRAM_PROP_ENUM._FRAGMENT_SOURCE) ||
                    (e == MESHHOLOGRAM_PROP_ENUM._COLOR_SOURCE) ||
                    (e == MESHHOLOGRAM_PROP_ENUM._GEOMETRY_SOURCE);
                audiolink_source_enum =
                    (e == MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_SOURCE) ||
                    (e == MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE);

                string data = data_dic[prop];
                MaterialProperty mp = MeshHologramProps[e].var;
                ShaderPropertyType type = MeshHologramProps[e].type;
                switch (type)
                {
                    case ShaderPropertyType.Color:
                        Color? r_c = StringToColor(data);
                        if (CheckVector4Exception(r_c)) mp.colorValue = (Color)r_c;
                        break;
                    case ShaderPropertyType.Vector:
                        Vector4? r_v = StringToVector4(data);
                        if (CheckVector4Exception(r_v)) mp.vectorValue = (Vector4)r_v;
                        break;
                    case ShaderPropertyType.Float:
                        float? r_f = StringToFloat(data);
                        if (CheckException(r_f)) mp.floatValue = (float)r_f;
                        break;
                    case ShaderPropertyType.Range:
                        float? r_r = StringToFloat(data);
                        if (CheckException(r_r)) mp.floatValue = (float)r_r;
                        break;
                    case ShaderPropertyType.Texture:
                        Texture r_t = StringToTexture(data);
                        if (r_t == null && data != "") type_mismatch_flag = true;
                        else mp.textureValue = r_t;
                        break;
                    case ShaderPropertyType.Int:
                        int? r_i = StringToInt(data);
                        if (CheckException(r_i)) mp.intValue = (int)r_i;
                        break;
                }
                if (type_mismatch_flag) TypeMismatchException(MeshHologramProps[e].property, type);

                bool CheckException(float? var)
                {
                    if (var == null)
                    {
                        type_mismatch_flag = true;
                        return false;
                    }
                    else
                    {
                        if ((e == MESHHOLOGRAM_PROP_ENUM._FRAGMENT_SOURCE) || (e == MESHHOLOGRAM_PROP_ENUM._COLOR_SOURCE) || (e == MESHHOLOGRAM_PROP_ENUM._GEOMETRY_SOURCE)) {
                            if (var > 1)
                            {
                                OutOfRangeException(MeshHologramProps[e].property);
                                return false;
                            }
                            else return true;
                        } else if (e == MESHHOLOGRAM_PROP_ENUM._ORBIT_WAVE_AUDIOLINK_SOURCE)
                        {
                            if (var==1)
                            {
                                OutOfRangeException(MeshHologramProps[e].property);
                                return false;
                            }
                            else return true;
                        } else if (e == MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE)
                        {
                            switch (var)
                            {
                                case 2:
                                    OutOfRangeException(MeshHologramProps[e].property);
                                    return false;
                                case 4:
                                    OutOfRangeException(MeshHologramProps[e].property);
                                    return false;
                                default:
                                    return true;
                            }
                        }
                        else return true;
                    }
                }
                bool CheckVector4Exception(Vector4? input)
                {
                    if (input == null)
                    {
                        type_mismatch_flag = true;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private static void TypeMismatchException(string prop, ShaderPropertyType type)
        {
            TypeMismatchPasteProperty.Add(String.Format("{0}: {1} | {2}: {3}",
            LocalizationManager.GetLocalizeText("text.property"),
            prop,
            LocalizationManager.GetLocalizeText("text.type"),
            type
            ));
            dialog_flag = true;
        }

        private static void OutOfRangeException(string prop)
        {
            OutOfRangePasteProperty.Add(LocalizationManager.GetLocalizeText("text.property") + ": " + prop);
            dialog_flag = true;
        }

        public static List<string> SplitComponent(string input)
        {
            List<string> r = new List<string>();
            StringBuilder current = new StringBuilder();
            int brace = 0;
            int paren = 0;
            foreach (char c in input)
            {
                switch (c)
                {
                    case '{':
                        brace++;
                        current.Append(c);
                        break;
                    case '}':
                        brace--;
                        current.Append(c);
                        break;
                    case '(':
                        paren++;
                        current.Append(c);
                        break;
                    case ')':
                        paren--;
                        current.Append(c);
                        break;
                    case ',':
                        if (brace == 0 && paren == 0)
                        {
                            r.Add(current.ToString());
                            current.Clear();
                            continue;
                        }
                        current.Append(c);
                        break;
                    default:
                        current.Append(c);
                        break;
                }
            }
            if (current.Length > 0)
            {
                r.Add(current.ToString());
            }
            return r;
        }

        public static Color? StringToColor(string input)
        {
            if (!input.StartsWith("RGBA")) return null;
            string[] elements = input.Remove(0, 4).Trim('(', ')').Split(',');
            if (4 != elements.Length) return null;
            Color r_vec = Color.black;
            for (int i = 0; i < 4; i++)
            {
                float value;
                if(!float.TryParse(elements[i], out value)) return null;
                r_vec[i] = value;
            }
            return r_vec;
        }
        public static Vector4? StringToVector4(string input)
        {
            string[] elements = input.Trim('(', ')').Split(',');
            if (4 != elements.Length) return null;
            Vector4 r_vec = Vector4.zero;
            for (int i = 0; i < 4; i++)
            {
                float value;
                if(!float.TryParse(elements[i], out value)) return null;
                r_vec[i] = value;
            }
            return r_vec;
        }
        public static float? StringToFloat(string input)
        {
            float value;
            if(!float.TryParse(input, out value)) return null;
            return value;
        }
        public static Texture StringToTexture(string input)
        {
            return AssetDatabase.LoadAssetAtPath(input, typeof(Texture)) as Texture;
        }
        public static int? StringToInt(string input)
        {
            int value;
            if(!int.TryParse(input, out value)) return null;
            return value;
        }

    }
}

#endif

