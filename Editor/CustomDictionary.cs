#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public class CustomDictionary
    {
        public Dictionary<CUSTOM_PROPERTY, CustomPropertyState> GetCustomProperties()
        {
            return new Dictionary<CUSTOM_PROPERTY, CustomPropertyState>
            {
                {CUSTOM_PROPERTY._Z_WRITE,new CustomPropertyState(
                new List<string>(){"_"},
                "_ZWrite", "Z Write")
                },
                {CUSTOM_PROPERTY._ACTIVATE_DIRECTIONAL_LIGHT_INFLUENCE,new CustomPropertyState(
                new List<string>(){"_","_ACTIVATE_DIRECTIONALLIGHT_INFLUENCE"},
                "_ActivateDirectionalLightInfluence", "Directional Light Influence")
                },
                {CUSTOM_PROPERTY._ACTIVATE_AMBIENT_INFLUENCE,new CustomPropertyState(
                new List<string>(){"_","_ACTIVATE_AMBIENT_INFLUENCE"},
                "_ActivateAmbientInfluence", "Ambient Influence")
                },
                {CUSTOM_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE,new CustomPropertyState(
                new List<string>(){"_","_ACTIVATE_LIGHTVOLUMES"},
                "_ActivateLightVolumesInfluence", "LightVolumes Influence")
                },
                {CUSTOM_PROPERTY._Z_CLIP,new CustomPropertyState(
                new List<string>(){"_"},
                "_ZClip", "Z Clip")
                },
                {CUSTOM_PROPERTY._ALPHA_TO_MASK,new CustomPropertyState(
                new List<string>(){"_"},
                "_AlphaToMaskMemory", "Alpha To Mask")
                },
                {CUSTOM_PROPERTY._USE_AUDIOLINK,new CustomPropertyState(
                new List<string>(){"_","_USE_AUDIOLINK"},
                "_UseAudioLink", "Use AudioLink")
                },
                {CUSTOM_PROPERTY._GEOMETRY_SCALE,new CustomPropertyState(
                new List<string>(){"_","_GEOMETRY_SCALE"},
                "_GeometryScale", "Activate Scale")
                },
                {CUSTOM_PROPERTY._GEOMETRY_EXTRUDE,new CustomPropertyState(
                new List<string>(){"_","_GEOMETRY_EXTRUDE"},
                "_GeometryExtrude", "Activate Extrude")
                },
                {CUSTOM_PROPERTY._GEOMETRY_ROTATION,new CustomPropertyState(
                new List<string>(){"_","_GEOMETRY_ROTATION"},
                "_GeometryRotation", "Activate Rotation")
                },
                {CUSTOM_PROPERTY._GEOMETRY_ROTATION_NOISE_REPEAT,new CustomPropertyState(
                new List<string>(){"_","_GEOMETRY_ROTATION_NOISE_REPEAT"},
                "_GeometryRotationNoiseRepeat", "Rotation Noise Repeat")
                },
                { CUSTOM_PROPERTY._GEOMETRY_MESSY_TOGGLE,new CustomPropertyState(
                new List<string>(){"_","_ACTIVATE_GEOMETRYMESSY"},
                "_GeometryMessyToggle", "Activate Messy")
                },

                { CUSTOM_PROPERTY._FRAGMENT_SOURCE,new CustomPropertyState(
                new List<string>(){
                    "_FRAGMENTSOURCE_VALUE",
                    "_FRAGMENTSOURCE_NOISE1ST",
                    "_FRAGMENTSOURCE_NOISE2ND",
                    "_FRAGMENTSOURCE_NOISE3RD",
                    "_FRAGMENTSOURCE_AUDIOLINK_VU",
                    "_FRAGMENTSOURCE_AUDIOLINK_CHRONOTENSITY",
                },
                "_FragmentSource", "Fragment Source")
                },

                { CUSTOM_PROPERTY._COLORING_SOURCE,new CustomPropertyState(
                new List<string>(){
                    "_COLORINGSOURCE_VALUE",
                    "_COLORINGSOURCE_NOISE1ST",
                    "_COLORINGSOURCE_NOISE2ND",
                    "_COLORINGSOURCE_NOISE3RD",
                    "_COLORINGSOURCE_AUDIOLINK_VU",
                    "_COLORINGSOURCE_AUDIOLINK_CHRONOTENSITY",
                },
                "_ColoringSource", "Coloring Source")
                },

                { CUSTOM_PROPERTY._GEOMETRY_SOURCE,new CustomPropertyState(
                new List<string>(){
                    "_GEOMETRYSOURCE_VALUE",
                    "_GEOMETRYSOURCE_NOISE1ST",
                    "_GEOMETRYSOURCE_NOISE2ND",
                    "_GEOMETRYSOURCE_NOISE3RD",
                    "_GEOMETRYSOURCE_AUDIOLINK_VU",
                    "_GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY",
                },
                "_GeometrySource", "Geometry Source")
                },

                { CUSTOM_PROPERTY._GEOMETRY_MESSY_SOURCE,new CustomPropertyState(
                new List<string>(){
                    "_GEOMETRYMESSYSOURCE_VALUE",
                    "_GEOMETRYMESSYSOURCE_NOISE1ST",
                    "_GEOMETRYMESSYSOURCE_NOISE2ND",
                    "_GEOMETRYMESSYSOURCE_NOISE3RD",
                    "_GEOMETRYMESSYSOURCE_AUDIOLINK_VU",
                    "_GEOMETRYMESSYSOURCE_AUDIOLINK_CHRONOTENSITY",
                },
                "_GeometryMessySource", "Messy Source")
                },



                { CUSTOM_PROPERTY._NOISE1ST_SPACE,new CustomPropertyState(
                new List<string>(){
                    "_NOISE1STSPACE_OFFSET",
                    "_NOISE1STSPACE_MODEL",
                    "_NOISE1STSPACE_WORLD",
                    "_NOISE1STSPACE_ORIGIN_WORLD",
                    "_NOISE1STSPACE_MODEL_WORLD",
                    "_NOISE1STSPACE_VERTEX_COLOR",
                    },
                "_Noise1stSpace", "Space")
                },
                { CUSTOM_PROPERTY._NOISE2ND_SPACE,new CustomPropertyState(
                new List<string>(){
                    "_NOISE2NDSPACE_OFFSET",
                    "_NOISE2NDSPACE_MODEL",
                    "_NOISE2NDSPACE_WORLD",
                    "_NOISE2NDSPACE_ORIGIN_WORLD",
                    "_NOISE2NDSPACE_MODEL_WORLD",
                    "_NOISE2NDSPACE_VERTEX_COLOR",
                    },
                "_Noise2ndSpace", "Space")
                },
                { CUSTOM_PROPERTY._NOISE3RD_SPACE,new CustomPropertyState(
                new List<string>(){
                    "_NOISE3RDSPACE_OFFSET",
                    "_NOISE3RDSPACE_MODEL",
                    "_NOISE3RDSPACE_WORLD",
                    "_NOISE3RDSPACE_ORIGIN_WORLD",
                    "_NOISE3RDSPACE_MODEL_WORLD",
                    "_NOISE3RDSPACE_VERTEX_COLOR",
                    },
                "_Noise3rdSpace", "Space")
                },

                {CUSTOM_PROPERTY._RENDERING_MODE,new CustomPropertyState(
                    new List<string>(){
                        "_RENDERINGMODE_TRANSPARENT",
                        "_RENDERINGMODE_CUTOUT",
                        "_RENDERINGMODE_SHADOWONLY",
                    },
                    "_RenderingMode", "Rendering Mode"
                )

                }

            };
        }
        public Dictionary<SHADER_PROPERTY, ShaderPropertyState> GetShaderProperties()
        {
            return new Dictionary<SHADER_PROPERTY, ShaderPropertyState>
            {
                {SHADER_PROPERTY._CULL,new ShaderPropertyState(
                    "_Cull", "Culling Mode")
                },
                {SHADER_PROPERTY._ZWRITE,new ShaderPropertyState(
                    "_ZWrite", "Z Write")
                },
                {SHADER_PROPERTY._FORCED_Z_SCALE_ZERO,new ShaderPropertyState(
                    "_Forced_Z_Scale_Zero", "Forced Z Scale Zero")
                },
                {SHADER_PROPERTY._BILLBOARD_MODE,new ShaderPropertyState(
                    "_BillboardMode", "Billboard Mode(Feature)")
                },
                { SHADER_PROPERTY._DISTANCE_INFLUENCE,new ShaderPropertyState(
                    "_DistanceInfluence", "Distance Influence")
                },
                {SHADER_PROPERTY._STEREO_MERGE_MODE,new ShaderPropertyState(
                    "_StereoMergeMode", "Stereo Merge Mode(Feature)")
                },
                {SHADER_PROPERTY._USE_FWIDTH,new ShaderPropertyState(
                    "_UseFwidth", "Use fwidth()")
                },
                {SHADER_PROPERTY._DIRECTIONAL_LIGHT_INFLUENCE,new ShaderPropertyState(
                    "_DirectionalLightInfluence", "")
                },
                {SHADER_PROPERTY._AMBIENT_INFLUENCE,new ShaderPropertyState(
                    "_AmbientInfluence", "")
                },
                {SHADER_PROPERTY._LIGHTVOLUMES_INFLUENCE,new ShaderPropertyState(
                    "_LightVolumesInfluence", "")
                },
                {SHADER_PROPERTY._PREVIEW_MODE,new ShaderPropertyState(
                    "_PreviewMode", "Preview Mode")
                },

                {SHADER_PROPERTY._BLEND_OP,new ShaderPropertyState(
                    "_BlendOp", "Blend Operation")
                },
                {SHADER_PROPERTY._SRC_BLEND,new ShaderPropertyState(
                    "_SrcBlend", "Blend Mode Source")
                },
                {SHADER_PROPERTY._DST_BLEND,new ShaderPropertyState(
                    "_DstBlend", "Blend Mode Destination")
                },
                {SHADER_PROPERTY._BLEND_OP_ALPHA,new ShaderPropertyState(
                    "_BlendOpAlpha", "Alpha Blend Operation")
                },
                {SHADER_PROPERTY._SRC_BLEND_ALPHA,new ShaderPropertyState(
                    "_SrcBlendAlpha", "Alpha Blend Mode Source")
                },
                {SHADER_PROPERTY._DST_BLEND_ALPHA,new ShaderPropertyState(
                    "_DstBlendAlpha", "Alpha Blend Mode Destination")
                },
                {SHADER_PROPERTY._Z_TEST,new ShaderPropertyState(
                    "_ZTest","Z Test")
                },
                {SHADER_PROPERTY._COLOR_MASK,new ShaderPropertyState(
                    "_ColorMask","Color Mask")
                },
                {SHADER_PROPERTY._OFFSET_FACTOR,new ShaderPropertyState(
                    "_OffsetFactor","Offset Factor")
                },
                {SHADER_PROPERTY._OFFSET_UNITS,new ShaderPropertyState(
                    "_OffsetUnits","Offset Units")
                },

                {SHADER_PROPERTY._STENCIL_REF,new ShaderPropertyState(
                    "_StencilRef","Stencil Ref")
                },
                {SHADER_PROPERTY._STENCIL_READ_MASK,new ShaderPropertyState(
                    "_StencilReadMask","Stencil Read Mask")
                },
                {SHADER_PROPERTY._STENCIL_WRITE_MASK,new ShaderPropertyState(
                    "_StencilWriteMask","Stencil Write Mask")
                },
                {SHADER_PROPERTY._STENCIL_COMP,new ShaderPropertyState(
                    "_StencilComp","Stencil Comp")
                },
                {SHADER_PROPERTY._STENCIL_PASS,new ShaderPropertyState(
                    "_StencilPass","Stencil Pass")
                },
                {SHADER_PROPERTY._STENCIL_FAIL,new ShaderPropertyState(
                    "_StencilFail","Stencil Fail")
                },
                {SHADER_PROPERTY._STENCIL_Z_FAIL,new ShaderPropertyState(
                    "_StencilZFail","Stencil ZFail")
                },

                {SHADER_PROPERTY._MAIN_TEX,new ShaderPropertyState(
                    "_MainTex", "Fallback Texture")
                },

                {SHADER_PROPERTY._AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState(
                    "_AudioLinkMaskControlTex", "AudioLink Mask Control Tex")
                },
                {SHADER_PROPERTY._AUDIOLINK_MASK_CONTROL,new ShaderPropertyState(
                    "_AudioLinkMaskControl", "AudioLink Mask Control Strength")
                },
                {SHADER_PROPERTY._FRAGMENT_MASK_CONTROL_TEX,new ShaderPropertyState(
                    "_FragmentMaskControlTex", "Fragment Mask Control Tex")
                },
                {SHADER_PROPERTY._FRAGMENT_MASK_CONTROL,new ShaderPropertyState(
                    "_FragmentMaskControl", "Fragment Mask Control Strength")
                },
                {SHADER_PROPERTY._COLORING_MASK_CONTROL_TEX,new ShaderPropertyState(
                    "_ColoringMaskControlTex", "Coloring Mask Control Tex")
                },
                {SHADER_PROPERTY._COLORING_MASK_CONTROL,new ShaderPropertyState(
                    "_ColoringMaskControl", "Coloring Mask Control Strength")
                },
                {SHADER_PROPERTY._GEOMETRY_MASK_CONTROL_TEX,new ShaderPropertyState(
                    "_GeometryMaskControlTex", "Geometry Mask Control Tex")
                },
                {SHADER_PROPERTY._GEOMETRY_MASK_CONTROL,new ShaderPropertyState(
                    "_GeometryMaskControl", "Geometry Mask Control Strength")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_MASK_CONTROL_TEX,new ShaderPropertyState(
                    "_GeometryMessyMaskControlTex", "Messy Mask Control Tex")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_MASK_CONTROL,new ShaderPropertyState(
                    "_GeometryMessyMaskControl", "Messy Mask Control Strength")
                },
                {SHADER_PROPERTY._NOISE1ST_OFFSET_CONTROL_TEX,new ShaderPropertyState(
                    "_Noise1stMaskControlTex", "Noise 1st Offset Control Tex")
                },
                {SHADER_PROPERTY._NOISE1ST_OFFSET_CONTROL,new ShaderPropertyState(
                    "_Noise1stMaskControl", "Noise 1st Offset Control Strength")
                },
                {SHADER_PROPERTY._NOISE2ND_OFFSET_CONTROL_TEX,new ShaderPropertyState(
                    "_Noise2ndMaskControlTex", "Noise 2nd Offset Control Tex")
                },
                {SHADER_PROPERTY._NOISE2ND_OFFSET_CONTROL,new ShaderPropertyState(
                    "_Noise2ndMaskControl", "Noise 2nd Offset Control")
                },
                {SHADER_PROPERTY._NOISE3RD_OFFSET_CONTROL_TEX,new ShaderPropertyState(
                    "_Noise3rdMaskControlTex", "Noise 3rd Offset Control Tex")
                },
                {SHADER_PROPERTY._NOISE3RD_OFFSET_CONTROL,new ShaderPropertyState(
                    "_Noise3rdMaskControl", "Noise 3rd Offset Control")
                },

                {SHADER_PROPERTY._AUDIOLINK_VU_BAND,new ShaderPropertyState(
                    "_AudioLinkVUBand", "VU Band")
                },
                {SHADER_PROPERTY._AUDIOLINK_VU_SMOOTH,new ShaderPropertyState(
                    "_AudioLinkVUSmooth", "VU Smooth")
                },
                {SHADER_PROPERTY._AUDIOLINK_VU_PANNING,new ShaderPropertyState(
                    "_AudioLinkVUPanning", "VU Panning")
                },
                {SHADER_PROPERTY._AUDIOLINK_VU_GAIN_MUL,new ShaderPropertyState(
                    "_AudioLinkVUGainMul", "VU Gain(Mul)")
                },
                {SHADER_PROPERTY._AUDIOLINK_VU_GAIN_ADD,new ShaderPropertyState(
                    "_AudioLinkVUGainAdd", "VU Gain(Add)")
                },
                {SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_SCALE,new ShaderPropertyState(
                    "_AudioLinkChronoTensityScale", "Chrono Tensity Scale")
                },
                {SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_BAND,new ShaderPropertyState(
                    "_AudioLinkChronoTensityBand", "Chrono Tensity Band")
                },
                {SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_TYPE,new ShaderPropertyState(
                    "_AudioLinkChronoTensityType", "Chrono Tensity Type")
                },
                {SHADER_PROPERTY._AUDIOLINK_THEME_COLOR_BAND,new ShaderPropertyState(
                    "_AudioLinkThemeColorBand", "Theme Color Band")
                },

                {SHADER_PROPERTY._TRIANGLE_COMP,new ShaderPropertyState(
                    "_TriangleComp", "Triangle Compression")
                },
                {SHADER_PROPERTY._FILL,new ShaderPropertyState(
                    "_Fill", "Fill")
                },
                {SHADER_PROPERTY._LINE_WIDTH,new ShaderPropertyState(
                    "_LineWidth", "Line Width")
                },
                {SHADER_PROPERTY._LINE_GRADIENT_BIAS,new ShaderPropertyState(
                    "_LineGradientBias", "Line Gradient Bias")
                },
                {SHADER_PROPERTY._LINE_SCALE,new ShaderPropertyState(
                    "_LineScale", "Line Scale")
                },
                {SHADER_PROPERTY._LINE_FADE_MODE,new ShaderPropertyState(
                    "_LineFadeMode", "Line Fade Mode")
                },
                {SHADER_PROPERTY._FRAGMENT_VALUE,new ShaderPropertyState(
                    "_FragmentValue", "Fragment Value")
                },
                {SHADER_PROPERTY._PARTITION_TYPE,new ShaderPropertyState(
                    "_PartitionType", "Partition Type")
                },

                { SHADER_PROPERTY._COLOR0,new ShaderPropertyState(
                    "_Color0", "Primary Color")
                },
                {SHADER_PROPERTY._COLOR1,new ShaderPropertyState(
                    "_Color1", "Secondary Color")
                },
                {SHADER_PROPERTY._EMISSION,new ShaderPropertyState(
                    "_Emission", "Add Emission")
                },
                {SHADER_PROPERTY._COLOR_SOURCE,new ShaderPropertyState(
                    "_ColorSource", "Color Source")
                },
                {SHADER_PROPERTY._COLOR_GRADIENT_TEX,new ShaderPropertyState(
                    "_ColorGradientTex", "Gradient Tex")
                },
                {SHADER_PROPERTY._COLOR_VALUE,new ShaderPropertyState(
                    "_ColoringValue", "Coloring Value")
                },
                {SHADER_PROPERTY._COLORING_PARTITION_TYPE,new ShaderPropertyState(
                    "_ColoringPartitionType", "Coloring Partition")
                },

                {SHADER_PROPERTY._GEOMETRY_VALUE,new ShaderPropertyState(
                    "_GeometryValue", "Geometry Value")
                },
                {SHADER_PROPERTY._GEOMETRY_SCALE0,new ShaderPropertyState(
                    "_GeometryScale0", "Scale Range 0")
                },
                {SHADER_PROPERTY._GEOMETRY_SCALE1,new ShaderPropertyState(
                    "_GeometryScale1", "Scale Range 1")
                },
                {SHADER_PROPERTY._GEOMETRY_EXTRUDE0,new ShaderPropertyState(
                    "_GeometryExtrude0", "Extrude Range 0")
                },
                {SHADER_PROPERTY._GEOMETRY_EXTRUDE1,new ShaderPropertyState(
                    "_GeometryExtrude1", "Extrude Range 1")
                },
                {SHADER_PROPERTY._GEOMETRY_ROTATION0,new ShaderPropertyState(
                    "_GeometryRotation0", "Rotation Range 0")
                },
                {SHADER_PROPERTY._GEOMETRY_ROTATION1,new ShaderPropertyState(
                    "_GeometryRotation1", "Rotation Range 1")
                },
                {SHADER_PROPERTY._GEOMETRY_ROTATION_REVERSE,new ShaderPropertyState(
                    "_GeometryRotationReverse", "Rotation Reverse")
                },

                {SHADER_PROPERTY._GEOMETRY_MESSY_VALUE,new ShaderPropertyState(
                    "_GeometryMessyValue", "Messy Value")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_SEED,new ShaderPropertyState(
                    "_GeometryMessySeed", "Messy Primitive Seed")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_ROTATION,new ShaderPropertyState(
                    "_GeometryMessyOrbitRotation", "Messy Orbit Rotation")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_ROTATION_FORWARD,new ShaderPropertyState(
                    "_GeometryMessyOrbitRotationForward", "Messy Orbit Rotation Forward")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_ROTATION_RIGHT,new ShaderPropertyState(
                    "_GeometryMessyOrbitRotationRight", "Messy Orbit Rotation Right")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_POSITION,new ShaderPropertyState(
                    "_GeometryMessyOrbitPosition", "Messy Orbit Position")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_SCALE_Y,new ShaderPropertyState(
                    "_GeometryMessyOrbitScaleY", "Messy Orbit Scale Y")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_SCALE_Z,new ShaderPropertyState(
                    "_GeometryMessyOrbitScaleZ", "Messy Orbit Scale Z")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_VARIANCE,new ShaderPropertyState(
                    "_GeometryMessyOrbitVariance", "Messy Orbit Variance")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_ROTATION_PHASE,new ShaderPropertyState(
                    "_GeometryMessyOrbitRotationPhase", "Orbit Rotation Phase")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_ROTATION_TIME_MULTIPLIER,new ShaderPropertyState(
                    "_GeometryMessyOrbitRotationTimeMultiplier", "Orbit Rotation Time Multiplier")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_WAVE_XY_STRENGTH,new ShaderPropertyState(
                    "_GeometryMessyOrbitWaveXYStrength", "Orbit Wave XY Strength")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_WAVE_XY_FREQUENCY,new ShaderPropertyState(
                    "_GeometryMessyOrbitWaveXYFrequency", "Orbit Wave XY Frequency")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_WAVE_XY_PHASE,new ShaderPropertyState(
                    "_GeometryMessyOrbitWaveXYPhase", "Orbit Wave XY Phase")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_WAVE_XY_TIME_MULTIPLIER,new ShaderPropertyState(
                    "_GeometryMessyOrbitWaveXYTimeMultiplier", "Orbit Wave XY Time Multiplier")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_WAVE_Z_STRENGTH,new ShaderPropertyState(
                    "_GeometryMessyOrbitWaveZStrength", "Orbit Wave Z Strength")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_WAVE_Z_FREQUENCY,new ShaderPropertyState(
                    "_GeometryMessyOrbitWaveZFrequency", "Orbit Wave Z Frequency")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_WAVE_Z_PHASE,new ShaderPropertyState(
                    "_GeometryMessyOrbitWaveZPhase", "Orbit Wave Z Phase")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_WAVE_Z_TIME_MULTIPLIER,new ShaderPropertyState(
                    "_GeometryMessyOrbitWaveZTimeMultiplier", "Orbit Wave Z Time Multiplier")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_REFERENCE_TIME,new ShaderPropertyState(
                    "_GeometryMessyReferenceTime", "Orbit Rotation Reference Time")
                },
                {SHADER_PROPERTY._ORBIT_ROTATION_REF_AUDIOLINK,new ShaderPropertyState(
                    "_OrbitRotationRefAudioLink", "Orbit Rotation Reference AudioLink")
                },
                {SHADER_PROPERTY._GEOMETRY_MESSY_ORBIT_AUDIOLINK_STRENGTH,new ShaderPropertyState(
                    "_GeometryMessyOrbitAudioLinkStrength", "Orbit Rotation AudioLink Strength")
                },
                { SHADER_PROPERTY._GEOMETRY_PARTITION_BIAS,new ShaderPropertyState(
                    "_GeometryPartitionBias", "Geometry Partition Bias| Vertex <=> Center")
                },
                {SHADER_PROPERTY._PIXELIZATION_SPACE,new ShaderPropertyState(
                    "_PixelizationSpace", "Vertex Pixelization Position Space")
                },
                {SHADER_PROPERTY._PIXELIZATION,new ShaderPropertyState(
                    "_Pixelization", "Vertex Pixelization")
                },

                { SHADER_PROPERTY._NOISE1ST_OFFSET0,new ShaderPropertyState(
                    "_Noise1stOffset0", "Offset")
                },
                {SHADER_PROPERTY._NOISE1ST_SCALE0,new ShaderPropertyState(
                    "_Noise1stScale0", "Scale")
                },
                {SHADER_PROPERTY._NOISE1ST_OFFSET1,new ShaderPropertyState(
                    "_Noise1stOffset1", "World Offset")
                },
                {SHADER_PROPERTY._NOISE1ST_SCALE1,new ShaderPropertyState(
                    "_Noise1stScale1", "World Scale")
                },
                {SHADER_PROPERTY._NOISE1ST_OFFSET_BEFORE_SCALE,new ShaderPropertyState(
                    "_Noise1stOffsetBeforeScale", "Offset before Scale")
                },
                {SHADER_PROPERTY._NOISE1ST_SEED,new ShaderPropertyState(
                    "_Noise1stSeed", "Seed")
                },
                {SHADER_PROPERTY._NOISE1ST_VALUE_CURVE,new ShaderPropertyState(
                    "_Noise1stValueCurve", "Value Curve")
                },
                {SHADER_PROPERTY._NOISE1ST_CURVE_TYPE,new ShaderPropertyState(
                    "_Noise1stCurveType", "Curve Type")
                },
                {SHADER_PROPERTY._NOISE1ST_THRESHOLD_MUL,new ShaderPropertyState(
                    "_Noise1stThresholdMul", "Threshold(Mul)")
                },
                {SHADER_PROPERTY._NOISE1ST_THRESHOLD_ADD,new ShaderPropertyState(
                    "_Noise1stThresholdAdd", "Threshold(Add)")
                },
                {SHADER_PROPERTY._NOISE1ST_TIME_MULTI,new ShaderPropertyState(
                    "_Noise1stTimeMulti", "Time Multiplier")
                },
                {SHADER_PROPERTY._NOISE1ST_TIME_PHASE,new ShaderPropertyState(
                    "_Noise1stTimePhase", "Time Phase")
                },
                {SHADER_PROPERTY._NOISE1ST_PHASE_SCALE,new ShaderPropertyState(
                    "_Noise1stPhaseScale", "Phase Scale")
                },
                {SHADER_PROPERTY._NOISE1ST_REFERENCE_TIME,new ShaderPropertyState(
                    "_Noise1stReferenceTime", "Reference Time")
                },
                {SHADER_PROPERTY._NOISE1ST_PHASE_REF_AUDIOLINK,new ShaderPropertyState(
                    "_Noise1stPhaseRefAudioLink", "Phase Reference AudioLink")
                },

                { SHADER_PROPERTY._NOISE2ND_OFFSET0,new ShaderPropertyState(
                    "_Noise2ndOffset0", "Offset")
                },
                {SHADER_PROPERTY._NOISE2ND_SCALE0,new ShaderPropertyState(
                    "_Noise2ndScale0", "Scale")
                },
                {SHADER_PROPERTY._NOISE2ND_OFFSET1,new ShaderPropertyState(
                    "_Noise2ndOffset1", "World Offset")
                },
                {SHADER_PROPERTY._NOISE2ND_SCALE1,new ShaderPropertyState(
                    "_Noise2ndScale1", "World Scale")
                },
                {SHADER_PROPERTY._NOISE2ND_OFFSET_BEFORE_SCALE,new ShaderPropertyState(
                    "_Noise2ndOffsetBeforeScale", "Offset before Scale")
                },
                {SHADER_PROPERTY._NOISE2ND_SEED,new ShaderPropertyState(
                    "_Noise2ndSeed", "Seed")
                },
                {SHADER_PROPERTY._NOISE2ND_VALUE_CURVE,new ShaderPropertyState(
                    "_Noise2ndValueCurve", "Value Curve")
                },
                {SHADER_PROPERTY._NOISE2ND_CURVE_TYPE,new ShaderPropertyState(
                    "_Noise2ndCurveType", "Curve Type")
                },
                {SHADER_PROPERTY._NOISE2ND_THRESHOLD_MUL,new ShaderPropertyState(
                    "_Noise2ndThresholdMul", "Threshold(Mul)")
                },
                {SHADER_PROPERTY._NOISE2ND_THRESHOLD_ADD,new ShaderPropertyState(
                    "_Noise2ndThresholdAdd", "Threshold(Add)")
                },
                {SHADER_PROPERTY._NOISE2ND_TIME_MULTI,new ShaderPropertyState(
                    "_Noise2ndTimeMulti", "Time Multiplier")
                },
                {SHADER_PROPERTY._NOISE2ND_TIME_PHASE,new ShaderPropertyState(
                    "_Noise2ndTimePhase", "Time Phase")
                },
                {SHADER_PROPERTY._NOISE2ND_PHASE_SCALE,new ShaderPropertyState(
                    "_Noise2ndPhaseScale", "Phase Scale")
                },
                {SHADER_PROPERTY._NOISE2ND_REFERENCE_TIME,new ShaderPropertyState(
                    "_Noise2ndReferenceTime", "Reference Time")
                },
                {SHADER_PROPERTY._NOISE2ND_PHASE_REF_AUDIOLINK,new ShaderPropertyState(
                    "_Noise2ndPhaseRefAudioLink", "Phase Reference AudioLink")
                },

                { SHADER_PROPERTY._NOISE3RD_OFFSET0,new ShaderPropertyState(
                    "_Noise3rdOffset0", "Offset")
                },
                {SHADER_PROPERTY._NOISE3RD_SCALE0,new ShaderPropertyState(
                    "_Noise3rdScale0", "Scale")
                },
                {SHADER_PROPERTY._NOISE3RD_OFFSET1,new ShaderPropertyState(
                    "_Noise3rdOffset1", "World Offset")
                },
                {SHADER_PROPERTY._NOISE3RD_SCALE1,new ShaderPropertyState(
                    "_Noise3rdScale1", "World Scale")
                },
                {SHADER_PROPERTY._NOISE3RD_OFFSET_BEFORE_SCALE,new ShaderPropertyState(
                    "_Noise3rdOffsetBeforeScale", "Offset before Scale")
                },
                {SHADER_PROPERTY._NOISE3RD_SEED,new ShaderPropertyState(
                    "_Noise3rdSeed", "Seed")
                },
                {SHADER_PROPERTY._NOISE3RD_VALUE_CURVE,new ShaderPropertyState(
                    "_Noise3rdValueCurve", "Value Curve")
                },
                {SHADER_PROPERTY._NOISE3RD_CURVE_TYPE,new ShaderPropertyState(
                    "_Noise3rdCurveType", "Curve Type")
                },
                {SHADER_PROPERTY._NOISE3RD_THRESHOLD_MUL,new ShaderPropertyState(
                    "_Noise3rdThresholdMul", "Threshold(Mul)")
                },
                {SHADER_PROPERTY._NOISE3RD_THRESHOLD_ADD,new ShaderPropertyState(
                    "_Noise3rdThresholdAdd", "Threshold(Add)")
                },
                {SHADER_PROPERTY._NOISE3RD_TIME_MULTI,new ShaderPropertyState(
                    "_Noise3rdTimeMulti", "Time Multiplier")
                },
                {SHADER_PROPERTY._NOISE3RD_TIME_PHASE,new ShaderPropertyState(
                    "_Noise3rdTimePhase", "Time Phase")
                },
                {SHADER_PROPERTY._NOISE3RD_PHASE_SCALE,new ShaderPropertyState(
                    "_Noise3rdPhaseScale", "Phase Scale")
                },
                {SHADER_PROPERTY._NOISE3RD_REFERENCE_TIME,new ShaderPropertyState(
                    "_Noise3rdReferenceTime", "Reference Time")
                },
                {SHADER_PROPERTY._NOISE3RD_PHASE_REF_AUDIOLINK,new ShaderPropertyState(
                    "_Noise3rdPhaseRefAudioLink", "Phase Reference AudioLink")
                },

                { SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_T,new ShaderPropertyState(
                    "_CustomRenderQueueT","Transparent Render Queue")
                },
                {SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C,new ShaderPropertyState(
                    "_CustomRenderQueueC","Cutout Render Queue")
                }

            };
        }
        public static Dictionary<CUSTOM_GUI, GUIStyle> gui = new Dictionary<CUSTOM_GUI, GUIStyle> {
            {CUSTOM_GUI.PLAIN,new GUIStyle(){

            }},
            {CUSTOM_GUI.TITLE0,new GUIStyle(){
                richText = true, alignment = TextAnchor.UpperCenter, fontSize = 32
            }},
            {CUSTOM_GUI.TITLE1,new GUIStyle(){
                richText = true, alignment = TextAnchor.UpperCenter, fontSize = 24
            }},
            {CUSTOM_GUI.HEADER0,new GUIStyle(){
                richText = true, alignment = TextAnchor.UpperLeft, fontSize = 16
            }}
        };

    }
    public class CustomPropertyState {
        public MaterialProperty var;
        readonly public string property;
        public string display;
        readonly public List<string> keywords;
        public int value = 0;
        public CustomPropertyState(List<string> k, string p, string d)
        {
            keywords = k;
            property = p;
            display = d;
        }
    }
    public class ShaderPropertyState {
        public MaterialProperty var;
        readonly public string property;
        public string display;
        public ShaderPropertyState(string p, string d)
        {
            property = p;
            display = d;
        }
    }
}
#endif