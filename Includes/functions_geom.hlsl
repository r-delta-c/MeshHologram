[maxvertexcount(3)]
void geom(triangle v2f inp[3], uint id:SV_PRIMITIVEID, inout TriangleStream<g2f> stream){
    g2f o;
    UNITY_INITIALIZE_OUTPUT(g2f,o);
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(inp[0])
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(inp[1])
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(inp[2])

    float3 scale = float3(
        length(UNITY_MATRIX_M._m00_m01_m02),
        length(UNITY_MATRIX_M._m10_m11_m12),
        length(UNITY_MATRIX_M._m20_m21_m22)
    );

    // CONTROL
        float2 transform_uv[3];
        float2 transform_pushpull_uv[3];
        float2 uv_mesh;

        TRANSFORM_TEX_MACRO(_FragmentMaskMap);
        float3 fragment_mask = MASK_CONTROL_MACRO3(_FragmentMaskMap,_point_repeat,_FragmentMaskMapStrength);
        TRANSFORM_TEX_MACRO(_FragmentMap);
        float3 fragment_map = OFFSET_CONTROL_MACRO3(_FragmentMap,_point_repeat,_FragmentMapStrength);

        TRANSFORM_TEX_MACRO(_ColoringMaskMap);
        float3 coloring_mask = MASK_CONTROL_MACRO3(_ColoringMaskMap,_point_repeat,_ColoringMaskMapStrength);
        TRANSFORM_TEX_MACRO(_ColoringMap);
        float3 coloring_map = OFFSET_CONTROL_MACRO3(_ColoringMap,_point_repeat,_ColoringMapStrength);

        TRANSFORM_TEX_MACRO(_GeometryMaskMap);
        UV_MESH_MACRO;
        float3 geometry_mask = MASK_CONTROL_MACRO3_MESH(_GeometryMaskMap,_point_repeat,_GeometryMaskMapStrength);
        transform_pushpull_uv[0] = VertexCenterBias(transform_uv[1],transform_uv[2],transform_uv[0],uv_mesh,_GeometryPushPullPartitionBias);
        transform_pushpull_uv[1] = VertexCenterBias(transform_uv[2],transform_uv[0],transform_uv[1],uv_mesh,_GeometryPushPullPartitionBias);
        transform_pushpull_uv[2] = VertexCenterBias(transform_uv[0],transform_uv[1],transform_uv[2],uv_mesh,_GeometryPushPullPartitionBias);
        float3 geometry_pushpull_mask = MASK_CONTROL_MACRO3_UV(_GeometryMaskMap,_point_repeat,_GeometryMaskMapStrength,transform_pushpull_uv);

        TRANSFORM_TEX_MACRO(_GeometryMap);
        UV_MESH_MACRO;
        float3 geometry_map = OFFSET_CONTROL_MACRO3_MESH(_GeometryMap,_point_repeat,_GeometryMapStrength);
        transform_pushpull_uv[0] = VertexCenterBias(transform_uv[1],transform_uv[2],transform_uv[0],uv_mesh,_GeometryPushPullPartitionBias);
        transform_pushpull_uv[1] = VertexCenterBias(transform_uv[2],transform_uv[0],transform_uv[1],uv_mesh,_GeometryPushPullPartitionBias);
        transform_pushpull_uv[2] = VertexCenterBias(transform_uv[0],transform_uv[1],transform_uv[2],uv_mesh,_GeometryPushPullPartitionBias);
        float3 geometry_pushpull_map = OFFSET_CONTROL_MACRO3_UV(_GeometryMap,_point_repeat,_GeometryMapStrength,transform_pushpull_uv);

        TRANSFORM_TEX_MACRO(_OrbitMaskMap);
        UV_MESH_MACRO;
        float3 orbit_mask = MASK_CONTROL_MACRO3_MESH(_OrbitMaskMap,_point_repeat,_OrbitMaskMapStrength);
        TRANSFORM_TEX_MACRO(_OrbitMap);
        UV_MESH_MACRO;
        float3 orbit_map = OFFSET_CONTROL_MACRO3_MESH(_OrbitMap,_point_repeat,_OrbitMapStrength);

        TRANSFORM_TEX_MACRO(_OrbitRotationMaskMap);
        UV_MESH_MACRO;
        float3 orbit_rotation_mask = MASK_CONTROL_MACRO3_MESH(_OrbitRotationMaskMap,_point_repeat,_OrbitRotationMaskMapStrength);
        TRANSFORM_TEX_MACRO(_OrbitRotationMap);
        UV_MESH_MACRO;
        float3 orbit_rotation_map = OFFSET_CONTROL_MACRO3_MESH(_OrbitRotationMap,_point_repeat,_OrbitRotationMapStrength);

        TRANSFORM_TEX_MACRO(_OrbitRotationOffsetMaskMap);
        UV_MESH_MACRO;
        float3 orbit_rotation_offset_mask = MASK_CONTROL_MACRO3_MESH(_OrbitRotationOffsetMaskMap,_point_repeat,1.0);
        orbit_rotation_offset_mask = orbit_rotation_offset_mask*_OrbitRotationOffsetMaskMapStrength.xyz*_OrbitRotationOffsetMaskMapStrength.w;

        #if defined(_AUDIOLINK_ENABLE)
            TRANSFORM_TEX_MACRO(_FragmentAudioLinkMaskMap);
            float3 fragment_al_mask = MASK_CONTROL_MACRO3(_FragmentAudioLinkMaskMap,_point_repeat,_FragmentAudioLinkMaskMapStrength);
            TRANSFORM_TEX_MACRO(_ColoringAudioLinkMaskMap);
            float3 coloring_al_mask = MASK_CONTROL_MACRO3(_ColoringAudioLinkMaskMap,_point_repeat,_ColoringAudioLinkMaskMapStrength);
            TRANSFORM_TEX_MACRO(_GeometryAudioLinkMaskMap);
            UV_MESH_MACRO;
            float3 geometry_al_mask = MASK_CONTROL_MACRO3_MESH(_GeometryAudioLinkMaskMap,_point_repeat,_GeometryAudioLinkMaskMapStrength);
            transform_pushpull_uv[0] = VertexCenterBias(transform_uv[1],transform_uv[2],transform_uv[0],uv_mesh,_GeometryPushPullPartitionBias);
            transform_pushpull_uv[1] = VertexCenterBias(transform_uv[2],transform_uv[0],transform_uv[1],uv_mesh,_GeometryPushPullPartitionBias);
            transform_pushpull_uv[2] = VertexCenterBias(transform_uv[0],transform_uv[1],transform_uv[2],uv_mesh,_GeometryPushPullPartitionBias);
            float3 geometry_pushpull_al_mask = MASK_CONTROL_MACRO3_UV(_GeometryAudioLinkMaskMap,_point_repeat,_GeometryAudioLinkMaskMapStrength,transform_pushpull_uv);
            TRANSFORM_TEX_MACRO(_OrbitAudioLinkMaskMap);
            UV_MESH_MACRO;
            float3 orbit_al_mask = MASK_CONTROL_MACRO3_MESH(_OrbitAudioLinkMaskMap,_point_repeat,_OrbitAudioLinkMaskMapStrength);
            TRANSFORM_TEX_MACRO(_OrbitRotationOffsetAudioLinkMaskMap);
            UV_MESH_MACRO;
            float3 orbit_rotation_offset_al_mask = MASK_CONTROL_MACRO3_MESH(_OrbitRotationOffsetAudioLinkMaskMap,_point_repeat,1.0);
            orbit_rotation_offset_al_mask = orbit_rotation_offset_al_mask*_OrbitRotationOffsetAudioLinkMaskMapStrength.xyz*_OrbitRotationOffsetAudioLinkMaskMapStrength.w;
        #endif



    #if defined(_AUDIOLINK_ENABLE)
        float4 audiolink_vu_band = lerp(AudioLinkData(ALPASS_FILTEREDAUDIOLINK+uint2(_AudioLinkVUSmoothing,_AudioLinkVUBand)),AudioLinkData(ALPASS_FILTEREDVU_INTENSITY),max(0.0,_AudioLinkVUBand-3.0));
        float audiolink_vu = saturate(lerp(audiolink_vu_band.r,audiolink_vu_band.b,_AudioLinkVUPanning)*_AudioLinkVUGainMul+_AudioLinkVUGainAdd);
        float audiolink_chronotensity = (AudioLinkDecodeDataAsUInt(ALPASS_CHRONOTENSITY+uint2(_AudioLinkChronoTensityMode,_AudioLinkChronoTensityBand)).r/_AudioLinkChronoTensityDivisor);
    #endif


    // NOISE
        float3 noise1st_center_pos = (inp[0].noise1st_pos+inp[1].noise1st_pos+inp[2].noise1st_pos)/3.0;
        float3 noise2nd_center_pos = (inp[0].noise2nd_pos+inp[1].noise2nd_pos+inp[2].noise2nd_pos)/3.0;
        float3 noise3rd_center_pos = (inp[0].noise3rd_pos+inp[1].noise3rd_pos+inp[2].noise3rd_pos)/3.0;
        float3 noise4th_center_pos = (inp[0].noise4th_pos+inp[1].noise4th_pos+inp[2].noise4th_pos)/3.0;
        float3 noise5th_center_pos = (inp[0].noise5th_pos+inp[1].noise5th_pos+inp[2].noise5th_pos)/3.0;

        float noise1st_time = _Time.x*_Noise1stTimeSpeed+_Noise1stTimePhase;
        float3 noise1st_mesh_value = ValueNoise3D(noise1st_center_pos,_Noise1stSeed);
        noise1st_mesh_value = noise1st_mesh_value*_Noise1stValueScale+noise1st_time;

        float noise2nd_time = _Time.x*_Noise2ndTimeSpeed+_Noise2ndTimePhase;
        float3 noise2nd_mesh_value = ValueNoise3D(noise2nd_center_pos,_Noise2ndSeed);
        noise2nd_mesh_value = noise2nd_mesh_value*_Noise2ndValueScale+noise2nd_time;

        float noise3rd_time = _Time.x*_Noise3rdTimeSpeed+_Noise3rdTimePhase;
        float3 noise3rd_mesh_value = ValueNoise3D(noise3rd_center_pos,_Noise3rdSeed);
        noise3rd_mesh_value = noise3rd_mesh_value*_Noise3rdValueScale+noise3rd_time;

        float noise4th_time = _Time.x*_Noise4thTimeSpeed+_Noise4thTimePhase;
        float3 noise4th_mesh_value = ValueNoise3D(noise4th_center_pos,_Noise4thSeed);
        noise4th_mesh_value = noise4th_mesh_value*_Noise4thValueScale+noise4th_time;

        float noise5th_time = _Time.x*_Noise5thTimeSpeed+_Noise5thTimePhase;
        float3 noise5th_mesh_value = ValueNoise3D(noise5th_center_pos,_Noise5thSeed);
        noise5th_mesh_value = noise5th_mesh_value*_Noise5thValueScale+noise5th_time;

        // #if defined(_GEOMETRY_PUSHPULL_ENABLE)
        //     float3 pushpull_noise_pos[3];
        //     pushpull_noise_pos[0] = VertexCenterBias(inp[1].noise1st_pos,inp[2].noise1st_pos,inp[0].noise1st_pos,noise1st_center_pos,_GeometryPushPullPartitionBias);
        //     pushpull_noise_pos[1] = VertexCenterBias(inp[2].noise1st_pos,inp[0].noise1st_pos,inp[1].noise1st_pos,noise1st_center_pos,_GeometryPushPullPartitionBias);
        //     pushpull_noise_pos[2] = VertexCenterBias(inp[0].noise1st_pos,inp[1].noise1st_pos,inp[2].noise1st_pos,noise1st_center_pos,_GeometryPushPullPartitionBias);
        //     float3 noise1st_pushpull_value = float3(
        //         ValueNoise3D(pushpull_noise_pos[0],_Noise1stSeed),
        //         ValueNoise3D(pushpull_noise_pos[1],_Noise1stSeed),
        //         ValueNoise3D(pushpull_noise_pos[2],_Noise1stSeed)
        //     )*_Noise1stValueScale+noise1st_time;
        //     pushpull_noise_pos[0] = VertexCenterBias(inp[1].noise2nd_pos,inp[2].noise2nd_pos,inp[0].noise2nd_pos,noise2nd_center_pos,_GeometryPushPullPartitionBias);
        //     pushpull_noise_pos[1] = VertexCenterBias(inp[2].noise2nd_pos,inp[0].noise2nd_pos,inp[1].noise2nd_pos,noise2nd_center_pos,_GeometryPushPullPartitionBias);
        //     pushpull_noise_pos[2] = VertexCenterBias(inp[0].noise2nd_pos,inp[1].noise2nd_pos,inp[2].noise2nd_pos,noise2nd_center_pos,_GeometryPushPullPartitionBias);
        //     float3 noise2nd_pushpull_value = float3(
        //         ValueNoise3D(pushpull_noise_pos[0],_Noise2ndSeed),
        //         ValueNoise3D(pushpull_noise_pos[1],_Noise2ndSeed),
        //         ValueNoise3D(pushpull_noise_pos[2],_Noise2ndSeed)
        //     )*_Noise2ndValueScale+noise2nd_time;
        //     pushpull_noise_pos[0] = VertexCenterBias(inp[1].noise3rd_pos,inp[2].noise3rd_pos,inp[0].noise3rd_pos,noise3rd_center_pos,_GeometryPushPullPartitionBias);
        //     pushpull_noise_pos[1] = VertexCenterBias(inp[2].noise3rd_pos,inp[0].noise3rd_pos,inp[1].noise3rd_pos,noise3rd_center_pos,_GeometryPushPullPartitionBias);
        //     pushpull_noise_pos[2] = VertexCenterBias(inp[0].noise3rd_pos,inp[1].noise3rd_pos,inp[2].noise3rd_pos,noise3rd_center_pos,_GeometryPushPullPartitionBias);
        //     float3 noise3rd_pushpull_value = float3(
        //         ValueNoise3D(pushpull_noise_pos[0],_Noise3rdSeed),
        //         ValueNoise3D(pushpull_noise_pos[1],_Noise3rdSeed),
        //         ValueNoise3D(pushpull_noise_pos[2],_Noise3rdSeed)
        //     )*_Noise3rdValueScale+noise3rd_time;
        // #endif

    float3 fragment_stream[3];
    float3 fragment_value = 0.0;

    [branch]switch(_FragmentPartitionMode){
        default:
            [flatten]switch(_FragmentSource){
                default:
                    fragment_value = _FragmentFixedValue;
                    break;
                case 1:
                    fragment_value = FUNC_NOISE_VERTEX_VALUE(noise1st_pos,_Noise1stSeed,_Noise1stValueScale,noise1st_time);
                    break;
                case 2:
                    fragment_value = FUNC_NOISE_VERTEX_VALUE(noise2nd_pos,_Noise2ndSeed,_Noise2ndValueScale,noise2nd_time);
                    break;
                case 3:
                    fragment_value = FUNC_NOISE_VERTEX_VALUE(noise3rd_pos,_Noise3rdSeed,_Noise3rdValueScale,noise3rd_time);
                    break;
                case 4:
                    fragment_value = FUNC_NOISE_VERTEX_VALUE(noise4th_pos,_Noise4thSeed,_Noise4thValueScale,noise4th_time);
                    break;
                case 5:
                    fragment_value = FUNC_NOISE_VERTEX_VALUE(noise5th_pos,_Noise5thSeed,_Noise5thValueScale,noise5th_time);
                    break;
            }
            FUNC_GEOMETRY_FRAGMENT_PROCESS;
            fragment_stream[0] = float3(0.0,fragment_value.x,fragment_value.x);
            fragment_stream[1] = float3(fragment_value.y,0.0,fragment_value.y);
            fragment_stream[2] = float3(fragment_value.z,fragment_value.z,0.0);
            break;
        case 1:
            [flatten]switch(_FragmentSource){
                default:
                    fragment_value = _FragmentFixedValue;
                    break;
                case 1:
                    fragment_value = FUNC_NOISE_SIDE_VALUE(noise1st_pos,noise1st_center_pos,_Noise1stSeed,_Noise1stValueScale,noise1st_time);
                    break;
                case 2:
                    fragment_value = FUNC_NOISE_SIDE_VALUE(noise2nd_pos,noise2nd_center_pos,_Noise2ndSeed,_Noise2ndValueScale,noise2nd_time);
                    break;
                case 3:
                    fragment_value = FUNC_NOISE_SIDE_VALUE(noise3rd_pos,noise3rd_center_pos,_Noise3rdSeed,_Noise3rdValueScale,noise3rd_time);
                    break;
                case 4:
                    fragment_value = FUNC_NOISE_SIDE_VALUE(noise4th_pos,noise4th_center_pos,_Noise4thSeed,_Noise4thValueScale,noise4th_time);
                    break;
                case 5:
                    fragment_value = FUNC_NOISE_SIDE_VALUE(noise5th_pos,noise5th_center_pos,_Noise5thSeed,_Noise5thValueScale,noise5th_time);
                    break;
            }
            FUNC_GEOMETRY_FRAGMENT_PROCESS;
            float fragment_center_value = (fragment_value.x+fragment_value.y+fragment_value.z)/3.0;
            fragment_value = float3(
                SideCenterPos(fragment_value.y,fragment_value.z,fragment_value.x,fragment_center_value),
                SideCenterPos(fragment_value.z,fragment_value.x,fragment_value.y,fragment_center_value),
                SideCenterPos(fragment_value.x,fragment_value.y,fragment_value.z,fragment_center_value)
            );
            fragment_stream[0] = float3(0.0,fragment_value.y,fragment_value.z);
            fragment_stream[1] = float3(fragment_value.x,0.0,fragment_value.z);
            fragment_stream[2] = float3(fragment_value.x,fragment_value.y,0.0);
            break;
        case 2:
            [flatten]switch(_FragmentSource){
                default:
                    fragment_value = _FragmentFixedValue;
                    break;
                case 1:
                    fragment_value = noise1st_mesh_value;
                    break;
                case 2:
                    fragment_value = noise2nd_mesh_value;
                    break;
                case 3:
                    fragment_value = noise3rd_mesh_value;
                    break;
                case 4:
                    fragment_value = noise4th_mesh_value;
                    break;
                case 5:
                    fragment_value = noise5th_mesh_value;
                    break;
            }
            FUNC_GEOMETRY_FRAGMENT_PROCESS;
            fragment_stream[0] = fragment_value;
            fragment_stream[1] = fragment_value;
            fragment_stream[2] = fragment_value;
            break;
    }
    float3 color_stream[3];
    float3 coloring_value = 0.0;

    [branch]switch(_ColoringPartitionMode){
        default:
            [flatten]switch(_ColoringSource){
                default:
                    coloring_value = _ColoringFixedValue;
                    break;
                case 1:
                    coloring_value = FUNC_NOISE_VERTEX_VALUE(noise1st_pos,_Noise1stSeed,_Noise1stValueScale,noise1st_time);
                    break;
                case 2:
                    coloring_value = FUNC_NOISE_VERTEX_VALUE(noise2nd_pos,_Noise2ndSeed,_Noise2ndValueScale,noise2nd_time);
                    break;
                case 3:
                    coloring_value = FUNC_NOISE_VERTEX_VALUE(noise3rd_pos,_Noise3rdSeed,_Noise3rdValueScale,noise3rd_time);
                    break;
                case 4:
                    coloring_value = FUNC_NOISE_VERTEX_VALUE(noise4th_pos,_Noise4thSeed,_Noise4thValueScale,noise4th_time);
                    break;
                case 5:
                    coloring_value = FUNC_NOISE_VERTEX_VALUE(noise5th_pos,_Noise5thSeed,_Noise5thValueScale,noise5th_time);
                    break;
            }
            FUNC_GEOMETRY_COLORING_PROCESS;
            color_stream[0] = coloring_value.x;
            color_stream[1] = coloring_value.y;
            color_stream[2] = coloring_value.z;
            break;
        case 1:
            [flatten]switch(_ColoringSource){
                default:
                    coloring_value = _ColoringFixedValue;
                    break;
                case 1:
                    coloring_value = FUNC_NOISE_SIDE_VALUE(noise1st_pos,noise1st_center_pos,_Noise1stSeed,_Noise1stValueScale,noise1st_time);
                    break;
                case 2:
                    coloring_value = FUNC_NOISE_SIDE_VALUE(noise2nd_pos,noise2nd_center_pos,_Noise2ndSeed,_Noise2ndValueScale,noise2nd_time);
                    break;
                case 3:
                    coloring_value = FUNC_NOISE_SIDE_VALUE(noise3rd_pos,noise3rd_center_pos,_Noise3rdSeed,_Noise3rdValueScale,noise3rd_time);
                    break;
                case 4:
                    coloring_value = FUNC_NOISE_SIDE_VALUE(noise4th_pos,noise4th_center_pos,_Noise4thSeed,_Noise4thValueScale,noise4th_time);
                    break;
                case 5:
                    coloring_value = FUNC_NOISE_SIDE_VALUE(noise5th_pos,noise5th_center_pos,_Noise5thSeed,_Noise5thValueScale,noise5th_time);
                    break;
            }
            FUNC_GEOMETRY_COLORING_PROCESS;
            float coloring_center_value = (coloring_value.x+coloring_value.y+coloring_value.z)/3.0;
            coloring_value = float3(
                SideCenterPos(coloring_value.y,coloring_value.z,coloring_value.x,coloring_center_value),
                SideCenterPos(coloring_value.z,coloring_value.x,coloring_value.y,coloring_center_value),
                SideCenterPos(coloring_value.x,coloring_value.y,coloring_value.z,coloring_center_value)
            );
            color_stream[0] = float3(0.0,coloring_value.y,coloring_value.z);
            color_stream[1] = float3(coloring_value.x,0.0,coloring_value.z);
            color_stream[2] = float3(coloring_value.x,coloring_value.y,0.0);
            break;
        case 2:
            [flatten]switch(_ColoringSource){
                default:
                    coloring_value = _ColoringFixedValue;
                    break;
                case 1:
                    coloring_value = noise1st_mesh_value;
                    break;
                case 2:
                    coloring_value = noise2nd_mesh_value;
                    break;
                case 3:
                    coloring_value = noise3rd_mesh_value;
                    break;
                case 4:
                    coloring_value = noise4th_mesh_value;
                    break;
                case 5:
                    coloring_value = noise5th_mesh_value;
                    break;
            }
            FUNC_GEOMETRY_COLORING_PROCESS;
            color_stream[0] = coloring_value;
            color_stream[1] = coloring_value;
            color_stream[2] = coloring_value;
            break;
    }

    float3 geometry_pos[3] = {inp[0].pos.xyz,inp[1].pos.xyz,inp[2].pos.xyz};
    float3 geometry_center_pos = (geometry_pos[0]+geometry_pos[1]+geometry_pos[2])/3.0;
    float geometry_value = 0.0;
    float geometry_rotation_value = 0.0;
    [branch]if((_GeometryScaleEnable==1)||(_GeometryRotationEnable==1)){

        [flatten]switch(_GeometrySource){
            default:
                geometry_value = _GeometryFixedValue;
                break;
            case 1:
                geometry_value = noise1st_mesh_value;
                break;
            case 2:
                geometry_value = noise2nd_mesh_value;
                break;
            case 3:
                geometry_value = noise3rd_mesh_value;
                break;
            case 4:
                geometry_value = noise4th_mesh_value;
                break;
            case 5:
                geometry_value = noise5th_mesh_value;
                break;
        }
        geometry_value *= geometry_mask;
        geometry_value += geometry_map;
        // FUNC_GEOMETRY_PROCESS(
        //     geometry_value,
        //     _GeometryFixedValue,
        //     _GeometrySource,
        //     noise1st_mesh_value,
        //     noise2nd_mesh_value,
        //     noise3rd_mesh_value,
        //     geometry_mask,
        //     geometry_map
        // );
        FUNC_GEOMETRY_AUDIOLINK_PROCESS(
            geometry_value,
            geometry_al_mask,
            _GeometryAudioLinkSource,
            _GeometryAudioLinkVUStrength,
            _GeometryAudioLinkChronoTensityStrength,
            _GeometryAudioLinkSpectrumStrength,
            _GeometryAudioLinkSpectrumMirror,
            0
        );
        geometry_rotation_value = geometry_value;

        FUNC_GEOMETRY_MODIFIER_PROCESS(
            geometry_value,
            _GeometryPhaseScale,
            _GeometryLoopMode,
            _GeometryMidMul,
            _GeometryMidAdd,
            _GeometryEaseCurve,
            _GeometryEaseMode
        );

        geometry_rotation_value *= _GeometryPhaseScale;
        [branch]if(_GeometryRotationNoiseRepeat==1){
            geometry_rotation_value = mod(geometry_rotation_value,1.0);
        }else{
            geometry_rotation_value = triloop(geometry_rotation_value);
        }
        geometry_rotation_value = ThresholdFormula(geometry_rotation_value,_GeometryMidMul,_GeometryMidAdd);
        FUNC_EASING_BRANCH(geometry_rotation_value,_GeometryEaseCurve,_GeometryEaseMode);
    }

    float3 geometry_pushpull_value = 0.0;
    [branch]if(_GeometryPushPullEnable==1){
        [flatten]switch(_GeometrySource){
            default:
                geometry_pushpull_value = _GeometryFixedValue;
                break;
            case 1:
                geometry_pushpull_value = FUNC_NOISE_BIAS_VALUE(noise1st_pos,noise1st_center_pos,_Noise1stSeed,_Noise1stValueScale,noise1st_time,_GeometryPushPullPartitionBias);
                break;
            case 2:
                geometry_pushpull_value = FUNC_NOISE_BIAS_VALUE(noise2nd_pos,noise2nd_center_pos,_Noise2ndSeed,_Noise2ndValueScale,noise2nd_time,_GeometryPushPullPartitionBias);
                break;
            case 3:
                geometry_pushpull_value = FUNC_NOISE_BIAS_VALUE(noise3rd_pos,noise3rd_center_pos,_Noise3rdSeed,_Noise3rdValueScale,noise3rd_time,_GeometryPushPullPartitionBias);
                break;
            case 4:
                geometry_pushpull_value = FUNC_NOISE_BIAS_VALUE(noise4th_pos,noise4th_center_pos,_Noise4thSeed,_Noise4thValueScale,noise4th_time,_GeometryPushPullPartitionBias);
                break;
            case 5:
                geometry_pushpull_value = FUNC_NOISE_BIAS_VALUE(noise5th_pos,noise5th_center_pos,_Noise5thSeed,_Noise5thValueScale,noise5th_time,_GeometryPushPullPartitionBias);
                break;
        }
        geometry_pushpull_value *= geometry_pushpull_mask;
        geometry_pushpull_value += geometry_pushpull_map;
        // FUNC_GEOMETRY_PROCESS(
        //     geometry_pushpull_value,
        //     _GeometryFixedValue,
        //     _GeometrySource,
        //     noise1st_pushpull_value,
        //     noise2nd_pushpull_value,
        //     noise3rd_pushpull_value,
        //     geometry_pushpull_mask,
        //     geometry_pushpull_map
        // );

        FUNC_GEOMETRY_AUDIOLINK_PROCESS(
            geometry_pushpull_value,
            geometry_pushpull_al_mask,
            _GeometryAudioLinkSource,
            _GeometryAudioLinkVUStrength,
            _GeometryAudioLinkChronoTensityStrength,
            _GeometryAudioLinkSpectrumStrength,
            _GeometryAudioLinkSpectrumMirror,
            0
        );
        FUNC_GEOMETRY_MODIFIER_PROCESS(
            geometry_pushpull_value,
            _GeometryPhaseScale,
            _GeometryLoopMode,
            _GeometryMidMul,
            _GeometryMidAdd,
            _GeometryEaseCurve,
            _GeometryEaseMode
        );
    }

    [branch]if(_GeometryScaleEnable==1){
        geometry_pos[0] = lerp(geometry_center_pos,geometry_pos[0],lerp(_GeometryScaleBounds.x,_GeometryScaleBounds.y,geometry_value));
        geometry_pos[1] = lerp(geometry_center_pos,geometry_pos[1],lerp(_GeometryScaleBounds.x,_GeometryScaleBounds.y,geometry_value));
        geometry_pos[2] = lerp(geometry_center_pos,geometry_pos[2],lerp(_GeometryScaleBounds.x,_GeometryScaleBounds.y,geometry_value));
    }
    [branch]if(_GeometryPushPullEnable==1){
        geometry_pos[0] = geometry_pos[0]+lerp(_GeometryPushPullBounds.x,_GeometryPushPullBounds.y,geometry_pushpull_value.x)*inp[0].world_normal;
        geometry_pos[1] = geometry_pos[1]+lerp(_GeometryPushPullBounds.x,_GeometryPushPullBounds.y,geometry_pushpull_value.y)*inp[1].world_normal;
        geometry_pos[2] = geometry_pos[2]+lerp(_GeometryPushPullBounds.x,_GeometryPushPullBounds.y,geometry_pushpull_value.z)*inp[2].world_normal;
    }
    [branch]if(_GeometryRotationEnable==1){
        float3 normal_average = (inp[0].world_normal+inp[1].world_normal+inp[2].world_normal)/3.0;
        float rotation_sign = sign(_GeometryRotationInvert*2.0-1.0);
        geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center_pos,rotation_sign*geometry_rotation_value*UNITY_TWO_PI*_GeometryRotationStrength,normal_average)+geometry_center_pos;
        geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center_pos,rotation_sign*geometry_rotation_value*UNITY_TWO_PI*_GeometryRotationStrength,normal_average)+geometry_center_pos;
        geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center_pos,rotation_sign*geometry_rotation_value*UNITY_TWO_PI*_GeometryRotationStrength,normal_average)+geometry_center_pos;
    }

    [branch]if(_OrbitEnable==1){
        float3 orbit_value = 0.0;
        [flatten]switch(_OrbitSource){
            default:
                orbit_value = _OrbitFixedValue;
                break;
            case 1:
                orbit_value = (random(id+_OrbitSeed)>=_OrbitPrimitiveRatio);
                break;
            case 2:
                orbit_value = noise1st_mesh_value;
                break;
            case 3:
                orbit_value = noise2nd_mesh_value;
                break;
            case 4:
                orbit_value = noise3rd_mesh_value;
                break;
            case 5:
                orbit_value = noise4th_mesh_value;
                break;
            case 6:
                orbit_value = noise5th_mesh_value;
                break;
        }
        orbit_value *= orbit_mask;
        orbit_value += orbit_map;

        FUNC_GEOMETRY_AUDIOLINK_PROCESS(
            orbit_value,
            orbit_al_mask,
            _OrbitAudioLinkSource,
            _OrbitAudioLinkVUStrength,
            _OrbitAudioLinkChronoTensityStrength,
            _OrbitAudioLinkSpectrumStrength,
            _OrbitAudioLinkSpectrumMirror,
            0
        );

        FUNC_GEOMETRY_MODIFIER_PROCESS(
            orbit_value,
            _OrbitPhaseScale,
            _OrbitLoopMode,
            _OrbitMidMul,
            _OrbitMidAdd,
            _OrbitEaseCurve,
            _OrbitEaseMode
        );

        float3 orbit[3] = {
            geometry_pos[0]-geometry_center_pos+_OrbitOffset.xyz,
            geometry_pos[1]-geometry_center_pos+_OrbitOffset.xyz,
            geometry_pos[2]-geometry_center_pos+_OrbitOffset.xyz
        };

        float3 orbit_rotation_value = 0.0;
        [flatten]switch(_OrbitRotationSource){
            case 0:
                orbit_rotation_value = _OrbitRotationFixedValue;
                break;
            case 1:
                orbit_rotation_value = random(id+_OrbitRotationSeed);
                break;
            case 2:
                orbit_rotation_value = noise1st_mesh_value;
                break;
            case 3:
                orbit_rotation_value = noise2nd_mesh_value;
                break;
            case 4:
                orbit_rotation_value = noise3rd_mesh_value;
                break;
            case 5:
                orbit_rotation_value = noise4th_mesh_value;
                break;
            case 6:
                orbit_rotation_value = noise5th_mesh_value;
                break;
        }
        orbit_rotation_value *= orbit_rotation_mask;
        orbit_rotation_value += orbit_rotation_map;

        float3 orbit_anim = orbit_rotation_value*_OrbitRotationSpread.xyz;

        #if defined(_AUDIOLINK_ENABLE)
            float3 orbit_wave_spectrum = MeshHAudioLinkSpectrum(orbit_anim.x,_OrbitWaveAudioLinkSpectrumMirror,_OrbitWaveAudioLinkSpectrumMode)*float3(_OrbitWaveAudioLinkSpectrumStrength.x,_OrbitWaveAudioLinkSpectrumStrength.y,_OrbitWaveAudioLinkSpectrumStrength.y);
        #endif
        orbit_anim *= UNITY_TWO_PI;

        float3 orbit_wave_value = float3(
            (orbit_anim.x+_OrbitWavePhase.x+ORBIT_WAVE_X_TIME_MACRO),
            (orbit_anim.x+_OrbitWavePhase.y+ORBIT_WAVE_YZ_TIME_MACRO),
            (orbit_anim.x+_OrbitWavePhase.y+ORBIT_WAVE_YZ_TIME_MACRO)
        );
        #if defined(_AUDIOLINK_ENABLE)
            orbit_wave_value *= float3(_OrbitWaveFrequency.x,_OrbitWaveFrequency.y,_OrbitWaveFrequency.y);
            [branch]if(_OrbitWaveAudioLinkSource==2) orbit_wave_value += audiolink_chronotensity*_OrbitWaveAudioLinkChronoTensityStrength*orbit_rotation_offset_al_mask;
        #endif

        orbit_anim += ORBIT_ROTATION_TIME_MACRO;
        orbit_anim *= lerp(1.0,orbit_rotation_offset_mask,saturate(_OrbitRotationOffsetMaskMapStrength.xyz)*saturate(_OrbitRotationOffsetMaskMapStrength.w));
        orbit_anim += float3(_OrbitRotationAngle.x,_OrbitRotationAngle.y,_OrbitRotationAngle.z)*UNITY_TWO_PI;

        #if defined(_AUDIOLINK_ENABLE)
            [branch]if(_OrbitRotationOffsetAudioLinkSource==1){
                orbit_anim += audiolink_vu*UNITY_TWO_PI*orbit_rotation_offset_al_mask*_OrbitRotationOffsetAudioLinkVUStrength.xyz*_OrbitRotationOffsetAudioLinkVUStrength.w;
            }else if(_OrbitRotationOffsetAudioLinkSource==2){
                orbit_anim += audiolink_chronotensity*orbit_rotation_offset_al_mask*_OrbitRotationOffsetAudioLinkChronoTensityStrength.xyz*_OrbitRotationOffsetAudioLinkChronoTensityStrength.w;
            }
        #endif

        orbit_wave_value = float3(
            sin(orbit_wave_value.x)*_OrbitWaveStrength.x,
            cos(orbit_anim.x)*sin(orbit_wave_value.y)*_OrbitWaveStrength.y,
            sin(orbit_anim.x)*sin(orbit_wave_value.z)*_OrbitWaveStrength.y
        );

        float3 orbit_wave_al_value = 0.0;
        #if defined(_AUDIOLINK_ENABLE)
            [branch]if(_OrbitWaveAudioLinkSource==3)lerp(_OrbitWaveAudioLinkSpectrumBounds.x,_OrbitWaveAudioLinkSpectrumBounds.y,orbit_wave_spectrum)*orbit_rotation_offset_al_mask;
        #endif

        orbit_wave_value += float3(
            orbit_wave_al_value.x,
            cos(orbit_anim.x)*orbit_wave_al_value.y,
            sin(orbit_anim.x)*orbit_wave_al_value.z
        );

        #if defined(_AUDIOLINK_ENABLE)
            [branch]if(_OrbitWaveAudioLinkSource==1) orbit_wave_value *= audiolink_vu*float3(_OrbitWaveAudioLinkVUStrength.x,_OrbitWaveAudioLinkVUStrength.y,_OrbitWaveAudioLinkVUStrength.y)*orbit_rotation_offset_al_mask;
        #endif

        float3 orbit_dir = cos(orbit_anim.x)*float3(0.0,1.0,0.0)*_OrbitScale.y + sin(orbit_anim.x)*float3(0.0,0.0,1.0)*_OrbitScale.z;
        orbit_dir *= _OrbitScale.w;

        orbit_dir += orbit_wave_value*_OrbitScale.w;
        orbit_dir = RodriguesRotation(orbit_dir,orbit_anim.y,float3(0.0,1.0,0.0));
        orbit_dir = RodriguesRotation(orbit_dir,orbit_anim.z,float3(0.0,0.0,1.0));
        orbit_dir = mul(UNITY_MATRIX_M,float4(orbit_dir,1.0));

        orbit[0] = orbit[0]+orbit_dir;
        orbit[1] = orbit[1]+orbit_dir;
        orbit[2] = orbit[2]+orbit_dir;

        geometry_pos[0] = lerp(geometry_pos[0],orbit[0],orbit_value);
        geometry_pos[1] = lerp(geometry_pos[1],orbit[1],orbit_value);
        geometry_pos[2] = lerp(geometry_pos[2],orbit[2],orbit_value);
    }

    SWITCH_SHADE_WORLDPOS_MACRO float3 world_pos[3];
    float4 pos[3];
    float camera_distance[3];
    float4x4 matrix_v[3];
    [unroll]
    for(int i = 0; i < 3; i++){
        matrix_v[i] = float4x4(inp[i].matrix_v_0,inp[i].matrix_v_1,inp[i].matrix_v_2,0.0,0.0,0.0,1.0);

        [branch]if(_GeometryPixelizationSpace==3) geometry_pos[i] = Pixelization(geometry_pos[i],(scale));

        SWITCH_SHADE_WORLDPOS_MACRO world_pos[i] = geometry_pos[i];
        camera_distance[i] = HOLOGRAM_CAMERA_DISTANCE_MACRO(i);

        pos[i] = mul(matrix_v[i],float4(geometry_pos[i],1.0));
        pos[i] = mul(UNITY_MATRIX_P,pos[i]);
    }

    o.model_scale = (scale.x+scale.y+scale.z)/3.0;

    o.pos = pos[0];
    o.alpha = inp[0].alpha;
    o.camera_distance = camera_distance[0];
    o.baryCentricCoords = float3(1.0,0.0,0.0);
    o.fragment_noise = fragment_stream[0];
    o.color_noise = color_stream[0];
    o.vertex_color = inp[0].vertex_color;
    o.normal = inp[0].normal;
    SWITCH_SHADE_WORLDPOS_MACRO o.world_pos = world_pos[0];
    SWITCH_WORLDNORMAL_MACRO o.world_normal = inp[0].world_normal;
    UNITY_TRANSFER_LIGHTING(o,inp[0].uv)
    UNITY_TRANSFER_INSTANCE_ID(inp[0], o);
    UNITY_TRANSFER_VERTEX_OUTPUT_STEREO(inp[0], o);
    stream.Append(o);

    o.pos = pos[1];
    o.alpha = inp[1].alpha;
    o.camera_distance = camera_distance[1];
    o.baryCentricCoords = float3(0.0,1.0,0.0);
    o.fragment_noise = fragment_stream[1];
    o.color_noise = color_stream[1];
    o.vertex_color = inp[1].vertex_color;
    o.normal = inp[1].normal;
    SWITCH_SHADE_WORLDPOS_MACRO o.world_pos = world_pos[1];
    SWITCH_WORLDNORMAL_MACRO o.world_normal = inp[1].world_normal;
    UNITY_TRANSFER_LIGHTING(o,inp[1].uv)
    UNITY_TRANSFER_INSTANCE_ID(inp[1], o);
    UNITY_TRANSFER_VERTEX_OUTPUT_STEREO(inp[1], o);
    stream.Append(o);

    o.pos = pos[2];
    o.alpha = inp[2].alpha;
    o.camera_distance = camera_distance[2];
    o.baryCentricCoords = float3(0.0,0.0,1.0);
    o.fragment_noise = fragment_stream[2];
    o.color_noise = color_stream[2];
    o.vertex_color = inp[2].vertex_color;
    o.normal = inp[2].normal;
    SWITCH_SHADE_WORLDPOS_MACRO o.world_pos = world_pos[2];
    SWITCH_WORLDNORMAL_MACRO o.world_normal = inp[2].world_normal;
    UNITY_TRANSFER_LIGHTING(o,inp[2].uv)
    UNITY_TRANSFER_INSTANCE_ID(inp[2], o);
    UNITY_TRANSFER_VERTEX_OUTPUT_STEREO(inp[2], o);
    stream.Append(o);

    stream.RestartStrip();

}
