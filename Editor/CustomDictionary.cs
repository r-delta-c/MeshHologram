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
                { SHADER_PROPERTY._FORCED_Z_SCALE_ZERO,new ShaderPropertyState("_Forced_Z_Scale_Zero")},
                {SHADER_PROPERTY._BILLBOARD_MODE,new ShaderPropertyState("_BillboardMode")},
                {SHADER_PROPERTY._DISTANCE_INFLUENCE,new ShaderPropertyState("_DistanceInfluence")},
                {SHADER_PROPERTY._STEREO_MERGE_MODE,new ShaderPropertyState("_StereoMergeMode")},
                {SHADER_PROPERTY._USE_FWIDTH,new ShaderPropertyState("_UseFwidth")},

                {SHADER_PROPERTY._ACTIVATE_DIRECTIONAL_LIGHT_INFLUENCE, new ShaderPropertyState("_ActivateDirectionalLightInfluence")},
                {SHADER_PROPERTY._DIRECTIONAL_LIGHT_INFLUENCE,new ShaderPropertyState("_DirectionalLightInfluence")},
                {SHADER_PROPERTY._ACTIVATE_AMBIENT_INFLUENCE, new ShaderPropertyState("_ActivateAmbientInfluence")},
                {SHADER_PROPERTY._AMBIENT_INFLUENCE,new ShaderPropertyState("_AmbientInfluence")},
                {SHADER_PROPERTY._ACTIVATE_LIGHTVOLUMES_INFLUENCE, new ShaderPropertyState("_ActivateLightVolumesInfluence")},
                {SHADER_PROPERTY._LIGHTVOLUMES_INFLUENCE,new ShaderPropertyState("_LightVolumesInfluence")},
                {SHADER_PROPERTY._PREVIEW_MODE,new ShaderPropertyState("_PreviewMode")},
                {SHADER_PROPERTY._ANTI_ALIASING,new ShaderPropertyState("_AntiAliasing")},

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


                {SHADER_PROPERTY._USE_AUDIOLINK,new ShaderPropertyState("_UseAudioLink")},
                { SHADER_PROPERTY._AUDIOLINK_VU_BAND,new ShaderPropertyState("_AudioLinkVUBand")},
                {SHADER_PROPERTY._AUDIOLINK_VU_SMOOTH,new ShaderPropertyState("_AudioLinkVUSmooth")},
                {SHADER_PROPERTY._AUDIOLINK_VU_PANNING,new ShaderPropertyState("_AudioLinkVUPanning")},
                {SHADER_PROPERTY._AUDIOLINK_VU_GAIN_MUL,new ShaderPropertyState("_AudioLinkVUGainMul")},
                {SHADER_PROPERTY._AUDIOLINK_VU_GAIN_ADD,new ShaderPropertyState("_AudioLinkVUGainAdd")},
                {SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_SCALE,new ShaderPropertyState("_AudioLinkChronoTensityScale")},
                {SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_BAND,new ShaderPropertyState("_AudioLinkChronoTensityBand")},
                {SHADER_PROPERTY._AUDIOLINK_CHRONO_TENSITY_TYPE,new ShaderPropertyState("_AudioLinkChronoTensityType")},
                {SHADER_PROPERTY._AUDIOLINK_THEME_COLOR_BAND,new ShaderPropertyState("_AudioLinkThemeColorBand")},


                {SHADER_PROPERTY._TRIANGLE_COMP,new ShaderPropertyState("_TriangleComp")},
                {SHADER_PROPERTY._FILL,new ShaderPropertyState("_Fill")},
                {SHADER_PROPERTY._LINE_WIDTH,new ShaderPropertyState("_LineWidth")},
                {SHADER_PROPERTY._LINE_GRADIENT_BIAS,new ShaderPropertyState("_LineGradientBias")},
                {SHADER_PROPERTY._MANUAL_LINE_SCALING,new ShaderPropertyState("_ManualLineScaling")},
                {SHADER_PROPERTY._LINE_SCALE,new ShaderPropertyState("_LineScale")},
                {SHADER_PROPERTY._LINE_FADE_MODE,new ShaderPropertyState("_LineFadeMode")},
                {SHADER_PROPERTY._FRAGMENT_INVERSE,new ShaderPropertyState("_FragmentInverse")},
                {SHADER_PROPERTY._FRAGMENT_PARTITION_TYPE,new ShaderPropertyState("_FragmentPartitionType")},


                {SHADER_PROPERTY._COLOR0,new ShaderPropertyState("_Color0")},
                {SHADER_PROPERTY._COLOR1,new ShaderPropertyState("_Color1")},
                {SHADER_PROPERTY._EMISSION,new ShaderPropertyState("_Emission")},
                {SHADER_PROPERTY._COLOR_SOURCE,new ShaderPropertyState("_ColorSource")},
                {SHADER_PROPERTY._COLOR_GRADIENT_TEX,new ShaderPropertyState("_ColorGradientTex")},
                {SHADER_PROPERTY._COLORING_PARTITION_TYPE,new ShaderPropertyState("_ColoringPartitionType")},


                {SHADER_PROPERTY._GEOMETRY_SCALE,new ShaderPropertyState("_GeometryScale")},
                {SHADER_PROPERTY._GEOMETRY_SCALE_RANGE,new ShaderPropertyState("_GeometryScaleRange")},
                {SHADER_PROPERTY._GEOMETRY_EXTRUDE,new ShaderPropertyState("_GeometryExtrude")},
                {SHADER_PROPERTY._GEOMETRY_EXTRUDE_RANGE,new ShaderPropertyState("_GeometryExtrudeRange")},
                {SHADER_PROPERTY._GEOMETRY_PARTITION_BIAS,new ShaderPropertyState("_GeometryPartitionBias")},
                {SHADER_PROPERTY._GEOMETRY_ROTATION,new ShaderPropertyState("_GeometryRotation")},
                {SHADER_PROPERTY._GEOMETRY_ROTATION_INFLUENCE,new ShaderPropertyState("_GeometryRotationInfluence")},
                {SHADER_PROPERTY._GEOMETRY_ROTATION_REVERSE,new ShaderPropertyState("_GeometryRotationReverse")},
                {SHADER_PROPERTY._GEOMETRY_ROTATION_NOISE_REPEAT,new ShaderPropertyState("_GeometryRotationNoiseRepeat")},

                {SHADER_PROPERTY._PIXELIZATION_SPACE,new ShaderPropertyState("_PixelizationSpace")},
                {SHADER_PROPERTY._PIXELIZATION,new ShaderPropertyState("_Pixelization")},


                {SHADER_PROPERTY._ACTIVATE_ORBIT,new ShaderPropertyState("_ActivateOrbit")},

                {SHADER_PROPERTY._ORBIT_SEED,new ShaderPropertyState("_OrbitSeed")},
                {SHADER_PROPERTY._ORBIT_PRIMITIVE_THRESHOLD,new ShaderPropertyState("_OrbitPrimitiveThreshold")},
                {SHADER_PROPERTY._ORBIT_ROTATION_SEED,new ShaderPropertyState("_OrbitRotationSeed")},
                {SHADER_PROPERTY._ORBIT_ROTATION,new ShaderPropertyState("_OrbitRotation")},
                {SHADER_PROPERTY._ORBIT_ROTATION_TIME_MULTIPLIER,new ShaderPropertyState("_OrbitRotationTimeMultiplier")},
                {SHADER_PROPERTY._ORBIT_ROTATION_VARIANCE,new ShaderPropertyState("_OrbitRotationVariance")},

                {SHADER_PROPERTY._ORBIT_OFFSET,new ShaderPropertyState("_OrbitOffset")},
                {SHADER_PROPERTY._ORBIT_SCALE,new ShaderPropertyState("_OrbitScale")},

                {SHADER_PROPERTY._ORBIT_WAVE_STRENGTH,new ShaderPropertyState("_OrbitWaveStrength")},
                {SHADER_PROPERTY._ORBIT_WAVE_FREQUENCY,new ShaderPropertyState("_OrbitWaveFrequency")},
                {SHADER_PROPERTY._ORBIT_WAVE_PHASE,new ShaderPropertyState("_OrbitWavePhase")},
                {SHADER_PROPERTY._ORBIT_WAVE_TIME_MULTIPLIER,new ShaderPropertyState("_OrbitWaveTimeMultiplier")},

                {SHADER_PROPERTY._FRAGMENT_SOURCE,new ShaderPropertyState("_FragmentSource")},
                {SHADER_PROPERTY._FRAGMENT_VALUE,new ShaderPropertyState("_FragmentValue")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SOURCE,new ShaderPropertyState("_FragmentAudioLinkSource")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_FragmentAudioLinkVUStrength")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_FragmentAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_FragmentAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_FragmentAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_SPECTRUM_TYPE,new ShaderPropertyState("_FragmentAudioLinkSpectrumType")},
                {SHADER_PROPERTY._FRAGMENT_PHASE_SCALE,new ShaderPropertyState("_FragmentPhaseScale")},
                {SHADER_PROPERTY._FRAGMENT_THRESHOLD_MUL,new ShaderPropertyState("_FragmentThresholdMul")},
                {SHADER_PROPERTY._FRAGMENT_THRESHOLD_ADD,new ShaderPropertyState("_FragmentThresholdAdd")},
                {SHADER_PROPERTY._FRAGMENT_LOOP_MODE,new ShaderPropertyState("_FragmentLoopMode")},
                {SHADER_PROPERTY._FRAGMENT_EASE_MODE,new ShaderPropertyState("_FragmentEaseMode")},
                {SHADER_PROPERTY._FRAGMENT_EASE_CURVE,new ShaderPropertyState("_FragmentEaseCurve")},


                {SHADER_PROPERTY._COLORING_SOURCE,new ShaderPropertyState("_ColoringSource")},
                {SHADER_PROPERTY._COLORING_VALUE,new ShaderPropertyState("_ColoringValue")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SOURCE,new ShaderPropertyState("_ColoringAudioLinkSource")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_ColoringAudioLinkVUStrength")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_ColoringAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_ColoringAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_ColoringAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_SPECTRUM_TYPE,new ShaderPropertyState("_ColoringAudioLinkSpectrumType")},
                {SHADER_PROPERTY._COLORING_PHASE_SCALE,new ShaderPropertyState("_ColoringPhaseScale")},
                {SHADER_PROPERTY._COLORING_THRESHOLD_MUL,new ShaderPropertyState("_ColoringThresholdMul")},
                {SHADER_PROPERTY._COLORING_THRESHOLD_ADD,new ShaderPropertyState("_ColoringThresholdAdd")},
                {SHADER_PROPERTY._COLORING_LOOP_MODE,new ShaderPropertyState("_ColoringLoopMode")},
                {SHADER_PROPERTY._COLORING_EASE_MODE,new ShaderPropertyState("_ColoringEaseMode")},
                {SHADER_PROPERTY._COLORING_EASE_CURVE,new ShaderPropertyState("_ColoringEaseCurve")},


                {SHADER_PROPERTY._GEOMETRY_SOURCE,new ShaderPropertyState("_GeometrySource")},
                {SHADER_PROPERTY._GEOMETRY_VALUE,new ShaderPropertyState("_GeometryValue")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SOURCE,new ShaderPropertyState("_GeometryAudioLinkSource")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_GeometryAudioLinkVUStrength")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_GeometryAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_GeometryAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_GeometryAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_SPECTRUM_TYPE,new ShaderPropertyState("_GeometryAudioLinkSpectrumType")},
                {SHADER_PROPERTY._GEOMETRY_PHASE_SCALE,new ShaderPropertyState("_GeometryPhaseScale")},
                {SHADER_PROPERTY._GEOMETRY_THRESHOLD_MUL,new ShaderPropertyState("_GeometryThresholdMul")},
                {SHADER_PROPERTY._GEOMETRY_THRESHOLD_ADD,new ShaderPropertyState("_GeometryThresholdAdd")},
                {SHADER_PROPERTY._GEOMETRY_LOOP_MODE,new ShaderPropertyState("_GeometryLoopMode")},
                {SHADER_PROPERTY._GEOMETRY_EASE_MODE,new ShaderPropertyState("_GeometryEaseMode")},
                {SHADER_PROPERTY._GEOMETRY_EASE_CURVE,new ShaderPropertyState("_GeometryEaseCurve")},


                {SHADER_PROPERTY._ORBIT_SOURCE,new ShaderPropertyState("_OrbitSource")},
                {SHADER_PROPERTY._ORBIT_VALUE,new ShaderPropertyState("_OrbitValue")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_SOURCE,new ShaderPropertyState("_OrbitAudioLinkSource")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_OrbitAudioLinkVUStrength")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_OrbitAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_OrbitAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_OrbitAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_SPECTRUM_TYPE,new ShaderPropertyState("_OrbitAudioLinkSpectrumType")},
                {SHADER_PROPERTY._ORBIT_PHASE_SCALE,new ShaderPropertyState("_OrbitPhaseScale")},
                {SHADER_PROPERTY._ORBIT_THRESHOLD_MUL,new ShaderPropertyState("_OrbitThresholdMul")},
                {SHADER_PROPERTY._ORBIT_THRESHOLD_ADD,new ShaderPropertyState("_OrbitThresholdAdd")},
                {SHADER_PROPERTY._ORBIT_LOOP_MODE,new ShaderPropertyState("_OrbitLoopMode")},
                {SHADER_PROPERTY._ORBIT_EASE_MODE,new ShaderPropertyState("_OrbitEaseMode")},
                {SHADER_PROPERTY._ORBIT_EASE_CURVE,new ShaderPropertyState("_OrbitEaseCurve")},


                {SHADER_PROPERTY._ORBIT_ROTATION_SOURCE,new ShaderPropertyState("_OrbitRotationSource")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_SOURCE,new ShaderPropertyState("_OrbitRotationOffsetSource")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_SOURCE,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkSource")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkVUStrength")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_CHRONO_TENSITY_STRENGTH,new ShaderPropertyState("_OrbitRotationOffsetAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._ORBIT_ROTATION_VALUE,new ShaderPropertyState("_OrbitRotationValue")},
                {SHADER_PROPERTY._ORBIT_ROTATION_PHASE_SCALE,new ShaderPropertyState("_OrbitRotationPhaseScale")},
                {SHADER_PROPERTY._ORBIT_ROTATION_THRESHOLD_MUL,new ShaderPropertyState("_OrbitRotationThresholdMul")},
                {SHADER_PROPERTY._ORBIT_ROTATION_THRESHOLD_ADD,new ShaderPropertyState("_OrbitRotationThresholdAdd")},
                {SHADER_PROPERTY._ORBIT_ROTATION_LOOP_MODE,new ShaderPropertyState("_OrbitRotationLoopMode")},
                {SHADER_PROPERTY._ORBIT_ROTATION_EASE_MODE,new ShaderPropertyState("_OrbitRotationEaseMode")},
                {SHADER_PROPERTY._ORBIT_ROTATION_EASE_CURVE,new ShaderPropertyState("_OrbitRotationEaseCurve")},

                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SOURCE,new ShaderPropertyState("_OrbitWaveAudioLinkSource")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_VU_STRENGTH,new ShaderPropertyState("_OrbitWaveAudioLinkVUStrength")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_CHRONOTENSITY_STRENGTH,new ShaderPropertyState("_OrbitWaveAudioLinkChronoTensityStrength")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_STRENGTH,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumStrength")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_MIRROR,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumMirror")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_TYPE,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumType")},
                {SHADER_PROPERTY._ORBIT_WAVE_AUDIOLINK_SPECTRUM_RANGE,new ShaderPropertyState("_OrbitWaveAudioLinkSpectrumRange")},


                { SHADER_PROPERTY._FRAGMENT_MASK_CONTROL_TEX,new ShaderPropertyState("_FragmentMaskMap")},
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

                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState("_FragmentALMaskMap")},
                {SHADER_PROPERTY._FRAGMENT_AUDIOLINK_MASK_CONTROL,new ShaderPropertyState("_FragmentALMaskMapStrength")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState("_ColoringALMaskMap")},
                {SHADER_PROPERTY._COLORING_AUDIOLINK_MASK_CONTROL,new ShaderPropertyState("_ColoringALMaskMapStrength")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState("_GeometryALMaskMap")},
                {SHADER_PROPERTY._GEOMETRY_AUDIOLINK_MASK_CONTROL,new ShaderPropertyState("_GeometryALMaskMapStrength")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState("_OrbitALMaskMap")},
                {SHADER_PROPERTY._ORBIT_AUDIOLINK_MASK_CONTROL,new ShaderPropertyState("_OrbitALMaskMapStrength")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL_TEX,new ShaderPropertyState("_OrbitRotationOffsetALMaskMap")},
                {SHADER_PROPERTY._ORBIT_ROTATION_OFFSET_AUDIOLINK_MASK_CONTROL,new ShaderPropertyState("_OrbitRotationOffsetALMaskMapStrength")},


                {SHADER_PROPERTY._NOISE1ST_SPACE,new ShaderPropertyState("_Noise1stSpace")},
                {SHADER_PROPERTY._NOISE2ND_SPACE,new ShaderPropertyState("_Noise2ndSpace")},
                {SHADER_PROPERTY._NOISE3RD_SPACE,new ShaderPropertyState("_Noise3rdSpace")},

                {SHADER_PROPERTY._NOISE1ST_OFFSET0,new ShaderPropertyState("_Noise1stOffset0")},
                {SHADER_PROPERTY._NOISE1ST_SCALE0,new ShaderPropertyState("_Noise1stScale0")},
                {SHADER_PROPERTY._NOISE1ST_OFFSET1,new ShaderPropertyState("_Noise1stOffset1")},
                {SHADER_PROPERTY._NOISE1ST_SCALE1,new ShaderPropertyState("_Noise1stScale1")},
                {SHADER_PROPERTY._NOISE1ST_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_Noise1stOffsetBeforeScale")},
                {SHADER_PROPERTY._NOISE1ST_SEED,new ShaderPropertyState("_Noise1stSeed")},
                {SHADER_PROPERTY._NOISE1ST_TIME_MULTI,new ShaderPropertyState("_Noise1stTimeMulti")},
                {SHADER_PROPERTY._NOISE1ST_TIME_PHASE,new ShaderPropertyState("_Noise1stTimePhase")},
                {SHADER_PROPERTY._NOISE1ST_PHASE_SCALE,new ShaderPropertyState("_Noise1stPhaseScale")},

                { SHADER_PROPERTY._NOISE2ND_OFFSET0,new ShaderPropertyState("_Noise2ndOffset0")},
                {SHADER_PROPERTY._NOISE2ND_SCALE0,new ShaderPropertyState("_Noise2ndScale0")},
                {SHADER_PROPERTY._NOISE2ND_OFFSET1,new ShaderPropertyState("_Noise2ndOffset1")},
                {SHADER_PROPERTY._NOISE2ND_SCALE1,new ShaderPropertyState("_Noise2ndScale1")},
                {SHADER_PROPERTY._NOISE2ND_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_Noise2ndOffsetBeforeScale")},
                {SHADER_PROPERTY._NOISE2ND_SEED,new ShaderPropertyState("_Noise2ndSeed")},
                {SHADER_PROPERTY._NOISE2ND_TIME_MULTI,new ShaderPropertyState("_Noise2ndTimeMulti")},
                {SHADER_PROPERTY._NOISE2ND_TIME_PHASE,new ShaderPropertyState("_Noise2ndTimePhase")},
                {SHADER_PROPERTY._NOISE2ND_PHASE_SCALE,new ShaderPropertyState("_Noise2ndPhaseScale")},

                {SHADER_PROPERTY._NOISE3RD_OFFSET0,new ShaderPropertyState("_Noise3rdOffset0")},
                {SHADER_PROPERTY._NOISE3RD_SCALE0,new ShaderPropertyState("_Noise3rdScale0")},
                {SHADER_PROPERTY._NOISE3RD_OFFSET1,new ShaderPropertyState("_Noise3rdOffset1")},
                {SHADER_PROPERTY._NOISE3RD_SCALE1,new ShaderPropertyState("_Noise3rdScale1")},
                {SHADER_PROPERTY._NOISE3RD_OFFSET_BEFORE_SCALE,new ShaderPropertyState("_Noise3rdOffsetBeforeScale")},
                {SHADER_PROPERTY._NOISE3RD_SEED,new ShaderPropertyState("_Noise3rdSeed")},
                {SHADER_PROPERTY._NOISE3RD_TIME_MULTI,new ShaderPropertyState("_Noise3rdTimeMulti")},
                {SHADER_PROPERTY._NOISE3RD_TIME_PHASE,new ShaderPropertyState("_Noise3rdTimePhase")},
                {SHADER_PROPERTY._NOISE3RD_PHASE_SCALE,new ShaderPropertyState("_Noise3rdPhaseScale")},
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