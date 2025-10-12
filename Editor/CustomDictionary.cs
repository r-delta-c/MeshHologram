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
                {SHADER_PROPERTY._RENDERING_MODE,new ShaderPropertyState("_RenderingMode")},
                {SHADER_PROPERTY._CULL,new ShaderPropertyState("_Cull")},
                {SHADER_PROPERTY._Z_WRITE,new ShaderPropertyState("_ZWrite")},
                {SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_T,new ShaderPropertyState("_CustomRenderQueueT")},
                {SHADER_PROPERTY._CUSTOM_RENDER_QUEUE_C,new ShaderPropertyState("_CustomRenderQueueC")},
                {SHADER_PROPERTY._FORCED_Z_SCALE_ZERO,new ShaderPropertyState("_Forced_Z_Scale_Zero")},
                {SHADER_PROPERTY._BILLBOARD_ENABLE,new ShaderPropertyState("_BillboardEnable")},
                {SHADER_PROPERTY._DISTANCE_INFLUENCE,new ShaderPropertyState("_DistanceInfluence")},
                {SHADER_PROPERTY._STEREO_MERGE_MODE,new ShaderPropertyState("_StereoMergeMode")},
                {SHADER_PROPERTY._FWIDTH_ENABLE,new ShaderPropertyState("_FwidthEnable")},

                {SHADER_PROPERTY._DIRECTIONAL_LIGHT_INFLUENCE_ENABLE, new ShaderPropertyState("_DirectionalLightInfluenceEnable")},
                {SHADER_PROPERTY._DIRECTIONAL_LIGHT_INFLUENCE,new ShaderPropertyState("_DirectionalLightInfluence")},
                {SHADER_PROPERTY._AMBIENT_INFLUENCE_ENABLE, new ShaderPropertyState("_AmbientInfluenceEnable")},
                {SHADER_PROPERTY._AMBIENT_INFLUENCE,new ShaderPropertyState("_AmbientInfluence")},
                {SHADER_PROPERTY._LIGHTVOLUMES_INFLUENCE_ENABLE, new ShaderPropertyState("_LightVolumesInfluenceEnable")},
                {SHADER_PROPERTY._LIGHTVOLUMES_INFLUENCE,new ShaderPropertyState("_LightVolumesInfluence")},
                {SHADER_PROPERTY._PREVIEW_ENABLE,new ShaderPropertyState("_PreviewEnable")},
                {SHADER_PROPERTY._ANTI_ALIASING_ENABLE,new ShaderPropertyState("_AntiAliasingEnable")},

                {SHADER_PROPERTY._MAIN_TEX,new ShaderPropertyState("_MainTex")},

                {SHADER_PROPERTY._Z_CLIP,new ShaderPropertyState("_ZClip")},
                {SHADER_PROPERTY._Z_TEST,new ShaderPropertyState("_ZTest")},
                {SHADER_PROPERTY._COLOR_MASK,new ShaderPropertyState("_ColorMask")},
                {SHADER_PROPERTY._OFFSET_FACTOR,new ShaderPropertyState("_OffsetFactor")},
                {SHADER_PROPERTY._OFFSET_UNITS,new ShaderPropertyState("_OffsetUnits")},
                {SHADER_PROPERTY._ALPHA_TO_MASK,new ShaderPropertyState("_AlphaToMaskMemory")},

                {SHADER_PROPERTY._BLEND_OP,new ShaderPropertyState("_BlendOp")},
                {SHADER_PROPERTY._SRC_BLEND,new ShaderPropertyState("_SrcBlend")},
                {SHADER_PROPERTY._DST_BLEND,new ShaderPropertyState("_DstBlend")},
                {SHADER_PROPERTY._BLEND_OP_ALPHA,new ShaderPropertyState("_BlendOpAlpha")},
                {SHADER_PROPERTY._SRC_BLEND_ALPHA,new ShaderPropertyState("_SrcBlendAlpha")},
                {SHADER_PROPERTY._DST_BLEND_ALPHA,new ShaderPropertyState("_DstBlendAlpha")},

                {SHADER_PROPERTY._STENCIL_REF,new ShaderPropertyState("_StencilRef")},
                {SHADER_PROPERTY._STENCIL_READ_MASK,new ShaderPropertyState("_StencilReadMask")},
                {SHADER_PROPERTY._STENCIL_WRITE_MASK,new ShaderPropertyState("_StencilWriteMask")},
                {SHADER_PROPERTY._STENCIL_COMP,new ShaderPropertyState("_StencilComp")},
                {SHADER_PROPERTY._STENCIL_PASS,new ShaderPropertyState("_StencilPass")},
                {SHADER_PROPERTY._STENCIL_FAIL,new ShaderPropertyState("_StencilFail")},
                {SHADER_PROPERTY._STENCIL_Z_FAIL,new ShaderPropertyState("_StencilZFail")},


                {SHADER_PROPERTY._AUDIOLINK_ENABLE,new ShaderPropertyState("_AudioLinkEnable")},
                {SHADER_PROPERTY._AUDIOLINK_THEME_COLOR_BAND,new ShaderPropertyState("_AudioLinkThemeColorBand")},

                {SHADER_PROPERTY._FRAGMENT_TRIANGLE_COMPRESSION,new ShaderPropertyState("_FragmentTriangleCompression")},
                {SHADER_PROPERTY._FRAGMENT_FILL,new ShaderPropertyState("_FragmentFill")},
                {SHADER_PROPERTY._FRAGMENT_LINE_WIDTH,new ShaderPropertyState("_FragmentLineWidth")},
                {SHADER_PROPERTY._FRAGMENT_LINE_GRADIENT_BIAS,new ShaderPropertyState("_FragmentLineGradientBias")},
                {SHADER_PROPERTY._FRAGMENT_MANUAL_LINE_SCALING,new ShaderPropertyState("_FragmentManualLineScalingEnable")},
                {SHADER_PROPERTY._FRAGMENT_LINE_SCALE,new ShaderPropertyState("_FragmentLineScale")},
                {SHADER_PROPERTY._FRAGMENT_LINE_ANIMATION_MODE,new ShaderPropertyState("_FragmentLineAnimationMode")},
                {SHADER_PROPERTY._FRAGMENT_PARTITION_MODE,new ShaderPropertyState("_FragmentPartitionMode")},


                {SHADER_PROPERTY._COLOR0,new ShaderPropertyState("_Color0")},
                {SHADER_PROPERTY._COLOR1,new ShaderPropertyState("_Color1")},
                {SHADER_PROPERTY._EMISSION,new ShaderPropertyState("_Emission")},
                {SHADER_PROPERTY._COLOR_SOURCE,new ShaderPropertyState("_ColorSource")},
                {SHADER_PROPERTY._COLOR_GRADIENT_TEX,new ShaderPropertyState("_ColorGradientTex")},
                {SHADER_PROPERTY._COLORING_PARTITION_MODE,new ShaderPropertyState("_ColoringPartitionMode")},


                {SHADER_PROPERTY._GEOMETRY_SCALE_ENABLE,new ShaderPropertyState("_GeometryScaleEnable")},
                {SHADER_PROPERTY._GEOMETRY_SCALE_BOUNDS,new ShaderPropertyState("_GeometryScaleBounds")},
                {SHADER_PROPERTY._GEOMETRY_PUSHPULL_ENABLE,new ShaderPropertyState("_GeometryPushPullEnable")},
                {SHADER_PROPERTY._GEOMETRY_PUSHPULL_BOUNDS,new ShaderPropertyState("_GeometryPushPullBounds")},
                {SHADER_PROPERTY._GEOMETRY_PUSHPULL_PARTITION_BIAS,new ShaderPropertyState("_GeometryPushPullPartitionBias")},
                {SHADER_PROPERTY._GEOMETRY_ROTATION_ENABLE,new ShaderPropertyState("_GeometryRotationEnable")},
                {SHADER_PROPERTY._GEOMETRY_ROTATION_STRENGTH,new ShaderPropertyState("_GeometryRotationStrength")},
                {SHADER_PROPERTY._GEOMETRY_ROTATION_INVERT,new ShaderPropertyState("_GeometryRotationInvert")},
                {SHADER_PROPERTY._GEOMETRY_ROTATION_NOISE_REPEAT,new ShaderPropertyState("_GeometryRotationNoiseRepeat")},

                {SHADER_PROPERTY._GEOMETRY_PIXELIZATION_SPACE,new ShaderPropertyState("_GeometryPixelizationSpace")},
                {SHADER_PROPERTY._GEOMETRY_PIXELIZATION,new ShaderPropertyState("_GeometryPixelization")},


                {SHADER_PROPERTY._ORBIT_ENABLE,new ShaderPropertyState("_OrbitEnable")},

                {SHADER_PROPERTY._ORBIT_SEED,new ShaderPropertyState("_OrbitSeed")},
                {SHADER_PROPERTY._ORBIT_PRIMITIVE_RATIO,new ShaderPropertyState("_OrbitPrimitiveRatio")},
                {SHADER_PROPERTY._ORBIT_OFFSET,new ShaderPropertyState("_OrbitOffset")},
                {SHADER_PROPERTY._ORBIT_SCALE,new ShaderPropertyState("_OrbitScale")},

                {SHADER_PROPERTY._ORBIT_ROTATION_SEED,new ShaderPropertyState("_OrbitRotationSeed")},
                {SHADER_PROPERTY._ORBIT_ROTATION_ANGLE,new ShaderPropertyState("_OrbitRotationAngle")},
                {SHADER_PROPERTY._ORBIT_ROTATION_SPEED,new ShaderPropertyState("_OrbitRotationSpeed")},
                {SHADER_PROPERTY._ORBIT_ROTATION_SPREAD,new ShaderPropertyState("_OrbitRotationSpread")},


                {SHADER_PROPERTY._ORBIT_WAVE_STRENGTH,new ShaderPropertyState("_OrbitWaveStrength")},
                {SHADER_PROPERTY._ORBIT_WAVE_FREQUENCY,new ShaderPropertyState("_OrbitWaveFrequency")},
                {SHADER_PROPERTY._ORBIT_WAVE_PHASE,new ShaderPropertyState("_OrbitWavePhase")},
                {SHADER_PROPERTY._ORBIT_WAVE_SPEED,new ShaderPropertyState("_OrbitWaveSpeed")},

                {SHADER_PROPERTY._FRAGMENT_SOURCE,new ShaderPropertyState("_FragmentSource")},
                {SHADER_PROPERTY._FRAGMENT_FIXED_VALUE,new ShaderPropertyState("_FragmentFixedValue")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SOURCE,new ShaderPropertyState("_FragmentAudioLinkSource")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_VU_BAND,new ShaderPropertyState("_FragmentAudioLinkVUBand")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_VU_SMOOTHING,new ShaderPropertyState("_FragmentAudioLinkVUSmoothing")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_VU_PANNING,new ShaderPropertyState("_FragmentAudioLinkVUPanning")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_FragmentAudioLinkVUStrength")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_MODE,new ShaderPropertyState("_FragmentAudioLinkChronoTensityMode")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_BAND,new ShaderPropertyState("_FragmentAudioLinkChronoTensityBand")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_FragmentAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_FragmentAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_FragmentAudioLinkSpectrumStrength")},

                {SHADER_PROPERTY._FRAGMENT_PHASE_SCALE,new ShaderPropertyState("_FragmentPhaseScale")},
                {SHADER_PROPERTY._FRAGMENT_LOOP_MODE,new ShaderPropertyState("_FragmentLoopMode")},
                {SHADER_PROPERTY._FRAGMENT_EASE_MODE,new ShaderPropertyState("_FragmentEaseMode")},
                {SHADER_PROPERTY._FRAGMENT_EASE_CURVE,new ShaderPropertyState("_FragmentEaseCurve")},
                {SHADER_PROPERTY._FRAGMENT_MID_MUL,new ShaderPropertyState("_FragmentMidMul")},
                {SHADER_PROPERTY._FRAGMENT_MID_ADD,new ShaderPropertyState("_FragmentMidAdd")},


                {SHADER_PROPERTY._COLORING_SOURCE,new ShaderPropertyState("_ColoringSource")},
                {SHADER_PROPERTY._COLORING_FIXED_VALUE,new ShaderPropertyState("_ColoringFixedValue")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SOURCE,new ShaderPropertyState("_ColoringAudioLinkSource")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_VU_BAND,new ShaderPropertyState("_ColoringAudioLinkVUBand")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_VU_SMOOTHING,new ShaderPropertyState("_ColoringAudioLinkVUSmoothing")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_VU_PANNING,new ShaderPropertyState("_ColoringAudioLinkVUPanning")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_ColoringAudioLinkVUStrength")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_CHRONO_TENSITY_MODE,new ShaderPropertyState("_ColoringAudioLinkChronoTensityMode")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_CHRONO_TENSITY_BAND,new ShaderPropertyState("_ColoringAudioLinkChronoTensityBand")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_ColoringAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_ColoringAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_ColoringAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._COLORING_PHASE_SCALE,new ShaderPropertyState("_ColoringPhaseScale")},
                {SHADER_PROPERTY._COLORING_LOOP_MODE,new ShaderPropertyState("_ColoringLoopMode")},
                {SHADER_PROPERTY._COLORING_EASE_MODE,new ShaderPropertyState("_ColoringEaseMode")},
                {SHADER_PROPERTY._COLORING_EASE_CURVE,new ShaderPropertyState("_ColoringEaseCurve")},
                {SHADER_PROPERTY._COLORING_MID_MUL,new ShaderPropertyState("_ColoringMidMul")},
                {SHADER_PROPERTY._COLORING_MID_ADD,new ShaderPropertyState("_ColoringMidAdd")},


                {SHADER_PROPERTY._GEOMETRY_SOURCE,new ShaderPropertyState("_GeometrySource")},
                {SHADER_PROPERTY._GEOMETRY_FIXED_VALUE,new ShaderPropertyState("_GeometryFixedValue")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SOURCE,new ShaderPropertyState("_GeometryAudioLinkSource")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_VU_BAND,new ShaderPropertyState("_GeometryAudioLinkVUBand")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_VU_SMOOTHING,new ShaderPropertyState("_GeometryAudioLinkVUSmoothing")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_VU_PANNING,new ShaderPropertyState("_GeometryAudioLinkVUPanning")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_GeometryAudioLinkVUStrength")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_MODE,new ShaderPropertyState("_GeometryAudioLinkChronoTensityMode")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_BAND,new ShaderPropertyState("_GeometryAudioLinkChronoTensityBand")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_GeometryAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_GeometryAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._GEOMETRY_PHASE_SCALE,new ShaderPropertyState("_GeometryPhaseScale")},
                {SHADER_PROPERTY._GEOMETRY_LOOP_MODE,new ShaderPropertyState("_GeometryLoopMode")},
                {SHADER_PROPERTY._GEOMETRY_EASE_MODE,new ShaderPropertyState("_GeometryEaseMode")},
                {SHADER_PROPERTY._GEOMETRY_EASE_CURVE,new ShaderPropertyState("_GeometryEaseCurve")},
                {SHADER_PROPERTY._GEOMETRY_MID_MUL,new ShaderPropertyState("_GeometryMidMul")},
                {SHADER_PROPERTY._GEOMETRY_MID_ADD,new ShaderPropertyState("_GeometryMidAdd")},


                {SHADER_PROPERTY._ORBIT_SOURCE,new ShaderPropertyState("_OrbitSource")},
                {SHADER_PROPERTY._ORBIT_FIXED_VALUE,new ShaderPropertyState("_OrbitFixedValue")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_SOURCE,new ShaderPropertyState("_OrbitAudioLinkSource")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_VU_BAND,new ShaderPropertyState("_OrbitAudioLinkVUBand")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_VU_SMOOTHING,new ShaderPropertyState("_OrbitAudioLinkVUSmoothing")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_VU_PANNING,new ShaderPropertyState("_OrbitAudioLinkVUPanning")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_OrbitAudioLinkVUStrength")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_CHRONO_TENSITY_MODE,new ShaderPropertyState("_OrbitAudioLinkChronoTensityMode")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_CHRONO_TENSITY_BAND,new ShaderPropertyState("_OrbitAudioLinkChronoTensityBand")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_OrbitAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_OrbitAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_OrbitAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._ORBIT_PHASE_SCALE,new ShaderPropertyState("_OrbitPhaseScale")},
                {SHADER_PROPERTY._ORBIT_LOOP_MODE,new ShaderPropertyState("_OrbitLoopMode")},
                {SHADER_PROPERTY._ORBIT_EASE_MODE,new ShaderPropertyState("_OrbitEaseMode")},
                {SHADER_PROPERTY._ORBIT_EASE_CURVE,new ShaderPropertyState("_OrbitEaseCurve")},
                {SHADER_PROPERTY._ORBIT_MID_MUL,new ShaderPropertyState("_OrbitMidMul")},
                {SHADER_PROPERTY._ORBIT_MID_ADD,new ShaderPropertyState("_OrbitMidAdd")},


                {SHADER_PROPERTY._ORBIT_ROTATION_SOURCE,new ShaderPropertyState("_OrbitRotationSource")},
                {SHADER_PROPERTY._ORBIT_ROTATION_FIXED_VALUE,new ShaderPropertyState("_OrbitRotationFixedValue")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkSource")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_BAND,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkVUBand")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_SMOOTHING,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkVUSmoothing")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_PANNING,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkVUPanning")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkVUStrength")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_MODE,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkChronoTensityMode")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_BAND,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkChronoTensityBand")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkChronoTensityStrength")},

                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SOURCE,new ShaderPropertyState("_OrbitWaveAudioLinkSource")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_VU_BAND,new ShaderPropertyState("_OrbitWaveAudioLinkVUBand")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_VU_SMOOTHING,new ShaderPropertyState("_OrbitWaveAudioLinkVUSmoothing")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_VU_PANNING,new ShaderPropertyState("_OrbitWaveAudioLinkVUPanning")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_OrbitWaveAudioLinkVUStrength")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_MODE,new ShaderPropertyState("_OrbitWaveAudioLinkChronoTensityMode")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_BAND,new ShaderPropertyState("_OrbitWaveAudioLinkChronoTensityBand")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_OrbitWaveAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_MODE,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumMode")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_BOUNDS,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumBounds")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumStrength")},


                {SHADER_PROPERTY._FRAGMENT_MASK_CONTROL_TEX,new ShaderPropertyState("_FragmentMaskMap")},
                {SHADER_PROPERTY._FRAGMENT_MASK_CONTROL,new ShaderPropertyState("_FragmentMaskMapStrength")},
                {SHADER_PROPERTY._COLORING_MASK_CONTROL_TEX,new ShaderPropertyState("_ColoringMaskMap")},
                {SHADER_PROPERTY._COLORING_MASK_CONTROL,new ShaderPropertyState("_ColoringMaskMapStrength")},
                {SHADER_PROPERTY._GEOMETRY_MASK_CONTROL_TEX,new ShaderPropertyState("_GeometryMaskMap")},
                {SHADER_PROPERTY._GEOMETRY_MASK_CONTROL,new ShaderPropertyState("_GeometryMaskMapStrength")},
                {SHADER_PROPERTY._ORBIT_MASK_CONTROL_TEX,new ShaderPropertyState("_OrbitMaskMap")},
                {SHADER_PROPERTY._ORBIT_MASK_CONTROL,new ShaderPropertyState("_OrbitMaskMapStrength")},
                {SHADER_PROPERTY._ORBIT_ROTATION_MASK_CONTROL_TEX,new ShaderPropertyState("_OrbitRotationMaskMap")},
                {SHADER_PROPERTY._ORBIT_ROTATION_MASK_CONTROL,new ShaderPropertyState("_OrbitRotationMaskMapStrength")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_MASK_CONTROL_TEX,new ShaderPropertyState("_OrbitRotationOffsetMaskMap")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_MASK_CONTROL,new ShaderPropertyState("_OrbitRotationOffsetMaskMapStrength")},

                {SHADER_PROPERTY._FRAGMENT_OFFSET_CONTROL_TEX,new ShaderPropertyState("_FragmentMap")},
                {SHADER_PROPERTY._FRAGMENT_OFFSET_CONTROL,new ShaderPropertyState("_FragmentMapStrength")},
                {SHADER_PROPERTY._COLORING_OFFSET_CONTROL_TEX,new ShaderPropertyState("_ColoringMap")},
                {SHADER_PROPERTY._COLORING_OFFSET_CONTROL,new ShaderPropertyState("_ColoringMapStrength")},
                {SHADER_PROPERTY._GEOMETRY_OFFSET_CONTROL_TEX,new ShaderPropertyState("_GeometryMap")},
                {SHADER_PROPERTY._GEOMETRY_OFFSET_CONTROL,new ShaderPropertyState("_GeometryMapStrength")},
                {SHADER_PROPERTY._ORBIT_OFFSET_CONTROL_TEX,new ShaderPropertyState("_OrbitMap")},
                {SHADER_PROPERTY._ORBIT_OFFSET_CONTROL,new ShaderPropertyState("_OrbitMapStrength")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_CONTROL_TEX,new ShaderPropertyState("_OrbitRotationMap")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_CONTROL,new ShaderPropertyState("_OrbitRotationMapStrength")},

                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState("_FragmentAudioLinkMaskMap")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_MASK_CONTROL,new ShaderPropertyState("_FragmentAudioLinkMaskMapStrength")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState("_ColoringAudioLinkMaskMap")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_MASK_CONTROL,new ShaderPropertyState("_ColoringAudioLinkMaskMapStrength")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState("_GeometryAudioLinkMaskMap")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_MASK_CONTROL,new ShaderPropertyState("_GeometryAudioLinkMaskMapStrength")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState("_OrbitAudioLinkMaskMap")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_MASK_CONTROL,new ShaderPropertyState("_OrbitAudioLinkMaskMapStrength")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkMaskMap")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkMaskMapStrength")},


                {SHADER_PROPERTY._FRAGMENT_NOISE_SPACE,new ShaderPropertyState("_FragmentNoiseSpace")},
                {SHADER_PROPERTY._COLORING_NOISE_SPACE,new ShaderPropertyState("_ColoringNoiseSpace")},
                {SHADER_PROPERTY._GEOMETRY_NOISE_SPACE,new ShaderPropertyState("_GeometryNoiseSpace")},
                {SHADER_PROPERTY._ORBIT_NOISE_SPACE,new ShaderPropertyState("_OrbitNoiseSpace")},
                {SHADER_PROPERTY._ORBIT_ROTATION_NOISE_SPACE,new ShaderPropertyState("_OrbitRotationNoiseSpace")},

                {SHADER_PROPERTY._FRAGMENT_NOISE_OFFSET0,new ShaderPropertyState("_FragmentNoiseOffset0")},
                {SHADER_PROPERTY._FRAGMENT_NOISE_SCALE0,new ShaderPropertyState("_FragmentNoiseScale0")},
                {SHADER_PROPERTY._FRAGMENT_NOISE_OFFSET1,new ShaderPropertyState("_FragmentNoiseOffset1")},
                {SHADER_PROPERTY._FRAGMENT_NOISE_SCALE1,new ShaderPropertyState("_FragmentNoiseScale1")},
                {SHADER_PROPERTY._FRAGMENT_NOISE_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_FragmentNoiseOffsetBeforeScale")},
                {SHADER_PROPERTY._FRAGMENT_NOISE_SEED,new ShaderPropertyState("_FragmentNoiseSeed")},
                {SHADER_PROPERTY._FRAGMENT_NOISE_TIME_SPEED,new ShaderPropertyState("_FragmentNoiseTimeSpeed")},
                {SHADER_PROPERTY._FRAGMENT_NOISE_TIME_PHASE,new ShaderPropertyState("_FragmentNoiseTimePhase")},
                {SHADER_PROPERTY._FRAGMENT_NOISE_VALUE_SCALE,new ShaderPropertyState("_FragmentNoiseValueScale")},

                {SHADER_PROPERTY._COLORING_NOISE_OFFSET0,new ShaderPropertyState("_ColoringNoiseOffset0")},
                {SHADER_PROPERTY._COLORING_NOISE_SCALE0,new ShaderPropertyState("_ColoringNoiseScale0")},
                {SHADER_PROPERTY._COLORING_NOISE_OFFSET1,new ShaderPropertyState("_ColoringNoiseOffset1")},
                {SHADER_PROPERTY._COLORING_NOISE_SCALE1,new ShaderPropertyState("_ColoringNoiseScale1")},
                {SHADER_PROPERTY._COLORING_NOISE_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_ColoringNoiseOffsetBeforeScale")},
                {SHADER_PROPERTY._COLORING_NOISE_SEED,new ShaderPropertyState("_ColoringNoiseSeed")},
                {SHADER_PROPERTY._COLORING_NOISE_TIME_SPEED,new ShaderPropertyState("_ColoringNoiseTimeSpeed")},
                {SHADER_PROPERTY._COLORING_NOISE_TIME_PHASE,new ShaderPropertyState("_ColoringNoiseTimePhase")},
                {SHADER_PROPERTY._COLORING_NOISE_VALUE_SCALE,new ShaderPropertyState("_ColoringNoiseValueScale")},

                {SHADER_PROPERTY._GEOMETRY_NOISE_OFFSET0,new ShaderPropertyState("_GeometryNoiseOffset0")},
                {SHADER_PROPERTY._GEOMETRY_NOISE_SCALE0,new ShaderPropertyState("_GeometryNoiseScale0")},
                {SHADER_PROPERTY._GEOMETRY_NOISE_OFFSET1,new ShaderPropertyState("_GeometryNoiseOffset1")},
                {SHADER_PROPERTY._GEOMETRY_NOISE_SCALE1,new ShaderPropertyState("_GeometryNoiseScale1")},
                {SHADER_PROPERTY._GEOMETRY_NOISE_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_GeometryNoiseOffsetBeforeScale")},
                {SHADER_PROPERTY._GEOMETRY_NOISE_SEED,new ShaderPropertyState("_GeometryNoiseSeed")},
                {SHADER_PROPERTY._GEOMETRY_NOISE_TIME_SPEED,new ShaderPropertyState("_GeometryNoiseTimeSpeed")},
                {SHADER_PROPERTY._GEOMETRY_NOISE_TIME_PHASE,new ShaderPropertyState("_GeometryNoiseTimePhase")},
                {SHADER_PROPERTY._GEOMETRY_NOISE_VALUE_SCALE,new ShaderPropertyState("_GeometryNoiseValueScale")},

                {SHADER_PROPERTY._ORBIT_NOISE_OFFSET0,new ShaderPropertyState("_OrbitNoiseOffset0")},
                {SHADER_PROPERTY._ORBIT_NOISE_SCALE0,new ShaderPropertyState("_OrbitNoiseScale0")},
                {SHADER_PROPERTY._ORBIT_NOISE_OFFSET1,new ShaderPropertyState("_OrbitNoiseOffset1")},
                {SHADER_PROPERTY._ORBIT_NOISE_SCALE1,new ShaderPropertyState("_OrbitNoiseScale1")},
                {SHADER_PROPERTY._ORBIT_NOISE_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_OrbitNoiseOffsetBeforeScale")},
                {SHADER_PROPERTY._ORBIT_NOISE_SEED,new ShaderPropertyState("_OrbitNoiseSeed")},
                {SHADER_PROPERTY._ORBIT_NOISE_TIME_SPEED,new ShaderPropertyState("_OrbitNoiseTimeSpeed")},
                {SHADER_PROPERTY._ORBIT_NOISE_TIME_PHASE,new ShaderPropertyState("_OrbitNoiseTimePhase")},
                {SHADER_PROPERTY._ORBIT_NOISE_VALUE_SCALE,new ShaderPropertyState("_OrbitNoiseValueScale")},

                {SHADER_PROPERTY._ORBIT_ROTATION_NOISE_OFFSET0,new ShaderPropertyState("_OrbitRotationNoiseOffset0")},
                {SHADER_PROPERTY._ORBIT_ROTATION_NOISE_SCALE0,new ShaderPropertyState("_OrbitRotationNoiseScale0")},
                {SHADER_PROPERTY._ORBIT_ROTATION_NOISE_OFFSET1,new ShaderPropertyState("_OrbitRotationNoiseOffset1")},
                {SHADER_PROPERTY._ORBIT_ROTATION_NOISE_SCALE1,new ShaderPropertyState("_OrbitRotationNoiseScale1")},
                {SHADER_PROPERTY._ORBIT_ROTATION_NOISE_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_OrbitRotationNoiseOffsetBeforeScale")},
                {SHADER_PROPERTY._ORBIT_ROTATION_NOISE_SEED,new ShaderPropertyState("_OrbitRotationNoiseSeed")},
                {SHADER_PROPERTY._ORBIT_ROTATION_NOISE_TIME_SPEED,new ShaderPropertyState("_OrbitRotationNoiseTimeSpeed")},
                {SHADER_PROPERTY._ORBIT_ROTATION_NOISE_TIME_PHASE,new ShaderPropertyState("_OrbitRotationNoiseTimePhase")},
                {SHADER_PROPERTY._ORBIT_ROTATION_NOISE_VALUE_SCALE,new ShaderPropertyState("_OrbitRotationNoiseValueScale")},

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
        public ShaderPropertyState(string p)
        {
            property = p;
            display = p;
        }
    }
}
#endif