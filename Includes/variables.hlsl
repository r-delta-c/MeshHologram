fixed3 _LightColor0;
float _AmbientInfluence;
float _DirectionalLightInfluence;
float _LightVolumesInfluence;

float _Forced_Z_Scale_Zero;
float _DistanceInfluence;

#ifdef _USE_AUDIOLINK
    sampler2D _AudioLinkMaskControlTex;
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
    float4 _GeometryMessyOrbitAudioLinkStrength;
#endif

sampler2D _FragmentMaskControlTex;
float4 _FragmentMaskControl_ST;
sampler2D _ColoringMaskControlTex;
float4 _ColoringMaskControl_ST;
sampler2D _GeometryMaskControlTex;
float4 _GeometryMaskControl_ST;
sampler2D _GeometryMessyMaskControlTex;
float4 _GeometryMessyMaskControl_ST;
sampler2D _ColorGradientTex;
float4 _ColorGradientTex_ST;

float _FragmentValue;
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
float _GeometryScale0;
float _GeometryScale1;
float _GeometryExtrude0;
float _GeometryExtrude1;
float _GeometryRotationReverse;

float _GeometryMessyValue;
float _GeometryMessyMaskControl;
float _GeometryMessySeed;

float _GeometryMessyOrbitRotation;
float _GeometryMessyOrbitRotationForward;
float _GeometryMessyOrbitRotationRight;
float4 _GeometryMessyOrbitPosition;
float _GeometryMessyOrbitScaleY;
float _GeometryMessyOrbitScaleZ;
float4 _GeometryMessyOrbitVariance;

float4 _GeometryMessyOrbitRotationPhase;
float4 _GeometryMessyOrbitRotationTimeMultiplier;

float _GeometryMessyOrbitWaveXYStrength;
float _GeometryMessyOrbitWaveXYFrequency;
float _GeometryMessyOrbitWaveXYPhase;
float _GeometryMessyOrbitWaveXYTimeMultiplier;
float _GeometryMessyOrbitWaveZStrength;
float _GeometryMessyOrbitWaveZFrequency;
float _GeometryMessyOrbitWaveZPhase;
float _GeometryMessyOrbitWaveZTimeMultiplier;

float _GeometryPartitionBias;
float4 _Pixelization;

#if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYMESSYSOURCE_NOISE1ST)
    float3 _Noise1stOffset0;
    float3 _Noise1stOffset1;
    float4 _Noise1stScale0;
    float4 _Noise1stScale1;
    float _Noise1stSeed;
    float _Noise1stThresholdMul;
    float _Noise1stThresholdAdd;
    float _Noise1stValueCurve;
    float _Noise1stTimeMulti;
    float _Noise1stTimePhase;
    sampler2D _Noise1stMaskControlTex;
    float4 _Noise1stMaskControl_ST;
    float _Noise1stMaskControl;
    float _Noise1stPhaseScale;
#endif

#if defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYMESSYSOURCE_NOISE2ND)
    float3 _Noise2ndOffset0;
    float3 _Noise2ndOffset1;
    float4 _Noise2ndScale0;
    float4 _Noise2ndScale1;
    float _Noise2ndSeed;
    float _Noise2ndThresholdMul;
    float _Noise2ndThresholdAdd;
    float _Noise2ndValueCurve;
    float _Noise2ndTimeMulti;
    float _Noise2ndTimePhase;
    sampler2D _Noise2ndMaskControlTex;
    float4 _Noise2ndMaskControl_ST;
    float _Noise2ndMaskControl;
    float _Noise2ndPhaseScale;
#endif

#if defined(_FRAGMENTSOURCE_NOISE3RD) || defined(_COLORINGSOURCE_NOISE3RD) || defined(_GEOMETRYSOURCE_NOISE3RD) || defined(_GEOMETRYMESSYSOURCE_NOISE3RD)
    float3 _Noise3rdOffset0;
    float3 _Noise3rdOffset1;
    float4 _Noise3rdScale0;
    float4 _Noise3rdScale1;
    float _Noise3rdSeed;
    float _Noise3rdThresholdMul;
    float _Noise3rdThresholdAdd;
    float _Noise3rdValueCurve;
    float _Noise3rdTimeMulti;
    float _Noise3rdTimePhase;
    sampler2D _Noise3rdMaskControlTex;
    float4 _Noise3rdMaskControl_ST;
    float _Noise3rdMaskControl;
    float _Noise3rdPhaseScale;
#endif

float4 dummy;
