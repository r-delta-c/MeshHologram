    UNITY_SETUP_INSTANCE_ID(i)
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

    fixed4 c = fixed4(0.0,0.0,0.0,1.0);

    float3 sides;
    [branch]if(_FwidthEnable==0){
        sides = (i.baryCentricCoords*96.0);
    }else{
        sides = (i.baryCentricCoords/(fwidth(i.baryCentricCoords)*0.5/lerp(1.0,max(i.camera_distance,1e-4),_DistanceInfluence))/unity_CameraProjection._m11/_ScreenParams.y*1024.0);
    }
    [branch]if(_FragmentManualLineScalingEnable==0){
        sides /= i.model_scale;
    }else{
        sides /= max(_FragmentLineScale,1e-4);
    }
    float width = max(_FragmentLineWidth,1e-4);

    float3 diff;
    [branch]switch(_FragmentLineAnimationMode){
        default:
            diff = _FragmentTriangleCompression-sides;
            break;
        case 1:
            diff = (_FragmentTriangleCompression-sides)*i.fragment_noise;
            break;
        case 2:
            diff = (_FragmentTriangleCompression-sides)/i.fragment_noise;
            break;
        case 3:
            diff = _FragmentTriangleCompression-sides*i.fragment_noise-1.0;
            break;
        case 4:
            diff = _FragmentTriangleCompression-sides/i.fragment_noise;
            break;
        case 5:
            diff = _FragmentTriangleCompression-sides+i.fragment_noise;
            break;
        case 6:
            diff = _FragmentTriangleCompression-sides-i.fragment_noise;
            break;
        case 7:
            diff = _FragmentTriangleCompression*i.fragment_noise-sides;
            break;
        case 8:
            diff = (_FragmentTriangleCompression-1.0)/i.fragment_noise-sides+2.0;
            break;
        case 11:
            diff = _FragmentTriangleCompression/i.fragment_noise-sides/i.fragment_noise;
            break;
    }

    float3 range = (1.0-saturate(lerp(abs(diff),diff,_FragmentFill)/width))*(sign(_FragmentLineWidth));
    float3 mask;
    [branch]switch(_FragmentLineAnimationMode){
        default:
            mask = saturate(diff/width);
            break;
        case 9:
            mask = saturate(i.fragment_noise*diff/width);
            break;
        case 10:
            mask = saturate(i.fragment_noise*diff/(i.fragment_noise*width));
            break;
    }

    range.x = min(range.x*i.fragment_noise.x,(1.0-mask.g)*(1.0-mask.b));
    range.y = min(range.y*i.fragment_noise.y,(1.0-mask.r)*(1.0-mask.b));
    range.z = min(range.z*i.fragment_noise.z,(1.0-mask.r)*(1.0-mask.g));

    float draw = EasePowInOutBias(max(max(range.x,range.y),range.z),_FragmentLineGradientBias);

    float3 coloring_edge = 0.0;
    float coloring_t = 0.0;
    [branch]if(_ColoringPartitionMode==1){
        coloring_edge = i.color_noise * (range>0.0);
        sides = 0.0<sides;
        coloring_t = max(sides.x*coloring_edge.x,max(sides.y*coloring_edge.y,sides.z*coloring_edge.z));
        coloring_t = lerp(coloring_t,1.0,(i.color_noise.x+i.color_noise.y+i.color_noise.z)/3.0*1.1);
    }

    [branch]switch(_ColorSource){
        default:
            c = _Color0;
            break;
        case 0:
            [branch]if(_ColoringPartitionMode==1){
                c = lerp(_Color0,_Color1,coloring_t);
            }else{
                c = lerp(_Color0,_Color1,i.color_noise.r);
            }
            break;
        case 2:
            [branch]if(_ColoringPartitionMode==1){
                c = UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_ColorGradientTex, _linear_repeat,float2(coloring_t*0.994+0.004,0.5),0.0);
            }else{
                c = UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_ColorGradientTex, _linear_repeat,float2(i.color_noise.r*0.994+0.004,0.5),0.0);
            }
            break;
        case 3:
            c = i.vertex_color;
            break;
        case 4:
            c.rgb = lerp(i.baryCentricCoords,1.0-i.baryCentricCoords,i.color_noise.r);
            break;
        case 5:
            float3 coloring_value = 0.0;
            #if defined(_AUDIOLINK_ENABLE)
                coloring_value = AudioLinkData(ALPASS_CCCOLORS+uint2(_AudioLinkThemeColorBand,0)).rgb;
            #endif
            [branch]if(_ColoringPartitionMode==1){
                c.rgb = lerp(coloring_value,1.0-coloring_value,coloring_t);
            }else{
                c.rgb = lerp(coloring_value,1.0-coloring_value,i.color_noise.r);
            }
            break;
    }

