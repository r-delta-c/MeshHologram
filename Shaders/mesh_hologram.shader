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
        _BillboardMode("Billboard Mode(Feature)",Int)=0
        _DistanceInfluence("Distance Influence",Range(0.0,1.0))=1.0
        [KeywordEnum(None,Position,Rotation,Position_Rotation)]
        _StereoMergeMode("Stereo Merge Mode(Feature)",Int)=2
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
        _PreviewMode("Preview Mode(Feature)",Int)=0
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
        [IntRange]_AudioLinkVUSmooth("VU Smooth",Range(0,15))=0
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


        _TriangleComp("Triangle Compression",Float)=5.0
        [MaterialToggle]_Fill("Fill",Float)=0.0
        _LineWidth("Line Width",Float)=2.0
        _LineGradientBias("Line Gradient Bias",Range(-1.0,1.0))=0.0
        [Toggle(_MANUAL_LINE_SCALING)]
        _ManualLineScaling("Manual Line Scaling",Int)=0.0
        _LineScale("Line Scale",Float)=1.0
        [KeywordEnum(Normal,Instant,ZoomIn,ZoomOut,PowerZoomIn,Collapse,Break,OutWide,OutThin,Vanishing,Join1,Join2,Join3)]
        _LineFadeMode("Line Fade Mode",Int)=0
        [KeywordEnum(Value,Noise1st,Noise2nd,Noise3rd,AudioLink_VU,AudioLink_ChronoTensity)]
        _FragmentSource("Fragment Source",Int)=1
        _FragmentValue("Fragment Value",Range(0.0,1.0))=1.0
        [MaterialToggle]_FragmentInverse("Fragment Inverse",Int)=0
        [KeywordEnum(Vertex,Side,Mesh)]
        _PartitionType("Partition Type",Int)=1


        _Color0("Primary Color",Color)=(1.0,1.0,1.0,1.0)
        _Color1("Secondary Color",Color)=(0.2,0.2,0.2,1.0)
        _Emission("Add Emission",Float)=0.0
        [KeywordEnum(Gradient,Primary,GradientTex,VertexColor,UniqueSides,AudioLink_ThemeColor)]
        _ColorSource("Color Source",Int)=0
        _ColorGradientTex("Gradient Tex",2D)="white"{}
        [KeywordEnum(Value,Noise1st,Noise2nd,Noise3rd,AudioLink_VU,AudioLink_ChronoTensity)]
        _ColoringSource("Coloring Source",Int)=2
        _ColoringValue("Coloring Value",Range(0.0,1.0))=0.0
        [KeywordEnum(Vertex,Side,Mesh)]
        _ColoringPartitionType("Coloring Partition Type",Int)=1


        [KeywordEnum(Value,Noise1st,Noise2nd,Noise3rd,AudioLink_VU,AudioLink_ChronoTensity)]
        _GeometrySource("Geometry Source",Int)=3
        _GeometryValue("Geometry Value",Range(0.0,1.0))=0.0

        [DFToggle(_GEOMETRY_SCALE,1)]
        _GeometryScale("Activate Scale",Int)=0
        [DFVector(2)]_GeometryScaleRange("Scale Range",Vector)=(0.5,0.0,0.0,0.0)

        [DFToggle(_GEOMETRY_EXTRUDE,1)]
        _GeometryExtrude("Activate Extrude",Int)=1
        [DFVector(2)]_GeometryExtrudeRange("Extrude Range",Vector)=(-0.15,0.0,0.0,0.0)

        [DFToggle(_GEOMETRY_ROTATION,1)]
        _GeometryRotation("Activate Rotation",Int)=0
        [MaterialToggle(_GEOMETRY_ROTATION_REVERSE)]
        _GeometryRotationReverse("Rotation Reverse",Int)=0
        [Toggle(_GEOMETRY_ROTATION_NOISE_REPEAT)]
        _GeometryRotationNoiseRepeat("Rotation Noise Repeat",Int)=0

        _GeometryPartitionBias("Geometry Partition Bias| Vertex <=> Center",Range(0.0,1.0))=0.5
        [KeywordEnum(Disable,Model,World,PostGeometry)]
        _PixelizationSpace("Vertex Pixelization Position Space",Int)=0
        [DFVector(3,1)]_Pixelization("Vertex Pixelization",Vector)=(1.0,1.0,1.0,0.02)

        [DFToggle(_ACTIVATE_ORBIT,1)]
        _ActivateOrbit("Activate Orbit",Int)=0
        [KeywordEnum(Value,Primitive,Noise1st,Noise2nd,Noise3rd)]
        _OrbitSource("Orbit Source",Int)=3
        _OrbitValue("Orbit Value",Range(0.0,1.0))=0.0
        _OrbitSeed("Orbit Seed",Float)=0.0

        [KeywordEnum(Value,Primitive,Noise1st,Noise2nd,Noise3rd)]
        _OrbitRotationSource("Orbit Rotation Source",Int)=1
        _OrbitRotationValue("Orbit Rotation Value",Range(0.0,1.0))=0.0
        _OrbitRotationSeed("Orbit Rotation Seed",Float)=0.0
        [DFVector(3)]_OrbitOffset("Orbit Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(2,1)]_OrbitScale("Orbit Scale",Vector)=(1.0,1.0,1.0)
        [DFVector(1,2)]_OrbitRotation("Orbit Rotation",Vector)=(0.0,0.0,0.0,0.0)

        _OrbitRotationTimeMultiplier("Orbit Rotation Time Multiplier",Vector)=(4.0,2.0,0.0,1.0)

        _OrbitRotationVariance("Orbit Rotation Variance",Vector)=(1.0,0.0,0.0,1.0)

        _OrbitWaveXYStrength("Orbit Wave XY Strength",Float)=0.0
        _OrbitWaveXYFrequency("Orbit Wave XY Frequency",Float)=0.0
        _OrbitWaveXYPhase("Orbit Wave XY Phase",Float)=0.0
        _OrbitWaveXYTimeMultiplier("Orbit Wave XY Time Multiplier",Float)=1.0
        _OrbitWaveZStrength("Orbit Wave Z Strength",Float)=0.0
        _OrbitWaveZFrequency("Orbit Wave Z Frequency",Float)=0.0
        _OrbitWaveZPhase("Orbit Wave Z Phase",Float)=0.0
        _OrbitWaveZTimeMultiplier("Orbit Wave Z Time Multiplier",Float)=1.0

        [KeywordEnum(Disable,VU,ChronoTensity)]
        _OrbitRotationRefAudioLink("Orbit Rotation Reference AudioLink",Int)=0
        _OrbitRotationAudioLinkStrength("Orbit Rotation AudioLink Strength",Vector)=(1.0,0.0,0.0,1.0)

        [KeywordEnum(Disable,VU,Wave)]
        _OrbitWaveRefAudioLink("Orbit Wave Reference AudioLink",Int)=0
        _OrbitWaveAudioLinkStrength("Orbit Wave AudioLink Strength",Vector)=(1.0,1.0,1.0,1.0)
        [MaterialToggle]_OrbitWaveAudioLinkSpectrumMirror("AudioLink Wave Mirror",Int)=0.0
        [MaterialToggle]_OrbitWaveAudioLinkSpectrumType("AudioLink Wave Type",Int)=0.0
        [DFVector(2)]_OrbitWaveAudioLinkSpectrumRange("AudioLink Wave Range",Vector)=(-1.0,1.0,0.0,0.0)


        _AudioLinkMaskControlTex("AudioLink Mask Control Tex",2D)="white"{}
        _AudioLinkMaskControl("AudioLink Mask Control Strength",Range(0.0,1.0))=1.0
        _FragmentMaskControlTex("Fragment Mask Control Tex",2D)="white"{}
        _FragmentMaskControl("Fragment Mask Control Strength",Range(0.0,1.0))=1.0
        _ColoringMaskControlTex("Coloring Mask Control Tex",2D)="white"{}
        _ColoringMaskControl("Coloring Mask Control Strength",Range(0.0,1.0))=1.0
        _GeometryMaskControlTex("Geometry Mask Control Tex",2D)="white"{}
        _GeometryMaskControl("Geometry Mask Control Strength",Range(0.0,1.0))=1.0
        _OrbitMaskControlTex("Orbit Mask Control Tex",2D)="white"{}
        _OrbitMaskControl("Orbit Mask Control Strength",Range(0.0,1.0))=1.0
        _Noise1stOffsetControlTex("Noise 1st Offset Control Tex",2D)="white"{}
        _Noise1stOffsetControl("Noise 1st Phase Offset Control Strength",Range(0.0,1.0))=1.0
        _Noise2ndOffsetControlTex("Noise 2nd Offset Control Tex",2D)="white"{}
        _Noise2ndOffsetControl("Noise 2nd Phase Offset Control Strength",Range(0.0,1.0))=1.0
        _Noise3rdOffsetControlTex("Noise 3rd Control Tex",2D)="white"{}
        _Noise3rdOffsetControl("Noise 3rd Phase Offset Control Strength",Range(0.0,1.0))=1.0



        [DFToggle(_FRAGMENT_AUDIOLINK_NOISE_SPECTRUM,1)]
        _FragmentAudioLinkNoiseSpectrum("Fragment AudioLink Noise Spectrum",Int)=0
        _FragmentAudioLinkStrength("Strength",Float)=1.0
        [MaterialToggle]_FragmentAudioLinkSpectrumMirror("Noise Wave Mirror",Int)=0.0
        [MaterialToggle]_FragmentAudioLinkSpectrumType("Noise Wave Type",Int)=0.0
        [DFVector(2)]_FragmentAudioLinkSpectrumRange("Noise Wave Range",Vector)=(-1.0,1.0,0.0,0.0)

        [DFToggle(_COLORING_AUDIOLINK_NOISE_SPECTRUM,1)]
        _ColoringAudioLinkNoiseSpectrum("Coloring AudioLink Noise Spectrum",Int)=0
        _ColoringAudioLinkStrength("Strength",Float)=1.0
        [MaterialToggle]_ColoringAudioLinkSpectrumMirror("Noise Wave Mirror",Int)=0.0
        [MaterialToggle]_ColoringAudioLinkSpectrumType("Noise Wave Type",Int)=0.0
        [DFVector(2)]_ColoringAudioLinkSpectrumRange("Noise Wave Range",Vector)=(-1.0,1.0,0.0,0.0)

        [DFToggle(_GEOMETRY_AUDIOLINK_NOISE_SPECTRUM,1)]
        _GeometryAudioLinkNoiseSpectrum("Geometry AudioLink Noise Spectrum",Int)=0
        _GeometryAudioLinkStrength("Strength",Float)=1.0
        [MaterialToggle]_GeometryAudioLinkSpectrumMirror("Noise Wave Mirror",Int)=0.0
        [MaterialToggle]_GeometryAudioLinkSpectrumType("Noise Wave Type",Int)=0.0
        [DFVector(2)]_GeometryAudioLinkSpectrumRange("Noise Wave Range",Vector)=(-1.0,1.0,0.0,0.0)


        [DFVector(3)]_Noise1stOffset0("Noise 1st Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(3,1)]_Noise1stScale0("Noise 1st Scale",Vector)=(1.0,1.0,1.0,3.0)
        [DFVector(3)]_Noise1stOffset1("Noise 1st Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(3,1)]_Noise1stScale1("Noise 1st Scale Sub",Vector)=(1.0,1.0,1.0,1.0)
        [Toggle(_NOISE1ST_OFFSET_BEFORE_SCALE)]
        _Noise1stOffsetBeforeScale("Noise 1st Offset before Scale",Int)=0
        [KeywordEnum(Offset,Model,World,Origin_World,Model_World,VertexColor)]
        _Noise1stSpace("Noise 1st Position Space",Int)=1

        _Noise1stSeed("Noise 1st Seed",Float)=0.0
        _Noise1stValueCurve("Noise 1st Value Curve",Float)=0.5
        [MaterialToggle]_Noise1stCurveType("Noise 1st Curve Type",Int)=1
        _Noise1stThresholdMul("Noise 1st Threshold(Multiple)",Float)=1.0
        _Noise1stThresholdAdd("Noise 1st Threshold(Addition)",Range(-0.5,0.5))=0.0

        _Noise1stTimeMulti("Noise 1st Time Multiplier",Float)=3.0
        _Noise1stTimePhase("Noise 1st Time Phase",Float)=0.0
        _Noise1stPhaseScale("Noise 1st Phase Scale",Float)=3.0
        [KeywordEnum(Disable,VU,ChronoTensity)]
        _Noise1stPhaseRefAudioLink("Noise 1st Phase Reference AudioLink",Int)=0


        [DFVector(3)]_Noise2ndOffset0("Noise 2nd Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(3,1)]_Noise2ndScale0("Noise 2nd Scale",Vector)=(1.0,1.0,1.0,5.0)
        [DFVector(3)]_Noise2ndOffset1("Noise 2nd Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(3,1)]_Noise2ndScale1("Noise 2nd Scale",Vector)=(1.0,1.0,1.0,1.0)
        [Toggle(_NOISE2ND_OFFSET_BEFORE_SCALE)]
        _Noise2ndOffsetBeforeScale("Noise 2nd Offset before Scale",Int)=0
        [KeywordEnum(Offset,Model,World,Origin_World,Model_World,VertexColor)]
        _Noise2ndSpace("Noise 2nd Position Space",Int)=1

        _Noise2ndSeed("Noise 2nd Seed",Float)=1.0
        _Noise2ndValueCurve("Noise 2nd Value Curve",Float)=1.0
        [MaterialToggle]_Noise2ndCurveType("Noise 2nd Curve Type",Int)=1
        _Noise2ndThresholdMul("Noise 2nd Threshold(Multiple)",Float)=1.0
        _Noise2ndThresholdAdd("Noise 2nd Threshold(Addition)",Range(-0.5,0.5))=0.0

        _Noise2ndTimeMulti("Noise 2nd Time Multiplier",Float)=5.0
        _Noise2ndTimePhase("Noise 2nd Time Phase",Float)=0.0
        _Noise2ndPhaseScale("Noise 2nd Phase Scale",Float)=3.0

        [KeywordEnum(Disable,VU,ChronoTensity)]
        _Noise2ndPhaseRefAudioLink("Noise 2nd Phase Reference AudioLink",Int)=0


        [DFVector(3)]_Noise3rdOffset0("Noise 3rd Offset",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(3,1)]_Noise3rdScale0("Noise 3rd Scale",Vector)=(1.0,1.0,1.0,5.0)
        [DFVector(3)]_Noise3rdOffset1("Noise 3rd Offset Sub",Vector)=(0.0,0.0,0.0,0.0)
        [DFVector(3,1)]_Noise3rdScale1("Noise 3rd Scale",Vector)=(1.0,1.0,1.0,1.0)
        [Toggle(_NOISE3RD_OFFSET_BEFORE_SCALE)]
        _Noise3rdOffsetBeforeScale("Noise 3rd Offset before Scale",Int)=0
        [KeywordEnum(Offset,Model,World,Origin_World,Model_World,VertexColor)]
        _Noise3rdSpace("Noise 3rd Position Space",Int)=1

        _Noise3rdSeed("Noise 3rd Seed",Float)=2.0
        _Noise3rdValueCurve("Noise 3rd Value Curve",Float)=3.0
        [MaterialToggle]_Noise3rdCurveType("Noise 3rd Curve Type",Int)=0
        _Noise3rdThresholdMul("Noise 3rd Threshold(Multiple)",Float)=3.0
        _Noise3rdThresholdAdd("Noise 3rd Threshold(Addition)",Range(-0.5,0.5))=0.0

        _Noise3rdTimeMulti("Noise 3rd Time Multiplier",Float)=3.0
        _Noise3rdTimePhase("Noise 3rd Time Phase",Float)=0.0
        _Noise3rdPhaseScale("Noise 3rd Phase Scale",Float)=3.0

        [KeywordEnum(Disable,VU,ChronoTensity)]
        _Noise3rdPhaseRefAudioLink("Noise 3rd Phase Reference AudioLink",Int)=0
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

            #pragma shader_feature_local _ _ACTIVATE_DIRECTIONALLIGHT_INFLUENCE
            #pragma shader_feature_local _ _ACTIVATE_AMBIENT_INFLUENCE
            #pragma shader_feature_local _ _ACTIVATE_LIGHTVOLUMES

            #pragma shader_feature_local _STEREOMERGEMODE_NONE _STEREOMERGEMODE_POSITION _STEREOMERGEMODE_ROTATION _STEREOMERGEMODE_POSITION_ROTATION

            #pragma shader_feature_local _LINEFADEMODE_NORMAL _LINEFADEMODE_INSTANT _LINEFADEMODE_OUTWIDE _LINEFADEMODE_OUTTHIN _LINEFADEMODE_BREAK _LINEFADEMODE_VANISHING _LINEFADEMODE_ZOOMIN _LINEFADEMODE_ZOOMOUT _LINEFADEMODE_POWERZOOMIN _LINEFADEMODE_COLLAPSE _LINEFADEMODE_JOIN1 _LINEFADEMODE_JOIN2 _LINEFADEMODE_JOIN3


            #pragma shader_feature_local _ _MANUAL_LINE_SCALING
            #pragma shader_feature_local _FRAGMENTSOURCE_VALUE _FRAGMENTSOURCE_NOISE1ST _FRAGMENTSOURCE_NOISE2ND _FRAGMENTSOURCE_NOISE3RD _FRAGMENTSOURCE_AUDIOLINK_VU _FRAGMENTSOURCE_AUDIOLINK_CHRONOTENSITY
            #pragma shader_feature_local _PARTITIONTYPE_VERTEX _PARTITIONTYPE_SIDE _PARTITIONTYPE_MESH

            #pragma shader_feature_local _COLORSOURCE_GRADIENT _COLORSOURCE_PRIMARY _COLORSOURCE_GRADIENTTEX _COLORSOURCE_VERTEXCOLOR _COLORSOURCE_UNIQUESIDES _COLORSOURCE_AUDIOLINK_THEMECOLOR
            #pragma shader_feature_local _COLORINGSOURCE_VALUE _COLORINGSOURCE_NOISE1ST _COLORINGSOURCE_NOISE2ND _COLORINGSOURCE_NOISE3RD _COLORINGSOURCE_AUDIOLINK_VU _COLORINGSOURCE_AUDIOLINK_CHRONOTENSITY
            #pragma shader_feature_local _COLORINGPARTITIONTYPE_VERTEX _COLORINGPARTITIONTYPE_SIDE _COLORINGPARTITIONTYPE_MESH

            #pragma shader_feature_local _GEOMETRYSOURCE_VALUE _GEOMETRYSOURCE_NOISE1ST _GEOMETRYSOURCE_NOISE2ND _GEOMETRYSOURCE_NOISE3RD _GEOMETRYSOURCE_AUDIOLINK_VU _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
            #pragma shader_feature_local _ _GEOMETRY_SCALE
            #pragma shader_feature_local _ _GEOMETRY_EXTRUDE
            #pragma shader_feature_local _ _GEOMETRY_ROTATION
            #pragma shader_feature_local _ _GEOMETRY_ROTATION_NOISE_REPEAT

            #pragma shader_feature_local _ _ACTIVATE_ORBIT
            #pragma shader_feature_local _ORBITSOURCE_VALUE _ORBITSOURCE_PRIMITIVE _ORBITSOURCE_NOISE1ST _ORBITSOURCE_NOISE2ND _ORBITSOURCE_NOISE3RD
            #pragma shader_feature_local _ORBITROTATIONSOURCE_VALUE _ORBITROTATIONSOURCE_PRIMITIVE _ORBITROTATIONSOURCE_NOISE1ST _ORBITROTATIONSOURCE_NOISE2ND _ORBITROTATIONSOURCE_NOISE3RD

            #pragma shader_feature_local _ _FRAGMENT_AUDIOLINK_NOISE_SPECTRUM
            #pragma shader_feature_local _ _COLORING_AUDIOLINK_NOISE_SPECTRUM
            #pragma shader_feature_local _ _GEOMETRY_AUDIOLINK_NOISE_SPECTRUM


            #pragma shader_feature_local _ORBITROTATIONREFAUDIOLINK_DISABLE _ORBITROTATIONREFAUDIOLINK_VU _ORBITROTATIONREFAUDIOLINK_CHRONOTENSITY

            #pragma shader_feature_local _ORBITWAVEREFAUDIOLINK_DISABLE _ORBITWAVEREFAUDIOLINK_VU _ORBITWAVEREFAUDIOLINK_SPECTRUM

            #pragma shader_feature_local _PIXELIZATIONSPACE_DISABLE _PIXELIZATIONSPACE_MODEL _PIXELIZATIONSPACE_WORLD _PIXELIZATIONSPACE_POSTGEOMETRY



            #pragma shader_feature_local _NOISE1STSPACE_OFFSET _NOISE1STSPACE_MODEL _NOISE1STSPACE_WORLD _NOISE1STSPACE_ORIGIN_WORLD _NOISE1STSPACE_MODEL_WORLD _NOISE1STSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE1ST_OFFSET_BEFORE_SCALE
            #pragma shader_feature_local _NOISE1STPHASEREFAUDIOLINK_DISABLE _NOISE1STPHASEREFAUDIOLINK_VU _NOISE1STPHASEREFAUDIOLINK_CHRONOTENSITY

            #pragma shader_feature_local _NOISE2NDSPACE_OFFSET _NOISE2NDSPACE_MODEL _NOISE2NDSPACE_WORLD _NOISE2NDSPACE_ORIGIN_WORLD _NOISE2NDSPACE_MODEL_WORLD _NOISE2NDSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE2ND_OFFSET_BEFORE_SCALE
            #pragma shader_feature_local _NOISE2NDPHASEREFAUDIOLINK_DISABLE _NOISE2NDPHASEREFAUDIOLINK_VU _NOISE2NDPHASEREFAUDIOLINK_CHRONOTENSITY

            #pragma shader_feature_local _NOISE3RDSPACE_OFFSET _NOISE3RDSPACE_MODEL _NOISE3RDSPACE_WORLD _NOISE3RDSPACE_ORIGIN_WORLD _NOISE3RDSPACE_MODEL_WORLD _NOISE3RDSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE3RD_OFFSET_BEFORE_SCALE
            #pragma shader_feature_local _NOISE3RDPHASEREFAUDIOLINK_DISABLE _NOISE3RDPHASEREFAUDIOLINK_VU _NOISE3RDPHASEREFAUDIOLINK_CHRONOTENSITY

            #pragma shader_feature_local _ _USE_FWIDTH

            #pragma shader_feature_local _ _RENDERINGMODE_CUTOUT

            #include "AutoLight.cginc"

            #include "Packages/com.deltafield.meshhologram/Includes/macro_noise.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_thirdparties.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_general.hlsl"
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
            #pragma shader_feature_local _FRAGMENTSOURCE_VALUE _FRAGMENTSOURCE_NOISE1ST _FRAGMENTSOURCE_NOISE2ND _FRAGMENTSOURCE_NOISE3RD _FRAGMENTSOURCE_AUDIOLINK_VU _FRAGMENTSOURCE_AUDIOLINK_CHRONOTENSITY
            #pragma shader_feature_local _PARTITIONTYPE_VERTEX _PARTITIONTYPE_SIDE _PARTITIONTYPE_MESH

            #pragma shader_feature_local _COLORSOURCE_GRADIENT _COLORSOURCE_PRIMARY _COLORSOURCE_GRADIENTTEX _COLORSOURCE_VERTEXCOLOR _COLORSOURCE_UNIQUESIDES _COLORSOURCE_AUDIOLINK_THEMECOLOR
            #pragma shader_feature_local _COLORINGSOURCE_VALUE _COLORINGSOURCE_NOISE1ST _COLORINGSOURCE_NOISE2ND _COLORINGSOURCE_NOISE3RD _COLORINGSOURCE_AUDIOLINK_VU _COLORINGSOURCE_AUDIOLINK_CHRONOTENSITY
            #pragma shader_feature_local _COLORINGPARTITIONTYPE_VERTEX _COLORINGPARTITIONTYPE_SIDE _COLORINGPARTITIONTYPE_MESH

            #pragma shader_feature_local _GEOMETRYSOURCE_VALUE _GEOMETRYSOURCE_NOISE1ST _GEOMETRYSOURCE_NOISE2ND _GEOMETRYSOURCE_NOISE3RD _GEOMETRYSOURCE_AUDIOLINK_VU _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
            #pragma shader_feature_local _ _GEOMETRY_SCALE
            #pragma shader_feature_local _ _GEOMETRY_EXTRUDE
            #pragma shader_feature_local _ _GEOMETRY_ROTATION
            #pragma shader_feature_local _ _GEOMETRY_ROTATION_NOISE_REPEAT

            #pragma shader_feature_local _ _ACTIVATE_ORBIT
            #pragma shader_feature_local _ORBITSOURCE_VALUE _ORBITSOURCE_PRIMITIVE _ORBITSOURCE_NOISE1ST _ORBITSOURCE_NOISE2ND _ORBITSOURCE_NOISE3RD
            #pragma shader_feature_local _ORBITROTATIONSOURCE_VALUE _ORBITROTATIONSOURCE_PRIMITIVE _ORBITROTATIONSOURCE_NOISE1ST _ORBITROTATIONSOURCE_NOISE2ND _ORBITROTATIONSOURCE_NOISE3RD

            #pragma shader_feature_local _ORBITROTATIONREFAUDIOLINK_DISABLE _ORBITROTATIONREFAUDIOLINK_VU _ORBITROTATIONREFAUDIOLINK_CHRONOTENSITY

            #pragma shader_feature_local _ORBITWAVEREFAUDIOLINK_DISABLE _ORBITWAVEREFAUDIOLINK_VU _ORBITWAVEREFAUDIOLINK_SPECTRUM

            #pragma shader_feature_local _PIXELIZATIONSPACE_DISABLE _PIXELIZATIONSPACE_MODEL _PIXELIZATIONSPACE_WORLD _PIXELIZATIONSPACE_POSTGEOMETRY


            #pragma shader_feature_local _ _FRAGMENT_AUDIOLINK_NOISE_SPECTRUM
            #pragma shader_feature_local _ _COLORING_AUDIOLINK_NOISE_SPECTRUM
            #pragma shader_feature_local _ _GEOMETRY_AUDIOLINK_NOISE_SPECTRUM


            #pragma shader_feature_local _NOISE1STSPACE_OFFSET _NOISE1STSPACE_MODEL _NOISE1STSPACE_WORLD _NOISE1STSPACE_ORIGIN_WORLD _NOISE1STSPACE_MODEL_WORLD _NOISE1STSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE1ST_OFFSET_BEFORE_SCALE
            #pragma shader_feature_local _NOISE1STPHASEREFAUDIOLINK_DISABLE _NOISE1STPHASEREFAUDIOLINK_VU _NOISE1STPHASEREFAUDIOLINK_CHRONOTENSITY

            #pragma shader_feature_local _NOISE2NDSPACE_OFFSET _NOISE2NDSPACE_MODEL _NOISE2NDSPACE_WORLD _NOISE2NDSPACE_ORIGIN_WORLD _NOISE2NDSPACE_MODEL_WORLD _NOISE2NDSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE2ND_OFFSET_BEFORE_SCALE
            #pragma shader_feature_local _NOISE2NDPHASEREFAUDIOLINK_DISABLE _NOISE2NDPHASEREFAUDIOLINK_VU _NOISE2NDPHASEREFAUDIOLINK_CHRONOTENSITY

            #pragma shader_feature_local _NOISE3RDSPACE_OFFSET _NOISE3RDSPACE_MODEL _NOISE3RDSPACE_WORLD _NOISE3RDSPACE_ORIGIN_WORLD _NOISE3RDSPACE_MODEL_WORLD _NOISE3RDSPACE_VERTEXCOLOR
            #pragma shader_feature_local _ _NOISE3RD_OFFSET_BEFORE_SCALE
            #pragma shader_feature_local _NOISE3RDPHASEREFAUDIOLINK_DISABLE _NOISE3RDPHASEREFAUDIOLINK_VU _NOISE3RDPHASEREFAUDIOLINK_CHRONOTENSITY

            #pragma shader_feature_local _ _USE_FWIDTH

            #pragma shader_feature_local _ _RENDERINGMODE_CUTOUT

            #include "Packages/com.deltafield.meshhologram/Includes/macro_noise.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_thirdparties.hlsl"
            #include "Packages/com.deltafield.meshhologram/Includes/macro_general.hlsl"
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