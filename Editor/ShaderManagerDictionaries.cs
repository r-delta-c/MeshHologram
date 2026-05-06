#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static partial class MeshHologramManager
    {
        public static Dictionary<MESHHOLOGRAM_PROP_ENUM, ShaderPropertyState> MeshHologramProps = Enum.GetValues(typeof(MESHHOLOGRAM_PROP_ENUM)).Cast<MESHHOLOGRAM_PROP_ENUM>()
            .ToDictionary(
                e => e,
                e => new ShaderPropertyState(
                    typeof(MESHHOLOGRAM_PROP_ENUM).GetField(e.ToString()).GetCustomAttribute<ShaderParameterAttribute>(),
                    e
            )
        );

        private static Dictionary<string, MESHHOLOGRAM_PROP_ENUM> propEnumToName = MeshHologramProps.Values.ToDictionary(e => e.property, e => e.enum_value);

        public static ShaderPropertyState GetStringToPropertyState(string name)
        {
            return MeshHologramProps[propEnumToName[name]];
        }

        public static Dictionary<MESHHOLOGRAM_KEYWORD_ENUM, MaterialKeyword> MeshHologramKeywords = Enum.GetValues(typeof(MESHHOLOGRAM_KEYWORD_ENUM)).Cast<MESHHOLOGRAM_KEYWORD_ENUM>()
            .ToDictionary(
                e => e,
                e => GenerateKeywordDictionary(e)
            );

        public static MaterialKeyword GenerateKeywordDictionary(MESHHOLOGRAM_KEYWORD_ENUM e)
        {
            MeshHologramKeywordMeta meta = typeof(MESHHOLOGRAM_KEYWORD_ENUM).GetField(e.ToString()).GetCustomAttribute<MeshHologramKeywordMeta>(); 
            if (meta.isEnum)
            {
                return new EnumKeyword(meta.keywords, meta.label); 
            } 
            else return new ToggleKeyword(meta.keywords[1], meta.label);
        }

        internal static Dictionary<GUI_STYLE, GUIStyle> CustomGUIStyle = new Dictionary<GUI_STYLE, GUIStyle> {
            { Editor.GUI_STYLE.PLAIN,new GUIStyle(){

            }},
            { Editor.GUI_STYLE.TITLE0,new GUIStyle(){
                richText = true, alignment = TextAnchor.UpperCenter, fontSize = 32
            }},
            { Editor.GUI_STYLE.TITLE1,new GUIStyle(){
                richText = true, alignment = TextAnchor.UpperCenter, fontSize = 24
            }},
            { Editor.GUI_STYLE.HEADER0,new GUIStyle(){
                richText = true, alignment = TextAnchor.MiddleLeft, fontSize = 16, fontStyle=FontStyle.Bold
            }},
            { Editor.GUI_STYLE.HEADER1,new GUIStyle(){
                richText = true, alignment = TextAnchor.MiddleLeft, fontSize = 12, fontStyle=FontStyle.Bold
            }}
        };
    }
}

#endif