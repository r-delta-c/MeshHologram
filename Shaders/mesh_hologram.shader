Shader "DeltaField/shaders/MeshHologram"{
    Properties{
        [KeywordEnum(Transparent,Cutout,DepthOnly)]
        _RenderingMode("Rendering Mode",Int)=0
        [Enum(UnityEngine.Rendering.CullMode)]
        _Cull("Culling Mode",Int)=0
        [KeywordEnum(Off,On)]
        _ZWrite("Z Write",Int)=0

        [IntRange]_CustomRenderQueueT("Transparent Render Queue",Range(3000,5000))=3000
        [IntRange]_CustomRenderQueueC("Cutout Render Queue",Range(2001,2499))=2001

        [MaterialToggle]_Forced_Z_Scale_Zero("Forced Z Scale Zero",Float)=1.0
        [Toggle(_BILLBOARD_MODE)]
        _BillboardMode("Billboard Mode",Int)=0
        _DistanceInfluence("Distance Influence",Range(0.0,1.0))=1.0
        [KeywordEnum(None,Position,Rotation,Position_Rotation)]
        _StereoMergeMode("Stereo Merge Mode",Int)=2
        [Toggle(_USE_FWIDTH)]
        _UseFwidth("Use fwidth()",Int)=1

        [DFToggle(_ACTIVATE_DIRECTIONALLIGHT_INFLUENCE,1)]
        _ActivateDirectionalLightInfluence("Activate Directional Light Influence",Int)=0
        _DirectionalLightInfluence("Directional Light Influence",Range(0.0,1.0))=1.0
        [DFToggle(_ACTIVATE_AMBIENT_INFLUENCE,1)]
        _ActivateAmbientInfluence("Activate Ambient Influence",Int)=0.0
        _AmbientInfluence("Ambient Influence",Range(0.0,1.0))=1.0
        [DFToggle(_ACTIVATE_LIGHTVOLUMES,1)]
        _ActivateLightVolumesInfluence("Activate LightVolumes",Int)=0.0
        _LightVolumesInfluence("LightVolumes Influence",Range(0.0,1.0))=1.0

        [Toggle(_PREVIEW_MODE)]
        _PreviewMode("Preview Mode",Int)=0
        [Toggle(_ANTI_ALIASING)]
        _AntiAliasing("Anti Aliasing",Int)=0

        _MainTex("Fallback Texture",2D)="(1.0,1.0,1.0,0.25)" {}


        [MaterialToggle]_ZClip("Z Clip",Int)=1
        [Enum(UnityEngine.Rendering.CompareFunction)]_ZTest("Z Test",Int)=4
        [DFColorMask]_ColorMask("Color Mask",Int)=15
        _OffsetFactor("Offset Factor",Range(-1.0,1.0))=0.0
        _OffsetUnits("Offset Factor",Range(-1.0,1.0))=0.0
        _AlphaToMask("Alpha To Mask",Int)=0
        [MaterialToggle]_AlphaToMaskMemory("Alpha To Mask",Int)=0

        [Enum(UnityEngine.Rendering.BlendOp)]_BlendOp("Blend Operation", Int)=0
        [Enum(UnityEngine.Rendering.BlendMode)]_SrcBlend("Blend Mode Source", Int)=5
        [Enum(UnityEngine.Rendering.BlendMode)]_DstBlend("Blend Mode Destination", Int)=10

        [Enum(UnityEngine.Rendering.BlendOp)]_BlendOpAlpha("Alpha Blend Operation", Int)=0
        [Enum(UnityEngine.Rendering.BlendMode)]_SrcBlendAlpha("Alpha Blend Mode Source", Int)=5
        [Enum(UnityEngine.Rendering.BlendMode)]_DstBlendAlpha("Alpha Blend Mode Destination", Int)=10


        [IntRange]_StencilRef("Stencil Ref",Range(0,255))=0
        [IntRange]_StencilReadMask("Stencil Read Mask",Range(0,255))=255
        [IntRange]_StencilWriteMask("Stencil Write Mask",Range(0,255))=255
        [Enum(UnityEngine.Rendering.CompareFunction)]_StencilComp("Stencil Comp",Int)=8
        [Enum(UnityEngine.Rendering.StencilOp)]_StencilPass("Stencil Pass",Int)=0
        [Enum(UnityEngine.Rendering.StencilOp)]_StencilFail("Stencil Fail",Int)=0
        [Enum(UnityEngine.Rendering.StencilOp)]_StencilZFail("Stencil ZFail",Int)=0


        [DFToggle(_USE_AUDIOLINK,1)]
        _UseAudioLink("Use AudioLink", Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3,Average,4)]
        _AudioLinkVUBand("VU Band",Int)=0
        [IntRange]_AudioLinkVUSmooth("VU Smooth",Range(0,15))=8
        _AudioLinkVUPanning("VU Panning",Range(0.0,1.0))=0.5
        _AudioLinkVUGainMul("VU Gain(Mul)",Float)=1.0
        _AudioLinkVUGainAdd("VU Gain(Add)",Range(0.0,1.0))=0.0
        [PowerSlider(5)]_AudioLinkChronoTensityScale("Chrono Tensity Scale",Range(20000,1000000))=100000
        [Enum(Nudging,0,Nudging_Smooth,1,Dynamics,2,Dynamics_Smooth,3,Hold,4,Hold_Smooth,5)]
        _AudioLinkChronoTensityType("Chrono Tensity Type",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3)]
        _AudioLinkChronoTensityBand("Chrono Tensity Band",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3)]
        _AudioLinkThemeColorBand("Theme Color Band",Int)=0

        _AudioLinkSpectrumMirror("AudioLink Spectrum Mirror",Int)=0
        _AudioLinkSpectrumType("AudioLink Spectrum Type",Int)=0

        _TriangleComp("Triangle Compression",Float)=5.0
        [MaterialToggle]_Fill("Fill",Float)=0.0
        _LineWidth("Line Width",Float)=2.0
        _LineGradientBias("Line Gradient Bias",Range(-1.0,1.0))=0.0
        [Toggle(_MANUAL_LINE_SCALING)]
        _ManualLineScaling("Manual Line Scaling",Int)=0.0
        _LineScale("Line Scale",Float)=1.0
        [KeywordEnum(Normal,Instant,ZoomIn,ZoomOut,PowerZoomIn,Collapse,Break,OutWide,OutThin,Vanishing,Join1,Join2,Join3)]
        _LineFadeMode("Line Fade Mode",Int)=0
        [MaterialToggle]_FragmentInverse("Fragment Inverse",Int)=0
        [KeywordEnum(Vertex,Side,Mesh)]
        _FragmentPartitionType("Partition Type",Int)=1


        _Color0("Primary Color",Color)=(1.0,1.0,1.0,1.0)
        _Color1("Secondary Color",Color)=(0.2,0.2,0.2,1.0)
        _Emission("Add Emission",Float)=0.0
        [KeywordEnum(Gradient,Primary,GradientTex,VertexColor,UniqueSides,AudioLink_ThemeColor)]
        _ColorSource("Color Source",Int)=0
        _ColorGradientTex("Gradient Tex",2D)="white"{}
        [KeywordEnum(Vertex,Side,Mesh)]
        _ColoringPartitionType("Coloring Partition Type",Int)=1


        [DFToggle(_GEOMETRY_SCALE,1)]
        _GeometryScale("Activate Scale",Int)=0
        [DFVector(1,1)]_GeometryScaleRange("Scale Range",Vector)=(0.5,0.0,0.0,0.0)

        [DFToggle(_GEOMETRY_EXTRUDE,1)]
        _GeometryExtrude("Activate Extrude",Int)=1
        [DFVector(1,1)]_GeometryExtrudeRange("Extrude Range",Vector)=(-0.15,0.0,0.0,0.0)
        _GeometryPartitionBias("Geometry Partition Bias| Vertex <=> Center",Range(0.0,1.0))=0.5

        [DFToggle(_GEOMETRY_ROTATION,1)]
        _GeometryRotation("Activate Rotation",Int)=0
        _GeometryRotationInfluence("Rotation Influence",Range(0.0,1.0))=1.0
        [MaterialToggle(_GEOMETRY_ROTATION_REVERSE)]
        _GeometryRotationReverse("Rotation Reverse",Int)=0
        [MaterialToggle(_GEOMETRY_ROTATION_NOISE_REPEAT)]
        _GeometryRotationNoiseRepeat("Rotation Noise Repeat",Int)=0

        [KeywordEnum(Disable,Model,World,PostGeometry)]
        _PixelizationSpace("Vertex Pixelization Position Space",Int)=0
        [DFVector(1,1,1,2)]_Pixelization("Vertex Pixelization",Vector)=(1.0,1.0,1.0,0.02)

        [DFToggle(_ACTIVATE_ORBIT,1)]
        _ActivateOrbit("Activate Orbit",Int)=0
        _OrbitSeed("Orbit Seed",Float)=0.0
        _OrbitPrimitiveThreshold("Orbit Primitive Threshold",Range(0.0,1.0))=0.5

        _OrbitRotationSeed("Orbit Rotation Seed",Float)=1.0
        [DFVector(1,1,1)]_OrbitOffset("Orbit Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(0,1,1,2)]_OrbitScale("Orbit Scale",Vector)=(1.0,1.0,1.0,1.0)
        [DFVector(1,2,2)]_OrbitRotation("Orbit Rotation",Vector)=(0.0,0.0,0.0,0.0)

        [DFVector(1,1,1,2)]_OrbitRotationTimeMultiplier("Orbit Rotation Time Multiplier",Vector)=(4.0,0.0,0.0,1.0)

        [DFVector(1,1,1)]_OrbitRotationVariance("Orbit Rotation Variance",Vector)=(1.0,0.0,0.0,0.0)

        [DFVector(1,1)]_OrbitWaveStrength("Orbit Wave Strength",Vector)=(0.0,0.1,0.0,0.0)
        [DFVector(1,1)]_OrbitWaveFrequency("Orbit Wave Frequency",Vector)=(5.0,5.0,0.0,0.0)
        [DFVector(1,1)]_OrbitWavePhase("Orbit Wave Phase",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1)]_OrbitWaveTimeMultiplier("Orbit Wave Time Multiplier",Vector)=(1.0,5.0,0.0,0.0)

        [KeywordEnum(Disable,VU,Spectrum)]
        _OrbitWaveRefAudioLink("Orbit Wave Reference AudioLink",Int)=0
        [DFVector(1,1,1)]_OrbitWaveAudioLinkStrength("Orbit Wave AudioLink Strength",Vector)=(1.0,1.0,1.0,1.0)
        [MaterialToggle]_OrbitWaveAudioLinkSpectrumMirror("AudioLink Wave Mirror",Int)=0.0
        [MaterialToggle]_OrbitWaveAudioLinkSpectrumType("AudioLink Wave Type",Int)=0.0
        [DFVector(1,1)]_OrbitWaveAudioLinkSpectrumRange("AudioLink Wave Range",Vector)=(-1.0,1.0,0.0,0.0)



        [Enum(Value,0,Noise1st,1,Noise2nd,2,Noise3rd,3)]
        _FragmentSource("Fragment Source",Int)=1
        [Enum(Disable,0,VU_Add,1,VU_Mul,2,ChronoTensity,3,Spectrum,4)]
        _FragmentAudioLinkSource("Fragment AudioLink Source",Int)=0
        _FragmentAudioLinkVUStrength("Fragment AudioLink VU Strength",Float)=1.0
        _FragmentAudioLinkChronoTensityStrength("Fragment AudioLink ChronoTensity Strength",Float)=1.0
        _FragmentAudioLinkSpectrumStrength("Fragment AudioLink Spectrum Strength",Float)=1.0
        [MaterialToggle]_FragmentAudioLinkSpectrumMirror("Fragment AudioLink Spectrum Mirror",Int)=0.0
        [MaterialToggle]_FragmentAudioLinkSpectrumType("Fragment AudioLink Spectrum Type",Int)=0.0


        _FragmentValue("Fragment Value",Range(0.0,1.0))=0.0
        _FragmentPhaseScale("Fragment Phase Scale",Float)=1.0
        _FragmentThresholdMul("Fragment Threshold Mul",Float)=1.0
        _FragmentThresholdAdd("Fragment Threshold Add",Range(-0.5,0.5))=0.0
        [Enum(Clip,0,Repeat,1,PingPong,2)]
        _FragmentLoopMode("Fragment Loop Mode",Int)=0
        [Enum(In,0,Out,1,InOut,2,Invert_InOut,3)]
        _FragmentEaseMode("Fragment Easing Mode",Int)=2
        _FragmentEaseCurve("Fragment Easing Curve",Float)=1.0


        [Enum(Value,0,Noise1st,1,Noise2nd,2,Noise3rd,3)]
        _ColoringSource("Coloring Source",Int)=2
        [Enum(Disable,0,VU_Add,1,VU_Mul,2,ChronoTensity,3,Spectrum,4)]
        _ColoringAudioLinkSource("Coloring AudioLink Source",Int)=0
        _ColoringAudioLinkVUStrength("Coloring AudioLink VU Strength",Float)=1.0
        _ColoringAudioLinkChronoTensityStrength("Coloring AudioLink ChronoTensity Strength",Float)=1.0
        _ColoringAudioLinkSpectrumStrength("Coloring AudioLink Spectrum Strength",Float)=1.0
        [MaterialToggle]_ColoringAudioLinkSpectrumMirror("Coloring AudioLink Spectrum Mirror",Int)=0.0
        [MaterialToggle]_ColoringAudioLinkSpectrumType("Coloring AudioLink Spectrum Type",Int)=0.0

        _ColoringValue("Coloring Value",Range(0.0,1.0))=0.0
        _ColoringPhaseScale("Coloring Phase Scale",Float)=1.0
        _ColoringThresholdMul("Coloring Threshold Mul",Float)=1.0
        _ColoringThresholdAdd("Coloring Threshold Add",Range(-0.5,0.5))=0.0
        [Enum(Clip,0,Repeat,1,PingPong,2)]
        _ColoringLoopMode("Coloring Loop Mode",Int)=0
        [Enum(In,0,Out,1,InOut,2,Invert_InOut,3)]
        _ColoringEaseMode("Coloring Easing Mode",Int)=2
        _ColoringEaseCurve("Coloring Easing Curve",Float)=1.0


        [Enum(Value,0,Noise1st,1,Noise2nd,2,Noise3rd,3)]
        _GeometrySource("Geometry Source",Int)=3
        [Enum(Disable,0,VU_Add,1,VU_Mul,2,ChronoTensity,3,Spectrum,4)]
        _GeometryAudioLinkSource("Geometry AudioLink Source",Int)=0
        _GeometryAudioLinkVUStrength("Geometry AudioLink VU Strength",Float)=1.0
        _GeometryAudioLinkChronoTensityStrength("Geometry AudioLink ChronoTensity Strength",Float)=1.0
        _GeometryAudioLinkSpectrumStrength("Geometry AudioLink Spectrum Strength",Float)=1.0
        [MaterialToggle]_GeometryAudioLinkSpectrumMirror("Geometry AudioLink Spectrum Mirror",Int)=0.0
        [MaterialToggle]_GeometryAudioLinkSpectrumType("Geometry AudioLink Spectrum Type",Int)=0.0

        _GeometryValue("Geometry Value",Range(0.0,1.0))=0.0
        _GeometryPhaseScale("Geometry Phase Scale",Float)=1.0
        _GeometryThresholdMul("Geometry Threshold Mul",Float)=1.0
        _GeometryThresholdAdd("Geometry Threshold Add",Range(-0.5,0.5))=0.0
        [Enum(Clip,0,Repeat,1,PingPong,2)]
        _GeometryLoopMode("Geometry Loop Mode",Int)=0
        [Enum(In,0,Out,1,InOut,2,Invert_InOut,3)]
        _GeometryEaseMode("Geometry Easing Mode",Int)=2
        _GeometryEaseCurve("Geometry Easing Curve",Float)=1.0


        [Enum(Value,0,Primitive,1,Noise1st,2,Noise2nd,3,Noise3rd,4)]
        _OrbitSource("Orbit Source",Int)=0
        [Enum(Disable,0,VU_Add,1,VU_Mul,2,ChronoTensity,3,Spectrum,4)]
        _OrbitAudioLinkSource("Orbit AudioLink Source",Int)=0
        _OrbitAudioLinkVUStrength("Orbit AudioLink VU Strength",Float)=1.0
        _OrbitAudioLinkChronoTensityStrength("Orbit AudioLink ChronoTensity Strength",Float)=1.0
        _OrbitAudioLinkSpectrumStrength("Orbit AudioLink Spectrum Strength",Float)=1.0
        [MaterialToggle]_OrbitAudioLinkSpectrumMirror("Orbit AudioLink Spectrum Mirror",Int)=0.0
        [MaterialToggle]_OrbitAudioLinkSpectrumType("Orbit AudioLink Spectrum Type",Int)=0.0

        _OrbitValue("Orbit Value",Range(0.0,1.0))=0.0
        _OrbitPhaseScale("Orbit Phase Scale",Float)=1.0
        _OrbitThresholdMul("Orbit Threshold Mul",Float)=1.0
        _OrbitThresholdAdd("Orbit Threshold Add",Range(-0.5,0.5))=0.0
        [Enum(Clip,0,Repeat,1,PingPong,2)]
        _OrbitLoopMode("Orbit Loop Mode",Int)=0
        [Enum(In,0,Out,1,InOut,2,Invert_InOut,3)]
        _OrbitEaseMode("Orbit Easing Mode",Int)=2
        _OrbitEaseCurve("Orbit Easing Curve",Float)=1.0


        [Enum(Value,0,Primitive,1,Noise1st,2,Noise2nd,3,Noise3rd,4)]
        _OrbitRotationSource("Orbit Rotation Source",Int)=0
        [Enum(Nothing,0,Noise1st,1,Noise2nd,2,Noise3rd,3)]
        _OrbitRotationOffsetSource("Orbit Rotation Offset Source",Int)=0
        [Enum(Disable,0,VU_Add,1,ChronoTensity,2)]
        _OrbitRotationOffsetAudioLinkSource("Orbit Rotation Offset AudioLink Source",Int)=0
        _OrbitRotationOffsetAudioLinkVUStrength("Orbit Rotation Offset AudioLink VU Strength",Vector)=(1.0,0.0,0.0,0.0)
        _OrbitRotationOffsetAudioLinkChronoTensityStrength("Orbit Rotation Offset AudioLink ChronoTensity Strength",Vector)=(1.0,0.0,0.0,0.0)

        _OrbitRotationValue("Orbit Rotation Value",Range(0.0,1.0))=0.0
        _OrbitRotationPhaseScale("Orbit Rotation Phase Scale",Float)=1.0
        _OrbitRotationThresholdMul("Orbit Rotation Threshold Mul",Float)=1.0
        _OrbitRotationThresholdAdd("Orbit Rotation Threshold Add",Range(-0.5,0.5))=0.0
        [Enum(Clip,0,Repeat,1,PingPong,2)]
        _OrbitRotationLoopMode("Orbit Rotation Loop Mode",Int)=0
        [Enum(In,0,Out,1,InOut,2,Invert_InOut,3)]
        _OrbitRotationEaseMode("Orbit Rotation Easing Mode",Int)=2
        _OrbitRotationEaseCurve("Orbit Rotation Easing Curve",Float)=1.0

        [Enum(Disable,0,VU_Mul,1,ChronoTensity,2,Spectrum,3)]
        _OrbitWaveAudioLinkSource("Orbit Wave AudioLink Source",Int)=0
        _OrbitWaveAudioLinkVUStrength("Orbit Wave AudioLink VU Strength",Vector)=(1.0,0.0,0.0,0.0)
        _OrbitWaveAudioLinkChronoTensityStrength("Orbit Wave AudioLink ChronoTensity Strength",Float)=1.0
        _OrbitWaveAudioLinkSpectrumStrength("Orbit Wave AudioLink Spectrum Strength",Vector)=(1.0,0.0,0.0,0.0)
        [MaterialToggle]_OrbitWaveAudioLinkSpectrumMirror("Orbit Wave AudioLink Spectrum Mirror",Int)=0
        [MaterialToggle]_OrbitWaveAudioLinkSpectrumType("Orbit Wave AudioLink Spectrum Type",Int)=0
        _OrbitWaveAudioLinkSpectrumRange("Orbit Wave AudioLink Spectrum Range",Vector)=(0.0,1.0,0.0,0.0)


        _FragmentMaskMap("Fragment Mask Map",2D)="white"{}
        _FragmentMaskMapStrength("Fragment Mask Map Strength",Range(0.0,1.0))=1.0
        _ColoringMaskMap("Coloring Mask Map",2D)="white"{}
        _ColoringMaskMapStrength("Coloring Mask Map Strength",Range(0.0,1.0))=1.0
        _GeometryMaskMap("Geometry Mask Map",2D)="white"{}
        _GeometryMaskMapStrength("Geometry Mask Map Strength",Range(0.0,1.0))=1.0
        _OrbitMaskMap("Orbit Mask Map",2D)="white"{}
        _OrbitMaskMapStrength("Orbit Mask Map Strength",Range(0.0,1.0))=1.0
        _OrbitRotationMaskMap("Orbit Rotation Mask Map",2D)="white"{}
        _OrbitRotationMaskMapStrength("Orbit Rotation Mask Map Strength",Range(0.0,1.0))=1.0
        _OrbitRotationOffsetMaskMap("Orbit Rotation Mask Map",2D)="white"{}
        _OrbitRotationOffsetMaskMapStrength("Orbit Rotation Mask Map Strength",Vector)=(1.0,1.0,1.0,1.0)

        _FragmentMap("Fragment Offset Map",2D)="black"{}
        _FragmentMapStrength("Fragment Offset Map Strength",Range(0.0,1.0))=1.0
        _ColoringMap("Coloring Offset Map",2D)="black"{}
        _ColoringMapStrength("Coloring Offset Map Strength",Range(0.0,1.0))=1.0
        _GeometryMap("Geometry Offset Map",2D)="black"{}
        _GeometryMapStrength("Geometry Offset Map Strength",Range(0.0,1.0))=1.0
        _OrbitMap("Orbit Offset Map",2D)="black"{}
        _OrbitMapStrength("Orbit Offset Map Strength",Range(0.0,1.0))=1.0
        _OrbitRotationMap("Orbit Rotation Offset Map",2D)="black"{}
        _OrbitRotationMapStrength("Orbit Rotation Offset Map Strength",Range(0.0,1.0))=1.0

        _FragmentALMaskMap("Fragment AudioLink Mask Map",2D)="white"{}
        _FragmentALMaskMapStrength("Fragment AudioLink Mask Map Strength",Range(0.0,1.0))=1.0
        _ColoringALMaskMap("Coloring AudioLink Mask Map",2D)="white"{}
        _ColoringALMaskMapStrength("Coloring AudioLink Mask Map Strength",Range(0.0,1.0))=1.0
        _GeometryALMaskMap("Geometry AudioLink Mask Map",2D)="white"{}
        _GeometryALMaskMapStrength("Geometry AudioLink Mask Map Strength",Range(0.0,1.0))=1.0
        _OrbitALMaskMap("Orbit AudioLink Mask Map",2D)="white"{}
        _OrbitALMaskMapStrength("Orbit AudioLink Mask Map Strength",Range(0.0,1.0))=1.0
        _OrbitRotationOffsetALMaskMap("Orbit Rotation Offset AudioLink Mask Map",2D)="white"{}
        _OrbitRotationOffsetALMaskMapStrength("Orbit Rotation Offset AudioLink Mask Map Strength",Vector)=(1.0,1.0,1.0,1.0)

        [DFToggle(_FRAGMENT_AUDIOLINK_NOISE_SPECTRUM,1)]
        _FragmentAudioLinkNoiseSpectrum("Fragment AudioLink Noise Spectrum",Int)=0
        _FragmentAudioLinkStrength("Strength",Float)=1.0
        [MaterialToggle]_FragmentAudioLinkSpectrumMirror("Noise Wave Mirror",Int)=0.0
        [MaterialToggle]_FragmentAudioLinkSpectrumType("Noise Wave Type",Int)=0.0
        [DFVector(1,1)]_FragmentAudioLinkSpectrumRange("Noise Wave Range",Vector)=(-1.0,1.0,0.0,0.0)

        [DFToggle(_COLORING_AUDIOLINK_NOISE_SPECTRUM,1)]
        _ColoringAudioLinkNoiseSpectrum("Coloring AudioLink Noise Spectrum",Int)=0
        _ColoringAudioLinkStrength("Strength",Float)=1.0
        [MaterialToggle]_ColoringAudioLinkSpectrumMirror("Noise Wave Mirror",Int)=0.0
        [MaterialToggle]_ColoringAudioLinkSpectrumType("Noise Wave Type",Int)=0.0
        [DFVector(1,1)]_ColoringAudioLinkSpectrumRange("Noise Wave Range",Vector)=(-1.0,1.0,0.0,0.0)

        [DFToggle(_GEOMETRY_AUDIOLINK_NOISE_SPECTRUM,1)]
        _GeometryAudioLinkNoiseSpectrum("Geometry AudioLink Noise Spectrum",Int)=0
        _GeometryAudioLinkStrength("Strength",Float)=1.0
        [MaterialToggle]_GeometryAudioLinkSpectrumMirror("Noise Wave Mirror",Int)=0.0
        [MaterialToggle]_GeometryAudioLinkSpectrumType("Noise Wave Type",Int)=0.0
        [DFVector(1,1)]_GeometryAudioLinkSpectrumRange("Noise Wave Range",Vector)=(-1.0,1.0,0.0,0.0)


        [DFVector(1,1,1)]_Noise1stOffset0("Noise 1st Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_Noise1stScale0("Noise 1st Scale",Vector)=(1.0,1.0,1.0,3.0)
        [DFVector(1,1,1)]_Noise1stOffset1("Noise 1st Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_Noise1stScale1("Noise 1st Scale Sub",Vector)=(1.0,1.0,1.0,1.0)
        [Toggle(_NOISE1ST_OFFSET_BEFORE_SCALE)]
        _Noise1stOffsetBeforeScale("Noise 1st Offset before Scale",Int)=0
        [KeywordEnum(Offset,Model,World,Origin_World,Model_World,VertexColor)]
        _Noise1stSpace("Noise 1st Position Space",Int)=1
        _Noise1stSeed("Noise 1st Seed",Float)=0.0
        _Noise1stTimeMulti("Noise 1st Time Multiplier",Float)=3.0
        _Noise1stTimePhase("Noise 1st Time Phase",Float)=0.0
        _Noise1stPhaseScale("Noise 1st Phase Scale",Float)=0.0


        [DFVector(1,1,1)]_Noise2ndOffset0("Noise 2nd Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_Noise2ndScale0("Noise 2nd Scale",Vector)=(1.0,1.0,1.0,5.0)
        [DFVector(1,1,1)]_Noise2ndOffset1("Noise 2nd Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_Noise2ndScale1("Noise 2nd Scale",Vector)=(1.0,1.0,1.0,1.0)
        [Toggle(_NOISE2ND_OFFSET_BEFORE_SCALE)]
        _Noise2ndOffsetBeforeScale("Noise 2nd Offset before Scale",Int)=0
        [KeywordEnum(Offset,Model,World,Origin_World,Model_World,VertexColor)]
        _Noise2ndSpace("Noise 2nd Position Space",Int)=1
        _Noise2ndSeed("Noise 2nd Seed",Float)=1.0
        _Noise2ndTimeMulti("Noise 2nd Time Multiplier",Float)=5.0
        _Noise2ndTimePhase("Noise 2nd Time Phase",Float)=0.0
        _Noise2ndPhaseScale("Noise 2nd Phase Scale",Float)=0.0


        [DFVector(1,1,1)]_Noise3rdOffset0("Noise 3rd Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_Noise3rdScale0("Noise 3rd Scale",Vector)=(1.0,1.0,1.0,5.0)
        [DFVector(1,1,1)]_Noise3rdOffset1("Noise 3rd Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_Noise3rdScale1("Noise 3rd Scale",Vector)=(1.0,1.0,1.0,1.0)
        [Toggle(_NOISE3RD_OFFSET_BEFORE_SCALE)]
        _Noise3rdOffsetBeforeScale("Noise 3rd Offset before Scale",Int)=0
        [KeywordEnum(Offset,Model,World,Origin_World,Model_World,VertexColor)]
        _Noise3rdSpace("Noise 3rd Position Space",Int)=1
        _Noise3rdSeed("Noise 3rd Seed",Float)=2.0
        _Noise3rdTimeMulti("Noise 3rd Time Multiplier",Float)=3.0
        _Noise3rdTimePhase("Noise 3rd Time Phase",Float)=0.0
        _Noise3rdPhaseScale("Noise 3rd Phase Scale",Float)=0.0



    }
    SubShader{
        Pass{
            Name "DepthWrite"
            Tags{ "RenderType"="Opaque" "Queue"="Geometry" "LightMode"="ShadowCaster"}
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

            #pragma vertex vert
            #pragma fragment frag
            #pragma geometry geom
            #pragma multi_compile_shadowcaster
            #include "UnityCG.cginc"

            #pragma shader_feature_local _ _PREVIEW_MODE
            #pragma shader_feature_local _ _BILLBOARD_MODE
            #pragma shader_feature_local _ _USE_AUDIOLINK
            #pragma shader_feature_local _ _ANTI_ALIASING

            #pragma shader_feature_local _ _ACTIVATE_DIRECTIONALLIGHT_INFLUENCE
            #pragma shader_feature_local _ _ACTIVATE_AMBIENT_INFLUENCE
            #pragma shader_feature_local _ _ACTIVATE_LIGHTVOLUMES

            #pragma shader_feature_local _STEREOMERGEMODE_NONE _STEREOMERGEMODE_POSITION _STEREOMERGEMODE_ROTATION _STEREOMERGEMODE_POSITION_ROTATION

            #pragma shader_feature_local _LINEFADEMODE_NORMAL _LINEFADEMODE_INSTANT _LINEFADEMODE_OUTWIDE _LINEFADEMODE_OUTTHIN _LINEFADEMODE_BREAK _LINEFADEMODE_VANISHING _LINEFADEMODE_ZOOMIN _LINEFADEMODE_ZOOMOUT _LINEFADEMODE_POWERZOOMIN _LINEFADEMODE_COLLAPSE _LINEFADEMODE_JOIN1 _LINEFADEMODE_JOIN2 _LINEFADEMODE_JOIN3


            #pragma shader_feature_local _ _MANUAL_LINE_SCALING
            #pragma shader_feature_local _FRAGMENTPARTITIONTYPE_VERTEX _FRAGMENTPARTITIONTYPE_SIDE _FRAGMENTPARTITIONTYPE_MESH

            #pragma shader_feature_local _COLORSOURCE_GRADIENT _COLORSOURCE_PRIMARY _COLORSOURCE_GRADIENTTEX _COLORSOURCE_VERTEXCOLOR _COLORSOURCE_UNIQUESIDES _COLORSOURCE_AUDIOLINK_THEMECOLOR
            #pragma shader_feature_local _COLORINGPARTITIONTYPE_VERTEX _COLORINGPARTITIONTYPE_SIDE _COLORINGPARTITIONTYPE_MESH

            #pragma shader_feature_local _ _GEOMETRY_SCALE
            #pragma shader_feature_local _ _GEOMETRY_EXTRUDE
            #pragma shader_feature_local _ _GEOMETRY_ROTATION
            #pragma shader_feature_local _ _GEOMETRY_ROTATION_NOISE_REPEAT

            #pragma shader_feature_local _ _ACTIVATE_ORBIT
            #pragma shader_feature_local _PIXELIZATIONSPACE_DISABLE _PIXELIZATIONSPACE_MODEL _PIXELIZATIONSPACE_WORLD _PIXELIZATIONSPACE_POSTGEOMETRY



            #pragma shader_feature_local _NOISE1STSPACE_OFFSET _NOISE1STSPACE_MODEL _NOISE1STSPACE_WORLD _NOISE1STSPACE_ORIGIN_WORLD _NOISE1STSPACE_MODEL_WORLD _NOISE1STSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE1ST_OFFSET_BEFORE_SCALE

            #pragma shader_feature_local _NOISE2NDSPACE_OFFSET _NOISE2NDSPACE_MODEL _NOISE2NDSPACE_WORLD _NOISE2NDSPACE_ORIGIN_WORLD _NOISE2NDSPACE_MODEL_WORLD _NOISE2NDSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE2ND_OFFSET_BEFORE_SCALE

            #pragma shader_feature_local _NOISE3RDSPACE_OFFSET _NOISE3RDSPACE_MODEL _NOISE3RDSPACE_WORLD _NOISE3RDSPACE_ORIGIN_WORLD _NOISE3RDSPACE_MODEL_WORLD _NOISE3RDSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE3RD_OFFSET_BEFORE_SCALE

            #pragma shader_feature_local _ _USE_FWIDTH

            #pragma shader_feature_local _ _RENDERINGMODE_CUTOUT

            #include "AutoLight.cginc"

            #include "Packages/com.deltafield.meshhologram/Includes/macro_general.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_noise.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_uv.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_geom.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_thirdparties.hlsl"
            #include "Packages/com.deltafield.shader_commons/Includes/macro_stereo_merge.hlsl"
            
            #include "Packages/com.deltafield.shader_commons/Includes/functions_math.hlsl"
            #include "Packages/com.deltafield.shader_commons/Includes/functions_random.hlsl"
            #include "Packages/com.deltafield.shader_commons/Includes/functions_random3d.hlsl"
            #include "Packages/com.deltafield.shader_commons/Includes/functions_stereo_merge.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/variables.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_common.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_thirdparties.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_noise.hlsl"

            #include "Packages/com.deltafield.meshhologram/Includes/structs.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_vert.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_geom.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_frag_depth_write.hlsl"

            ENDHLSL
        }

        Pass{
            Name "MainRender"
            Tags { "RenderType"="Transparent" "Queue"="Transparent" "LightMode"="ForwardBase"}
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

            #pragma vertex vert
            #pragma fragment frag
            #pragma geometry geom
            #pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"



            #pragma shader_feature_local _ _PREVIEW_MODE
            #pragma shader_feature_local _ _BILLBOARD_MODE
            #pragma shader_feature_local _ _USE_AUDIOLINK
            #pragma shader_feature_local _ _ANTI_ALIASING

            #pragma shader_feature_local _ _ACTIVATE_DIRECTIONALLIGHT_INFLUENCE
            #pragma shader_feature_local _ _ACTIVATE_AMBIENT_INFLUENCE
            #pragma shader_feature_local _ _ACTIVATE_LIGHTVOLUMES

            #pragma shader_feature_local _STEREOMERGEMODE_NONE _STEREOMERGEMODE_POSITION _STEREOMERGEMODE_ROTATION _STEREOMERGEMODE_POSITION_ROTATION

            #pragma shader_feature_local _LINEFADEMODE_NORMAL _LINEFADEMODE_INSTANT _LINEFADEMODE_OUTWIDE _LINEFADEMODE_OUTTHIN _LINEFADEMODE_BREAK _LINEFADEMODE_VANISHING _LINEFADEMODE_ZOOMIN _LINEFADEMODE_ZOOMOUT _LINEFADEMODE_POWERZOOMIN _LINEFADEMODE_COLLAPSE _LINEFADEMODE_JOIN1 _LINEFADEMODE_JOIN2 _LINEFADEMODE_JOIN3


            #pragma shader_feature_local _ _MANUAL_LINE_SCALING
            #pragma shader_feature_local _FRAGMENTPARTITIONTYPE_VERTEX _FRAGMENTPARTITIONTYPE_SIDE _FRAGMENTPARTITIONTYPE_MESH

            #pragma shader_feature_local _COLORSOURCE_GRADIENT _COLORSOURCE_PRIMARY _COLORSOURCE_GRADIENTTEX _COLORSOURCE_VERTEXCOLOR _COLORSOURCE_UNIQUESIDES _COLORSOURCE_AUDIOLINK_THEMECOLOR
            #pragma shader_feature_local _COLORINGPARTITIONTYPE_VERTEX _COLORINGPARTITIONTYPE_SIDE _COLORINGPARTITIONTYPE_MESH

            #pragma shader_feature_local _ _GEOMETRY_SCALE
            #pragma shader_feature_local _ _GEOMETRY_EXTRUDE
            #pragma shader_feature_local _ _GEOMETRY_ROTATION
            #pragma shader_feature_local _ _GEOMETRY_ROTATION_NOISE_REPEAT

            #pragma shader_feature_local _ _ACTIVATE_ORBIT
            #pragma shader_feature_local _PIXELIZATIONSPACE_DISABLE _PIXELIZATIONSPACE_MODEL _PIXELIZATIONSPACE_WORLD _PIXELIZATIONSPACE_POSTGEOMETRY



            #pragma shader_feature_local _NOISE1STSPACE_OFFSET _NOISE1STSPACE_MODEL _NOISE1STSPACE_WORLD _NOISE1STSPACE_ORIGIN_WORLD _NOISE1STSPACE_MODEL_WORLD _NOISE1STSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE1ST_OFFSET_BEFORE_SCALE

            #pragma shader_feature_local _NOISE2NDSPACE_OFFSET _NOISE2NDSPACE_MODEL _NOISE2NDSPACE_WORLD _NOISE2NDSPACE_ORIGIN_WORLD _NOISE2NDSPACE_MODEL_WORLD _NOISE2NDSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE2ND_OFFSET_BEFORE_SCALE

            #pragma shader_feature_local _NOISE3RDSPACE_OFFSET _NOISE3RDSPACE_MODEL _NOISE3RDSPACE_WORLD _NOISE3RDSPACE_ORIGIN_WORLD _NOISE3RDSPACE_MODEL_WORLD _NOISE3RDSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE3RD_OFFSET_BEFORE_SCALE

            #pragma shader_feature_local _ _USE_FWIDTH

            #pragma shader_feature_local _ _RENDERINGMODE_CUTOUT

            #include "Packages/com.deltafield.meshhologram/Includes/macro_general.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_noise.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_uv.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_geom.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_thirdparties.hlsl"
            #include "Packages/com.deltafield.shader_commons/Includes/macro_stereo_merge.hlsl"

            #include "Packages/com.deltafield.shader_commons/Includes/functions_math.hlsl"
            #include "Packages/com.deltafield.shader_commons/Includes/functions_random.hlsl"
            #include "Packages/com.deltafield.shader_commons/Includes/functions_random3d.hlsl"
            #include "Packages/com.deltafield.shader_commons/Includes/functions_stereo_merge.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/variables.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_common.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_thirdparties.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_noise.hlsl"

            #include "Packages/com.deltafield.meshhologram/Includes/structs.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_vert.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/functions_geom.hlsl"
            fixed4 frag(g2f i) : SV_Target{
                #include "Packages/com.deltafield.meshhologram/Includes/functions_frag.hlsl"
                #include "Packages/com.deltafield.meshhologram/Includes/functions_frag_mesh.hlsl"
            }
            ENDHLSL
        }

    }
    Fallback "Mobile/Particle/Alpha Blended"
    CustomEditor "DeltaField.Shaders.MeshHologram.Editor.MeshHologramInspector"
}