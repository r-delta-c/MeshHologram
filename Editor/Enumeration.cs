#if UNITY_EDITOR
using System;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public enum VAR_TYPE
    {
        _FLOAT    ,
        _HALF     ,
        _INT      ,
        _UINT     ,
        _BOOL     ,
        _TEXTURE2D,
    }
    public enum PROP_TYPE
    {
        _FLOAT,
        _INT,
        _RANGE,
        _VECTOR,
        _COLOR,
        _2D,
    }
    public enum PROP_DRAWER
    {
        _NONE                            ,
        _DF_COLOR_MASK                   ,
        _DF_RENDERING_MODE               ,
        _DF_CULL                         ,
        _DF_COMPARE                      ,
        _DF_STEREO_MERGE_MODE            ,
        _DF_BLEND_OP                     ,
        _DF_BLEND_MODE                   ,
        _DF_STENCIL_OP                   ,
        _DF_AUDIOLINK_BAND               ,
        _DF_AUDIOLINK_BAND_EXPANDED      ,
        _DF_LINE_ANIMATION_MODE          ,
        _DF_PARTITION_MODE               ,
        _DF_COLOR_SOURCE                 ,
        _DF_PIXELIZATION_SPACE           ,
        _DF_NOISE_SPACE                  ,
        _DF_AUDIOLINK_CHRONOTENSITY_MODE ,
        _DF_LOOP_MODE                    ,
        _DF_EASE_MODE                    ,
    }

    public enum MESHHOLOGRAM_PROP_ENUM
    {
        [MetaNumber(0.0f,VAR_TYPE._FLOAT,"_dummy")]_DUMMY = 0,
        [MetaEnum(0,PROP_DRAWER._DF_RENDERING_MODE,"_RenderingMode")] _RENDERING_MODE,
        [MetaEnum(0,PROP_DRAWER._DF_CULL,"_Cull")] _CULL,
        [MetaToggle(false,VAR_TYPE._INT,"_ZWrite")] _Z_WRITE,
        [MetaRange(3000,3000,5000,VAR_TYPE._INT,"_CustomRenderQueueT",true)] _CUSTOM_RENDER_QUEUE_T,
        [MetaRange(2001,2001,2499,VAR_TYPE._INT,"_CustomRenderQueueC",true)] _CUSTOM_RENDER_QUEUE_C,
        [MetaToggle(false,VAR_TYPE._BOOL,"_Forced_Z_Scale_Zero")] _FORCED_Z_SCALE_ZERO,
        [MetaRange(1.0f,0.0f,1.0f,VAR_TYPE._FLOAT,"_BillboardEnable")] _BILLBOARD_ENABLE,
        [MetaRange(1.0f,0.0f,1.0f,VAR_TYPE._FLOAT,"_DistanceInfluence")] _DISTANCE_INFLUENCE,
        [MetaEnum(2,PROP_DRAWER._DF_STEREO_MERGE_MODE,"_StereoMergeMode")] _STEREO_MERGE_MODE,
        [MetaToggle(true,VAR_TYPE._BOOL,"_FwidthEnable",true)] _FWIDTH_ENABLE,

        [MetaRange(1.0f,0.0f,1.0f,VAR_TYPE._INT,"_DirectionalLightInfluence")] _DIRECTIONAL_LIGHT_INFLUENCE,
        [MetaRange(1.0f,0.0f,1.0f,VAR_TYPE._INT,"_AmbientInfluence")] _AMBIENT_INFLUENCE,
        [MetaRange(1.0f,0.0f,1.0f,VAR_TYPE._INT,"_LightVolumesInfluence")] _LIGHTVOLUMES_INFLUENCE,
        [MetaToggle(false,VAR_TYPE._INT,"_PreviewEnable")] _PREVIEW_ENABLE,
        [MetaToggle(true,VAR_TYPE._INT,"_AntiAliasingEnable")] _ANTI_ALIASING_ENABLE,

        [MetaTexture("\"(1.0,1.0,1.0,0.25)\" {}","_MainTex")] _MAIN_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_MainTex_ST")] _MAIN_TEX_ST,

        [MetaToggle(true,VAR_TYPE._INT,"_ZClip")] _Z_CLIP,
        [MetaEnum(4,PROP_DRAWER._DF_COMPARE,"_ZTest")] _Z_TEST,
        [MetaEnum(15,PROP_DRAWER._DF_COLOR_MASK,"_ColorMask")] _COLOR_MASK,
        [MetaRange(0.0f,-1.0f,1.0f,VAR_TYPE._FLOAT,"_OffsetFactor")] _OFFSET_FACTOR,
        [MetaRange(0.0f,-1.0f,1.0f,VAR_TYPE._FLOAT,"_OffsetUnits")] _OFFSET_UNITS,
        [MetaToggle(false,VAR_TYPE._BOOL,"_AlphaToMaskMemory",false,true)] _ALPHA_TO_MASK_MEMORY,
        [MetaToggle(false,VAR_TYPE._BOOL,"_AlphaToMask",false,true)] _ALPHA_TO_MASK,

        [MetaEnum(0,PROP_DRAWER._DF_BLEND_OP,"_BlendOp")] _BLEND_OP,
        [MetaEnum(5,PROP_DRAWER._DF_BLEND_MODE,"_SrcBlend")] _SRC_BLEND,
        [MetaEnum(10,PROP_DRAWER._DF_BLEND_MODE,"_DstBlend")] _DST_BLEND,
        [MetaEnum(0,PROP_DRAWER._DF_BLEND_OP,"_BlendOpAlpha")] _BLEND_OP_ALPHA,
        [MetaEnum(5,PROP_DRAWER._DF_BLEND_MODE,"_SrcBlendAlpha")] _SRC_BLEND_ALPHA,
        [MetaEnum(10,PROP_DRAWER._DF_BLEND_MODE,"_DstBlendAlpha")] _DST_BLEND_ALPHA,

        [MetaRange(0,0,255,VAR_TYPE._INT,"_StencilRef")] _STENCIL_REF,
        [MetaRange(255,0,255,VAR_TYPE._INT,"_StencilReadMask")] _STENCIL_READ_MASK,
        [MetaRange(255,0,255,VAR_TYPE._INT,"_StencilWriteMask")] _STENCIL_WRITE_MASK,
        [MetaEnum(0,PROP_DRAWER._DF_COMPARE,"_StencilComp")] _STENCIL_COMP,
        [MetaEnum(0,PROP_DRAWER._DF_STENCIL_OP,"_StencilPass")] _STENCIL_PASS,
        [MetaEnum(0,PROP_DRAWER._DF_STENCIL_OP,"_StencilFail")] _STENCIL_FAIL,
        [MetaEnum(0,PROP_DRAWER._DF_STENCIL_OP,"_StencilZFail")] _STENCIL_Z_FAIL,

        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND,"_AudioLinkThemeColorBand")] _AUDIOLINK_THEME_COLOR_BAND,

        [MetaNumber(5.0f,VAR_TYPE._FLOAT,"_FragmentTriangleCompression")] _FRAGMENT_TRIANGLE_COMPRESSION,
        [MetaToggle(false,VAR_TYPE._INT,"_FragmentFill")] _FRAGMENT_FILL,
        [MetaNumber(2.0f,VAR_TYPE._FLOAT,"_FragmentLineWidth")] _FRAGMENT_LINE_WIDTH,
        [MetaNumber(0.0f,VAR_TYPE._FLOAT,"_FragmentLineGradientBias")] _FRAGMENT_LINE_GRADIENT_BIAS,
        [MetaToggle(false,VAR_TYPE._INT,"_FragmentManualLineScalingEnable")] _FRAGMENT_MANUAL_LINE_SCALING,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_FragmentLineScale")] _FRAGMENT_LINE_SCALE,
        [MetaEnum(0,PROP_DRAWER._DF_LINE_ANIMATION_MODE,"_FragmentLineAnimationMode")] _FRAGMENT_LINE_ANIMATION_MODE,
        [MetaEnum(1,PROP_DRAWER._DF_PARTITION_MODE,"_FragmentPartitionMode")] _FRAGMENT_PARTITION_MODE,
        [MetaNumber(8.0f,VAR_TYPE._FLOAT,"_FragmentEdgeBlendWidth")] _FRAGMENT_EDGE_BLEND_WIDTH,

        [MetaSource(1,"_FragmentSource")] _FRAGMENT_SOURCE,
        [MetaRange(0.0f,0.0f,1.0f,VAR_TYPE._FLOAT,"_FragmentFixedValue")] _FRAGMENT_FIXED_VALUE,
        [MetaEnum(1,PROP_DRAWER._DF_NOISE_SPACE,"_FragmentNoiseSpace")] _FRAGMENT_NOISE_SPACE,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_FragmentNoiseOffset0")] _FRAGMENT_NOISE_OFFSET0,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,3.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_FragmentNoiseScale0")] _FRAGMENT_NOISE_SCALE0,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_FragmentNoiseOffset1")] _FRAGMENT_NOISE_OFFSET1,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,1.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_FragmentNoiseScale1")] _FRAGMENT_NOISE_SCALE1,
        [MetaToggle(false,VAR_TYPE._INT,"_FragmentNoiseOffsetBeforeScale")] _FRAGMENT_NOISE_OFFSET_BEFORE_SCALE,
        [MetaNumber(0.0f,VAR_TYPE._FLOAT,"_FragmentNoiseSeed")] _FRAGMENT_NOISE_SEED,
        [MetaNumber(3.0f,VAR_TYPE._FLOAT,"_FragmentNoiseTimeSpeed")] _FRAGMENT_NOISE_TIME_SPEED,
        [MetaNumber(0.0f,VAR_TYPE._FLOAT,"_FragmentNoiseTimePhase")] _FRAGMENT_NOISE_TIME_PHASE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_FragmentNoiseValueScale")] _FRAGMENT_NOISE_VALUE_SCALE,
        [MetaTexture("\"\"{}","_FragmentLiteNoiseMap")] _FRAGMENT_LITE_NOISE_MAP,
        [MetaTextureST(new float[]{0.0f,0.0f,1.0f,1.0f},"_FragmentLiteNoiseMap_ST")] _FRAGMENT_LITE_NOISE_MAP_ST,

        [MetaAudioLinkSource(0,0,"_FragmentAudioLinkSource")] _FRAGMENT_AUDIOLINK_SOURCE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND_EXPANDED,"_FragmentAudioLinkVUBand")] _FRAGMENT_AUDIOLINK_VU_BAND,
        [MetaRange(8,0,15,VAR_TYPE._UINT,"_FragmentAudioLinkVUSmoothing")] _FRAGMENT_AUDIOLINK_VU_SMOOTHING,
        [MetaRange(0.0f,1.0f,0.5f,VAR_TYPE._FLOAT,"_FragmentAudioLinkVUPanning")] _FRAGMENT_AUDIOLINK_VU_PANNING,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_FragmentAudioLinkVUStrength")] _FRAGMENT_AUDIOLINK_VU_STRENGTH,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_CHRONOTENSITY_MODE,"_FragmentAudioLinkChronoTensityMode")] _FRAGMENT_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND,"_FragmentAudioLinkChronoTensityBand")] _FRAGMENT_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_FragmentAudioLinkChronoTensityStrength")] _FRAGMENT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
        [MetaToggle(false,VAR_TYPE._BOOL,"_FragmentAudioLinkSpectrumMirror")] _FRAGMENT_AUDIOLINK_SPECTRUM_MIRROR,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_FragmentAudioLinkSpectrumStrength")] _FRAGMENT_AUDIOLINK_SPECTRUM_STRENGTH,

        [MetaTexture("\"white\"{}","_FragmentMaskMap")] _FRAGMENT_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_FragmentMaskMap_ST")] _FRAGMENT_MASK_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_FragmentMaskMapStrength")] _FRAGMENT_MASK_CONTROL,
        [MetaTexture("\"black\"{}","_FragmentMap")] _FRAGMENT_OFFSET_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_FragmentMap_ST")] _FRAGMENT_OFFSET_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_FragmentMapStrength")] _FRAGMENT_OFFSET_CONTROL,
        [MetaTexture("\"white\"{}","_FragmentAudioLinkMaskMap")] _FRAGMENT_AUDIOLINK_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_FragmentAudioLinkMaskMap_ST")] _FRAGMENT_AUDIOLINK_MASK_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_FragmentAudioLinkMaskMapStrength")] _FRAGMENT_AUDIOLINK_MASK_CONTROL,

        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_FragmentPhaseScale")] _FRAGMENT_PHASE_SCALE,
        [MetaEnum(0,PROP_DRAWER._DF_LOOP_MODE,"_FragmentLoopMode")] _FRAGMENT_LOOP_MODE,
        [MetaEnum(2,PROP_DRAWER._DF_EASE_MODE,"_FragmentEaseMode")] _FRAGMENT_EASE_MODE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_FragmentEaseCurve")] _FRAGMENT_EASE_CURVE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_FragmentMidMul")] _FRAGMENT_MID_MUL,
        [MetaRange(0.0f,-0.5f,0.5f,VAR_TYPE._FLOAT,"_FragmentMidAdd")] _FRAGMENT_MID_ADD,


        [MetaColor(new float[]{1.0f,1.0f,1.0f,1.0f},"_Color0")] _COLOR0,
        [MetaColor(new float[]{0.2f,0.2f,0.2f,1.0f},"_Color1")] _COLOR1,
        [MetaNumber(0.0f,VAR_TYPE._FLOAT,"_Emission")] _EMISSION,
        [MetaEnum(0,PROP_DRAWER._DF_COLOR_SOURCE,"_ColorSource")] _COLOR_SOURCE,
        [MetaTexture("\"white\"{}","_ColorGradientTex")] _COLOR_GRADIENT_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_ColorGradientTex_ST")] _COLOR_GRADIENT_TEX_ST,
        [MetaEnum(1,PROP_DRAWER._DF_PARTITION_MODE,"_ColoringPartitionMode")] _COLORING_PARTITION_MODE,
        [MetaNumber(8.0f,VAR_TYPE._FLOAT,"_ColoringEdgeBlendWidth")] _COLORING_EDGE_BLEND_WIDTH,

        [MetaSource(1,"_ColoringSource")] _COLORING_SOURCE,
        [MetaRange(0.0f,0.0f,1.0f,VAR_TYPE._FLOAT,"_ColoringFixedValue")] _COLORING_FIXED_VALUE,
        [MetaEnum(1,PROP_DRAWER._DF_NOISE_SPACE,"_ColoringNoiseSpace")] _COLORING_NOISE_SPACE,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_ColoringNoiseOffset0")] _COLORING_NOISE_OFFSET0,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,5.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_ColoringNoiseScale0")] _COLORING_NOISE_SCALE0,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_ColoringNoiseOffset1")] _COLORING_NOISE_OFFSET1,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,1.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_ColoringNoiseScale1")] _COLORING_NOISE_SCALE1,
        [MetaToggle(false,VAR_TYPE._BOOL,"_ColoringNoiseOffsetBeforeScale")] _COLORING_NOISE_OFFSET_BEFORE_SCALE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_ColoringNoiseSeed")] _COLORING_NOISE_SEED,
        [MetaNumber(5.0f,VAR_TYPE._FLOAT,"_ColoringNoiseTimeSpeed")] _COLORING_NOISE_TIME_SPEED,
        [MetaNumber(0.0f,VAR_TYPE._FLOAT,"_ColoringNoiseTimePhase")] _COLORING_NOISE_TIME_PHASE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_ColoringNoiseValueScale")] _COLORING_NOISE_VALUE_SCALE,
        [MetaTexture("\"\"{}","_ColoringLiteNoiseMap")] _COLORING_LITE_NOISE_MAP,
        [MetaTextureST(new float[]{0.0f,0.0f,1.0f,1.0f},"_ColoringLiteNoiseMap_ST")] _COLORING_LITE_NOISE_MAP_ST,

        [MetaAudioLinkSource(1,0,"_ColoringAudioLinkSource")] _COLORING_AUDIOLINK_SOURCE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND_EXPANDED,"_ColoringAudioLinkVUBand")] _COLORING_AUDIOLINK_VU_BAND,
        [MetaRange(8,0,15,VAR_TYPE._UINT,"_ColoringAudioLinkVUSmoothing")] _COLORING_AUDIOLINK_VU_SMOOTHING,
        [MetaRange(0.5f,0.0f,1.0f,VAR_TYPE._FLOAT,"_ColoringAudioLinkVUPanning")] _COLORING_AUDIOLINK_VU_PANNING,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_ColoringAudioLinkVUStrength")] _COLORING_AUDIOLINK_VU_STRENGTH,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_CHRONOTENSITY_MODE,"_ColoringAudioLinkChronoTensityMode")] _COLORING_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND,"_ColoringAudioLinkChronoTensityBand")] _COLORING_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_ColoringAudioLinkChronoTensityStrength")] _COLORING_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
        [MetaToggle(false,VAR_TYPE._BOOL,"_ColoringAudioLinkSpectrumMirror")] _COLORING_AUDIOLINK_SPECTRUM_MIRROR,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_ColoringAudioLinkSpectrumStrength")] _COLORING_AUDIOLINK_SPECTRUM_STRENGTH,

        [MetaTexture("\"white\"{}","_ColoringMaskMap")] _COLORING_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_ColoringMaskMap_ST")] _COLORING_MASK_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_ColoringMaskMapStrength")] _COLORING_MASK_CONTROL,
        [MetaTexture("\"black\"{}","_ColoringMap")] _COLORING_OFFSET_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_ColoringMap_ST")] _COLORING_OFFSET_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_ColoringMapStrength")] _COLORING_OFFSET_CONTROL,
        [MetaTexture("\"white\"{}","_ColoringAudioLinkMaskMap")] _COLORING_AUDIOLINK_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_ColoringAudioLinkMaskMap_ST")] _COLORING_AUDIOLINK_MASK_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_ColoringAudioLinkMaskMapStrength")] _COLORING_AUDIOLINK_MASK_CONTROL,

        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_ColoringPhaseScale")] _COLORING_PHASE_SCALE,
        [MetaEnum(2,PROP_DRAWER._DF_LOOP_MODE,"_ColoringLoopMode")] _COLORING_LOOP_MODE,
        [MetaEnum(2,PROP_DRAWER._DF_EASE_MODE,"_ColoringEaseMode")] _COLORING_EASE_MODE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_ColoringEaseCurve")] _COLORING_EASE_CURVE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_ColoringMidMul")] _COLORING_MID_MUL,
        [MetaRange(0.0f,-0.5f,0.5f,VAR_TYPE._FLOAT,"_ColoringMidAdd")] _COLORING_MID_ADD,

        [MetaToggle(false,VAR_TYPE._INT,"_GeometryScaleEnable",true)] _GEOMETRY_SCALE_ENABLE,
        [MetaVector(new float[]{0.5f,0.0f,0.0f,0.0f},new int[]{1,1},VAR_TYPE._FLOAT,"_GeometryScaleBounds")] _GEOMETRY_SCALE_BOUNDS,
        [MetaToggle(true,VAR_TYPE._INT,"_GeometryPushPullEnable",true)] _GEOMETRY_PUSHPULL_ENABLE,
        [MetaVector(new float[]{-0.15f,0.0f,0.0f,0.0f},new int[]{1,1},VAR_TYPE._FLOAT,"_GeometryPushPullBounds")] _GEOMETRY_PUSHPULL_BOUNDS,
        [MetaRange(0.5f,0.0f,1.0f,VAR_TYPE._FLOAT,"_GeometryPushPullPartitionBias")] _GEOMETRY_PUSHPULL_PARTITION_BIAS,
        [MetaToggle(false,VAR_TYPE._INT,"_GeometryRotationEnable",true)] _GEOMETRY_ROTATION_ENABLE,
        [MetaRange(1.0f,0.0f,1.0f,VAR_TYPE._FLOAT,"_GeometryRotationStrength")] _GEOMETRY_ROTATION_STRENGTH,
        [MetaToggle(false,VAR_TYPE._BOOL,"_GeometryRotationInvert")] _GEOMETRY_ROTATION_INVERT,
        [MetaToggle(false,VAR_TYPE._BOOL,"_GeometryRotationNoiseRepeat")] _GEOMETRY_ROTATION_NOISE_REPEAT,

        [MetaEnum(0,PROP_DRAWER._DF_PIXELIZATION_SPACE,"_GeometryPixelizationSpace")] _GEOMETRY_PIXELIZATION_SPACE,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.02f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_GeometryPixelization")] _GEOMETRY_PIXELIZATION,

        [MetaSource(1,"_GeometrySource")] _GEOMETRY_SOURCE,
        [MetaRange(0.0f,0.0f,1.0f,VAR_TYPE._FLOAT,"_GeometryFixedValue")] _GEOMETRY_FIXED_VALUE,
        [MetaEnum(1,PROP_DRAWER._DF_NOISE_SPACE,"_GeometryNoiseSpace")] _GEOMETRY_NOISE_SPACE,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_GeometryNoiseOffset0")] _GEOMETRY_NOISE_OFFSET0,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,5.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_GeometryNoiseScale0")] _GEOMETRY_NOISE_SCALE0,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_GeometryNoiseOffset1")] _GEOMETRY_NOISE_OFFSET1,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,1.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_GeometryNoiseScale1")] _GEOMETRY_NOISE_SCALE1,
        [MetaToggle(false,VAR_TYPE._BOOL,"_GeometryNoiseOffsetBeforeScale")] _GEOMETRY_NOISE_OFFSET_BEFORE_SCALE,
        [MetaNumber(2.0f,VAR_TYPE._FLOAT,"_GeometryNoiseSeed")] _GEOMETRY_NOISE_SEED,
        [MetaNumber(3.0f,VAR_TYPE._FLOAT,"_GeometryNoiseTimeSpeed")] _GEOMETRY_NOISE_TIME_SPEED,
        [MetaNumber(0.0f,VAR_TYPE._FLOAT,"_GeometryNoiseTimePhase")] _GEOMETRY_NOISE_TIME_PHASE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_GeometryNoiseValueScale")] _GEOMETRY_NOISE_VALUE_SCALE,
        [MetaTexture("\"\"{}","_GeometryLiteNoiseMap")] _GEOMETRY_LITE_NOISE_MAP,
        [MetaTextureST(new float[]{0.0f,0.0f,1.0f,1.0f},"_GeometryLiteNoiseMap_ST")] _GEOMETRY_LITE_NOISE_MAP_ST,

        [MetaAudioLinkSource(0,0,"_GeometryAudioLinkSource")] _GEOMETRY_AUDIOLINK_SOURCE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND_EXPANDED,"_GeometryAudioLinkVUBand")] _GEOMETRY_AUDIOLINK_VU_BAND,
        [MetaRange(8,0,15,VAR_TYPE._UINT,"_GeometryAudioLinkVUSmoothing")] _GEOMETRY_AUDIOLINK_VU_SMOOTHING,
        [MetaRange(0.5f,0.0f,1.0f,VAR_TYPE._FLOAT,"_GeometryAudioLinkVUPanning")] _GEOMETRY_AUDIOLINK_VU_PANNING,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_GeometryAudioLinkVUStrength")] _GEOMETRY_AUDIOLINK_VU_STRENGTH,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_CHRONOTENSITY_MODE,"_GeometryAudioLinkChronoTensityMode")] _GEOMETRY_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND,"_GeometryAudioLinkChronoTensityBand")] _GEOMETRY_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_GeometryAudioLinkChronoTensityStrength")] _GEOMETRY_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
        [MetaToggle(false,VAR_TYPE._BOOL,"_GeometryAudioLinkSpectrumMirror")] _GEOMETRY_AUDIOLINK_SPECTRUM_MIRROR,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_GeometryAudioLinkSpectrumStrength")] _GEOMETRY_AUDIOLINK_SPECTRUM_STRENGTH,

        [MetaTexture("\"white\"{}","_GeometryMaskMap")] _GEOMETRY_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_GeometryMaskMap_ST")] _GEOMETRY_MASK_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_GeometryMaskMapStrength")] _GEOMETRY_MASK_CONTROL,
        [MetaTexture("\"black\"{}","_GeometryMap")] _GEOMETRY_OFFSET_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_GeometryMap_ST")] _GEOMETRY_OFFSET_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_GeometryMapStrength")] _GEOMETRY_OFFSET_CONTROL,
        [MetaTexture("\"white\"{}","_GeometryAudioLinkMaskMap")] _GEOMETRY_AUDIOLINK_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_GeometryAudioLinkMaskMap_ST")] _GEOMETRY_AUDIOLINK_MASK_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_GeometryAudioLinkMaskMapStrength")] _GEOMETRY_AUDIOLINK_MASK_CONTROL,

        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_GeometryPhaseScale")] _GEOMETRY_PHASE_SCALE,
        [MetaEnum(2,PROP_DRAWER._DF_LOOP_MODE,"_GeometryLoopMode")] _GEOMETRY_LOOP_MODE,
        [MetaEnum(2,PROP_DRAWER._DF_EASE_MODE,"_GeometryEaseMode")] _GEOMETRY_EASE_MODE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_GeometryEaseCurve")] _GEOMETRY_EASE_CURVE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_GeometryMidMul")] _GEOMETRY_MID_MUL,
        [MetaRange(0.0f,-0.5f,0.5f,VAR_TYPE._FLOAT,"_GeometryMidAdd")] _GEOMETRY_MID_ADD,


        [MetaToggle(false,VAR_TYPE._BOOL,"_OrbitEnable")] _ORBIT_ENABLE,

        [MetaNumber(0.0f,VAR_TYPE._FLOAT,"_OrbitSeed")] _ORBIT_SEED,
        [MetaRange(0.5f,0.0f,1.0f,VAR_TYPE._FLOAT,"_OrbitPrimitiveRatio")] _ORBIT_PRIMITIVE_RATIO,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_OrbitOffset")] _ORBIT_OFFSET,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,1.0f},new int[]{0,1,1,2},VAR_TYPE._FLOAT,"_OrbitScale")] _ORBIT_SCALE,

        [MetaSource(2,"_OrbitSource")] _ORBIT_SOURCE,
        [MetaRange(0.0f,0.0f,1.0f,VAR_TYPE._FLOAT,"_OrbitFixedValue")] _ORBIT_FIXED_VALUE,
        [MetaEnum(1,PROP_DRAWER._DF_NOISE_SPACE,"_OrbitNoiseSpace")] _ORBIT_NOISE_SPACE,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_OrbitNoiseOffset0")] _ORBIT_NOISE_OFFSET0,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,5.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_OrbitNoiseScale0")] _ORBIT_NOISE_SCALE0,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_OrbitNoiseOffset1")] _ORBIT_NOISE_OFFSET1,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,1.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_OrbitNoiseScale1")] _ORBIT_NOISE_SCALE1,
        [MetaToggle(false,VAR_TYPE._BOOL,"_OrbitNoiseOffsetBeforeScale")] _ORBIT_NOISE_OFFSET_BEFORE_SCALE,
        [MetaNumber(3.0f,VAR_TYPE._FLOAT,"_OrbitNoiseSeed")] _ORBIT_NOISE_SEED,
        [MetaNumber(3.0f,VAR_TYPE._FLOAT,"_OrbitNoiseTimeSpeed")] _ORBIT_NOISE_TIME_SPEED,
        [MetaNumber(0.0f,VAR_TYPE._FLOAT,"_OrbitNoiseTimePhase")] _ORBIT_NOISE_TIME_PHASE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_OrbitNoiseValueScale")] _ORBIT_NOISE_VALUE_SCALE,
        [MetaTexture("\"\"{}","_OrbitLiteNoiseMap")] _ORBIT_LITE_NOISE_MAP,
        [MetaTextureST(new float[]{0.0f,0.0f,1.0f,1.0f},"_OrbitLiteNoiseMap_ST")] _ORBIT_LITE_NOISE_MAP_ST,

        [MetaAudioLinkSource(0,0,"_OrbitAudioLinkSource")] _ORBIT_AUDIOLINK_SOURCE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND_EXPANDED,"_OrbitAudioLinkVUBand")] _ORBIT_AUDIOLINK_VU_BAND,
        [MetaRange(8,0,15,VAR_TYPE._UINT,"_OrbitAudioLinkVUSmoothing")] _ORBIT_AUDIOLINK_VU_SMOOTHING,
        [MetaRange(0.5f,0.0f,1.0f,VAR_TYPE._FLOAT,"_OrbitAudioLinkVUPanning")] _ORBIT_AUDIOLINK_VU_PANNING,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_OrbitAudioLinkVUStrength")] _ORBIT_AUDIOLINK_VU_STRENGTH,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_CHRONOTENSITY_MODE,"_OrbitAudioLinkChronoTensityMode")] _ORBIT_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND,"_OrbitAudioLinkChronoTensityBand")] _ORBIT_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_OrbitAudioLinkChronoTensityStrength")] _ORBIT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
        [MetaToggle(false,VAR_TYPE._BOOL,"_OrbitAudioLinkSpectrumMirror")] _ORBIT_AUDIOLINK_SPECTRUM_MIRROR,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_OrbitAudioLinkSpectrumStrength")] _ORBIT_AUDIOLINK_SPECTRUM_STRENGTH,

        [MetaTexture("\"white\"{}","_OrbitMaskMap")] _ORBIT_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_OrbitMaskMap_ST")] _ORBIT_MASK_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_OrbitMaskMapStrength")] _ORBIT_MASK_CONTROL,
        [MetaTexture("\"black\"{}","_OrbitMap")] _ORBIT_OFFSET_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_OrbitMap_ST")] _ORBIT_OFFSET_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_OrbitMapStrength")] _ORBIT_OFFSET_CONTROL,
        [MetaTexture("\"white\"{}","_OrbitAudioLinkMaskMap")] _ORBIT_AUDIOLINK_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_OrbitAudioLinkMaskMap_ST")] _ORBIT_AUDIOLINK_MASK_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_OrbitAudioLinkMaskMapStrength")] _ORBIT_AUDIOLINK_MASK_CONTROL,

        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_OrbitPhaseScale")] _ORBIT_PHASE_SCALE,
        [MetaEnum(0,PROP_DRAWER._DF_LOOP_MODE,"_OrbitLoopMode")] _ORBIT_LOOP_MODE,
        [MetaEnum(2,PROP_DRAWER._DF_EASE_MODE,"_OrbitEaseMode")] _ORBIT_EASE_MODE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_OrbitEaseCurve")] _ORBIT_EASE_CURVE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_OrbitMidMul")] _ORBIT_MID_MUL,
        [MetaRange(0.0f,-0.5f,0.5f,VAR_TYPE._FLOAT,"_OrbitMidAdd")] _ORBIT_MID_ADD,


        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_OrbitRotationSeed")] _ORBIT_ROTATION_SEED,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,2,2},VAR_TYPE._FLOAT,"_OrbitRotationAngle")] _ORBIT_ROTATION_ANGLE,
        [MetaVector(new float[]{4.0f,0.0f,0.0f,1.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_OrbitRotationSpeed")] _ORBIT_ROTATION_SPEED,
        [MetaVector(new float[]{1.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_OrbitRotationSpread")] _ORBIT_ROTATION_SPREAD,

        [MetaSource(2,"_OrbitRotationSource",true)] _ORBIT_ROTATION_SOURCE,
        [MetaRange(0.0f,0.0f,1.0f,VAR_TYPE._FLOAT,"_OrbitRotationFixedValue")] _ORBIT_ROTATION_FIXED_VALUE,
        [MetaEnum(1,PROP_DRAWER._DF_NOISE_SPACE,"_OrbitRotationNoiseSpace")] _ORBIT_ROTATION_NOISE_SPACE,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_OrbitRotationNoiseOffset0")] _ORBIT_ROTATION_NOISE_OFFSET0,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,5.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_OrbitRotationNoiseScale0")] _ORBIT_ROTATION_NOISE_SCALE0,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1,1},VAR_TYPE._FLOAT,"_OrbitRotationNoiseOffset1")] _ORBIT_ROTATION_NOISE_OFFSET1,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,1.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_OrbitRotationNoiseScale1")] _ORBIT_ROTATION_NOISE_SCALE1,
        [MetaToggle(false,VAR_TYPE._BOOL,"_OrbitRotationNoiseOffsetBeforeScale")] _ORBIT_ROTATION_NOISE_OFFSET_BEFORE_SCALE,
        [MetaNumber(4.0f,VAR_TYPE._FLOAT,"_OrbitRotationNoiseSeed")] _ORBIT_ROTATION_NOISE_SEED,
        [MetaNumber(3.0f,VAR_TYPE._FLOAT,"_OrbitRotationNoiseTimeSpeed")] _ORBIT_ROTATION_NOISE_TIME_SPEED,
        [MetaNumber(0.0f,VAR_TYPE._FLOAT,"_OrbitRotationNoiseTimePhase")] _ORBIT_ROTATION_NOISE_TIME_PHASE,
        [MetaNumber(1.0f,VAR_TYPE._FLOAT,"_OrbitRotationNoiseValueScale")] _ORBIT_ROTATION_NOISE_VALUE_SCALE,
        [MetaTexture("\"\"{}","_OrbitRotationLiteNoiseMap")] _ORBIT_ROTATION_LITE_NOISE_MAP,
        [MetaTextureST(new float[]{0.0f,0.0f,1.0f,1.0f},"_OrbitRotationLiteNoiseMap_ST")] _ORBIT_ROTATION_LITE_NOISE_MAP_ST,

        [MetaTexture("\"white\"{}","_OrbitRotationMaskMap")] _ORBIT_ROTATION_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_OrbitRotationMaskMap_ST")] _ORBIT_ROTATION_MASK_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_OrbitRotationMaskMapStrength")] _ORBIT_ROTATION_MASK_CONTROL,
        [MetaTexture("\"black\"{}","_OrbitRotationMap")] _ORBIT_ROTATION_OFFSET_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_OrbitRotationMap_ST")] _ORBIT_ROTATION_OFFSET_CONTROL_TEX_ST,
        [MetaTextureStrength(1.0f,0.0f,1.0f,"_OrbitRotationMapStrength")] _ORBIT_ROTATION_OFFSET_CONTROL,


        [MetaVector(new float[]{0.0f,0.1f,0.0f,0.0f},new int[]{1,1},VAR_TYPE._FLOAT,"_OrbitWaveStrength")] _ORBIT_WAVE_STRENGTH,
        [MetaVector(new float[]{5.0f,5.0f,0.0f,0.0f},new int[]{1,1},VAR_TYPE._FLOAT,"_OrbitWaveFrequency")] _ORBIT_WAVE_FREQUENCY,
        [MetaVector(new float[]{0.0f,0.0f,0.0f,0.0f},new int[]{1,1},VAR_TYPE._FLOAT,"_OrbitWavePhase")] _ORBIT_WAVE_PHASE,
        [MetaVector(new float[]{1.0f,5.0f,0.0f,0.0f},new int[]{1,1},VAR_TYPE._FLOAT,"_OrbitWaveSpeed")] _ORBIT_WAVE_SPEED,

        [MetaAudioLinkSource(0,1,"_OrbitWaveAudioLinkSource")] _ORBIT_WAVE_AUDIOLINK_SOURCE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND_EXPANDED,"_OrbitWaveAudioLinkVUBand")] _ORBIT_WAVE_AUDIOLINK_VU_BAND,
        [MetaRange(8,0,15,VAR_TYPE._UINT,"_OrbitWaveAudioLinkVUSmoothing")] _ORBIT_WAVE_AUDIOLINK_VU_SMOOTHING,
        [MetaRange(0.5f,0.0f,1.0f,VAR_TYPE._FLOAT,"_OrbitWaveAudioLinkVUPanning")] _ORBIT_WAVE_AUDIOLINK_VU_PANNING,
        [MetaVector(new float[]{1.0f,0.0f,0.0f,0.0f},new int[]{1,1},VAR_TYPE._FLOAT,"_OrbitWaveAudioLinkVUStrength")] _ORBIT_WAVE_AUDIOLINK_VU_STRENGTH,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_CHRONOTENSITY_MODE,"_OrbitWaveAudioLinkChronoTensityMode")] _ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND,"_OrbitWaveAudioLinkChronoTensityBand")] _ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MetaVector(new float[]{1.0f,1.0f,0.0f,0.0f},new int[]{1,1},VAR_TYPE._FLOAT,"_OrbitWaveAudioLinkChronoTensityStrength")] _ORBIT_WAVE_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
        [MetaToggle(false,VAR_TYPE._BOOL,"_OrbitWaveAudioLinkSpectrumMode")] _ORBIT_WAVE_AUDIOLINK_SPECTRUM_MODE,
        [MetaToggle(false,VAR_TYPE._BOOL,"_OrbitWaveAudioLinkSpectrumMirror")] _ORBIT_WAVE_AUDIOLINK_SPECTRUM_MIRROR,
        [MetaVector(new float[]{0.0f,1.0f,0.0f,0.0f},new int[]{1,1},VAR_TYPE._FLOAT,"_OrbitWaveAudioLinkSpectrumBounds")] _ORBIT_WAVE_AUDIOLINK_SPECTRUM_BOUNDS,
        [MetaVector(new float[]{1.0f,0.0f,0.0f,0.0f},new int[]{1,1},VAR_TYPE._FLOAT,"_OrbitWaveAudioLinkSpectrumStrength")] _ORBIT_WAVE_AUDIOLINK_SPECTRUM_STRENGTH,

        [MetaAudioLinkSource(0,2,"_OrbitRotationOffsetAudioLinkSource")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND_EXPANDED,"_OrbitRotationOffsetAudioLinkVUBand")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_BAND,
        [MetaRange(8,0,15,VAR_TYPE._UINT,"_OrbitRotationOffsetAudioLinkVUSmoothing")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_SMOOTHING,
        [MetaRange(0.5f,0.0f,1.0f,VAR_TYPE._FLOAT,"_OrbitRotationOffsetAudioLinkVUPanning")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_PANNING,
        [MetaVector(new float[]{1.0f,0.0f,0.0f,1.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_OrbitRotationOffsetAudioLinkVUStrength")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_STRENGTH,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_CHRONOTENSITY_MODE,"_OrbitRotationOffsetAudioLinkChronoTensityMode")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_MODE,
        [MetaEnum(0,PROP_DRAWER._DF_AUDIOLINK_BAND,"_OrbitRotationOffsetAudioLinkChronoTensityBand")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_BAND,
        [MetaVector(new float[]{1.0f,0.0f,0.0f,1.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_OrbitRotationOffsetAudioLinkChronoTensityStrength")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_STRENGTH,

        [MetaTexture("\"white\"{}","_OrbitRotationOffsetMaskMap")] _ORBIT_ROTATION_OFFSET_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_OrbitRotationOffsetMaskMap_ST")] _ORBIT_ROTATION_OFFSET_MASK_CONTROL_TEX_ST,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,1.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_OrbitRotationOffsetMaskMapStrength")] _ORBIT_ROTATION_OFFSET_MASK_CONTROL,
        [MetaTexture("\"white\"{}","_OrbitRotationOffsetAudioLinkMaskMap")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL_TEX,
        [MetaTextureST(new float[]{1.0f,1.0f,0.0f,0.0f},"_OrbitRotationOffsetAudioLinkMaskMap_ST")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL_TEX_ST,
        [MetaVector(new float[]{1.0f,1.0f,1.0f,1.0f},new int[]{1,1,1,2},VAR_TYPE._FLOAT,"_OrbitRotationOffsetAudioLinkMaskMapStrength")] _ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL,
    }

    public enum MESHHOLOGRAM_KEYWORD_ENUM
    {
        [MeshHologramKeywordMeta("_DIRECTIONALLIGHT_ENABLE","_DirectionalLightInfluenceEnable")] _DIRECTIONALLIGHT_ENABLE,
        [MeshHologramKeywordMeta("_AMBIENT_INFLUENCE_ENABLE","_AmbientInfluenceEnable")] _AMBIENT_INFLUENCE_ENABLE,
        [MeshHologramKeywordMeta("_AUDIOLINK_ENABLE","_AudioLinkEnable")] _AUDIOLINK_ENABLE,
        [MeshHologramKeywordMeta("_LIGHTVOLUMES_ENABLE","_LightVolumesInfluenceEnable")] _LIGHTVOLUMES_ENABLE,

        [MeshHologramKeywordMeta(new string[]
        {
            "_STEREO_MERGE_MODE_NONE",
            "_STEREO_MERGE_MODE_POSITION",
            "_STEREO_MERGE_MODE_ROTATION",
            "_STEREO_MERGE_MODE_POSITION_ROTATION",
        },"_StereoMergeMode")] _STEREO_MERGE_MODE,

        [MeshHologramKeywordMeta(new string[]{
            "_FRAGMENT_NOISE_LITE_MODE_NORMAL",
            "_FRAGMENT_NOISE_LITE_MODE_LITE_0",
            "_FRAGMENT_NOISE_LITE_MODE_LITE_1",
            },"test")] _FRAGMENT_NOISE_LITE_MODE,

        [MeshHologramKeywordMeta(new string[]{
            "_COLORING_NOISE_LITE_MODE_NORMAL",
            "_COLORING_NOISE_LITE_MODE_LITE_0",
            "_COLORING_NOISE_LITE_MODE_LITE_1",
            },"test")] _COLORING_NOISE_LITE_MODE,

        [MeshHologramKeywordMeta(new string[]{
            "_GEOMETRY_NOISE_LITE_MODE_NORMAL",
            "_GEOMETRY_NOISE_LITE_MODE_LITE_0",
            "_GEOMETRY_NOISE_LITE_MODE_LITE_1",
            },"test")] _GEOMETRY_NOISE_LITE_MODE,

        [MeshHologramKeywordMeta(new string[]{
            "_ORBIT_NOISE_LITE_MODE_NORMAL",
            "_ORBIT_NOISE_LITE_MODE_LITE_0",
            "_ORBIT_NOISE_LITE_MODE_LITE_1",
            },"test")] _ORBIT_NOISE_LITE_MODE,

        [MeshHologramKeywordMeta(new string[]{
            "_ORBIT_ROTATION_NOISE_LITE_MODE_NORMAL",
            "_ORBIT_ROTATION_NOISE_LITE_MODE_LITE_0",
            "_ORBIT_ROTATION_NOISE_LITE_MODE_LITE_1",
            },"test")] _ORBIT_ROTATION_NOISE_LITE_MODE,
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

    public enum MAIN_CATEGORY
    {
        FRAGMENT       = 0,
        COLOR          = 1,
        GEOMETRY       = 2,
        ORBIT          = 3,
        ORBIT_ROTATION = 4,
    }

    public enum STEREO_MERGE_MODE
    {
        _                 = 0,
        POSITION          = 1,
        ROTATION          = 2,
        POSITION_ROTATION = 3
    }

    public enum DF_ENUM_RENDERING_MODE
    {
        [InspectorName("Transparent")]
        TRANSPARENT,
        [InspectorName("Cutout")]
        CUTOUT,
        [InspectorName("DepthOnly")]
        DEPTH_ONLY,
    }
    public enum DF_ENUM_CULL
    {
        [InspectorName("0: Off")]
        OFF,
        [InspectorName("1: Front")]
        FRONT,
        [InspectorName("2: Back")]
        BACK,
    }
    public enum DF_ENUM_COMPARE
    {
        [InspectorName("0: Disabled")]
        DISABLE,
        [InspectorName("1: Never")]
        NEVER,
        [InspectorName("2: Less")]
        LESS,
        [InspectorName("3: Equal")]
        EQUAL,
        [InspectorName("4: LessEqual")]
        LESS_EQUAL,
        [InspectorName("5: Greater")]
        GREATER,
        [InspectorName("6: NotEqual")]
        NOT_EQUAL,
        [InspectorName("7: GreaterEqual")]
        GREATER_EQUAL,
        [InspectorName("8: Always")]
        ALWAYS,
    }
    public enum DF_ENUM_STEREO_MERGE_MODE
    {
        [InspectorName("None")]
        NONE,
        [InspectorName("Position")]
        POSITION,
        [InspectorName("Rotation")]
        ROTATION,
        [InspectorName("Position & Rotation")]
        POSITION_ROTATION,
    }

    public enum DF_ENUM_BLEND_OP
    {
        [InspectorName("0: Add")]
        ADD,
        [InspectorName("1: Subtract")]
        SUBTRACT,
        [InspectorName("2: ReverseSubtract")]
        REVERSESUBTRACT,
        [InspectorName("3: Min")]
        MIN,
        [InspectorName("4: Max")]
        MAX,
        [InspectorName("5: LogicalClear")]
        LOGICALCLEAR,
        [InspectorName("6: LogicalSet")]
        LOGICALSET,
        [InspectorName("7: LogicalCopy")]
        LOGICALCOPY,
        [InspectorName("8: LogicalCopyInverted")]
        LOGICALCOPYINVERTED,
        [InspectorName("9: LogicalNoop")]
        LOGICALNOOP,
        [InspectorName("10: LogicalInvert")]
        LOGICALINVERT,
        [InspectorName("11: LogicalAnd")]
        LOGICALAND,
        [InspectorName("12: LogicalNand")]
        LOGICALNAND,
        [InspectorName("13: LogicalOr")]
        LOGICALOR,
        [InspectorName("14: LogicalNor")]
        LOGICALNOR,
        [InspectorName("15: LogicalXor")]
        LOGICALXOR,
        [InspectorName("16: LogicalEquivalence")]
        LOGICALEQUIVALENCE,
        [InspectorName("17: LogicalAndReverse")]
        LOGICALANDREVERSE,
        [InspectorName("18: LogicalAndInverted")]
        LOGICALANDINVERTED,
        [InspectorName("19: LogicalOrReverse")]
        LOGICALORREVERSE,
        [InspectorName("20: LogicalOrInverted")]
        LOGICALORINVERTED,
        [InspectorName("21: Multiply")]
        MULTIPLY,
        [InspectorName("22: Screen")]
        SCREEN,
        [InspectorName("23: Overlay")]
        OVERLAY,
        [InspectorName("24: Darken")]
        DARKEN,
        [InspectorName("25: Lighten")]
        LIGHTEN,
        [InspectorName("26: ColorDodge")]
        COLORDODGE,
        [InspectorName("27: ColorBurn")]
        COLORBURN,
        [InspectorName("28: HardLight")]
        HARDLIGHT,
        [InspectorName("29: SoftLight")]
        SOFTLIGHT,
        [InspectorName("30: Difference")]
        DIFFERENCE,
        [InspectorName("31: Exclusion")]
        EXCLUSION,
        [InspectorName("32: HSLHue")]
        HSLHUE,
        [InspectorName("33: HSLSaturation")]
        HSLSATURATION,
        [InspectorName("34: HSLColor")]
        HSLCOLOR,
        [InspectorName("35: HSLLuminosity")]
        HSLLUMINOSITY,
    }
    public enum DF_ENUM_BLEND_MODE
    {
        [InspectorName("0: Zero")]
        ZERO,
        [InspectorName("1: One")]
        ONE,
        [InspectorName("2: DstColor")]
        DSTCOLOR,
        [InspectorName("3: SrcColor")]
        SRCCOLOR,
        [InspectorName("4: OneMinusDstColor")]
        ONEMINUSDSTCOLOR,
        [InspectorName("5: SrcAlpha")]
        SRCALPHA,
        [InspectorName("6: OneMinusSrcColor")]
        ONEMINUSSRCCOLOR,
        [InspectorName("7: DstAlpha")]
        DSTALPHA,
        [InspectorName("8: OneMinusDstAlpha")]
        ONEMINUSDSTALPHA,
        [InspectorName("9: SrcAlphaSaturate")]
        SRCALPHASATURATE,
        [InspectorName("10: OneMinusSrcAlpha")]
        ONEMINUSSRCALPHA,
    }
    public enum DF_ENUM_STENCIL_OP
    {
        [InspectorName("0: Keep")]
        KEEP,
        [InspectorName("1: Zero")]
        ZERO,
        [InspectorName("2: Replace")]
        REPLACE,
        [InspectorName("3: IncrementSaturate")]
        INCREMENTSATURATE,
        [InspectorName("4: DecrementSaturate")]
        DECREMENTSATURATE,
        [InspectorName("5: Invert")]
        INVERT,
        [InspectorName("6: IncrementWrap")]
        INCREMENTWRAP,
        [InspectorName("7: DecrementWrap")]
        DECREMENTWRAP,
    }

    public enum DF_ENUM_AUDIOLINK_BAND
    {
        [InspectorName("0: Bass")]
        BASS,
        [InspectorName("1: Low Mid")]
        LOW_MID,
        [InspectorName("2: High Mid")]
        HIGH_MID,
        [InspectorName("3: Treble")]
        TREBLE,
    }

    public enum DF_ENUM_AUDIOLINK_BAND_EXPANDED
    {
        [InspectorName("0: Bass")]
        BASS,
        [InspectorName("1: Low Mid")]
        LOW_MID,
        [InspectorName("2: High Mid")]
        HIGH_MID,
        [InspectorName("3: Treble")]
        TREBLE,
        [InspectorName("4: Average")]
        AVERAGE,
    }

    public enum DF_ENUM_LINE_ANIMATION_MODE
    {
        [InspectorName("0: Normal")]
        NORMAL,
        [InspectorName("1: ZoomIn")]
        ZOOM_IN,
        [InspectorName("2: ZoomOut")]
        ZOOM_OUT,
        [InspectorName("3: PowerZoomIn")]
        POWER_ZOOM_IN,
        [InspectorName("4: Collapse")]
        COLLAPSE,
        [InspectorName("5: Break")]
        BREAK,
        [InspectorName("6: OutWide")]
        OUT_WIDE,
        [InspectorName("7: OutThin")]
        OUT_THIN,
        [InspectorName("8: Vanishing")]
        VANISHING,
        [InspectorName("9: Join1")]
        JOIN_1,
        [InspectorName("10: Join2")]
        JOIN_2,
        [InspectorName("11: Join3")]
        JOIN_3,
    }
    public enum DF_ENUM_PARTITION_MODE
    {
        [InspectorName("0: Vertex")]
        VERTEX,
        [InspectorName("1: Edge")]
        EDGE,
        [InspectorName("2: Mesh")]
        MESH,
    }
    public enum DF_ENUM_COLOR_SOURCE
    {
        [InspectorName("0: Gradient")]
        GRADIENT,
        [InspectorName("1: Primary")]
        PRIMARY,
        [InspectorName("2: GradientTex")]
        GRADIENTTEX,
        [InspectorName("3: VertexColor")]
        VERTEXCOLOR,
        [InspectorName("4: UniqueEdges")]
        UNIQUEEDGES,
        [InspectorName("5: AudioLink ThemeColor")]
        AUDIOLINK_THEMECOLOR,
    }
    public enum DF_ENUM_PIXELIZATION_SPACE
    {
        [InspectorName("0: Disable")]
        DISABLE,
        [InspectorName("1: Model")]
        MODEL,
        [InspectorName("2: World")]
        WORLD,
        [InspectorName("3: PostGeometry")]
        POSTGEOMETRY,
    }
    public enum DF_ENUM_NOISE_SPACE
    {
        [InspectorName("0: Offset")]
        OFFSET,
        [InspectorName("1: Model")]
        MODEL,
        [InspectorName("2: World")]
        WORLD,
        [InspectorName("3: Offset World")]
        OFFSET_WORLD,
        [InspectorName("4: Model & World")]
        MODEL_WORLD,
        [InspectorName("5: VertexColor")]
        VERTEXCOLOR,
    }

    public enum DF_ENUM_SOURCE
    {
        [InspectorName("0: Fixed Value")]
        FIXED_VALUE,
        [InspectorName("1: Noise")]
        NOISE,
        [InspectorName("2: Primitive")]
        PRIMITIVE,
    }
    public enum DF_ENUM_AUDIOLINK_SOURCE
    {
        [InspectorName("0: None")]
        NONE,
        [InspectorName("1: VU Add")]
        VU_ADD,
        [InspectorName("2: VU Mul")]
        VU_MUL,
        [InspectorName("3: ChronoTensity")]
        CHRONOTENSITY,
        [InspectorName("4: Spectrum")]
        SPECTRUM,
    }
    public enum DF_ENUM_AUDIOLINK_CHRONOTENSITY_MODE
    {
        [InspectorName("0: Nudging")]
        NUDGING,
        [InspectorName("1: Filtered Nudging")]
        FILTERED_NUDGING,
        [InspectorName("2: Dynamics")]
        DYNAMICS,
        [InspectorName("3: Filtered Dynamics")]
        FILTERED_DYNAMICS,
        [InspectorName("4: Hold")]
        HOLD,
        [InspectorName("5: Filtered Hold")]
        FILTERED_HOLD,
        [InspectorName("6: Increases with Louder")]
        INCREASES_WITH_LOUDER,
        [InspectorName("7: Increases with Quite")]
        INCREASES_WITH_QUITE,
    }

    public enum DF_ENUM_LOOP_MODE
    {
        [InspectorName("0: Clip")]
        CLIP,
        [InspectorName("1: Repeat")]
        REPEAT,
        [InspectorName("2: Ping-Pong")]
        PING_PONG,
    }
    public enum DF_ENUM_EASE_MODE
    {
        [InspectorName("0: In")]
        IN,
        [InspectorName("1: Out")]
        OUT,
        [InspectorName("2: InOut")]
        INOUT,
        [InspectorName("3: Invert InOut")]
        INVERT_INOUT,
    }

    public enum GUI_STYLE
    {
        PLAIN,
        TITLE0,
        TITLE1,
        HEADER0,
        HEADER1,
    }

    public enum CONFIG
    {
        LANGUAGE = 0,
        TITLE_SKIN = 1,
        PIPELINE = 2,
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

    public enum PIPELINE
    {
        BUILTIN = 0,
        URP = 1,
        HDRP = 2,
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