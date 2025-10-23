#if UNITY_EDITOR
using System;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public enum MESHHOLOGRAM_PROP_ENUM
    {
        [MeshHologramPropMeta("_dummy")] _DUMMY = 0,
        [MeshHologramPropMeta("_RenderingMode")] _RENDERING_MODE,
        [MeshHologramPropMeta("_Cull")] _CULL,
        [MeshHologramPropMeta("_ZWrite")] _Z_WRITE,
        [MeshHologramPropMeta("_CustomRenderQueueT")] _CUSTOM_RENDER_QUEUE_T,
        [MeshHologramPropMeta("_CustomRenderQueueC")] _CUSTOM_RENDER_QUEUE_C,
        [MeshHologramPropMeta("_Forced_Z_Scale_Zero")] _FORCED_Z_SCALE_ZERO,
        [MeshHologramPropMeta("_BillboardEnable")] _BILLBOARD_ENABLE,
        [MeshHologramPropMeta("_DistanceInfluence")] _DISTANCE_INFLUENCE,
        [MeshHologramPropMeta("_StereoMergeMode")] _STEREO_MERGE_MODE,
        [MeshHologramPropMeta("_FwidthEnable")] _FWIDTH_ENABLE,

        [MeshHologramPropMeta("_DirectionalLightInfluenceEnable")] _DIRECTIONAL_LIGHT_INFLUENCE_ENABLE,
        [MeshHologramPropMeta("_DirectionalLightInfluence")] _DIRECTIONAL_LIGHT_INFLUENCE,
        [MeshHologramPropMeta("_AmbientInfluenceEnable")] _AMBIENT_INFLUENCE_ENABLE,
        [MeshHologramPropMeta("_AmbientInfluence")] _AMBIENT_INFLUENCE,
        [MeshHologramPropMeta("_LightVolumesInfluenceEnable")] _LIGHTVOLUMES_INFLUENCE_ENABLE,
        [MeshHologramPropMeta("_LightVolumesInfluence")] _LIGHTVOLUMES_INFLUENCE,
        [MeshHologramPropMeta("_PreviewEnable")] _PREVIEW_ENABLE,
        [MeshHologramPropMeta("_AntiAliasingEnable")] _ANTI_ALIASING_ENABLE,

        [MeshHologramPropMeta("_MainTex")] _MAIN_TEX,

        [MeshHologramPropMeta("_ZClip")] _Z_CLIP,
        [MeshHologramPropMeta("_ZTest")] _Z_TEST,
        [MeshHologramPropMeta("_ColorMask")] _COLOR_MASK,
        [MeshHologramPropMeta("_OffsetFactor")] _OFFSET_FACTOR,
        [MeshHologramPropMeta("_OffsetUnits")] _OFFSET_UNITS,
        [MeshHologramPropMeta("_AlphaToMaskMemory")] _ALPHA_TO_MASK,

        [MeshHologramPropMeta("_BlendOp")] _BLEND_OP,
        [MeshHologramPropMeta("_SrcBlend")] _SRC_BLEND,
        [MeshHologramPropMeta("_DstBlend")] _DST_BLEND,
        [MeshHologramPropMeta("_BlendOpAlpha")] _BLEND_OP_ALPHA,
        [MeshHologramPropMeta("_SrcBlendAlpha")] _SRC_BLEND_ALPHA,
        [MeshHologramPropMeta("_DstBlendAlpha")] _DST_BLEND_ALPHA,

        [MeshHologramPropMeta("_StencilRef")] _STENCIL_REF,
        [MeshHologramPropMeta("_StencilReadMask")] _STENCIL_READ_MASK,
        [MeshHologramPropMeta("_StencilWriteMask")] _STENCIL_WRITE_MASK,
        [MeshHologramPropMeta("_StencilComp")] _STENCIL_COMP,
        [MeshHologramPropMeta("_StencilPass")] _STENCIL_PASS,
        [MeshHologramPropMeta("_StencilFail")] _STENCIL_FAIL,
        [MeshHologramPropMeta("_StencilZFail")] _STENCIL_Z_FAIL,

        [MeshHologramPropMeta("_AudioLinkEnable")] _AUDIOLINK_ENABLE,
        [MeshHologramPropMeta("_AudioLinkThemeColorBand")] _AUDIOLINK_THEME_COLOR_BAND,


        [MeshHologramPropMeta("_FragmentTriangleCompression")] _FRAGMENT_TRIANGLE_COMPRESSION,
        [MeshHologramPropMeta("_FragmentFill")] _FRAGMENT_FILL,
        [MeshHologramPropMeta("_FragmentLineWidth")] _FRAGMENT_LINE_WIDTH,
        [MeshHologramPropMeta("_FragmentLineGradientBias")] _FRAGMENT_LINE_GRADIENT_BIAS,
        [MeshHologramPropMeta("_FragmentManualLineScalingEnable")] _FRAGMENT_MANUAL_LINE_SCALING,
        [MeshHologramPropMeta("_FragmentLineScale")] _FRAGMENT_LINE_SCALE,
        [MeshHologramPropMeta("_FragmentLineAnimationMode")] _FRAGMENT_LINE_ANIMATION_MODE,
        [MeshHologramPropMeta("_FragmentPartitionMode")] _FRAGMENT_PARTITION_MODE,

        [MeshHologramPropMeta("_FragmentSource")] _FRAGMENT_SOURCE,
        [MeshHologramPropMeta("_FragmentFixedValue")] _FRAGMENT_FIXED_VALUE,
        [MeshHologramPropMeta("_FragmentNoiseSpace")] _FRAGMENT_NOISE_SPACE,
        [MeshHologramPropMeta("_FragmentNoiseOffset0")] _FRAGMENT_NOISE_OFFSET0,
        [MeshHologramPropMeta("_FragmentNoiseScale0")] _FRAGMENT_NOISE_SCALE0,
        [MeshHologramPropMeta("_FragmentNoiseOffset1")] _FRAGMENT_NOISE_OFFSET1,
        [MeshHologramPropMeta("_FragmentNoiseScale1")] _FRAGMENT_NOISE_SCALE1,
        [MeshHologramPropMeta("_FragmentNoiseOffsetBeforeScale")] _FRAGMENT_NOISE_OFFSET_BEFORE_SCALE,
        [MeshHologramPropMeta("_FragmentNoiseSeed")] _FRAGMENT_NOISE_SEED,
        [MeshHologramPropMeta("_FragmentNoiseTimeSpeed")] _FRAGMENT_NOISE_TIME_SPEED,
        [MeshHologramPropMeta("_FragmentNoiseTimePhase")] _FRAGMENT_NOISE_TIME_PHASE,
        [MeshHologramPropMeta("_FragmentNoiseValueScale")] _FRAGMENT_NOISE_VALUE_SCALE,

        [MeshHologramPropMeta("_FragmentAudioLinkSource")] _FRAGMENT_AUDIOLINK_SOURCE,
        [MeshHologramPropMeta("_FragmentAudioLinkVUBand")] _FRAGMENT_AUDIOLINK_VU_BAND,
        [MeshHologramPropMeta("_FragmentAudioLinkVUSmoothing")] _FRAGMENT_AUDIOLINK_VU_SMOOTHING,
        [MeshHologramPropMeta("_FragmentAudioLinkVUPanning")] _FRAGMENT_AUDIOLINK_VU_PANNING,
        [MeshHologramPropMeta("_FragmentAudioLinkVUStrength")] _FRAGMENT_AUDIOLINK_VU_STRENGTH,
        [MeshHologramPropMeta("_FragmentAudioLinkChronoTensityMode")] _FRAGMENT_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MeshHologramPropMeta("_FragmentAudioLinkChronoTensityBand")] _FRAGMENT_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MeshHologramPropMeta("_FragmentAudioLinkChronoTensityStrength")] _FRAGMENT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
        [MeshHologramPropMeta("_FragmentAudioLinkSpectrumMirror")] _FRAGMENT_AUDIOLINK_SPECTRUM_MIRROR,
        [MeshHologramPropMeta("_FragmentAudioLinkSpectrumStrength")] _FRAGMENT_AUDIOLINK_SPECTRUM_STRENGTH,

        [MeshHologramPropMeta("_FragmentMaskMap")] _FRAGMENT_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_FragmentMaskMapStrength")] _FRAGMENT_MASK_CONTROL,
        [MeshHologramPropMeta("_FragmentMap")] _FRAGMENT_OFFSET_CONTROL_TEX,
        [MeshHologramPropMeta("_FragmentMapStrength")] _FRAGMENT_OFFSET_CONTROL,
        [MeshHologramPropMeta("_FragmentAudioLinkMaskMap")] _FRAGMENT_AUDIOLINK_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_FragmentAudioLinkMaskMapStrength")] _FRAGMENT_AUDIOLINK_MASK_CONTROL,

        [MeshHologramPropMeta("_FragmentPhaseScale")] _FRAGMENT_PHASE_SCALE,
        [MeshHologramPropMeta("_FragmentLoopMode")] _FRAGMENT_LOOP_MODE,
        [MeshHologramPropMeta("_FragmentEaseMode")] _FRAGMENT_EASE_MODE,
        [MeshHologramPropMeta("_FragmentEaseCurve")] _FRAGMENT_EASE_CURVE,
        [MeshHologramPropMeta("_FragmentMidMul")] _FRAGMENT_MID_MUL,
        [MeshHologramPropMeta("_FragmentMidAdd")] _FRAGMENT_MID_ADD,


        [MeshHologramPropMeta("_Color0")] _COLOR0,
        [MeshHologramPropMeta("_Color1")] _COLOR1,
        [MeshHologramPropMeta("_Emission")] _EMISSION,
        [MeshHologramPropMeta("_ColorSource")] _COLOR_SOURCE,
        [MeshHologramPropMeta("_ColorGradientTex")] _COLOR_GRADIENT_TEX,
        [MeshHologramPropMeta("_ColoringPartitionMode")] _COLORING_PARTITION_MODE,

        [MeshHologramPropMeta("_ColoringSource")] _COLORING_SOURCE,
        [MeshHologramPropMeta("_ColoringFixedValue")] _COLORING_FIXED_VALUE,
        [MeshHologramPropMeta("_ColoringNoiseSpace")] _COLORING_NOISE_SPACE,
        [MeshHologramPropMeta("_ColoringNoiseOffset0")] _COLORING_NOISE_OFFSET0,
        [MeshHologramPropMeta("_ColoringNoiseScale0")] _COLORING_NOISE_SCALE0,
        [MeshHologramPropMeta("_ColoringNoiseOffset1")] _COLORING_NOISE_OFFSET1,
        [MeshHologramPropMeta("_ColoringNoiseScale1")] _COLORING_NOISE_SCALE1,
        [MeshHologramPropMeta("_ColoringNoiseOffsetBeforeScale")] _COLORING_NOISE_OFFSET_BEFORE_SCALE,
        [MeshHologramPropMeta("_ColoringNoiseSeed")] _COLORING_NOISE_SEED,
        [MeshHologramPropMeta("_ColoringNoiseTimeSpeed")] _COLORING_NOISE_TIME_SPEED,
        [MeshHologramPropMeta("_ColoringNoiseTimePhase")] _COLORING_NOISE_TIME_PHASE,
        [MeshHologramPropMeta("_ColoringNoiseValueScale")] _COLORING_NOISE_VALUE_SCALE,

        [MeshHologramPropMeta("_ColoringAudioLinkSource")] _COLORING_AUDIOLINK_SOURCE,
        [MeshHologramPropMeta("_ColoringAudioLinkVUBand")] _COLORING_AUDIOLINK_VU_BAND,
        [MeshHologramPropMeta("_ColoringAudioLinkVUSmoothing")] _COLORING_AUDIOLINK_VU_SMOOTHING,
        [MeshHologramPropMeta("_ColoringAudioLinkVUPanning")] _COLORING_AUDIOLINK_VU_PANNING,
        [MeshHologramPropMeta("_ColoringAudioLinkVUStrength")] _COLORING_AUDIOLINK_VU_STRENGTH,
        [MeshHologramPropMeta("_ColoringAudioLinkChronoTensityMode")] _COLORING_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MeshHologramPropMeta("_ColoringAudioLinkChronoTensityBand")] _COLORING_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MeshHologramPropMeta("_ColoringAudioLinkChronoTensityStrength")] _COLORING_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
        [MeshHologramPropMeta("_ColoringAudioLinkSpectrumMirror")] _COLORING_AUDIOLINK_SPECTRUM_MIRROR,
        [MeshHologramPropMeta("_ColoringAudioLinkSpectrumStrength")] _COLORING_AUDIOLINK_SPECTRUM_STRENGTH,

        [MeshHologramPropMeta("_ColoringMaskMap")] _COLORING_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_ColoringMaskMapStrength")] _COLORING_MASK_CONTROL,
        [MeshHologramPropMeta("_ColoringMap")] _COLORING_OFFSET_CONTROL_TEX,
        [MeshHologramPropMeta("_ColoringMapStrength")] _COLORING_OFFSET_CONTROL,
        [MeshHologramPropMeta("_ColoringAudioLinkMaskMap")] _COLORING_AUDIOLINK_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_ColoringAudioLinkMaskMapStrength")] _COLORING_AUDIOLINK_MASK_CONTROL,

        [MeshHologramPropMeta("_ColoringPhaseScale")] _COLORING_PHASE_SCALE,
        [MeshHologramPropMeta("_ColoringLoopMode")] _COLORING_LOOP_MODE,
        [MeshHologramPropMeta("_ColoringEaseMode")] _COLORING_EASE_MODE,
        [MeshHologramPropMeta("_ColoringEaseCurve")] _COLORING_EASE_CURVE,
        [MeshHologramPropMeta("_ColoringMidMul")] _COLORING_MID_MUL,
        [MeshHologramPropMeta("_ColoringMidAdd")] _COLORING_MID_ADD,


        [MeshHologramPropMeta("_GeometryScaleEnable")] _GEOMETRY_SCALE_ENABLE,
        [MeshHologramPropMeta("_GeometryScaleBounds")] _GEOMETRY_SCALE_BOUNDS,
        [MeshHologramPropMeta("_GeometryPushPullEnable")] _GEOMETRY_PUSHPULL_ENABLE,
        [MeshHologramPropMeta("_GeometryPushPullBounds")] _GEOMETRY_PUSHPULL_BOUNDS,
        [MeshHologramPropMeta("_GeometryPushPullPartitionBias")] _GEOMETRY_PUSHPULL_PARTITION_BIAS,
        [MeshHologramPropMeta("_GeometryRotationEnable")] _GEOMETRY_ROTATION_ENABLE,
        [MeshHologramPropMeta("_GeometryRotationStrength")] _GEOMETRY_ROTATION_STRENGTH,
        [MeshHologramPropMeta("_GeometryRotationInvert")] _GEOMETRY_ROTATION_INVERT,
        [MeshHologramPropMeta("_GeometryRotationNoiseRepeat")] _GEOMETRY_ROTATION_NOISE_REPEAT,

        [MeshHologramPropMeta("_GeometryPixelizationSpace")] _GEOMETRY_PIXELIZATION_SPACE,
        [MeshHologramPropMeta("_GeometryPixelization")] _GEOMETRY_PIXELIZATION,

        [MeshHologramPropMeta("_GeometrySource")] _GEOMETRY_SOURCE,
        [MeshHologramPropMeta("_GeometryFixedValue")] _GEOMETRY_FIXED_VALUE,
        [MeshHologramPropMeta("_GeometryNoiseSpace")] _GEOMETRY_NOISE_SPACE,
        [MeshHologramPropMeta("_GeometryNoiseOffset0")] _GEOMETRY_NOISE_OFFSET0,
        [MeshHologramPropMeta("_GeometryNoiseScale0")] _GEOMETRY_NOISE_SCALE0,
        [MeshHologramPropMeta("_GeometryNoiseOffset1")] _GEOMETRY_NOISE_OFFSET1,
        [MeshHologramPropMeta("_GeometryNoiseScale1")] _GEOMETRY_NOISE_SCALE1,
        [MeshHologramPropMeta("_GeometryNoiseOffsetBeforeScale")] _GEOMETRY_NOISE_OFFSET_BEFORE_SCALE,
        [MeshHologramPropMeta("_GeometryNoiseSeed")] _GEOMETRY_NOISE_SEED,
        [MeshHologramPropMeta("_GeometryNoiseTimeSpeed")] _GEOMETRY_NOISE_TIME_SPEED,
        [MeshHologramPropMeta("_GeometryNoiseTimePhase")] _GEOMETRY_NOISE_TIME_PHASE,
        [MeshHologramPropMeta("_GeometryNoiseValueScale")] _GEOMETRY_NOISE_VALUE_SCALE,

        [MeshHologramPropMeta("_GeometryAudioLinkSource")] _GEOMETRY_AUDIOLINK_SOURCE,
        [MeshHologramPropMeta("_GeometryAudioLinkVUBand")] _GEOMETRY_AUDIOLINK_VU_BAND,
        [MeshHologramPropMeta("_GeometryAudioLinkVUSmoothing")] _GEOMETRY_AUDIOLINK_VU_SMOOTHING,
        [MeshHologramPropMeta("_GeometryAudioLinkVUPanning")] _GEOMETRY_AUDIOLINK_VU_PANNING,
        [MeshHologramPropMeta("_GeometryAudioLinkVUStrength")] _GEOMETRY_AUDIOLINK_VU_STRENGTH,
        [MeshHologramPropMeta("_GeometryAudioLinkChronoTensityMode")] _GEOMETRY_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MeshHologramPropMeta("_GeometryAudioLinkChronoTensityBand")] _GEOMETRY_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MeshHologramPropMeta("_GeometryAudioLinkChronoTensityStrength")] _GEOMETRY_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
        [MeshHologramPropMeta("_GeometryAudioLinkSpectrumMirror")] _GEOMETRY_AUDIOLINK_SPECTRUM_MIRROR,
        [MeshHologramPropMeta("_GeometryAudioLinkSpectrumStrength")] _GEOMETRY_AUDIOLINK_SPECTRUM_STRENGTH,

        [MeshHologramPropMeta("_GeometryMaskMap")] _GEOMETRY_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_GeometryMaskMapStrength")] _GEOMETRY_MASK_CONTROL,
        [MeshHologramPropMeta("_GeometryMap")] _GEOMETRY_OFFSET_CONTROL_TEX,
        [MeshHologramPropMeta("_GeometryMapStrength")] _GEOMETRY_OFFSET_CONTROL,
        [MeshHologramPropMeta("_GeometryAudioLinkMaskMap")] _GEOMETRY_AUDIOLINK_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_GeometryAudioLinkMaskMapStrength")] _GEOMETRY_AUDIOLINK_MASK_CONTROL,

        [MeshHologramPropMeta("_GeometryPhaseScale")] _GEOMETRY_PHASE_SCALE,
        [MeshHologramPropMeta("_GeometryLoopMode")] _GEOMETRY_LOOP_MODE,
        [MeshHologramPropMeta("_GeometryEaseMode")] _GEOMETRY_EASE_MODE,
        [MeshHologramPropMeta("_GeometryEaseCurve")] _GEOMETRY_EASE_CURVE,
        [MeshHologramPropMeta("_GeometryMidMul")] _GEOMETRY_MID_MUL,
        [MeshHologramPropMeta("_GeometryMidAdd")] _GEOMETRY_MID_ADD,


        [MeshHologramPropMeta("_OrbitEnable")] _ORBIT_ENABLE,

        [MeshHologramPropMeta("_OrbitSeed")] _ORBIT_SEED,
        [MeshHologramPropMeta("_OrbitPrimitiveRatio")] _ORBIT_PRIMITIVE_RATIO,
        [MeshHologramPropMeta("_OrbitOffset")] _ORBIT_OFFSET,
        [MeshHologramPropMeta("_OrbitScale")] _ORBIT_SCALE,

        [MeshHologramPropMeta("_OrbitSource")] _ORBIT_SOURCE,
        [MeshHologramPropMeta("_OrbitFixedValue")] _ORBIT_FIXED_VALUE,
        [MeshHologramPropMeta("_OrbitNoiseSpace")] _ORBIT_NOISE_SPACE,
        [MeshHologramPropMeta("_OrbitNoiseOffset0")] _ORBIT_NOISE_OFFSET0,
        [MeshHologramPropMeta("_OrbitNoiseScale0")] _ORBIT_NOISE_SCALE0,
        [MeshHologramPropMeta("_OrbitNoiseOffset1")] _ORBIT_NOISE_OFFSET1,
        [MeshHologramPropMeta("_OrbitNoiseScale1")] _ORBIT_NOISE_SCALE1,
        [MeshHologramPropMeta("_OrbitNoiseOffsetBeforeScale")] _ORBIT_NOISE_OFFSET_BEFORE_SCALE,
        [MeshHologramPropMeta("_OrbitNoiseSeed")] _ORBIT_NOISE_SEED,
        [MeshHologramPropMeta("_OrbitNoiseTimeSpeed")] _ORBIT_NOISE_TIME_SPEED,
        [MeshHologramPropMeta("_OrbitNoiseTimePhase")] _ORBIT_NOISE_TIME_PHASE,
        [MeshHologramPropMeta("_OrbitNoiseValueScale")] _ORBIT_NOISE_VALUE_SCALE,

        [MeshHologramPropMeta("_OrbitAudioLinkSource")] _ORBIT_AUDIOLINK_SOURCE,
        [MeshHologramPropMeta("_OrbitAudioLinkVUBand")] _ORBIT_AUDIOLINK_VU_BAND,
        [MeshHologramPropMeta("_OrbitAudioLinkVUSmoothing")] _ORBIT_AUDIOLINK_VU_SMOOTHING,
        [MeshHologramPropMeta("_OrbitAudioLinkVUPanning")] _ORBIT_AUDIOLINK_VU_PANNING,
        [MeshHologramPropMeta("_OrbitAudioLinkVUStrength")] _ORBIT_AUDIOLINK_VU_STRENGTH,
        [MeshHologramPropMeta("_OrbitAudioLinkChronoTensityMode")] _ORBIT_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MeshHologramPropMeta("_OrbitAudioLinkChronoTensityBand")] _ORBIT_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MeshHologramPropMeta("_OrbitAudioLinkChronoTensityStrength")] _ORBIT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
        [MeshHologramPropMeta("_OrbitAudioLinkSpectrumMirror")] _ORBIT_AUDIOLINK_SPECTRUM_MIRROR,
        [MeshHologramPropMeta("_OrbitAudioLinkSpectrumStrength")] _ORBIT_AUDIOLINK_SPECTRUM_STRENGTH,

        [MeshHologramPropMeta("_OrbitMaskMap")] _ORBIT_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_OrbitMaskMapStrength")] _ORBIT_MASK_CONTROL,
        [MeshHologramPropMeta("_OrbitMap")] _ORBIT_OFFSET_CONTROL_TEX,
        [MeshHologramPropMeta("_OrbitMapStrength")] _ORBIT_OFFSET_CONTROL,
        [MeshHologramPropMeta("_OrbitAudioLinkMaskMap")] _ORBIT_AUDIOLINK_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_OrbitAudioLinkMaskMapStrength")] _ORBIT_AUDIOLINK_MASK_CONTROL,

        [MeshHologramPropMeta("_OrbitPhaseScale")] _ORBIT_PHASE_SCALE,
        [MeshHologramPropMeta("_OrbitLoopMode")] _ORBIT_LOOP_MODE,
        [MeshHologramPropMeta("_OrbitEaseMode")] _ORBIT_EASE_MODE,
        [MeshHologramPropMeta("_OrbitEaseCurve")] _ORBIT_EASE_CURVE,
        [MeshHologramPropMeta("_OrbitMidMul")] _ORBIT_MID_MUL,
        [MeshHologramPropMeta("_OrbitMidAdd")] _ORBIT_MID_ADD,


        [MeshHologramPropMeta("_OrbitRotationSeed")] _ORBIT_ROTATION_SEED,
        [MeshHologramPropMeta("_OrbitRotationSpread")] _ORBIT_ROTATION_SPREAD,

        [MeshHologramPropMeta("_OrbitRotationSource")] _ORBIT_ROTATION_SOURCE,
        [MeshHologramPropMeta("_OrbitRotationFixedValue")] _ORBIT_ROTATION_FIXED_VALUE,
        [MeshHologramPropMeta("_OrbitRotationNoiseSpace")] _ORBIT_ROTATION_NOISE_SPACE,
        [MeshHologramPropMeta("_OrbitRotationNoiseOffset0")] _ORBIT_ROTATION_NOISE_OFFSET0,
        [MeshHologramPropMeta("_OrbitRotationNoiseScale0")] _ORBIT_ROTATION_NOISE_SCALE0,
        [MeshHologramPropMeta("_OrbitRotationNoiseOffset1")] _ORBIT_ROTATION_NOISE_OFFSET1,
        [MeshHologramPropMeta("_OrbitRotationNoiseScale1")] _ORBIT_ROTATION_NOISE_SCALE1,
        [MeshHologramPropMeta("_OrbitRotationNoiseOffsetBeforeScale")] _ORBIT_ROTATION_NOISE_OFFSET_BEFORE_SCALE,
        [MeshHologramPropMeta("_OrbitRotationNoiseSeed")] _ORBIT_ROTATION_NOISE_SEED,
        [MeshHologramPropMeta("_OrbitRotationNoiseTimeSpeed")] _ORBIT_ROTATION_NOISE_TIME_SPEED,
        [MeshHologramPropMeta("_OrbitRotationNoiseTimePhase")] _ORBIT_ROTATION_NOISE_TIME_PHASE,
        [MeshHologramPropMeta("_OrbitRotationNoiseValueScale")] _ORBIT_ROTATION_NOISE_VALUE_SCALE,

        [MeshHologramPropMeta("_OrbitRotationMaskMap")] _ORBIT_ROTATION_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_OrbitRotationMaskMapStrength")] _ORBIT_ROTATION_MASK_CONTROL,
        [MeshHologramPropMeta("_OrbitRotationMap")] _ORBIT_ROTATION_OFFSET_CONTROL_TEX,
        [MeshHologramPropMeta("_OrbitRotationMapStrength")] _ORBIT_ROTATION_OFFSET_CONTROL,


        [MeshHologramPropMeta("_OrbitWaveStrength")] _ORBIT_WAVE_STRENGTH,
        [MeshHologramPropMeta("_OrbitWaveFrequency")] _ORBIT_WAVE_FREQUENCY,
        [MeshHologramPropMeta("_OrbitWavePhase")] _ORBIT_WAVE_PHASE,
        [MeshHologramPropMeta("_OrbitWaveSpeed")] _ORBIT_WAVE_SPEED,

        [MeshHologramPropMeta("_OrbitWaveAudioLinkSource")] _ORBIT_WAVE_AUDIOLINK_SOURCE,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkVUBand")] _ORBIT_WAVE_AUDIOLINK_VU_BAND,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkVUSmoothing")] _ORBIT_WAVE_AUDIOLINK_VU_SMOOTHING,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkVUPanning")] _ORBIT_WAVE_AUDIOLINK_VU_PANNING,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkVUStrength")] _ORBIT_WAVE_AUDIOLINK_VU_STRENGTH,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkChronoTensityMode")] _ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkChronoTensityBand")] _ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkChronoTensityStrength")] _ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkSpectrumMode")] _ORBIT_WAVE_AUDIOLINK_SPECTRUM_MODE,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkSpectrumMirror")] _ORBIT_WAVE_AUDIOLINK_SPECTRUM_MIRROR,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkSpectrumBounds")] _ORBIT_WAVE_AUDIOLINK_SPECTRUM_BOUNDS,
        [MeshHologramPropMeta("_OrbitWaveAudioLinkSpectrumStrength")] _ORBIT_WAVE_AUDIOLINK_SPECTRUM_STRENGTH,


        [MeshHologramPropMeta("_OrbitRotationAngle")] _ORBIT_ROTATION_ANGLE,
        [MeshHologramPropMeta("_OrbitRotationSpeed")] _ORBIT_ROTATION_SPEED,

        [MeshHologramPropMeta("_OrbitRotationOffsetAudioLinkSource")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE,
        [MeshHologramPropMeta("_OrbitRotationOffsetAudioLinkVUBand")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_BAND,
        [MeshHologramPropMeta("_OrbitRotationOffsetAudioLinkVUSmoothing")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_SMOOTHING,
        [MeshHologramPropMeta("_OrbitRotationOffsetAudioLinkVUPanning")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_PANNING,
        [MeshHologramPropMeta("_OrbitRotationOffsetAudioLinkVUStrength")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_STRENGTH,
        [MeshHologramPropMeta("_OrbitRotationOffsetAudioLinkChronoTensityMode")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MeshHologramPropMeta("_OrbitRotationOffsetAudioLinkChronoTensityBand")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MeshHologramPropMeta("_OrbitRotationOffsetAudioLinkChronoTensityStrength")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_STRENGTH,

        [MeshHologramPropMeta("_OrbitRotationOffsetMaskMap")] _ORBIT_ROTATION_OFFSET_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_OrbitRotationOffsetMaskMapStrength")] _ORBIT_ROTATION_OFFSET_MASK_CONTROL,
        [MeshHologramPropMeta("_OrbitRotationOffsetAudioLinkMaskMap")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL_TEX,
        [MeshHologramPropMeta("_OrbitRotationOffsetAudioLinkMaskMapStrength")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL,
    }

    public enum PROPERTY_BLOCK
    {
        RENDERING,
        STENCIL,
        AUDIOLINK,
        FRAGMENT,
        COLOR,
        GEOMETRY,
        ORBIT,
        ORBIT_ROTATION,
        ORBIT_WAVE,
        ORBIT_ROTATION_OFFSET,
        SOURCE,
        AUDIOLINK_SOURCE,
        MASK_OFFSET,
        MODIFIER
    } 

    public enum GUI_STYLE
    {
        PLAIN,
        TITLE0,
        TITLE1,
        HEADER0,
        HEADER1,
    }

    public enum TITLE_SKINS
    {
        NORMAL,
        RAINBOW,
        SPREAD,
        DAY_AND_NIGHT,
    }

    public enum LANG
    {
        [Obsolete]
        PROPERTY = 0,
        ENGLISH = 1,
        JAPANESE = 2,
    }

    public enum FOLDOUT
    {
        RENDERING,
        RENDERING_OTHER,
        STENCIL,
        AUDIOLINK,
        FRAGMENT,
        COLOR,
        GEOMETRY,
        ORBIT,
        MASK_OFFSET,
        SOURCE,
        AUDIOLINK_SOURCE,
        MODIFIER,
        OTHERS
    }
}

#endif