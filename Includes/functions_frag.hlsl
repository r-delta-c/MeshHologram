    UNITY_SETUP_INSTANCE_ID(i)
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

    fixed4 c = fixed4(0.0,0.0,0.0,1.0);

    #ifdef _USE_FWIDTH
    float3 sides = (i.baryCentricCoords/(fwidth(i.baryCentricCoords)*0.5/lerp(1.0,max(i.camera_distance,1e-4),_DistanceInfluence))/unity_CameraProjection._m11/_ScreenParams.y*1024.0/LINE_SCALE_MACRO);
    #else
    float3 sides = (i.baryCentricCoords*96.0);
    #endif
    float width = max(_LineWidth,1e-4);

    #ifdef _LINEFADEMODE_OUTWIDE
        float3 diff = (_TriangleComp-sides)*i.fragment_noise;
    #elif _LINEFADEMODE_OUTTHIN
        float3 diff = (_TriangleComp-sides)/i.fragment_noise;
    #elif _LINEFADEMODE_BREAK
        float3 diff = _TriangleComp-sides*i.fragment_noise-1.0;
    #elif _LINEFADEMODE_VANISHING
        float3 diff = _TriangleComp-sides/i.fragment_noise;
    #elif _LINEFADEMODE_ZOOMIN
        float3 diff = _TriangleComp-sides+i.fragment_noise;
    #elif _LINEFADEMODE_ZOOMOUT
        float3 diff = _TriangleComp-sides-i.fragment_noise;
    #elif _LINEFADEMODE_POWERZOOMIN
        float3 diff = _TriangleComp*i.fragment_noise-sides;
    #elif _LINEFADEMODE_COLLAPSE
        float3 diff = (_TriangleComp-1.0)/i.fragment_noise-sides+2.0;
    #elif _LINEFADEMODE_JOIN3
        float3 diff = _TriangleComp/i.fragment_noise-sides/i.fragment_noise;
    #else
        float3 diff = _TriangleComp-sides;
    #endif

    float3 range = (1.0-saturate(lerp(abs(diff),diff,_Fill)/width))*(sign(_LineWidth));
    #ifdef _LINEFADEMODE_JOIN1
        float3 mask = saturate(i.fragment_noise*diff/width);
    #elif _LINEFADEMODE_JOIN2
        float3 mask = saturate(i.fragment_noise*diff/(i.fragment_noise*width));
    #else
        float3 mask = saturate(diff/width);
    #endif

    range.x = min(range.x*i.fragment_noise.x,(1.0-mask.g)*(1.0-mask.b));
    range.y = min(range.y*i.fragment_noise.y,(1.0-mask.r)*(1.0-mask.b));
    range.z = min(range.z*i.fragment_noise.z,(1.0-mask.r)*(1.0-mask.g));

    float draw = EaseBias(max(max(range.x,range.y),range.z),_LineGradientBias);

    #ifdef _COLORSOURCE_GRADIENT
        #if !defined(_COLORINGSOURCE_VALUE)
            #ifdef _COLORINGPARTITIONTYPE_SIDE
                float3 coloring_side = i.color_noise * (range>0.0);
                sides = 0.0<sides;
                float coloring_t = max(sides.x*coloring_side.x,max(sides.y*coloring_side.y,sides.z*coloring_side.z));
                coloring_t = lerp(coloring_t,1.0,(i.color_noise.x+i.color_noise.y+i.color_noise.z)/3.0*1.1);
                c = lerp(_Color0,_Color1,coloring_t);
            #else
                c = lerp(_Color0,_Color1,i.color_noise);
            #endif
        #else
            c = lerp(_Color0,_Color1,_ColoringValue);
        #endif
    #elif _COLORSOURCE_PRIMARY
        c = _Color0;
    #elif _COLORSOURCE_GRADIENTTEX
        #ifdef _COLORINGPARTITIONTYPE_SIDE
            float3 coloring_side = i.color_noise * (range>0.0);
            sides = 0.0<sides;
            float coloring_t = saturate(
                max(sides.x*coloring_side.x,max(sides.y*coloring_side.y,sides.z*coloring_side.z)));
            coloring_t = lerp(coloring_t,1.0,(i.color_noise.x+i.color_noise.y+i.color_noise.z)/3.0*1.1);
            c = tex2Dlod(_ColorGradientTex,float4(coloring_t*0.994+0.004,0.5,0.0,0.0));
        #else
            c = tex2Dlod(_ColorGradientTex,float4(i.color_noise*0.994+0.004,0.5,0.0,0.0));
        #endif
    #elif _COLORSOURCE_VERTEXCOLOR
        c = i.vertex_color;
    #elif _COLORSOURCE_UNIQUESIDES
        c.rgb = lerp(i.baryCentricCoords,1.0-i.baryCentricCoords,i.color_noise);
    #elif _COLORSOURCE_AUDIOLINK_THEMECOLOR
        c.rgb = AudioLinkData(ALPASS_CCCOLORS+uint2(_AudioLinkThemeColorBand,0)).rgb;
    #endif

