fixed3 _LightColor0;
float _AmbientInfluence;
float _DirectionalLightInfluence;
float _LightVolumesInfluence;

float _Forced_Z_Scale_Zero;
float _DistanceInfluence;

#ifdef _USE_AUDIOLINK
    UNITY_DECLARE_TEX2D_NOSAMPLER(_AudioLinkMaskControlTex);
    float4 _AudioLinkMaskControl_ST;
    float _AudioLinkMaskControl;
    float _AudioLinkVUBand;
    float _AudioLinkVUSmooth;
    float _AudioLinkVUPanning;
    float _AudioLinkVUGainMul;
    float _AudioLinkVUGainAdd;
    float _AudioLinkChronoTensityScale;
    uint _AudioLinkChronoTensityType;
    uint _AudioLinkChronoTensityBand;
    uint _AudioLinkThemeColorBand;

    float4 _OrbitRotationAudioLinkStrength;
    float4 _OrbitWaveAudioLinkStrength;
    bool _OrbitWaveAudioLinkSpectrumMirror;
    bool _OrbitWaveAudioLinkSpectrumType;
    float2 _OrbitWaveAudioLinkSpectrumRange;
#endif

UNITY_DECLARE_TEX2D_NOSAMPLER(_FragmentMaskControlTex);
float4 _FragmentMaskControl_ST;
UNITY_DECLARE_TEX2D_NOSAMPLER(_ColoringMaskControlTex);
float4 _ColoringMaskControl_ST;
UNITY_DECLARE_TEX2D_NOSAMPLER(_GeometryMaskControlTex);
float4 _GeometryMaskControl_ST;
UNITY_DECLARE_TEX2D_NOSAMPLER(_OrbitMaskControlTex);
float4 _OrbitMaskControl_ST;
UNITY_DECLARE_TEX2D_NOSAMPLER(_ColorGradientTex);
float4 _ColorGradientTex_ST;

float _FragmentValue;
bool _FragmentInverse;
float _FragmentMaskControl;
float _TriangleComp;
float _Fill;
float _LineWidth;
float _LineGradientBias;
float _LineScale;

float _ColoringValue;
float _ColoringMaskControl;
fixed4 _Color0;
fixed4 _Color1;
float _Emission;

float _GeometryValue;
float _GeometryMaskControl;
float2 _GeometryScaleRange;
float2 _GeometryExtrudeRange;
float _GeometryRotationReverse;

float _GeometryPartitionBias;
float4 _Pixelization;

float _OrbitValue;
float _OrbitSeed;
float _OrbitMaskControl;

float _OrbitRotationValue;
float _OrbitRotationSeed;
float3 _OrbitRotation;
float4 _OrbitRotationTimeMultiplier;

float3 _OrbitRotationVariance;

float3 _OrbitOffset;
float3 _OrbitScale;

float _OrbitWaveXYStrength;
float _OrbitWaveXYFrequency;
float _OrbitWaveXYPhase;
float _OrbitWaveXYTimeMultiplier;
float _OrbitWaveZStrength;
float _OrbitWaveZFrequency;
float _OrbitWaveZPhase;
float _OrbitWaveZTimeMultiplier;


float _FragmentAudioLinkStrength;
bool _FragmentAudioLinkSpectrumMirror;
bool _FragmentAudioLinkSpectrumType;
float2 _FragmentAudioLinkSpectrumRange;

float _ColoringAudioLinkStrength;
bool _ColoringAudioLinkSpectrumMirror;
bool _ColoringAudioLinkSpectrumType;
float2 _ColoringAudioLinkSpectrumRange;

float _GeometryAudioLinkStrength;
bool _GeometryAudioLinkSpectrumMirror;
bool _GeometryAudioLinkSpectrumType;
float2 _GeometryAudioLinkSpectrumRange;

#if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_ORBITSOURCE_NOISE1ST) || defined(_ORBITROTATIONSOURCE_NOISE1ST)
    float3 _Noise1stOffset0;
    float3 _Noise1stOffset1;
    float4 _Noise1stScale0;
    float4 _Noise1stScale1;
    float _Noise1stSeed;
    float _Noise1stThresholdMul;
    float _Noise1stThresholdAdd;
    float _Noise1stValueCurve;
    float _Noise1stCurveType;
    float _Noise1stTimeMulti;
    float _Noise1stTimePhase;
    UNITY_DECLARE_TEX2D_NOSAMPLER(_Noise1stOffsetControlTex);
    float4 _Noise1stOffsetControl_ST;
    float _Noise1stOffsetControl;
    float _Noise1stPhaseScale;
#endif

#if defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_ORBITSOURCE_NOISE2ND) || defined(_ORBITROTATIONSOURCE_NOISE2ND)
    float3 _Noise2ndOffset0;
    float3 _Noise2ndOffset1;
    float4 _Noise2ndScale0;
    float4 _Noise2ndScale1;
    float _Noise2ndSeed;
    float _Noise2ndThresholdMul;
    float _Noise2ndThresholdAdd;
    float _Noise2ndValueCurve;
    float _Noise2ndCurveType;
    float _Noise2ndTimeMulti;
    float _Noise2ndTimePhase;
    UNITY_DECLARE_TEX2D_NOSAMPLER(_Noise2ndOffsetControlTex);
    float4 _Noise2ndOffsetControl_ST;
    float _Noise2ndOffsetControl;
    float _Noise2ndPhaseScale;
#endif

#if defined(_FRAGMENTSOURCE_NOISE3RD) || defined(_COLORINGSOURCE_NOISE3RD) || defined(_GEOMETRYSOURCE_NOISE3RD) || defined(_ORBITSOURCE_NOISE3RD) || defined(_ORBITROTATIONSOURCE_NOISE3RD)
    float3 _Noise3rdOffset0;
    float3 _Noise3rdOffset1;
    float4 _Noise3rdScale0;
    float4 _Noise3rdScale1;
    float _Noise3rdSeed;
    float _Noise3rdThresholdMul;
    float _Noise3rdThresholdAdd;
    float _Noise3rdValueCurve;
    float _Noise3rdCurveType;
    float _Noise3rdTimeMulti;
    float _Noise3rdTimePhase;
    UNITY_DECLARE_TEX2D_NOSAMPLER(_Noise3rdOffsetControlTex);
    float4 _Noise3rdOffsetControl_ST;
    float _Noise3rdOffsetControl;
    float _Noise3rdPhaseScale;
#endif

SamplerState sampler_point_clamp;
SamplerState sampler_linear_repeat;

float4 dummy;
