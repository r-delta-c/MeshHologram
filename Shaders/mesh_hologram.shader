Shader "DeltaField/shaders/MeshHologram"{
    Properties{
        [Enum(Transparent,0,Cutout,1,DepthOnly,2)]
        _RenderingMode("Rendering Mode",Int)=0
        [Enum(UnityEngine.Rendering.CullMode)]
        _Cull("Culling Mode",Int)=0
        [DFToggle(,0)]_ZWrite("Z Write",Int)=0

        [IntRange]_CustomRenderQueueT("Transparent Render Queue",Range(3000,5000))=3000
        [IntRange]_CustomRenderQueueC("Cutout Render Queue",Range(2001,2499))=2001

        [DFToggle(,0)]_BillboardEnable("Enable Billboard",Int)=0
        [DFToggle(,0)]_Forced_Z_Scale_Zero("Forced Z Scale Zero",Float)=1.0
        _DistanceInfluence("Distance Influence",Range(0.0,1.0))=1.0
        [KeywordEnum(None,Position,Rotation,Position_Rotation)]
        _StereoMergeMode("Stereo Merge Mode",Int)=2
        [DFToggle(,0)]_FwidthEnable("Enable fwidth()",Int)=1

        [DFToggle(_DIRECTIONALLIGHT_INFLUENCE_ENABLE,1)]
        _DirectionalLightInfluenceEnable("Activate Directional Light Influence",Int)=0
        _DirectionalLightInfluence("Directional Light Influence",Range(0.0,1.0))=1.0
        [DFToggle(_AMBIENT_INFLUENCE_ENABLE,1)]
        _AmbientInfluenceEnable("Activate Ambient Influence",Int)=0.0
        _AmbientInfluence("Ambient Influence",Range(0.0,1.0))=1.0
        [DFToggle(_LIGHTVOLUMES_ENABLE,1)]
        _LightVolumesInfluenceEnable("Activate LightVolumes",Int)=0.0
        _LightVolumesInfluence("LightVolumes Influence",Range(0.0,1.0))=1.0

        [DFToggle(,0)]_PreviewEnable("Enable Preview",Int)=0
        [DFToggle(,0)]_AntiAliasingEnable("Enable Anti Aliasing",Int)=1

        _MainTex("Fallback Texture",2D)="(1.0,1.0,1.0,0.25)" {}


        [DFToggle(,0)]_ZClip("Z Clip",Int)=1
        [Enum(UnityEngine.Rendering.CompareFunction)]_ZTest("Z Test",Int)=4
        [DFColorMask]_ColorMask("Color Mask",Int)=15
        _OffsetFactor("Offset Factor",Range(-1.0,1.0))=0.0
        _OffsetUnits("Offset Factor",Range(-1.0,1.0))=0.0
        _AlphaToMask("Alpha To Mask",Int)=0
        [DFToggle(,0)]_AlphaToMaskMemory("Alpha To Mask",Int)=0

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


        [DFToggle(_AUDIOLINK_ENABLE,1)]
        _AudioLinkEnable("Enable AudioLink",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3)]
        _AudioLinkThemeColorBand("Theme Color Band",Int)=0

        _FragmentTriangleCompression("Triangle Compression",Float)=5.0
        [DFToggle(,0)]_FragmentFill("Fill",Float)=0.0
        _FragmentLineWidth("Line Width",Float)=2.0
        _FragmentLineGradientBias("Line Gradient Bias",Float)=0.0
        [DFToggle(,0)]_FragmentManualLineScalingEnable("Enable Manual Line Scaling",Int)=0.0
        _FragmentLineScale("Line Scale",Float)=1.0
        [DFLineAnimationMode]_FragmentLineAnimationMode("Line Animation Mode",Int)=0
        [Enum(Vertex,0,Edge,1,Mesh,2)]
        _FragmentPartitionMode("Partition Mode",Int)=1


        _Color0("Primary Color",Color)=(1.0,1.0,1.0,1.0)
        _Color1("Secondary Color",Color)=(0.2,0.2,0.2,1.0)
        _Emission("Add Emission",Float)=0.0
        [Enum(Gradient,0,Primary,1,GradientTex,2,VertexColor,3,UniqueEdges,4,AudioLink_ThemeColor,5)]
        _ColorSource("Color Source",Int)=0
        _ColorGradientTex("Gradient Tex",2D)="white"{}
        [Enum(Vertex,0,Edge,1,Mesh,2)]
        _ColoringPartitionMode("Coloring Partition Mode",Int)=1


        [DFToggle(,1)]
        _GeometryScaleEnable("Enable Scale",Int)=0
        [DFVector(1,1)]_GeometryScaleBounds("Scale Bounds",Vector)=(0.5,0.0,0.0,0.0)

        [DFToggle(,1)]
        _GeometryPushPullEnable("Enable PushPull",Int)=1
        [DFVector(1,1)]_GeometryPushPullBounds("PushPull Bounds",Vector)=(-0.15,0.0,0.0,0.0)
        _GeometryPushPullPartitionBias("PushPull Partition Bias| Vertex <=> Center",Range(0.0,1.0))=0.5

        [DFToggle(,1)]
        _GeometryRotationEnable("Enable Rotation",Int)=0
        _GeometryRotationStrength("Rotation Strength",Range(0.0,1.0))=1.0
        [DFToggle(,0)]
        _GeometryRotationInvert("Invert Rotation",Int)=0
        [DFToggle(,0)]
        _GeometryRotationNoiseRepeat("Rotation Noise Repeat",Int)=0

        [Enum(Disable,0,Model,1,World,2,PostGeometry,3)]
        _GeometryPixelizationSpace("Pixelization Space",Int)=0
        [DFVector(1,1,1,2)]_GeometryPixelization("Pixelization",Vector)=(0.0,0.0,0.0,0.02)

        [DFToggle(,1)]
        _OrbitEnable("Enable Orbit",Int)=0
        _OrbitSeed("Orbit Seed",Float)=0.0
        _OrbitPrimitiveRatio("Orbit Primitive Ratio",Range(0.0,1.0))=0.5
        [DFVector(1,1,1)]_OrbitOffset("Orbit Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(0,1,1,2)]_OrbitScale("Orbit Scale",Vector)=(1.0,1.0,1.0,1.0)

        _OrbitRotationSeed("Orbit Rotation Seed",Float)=1.0
        [DFVector(1,2,2)]_OrbitRotationAngle("Orbit Rotation Angle",Vector)=(0.0,0.0,0.0,0.0)

        [DFVector(1,1,1,2)]_OrbitRotationSpeed("Orbit Rotation Speed",Vector)=(4.0,0.0,0.0,1.0)

        [DFVector(1,1,1)]_OrbitRotationSpread("Orbit Rotation Spread",Vector)=(1.0,0.0,0.0,0.0)

        [DFVector(1,1)]_OrbitWaveStrength("Orbit Wave Strength",Vector)=(0.0,0.1,0.0,0.0)
        [DFVector(1,1)]_OrbitWaveFrequency("Orbit Wave Frequency",Vector)=(5.0,5.0,0.0,0.0)
        [DFVector(1,1)]_OrbitWavePhase("Orbit Wave Phase",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1)]_OrbitWaveSpeed("Orbit Wave Speed",Vector)=(1.0,5.0,0.0,0.0)



        [Enum(Value,0,Noise,1)]
        _FragmentSource("Fragment Source",Int)=1
        _FragmentFixedValue("Fragment Fixed Value",Range(0.0,1.0))=0.0
        [Enum(Disable,0,VU_Add,1,VU_Mul,2,ChronoTensity,3,Spectrum,4)]
        _FragmentAudioLinkSource("Fragment AudioLink Source",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3,Average,4)]
        _FragmentAudioLinkVUBand("Fragment AudioLink VUBand",Int)=0
        [IntRange]_FragmentAudioLinkVUSmoothing("Fragment AudioLink VU Smoothing",Range(0,15))=8
        _FragmentAudioLinkVUPanning("Fragment AudioLink VU Panning",Range(0.0,1.0))=0.5
        _FragmentAudioLinkVUStrength("Fragment AudioLink VU Strength",Float)=1.0
        [DFChronoTensityMode]
        _FragmentAudioLinkChronoTensityMode("Fragment AudioLink Chrono Tensity Mode",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3)]
        _FragmentAudioLinkChronoTensityBand("Fragment AudioLink Chrono Tensity Band",Int)=0
        _FragmentAudioLinkChronoTensityStrength("Fragment AudioLink ChronoTensity Strength",Float)=1.0
        _FragmentAudioLinkSpectrumStrength("Fragment AudioLink Spectrum Strength",Float)=1.0
        [DFToggle(,0)]_FragmentAudioLinkSpectrumMirror("Fragment AudioLink Spectrum Mirror",Int)=0.0

        _FragmentPhaseScale("Fragment Phase Scale",Float)=1.0
        [Enum(Clip,0,Repeat,1,PingPong,2)]
        _FragmentLoopMode("Fragment Loop Mode",Int)=2
        [Enum(In,0,Out,1,InOut,2,Invert_InOut,3)]
        _FragmentEaseMode("Fragment Easing Mode",Int)=2
        _FragmentEaseCurve("Fragment Easing Curve",Float)=1.0
        _FragmentMidMul("Fragment Mid Mul",Float)=1.0
        _FragmentMidAdd("Fragment Mid Add",Range(-0.5,0.5))=0.0


        [Enum(Value,0,Noise,1)]
        _ColoringSource("Coloring Source",Int)=1
        _ColoringFixedValue("Coloring Fixed Value",Range(0.0,1.0))=0.0
        [Enum(Disable,0,VU_Add,1,VU_Mul,2,ChronoTensity,3,Spectrum,4)]
        _ColoringAudioLinkSource("Coloring AudioLink Source",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3,Average,4)]
        _ColoringAudioLinkVUBand("Coloring AudioLink VUBand",Int)=0
        [IntRange]_ColoringAudioLinkVUSmoothing("Coloring AudioLink VU Smoothing",Range(0,15))=8
        _ColoringAudioLinkVUPanning("Coloring AudioLink VU Panning",Range(0.0,1.0))=0.5
        _ColoringAudioLinkVUStrength("Coloring AudioLink VU Strength",Float)=1.0
        [DFChronoTensityMode]
        _ColoringAudioLinkChronoTensityMode("Coloring AudioLink Chrono Tensity Mode",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3)]
        _ColoringAudioLinkChronoTensityBand("Coloring AudioLink Chrono Tensity Band",Int)=0
        _ColoringAudioLinkChronoTensityStrength("Coloring AudioLink ChronoTensity Strength",Float)=1.0
        _ColoringAudioLinkSpectrumStrength("Coloring AudioLink Spectrum Strength",Float)=1.0
        [DFToggle(,0)]_ColoringAudioLinkSpectrumMirror("Coloring AudioLink Spectrum Mirror",Int)=0.0

        _ColoringPhaseScale("Coloring Phase Scale",Float)=1.0
        [Enum(Clip,0,Repeat,1,PingPong,2)]
        _ColoringLoopMode("Coloring Loop Mode",Int)=2
        [Enum(In,0,Out,1,InOut,2,Invert_InOut,3)]
        _ColoringEaseMode("Coloring Easing Mode",Int)=2
        _ColoringEaseCurve("Coloring Easing Curve",Float)=1.0
        _ColoringMidMul("Coloring Mid Mul",Float)=1.0
        _ColoringMidAdd("Coloring Mid Add",Range(-0.5,0.5))=0.0


        [Enum(Value,0,Noise,1)]
        _GeometrySource("Geometry Source",Int)=1
        _GeometryFixedValue("Geometry Fixed Value",Range(0.0,1.0))=0.0
        [Enum(Disable,0,VU_Add,1,VU_Mul,2,ChronoTensity,3,Spectrum,4)]
        _GeometryAudioLinkSource("Geometry AudioLink Source",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3,Average,4)]
        _GeometryAudioLinkVUBand("Geometry AudioLink VUBand",Int)=0
        [IntRange]_GeometryAudioLinkVUSmoothing("Geometry AudioLink VU Smoothing",Range(0,15))=8
        _GeometryAudioLinkVUPanning("Geometry AudioLink VU Panning",Range(0.0,1.0))=0.5
        _GeometryAudioLinkVUStrength("Geometry AudioLink VU Strength",Float)=1.0
        [DFChronoTensityMode]
        _GeometryAudioLinkChronoTensityMode("Geometry AudioLink Chrono Tensity Mode",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3)]
        _GeometryAudioLinkChronoTensityBand("Geometry AudioLink Chrono Tensity Band",Int)=0
        _GeometryAudioLinkChronoTensityStrength("Geometry AudioLink ChronoTensity Strength",Float)=1.0
        _GeometryAudioLinkSpectrumStrength("Geometry AudioLink Spectrum Strength",Float)=1.0
        [DFToggle(,0)]_GeometryAudioLinkSpectrumMirror("Geometry AudioLink Spectrum Mirror",Int)=0.0

        _GeometryPhaseScale("Geometry Phase Scale",Float)=1.0
        [Enum(Clip,0,Repeat,1,PingPong,2)]
        _GeometryLoopMode("Geometry Loop Mode",Int)=2
        [Enum(In,0,Out,1,InOut,2,Invert_InOut,3)]
        _GeometryEaseMode("Geometry Easing Mode",Int)=2
        _GeometryEaseCurve("Geometry Easing Curve",Float)=1.0
        _GeometryMidMul("Geometry Mid Mul",Float)=1.0
        _GeometryMidAdd("Geometry Mid Add",Range(-0.5,0.5))=0.0


        [Enum(Value,0,Primitive,1,Noise,2)]
        _OrbitSource("Orbit Source",Int)=1
        _OrbitFixedValue("Orbit Value",Range(0.0,1.0))=0.0
        [Enum(Disable,0,VU_Add,1,VU_Mul,2,ChronoTensity,3,Spectrum,4)]
        _OrbitAudioLinkSource("Orbit AudioLink Source",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3,Average,4)]
        _OrbitAudioLinkVUBand("Orbit AudioLink VUBand",Int)=0
        [IntRange]_OrbitAudioLinkVUSmoothing("Orbit AudioLink VU Smoothing",Range(0,15))=8
        _OrbitAudioLinkVUPanning("Orbit AudioLink VU Panning",Range(0.0,1.0))=0.5
        _OrbitAudioLinkVUStrength("Orbit AudioLink VU Strength",Float)=1.0
        [DFChronoTensityMode]
        _OrbitAudioLinkChronoTensityMode("Orbit AudioLink Chrono Tensity Mode",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3)]
        _OrbitAudioLinkChronoTensityBand("Orbit AudioLink Chrono Tensity Band",Int)=0
        _OrbitAudioLinkChronoTensityStrength("Orbit AudioLink ChronoTensity Strength",Float)=1.0
        _OrbitAudioLinkSpectrumStrength("Orbit AudioLink Spectrum Strength",Float)=1.0
        [DFToggle(,0)]_OrbitAudioLinkSpectrumMirror("Orbit AudioLink Spectrum Mirror",Int)=0.0

        _OrbitPhaseScale("Orbit Phase Scale",Float)=1.0
        [Enum(Clip,0,Repeat,1,PingPong,2)]
        _OrbitLoopMode("Orbit Loop Mode",Int)=2
        [Enum(In,0,Out,1,InOut,2,Invert_InOut,3)]
        _OrbitEaseMode("Orbit Easing Mode",Int)=2
        _OrbitEaseCurve("Orbit Easing Curve",Float)=1.0
        _OrbitMidMul("Orbit Mid Mul",Float)=1.0
        _OrbitMidAdd("Orbit Mid Add",Range(-0.5,0.5))=0.0



        [Enum(Value,0,Primitive,1,Noise,2)]
        _OrbitRotationSource("Orbit Rotation Source",Int)=1
        _OrbitRotationFixedValue("Orbit Rotation Fixed Value",Range(0.0,1.0))=0.0
        [Enum(Disable,0,VU_Add,1,ChronoTensity,2)]
        _OrbitRotationOffsetAudioLinkSource("Orbit Rotation Offset AudioLink Source",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3,Average,4)]
        _OrbitRotationOffsetAudioLinkVUBand("Orbit Offset AudioLink VUBand",Int)=0
        [IntRange]_OrbitRotationOffsetAudioLinkVUSmoothing("Orbit Offset AudioLink VU Smoothing",Range(0,15))=8
        _OrbitRotationOffsetAudioLinkVUPanning("Orbit Offset AudioLink VU Panning",Range(0.0,1.0))=0.5
        [DFVector(1,1,1,2)]_OrbitRotationOffsetAudioLinkVUStrength("Orbit Rotation Offset AudioLink VU Strength",Vector)=(1.0,0.0,0.0,1.0)
        [DFChronoTensityMode]
        _OrbitRotationOffsetAudioLinkChronoTensityMode("Orbit Offset AudioLink Chrono Tensity Mode",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3)]
        _OrbitRotationOffsetAudioLinkChronoTensityBand("Orbit Offset AudioLink Chrono Tensity Band",Int)=0
        [DFVector(1,1,1,2)]_OrbitRotationOffsetAudioLinkChronoTensityStrength("Orbit Rotation Offset AudioLink ChronoTensity Strength",Vector)=(1.0,0.0,0.0,1.0)



        [Enum(Disable,0,VU_Mul,1,ChronoTensity,2,Spectrum,3)]
        _OrbitWaveAudioLinkSource("Orbit Wave AudioLink Source",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3,Average,4)]
        _OrbitWaveAudioLinkVUBand("Orbit Wave AudioLink VUBand",Int)=0
        [IntRange]_OrbitWaveAudioLinkVUSmoothing("Orbit Wave AudioLink VU Smoothing",Range(0,15))=8
        _OrbitWaveAudioLinkVUPanning("Orbit Wave AudioLink VU Panning",Range(0.0,1.0))=0.5
        [DFVector(1,1)]_OrbitWaveAudioLinkVUStrength("Orbit Wave AudioLink VU Strength",Vector)=(1.0,0.0,0.0,0.0)
        [DFVector(1,1)]_OrbitWaveAudioLinkChronoTensityStrength("Orbit Wave AudioLink ChronoTensity Strength",Vector)=(1.0,1.0,0.0,0.0)
        [DFChronoTensityMode]
        _OrbitWaveAudioLinkChronoTensityMode("Orbit Wave AudioLink Chrono Tensity Mode",Int)=0
        [Enum(Bass,0,Low_Mid,1,High_Mid,2,Treble,3)]
        _OrbitWaveAudioLinkChronoTensityBand("Orbit Wave AudioLink Chrono Tensity Band",Int)=0
        [DFToggle(,0)]_OrbitWaveAudioLinkSpectrumMode("Orbit Wave AudioLink Spectrum Mode",Int)=0
        [DFToggle(,0)]_OrbitWaveAudioLinkSpectrumMirror("Orbit Wave AudioLink Spectrum Mirror",Int)=0
        [DFVector(1,1)]_OrbitWaveAudioLinkSpectrumBounds("Orbit Wave AudioLink Spectrum Bounds",Vector)=(0.0,1.0,0.0,0.0)
        [DFVector(1,1)]_OrbitWaveAudioLinkSpectrumStrength("Orbit Wave AudioLink Spectrum Strength",Vector)=(1.0,0.0,0.0,0.0)


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
        [DFVector(1,1,1,2)]_OrbitRotationOffsetMaskMapStrength("Orbit Rotation Mask Map Strength",Vector)=(1.0,1.0,1.0,1.0)

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

        _FragmentAudioLinkMaskMap("Fragment AudioLink Mask Map",2D)="white"{}
        _FragmentAudioLinkMaskMapStrength("Fragment AudioLink Mask Map Strength",Range(0.0,1.0))=1.0
        _ColoringAudioLinkMaskMap("Coloring AudioLink Mask Map",2D)="white"{}
        _ColoringAudioLinkMaskMapStrength("Coloring AudioLink Mask Map Strength",Range(0.0,1.0))=1.0
        _GeometryAudioLinkMaskMap("Geometry AudioLink Mask Map",2D)="white"{}
        _GeometryAudioLinkMaskMapStrength("Geometry AudioLink Mask Map Strength",Range(0.0,1.0))=1.0
        _OrbitAudioLinkMaskMap("Orbit AudioLink Mask Map",2D)="white"{}
        _OrbitAudioLinkMaskMapStrength("Orbit AudioLink Mask Map Strength",Range(0.0,1.0))=1.0
        _OrbitRotationOffsetAudioLinkMaskMap("Orbit Rotation Offset AudioLink Mask Map",2D)="white"{}
        [DFVector(1,1,1,2)]_OrbitRotationOffsetAudioLinkMaskMapStrength("Orbit Rotation Offset AudioLink Mask Map Strength",Vector)=(1.0,1.0,1.0,1.0)


        [DFVector(1,1,1)]_FragmentNoiseOffset0("Noise 1st Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_FragmentNoiseScale0("Noise 1st Scale",Vector)=(1.0,1.0,1.0,3.0)
        [DFVector(1,1,1)]_FragmentNoiseOffset1("Noise 1st Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_FragmentNoiseScale1("Noise 1st Scale Sub",Vector)=(1.0,1.0,1.0,1.0)
        [Enum(Offset,0,Model,1,World,2,Origin_World,3,Model_World,4,VertexColor,5)]
        _FragmentNoiseSpace("Noise 1st Position Space",Int)=1
        [DFToggle(,0)]_FragmentNoiseOffsetBeforeScale("Noise 1st Offset before Scale",Int)=0
        _FragmentNoiseSeed("Noise 1st Seed",Float)=0.0
        _FragmentNoiseTimeSpeed("Noise 1st Time Speed",Float)=3.0
        _FragmentNoiseTimePhase("Noise 1st Time Phase",Float)=0.0
        _FragmentNoiseValueScale("Noise 1st Value Scale",Float)=1.0


        [DFVector(1,1,1)]_ColoringNoiseOffset0("Noise 2nd Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_ColoringNoiseScale0("Noise 2nd Scale",Vector)=(1.0,1.0,1.0,5.0)
        [DFVector(1,1,1)]_ColoringNoiseOffset1("Noise 2nd Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_ColoringNoiseScale1("Noise 2nd Scale",Vector)=(1.0,1.0,1.0,1.0)
        [Enum(Offset,0,Model,1,World,2,Origin_World,3,Model_World,4,VertexColor,5)]
        _ColoringNoiseSpace("Noise 2nd Position Space",Int)=1
        [DFToggle(,0)]_ColoringNoiseOffsetBeforeScale("Noise 2nd Offset before Scale",Int)=0
        _ColoringNoiseSeed("Noise 2nd Seed",Float)=1.0
        _ColoringNoiseTimeSpeed("Noise 2nd Time Speed",Float)=5.0
        _ColoringNoiseTimePhase("Noise 2nd Time Phase",Float)=0.0
        _ColoringNoiseValueScale("Noise 2nd Value Scale",Float)=1.0


        [DFVector(1,1,1)]_GeometryNoiseOffset0("Noise 3rd Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_GeometryNoiseScale0("Noise 3rd Scale",Vector)=(1.0,1.0,1.0,5.0)
        [DFVector(1,1,1)]_GeometryNoiseOffset1("Noise 3rd Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_GeometryNoiseScale1("Noise 3rd Scale",Vector)=(1.0,1.0,1.0,1.0)
        [Enum(Offset,0,Model,1,World,2,Origin_World,3,Model_World,4,VertexColor,5)]
        _GeometryNoiseSpace("Noise 3rd Position Space",Int)=1
        [DFToggle(,0)]_GeometryNoiseOffsetBeforeScale("Noise 3rd Offset before Scale",Int)=0
        _GeometryNoiseSeed("Noise 3rd Seed",Float)=2.0
        _GeometryNoiseTimeSpeed("Noise 3rd Time Speed",Float)=3.0
        _GeometryNoiseTimePhase("Noise 3rd Time Phase",Float)=0.0
        _GeometryNoiseValueScale("Noise 3rd Value Scale",Float)=1.0


        [DFVector(1,1,1)]_OrbitNoiseOffset0("Noise 4th Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_OrbitNoiseScale0("Noise 4th Scale",Vector)=(1.0,1.0,1.0,5.0)
        [DFVector(1,1,1)]_OrbitNoiseOffset1("Noise 4th Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_OrbitNoiseScale1("Noise 4th Scale",Vector)=(1.0,1.0,1.0,1.0)
        [Enum(Offset,0,Model,1,World,2,Origin_World,3,Model_World,4,VertexColor,5)]
        _OrbitNoiseSpace("Noise 4th Position Space",Int)=1
        [DFToggle(,0)]_OrbitNoiseOffsetBeforeScale("Noise 4th Offset before Scale",Int)=0
        _OrbitNoiseSeed("Noise 4th Seed",Float)=2.0
        _OrbitNoiseTimeSpeed("Noise 4th Time Speed",Float)=3.0
        _OrbitNoiseTimePhase("Noise 4th Time Phase",Float)=0.0
        _OrbitNoiseValueScale("Noise 4th Value Scale",Float)=1.0


        [DFVector(1,1,1)]_OrbitRotationNoiseOffset0("Noise 5th Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_OrbitRotationNoiseScale0("Noise 5th Scale",Vector)=(1.0,1.0,1.0,5.0)
        [DFVector(1,1,1)]_OrbitRotationNoiseOffset1("Noise 5th Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(1,1,1,2)]_OrbitRotationNoiseScale1("Noise 5th Scale",Vector)=(1.0,1.0,1.0,1.0)
        [Enum(Offset,0,Model,1,World,2,Origin_World,3,Model_World,4,VertexColor,5)]
        _OrbitRotationNoiseSpace("Noise 5th Position Space",Int)=1
        [DFToggle(,0)]_OrbitRotationNoiseOffsetBeforeScale("Noise 5th Offset before Scale",Int)=0
        _OrbitRotationNoiseSeed("Noise 5th Seed",Float)=2.0
        _OrbitRotationNoiseTimeSpeed("Noise 5th Time Speed",Float)=3.0
        _OrbitRotationNoiseTimePhase("Noise 5th Time Phase",Float)=0.0
        _OrbitRotationNoiseValueScale("Noise 5th Value Scale",Float)=1.0



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

            #pragma shader_feature_local _ _AUDIOLINK_ENABLE
            #pragma shader_feature_local _ _DIRECTIONALLIGHT_INFLUENCE_ENABLE
            #pragma shader_feature_local _ _AMBIENT_INFLUENCE_ENABLE
            #pragma shader_feature_local _ _LIGHTVOLUMES_ENABLE

            #pragma shader_feature_local _STEREOMERGEMODE_NONE _STEREOMERGEMODE_POSITION _STEREOMERGEMODE_ROTATION _STEREOMERGEMODE_POSITION_ROTATION

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

            #pragma shader_feature_local _ _AUDIOLINK_ENABLE
            #pragma shader_feature_local _ _DIRECTIONALLIGHT_INFLUENCE_ENABLE
            #pragma shader_feature_local _ _AMBIENT_INFLUENCE_ENABLE
            #pragma shader_feature_local _ _LIGHTVOLUMES_ENABLE

            #pragma shader_feature_local _STEREOMERGEMODE_NONE _STEREOMERGEMODE_POSITION _STEREOMERGEMODE_ROTATION _STEREOMERGEMODE_POSITION_ROTATION

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