fixed3 _LightColor0;
float _AmbientInfluence;
float _DirectionalLightInfluence;
float _LightVolumesInfluence;

float _Forced_Z_Scale_Zero;
float _DistanceInfluence;

#ifdef _USE_AUDIOLINK
    UNITY_DECLARE_TEX2D_NOSAMPLER(_AudioLinkMaskMap);
    float _AudioLinkVUBand;
    float _AudioLinkVUSmooth;
    float _AudioLinkVUPanning;
    float _AudioLinkVUGainMul;
    float _AudioLinkVUGainAdd;
    float _AudioLinkChronoTensityScale;
    uint _AudioLinkChronoTensityType;
    uint _AudioLinkChronoTensityBand;
    uint _AudioLinkThemeColorBand;

    bool _AudioLinkSpectrumMirror;
    bool _AudioLinkSpectrumType;

    float _FragmentAudioLinkVUStrength;
    float _FragmentAudioLinkChronoTensityStrength;
    float _FragmentAudioLinkSpectrumStrength;
    bool _FragmentAudioLinkSpectrumMirror;
    bool _FragmentAudioLinkSpectrumType;

    float _ColoringAudioLinkVUStrength;
    float _ColoringAudioLinkChronoTensityStrength;
    float _ColoringAudioLinkSpectrumStrength;
    bool _ColoringAudioLinkSpectrumMirror;
    bool _ColoringAudioLinkSpectrumType;

    float _GeometryAudioLinkVUStrength;
    float _GeometryAudioLinkChronoTensityStrength;
    float _GeometryAudioLinkSpectrumStrength;
    bool _GeometryAudioLinkSpectrumMirror;
    bool _GeometryAudioLinkSpectrumType;

    float _OrbitAudioLinkVUStrength;
    float _OrbitAudioLinkChronoTensityStrength;
    float _OrbitAudioLinkSpectrumStrength;
    bool _OrbitAudioLinkSpectrumMirror;
    bool _OrbitAudioLinkSpectrumType;

    float4 _OrbitRotationAudioLinkStrength;
    float4 _OrbitWaveAudioLinkStrength;

    UNITY_DECLARE_TEX2D_NOSAMPLER(_FragmentALMaskMap);
    float4 _FragmentALMaskMap_ST;
    float _FragmentALMaskMapStrength;
    UNITY_DECLARE_TEX2D_NOSAMPLER(_ColoringALMaskMap);
    float4 _ColoringALMaskMap_ST;
    float _ColoringALMaskMapStrength;
    UNITY_DECLARE_TEX2D_NOSAMPLER(_GeometryALMaskMap);
    float4 _GeometryALMaskMap_ST;
    float _GeometryALMaskMapStrength;
    UNITY_DECLARE_TEX2D_NOSAMPLER(_OrbitALMaskMap);
    float4 _OrbitALMaskMap_ST;
    float _OrbitALMaskMapStrength;
    UNITY_DECLARE_TEX2D_NOSAMPLER(_OrbitRotationOffsetALMaskMap);
    float4 _OrbitRotationOffsetALMaskMap_ST;
    float4 _OrbitRotationOffsetALMaskMapStrength;

#endif

UNITY_DECLARE_TEX2D_NOSAMPLER(_FragmentMaskMap);
float4 _FragmentMaskMap_ST;
float _FragmentMaskMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_ColoringMaskMap);
float4 _ColoringMaskMap_ST;
float _ColoringMaskMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_GeometryMaskMap);
float4 _GeometryMaskMap_ST;
float _GeometryMaskMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_OrbitMaskMap);
float4 _OrbitMaskMap_ST;
float _OrbitMaskMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_OrbitRotationMaskMap);
float4 _OrbitRotationMaskMap_ST;
float _OrbitRotationMaskMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_OrbitRotationOffsetMaskMap);
float4 _OrbitRotationOffsetMaskMap_ST;
float4 _OrbitRotationOffsetMaskMapStrength;

UNITY_DECLARE_TEX2D_NOSAMPLER(_FragmentMap);
float4 _FragmentMap_ST;
float _FragmentMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_ColoringMap);
float4 _ColoringMap_ST;
float _ColoringMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_GeometryMap);
float4 _GeometryMap_ST;
float _GeometryMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_OrbitMap);
float4 _OrbitMap_ST;
float _OrbitMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_OrbitRotationMap);
float4 _OrbitRotationMap_ST;
float _OrbitRotationMapStrength;



UNITY_DECLARE_TEX2D_NOSAMPLER(_ColorGradientTex);
float4 _ColorGradientTex_ST;

bool _FragmentInverse;
float _TriangleComp;
float _Fill;
float _LineWidth;
float _LineGradientBias;
float _LineScale;

fixed4 _Color0;
fixed4 _Color1;
float _Emission;

float2 _GeometryScaleRange;
float2 _GeometryExtrudeRange;
float _GeometryRotationInfluence;
float _GeometryRotationReverse;
bool _GeometryRotationNoiseRepeat;


uint _FragmentSource;
uint _FragmentAudioLinkSource;
float _FragmentValue;
float _FragmentPhaseScale;
float _FragmentThresholdMul;
float _FragmentThresholdAdd;
uint _FragmentLoopMode;
uint _FragmentEaseMode;
float _FragmentEaseCurve;


uint _ColoringSource;
uint _ColoringAudioLinkSource;
float _ColoringValue;
float _ColoringPhaseScale;
float _ColoringThresholdMul;
float _ColoringThresholdAdd;
uint _ColoringLoopMode;
uint _ColoringEaseMode;
float _ColoringEaseCurve;


uint _GeometrySource;
uint _GeometryAudioLinkSource;
float _GeometryValue;
float _GeometryPhaseScale;
float _GeometryThresholdMul;
float _GeometryThresholdAdd;
uint _GeometryLoopMode;
uint _GeometryEaseMode;
float _GeometryEaseCurve;


uint _OrbitSource;
uint _OrbitAudioLinkSource;
float _OrbitValue;
float _OrbitPhaseScale;
float _OrbitThresholdMul;
float _OrbitThresholdAdd;
uint _OrbitLoopMode;
uint _OrbitEaseMode;
float _OrbitEaseCurve;


uint _OrbitRotationSource;
uint _OrbitRotationOffsetSource;
uint _OrbitRotationOffsetAudioLinkSource;
float4 _OrbitRotationOffsetAudioLinkVUStrength;
float4 _OrbitRotationOffsetAudioLinkChronoTensityStrength;
float _OrbitRotationValue;
float _OrbitRotationPhaseScale;
float _OrbitRotationThresholdMul;
float _OrbitRotationThresholdAdd;
uint _OrbitRotationLoopMode;
uint _OrbitRotationEaseMode;
float _OrbitRotationEaseCurve;

uint _OrbitWaveAudioLinkSource;
float2 _OrbitWaveAudioLinkVUStrength;
float _OrbitWaveAudioLinkChronoTensityStrength;
float2 _OrbitWaveAudioLinkSpectrumStrength;
bool _OrbitWaveAudioLinkSpectrumMirror;
bool _OrbitWaveAudioLinkSpectrumType;
float2 _OrbitWaveAudioLinkSpectrumRange;

float _GeometryPartitionBias;
float4 _Pixelization;

float _OrbitSeed;
float _OrbitPrimitiveThreshold;

float _OrbitRotationSeed;
float3 _OrbitRotation;
float4 _OrbitRotationTimeMultiplier;

float3 _OrbitRotationVariance;

float3 _OrbitOffset;
float4 _OrbitScale;

float3 _OrbitWaveStrength;
float3 _OrbitWaveFrequency;
float3 _OrbitWavePhase;
float3 _OrbitWaveTimeMultiplier;


float3 _Noise1stOffset0;
float3 _Noise1stOffset1;
float4 _Noise1stScale0;
float4 _Noise1stScale1;
float _Noise1stSeed;
float _Noise1stTimeMulti;
float _Noise1stTimePhase;
float _Noise1stPhaseScale;


float3 _Noise2ndOffset0;
float3 _Noise2ndOffset1;
float4 _Noise2ndScale0;
float4 _Noise2ndScale1;
float _Noise2ndSeed;
float _Noise2ndTimeMulti;
float _Noise2ndTimePhase;
float _Noise2ndPhaseScale;



float3 _Noise3rdOffset0;
float3 _Noise3rdOffset1;
float4 _Noise3rdScale0;
float4 _Noise3rdScale1;
float _Noise3rdSeed;
float _Noise3rdTimeMulti;
float _Noise3rdTimePhase;
float _Noise3rdPhaseScale;


SamplerState sampler_point_repeat;
SamplerState sampler_linear_repeat;

float4 dummy;
