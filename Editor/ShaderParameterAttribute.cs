#if UNITY_EDITOR

using System;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static partial class MeshHologramManager
    {
        public abstract class ShaderParameterAttribute : Attribute
        {
            internal readonly string property;
            internal readonly bool hidden_prop;
            internal readonly VAR_TYPE var_type;
            internal readonly PROP_TYPE prop_type;
            internal readonly uint? element;
            internal readonly float? def_value;
            internal readonly float[] vector_def_value;
            internal readonly string path_def_value;

            public ShaderParameterAttribute(string property, bool hidden_prop, VAR_TYPE var_type, PROP_TYPE prop_type = (PROP_TYPE)(-1), uint element = 1, float? def_value = null, float[] vector_def_value = null, string path_def_value = null)
            {
                this.property = property;
                this.hidden_prop = hidden_prop;
                this.var_type = var_type;
                if(prop_type!=(PROP_TYPE)(-1)) this.prop_type = prop_type;
                else
                {
                    this.prop_type = var_type switch
                    {
                        VAR_TYPE._FLOAT => PROP_TYPE._FLOAT,
                        VAR_TYPE._HALF => PROP_TYPE._FLOAT,
                        VAR_TYPE._INT => PROP_TYPE._INT,
                        VAR_TYPE._UINT => PROP_TYPE._INT,
                        VAR_TYPE._BOOL => PROP_TYPE._INT,
                        VAR_TYPE._TEXTURE2D => PROP_TYPE._2D,
                        _ => throw new ArgumentException()
                    };
                }
                this.element = element;
                if(def_value!=null) this.def_value = (float)def_value;
                if(vector_def_value!=null) this.vector_def_value = vector_def_value;
                if(path_def_value!=null) this.path_def_value = path_def_value;
            }
            public string GetPropertyCode()
            {
                if(def_value!=null)
                    return $"{GetDrawerCode()}{property}(\"{property}\",{GetPropType()})={GetDefValue(def_value)}";
                else if(vector_def_value!=null)
                    return $"{GetDrawerCode()}{property}(\"{property}\",{GetPropType()})={GetDefValue(vector_def_value)}";
                else if(path_def_value!=null)
                    return $"{GetDrawerCode()}{property}(\"{property}\",{GetPropType()})={GetDefValue(path_def_value)}";
                else
                    throw new Exception();

            }
            internal abstract string GetDrawerCode();
            internal virtual string GetPropType()
            {
                return prop_type switch
                {
                    PROP_TYPE._FLOAT => "Float",
                    PROP_TYPE._INT => "Int",
                    PROP_TYPE._VECTOR => "Vector",
                    PROP_TYPE._COLOR => "Color",
                    PROP_TYPE._2D => "2D",
                    _ => throw new ArgumentException()
                };
            }
            private string GetDefValue(float? value) => value.ToString();
            private string GetDefValue(float[] values) => "("+string.Join(',',values)+")";
            private string GetDefValue(string value) => value.ToString();

            internal string GetVariableCode()
            {
                string type = var_type switch
                {
                    VAR_TYPE._FLOAT => "float",
                    VAR_TYPE._HALF => "half",
                    VAR_TYPE._INT => "int",
                    VAR_TYPE._UINT => "uint",
                    VAR_TYPE._BOOL => "bool",
                    VAR_TYPE._TEXTURE2D => "Texture2D",
                    _ => throw new ArgumentException(),
                };
                if(var_type!=VAR_TYPE._TEXTURE2D&&element>1) return $"{type}{element} {property};";
                else return $"{type} {property};";
            }
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaNumberAttribute : ShaderParameterAttribute
        {
            public MetaNumberAttribute(float default_value, VAR_TYPE type, string property, bool hidden_prop = false) : 
                base(property, hidden_prop, type, def_value: default_value){}
            internal override string GetDrawerCode() => $"[DFNumber({(var_type!=VAR_TYPE._INT?"0":"1")})]";
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaToggleAttribute : ShaderParameterAttribute
        {
            internal readonly bool isLeft;
            public MetaToggleAttribute(bool default_value, VAR_TYPE type, string property, bool isLeft = false, bool hidden_prop = false) : 
                base(property, hidden_prop, type, def_value: default_value?1:0)
            {
                this.isLeft = isLeft;
            }
            internal override string GetDrawerCode() => $"[DFToggle({(isLeft?"1":"0")})]";
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaRangeAttribute : ShaderParameterAttribute
        {
            internal readonly float min;
            internal readonly float max;
            public MetaRangeAttribute(float default_value, float min, float max, VAR_TYPE type,string property, bool hidden_prop = false) : 
                base(property, hidden_prop, type, def_value: default_value)
            {
                this.min = min;
                this.max = max;
            }
            internal override string GetDrawerCode()
            {
                int min_minus = (min >=0?0:1);
                int max_minus = (max >=0?0:1);
                return $"[DFRange({MathF.Abs(min)},{MathF.Abs(max)},{(var_type!=VAR_TYPE._INT?"0":"1")},{min_minus},{max_minus})]";
            }
            internal override string GetPropType() => $"Range({min},{max})";
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaVectorAttribute : ShaderParameterAttribute
        {
            internal readonly int[] drawer_args;
            public MetaVectorAttribute(float[] default_value, int[] drawer_args, VAR_TYPE type, string property, bool hidden_prop = false) : 
                base(property, hidden_prop, type, PROP_TYPE._VECTOR, (uint)drawer_args.Length, vector_def_value: default_value)
            {
                this.drawer_args = drawer_args;
            }
            internal override string GetDrawerCode() => $"[DFVector({string.Join(',',drawer_args)})]";
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaColorAttribute : ShaderParameterAttribute
        {
            public MetaColorAttribute(float[] default_value, string property, bool hidden_prop = false) : 
                base(property, hidden_prop, VAR_TYPE._HALF, PROP_TYPE._COLOR, 4, vector_def_value: default_value){}
            internal override string GetDrawerCode() => "[DFColor]";
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaTextureAttribute : ShaderParameterAttribute
        {
            public MetaTextureAttribute(string default_value, string property, bool hidden_prop = false) : 
                base(property, hidden_prop, VAR_TYPE._TEXTURE2D, path_def_value: default_value){}
            internal override string GetDrawerCode() => "[DFTexture]";
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaTextureSTAttribute : ShaderParameterAttribute
        {
            internal readonly bool two_elements;
            public MetaTextureSTAttribute(float[] default_value, string property, bool two_elements = false, bool hidden_prop = false) : 
                base(property, hidden_prop, VAR_TYPE._FLOAT, PROP_TYPE._VECTOR, 4, vector_def_value: default_value)
            {
                this.two_elements = two_elements;
            }
            internal override string GetDrawerCode() => $"[DFTextureST({(two_elements?"0":"1")})]";
            internal override string GetPropType() => "Vector";
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaTextureStrengthAttribute : ShaderParameterAttribute
        {
            internal readonly float min;
            internal readonly float max;
            public MetaTextureStrengthAttribute(float default_value, float min, float max, string property, bool hidden_prop = false) : 
                base(property, hidden_prop, VAR_TYPE._FLOAT, def_value: default_value)
            {
                this.min = min;
                this.max = max;
            }
            internal override string GetDrawerCode() => "[DFTextureStrength]";
            internal override string GetPropType() => $"Range({min},{max})";
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaSourceAttribute : ShaderParameterAttribute
        {
            internal readonly bool isOrbit;
            public MetaSourceAttribute(int default_value, string property, bool isOrbit = false, bool hidden_prop = false) : base(property, hidden_prop, VAR_TYPE._INT, def_value: default_value)
            {
                this.isOrbit = isOrbit;
            }
            internal override string GetDrawerCode() => $"[DFSource({(isOrbit?"0":"1")})]";
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaAudioLinkSourceAttribute : ShaderParameterAttribute
        {
            internal readonly uint block_type;
            public MetaAudioLinkSourceAttribute(int default_value, uint block_type, string property, bool hidden_prop = false) : base(property, hidden_prop, VAR_TYPE._INT, def_value: default_value)
            {
                this.block_type = block_type;
            }
            internal override string GetDrawerCode() => $"[DFAudioLinkSource({block_type})]";
        }

        [AttributeUsage(AttributeTargets.Field)]
        internal class MetaEnumAttribute : ShaderParameterAttribute
        {
            internal readonly PROP_DRAWER drawer;
            internal readonly int[] drawer_args;
            public MetaEnumAttribute(float default_value, PROP_DRAWER drawer, string property, bool hidden_prop = false) : base(property, hidden_prop, VAR_TYPE._INT, def_value: default_value)
            {
                this.drawer = drawer;
            }
            internal override string GetDrawerCode()
            {
                return drawer switch
                {
                    PROP_DRAWER._DF_COLOR_MASK => "[DFColorMask]",
                    PROP_DRAWER._DF_RENDERING_MODE => "[DFRenderingMode]",
                    PROP_DRAWER._DF_CULL => "[DFCull]",
                    PROP_DRAWER._DF_COMPARE => "[DFCompare]",
                    PROP_DRAWER._DF_STEREO_MERGE_MODE => "[DFStereoMergeMode]",
                    PROP_DRAWER._DF_BLEND_OP => "[DFBlendOp]",
                    PROP_DRAWER._DF_BLEND_MODE => "[DFBlendMode]",
                    PROP_DRAWER._DF_STENCIL_OP => "[DFStencilOp]",
                    PROP_DRAWER._DF_AUDIOLINK_BAND => "[DFAudioLinkBand]",
                    PROP_DRAWER._DF_AUDIOLINK_BAND_EXPANDED => "[DFAudioLinkBandExpanded]",
                    PROP_DRAWER._DF_LINE_ANIMATION_MODE => "[DFLineAnimationMode]",
                    PROP_DRAWER._DF_PARTITION_MODE => "[DFPartitionMode]",
                    PROP_DRAWER._DF_COLOR_SOURCE => "[DFColorSource]",
                    PROP_DRAWER._DF_PIXELIZATION_SPACE => "[DFPixelizationSpace]",
                    PROP_DRAWER._DF_NOISE_SPACE => "[DFNoiseSpace]",
                    PROP_DRAWER._DF_AUDIOLINK_CHRONOTENSITY_MODE => "[DFAudioLinkChoronoTensityMode]",
                    PROP_DRAWER._DF_LOOP_MODE => "[DFLoopMode]",
                    PROP_DRAWER._DF_EASE_MODE => "[DFEaseMode]",
                    PROP_DRAWER._NONE => "",
                    _ => throw new ArgumentException()
                };
            }
        }
    }
}
#endif