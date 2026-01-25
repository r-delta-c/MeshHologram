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
            public readonly float minValue = 0.0f;
            public readonly float maxValue = 1.0f;
            public ShaderPropertyState(MeshHologramPropMeta meta, MESHHOLOGRAM_PROP_ENUM e)
            {
                string name = meta.property;
                int index = shader.FindPropertyIndex(name);
                if (name == "_dummy")
                {
                    type = ShaderPropertyType.Float;
                    id = 0;
                }
                else
                {
                    if (index == -1)
                    {
                        if (String.IsNullOrEmpty(name)) name = "EMPTY";
                        throw new Exception(name + " property is invalid.");
                    }
                    id = shader.GetPropertyNameId(index);
                    type = shader.GetPropertyType(index);
                }
                if (type == ShaderPropertyType.Range)
                {
                    minValue = ShaderUtil.GetRangeLimits(shader, index, 1);
                    maxValue = ShaderUtil.GetRangeLimits(shader, index, 2);
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
        public struct MeshHologramToggleState
        {
            public readonly string keyword;
            public readonly string label;
            public bool value;
            public bool _value;
            public bool hasMixedValue;
            public MeshHologramToggleState(string keyword, string label, bool value = false)
            {
                this.keyword = keyword;
                this.label = label;
                this.value = value;
                this._value = value;
                this.hasMixedValue = false;
            }
            public void Toggle(bool value)
            {
                this._value = !value;
            }
            public void ApplyToggle(Material m)
            {
                if (_value!=value)
                {
                    if(_value) m.EnableKeyword(keyword);
                    else m.DisableKeyword(keyword);
                }
            }
        }

        public struct MeshHologramCommonProps
        {
            public readonly MAIN_CATEGORY category;
            public readonly MeshHologramSourceProps source;
            public readonly MeshHologramAudioLinkProps audiolink;
            public readonly MeshHologramMaskOffsetProps mask_offset;
            public readonly MeshHologramModifierProps modifier;
            public MeshHologramCommonProps(
                MAIN_CATEGORY category,
                MeshHologramSourceProps source,
                MeshHologramAudioLinkProps audiolink,
                MeshHologramMaskOffsetProps mask_offset,
                MeshHologramModifierProps modifier
                )
            {
                this.category = category;
                this.source = source;
                this.audiolink = audiolink;
                this.mask_offset = mask_offset;
                this.modifier = modifier;
            }
        }

        public struct MeshHologramSourceProps
        {
            public readonly MESHHOLOGRAM_PROP_ENUM source;
            public readonly MESHHOLOGRAM_PROP_ENUM fixed_value;
            public readonly MESHHOLOGRAM_PROP_ENUM offset0;
            public readonly MESHHOLOGRAM_PROP_ENUM offset1;
            public readonly MESHHOLOGRAM_PROP_ENUM scale0;
            public readonly MESHHOLOGRAM_PROP_ENUM scale1;
            public readonly MESHHOLOGRAM_PROP_ENUM offset_before_scale;
            public readonly MESHHOLOGRAM_PROP_ENUM space;
            public readonly MESHHOLOGRAM_PROP_ENUM seed;
            public readonly MESHHOLOGRAM_PROP_ENUM time_speed;
            public readonly MESHHOLOGRAM_PROP_ENUM time_phase;
            public readonly MESHHOLOGRAM_PROP_ENUM value_scale;
            public readonly MESHHOLOGRAM_PROP_ENUM map;
            public readonly MESHHOLOGRAM_PROP_ENUM map_st;
            public MeshHologramSourceProps(
                MESHHOLOGRAM_PROP_ENUM source,
                MESHHOLOGRAM_PROP_ENUM fixed_value,
                MESHHOLOGRAM_PROP_ENUM offset0,
                MESHHOLOGRAM_PROP_ENUM scale0,
                MESHHOLOGRAM_PROP_ENUM offset1,
                MESHHOLOGRAM_PROP_ENUM scale1,
                MESHHOLOGRAM_PROP_ENUM offset_before_scale,
                MESHHOLOGRAM_PROP_ENUM space,
                MESHHOLOGRAM_PROP_ENUM seed,
                MESHHOLOGRAM_PROP_ENUM time_speed,
                MESHHOLOGRAM_PROP_ENUM time_phase,
                MESHHOLOGRAM_PROP_ENUM value_scale,
                MESHHOLOGRAM_PROP_ENUM map,
                MESHHOLOGRAM_PROP_ENUM map_st
            )
            {
                this.source = source;
                this.fixed_value = fixed_value;
                this.offset0 = offset0;
                this.scale0 = scale0;
                this.offset1 = offset1;
                this.scale1 = scale1;
                this.offset_before_scale = offset_before_scale;
                this.space = space;
                this.seed = seed;
                this.time_speed = time_speed;
                this.time_phase = time_phase;
                this.value_scale = value_scale;
                this.map = map;
                this.map_st = map_st;
            }
        }

        public struct MeshHologramAudioLinkProps
        {
            public readonly MESHHOLOGRAM_PROP_ENUM source;
            public readonly MESHHOLOGRAM_PROP_ENUM vu_band;
            public readonly MESHHOLOGRAM_PROP_ENUM vu_smoothing;
            public readonly MESHHOLOGRAM_PROP_ENUM vu_panning;
            public readonly MESHHOLOGRAM_PROP_ENUM vu_strength;
            public readonly MESHHOLOGRAM_PROP_ENUM chrono_tensity_mode;
            public readonly MESHHOLOGRAM_PROP_ENUM chrono_tensity_band;
            public readonly MESHHOLOGRAM_PROP_ENUM chrono_tensity_strength;
            public readonly MESHHOLOGRAM_PROP_ENUM spectrum_mode;
            public readonly MESHHOLOGRAM_PROP_ENUM spectrum_mirror;
            public readonly MESHHOLOGRAM_PROP_ENUM spectrum_bounds;
            public readonly MESHHOLOGRAM_PROP_ENUM spectrum_strength;

            public MeshHologramAudioLinkProps(
                MESHHOLOGRAM_PROP_ENUM source,
                MESHHOLOGRAM_PROP_ENUM vu_band,
                MESHHOLOGRAM_PROP_ENUM vu_smoothing,
                MESHHOLOGRAM_PROP_ENUM vu_panning,
                MESHHOLOGRAM_PROP_ENUM vu_strength,
                MESHHOLOGRAM_PROP_ENUM chrono_tensity_mode,
                MESHHOLOGRAM_PROP_ENUM chrono_tensity_band,
                MESHHOLOGRAM_PROP_ENUM chrono_tensity_strength,
                MESHHOLOGRAM_PROP_ENUM spectrum_mode,
                MESHHOLOGRAM_PROP_ENUM spectrum_mirror,
                MESHHOLOGRAM_PROP_ENUM spectrum_bounds,
                MESHHOLOGRAM_PROP_ENUM spectrum_strength
            )
            {
                this.source = source;
                this.vu_band = vu_band;
                this.vu_smoothing = vu_smoothing;
                this.vu_panning = vu_panning;
                this.vu_strength = vu_strength;
                this.chrono_tensity_mode = chrono_tensity_mode;
                this.chrono_tensity_band = chrono_tensity_band;
                this.chrono_tensity_strength = chrono_tensity_strength;
                this.spectrum_mode = spectrum_mode;
                this.spectrum_mirror = spectrum_mirror;
                this.spectrum_bounds = spectrum_bounds;
                this.spectrum_strength = spectrum_strength;
            }
        }

        public struct MeshHologramMaskOffsetProps
        {
            public readonly MESHHOLOGRAM_PROP_ENUM mask_tex;
            public readonly MESHHOLOGRAM_PROP_ENUM mask_st;
            public readonly MESHHOLOGRAM_PROP_ENUM mask_strength;
            public readonly MESHHOLOGRAM_PROP_ENUM offset_tex;
            public readonly MESHHOLOGRAM_PROP_ENUM offset_st;
            public readonly MESHHOLOGRAM_PROP_ENUM offset_strength;
            public readonly MESHHOLOGRAM_PROP_ENUM audiolink_mask_tex;
            public readonly MESHHOLOGRAM_PROP_ENUM audiolink_mask_st;
            public readonly MESHHOLOGRAM_PROP_ENUM audiolink_mask_strength;

            public MeshHologramMaskOffsetProps
            (
                MESHHOLOGRAM_PROP_ENUM mask_tex,
                MESHHOLOGRAM_PROP_ENUM mask_st,
                MESHHOLOGRAM_PROP_ENUM mask_strength,
                MESHHOLOGRAM_PROP_ENUM offset_tex,
                MESHHOLOGRAM_PROP_ENUM offset_st,
                MESHHOLOGRAM_PROP_ENUM offset_strength,
                MESHHOLOGRAM_PROP_ENUM audiolink_mask_tex,
                MESHHOLOGRAM_PROP_ENUM audiolink_mask_st,
                MESHHOLOGRAM_PROP_ENUM audiolink_mask_strength
            )
            {
                this.mask_tex = mask_tex;
                this.mask_st = mask_st;
                this.mask_strength = mask_strength;
                this.offset_tex = offset_tex;
                this.offset_st = offset_st;
                this.offset_strength = offset_strength;
                this.audiolink_mask_tex = audiolink_mask_tex;
                this.audiolink_mask_st = audiolink_mask_st;
                this.audiolink_mask_strength = audiolink_mask_strength;
            }
        }

        public struct MeshHologramModifierProps
        {
            public readonly MESHHOLOGRAM_PROP_ENUM phase_scale;
            public readonly MESHHOLOGRAM_PROP_ENUM loop_mode;
            public readonly MESHHOLOGRAM_PROP_ENUM ease_mode;
            public readonly MESHHOLOGRAM_PROP_ENUM ease_curve;
            public readonly MESHHOLOGRAM_PROP_ENUM mid_mul;
            public readonly MESHHOLOGRAM_PROP_ENUM mid_add;

            public MeshHologramModifierProps
            (
                MESHHOLOGRAM_PROP_ENUM phase_scale,
                MESHHOLOGRAM_PROP_ENUM loop_mode,
                MESHHOLOGRAM_PROP_ENUM ease_mode,
                MESHHOLOGRAM_PROP_ENUM ease_curve,
                MESHHOLOGRAM_PROP_ENUM mid_mul,
                MESHHOLOGRAM_PROP_ENUM mid_add
            )
            {
                this.phase_scale = phase_scale;
                this.loop_mode = loop_mode;
                this.ease_mode = ease_mode;
                this.ease_curve = ease_curve;
                this.mid_mul = mid_mul;
                this.mid_add = mid_add;
            }
        }

    }
}

#endif