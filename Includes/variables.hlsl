fixed3 _LightColor0;
uint _RenderingMode;
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


int _FragmentSource;
uint _FragmentAudioLinkSource;
float _FragmentFixedValue;
float _FragmentPhaseScale;
int _FragmentLoopMode;
uint _FragmentEaseMode;
float _FragmentEaseCurve;
float _FragmentMidMul;
float _FragmentMidAdd;


int _ColoringSource;
uint _ColoringAudioLinkSource;
float _ColoringFixedValue;
float _ColoringPhaseScale;
int _ColoringLoopMode;
uint _ColoringEaseMode;
float _ColoringEaseCurve;
float _ColoringMidMul;
float _ColoringMidAdd;


int _GeometrySource;
uint _GeometryAudioLinkSource;
float _GeometryFixedValue;
float _GeometryPhaseScale;
int _GeometryLoopMode;
uint _GeometryEaseMode;
float _GeometryEaseCurve;
float _GeometryMidMul;
float _GeometryMidAdd;


int _OrbitSource;
uint _OrbitAudioLinkSource;
float _OrbitFixedValue;
float _OrbitPhaseScale;
int _OrbitLoopMode;
uint _OrbitEaseMode;
float _OrbitEaseCurve;
float _OrbitMidMul;
float _OrbitMidAdd;


int _OrbitRotationSource;
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


uint _FragmentNoiseSpace;
bool _FragmentNoiseOffsetBeforeScale;
float3 _FragmentNoiseOffset0;
float3 _FragmentNoiseOffset1;
float4 _FragmentNoiseScale0;
float4 _FragmentNoiseScale1;
float _FragmentNoiseSeed;
float _FragmentNoiseTimeSpeed;
float _FragmentNoiseTimePhase;
float _FragmentNoiseValueScale;

uint _ColoringNoiseSpace;
bool _ColoringNoiseOffsetBeforeScale;
float3 _ColoringNoiseOffset0;
float3 _ColoringNoiseOffset1;
float4 _ColoringNoiseScale0;
float4 _ColoringNoiseScale1;
float _ColoringNoiseSeed;
float _ColoringNoiseTimeSpeed;
float _ColoringNoiseTimePhase;
float _ColoringNoiseValueScale;

uint _GeometryNoiseSpace;
bool _GeometryNoiseOffsetBeforeScale;
float3 _GeometryNoiseOffset0;
float3 _GeometryNoiseOffset1;
float4 _GeometryNoiseScale0;
float4 _GeometryNoiseScale1;
float _GeometryNoiseSeed;
float _GeometryNoiseTimeSpeed;
float _GeometryNoiseTimePhase;
float _GeometryNoiseValueScale;

uint _OrbitNoiseSpace;
bool _OrbitNoiseOffsetBeforeScale;
float3 _OrbitNoiseOffset0;
float3 _OrbitNoiseOffset1;
float4 _OrbitNoiseScale0;
float4 _OrbitNoiseScale1;
float _OrbitNoiseSeed;
float _OrbitNoiseTimeSpeed;
float _OrbitNoiseTimePhase;
float _OrbitNoiseValueScale;

uint _OrbitRotationNoiseSpace;
bool _OrbitRotationNoiseOffsetBeforeScale;
float3 _OrbitRotationNoiseOffset0;
float3 _OrbitRotationNoiseOffset1;
float4 _OrbitRotationNoiseScale0;
float4 _OrbitRotationNoiseScale1;
float _OrbitRotationNoiseSeed;
float _OrbitRotationNoiseTimeSpeed;
float _OrbitRotationNoiseTimePhase;
float _OrbitRotationNoiseValueScale;


SamplerState sampler_point_repeat;
SamplerState sampler_linear_repeat;

float4 dummy;
