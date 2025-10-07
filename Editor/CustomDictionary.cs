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
                { SHADER_PROPERTY._AUDIOLINK_VU_BAND,new ShaderPropertyState("_AudioLinkVUBand")},
                {SHADER_PROPERTY._AUDIOLINK_VU_SMOOTHING,new ShaderPropertyState("_AudioLinkVUSmoothing")},
                {SHADER_PROPERTY._AUDIOLINK_VU_PANNING,new ShaderPropertyState("_AudioLinkVUPanning")},
                {SHADER_PROPERTY._AUDIOLINK_VU_GAIN_MUL,new ShaderPropertyState("_AudioLinkVUGainMul")},
                {SHADER_PROPERTY._AUDIOLINK_VU_GAIN_ADD,new ShaderPropertyState("_AudioLinkVUGainAdd")},
                {SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_DIVISOR,new ShaderPropertyState("_AudioLinkChronoTensityDivisor")},
                {SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_BAND,new ShaderPropertyState("_AudioLinkChronoTensityBand")},
                {SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_MODE,new ShaderPropertyState("_AudioLinkChronoTensityMode")},
                {SHADER_PROPERTY._AUDIOLINK_THEME_COLOR_BAND,new ShaderPropertyState("_AudioLinkThemeColorBand")},


                {SHADER_PROPERTY._FRAGMENT_TRIANGLE_COMPRESSION,new ShaderPropertyState("_FragmentTriangleCompression")},
                {SHADER_PROPERTY._FRAGMENT_FILL,new ShaderPropertyState("_FragmentFill")},
                {SHADER_PROPERTY._FRAGMENT_LINE_WIDTH,new ShaderPropertyState("_FragmentLineWidth")},
                {SHADER_PROPERTY._FRAGMENT_LINE_GRADIENT_BIAS,new ShaderPropertyState("_FragmentLineGradientBias")},
                {SHADER_PROPERTY._FRAGMENT_MANUAL_LINE_SCALING,new ShaderPropertyState("_FragmentManualLineScalingEnable")},
                {SHADER_PROPERTY._FRAGMENT_LINE_SCALE,new ShaderPropertyState("_FragmentLineScale")},
                {SHADER_PROPERTY._FRAGMENT_LINE_ANIMATION_MODE,new ShaderPropertyState("_FragmentLineAnimationMode")},
                {SHADER_PROPERTY._FRAGMENT_INVERSE,new ShaderPropertyState("_InvertFragment")},
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
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_FragmentAudioLinkVUStrength")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_FragmentAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_FragmentAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_FragmentAudioLinkSpectrumMirror")},

                {SHADER_PROPERTY._FRAGMENT_PHASE_SCALE,new ShaderPropertyState("_FragmentPhaseScale")},
                {SHADER_PROPERTY._FRAGMENT_LOOP_MODE,new ShaderPropertyState("_FragmentLoopMode")},
                {SHADER_PROPERTY._FRAGMENT_EASE_MODE,new ShaderPropertyState("_FragmentEaseMode")},
                {SHADER_PROPERTY._FRAGMENT_EASE_CURVE,new ShaderPropertyState("_FragmentEaseCurve")},
                {SHADER_PROPERTY._FRAGMENT_MID_MUL,new ShaderPropertyState("_FragmentMidMul")},
                {SHADER_PROPERTY._FRAGMENT_MID_ADD,new ShaderPropertyState("_FragmentMidAdd")},


                {SHADER_PROPERTY._COLORING_SOURCE,new ShaderPropertyState("_ColoringSource")},
                {SHADER_PROPERTY._COLORING_FIXED_VALUE,new ShaderPropertyState("_ColoringFixedValue")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SOURCE,new ShaderPropertyState("_ColoringAudioLinkSource")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_ColoringAudioLinkVUStrength")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_ColoringAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_ColoringAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_ColoringAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._COLORING_PHASE_SCALE,new ShaderPropertyState("_ColoringPhaseScale")},
                {SHADER_PROPERTY._COLORING_LOOP_MODE,new ShaderPropertyState("_ColoringLoopMode")},
                {SHADER_PROPERTY._COLORING_EASE_MODE,new ShaderPropertyState("_ColoringEaseMode")},
                {SHADER_PROPERTY._COLORING_EASE_CURVE,new ShaderPropertyState("_ColoringEaseCurve")},
                {SHADER_PROPERTY._COLORING_MID_MUL,new ShaderPropertyState("_ColoringMidMul")},
                {SHADER_PROPERTY._COLORING_MID_ADD,new ShaderPropertyState("_ColoringMidAdd")},


                {SHADER_PROPERTY._GEOMETRY_SOURCE,new ShaderPropertyState("_GeometrySource")},
                {SHADER_PROPERTY._GEOMETRY_FIXED_VALUE,new ShaderPropertyState("_GeometryFixedValue")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SOURCE,new ShaderPropertyState("_GeometryAudioLinkSource")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_GeometryAudioLinkVUStrength")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_GeometryAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_GeometryAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_GeometryAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._GEOMETRY_PHASE_SCALE,new ShaderPropertyState("_GeometryPhaseScale")},
                {SHADER_PROPERTY._GEOMETRY_LOOP_MODE,new ShaderPropertyState("_GeometryLoopMode")},
                {SHADER_PROPERTY._GEOMETRY_EASE_MODE,new ShaderPropertyState("_GeometryEaseMode")},
                {SHADER_PROPERTY._GEOMETRY_EASE_CURVE,new ShaderPropertyState("_GeometryEaseCurve")},
                {SHADER_PROPERTY._GEOMETRY_MID_MUL,new ShaderPropertyState("_GeometryMidMul")},
                {SHADER_PROPERTY._GEOMETRY_MID_ADD,new ShaderPropertyState("_GeometryMidAdd")},


                {SHADER_PROPERTY._ORBIT_SOURCE,new ShaderPropertyState("_OrbitSource")},
                {SHADER_PROPERTY._ORBIT_FIXED_VALUE,new ShaderPropertyState("_OrbitFixedValue")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_SOURCE,new ShaderPropertyState("_OrbitAudioLinkSource")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_OrbitAudioLinkVUStrength")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_OrbitAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_OrbitAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_OrbitAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._ORBIT_PHASE_SCALE,new ShaderPropertyState("_OrbitPhaseScale")},
                {SHADER_PROPERTY._ORBIT_LOOP_MODE,new ShaderPropertyState("_OrbitLoopMode")},
                {SHADER_PROPERTY._ORBIT_EASE_MODE,new ShaderPropertyState("_OrbitEaseMode")},
                {SHADER_PROPERTY._ORBIT_EASE_CURVE,new ShaderPropertyState("_OrbitEaseCurve")},
                {SHADER_PROPERTY._ORBIT_MID_MUL,new ShaderPropertyState("_OrbitMidMul")},
                {SHADER_PROPERTY._ORBIT_MID_ADD,new ShaderPropertyState("_OrbitMidAdd")},


                {SHADER_PROPERTY._ORBIT_ROTATION_SOURCE,new ShaderPropertyState("_OrbitRotationSource")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_SOURCE,new ShaderPropertyState("_OrbitRotationOffsetSource")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkSource")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkVUStrength")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._ORBIT_ROTATION_FIXED_VALUE,new ShaderPropertyState("_OrbitRotationFixedValue")},

                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SOURCE,new ShaderPropertyState("_OrbitWaveAudioLinkSource")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_OrbitWaveAudioLinkVUStrength")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_CHRONOTENSITY_STRENGTH,new ShaderPropertyState("_OrbitWaveAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_MODE,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumMode")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_BOUNDS,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumBounds")},


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


                {SHADER_PROPERTY._NOISE1ST_SPACE,new ShaderPropertyState("_Noise1stSpace")},
                {SHADER_PROPERTY._NOISE2ND_SPACE,new ShaderPropertyState("_Noise2ndSpace")},
                {SHADER_PROPERTY._NOISE3RD_SPACE,new ShaderPropertyState("_Noise3rdSpace")},

                {SHADER_PROPERTY._NOISE1ST_OFFSET0,new ShaderPropertyState("_Noise1stOffset0")},
                {SHADER_PROPERTY._NOISE1ST_SCALE0,new ShaderPropertyState("_Noise1stScale0")},
                {SHADER_PROPERTY._NOISE1ST_OFFSET1,new ShaderPropertyState("_Noise1stOffset1")},
                {SHADER_PROPERTY._NOISE1ST_SCALE1,new ShaderPropertyState("_Noise1stScale1")},
                {SHADER_PROPERTY._NOISE1ST_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_Noise1stOffsetBeforeScale")},
                {SHADER_PROPERTY._NOISE1ST_SEED,new ShaderPropertyState("_Noise1stSeed")},
                {SHADER_PROPERTY._NOISE1ST_TIME_SPEED,new ShaderPropertyState("_Noise1stTimeSpeed")},
                {SHADER_PROPERTY._NOISE1ST_TIME_PHASE,new ShaderPropertyState("_Noise1stTimePhase")},
                {SHADER_PROPERTY._NOISE1ST_VALUE_SCALE,new ShaderPropertyState("_Noise1stValueScale")},

                {SHADER_PROPERTY._NOISE2ND_OFFSET0,new ShaderPropertyState("_Noise2ndOffset0")},
                {SHADER_PROPERTY._NOISE2ND_SCALE0,new ShaderPropertyState("_Noise2ndScale0")},
                {SHADER_PROPERTY._NOISE2ND_OFFSET1,new ShaderPropertyState("_Noise2ndOffset1")},
                {SHADER_PROPERTY._NOISE2ND_SCALE1,new ShaderPropertyState("_Noise2ndScale1")},
                {SHADER_PROPERTY._NOISE2ND_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_Noise2ndOffsetBeforeScale")},
                {SHADER_PROPERTY._NOISE2ND_SEED,new ShaderPropertyState("_Noise2ndSeed")},
                {SHADER_PROPERTY._NOISE2ND_TIME_SPEED,new ShaderPropertyState("_Noise2ndTimeSpeed")},
                {SHADER_PROPERTY._NOISE2ND_TIME_PHASE,new ShaderPropertyState("_Noise2ndTimePhase")},
                {SHADER_PROPERTY._NOISE2ND_VALUE_SCALE,new ShaderPropertyState("_Noise2ndValueScale")},

                {SHADER_PROPERTY._NOISE3RD_OFFSET0,new ShaderPropertyState("_Noise3rdOffset0")},
                {SHADER_PROPERTY._NOISE3RD_SCALE0,new ShaderPropertyState("_Noise3rdScale0")},
                {SHADER_PROPERTY._NOISE3RD_OFFSET1,new ShaderPropertyState("_Noise3rdOffset1")},
                {SHADER_PROPERTY._NOISE3RD_SCALE1,new ShaderPropertyState("_Noise3rdScale1")},
                {SHADER_PROPERTY._NOISE3RD_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_Noise3rdOffsetBeforeScale")},
                {SHADER_PROPERTY._NOISE3RD_SEED,new ShaderPropertyState("_Noise3rdSeed")},
                {SHADER_PROPERTY._NOISE3RD_TIME_SPEED,new ShaderPropertyState("_Noise3rdTimeSpeed")},
                {SHADER_PROPERTY._NOISE3RD_TIME_PHASE,new ShaderPropertyState("_Noise3rdTimePhase")},
                {SHADER_PROPERTY._NOISE3RD_VALUE_SCALE,new ShaderPropertyState("_Noise3rdValueScale")},
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