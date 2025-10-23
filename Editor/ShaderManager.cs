#if UNITY_EDITOR
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static partial class MeshHologramManager
    {
        public readonly static Shader shader = Shader.Find("DeltaField/shaders/MeshHologram");

        public static float GetPropertyFloat(Material mat, MESHHOLOGRAM_PROP_ENUM key)
        {
            return mat.GetFloat(Shader.PropertyToID(MeshHologramProps[key].property));
        }
        public static string GetPropertyValueToString(Material mat, MESHHOLOGRAM_PROP_ENUM key)
        {
            int id = MeshHologramProps[key].id;
            switch (MeshHologramProps[key].type)
            {
                case ShaderPropertyType.Color:
                    return mat.GetColor(id).ToString();
                case ShaderPropertyType.Vector:
                    return mat.GetVector(id).ToString();
                case ShaderPropertyType.Float:
                    return mat.GetFloat(id).ToString();
                case ShaderPropertyType.Range:
                    return mat.GetFloat(id).ToString();
                case ShaderPropertyType.Texture:
                    return AssetDatabase.GetAssetPath(mat.GetTexture(id));
                case ShaderPropertyType.Int:
                    return mat.GetInt(id).ToString();
                default:
                    throw new FormatException(MeshHologramProps[key].property);
            }
        }

        public class ShaderPropertyState
        {
            public MaterialProperty var;
            public readonly MESHHOLOGRAM_PROP_ENUM enum_value;
            public readonly string property;
            public string display;
            public readonly int id;
            public readonly ShaderPropertyType type;
            public ShaderPropertyState(MeshHologramPropMeta meta, MESHHOLOGRAM_PROP_ENUM e)
            {
                string name = meta.property;
                if (name == "_dummy")
                {
                    type = ShaderPropertyType.Float;
                    id = 0;
                }
                else
                {
                    id = shader.GetPropertyNameId(shader.FindPropertyIndex(name));
                    if (id == -1)
                    {
                        if (String.IsNullOrEmpty(name)) name = "EMPTY";
                        throw new Exception(name + " property is invalid.");
                    }
                    type = shader.GetPropertyType(shader.FindPropertyIndex(name));
                }
                property = name;
                display = name;

                enum_value = e;
            }
        }
        [AttributeUsage(AttributeTargets.Field)]
        public class MeshHologramPropMeta : Attribute
        {
            public readonly string property;
            public MeshHologramPropMeta(string name)
            {
                property = name;
            }
        }
    }
}

#endif