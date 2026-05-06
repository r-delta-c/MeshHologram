Shader "DeltaField/MeshHologram"{
    Properties{
        [DFNumber(0)]_dummy("_dummy",Float)=0
        [DFRenderingMode]_RenderingMode("_RenderingMode",Int)=0
        [DFCull]_Cull("_Cull",Int)=0
        [DFToggle(0)]_ZWrite("_ZWrite",Int)=0
        [DFRange(3000,5000,1,0,0)]_CustomRenderQueueT("_CustomRenderQueueT",Range(3000,5000))=3000
        [DFRange(2001,2499,1,0,0)]_CustomRenderQueueC("_CustomRenderQueueC",Range(2001,2499))=2001
        [DFToggle(0)]_Forced_Z_Scale_Zero("_Forced_Z_Scale_Zero",Int)=0
        [DFRange(0,1,0,0,0)]_BillboardEnable("_BillboardEnable",Range(0,1))=1
        [DFRange(0,1,0,0,0)]_DistanceInfluence("_DistanceInfluence",Range(0,1))=1
        [DFStereoMergeMode]_StereoMergeMode("_StereoMergeMode",Int)=2
        [DFToggle(1)]_FwidthEnable("_FwidthEnable",Int)=1
        [DFRange(0,1,1,0,0)]_DirectionalLightInfluence("_DirectionalLightInfluence",Range(0,1))=1
        [DFRange(0,1,1,0,0)]_AmbientInfluence("_AmbientInfluence",Range(0,1))=1
        [DFRange(0,1,1,0,0)]_LightVolumesInfluence("_LightVolumesInfluence",Range(0,1))=1
        [DFToggle(0)]_PreviewEnable("_PreviewEnable",Int)=0
        [DFToggle(0)]_AntiAliasingEnable("_AntiAliasingEnable",Int)=1
        [DFTexture]_MainTex("_MainTex",2D)="(1.0,1.0,1.0,0.25)" {}
        [DFTextureST(1)]_MainTex_ST("_MainTex_ST",Vector)=(1,1,0,0)
        [DFToggle(0)]_ZClip("_ZClip",Int)=1
        [DFCompare]_ZTest("_ZTest",Int)=4
        [DFColorMask]_ColorMask("_ColorMask",Int)=15
        [DFRange(1,1,0,1,0)]_OffsetFactor("_OffsetFactor",Range(-1,1))=0
        [DFRange(1,1,0,1,0)]_OffsetUnits("_OffsetUnits",Range(-1,1))=0
        [DFToggle(0)]_AlphaToMaskMemory("_AlphaToMaskMemory",Int)=0
        [DFToggle(0)]_AlphaToMask("_AlphaToMask",Int)=0
        [DFBlendOp]_BlendOp("_BlendOp",Int)=0
        [DFBlendMode]_SrcBlend("_SrcBlend",Int)=5
        [DFBlendMode]_DstBlend("_DstBlend",Int)=10
        [DFBlendOp]_BlendOpAlpha("_BlendOpAlpha",Int)=0
        [DFBlendMode]_SrcBlendAlpha("_SrcBlendAlpha",Int)=5
        [DFBlendMode]_DstBlendAlpha("_DstBlendAlpha",Int)=10
        [DFRange(0,255,1,0,0)]_StencilRef("_StencilRef",Range(0,255))=0
        [DFRange(0,255,1,0,0)]_StencilReadMask("_StencilReadMask",Range(0,255))=255
        [DFRange(0,255,1,0,0)]_StencilWriteMask("_StencilWriteMask",Range(0,255))=255
        [DFCompare]_StencilComp("_StencilComp",Int)=0
        [DFStencilOp]_StencilPass("_StencilPass",Int)=0
        [DFStencilOp]_StencilFail("_StencilFail",Int)=0
        [DFStencilOp]_StencilZFail("_StencilZFail",Int)=0
        [DFAudioLinkBand]_AudioLinkThemeColorBand("_AudioLinkThemeColorBand",Int)=0
        [DFNumber(0)]_FragmentTriangleCompression("_FragmentTriangleCompression",Float)=5
        [DFToggle(0)]_FragmentFill("_FragmentFill",Int)=0
        [DFNumber(0)]_FragmentLineWidth("_FragmentLineWidth",Float)=2
        [DFNumber(0)]_FragmentLineGradientBias("_FragmentLineGradientBias",Float)=0
        [DFToggle(0)]_FragmentManualLineScalingEnable("_FragmentManualLineScalingEnable",Int)=0
        [DFNumber(0)]_FragmentLineScale("_FragmentLineScale",Float)=1
        [DFLineAnimationMode]_FragmentLineAnimationMode("_FragmentLineAnimationMode",Int)=0
        [DFPartitionMode]_FragmentPartitionMode("_FragmentPartitionMode",Int)=1
        [DFNumber(0)]_FragmentEdgeBlendWidth("_FragmentEdgeBlendWidth",Float)=8
        [DFSource(1)]_FragmentSource("_FragmentSource",Int)=1
        [DFRange(0,1,0,0,0)]_FragmentFixedValue("_FragmentFixedValue",Range(0,1))=0
        [DFNoiseSpace]_FragmentNoiseSpace("_FragmentNoiseSpace",Int)=1
        [DFVector(1,1,1)]_FragmentNoiseOffset0("_FragmentNoiseOffset0",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_FragmentNoiseScale0("_FragmentNoiseScale0",Vector)=(1,1,1,3)
        [DFVector(1,1,1)]_FragmentNoiseOffset1("_FragmentNoiseOffset1",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_FragmentNoiseScale1("_FragmentNoiseScale1",Vector)=(1,1,1,1)
        [DFToggle(0)]_FragmentNoiseOffsetBeforeScale("_FragmentNoiseOffsetBeforeScale",Int)=0
        [DFNumber(0)]_FragmentNoiseSeed("_FragmentNoiseSeed",Float)=0
        [DFNumber(0)]_FragmentNoiseTimeSpeed("_FragmentNoiseTimeSpeed",Float)=3
        [DFNumber(0)]_FragmentNoiseTimePhase("_FragmentNoiseTimePhase",Float)=0
        [DFNumber(0)]_FragmentNoiseValueScale("_FragmentNoiseValueScale",Float)=1
        [DFTexture]_FragmentLiteNoiseMap("_FragmentLiteNoiseMap",2D)=""{}
        [DFTextureST(1)]_FragmentLiteNoiseMap_ST("_FragmentLiteNoiseMap_ST",Vector)=(0,0,1,1)
        [DFAudioLinkSource(0)]_FragmentAudioLinkSource("_FragmentAudioLinkSource",Int)=0
        [DFAudioLinkBandExpanded]_FragmentAudioLinkVUBand("_FragmentAudioLinkVUBand",Int)=0
        [DFRange(0,15,0,0,0)]_FragmentAudioLinkVUSmoothing("_FragmentAudioLinkVUSmoothing",Range(0,15))=8
        [DFRange(1,0.5,0,0,0)]_FragmentAudioLinkVUPanning("_FragmentAudioLinkVUPanning",Range(1,0.5))=0
        [DFNumber(0)]_FragmentAudioLinkVUStrength("_FragmentAudioLinkVUStrength",Float)=1
        [DFAudioLinkChoronoTensityMode]_FragmentAudioLinkChronoTensityMode("_FragmentAudioLinkChronoTensityMode",Int)=0
        [DFAudioLinkBand]_FragmentAudioLinkChronoTensityBand("_FragmentAudioLinkChronoTensityBand",Int)=0
        [DFNumber(0)]_FragmentAudioLinkChronoTensityStrength("_FragmentAudioLinkChronoTensityStrength",Float)=1
        [DFToggle(0)]_FragmentAudioLinkSpectrumMirror("_FragmentAudioLinkSpectrumMirror",Int)=0
        [DFNumber(0)]_FragmentAudioLinkSpectrumStrength("_FragmentAudioLinkSpectrumStrength",Float)=1
        [DFTexture]_FragmentMaskMap("_FragmentMaskMap",2D)="white"{}
        [DFTextureST(1)]_FragmentMaskMap_ST("_FragmentMaskMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_FragmentMaskMapStrength("_FragmentMaskMapStrength",Range(0,1))=1
        [DFTexture]_FragmentMap("_FragmentMap",2D)="black"{}
        [DFTextureST(1)]_FragmentMap_ST("_FragmentMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_FragmentMapStrength("_FragmentMapStrength",Range(0,1))=1
        [DFTexture]_FragmentAudioLinkMaskMap("_FragmentAudioLinkMaskMap",2D)="white"{}
        [DFTextureST(1)]_FragmentAudioLinkMaskMap_ST("_FragmentAudioLinkMaskMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_FragmentAudioLinkMaskMapStrength("_FragmentAudioLinkMaskMapStrength",Range(0,1))=1
        [DFNumber(0)]_FragmentPhaseScale("_FragmentPhaseScale",Float)=1
        [DFLoopMode]_FragmentLoopMode("_FragmentLoopMode",Int)=0
        [DFEaseMode]_FragmentEaseMode("_FragmentEaseMode",Int)=2
        [DFNumber(0)]_FragmentEaseCurve("_FragmentEaseCurve",Float)=1
        [DFNumber(0)]_FragmentMidMul("_FragmentMidMul",Float)=1
        [DFRange(0.5,0.5,0,1,0)]_FragmentMidAdd("_FragmentMidAdd",Range(-0.5,0.5))=0
        [DFColor]_Color0("_Color0",Color)=(1,1,1,1)
        [DFColor]_Color1("_Color1",Color)=(0.2,0.2,0.2,1)
        [DFNumber(0)]_Emission("_Emission",Float)=0
        [DFColorSource]_ColorSource("_ColorSource",Int)=0
        [DFTexture]_ColorGradientTex("_ColorGradientTex",2D)="white"{}
        [DFTextureST(1)]_ColorGradientTex_ST("_ColorGradientTex_ST",Vector)=(1,1,0,0)
        [DFPartitionMode]_ColoringPartitionMode("_ColoringPartitionMode",Int)=1
        [DFNumber(0)]_ColoringEdgeBlendWidth("_ColoringEdgeBlendWidth",Float)=8
        [DFSource(1)]_ColoringSource("_ColoringSource",Int)=1
        [DFRange(0,1,0,0,0)]_ColoringFixedValue("_ColoringFixedValue",Range(0,1))=0
        [DFNoiseSpace]_ColoringNoiseSpace("_ColoringNoiseSpace",Int)=1
        [DFVector(1,1,1)]_ColoringNoiseOffset0("_ColoringNoiseOffset0",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_ColoringNoiseScale0("_ColoringNoiseScale0",Vector)=(1,1,1,5)
        [DFVector(1,1,1)]_ColoringNoiseOffset1("_ColoringNoiseOffset1",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_ColoringNoiseScale1("_ColoringNoiseScale1",Vector)=(1,1,1,1)
        [DFToggle(0)]_ColoringNoiseOffsetBeforeScale("_ColoringNoiseOffsetBeforeScale",Int)=0
        [DFNumber(0)]_ColoringNoiseSeed("_ColoringNoiseSeed",Float)=1
        [DFNumber(0)]_ColoringNoiseTimeSpeed("_ColoringNoiseTimeSpeed",Float)=5
        [DFNumber(0)]_ColoringNoiseTimePhase("_ColoringNoiseTimePhase",Float)=0
        [DFNumber(0)]_ColoringNoiseValueScale("_ColoringNoiseValueScale",Float)=1
        [DFTexture]_ColoringLiteNoiseMap("_ColoringLiteNoiseMap",2D)=""{}
        [DFTextureST(1)]_ColoringLiteNoiseMap_ST("_ColoringLiteNoiseMap_ST",Vector)=(0,0,1,1)
        [DFAudioLinkSource(0)]_ColoringAudioLinkSource("_ColoringAudioLinkSource",Int)=1
        [DFAudioLinkBandExpanded]_ColoringAudioLinkVUBand("_ColoringAudioLinkVUBand",Int)=0
        [DFRange(0,15,0,0,0)]_ColoringAudioLinkVUSmoothing("_ColoringAudioLinkVUSmoothing",Range(0,15))=8
        [DFRange(0,1,0,0,0)]_ColoringAudioLinkVUPanning("_ColoringAudioLinkVUPanning",Range(0,1))=0.5
        [DFNumber(0)]_ColoringAudioLinkVUStrength("_ColoringAudioLinkVUStrength",Float)=1
        [DFAudioLinkChoronoTensityMode]_ColoringAudioLinkChronoTensityMode("_ColoringAudioLinkChronoTensityMode",Int)=0
        [DFAudioLinkBand]_ColoringAudioLinkChronoTensityBand("_ColoringAudioLinkChronoTensityBand",Int)=0
        [DFNumber(0)]_ColoringAudioLinkChronoTensityStrength("_ColoringAudioLinkChronoTensityStrength",Float)=1
        [DFToggle(0)]_ColoringAudioLinkSpectrumMirror("_ColoringAudioLinkSpectrumMirror",Int)=0
        [DFNumber(0)]_ColoringAudioLinkSpectrumStrength("_ColoringAudioLinkSpectrumStrength",Float)=1
        [DFTexture]_ColoringMaskMap("_ColoringMaskMap",2D)="white"{}
        [DFTextureST(1)]_ColoringMaskMap_ST("_ColoringMaskMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_ColoringMaskMapStrength("_ColoringMaskMapStrength",Range(0,1))=1
        [DFTexture]_ColoringMap("_ColoringMap",2D)="black"{}
        [DFTextureST(1)]_ColoringMap_ST("_ColoringMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_ColoringMapStrength("_ColoringMapStrength",Range(0,1))=1
        [DFTexture]_ColoringAudioLinkMaskMap("_ColoringAudioLinkMaskMap",2D)="white"{}
        [DFTextureST(1)]_ColoringAudioLinkMaskMap_ST("_ColoringAudioLinkMaskMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_ColoringAudioLinkMaskMapStrength("_ColoringAudioLinkMaskMapStrength",Range(0,1))=1
        [DFNumber(0)]_ColoringPhaseScale("_ColoringPhaseScale",Float)=1
        [DFLoopMode]_ColoringLoopMode("_ColoringLoopMode",Int)=2
        [DFEaseMode]_ColoringEaseMode("_ColoringEaseMode",Int)=2
        [DFNumber(0)]_ColoringEaseCurve("_ColoringEaseCurve",Float)=1
        [DFNumber(0)]_ColoringMidMul("_ColoringMidMul",Float)=1
        [DFRange(0.5,0.5,0,1,0)]_ColoringMidAdd("_ColoringMidAdd",Range(-0.5,0.5))=0
        [DFToggle(1)]_GeometryScaleEnable("_GeometryScaleEnable",Int)=0
        [DFVector(1,1)]_GeometryScaleBounds("_GeometryScaleBounds",Vector)=(0.5,0,0,0)
        [DFToggle(1)]_GeometryPushPullEnable("_GeometryPushPullEnable",Int)=1
        [DFVector(1,1)]_GeometryPushPullBounds("_GeometryPushPullBounds",Vector)=(-0.15,0,0,0)
        [DFRange(0,1,0,0,0)]_GeometryPushPullPartitionBias("_GeometryPushPullPartitionBias",Range(0,1))=0.5
        [DFToggle(1)]_GeometryRotationEnable("_GeometryRotationEnable",Int)=0
        [DFRange(0,1,0,0,0)]_GeometryRotationStrength("_GeometryRotationStrength",Range(0,1))=1
        [DFToggle(0)]_GeometryRotationInvert("_GeometryRotationInvert",Int)=0
        [DFToggle(0)]_GeometryRotationNoiseRepeat("_GeometryRotationNoiseRepeat",Int)=0
        [DFPixelizationSpace]_GeometryPixelizationSpace("_GeometryPixelizationSpace",Int)=0
        [DFVector(1,1,1,2)]_GeometryPixelization("_GeometryPixelization",Vector)=(0,0,0,0.02)
        [DFSource(1)]_GeometrySource("_GeometrySource",Int)=1
        [DFRange(0,1,0,0,0)]_GeometryFixedValue("_GeometryFixedValue",Range(0,1))=0
        [DFNoiseSpace]_GeometryNoiseSpace("_GeometryNoiseSpace",Int)=1
        [DFVector(1,1,1)]_GeometryNoiseOffset0("_GeometryNoiseOffset0",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_GeometryNoiseScale0("_GeometryNoiseScale0",Vector)=(1,1,1,5)
        [DFVector(1,1,1)]_GeometryNoiseOffset1("_GeometryNoiseOffset1",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_GeometryNoiseScale1("_GeometryNoiseScale1",Vector)=(1,1,1,1)
        [DFToggle(0)]_GeometryNoiseOffsetBeforeScale("_GeometryNoiseOffsetBeforeScale",Int)=0
        [DFNumber(0)]_GeometryNoiseSeed("_GeometryNoiseSeed",Float)=2
        [DFNumber(0)]_GeometryNoiseTimeSpeed("_GeometryNoiseTimeSpeed",Float)=3
        [DFNumber(0)]_GeometryNoiseTimePhase("_GeometryNoiseTimePhase",Float)=0
        [DFNumber(0)]_GeometryNoiseValueScale("_GeometryNoiseValueScale",Float)=1
        [DFTexture]_GeometryLiteNoiseMap("_GeometryLiteNoiseMap",2D)=""{}
        [DFTextureST(1)]_GeometryLiteNoiseMap_ST("_GeometryLiteNoiseMap_ST",Vector)=(0,0,1,1)
        [DFAudioLinkSource(0)]_GeometryAudioLinkSource("_GeometryAudioLinkSource",Int)=0
        [DFAudioLinkBandExpanded]_GeometryAudioLinkVUBand("_GeometryAudioLinkVUBand",Int)=0
        [DFRange(0,15,0,0,0)]_GeometryAudioLinkVUSmoothing("_GeometryAudioLinkVUSmoothing",Range(0,15))=8
        [DFRange(0,1,0,0,0)]_GeometryAudioLinkVUPanning("_GeometryAudioLinkVUPanning",Range(0,1))=0.5
        [DFNumber(0)]_GeometryAudioLinkVUStrength("_GeometryAudioLinkVUStrength",Float)=1
        [DFAudioLinkChoronoTensityMode]_GeometryAudioLinkChronoTensityMode("_GeometryAudioLinkChronoTensityMode",Int)=0
        [DFAudioLinkBand]_GeometryAudioLinkChronoTensityBand("_GeometryAudioLinkChronoTensityBand",Int)=0
        [DFNumber(0)]_GeometryAudioLinkChronoTensityStrength("_GeometryAudioLinkChronoTensityStrength",Float)=1
        [DFToggle(0)]_GeometryAudioLinkSpectrumMirror("_GeometryAudioLinkSpectrumMirror",Int)=0
        [DFNumber(0)]_GeometryAudioLinkSpectrumStrength("_GeometryAudioLinkSpectrumStrength",Float)=1
        [DFTexture]_GeometryMaskMap("_GeometryMaskMap",2D)="white"{}
        [DFTextureST(1)]_GeometryMaskMap_ST("_GeometryMaskMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_GeometryMaskMapStrength("_GeometryMaskMapStrength",Range(0,1))=1
        [DFTexture]_GeometryMap("_GeometryMap",2D)="black"{}
        [DFTextureST(1)]_GeometryMap_ST("_GeometryMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_GeometryMapStrength("_GeometryMapStrength",Range(0,1))=1
        [DFTexture]_GeometryAudioLinkMaskMap("_GeometryAudioLinkMaskMap",2D)="white"{}
        [DFTextureST(1)]_GeometryAudioLinkMaskMap_ST("_GeometryAudioLinkMaskMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_GeometryAudioLinkMaskMapStrength("_GeometryAudioLinkMaskMapStrength",Range(0,1))=1
        [DFNumber(0)]_GeometryPhaseScale("_GeometryPhaseScale",Float)=1
        [DFLoopMode]_GeometryLoopMode("_GeometryLoopMode",Int)=2
        [DFEaseMode]_GeometryEaseMode("_GeometryEaseMode",Int)=2
        [DFNumber(0)]_GeometryEaseCurve("_GeometryEaseCurve",Float)=1
        [DFNumber(0)]_GeometryMidMul("_GeometryMidMul",Float)=1
        [DFRange(0.5,0.5,0,1,0)]_GeometryMidAdd("_GeometryMidAdd",Range(-0.5,0.5))=0
        [DFToggle(0)]_OrbitEnable("_OrbitEnable",Int)=0
        [DFNumber(0)]_OrbitSeed("_OrbitSeed",Float)=0
        [DFRange(0,1,0,0,0)]_OrbitPrimitiveRatio("_OrbitPrimitiveRatio",Range(0,1))=0.5
        [DFVector(1,1,1)]_OrbitOffset("_OrbitOffset",Vector)=(0,0,0,0)
        [DFVector(0,1,1,2)]_OrbitScale("_OrbitScale",Vector)=(1,1,1,1)
        [DFSource(1)]_OrbitSource("_OrbitSource",Int)=2
        [DFRange(0,1,0,0,0)]_OrbitFixedValue("_OrbitFixedValue",Range(0,1))=0
        [DFNoiseSpace]_OrbitNoiseSpace("_OrbitNoiseSpace",Int)=1
        [DFVector(1,1,1)]_OrbitNoiseOffset0("_OrbitNoiseOffset0",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_OrbitNoiseScale0("_OrbitNoiseScale0",Vector)=(1,1,1,5)
        [DFVector(1,1,1)]_OrbitNoiseOffset1("_OrbitNoiseOffset1",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_OrbitNoiseScale1("_OrbitNoiseScale1",Vector)=(1,1,1,1)
        [DFToggle(0)]_OrbitNoiseOffsetBeforeScale("_OrbitNoiseOffsetBeforeScale",Int)=0
        [DFNumber(0)]_OrbitNoiseSeed("_OrbitNoiseSeed",Float)=3
        [DFNumber(0)]_OrbitNoiseTimeSpeed("_OrbitNoiseTimeSpeed",Float)=3
        [DFNumber(0)]_OrbitNoiseTimePhase("_OrbitNoiseTimePhase",Float)=0
        [DFNumber(0)]_OrbitNoiseValueScale("_OrbitNoiseValueScale",Float)=1
        [DFTexture]_OrbitLiteNoiseMap("_OrbitLiteNoiseMap",2D)=""{}
        [DFTextureST(1)]_OrbitLiteNoiseMap_ST("_OrbitLiteNoiseMap_ST",Vector)=(0,0,1,1)
        [DFAudioLinkSource(0)]_OrbitAudioLinkSource("_OrbitAudioLinkSource",Int)=0
        [DFAudioLinkBandExpanded]_OrbitAudioLinkVUBand("_OrbitAudioLinkVUBand",Int)=0
        [DFRange(0,15,0,0,0)]_OrbitAudioLinkVUSmoothing("_OrbitAudioLinkVUSmoothing",Range(0,15))=8
        [DFRange(0,1,0,0,0)]_OrbitAudioLinkVUPanning("_OrbitAudioLinkVUPanning",Range(0,1))=0.5
        [DFNumber(0)]_OrbitAudioLinkVUStrength("_OrbitAudioLinkVUStrength",Float)=1
        [DFAudioLinkChoronoTensityMode]_OrbitAudioLinkChronoTensityMode("_OrbitAudioLinkChronoTensityMode",Int)=0
        [DFAudioLinkBand]_OrbitAudioLinkChronoTensityBand("_OrbitAudioLinkChronoTensityBand",Int)=0
        [DFNumber(0)]_OrbitAudioLinkChronoTensityStrength("_OrbitAudioLinkChronoTensityStrength",Float)=1
        [DFToggle(0)]_OrbitAudioLinkSpectrumMirror("_OrbitAudioLinkSpectrumMirror",Int)=0
        [DFNumber(0)]_OrbitAudioLinkSpectrumStrength("_OrbitAudioLinkSpectrumStrength",Float)=1
        [DFTexture]_OrbitMaskMap("_OrbitMaskMap",2D)="white"{}
        [DFTextureST(1)]_OrbitMaskMap_ST("_OrbitMaskMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_OrbitMaskMapStrength("_OrbitMaskMapStrength",Range(0,1))=1
        [DFTexture]_OrbitMap("_OrbitMap",2D)="black"{}
        [DFTextureST(1)]_OrbitMap_ST("_OrbitMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_OrbitMapStrength("_OrbitMapStrength",Range(0,1))=1
        [DFTexture]_OrbitAudioLinkMaskMap("_OrbitAudioLinkMaskMap",2D)="white"{}
        [DFTextureST(1)]_OrbitAudioLinkMaskMap_ST("_OrbitAudioLinkMaskMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_OrbitAudioLinkMaskMapStrength("_OrbitAudioLinkMaskMapStrength",Range(0,1))=1
        [DFNumber(0)]_OrbitPhaseScale("_OrbitPhaseScale",Float)=1
        [DFLoopMode]_OrbitLoopMode("_OrbitLoopMode",Int)=0
        [DFEaseMode]_OrbitEaseMode("_OrbitEaseMode",Int)=2
        [DFNumber(0)]_OrbitEaseCurve("_OrbitEaseCurve",Float)=1
        [DFNumber(0)]_OrbitMidMul("_OrbitMidMul",Float)=1
        [DFRange(0.5,0.5,0,1,0)]_OrbitMidAdd("_OrbitMidAdd",Range(-0.5,0.5))=0
        [DFNumber(0)]_OrbitRotationSeed("_OrbitRotationSeed",Float)=1
        [DFVector(1,2,2)]_OrbitRotationAngle("_OrbitRotationAngle",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_OrbitRotationSpeed("_OrbitRotationSpeed",Vector)=(4,0,0,1)
        [DFVector(1,1,1)]_OrbitRotationSpread("_OrbitRotationSpread",Vector)=(1,0,0,0)
        [DFSource(0)]_OrbitRotationSource("_OrbitRotationSource",Int)=2
        [DFRange(0,1,0,0,0)]_OrbitRotationFixedValue("_OrbitRotationFixedValue",Range(0,1))=0
        [DFNoiseSpace]_OrbitRotationNoiseSpace("_OrbitRotationNoiseSpace",Int)=1
        [DFVector(1,1,1)]_OrbitRotationNoiseOffset0("_OrbitRotationNoiseOffset0",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_OrbitRotationNoiseScale0("_OrbitRotationNoiseScale0",Vector)=(1,1,1,5)
        [DFVector(1,1,1)]_OrbitRotationNoiseOffset1("_OrbitRotationNoiseOffset1",Vector)=(0,0,0,0)
        [DFVector(1,1,1,2)]_OrbitRotationNoiseScale1("_OrbitRotationNoiseScale1",Vector)=(1,1,1,1)
        [DFToggle(0)]_OrbitRotationNoiseOffsetBeforeScale("_OrbitRotationNoiseOffsetBeforeScale",Int)=0
        [DFNumber(0)]_OrbitRotationNoiseSeed("_OrbitRotationNoiseSeed",Float)=4
        [DFNumber(0)]_OrbitRotationNoiseTimeSpeed("_OrbitRotationNoiseTimeSpeed",Float)=3
        [DFNumber(0)]_OrbitRotationNoiseTimePhase("_OrbitRotationNoiseTimePhase",Float)=0
        [DFNumber(0)]_OrbitRotationNoiseValueScale("_OrbitRotationNoiseValueScale",Float)=1
        [DFTexture]_OrbitRotationLiteNoiseMap("_OrbitRotationLiteNoiseMap",2D)=""{}
        [DFTextureST(1)]_OrbitRotationLiteNoiseMap_ST("_OrbitRotationLiteNoiseMap_ST",Vector)=(0,0,1,1)
        [DFTexture]_OrbitRotationMaskMap("_OrbitRotationMaskMap",2D)="white"{}
        [DFTextureST(1)]_OrbitRotationMaskMap_ST("_OrbitRotationMaskMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_OrbitRotationMaskMapStrength("_OrbitRotationMaskMapStrength",Range(0,1))=1
        [DFTexture]_OrbitRotationMap("_OrbitRotationMap",2D)="black"{}
        [DFTextureST(1)]_OrbitRotationMap_ST("_OrbitRotationMap_ST",Vector)=(1,1,0,0)
        [DFTextureStrength]_OrbitRotationMapStrength("_OrbitRotationMapStrength",Range(0,1))=1
        [DFVector(1,1)]_OrbitWaveStrength("_OrbitWaveStrength",Vector)=(0,0.1,0,0)
        [DFVector(1,1)]_OrbitWaveFrequency("_OrbitWaveFrequency",Vector)=(5,5,0,0)
        [DFVector(1,1)]_OrbitWavePhase("_OrbitWavePhase",Vector)=(0,0,0,0)
        [DFVector(1,1)]_OrbitWaveSpeed("_OrbitWaveSpeed",Vector)=(1,5,0,0)
        [DFAudioLinkSource(1)]_OrbitWaveAudioLinkSource("_OrbitWaveAudioLinkSource",Int)=0
        [DFAudioLinkBandExpanded]_OrbitWaveAudioLinkVUBand("_OrbitWaveAudioLinkVUBand",Int)=0
        [DFRange(0,15,0,0,0)]_OrbitWaveAudioLinkVUSmoothing("_OrbitWaveAudioLinkVUSmoothing",Range(0,15))=8
        [DFRange(0,1,0,0,0)]_OrbitWaveAudioLinkVUPanning("_OrbitWaveAudioLinkVUPanning",Range(0,1))=0.5
        [DFVector(1,1)]_OrbitWaveAudioLinkVUStrength("_OrbitWaveAudioLinkVUStrength",Vector)=(1,0,0,0)
        [DFAudioLinkChoronoTensityMode]_OrbitWaveAudioLinkChronoTensityMode("_OrbitWaveAudioLinkChronoTensityMode",Int)=0
        [DFAudioLinkBand]_OrbitWaveAudioLinkChronoTensityBand("_OrbitWaveAudioLinkChronoTensityBand",Int)=0
        [DFVector(1,1)]_OrbitWaveAudioLinkChronoTensityStrength("_OrbitWaveAudioLinkChronoTensityStrength",Vector)=(1,1,0,0)
        [DFToggle(0)]_OrbitWaveAudioLinkSpectrumMode("_OrbitWaveAudioLinkSpectrumMode",Int)=0
        [DFToggle(0)]_OrbitWaveAudioLinkSpectrumMirror("_OrbitWaveAudioLinkSpectrumMirror",Int)=0
        [DFVector(1,1)]_OrbitWaveAudioLinkSpectrumBounds("_OrbitWaveAudioLinkSpectrumBounds",Vector)=(0,1,0,0)
        [DFVector(1,1)]_OrbitWaveAudioLinkSpectrumStrength("_OrbitWaveAudioLinkSpectrumStrength",Vector)=(1,0,0,0)
        [DFAudioLinkSource(2)]_OrbitRotationOffsetAudioLinkSource("_OrbitRotationOffsetAudioLinkSource",Int)=0
        [DFAudioLinkBandExpanded]_OrbitRotationOffsetAudioLinkVUBand("_OrbitRotationOffsetAudioLinkVUBand",Int)=0
        [DFRange(0,15,0,0,0)]_OrbitRotationOffsetAudioLinkVUSmoothing("_OrbitRotationOffsetAudioLinkVUSmoothing",Range(0,15))=8
        [DFRange(0,1,0,0,0)]_OrbitRotationOffsetAudioLinkVUPanning("_OrbitRotationOffsetAudioLinkVUPanning",Range(0,1))=0.5
        [DFVector(1,1,1,2)]_OrbitRotationOffsetAudioLinkVUStrength("_OrbitRotationOffsetAudioLinkVUStrength",Vector)=(1,0,0,1)
        [DFAudioLinkChoronoTensityMode]_OrbitRotationOffsetAudioLinkChronoTensityMode("_OrbitRotationOffsetAudioLinkChronoTensityMode",Int)=0
        [DFAudioLinkBand]_OrbitRotationOffsetAudioLinkChronoTensityBand("_OrbitRotationOffsetAudioLinkChronoTensityBand",Int)=0
        [DFVector(1,1,1,2)]_OrbitRotationOffsetAudioLinkChronoTensityStrength("_OrbitRotationOffsetAudioLinkChronoTensityStrength",Vector)=(1,0,0,1)
        [DFTexture]_OrbitRotationOffsetMaskMap("_OrbitRotationOffsetMaskMap",2D)="white"{}
        [DFTextureST(1)]_OrbitRotationOffsetMaskMap_ST("_OrbitRotationOffsetMaskMap_ST",Vector)=(1,1,0,0)
        [DFVector(1,1,1,2)]_OrbitRotationOffsetMaskMapStrength("_OrbitRotationOffsetMaskMapStrength",Vector)=(1,1,1,1)
        [DFTexture]_OrbitRotationOffsetAudioLinkMaskMap("_OrbitRotationOffsetAudioLinkMaskMap",2D)="white"{}
        [DFTextureST(1)]_OrbitRotationOffsetAudioLinkMaskMap_ST("_OrbitRotationOffsetAudioLinkMaskMap_ST",Vector)=(1,1,0,0)
        [DFVector(1,1,1,2)]_OrbitRotationOffsetAudioLinkMaskMapStrength("_OrbitRotationOffsetAudioLinkMaskMapStrength",Vector)=(1,1,1,1)
    }
    SubShader{
        Tags{"Renderpipeline"="UniversalPipeline"}
        Pass{
            Name "ShadowCaster"
            Tags{"RenderType"="Geometry""Queue"="Opaque""LightMode"="ShadowCaster"}
            Cull [_Cull]
            ZWrite On
            ZClip [_ZClip]
            ZTest [_ZTest]
            Stencil{
                Ref [_StencilRef]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilPass]
                Fail [_StencilFail]
                ZFail [_StencilZFail]
            }
            HLSLPROGRAM
            #pragma target 4.0
            #pragma vertex vert
            #pragma fragment frag
            #pragma geometry geom
            #pragma multi_compile_shadowcaster
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #pragma shader_feature_local _ _DIRECTIONALLIGHT_ENABLE
            #pragma shader_feature_local _ _AMBIENT_INFLUENCE_ENABLE
            #pragma shader_feature_local _ _AUDIOLINK_ENABLE
            #pragma shader_feature_local _ _LIGHTVOLUMES_ENABLE
            #pragma shader_feature_local _STEREO_MERGE_MODE_NONE _STEREO_MERGE_MODE_POSITION _STEREO_MERGE_MODE_ROTATION _STEREO_MERGE_MODE_POSITION_ROTATION
            #pragma shader_feature_local _FRAGMENT_NOISE_LITE_MODE_NORMAL _FRAGMENT_NOISE_LITE_MODE_LITE_0 _FRAGMENT_NOISE_LITE_MODE_LITE_1
            #pragma shader_feature_local _COLORING_NOISE_LITE_MODE_NORMAL _COLORING_NOISE_LITE_MODE_LITE_0 _COLORING_NOISE_LITE_MODE_LITE_1
            #pragma shader_feature_local _GEOMETRY_NOISE_LITE_MODE_NORMAL _GEOMETRY_NOISE_LITE_MODE_LITE_0 _GEOMETRY_NOISE_LITE_MODE_LITE_1
            #pragma shader_feature_local _ORBIT_NOISE_LITE_MODE_NORMAL _ORBIT_NOISE_LITE_MODE_LITE_0 _ORBIT_NOISE_LITE_MODE_LITE_1
            #pragma shader_feature_local _ORBIT_ROTATION_NOISE_LITE_MODE_NORMAL _ORBIT_ROTATION_NOISE_LITE_MODE_LITE_0 _ORBIT_ROTATION_NOISE_LITE_MODE_LITE_1

            #define MESHHOLOGRAM_URP

            CBUFFER_START(UnityPerMaterial)
            #include "../Includes/variables.hlsl"
            CBUFFER_END

            #include "../Includes/macro_replace.hlsl"
            #include "../Includes/macro_general.hlsl"
            #include "../Includes/macro_noise.hlsl"
            #include "../Includes/macro_uv.hlsl"
            #include "../Includes/macro_geom.hlsl"
            #include "../Includes/Thirdparties/AudioLink.cginc"
            #include "../Includes/Thirdparties/LightVolumes.cginc"
            #include "../Includes/Thirdparties/DeltaField-Shader-Commons.hlsl"
            #include "../Includes/functions_common.hlsl"
            #include "../Includes/functions_thirdparties.hlsl"
            #include "../Includes/functions_noise.hlsl"
            #include "../Includes/structs.hlsl"
            #include "../Includes/functions_vert.hlsl"
            #include "../Includes/functions_geom.hlsl"
            #include "../Includes/functions_frag_depth_write.hlsl"
            ENDHLSL
        }
        Pass{
            Name "MainRender"
            Tags{"RenderType"="Transparent""Queue"="Transparent""LightMode"="UniversalForward"}
            Cull [_Cull]
            ZWrite [_ZWrite]
            BlendOp [_BlendOp], [_BlendOpAlpha]
            Blend [_SrcBlend] [_DstBlend], [_SrcBlendAlpha] [_DstBlendAlpha]
            ZClip [_ZClip]
            ZTest [_ZTest]
            ColorMask [_ColorMask]
            Offset [_OffsetFactor], [_OffsetUnits]
            AlphaToMask [_AlphaToMask]
            Stencil{
                Ref [_StencilRef]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilPass]
                Fail [_StencilFail]
                ZFail [_StencilZFail]
            }
            HLSLPROGRAM
            #pragma target 4.0
            #pragma vertex vert
            #pragma fragment frag
            #pragma geometry geom
            #pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #pragma shader_feature_local _ _DIRECTIONALLIGHT_ENABLE
            #pragma shader_feature_local _ _AMBIENT_INFLUENCE_ENABLE
            #pragma shader_feature_local _ _AUDIOLINK_ENABLE
            #pragma shader_feature_local _ _LIGHTVOLUMES_ENABLE
            #pragma shader_feature_local _STEREO_MERGE_MODE_NONE _STEREO_MERGE_MODE_POSITION _STEREO_MERGE_MODE_ROTATION _STEREO_MERGE_MODE_POSITION_ROTATION
            #pragma shader_feature_local _FRAGMENT_NOISE_LITE_MODE_NORMAL _FRAGMENT_NOISE_LITE_MODE_LITE_0 _FRAGMENT_NOISE_LITE_MODE_LITE_1
            #pragma shader_feature_local _COLORING_NOISE_LITE_MODE_NORMAL _COLORING_NOISE_LITE_MODE_LITE_0 _COLORING_NOISE_LITE_MODE_LITE_1
            #pragma shader_feature_local _GEOMETRY_NOISE_LITE_MODE_NORMAL _GEOMETRY_NOISE_LITE_MODE_LITE_0 _GEOMETRY_NOISE_LITE_MODE_LITE_1
            #pragma shader_feature_local _ORBIT_NOISE_LITE_MODE_NORMAL _ORBIT_NOISE_LITE_MODE_LITE_0 _ORBIT_NOISE_LITE_MODE_LITE_1
            #pragma shader_feature_local _ORBIT_ROTATION_NOISE_LITE_MODE_NORMAL _ORBIT_ROTATION_NOISE_LITE_MODE_LITE_0 _ORBIT_ROTATION_NOISE_LITE_MODE_LITE_1

            #define MESHHOLOGRAM_URP

            CBUFFER_START(UnityPerMaterial)
            #include "../Includes/variables.hlsl"
            CBUFFER_END

            #include "../Includes/macro_replace.hlsl"
            #include "../Includes/macro_general.hlsl"
            #include "../Includes/macro_noise.hlsl"
            #include "../Includes/macro_uv.hlsl"
            #include "../Includes/macro_geom.hlsl"
            #include "../Includes/Thirdparties/AudioLink.cginc"
            #include "../Includes/Thirdparties/LightVolumes.cginc"
            #include "../Includes/Thirdparties/DeltaField-Shader-Commons.hlsl"
            #include "../Includes/functions_common.hlsl"
            #include "../Includes/functions_thirdparties.hlsl"
            #include "../Includes/functions_noise.hlsl"
            #include "../Includes/structs.hlsl"
            #include "../Includes/functions_vert.hlsl"
            #include "../Includes/functions_geom.hlsl"
            half4 frag(g2f i) : SV_Target{
                #include "../Includes/functions_frag.hlsl"
                #include "../Includes/functions_frag_mesh.hlsl"
            }
            ENDHLSL
        }
    }
    Fallback "Mobile/Particle/Alpha Blended"
    CustomEditor "DeltaField.Shaders.MeshHologram.Editor.MeshHologramInspector"
}
