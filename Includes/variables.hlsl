fixed3 _LightColor0;

bool _BillboardEnable;
float _Forced_Z_Scale_Zero;
float _DistanceInfluence;
bool _FwidthEnable;
bool _PreviewEnable;
bool _AntiAliasingEnable;

float _DirectionalLightInfluence;
float _AmbientInfluence;
float _LightVolumesInfluence;

float _AudioLinkVUBand;
float _AudioLinkVUSmoothing;
float _AudioLinkVUPanning;
float _AudioLinkVUGainMul;
float _AudioLinkVUGainAdd;
float _AudioLinkChronoTensityDivisor;
uint _AudioLinkChronoTensityMode;
uint _AudioLinkChronoTensityBand;
uint _AudioLinkThemeColorBand;

float _FragmentAudioLinkVUStrength;
float _FragmentAudioLinkChronoTensityStrength;
float _FragmentAudioLinkSpectrumStrength;
bool _FragmentAudioLinkSpectrumMirror;

float _ColoringAudioLinkVUStrength;
float _ColoringAudioLinkChronoTensityStrength;
float _ColoringAudioLinkSpectrumStrength;
bool _ColoringAudioLinkSpectrumMirror;

float _GeometryAudioLinkVUStrength;
float _GeometryAudioLinkChronoTensityStrength;
float _GeometryAudioLinkSpectrumStrength;
bool _GeometryAudioLinkSpectrumMirror;

float _OrbitAudioLinkVUStrength;
float _OrbitAudioLinkChronoTensityStrength;
float _OrbitAudioLinkSpectrumStrength;
bool _OrbitAudioLinkSpectrumMirror;

UNITY_DECLARE_TEX2D_NOSAMPLER(_FragmentAudioLinkMaskMap);
float4 _FragmentAudioLinkMaskMap_ST;
float _FragmentAudioLinkMaskMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_ColoringAudioLinkMaskMap);
float4 _ColoringAudioLinkMaskMap_ST;
float _ColoringAudioLinkMaskMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_GeometryAudioLinkMaskMap);
float4 _GeometryAudioLinkMaskMap_ST;
float _GeometryAudioLinkMaskMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_OrbitAudioLinkMaskMap);
float4 _OrbitAudioLinkMaskMap_ST;
float _OrbitAudioLinkMaskMapStrength;
UNITY_DECLARE_TEX2D_NOSAMPLER(_OrbitRotationOffsetAudioLinkMaskMap);
float4 _OrbitRotationOffsetAudioLinkMaskMap_ST;
float4 _OrbitRotationOffsetAudioLinkMaskMapStrength;



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

float _FragmentTriangleCompression;
float _FragmentFill;
float _FragmentLineWidth;
float _FragmentLineGradientBias;
float _FragmentLineScale;
bool _FragmentManualLineScalingEnable;
uint _FragmentLineAnimationMode;
uint _FragmentPartitionMode;

uint _ColorSource;
fixed4 _Color0;
fixed4 _Color1;
float _Emission;
uint _ColoringPartitionMode;

bool _GeometryScaleEnable;
float2 _GeometryScaleBounds;
bool _GeometryPushPullEnable;
float2 _GeometryPushPullBounds;
float _GeometryPushPullPartitionBias;
bool _GeometryRotationEnable;
float _GeometryRotationStrength;
float _GeometryRotationInvert;
bool _GeometryRotationNoiseRepeat;

uint _GeometryPixelizationSpace;
float4 _GeometryPixelization;

bool _OrbitEnable;
float _OrbitSeed;
float _OrbitPrimitiveRatio;
float3 _OrbitOffset;
float4 _OrbitScale;

float _OrbitRotationSeed;
float3 _OrbitRotationAngle;
float4 _OrbitRotationSpeed;
float3 _OrbitRotationSpread;

float3 _OrbitWaveStrength;
float3 _OrbitWaveFrequency;
float3 _OrbitWavePhase;
float3 _OrbitWaveSpeed;


uint _FragmentSource;
uint _FragmentAudioLinkSource;
float _FragmentFixedValue;
float _FragmentPhaseScale;
uint _FragmentLoopMode;
uint _FragmentEaseMode;
float _FragmentEaseCurve;
float _FragmentMidMul;
float _FragmentMidAdd;


uint _ColoringSource;
uint _ColoringAudioLinkSource;
float _ColoringFixedValue;
float _ColoringPhaseScale;
uint _ColoringLoopMode;
uint _ColoringEaseMode;
float _ColoringEaseCurve;
float _ColoringMidMul;
float _ColoringMidAdd;


uint _GeometrySource;
uint _GeometryAudioLinkSource;
float _GeometryFixedValue;
float _GeometryPhaseScale;
uint _GeometryLoopMode;
uint _GeometryEaseMode;
float _GeometryEaseCurve;
float _GeometryMidMul;
float _GeometryMidAdd;


uint _OrbitSource;
uint _OrbitAudioLinkSource;
float _OrbitFixedValue;
float _OrbitPhaseScale;
uint _OrbitLoopMode;
uint _OrbitEaseMode;
float _OrbitEaseCurve;
float _OrbitMidMul;
float _OrbitMidAdd;


uint _OrbitRotationSource;
uint _OrbitRotationOffsetAudioLinkSource;
float4 _OrbitRotationOffsetAudioLinkVUStrength;
float4 _OrbitRotationOffsetAudioLinkChronoTensityStrength;
float _OrbitRotationFixedValue;

uint _OrbitWaveAudioLinkSource;
float2 _OrbitWaveAudioLinkVUStrength;
float _OrbitWaveAudioLinkChronoTensityStrength;
float2 _OrbitWaveAudioLinkSpectrumStrength;
bool _OrbitWaveAudioLinkSpectrumMirror;
bool _OrbitWaveAudioLinkSpectrumMode;
float2 _OrbitWaveAudioLinkSpectrumBounds;


uint _Noise1stSpace;
bool _Noise1stOffsetBeforeScale;
float3 _Noise1stOffset0;
float3 _Noise1stOffset1;
float4 _Noise1stScale0;
float4 _Noise1stScale1;
float _Noise1stSeed;
float _Noise1stTimeSpeed;
float _Noise1stTimePhase;
float _Noise1stValueScale;

uint _Noise2ndSpace;
bool _Noise2ndOffsetBeforeScale;
float3 _Noise2ndOffset0;
float3 _Noise2ndOffset1;
float4 _Noise2ndScale0;
float4 _Noise2ndScale1;
float _Noise2ndSeed;
float _Noise2ndTimeSpeed;
float _Noise2ndTimePhase;
float _Noise2ndValueScale;

uint _Noise3rdSpace;
bool _Noise3rdOffsetBeforeScale;
float3 _Noise3rdOffset0;
float3 _Noise3rdOffset1;
float4 _Noise3rdScale0;
float4 _Noise3rdScale1;
float _Noise3rdSeed;
float _Noise3rdTimeSpeed;
float _Noise3rdTimePhase;
float _Noise3rdValueScale;

uint _Noise4thSpace;
bool _Noise4thOffsetBeforeScale;
float3 _Noise4thOffset0;
float3 _Noise4thOffset1;
float4 _Noise4thScale0;
float4 _Noise4thScale1;
float _Noise4thSeed;
float _Noise4thTimeSpeed;
float _Noise4thTimePhase;
float _Noise4thValueScale;

uint _Noise5thSpace;
bool _Noise5thOffsetBeforeScale;
float3 _Noise5thOffset0;
float3 _Noise5thOffset1;
float4 _Noise5thScale0;
float4 _Noise5thScale1;
float _Noise5thSeed;
float _Noise5thTimeSpeed;
float _Noise5thTimePhase;
float _Noise5thValueScale;


SamplerState sampler_point_repeat;
SamplerState sampler_linear_repeat;

float4 dummy;
