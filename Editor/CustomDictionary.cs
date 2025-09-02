#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    internal class CustomDictionary
    {
        internal Dictionary<SHADER_PROPERTY, ShaderPropertyState> GetShaderProperties()
        {
            return new Dictionary<SHADER_PROPERTY, ShaderPropertyState>
            {
                {SHADER_PROPERTY._RENDERING_MODE,new ShaderPropertyState(
                    "_RenderingMode", "Rendering Mode")
                },
                {SHADER_PROPERTY._CULL,new ShaderPropertyState(
                    "_Cull", "Culling Mode")
                },
                {SHADER_PROPERTY._Z_WRITE,new ShaderPropertyState(
                    "_ZWrite", "Z Write")
                },
                {SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_T,new ShaderPropertyState(
                    "_CustomRenderQueueT","Transparent Render Queue")
                },
                {SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C,new ShaderPropertyState(
                    "_CustomRenderQueueC","Cutout Render Queue")
                },
                { SHADER_PROPERTY._FORCED_Z_SCALE_ZERO,new ShaderPropertyState(
                    "_Forced_Z_Scale_Zero", "Forced Z Scale Zero")
                },
                {SHADER_PROPERTY._BILLBOARD_MODE,new ShaderPropertyState(
                    "_BillboardMode", "Billboard Mode(Feature)")
                },
                {SHADER_PROPERTY._DISTANCE_INFLUENCE,new ShaderPropertyState(
                    "_DistanceInfluence", "Distance Influence")
                },
                {SHADER_PROPERTY._STEREO_MERGE_MODE,new ShaderPropertyState(
                    "_StereoMergeMode", "Stereo Merge Mode(Feature)")
                },
                {SHADER_PROPERTY._USE_FWIDTH,new ShaderPropertyState(
                    "_UseFwidth", "Use fwidth()")
                },

                {SHADER_PROPERTY._ACTIVATE_DIRECTIONAL_LIGHT_INFLUENCE, new ShaderPropertyState(
                    "_ActivateDirectionalLightInfluence", "Directional Light Influence"
                )},
                {SHADER_PROPERTY._DIRECTIONAL_LIGHT_INFLUENCE,new ShaderPropertyState(
                    "_DirectionalLightInfluence", "")
                },
                {SHADER_PROPERTY._ACTIVATE_AMBIENT_INFLUENCE, new ShaderPropertyState(
                    "_ActivateAmbientInfluence", "Ambient Influence"
                )},
                {SHADER_PROPERTY._AMBIENT_INFLUENCE,new ShaderPropertyState(
                    "_AmbientInfluence", "")
                },
                {SHADER_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE, new ShaderPropertyState(
                    "_ActivateLightVolumesInfluence", "LightVolumes Influence"
                )},
                {SHADER_PROPERTY._LIGHTVOLUMES_INFLUENCE,new ShaderPropertyState(
                    "_LightVolumesInfluence", "")
                },
                {SHADER_PROPERTY._PREVIEW_MODE,new ShaderPropertyState(
                    "_PreviewMode", "Preview Mode")
                },
                {SHADER_PROPERTY._ANTI_ALIASING,new ShaderPropertyState(
                    "_AntiAliasing", "Anti Aliasing")
                },

                {SHADER_PROPERTY._MAIN_TEX,new ShaderPropertyState(
                    "_MainTex", "Fallback Texture")
                },

                {SHADER_PROPERTY._Z_CLIP,new ShaderPropertyState(
                    "_ZClip","Z Clip")
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
                {SHADER_PROPERTY._ALPHA_TO_MASK,new ShaderPropertyState(
                    "_AlphaToMaskMemory", "Alpha To Mask")
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


                {SHADER_PROPERTY._USE_AUDIOLINK,new ShaderPropertyState(
                    "_UseAudioLink", "Use AudioLink")
                },
                { SHADER_PROPERTY._AUDIOLINK_VU_BAND,new ShaderPropertyState(
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
                {SHADER_PROPERTY._MANUAL_LINE_SCALING,new ShaderPropertyState(
                    "_ManualLineScaling", "Manual Line Scaling")
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
                {SHADER_PROPERTY._FRAGMENT_INVERSE,new ShaderPropertyState(
                    "_FragmentInverse", "Fragment Inverse")
                },
                {SHADER_PROPERTY._PARTITION_TYPE,new ShaderPropertyState(
                    "_PartitionType", "Partition Type")
                },


                {SHADER_PROPERTY._COLOR0,new ShaderPropertyState(
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
                {SHADER_PROPERTY._GEOMETRY_SCALE,new ShaderPropertyState(
                    "_GeometryScale", "Activate Scale")
                },
                {SHADER_PROPERTY._GEOMETRY_SCALE_RANGE,new ShaderPropertyState(
                    "_GeometryScaleRange", "Scale Range")
                },
                {SHADER_PROPERTY._GEOMETRY_EXTRUDE,new ShaderPropertyState(
                    "_GeometryExtrude", "Activate Extrude")
                },
                {SHADER_PROPERTY._GEOMETRY_EXTRUDE_RANGE,new ShaderPropertyState(
                    "_GeometryExtrudeRange", "Extrude Range")
                },
                {SHADER_PROPERTY._GEOMETRY_ROTATION,new ShaderPropertyState(
                    "_GeometryRotation", "Activate Rotation")
                },
                {SHADER_PROPERTY._GEOMETRY_ROTATION_REVERSE,new ShaderPropertyState(
                    "_GeometryRotationReverse", "Rotation Reverse")
                },
                {SHADER_PROPERTY._GEOMETRY_ROTATION_NOISE_REPEAT,new ShaderPropertyState(
                    "_GeometryRotationNoiseRepeat", "Rotation Noise Repeat")
                },

                {SHADER_PROPERTY._GEOMETRY_PARTITION_BIAS,new ShaderPropertyState(
                    "_GeometryPartitionBias", "Geometry Partition Bias| Vertex <=> Center")
                },
                {SHADER_PROPERTY._PIXELIZATION_SPACE,new ShaderPropertyState(
                    "_PixelizationSpace", "Vertex Pixelization Position Space")
                },
                {SHADER_PROPERTY._PIXELIZATION,new ShaderPropertyState(
                    "_Pixelization", "Vertex Pixelization")
                },


                {SHADER_PROPERTY._ACTIVATE_ORBIT,new ShaderPropertyState(
                    "_ActivateOrbit", "Activate Orbit")
                },

                {SHADER_PROPERTY._ORBIT_VALUE,new ShaderPropertyState(
                    "_OrbitValue", "Orbit Value")
                },
                {SHADER_PROPERTY._ORBIT_SEED,new ShaderPropertyState(
                    "_OrbitSeed", "Orbit Seed")
                },
                {SHADER_PROPERTY._ORBIT_ROTATION_VALUE,new ShaderPropertyState(
                    "_OrbitRotationValue", "Orbit Rotation Value")
                },
                {SHADER_PROPERTY._ORBIT_ROTATION_SEED,new ShaderPropertyState(
                    "_OrbitRotationSeed", "Orbit Rotation Seed")
                },
                {SHADER_PROPERTY._ORBIT_ROTATION,new ShaderPropertyState(
                    "_OrbitRotation", "Orbit Rotation")
                },
                {SHADER_PROPERTY._ORBIT_ROTATION_TIME_MULTIPLIER,new ShaderPropertyState(
                    "_OrbitRotationTimeMultiplier", "Orbit Rotation Time Multiplier")
                },
                {SHADER_PROPERTY._ORBIT_ROTATION_VARIANCE,new ShaderPropertyState(
                    "_OrbitRotationVariance", "Orbit Rotation Variance")
                },

                {SHADER_PROPERTY._ORBIT_ROTATION_REF_AUDIOLINK,new ShaderPropertyState(
                    "_OrbitRotationRefAudioLink", "Orbit Rotation Reference AudioLink")
                },
                {SHADER_PROPERTY._ORBIT_ROTATION_AUDIOLINK_STRENGTH,new ShaderPropertyState(
                    "_OrbitRotationAudioLinkStrength", "Orbit Rotation AudioLink Strength")
                },

                {SHADER_PROPERTY._ORBIT_OFFSET,new ShaderPropertyState(
                    "_OrbitOffset", "Orbit Offset")
                },
                {SHADER_PROPERTY._ORBIT_SCALE,new ShaderPropertyState(
                    "_OrbitScale", "Orbit Scale")
                },

                {SHADER_PROPERTY._ORBIT_WAVE_XY_STRENGTH,new ShaderPropertyState(
                    "_OrbitWaveXYStrength", "Orbit Wave XY Strength")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_XY_FREQUENCY,new ShaderPropertyState(
                    "_OrbitWaveXYFrequency", "Orbit Wave XY Frequency")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_XY_PHASE,new ShaderPropertyState(
                    "_OrbitWaveXYPhase", "Orbit Wave XY Phase")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_XY_TIME_MULTIPLIER,new ShaderPropertyState(
                    "_OrbitWaveXYTimeMultiplier", "Orbit Wave XY Time Multiplier")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_Z_STRENGTH,new ShaderPropertyState(
                    "_OrbitWaveZStrength", "Orbit Wave Z Strength")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_Z_FREQUENCY,new ShaderPropertyState(
                    "_OrbitWaveZFrequency", "Orbit Wave Z Frequency")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_Z_PHASE,new ShaderPropertyState(
                    "_OrbitWaveZPhase", "Orbit Wave Z Phase")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_Z_TIME_MULTIPLIER,new ShaderPropertyState(
                    "_OrbitWaveZTimeMultiplier", "Orbit Wave Z Time Multiplier")
                },

                {SHADER_PROPERTY._ORBIT_WAVE_REF_AUDIOLINK,new ShaderPropertyState(
                    "_OrbitWaveRefAudioLink", "Orbit Wave Reference AudioLink")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_STRENGTH,new ShaderPropertyState(
                    "_OrbitWaveAudioLinkStrength", "Orbit Wave AudioLink Strength")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState(
                    "_OrbitWaveAudioLinkSpectrumMirror", "AudioLink Spectrum Mirror")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_TYPE,new ShaderPropertyState(
                    "_OrbitWaveAudioLinkSpectrumType", "AudioLink Spectrum Type")
                },
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_RANGE,new ShaderPropertyState(
                    "_OrbitWaveAudioLinkSpectrumRange", "AudioLink Spectrum Range")
                },

                {SHADER_PROPERTY._FRAGMENT_SOURCE,new ShaderPropertyState(
                    "_FragmentSource", "Fragment Source")
                },
                {SHADER_PROPERTY._COLORING_SOURCE,new ShaderPropertyState(
                    "_ColoringSource", "Coloring Source")
                },
                {SHADER_PROPERTY._GEOMETRY_SOURCE,new ShaderPropertyState(
                    "_GeometrySource", "Geometry Source")
                },
                {SHADER_PROPERTY._ORBIT_SOURCE,new ShaderPropertyState(
                    "_OrbitSource", "Orbit Source")
                },
                {SHADER_PROPERTY._ORBIT_ROTATION_SOURCE,new ShaderPropertyState(
                    "_OrbitRotationSource", "Orbit Rotation Source")
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
                {SHADER_PROPERTY._ORBIT_MASK_CONTROL_TEX,new ShaderPropertyState(
                    "_OrbitMaskControlTex", "Orbit Control Tex")
                },
                {SHADER_PROPERTY._ORBIT_MASK_CONTROL,new ShaderPropertyState(
                    "_OrbitMaskControl", "Orbit Control Strength")
                },
                {SHADER_PROPERTY._NOISE1ST_OFFSET_CONTROL_TEX,new ShaderPropertyState(
                    "_Noise1stOffsetControlTex", "Noise 1st Offset Control Tex")
                },
                {SHADER_PROPERTY._NOISE1ST_OFFSET_CONTROL,new ShaderPropertyState(
                    "_Noise1stOffsetControl", "Noise 1st Offset Control Strength")
                },
                {SHADER_PROPERTY._NOISE2ND_OFFSET_CONTROL_TEX,new ShaderPropertyState(
                    "_Noise2ndOffsetControlTex", "Noise 2nd Offset Control Tex")
                },
                {SHADER_PROPERTY._NOISE2ND_OFFSET_CONTROL,new ShaderPropertyState(
                    "_Noise2ndOffsetControl", "Noise 2nd Offset Control")
                },
                {SHADER_PROPERTY._NOISE3RD_OFFSET_CONTROL_TEX,new ShaderPropertyState(
                    "_Noise3rdOffsetControlTex", "Noise 3rd Offset Control Tex")
                },
                {SHADER_PROPERTY._NOISE3RD_OFFSET_CONTROL,new ShaderPropertyState(
                    "_Noise3rdOffsetControl", "Noise 3rd Offset Control")
                },


                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_NOISE_SPECTRUM,new ShaderPropertyState(
                    "_FragmentAudioLinkNoiseSpectrum", "Fragment AudioLink Noise Spectrum")
                },
                {SHADER_PROPERTY._COLORING_AUDIOLINK_NOISE_SPECTRUM,new ShaderPropertyState(
                    "_ColoringAudioLinkNoiseSpectrum", "Coloring AudioLink Noise Spectrum")
                },
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_NOISE_SPECTRUM,new ShaderPropertyState(
                    "_GeometryAudioLinkNoiseSpectrum", "Geometry AudioLink Noise Spectrum")
                },

                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_STRENGTH,new ShaderPropertyState(
                    "_FragmentAudioLinkStrength", "Noise Spectrum Strength")
                },
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState(
                    "_FragmentAudioLinkSpectrumMirror", "Noise Spectrum Mirror")
                },
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_TYPE,new ShaderPropertyState(
                    "_FragmentAudioLinkSpectrumType", "Noise Spectrum Type")
                },
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_RANGE,new ShaderPropertyState(
                    "_FragmentAudioLinkSpectrumRange", "Noise Spectrum Range")
                },

                {SHADER_PROPERTY._COLORING_AUDIOLINK_STRENGTH,new ShaderPropertyState(
                    "_ColoringAudioLinkStrength", "Noise Spectrum Strength")
                },
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState(
                    "_ColoringAudioLinkSpectrumMirror", "Noise Spectrum Mirror")
                },
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_TYPE,new ShaderPropertyState(
                    "_ColoringAudioLinkSpectrumType", "Noise Spectrum Type")
                },
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_RANGE,new ShaderPropertyState(
                    "_ColoringAudioLinkSpectrumRange", "Noise Spectrum Range")
                },

                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_STRENGTH,new ShaderPropertyState(
                    "_GeometryAudioLinkStrength", "Noise Spectrum Strength")
                },
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState(
                    "_GeometryAudioLinkSpectrumMirror", "Noise Spectrum Mirror")
                },
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_TYPE,new ShaderPropertyState(
                    "_GeometryAudioLinkSpectrumType", "Noise Spectrume Type")
                },
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_RANGE,new ShaderPropertyState(
                    "_GeometryAudioLinkSpectrumRange", "Noise Spectrum Range")
                },


                {SHADER_PROPERTY._NOISE1ST_SPACE,new ShaderPropertyState(
                    "_Noise1stSpace", "Space")
                },
                {SHADER_PROPERTY._NOISE2ND_SPACE,new ShaderPropertyState(
                    "_Noise2ndSpace", "Space")
                },
                {SHADER_PROPERTY._NOISE3RD_SPACE,new ShaderPropertyState(
                    "_Noise3rdSpace", "Space")
                },

                {SHADER_PROPERTY._NOISE1ST_OFFSET0,new ShaderPropertyState(
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
                {SHADER_PROPERTY._NOISE3RD_PHASE_REF_AUDIOLINK,new ShaderPropertyState(
                    "_Noise3rdPhaseRefAudioLink", "Phase Reference AudioLink")
                }
            };
        }
        internal static Dictionary<CUSTOM_GUI, GUIStyle> gui = new Dictionary<CUSTOM_GUI, GUIStyle> {
            {CUSTOM_GUI.PLAIN,new GUIStyle(){

            }},
            {CUSTOM_GUI.TITLE0,new GUIStyle(){
                richText = true, alignment = TextAnchor.UpperCenter, fontSize = 32
            }},
            {CUSTOM_GUI.TITLE1,new GUIStyle(){
                richText = true, alignment = TextAnchor.UpperCenter, fontSize = 24
            }},
            {CUSTOM_GUI.HEADER0,new GUIStyle(){
                richText = true, alignment = TextAnchor.UpperLeft, fontSize = 16, fontStyle=FontStyle.Bold
            }},
            {CUSTOM_GUI.HEADER1,new GUIStyle(){
                richText = true, alignment = TextAnchor.UpperLeft, fontSize = 12, fontStyle=FontStyle.Bold
            }}
        };
    }
    internal class ShaderPropertyState
    {
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