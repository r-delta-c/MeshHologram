#define FUNC_GEOMETRY_FRAGMENT_PROCESS \
    fragment_value *= fragment_mask; \
    fragment_value += fragment_map; \
    FUNC_GEOMETRY_AUDIOLINK_PROCESS( \
        fragment_value, \
        fragment_al_mask, \
        _FragmentAudioLinkSource, \
        _FragmentAudioLinkVUStrength, \
        _FragmentAudioLinkChronoTensityStrength, \
        _FragmentAudioLinkSpectrumStrength, \
        _FragmentAudioLinkSpectrumMirror, \
        0 \
    ); \
    FUNC_GEOMETRY_MODIFIER_PROCESS( \
        fragment_value, \
        _FragmentPhaseScale, \
        _FragmentLoopMode, \
        _FragmentMidMul, \
        _FragmentMidAdd, \
        _FragmentEaseCurve, \
        _FragmentEaseMode \
    );

#define FUNC_GEOMETRY_COLORING_PROCESS \
    coloring_value *= coloring_mask; \
    coloring_value += coloring_map; \
    FUNC_GEOMETRY_AUDIOLINK_PROCESS( \
        coloring_value, \
        coloring_al_mask, \
        _ColoringAudioLinkSource, \
        _ColoringAudioLinkVUStrength, \
        _ColoringAudioLinkChronoTensityStrength, \
        _ColoringAudioLinkSpectrumStrength, \
        _ColoringAudioLinkSpectrumMirror, \
        0 \
    ); \
    FUNC_GEOMETRY_MODIFIER_PROCESS( \
        coloring_value, \
        _ColoringPhaseScale, \
        _ColoringLoopMode, \
        _ColoringMidMul, \
        _ColoringMidAdd, \
        _ColoringEaseCurve, \
        _ColoringEaseMode \
    );

#if defined(_AUDIOLINK_ENABLE)
    #define FUNC_GEOMETRY_AUDIOLINK_PROCESS(value,al_mask,source,vu_add,chrono,spectrum,mirror,type) \
        [branch]switch(source){ \
            case 1: \
                value += audiolink_vu*vu_add*al_mask; \
                break; \
            case 2: \
                value = value*audiolink_vu*al_mask; \
                break; \
            case 3: \
                value += audiolink_chronotensity*chrono*al_mask; \
                break; \
            case 4: \
                value = MeshHAudioLinkSpectrum(value,mirror,type)*al_mask*spectrum; \
                break; \
            default: \
                break; \
        }
#else
    #define FUNC_GEOMETRY_AUDIOLINK_PROCESS(value,al_mask,source,vu_add,chrono,spectrum,mirror,type) //
#endif

#define FUNC_GEOMETRY_MODIFIER_PROCESS(value,phase_scale,loop_mode,mul,add,curve,ease_mode) \
    value *= phase_scale; \
    value = lerp(value,mod(value,1.0),SELECTOR_MACRO(loop_mode,1)); \
    value = lerp(value,triloop(value),SELECTOR_MACRO(loop_mode,2)); \
    value = ThresholdFormula(value,mul,add); \
    FUNC_EASING_BRANCH(value,curve,ease_mode);

#define FUNC_EASING_BRANCH(value,curve,ease_mode) \
    [branch]switch(ease_mode){ \
        case 0: \
            value = pow(value,curve); \
            break; \
        case 1: \
            value = (1.0-pow(1.0-value,curve)); \
            break; \
        case 2: \
            value = EaseInOutPow(value,curve); \
            break; \
        case 3: \
            value = EaseInvertInOutPow(value,curve); \
            break; \
        default: \
            break; \
    } \
    value = saturate(value);

#define FUNC_NOISE_CENTER_POS(pos) noise_center_pos = ((inp[0].pos+inp[1].pos+inp[2].pos)/3.0)

#define FUNC_NOISE_VERTEX_VALUE(pos,seed,scale,time) \
    (float3( \
        ValueNoise3D(inp[0].pos,seed), \
        ValueNoise3D(inp[1].pos,seed), \
        ValueNoise3D(inp[2].pos,seed) \
    )*scale+time)

#define FUNC_NOISE_SIDE_VALUE(pos,center,seed,scale,time) \
    (float3( \
        ValueNoise3D(SideCenterPos(inp[1].pos,inp[2].pos,inp[0].pos,center),seed), \
        ValueNoise3D(SideCenterPos(inp[2].pos,inp[0].pos,inp[1].pos,center),seed), \
        ValueNoise3D(SideCenterPos(inp[0].pos,inp[1].pos,inp[2].pos,center),seed) \
    )*scale+time)

#define FUNC_NOISE_BIAS_VALUE(pos,center,seed,scale,time,bias) \
    (float3( \
        ValueNoise3D(VertexCenterBias(inp[1].pos,inp[2].pos,inp[0].pos,center,bias),seed), \
        ValueNoise3D(VertexCenterBias(inp[2].pos,inp[0].pos,inp[1].pos,center,bias),seed), \
        ValueNoise3D(VertexCenterBias(inp[0].pos,inp[1].pos,inp[2].pos,center,bias),seed) \
    )*scale+time)