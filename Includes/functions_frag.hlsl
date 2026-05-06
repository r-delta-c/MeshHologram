    UNITY_SETUP_INSTANCE_ID(i)
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

    half4 c = half4(0.0,0.0,0.0,1.0);

    float3 sides;
    [branch]if(_FwidthEnable==0){
        sides = (i.baryCentricCoords*96.0);
    }else{
        sides = (i.baryCentricCoords/(fwidth(i.baryCentricCoords)*0.5/lerp(1.0,max(i.camera_distance,1e-4),_DistanceInfluence))/-UNITY_MATRIX_P._m11/_ScreenParams.y*1024.0);
    }
    [branch]if(_FragmentManualLineScalingEnable==0){
        sides /= i.model_scale;
    }else{
        sides /= max(_FragmentLineScale,1e-4);
    }
    float width = max(max(_FragmentLineWidth,_FragmentLineWidth*i.camera_distance),1e-4);
    float3 bary = 1.0-sides/max(64.0,64.0*i.camera_distance);
    float frame = smoothstep(0.0,0.05,(1.0-max(bary.x,max(bary.y,bary.z)))*2.0);
    float3 diff;
    float3 diff_0;
    float3 diff_1;
    float3 blend;
    float3 draw;

    [branch]switch(_FragmentLineAnimationMode){
        default: // def
            diff = (_FragmentTriangleCompression-sides)/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 1: // ZoomIn
            diff = (_FragmentTriangleCompression-sides)/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);
            diff *= i.fragment_noise.xyz;

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 2: // ZoomOut
            diff = (_FragmentTriangleCompression-sides)/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);
            diff /= i.fragment_noise.xyz;

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 3: // ZoomInPower
            diff = (_FragmentTriangleCompression-sides)/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);
            diff = (_FragmentTriangleCompression-sides*i.fragment_noise.xyz)/width;

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 4: // Collapse
            diff = (_FragmentTriangleCompression-sides)/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);
            diff = (_FragmentTriangleCompression-sides/i.fragment_noise.xyz)/width;

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 5: // Break
            diff = (_FragmentTriangleCompression-sides)/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);
            diff = (_FragmentTriangleCompression-sides+i.fragment_noise.xyz-1.0)/width;

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 6: // OutWide
            diff = (_FragmentTriangleCompression-sides)/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);
            diff = (_FragmentTriangleCompression-sides-i.fragment_noise.xyz+1.0)/width;

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 7: // OutThin
            diff = (_FragmentTriangleCompression-sides)/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);
            diff = (_FragmentTriangleCompression*i.fragment_noise.xyz-sides)/width;

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 8: // Vanishing
            diff = (_FragmentTriangleCompression-sides)/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);
            diff = (_FragmentTriangleCompression/i.fragment_noise.xyz-sides)/width;

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 9: // Join1
            diff = (_FragmentTriangleCompression-sides)/i.fragment_noise.xyz/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 10: // Join2
            diff = (_FragmentTriangleCompression-sides)*i.fragment_noise.xyz/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

        case 11: // Join3
            diff = (_FragmentTriangleCompression/i.fragment_noise.xyz-sides/i.fragment_noise.xyz)/width;
            diff_0 = float3(diff.y-diff.x,diff.x-diff.y,diff.x-diff.z);
            diff_1 = float3(diff.z-diff.x,diff.z-diff.y,diff.y-diff.z);

            blend = min(1.0,
                max(0.0,lerp(diff_0*_FragmentEdgeBlendWidth+1.0,sign(diff_0.xyz),i.fragment_noise.yxx*0.5))+
                max(0.0,lerp(diff_1*_FragmentEdgeBlendWidth+1.0,sign(diff_1.xyz),i.fragment_noise.zzy*0.5))
            );
            draw = lerp(saturate(1.0-lerp(abs(diff/1.0),diff,_FragmentFill))*i.fragment_noise.xyz,0.0,blend);
            break;

    }

    draw.x = EasePowInOutBias(draw.x,_FragmentLineGradientBias)*frame;
    draw.y = EasePowInOutBias(draw.y,_FragmentLineGradientBias)*frame;
    draw.z = EasePowInOutBias(draw.z,_FragmentLineGradientBias)*frame;

    float3 coloring_t = 0.0;
    [branch]if(_ColoringPartitionMode==1){
        coloring_t = saturate(lerp(lerp(i.color_noise.xyz,i.color_noise.zzy,saturate(diff_1*_ColoringEdgeBlendWidth+0.5)),i.color_noise.yxx,saturate(diff_0*_ColoringEdgeBlendWidth+0.5)));
    }

    [branch]switch(_ColorSource){
        default:
            c = _Color0;
            break;
        case 0:
            [branch]if(_ColoringPartitionMode==1){
                c.rgb += sign(draw.x)*lerp(_Color0,_Color1,coloring_t);
                c.rgb += sign(draw.y)*lerp(_Color0,_Color1,coloring_t);
                c.rgb += sign(draw.z)*lerp(_Color0,_Color1,coloring_t);
            }else{
                c = lerp(_Color0,_Color1,i.color_noise.r);
            }
            break;
        case 2:
            [branch]if(_ColoringPartitionMode==1){
                c.rgb += draw.x*_ColorGradientTex.SampleLevel(_linear_repeat,float2(mod(coloring_t.x*_ColorGradientTex_ST.x+_ColorGradientTex_ST.z,1.0)*0.994+0.004,0.5),0.0);
                c.rgb += draw.y*_ColorGradientTex.SampleLevel(_linear_repeat,float2(mod(coloring_t.y*_ColorGradientTex_ST.x+_ColorGradientTex_ST.z,1.0)*0.994+0.004,0.5),0.0);
                c.rgb += draw.z*_ColorGradientTex.SampleLevel(_linear_repeat,float2(mod(coloring_t.z*_ColorGradientTex_ST.x+_ColorGradientTex_ST.z,1.0)*0.994+0.004,0.5),0.0);
            }else{
                c = _ColorGradientTex.SampleLevel(_linear_repeat,float2(mod(i.color_noise.r*_ColorGradientTex_ST.x+_ColorGradientTex_ST.z,1.0)*0.994+0.004,0.5),0.0);
            }
            break;
        case 3:
            c = i.color;
            break;
        case 4:
            c.rgb = lerp(i.baryCentricCoords,1.0-i.baryCentricCoords,i.color_noise);
            break;
        case 5:
            float3 coloring_value = 0.0;
            #if defined(_AUDIOLINK_ENABLE)
                coloring_value = AudioLinkData(ALPASS_CCCOLORS+uint2(_AudioLinkThemeColorBand,0)).rgb;
            #endif
            [branch]if(_ColoringPartitionMode==1){
                c.rgb += draw.x*lerp(coloring_value,1.0-coloring_value,coloring_t);
                c.rgb += draw.y*lerp(coloring_value,1.0-coloring_value,coloring_t);
                c.rgb += draw.z*lerp(coloring_value,1.0-coloring_value,coloring_t);
            }else{
                c.rgb = lerp(coloring_value,1.0-coloring_value,i.color_noise);
            }
            break;
    }

