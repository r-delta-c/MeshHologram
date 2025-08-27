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

    float fragment_mask[3];
    float coloring_mask[3];
    float geometry_mask[3];
    float geometry_messy_mask[3];
    TEX2D_NOISE1ST_MACRO float noise1st_offset[3];
    TEX2D_NOISE2ND_MACRO float noise2nd_offset[3];
    TEX2D_NOISE3RD_MACRO float noise3rd_offset[3];
    float audiolink_mask[3];
    fragment_mask[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_FragmentMaskControlTex,_point_clamp, inp[0].uv, 0.0),_FragmentMaskControl);
    fragment_mask[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_FragmentMaskControlTex,_point_clamp, inp[1].uv, 0.0),_FragmentMaskControl);
    fragment_mask[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_FragmentMaskControlTex,_point_clamp, inp[2].uv, 0.0),_FragmentMaskControl);
    coloring_mask[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_ColoringMaskControlTex,_point_clamp, inp[0].uv, 0.0),_ColoringMaskControl);
    coloring_mask[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_ColoringMaskControlTex,_point_clamp, inp[1].uv, 0.0),_ColoringMaskControl);
    coloring_mask[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_ColoringMaskControlTex,_point_clamp, inp[2].uv, 0.0),_ColoringMaskControl);
    geometry_mask[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_GeometryMaskControlTex,_point_clamp, inp[0].uv, 0.0),_GeometryMaskControl);
    geometry_mask[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_GeometryMaskControlTex,_point_clamp, inp[1].uv, 0.0),_GeometryMaskControl);
    geometry_mask[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_GeometryMaskControlTex,_point_clamp, inp[2].uv, 0.0),_GeometryMaskControl);
    geometry_messy_mask[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_GeometryMessyMaskControlTex,_point_clamp, inp[0].uv, 0.0),_GeometryMessyMaskControl);
    geometry_messy_mask[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_GeometryMessyMaskControlTex,_point_clamp, inp[1].uv, 0.0),_GeometryMessyMaskControl);
    geometry_messy_mask[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_GeometryMessyMaskControlTex,_point_clamp, inp[2].uv, 0.0),_GeometryMessyMaskControl);

    #if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYMESSYSOURCE_NOISE1ST)
        TEX2D_NOISE1ST_MACRO noise1st_offset[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise1stOffsetControlTex, _point_clamp, inp[0].uv, 0.0),_Noise1stOffsetControl);
        TEX2D_NOISE1ST_MACRO noise1st_offset[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise1stOffsetControlTex, _point_clamp, inp[1].uv, 0.0),_Noise1stOffsetControl);
        TEX2D_NOISE1ST_MACRO noise1st_offset[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise1stOffsetControlTex, _point_clamp, inp[2].uv, 0.0),_Noise1stOffsetControl);
    #else
        noise1st_offset[0] = 1.0;
        noise1st_offset[1] = 1.0;
        noise1st_offset[2] = 1.0;
    #endif

    #if defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYMESSYSOURCE_NOISE2ND)
        TEX2D_NOISE2ND_MACRO noise2nd_offset[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise2ndOffsetControlTex, _point_clamp, inp[0].uv, 0.0),_Noise2ndOffsetControl);
        TEX2D_NOISE2ND_MACRO noise2nd_offset[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise2ndOffsetControlTex, _point_clamp, inp[1].uv, 0.0),_Noise2ndOffsetControl);
        TEX2D_NOISE2ND_MACRO noise2nd_offset[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise2ndOffsetControlTex, _point_clamp, inp[2].uv, 0.0),_Noise2ndOffsetControl);
    #else
        noise2nd_offset[0] = 1.0;
        noise2nd_offset[1] = 1.0;
        noise2nd_offset[2] = 1.0;
    #endif

    #if defined(_FRAGMENTSOURCE_NOISE3RD) || defined(_COLORINGSOURCE_NOISE3RD) || defined(_GEOMETRYSOURCE_NOISE3RD) || defined(_GEOMETRYMESSYSOURCE_NOISE3RD)
        TEX2D_NOISE3RD_MACRO noise3rd_offset[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise3rdOffsetControlTex, _point_clamp, inp[0].uv, 0.0),_Noise3rdOffsetControl);
        TEX2D_NOISE3RD_MACRO noise3rd_offset[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise3rdOffsetControlTex, _point_clamp, inp[1].uv, 0.0),_Noise3rdOffsetControl);
        TEX2D_NOISE3RD_MACRO noise3rd_offset[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise3rdOffsetControlTex, _point_clamp, inp[2].uv, 0.0),_Noise3rdOffsetControl);
    #else
        noise3rd_offset[0] = 1.0;
        noise3rd_offset[1] = 1.0;
        noise3rd_offset[2] = 1.0;
    #endif

    #ifdef _USE_AUDIOLINK
        audiolink_mask[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_AudioLinkMaskControlTex, _point_clamp, inp[0].uv, 0.0),_AudioLinkMaskControl);
        audiolink_mask[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_AudioLinkMaskControlTex, _point_clamp, inp[1].uv, 0.0),_AudioLinkMaskControl);
        audiolink_mask[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_AudioLinkMaskControlTex, _point_clamp, inp[2].uv, 0.0),_AudioLinkMaskControl);

        float4 audiolink_vu_band = lerp(AudioLinkData(ALPASS_FILTEREDAUDIOLINK+uint2(_AudioLinkVUSmooth,_AudioLinkVUBand)),AudioLinkData(ALPASS_FILTEREDVU_INTENSITY),max(0.0,_AudioLinkVUBand-4.0));
        float audiolink_vu = saturate(lerp(audiolink_vu_band.r,audiolink_vu_band.b,_AudioLinkVUPanning)*_AudioLinkVUGainMul+_AudioLinkVUGainAdd);
        float audiolink_chronotensity = (AudioLinkDecodeDataAsUInt(ALPASS_CHRONOTENSITY+uint2(_AudioLinkChronoTensityType,_AudioLinkChronoTensityBand)).r/_AudioLinkChronoTensityScale);

        #endif

    #if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_FRAGMENTSOURCE_NOISE3RD)
        float3 fragment_noise;
        float3 fragment_center = (inp[0].FRAGMENT_NOISE_MACRO+inp[1].FRAGMENT_NOISE_MACRO+inp[2].FRAGMENT_NOISE_MACRO)/3.0;
        float fragment_time = FRAGMENT_TIME_MACRO;
        #ifdef _PARTITIONTYPE_VERTEX
            fragment_noise = float3(
                FragmentNoisePingPong(inp[0].FRAGMENT_NOISE_MACRO,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO,
                FragmentNoisePingPong(inp[1].FRAGMENT_NOISE_MACRO,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO,
                FragmentNoisePingPong(inp[2].FRAGMENT_NOISE_MACRO,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO);
            fragment_noise.x = 1.0-(fragment_noise.x)*fragment_mask[0];
            fragment_noise.y = 1.0-(fragment_noise.y)*fragment_mask[1];
            fragment_noise.z = 1.0-(fragment_noise.z)*fragment_mask[2];

            #define FRAGMENT_STREAM_0_MACRO float3(0.0,fragment_noise.x,fragment_noise.x)
            #define FRAGMENT_STREAM_1_MACRO float3(fragment_noise.y,0.0,fragment_noise.y)
            #define FRAGMENT_STREAM_2_MACRO float3(fragment_noise.z,fragment_noise.z,0.0)

        #elif _PARTITIONTYPE_SIDE
            fragment_noise.x = FragmentSidePosNoise(inp[1].FRAGMENT_NOISE_MACRO,inp[2].FRAGMENT_NOISE_MACRO,inp[0].FRAGMENT_NOISE_MACRO,fragment_center,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO;
            fragment_noise.y = FragmentSidePosNoise(inp[2].FRAGMENT_NOISE_MACRO,inp[0].FRAGMENT_NOISE_MACRO,inp[1].FRAGMENT_NOISE_MACRO,fragment_center,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO;
            fragment_noise.z = FragmentSidePosNoise(inp[0].FRAGMENT_NOISE_MACRO,inp[1].FRAGMENT_NOISE_MACRO,inp[2].FRAGMENT_NOISE_MACRO,fragment_center,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO;

            #define FRAGMENT_STREAM_0_MACRO float3(0.0,1.0-fragment_noise.y*fragment_mask[0],1.0-fragment_noise.z*fragment_mask[0])
            #define FRAGMENT_STREAM_1_MACRO float3(1.0-fragment_noise.x*fragment_mask[1],0.0,1.0-fragment_noise.z*fragment_mask[1])
            #define FRAGMENT_STREAM_2_MACRO float3(1.0-fragment_noise.x*fragment_mask[2],1.0-fragment_noise.y*fragment_mask[2],0.0)*fragment_mask[2]

        #elif _PARTITIONTYPE_MESH
            #define FRAGMENT_STREAM_0_MACRO FragmentNoisePingPong(FRAGMENT_CENTER_MACRO,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO*fragment_mask[0]
            #define FRAGMENT_STREAM_1_MACRO FragmentNoisePingPong(FRAGMENT_CENTER_MACRO,FRAGMENT_OFFSET_MACRO(1),fragment_time)LINEFADEMODE_INSTANT_MACRO*fragment_mask[1]
            #define FRAGMENT_STREAM_2_MACRO FragmentNoisePingPong(FRAGMENT_CENTER_MACRO,FRAGMENT_OFFSET_MACRO(2),fragment_time)LINEFADEMODE_INSTANT_MACRO*fragment_mask[2]
        #endif
    #elif defined(_USE_AUDIOLINK) && _FRAGMENTSOURCE_AUDIOLINK_VU
        #define FRAGMENT_STREAM_0_MACRO audiolink_vu*audiolink_mask[0]
        #define FRAGMENT_STREAM_1_MACRO audiolink_vu*audiolink_mask[1]
        #define FRAGMENT_STREAM_2_MACRO audiolink_vu*audiolink_mask[2]
    #elif defined(_USE_AUDIOLINK) && _FRAGMENTSOURCE_AUDIOLINK_CHRONOTENSITY
        #define FRAGMENT_STREAM_0_MACRO triloop(audiolink_chronotensity*audiolink_mask[0])
        #define FRAGMENT_STREAM_1_MACRO triloop(audiolink_chronotensity*audiolink_mask[1])
        #define FRAGMENT_STREAM_2_MACRO triloop(audiolink_chronotensity*audiolink_mask[2])
    #else
        #define FRAGMENT_STREAM_0_MACRO _FragmentValue*fragment_mask[0]
        #define FRAGMENT_STREAM_1_MACRO _FragmentValue*fragment_mask[1]
        #define FRAGMENT_STREAM_2_MACRO _FragmentValue*fragment_mask[2]
    #endif

    #if defined(_COLORINGSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE3RD)
        float3 color_center = (inp[0].COLOR_NOISE_MACRO+inp[1].COLOR_NOISE_MACRO+inp[2].COLOR_NOISE_MACRO)/3.0;
        float color_time = COLOR_TIME_MACRO;
        #ifdef _COLORINGPARTITIONTYPE_VERTEX
            #define COLOR_STREAM_0_MACRO ColorNoisePingPong(inp[0].COLOR_NOISE_MACRO,COLOR_OFFSET_MACRO(0),color_time)*coloring_mask[0]
            #define COLOR_STREAM_1_MACRO ColorNoisePingPong(inp[1].COLOR_NOISE_MACRO,COLOR_OFFSET_MACRO(1),color_time)*coloring_mask[1]
            #define COLOR_STREAM_2_MACRO ColorNoisePingPong(inp[2].COLOR_NOISE_MACRO,COLOR_OFFSET_MACRO(2),color_time)*coloring_mask[2]
        #elif _COLORINGPARTITIONTYPE_SIDE
            float3 color_noise;
            color_noise.x = ColorSidePosNoisePingPong(inp[1].COLOR_NOISE_MACRO,inp[2].COLOR_NOISE_MACRO,inp[0].COLOR_NOISE_MACRO,color_center,COLOR_OFFSET_MACRO(0),color_time);
            color_noise.y = ColorSidePosNoisePingPong(inp[2].COLOR_NOISE_MACRO,inp[0].COLOR_NOISE_MACRO,inp[1].COLOR_NOISE_MACRO,color_center,COLOR_OFFSET_MACRO(1),color_time);
            color_noise.z = ColorSidePosNoisePingPong(inp[0].COLOR_NOISE_MACRO,inp[1].COLOR_NOISE_MACRO,inp[2].COLOR_NOISE_MACRO,color_center,COLOR_OFFSET_MACRO(2),color_time);

            #define COLOR_STREAM_0_MACRO float3(0.0,color_noise.y,color_noise.z)*coloring_mask[0]
            #define COLOR_STREAM_1_MACRO float3(color_noise.x,0.0,color_noise.z)*coloring_mask[1]
            #define COLOR_STREAM_2_MACRO float3(color_noise.x,color_noise.y,0.0)*coloring_mask[2]
        #elif _COLORINGPARTITIONTYPE_MESH
            #define COLOR_STREAM_0_MACRO ColorNoisePingPong(COLOR_CENTER_MACRO,COLOR_OFFSET_MACRO(0),color_time)*coloring_mask[0]
            #define COLOR_STREAM_1_MACRO ColorNoisePingPong(COLOR_CENTER_MACRO,COLOR_OFFSET_MACRO(1),color_time)*coloring_mask[1]
            #define COLOR_STREAM_2_MACRO ColorNoisePingPong(COLOR_CENTER_MACRO,COLOR_OFFSET_MACRO(2),color_time)*coloring_mask[2]
        #endif
    #elif defined(_USE_AUDIOLINK) && _COLORINGSOURCE_AUDIOLINK_VU
        #define COLOR_STREAM_0_MACRO audiolink_vu*audiolink_mask[0]
        #define COLOR_STREAM_1_MACRO audiolink_vu*audiolink_mask[1]
        #define COLOR_STREAM_2_MACRO audiolink_vu*audiolink_mask[2]
    #elif defined(_USE_AUDIOLINK) && _COLORINGSOURCE_AUDIOLINK_CHRONOTENSITY
        #define COLOR_STREAM_0_MACRO triloop(audiolink_chronotensity*audiolink_mask[0])
        #define COLOR_STREAM_1_MACRO triloop(audiolink_chronotensity*audiolink_mask[1])
        #define COLOR_STREAM_2_MACRO triloop(audiolink_chronotensity*audiolink_mask[2])
    #else
        #define COLOR_STREAM_0_MACRO _ColoringValue*coloring_mask[0]
        #define COLOR_STREAM_1_MACRO _ColoringValue*coloring_mask[1]
        #define COLOR_STREAM_2_MACRO _ColoringValue*coloring_mask[2]
    #endif

    #ifdef _COLORSOURCE_VERTEXCOLOR
        #define STREAM_VERTEXCOLOR_0_MACRO 
        #define STREAM_VERTEXCOLOR_1_MACRO 
        #define STREAM_VERTEXCOLOR_2_MACRO 
    #else
        #define STREAM_VERTEXCOLOR_0_MACRO //
        #define STREAM_VERTEXCOLOR_1_MACRO //
        #define STREAM_VERTEXCOLOR_2_MACRO //
    #endif

    float3 geometry_pos[3] = {inp[0].pos.xyz,inp[1].pos.xyz,inp[2].pos.xyz};
    #if defined(_GEOMETRY_SCALE) || defined(_GEOMETRY_EXTRUDE) || defined(_GEOMETRY_ROTATION) || defined(_ACTIVATE_GEOMETRYMESSY) || !defined(_PIXELIZATIONSPACE_DISABLE)
        float3 origin_pos = inp[0].origin_pos;
        float3 geometry_center = (geometry_pos[0]+geometry_pos[1]+geometry_pos[2])/3.0;
        float geometry_time = GEOMETRY_TIME_MACRO;
        #if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
            float3 geometry_center_noise = (inp[0].GEOMETRY_NOISE_MACRO+inp[1].GEOMETRY_NOISE_MACRO+inp[2].GEOMETRY_NOISE_MACRO)/3.0;
            float3 geometry_noise[3];
            geometry_noise[0] = VertexCenterBias(inp[1].GEOMETRY_NOISE_MACRO,inp[2].GEOMETRY_NOISE_MACRO,inp[0].GEOMETRY_NOISE_MACRO,geometry_center_noise,_GeometryPartitionBias);
            geometry_noise[1] = VertexCenterBias(inp[2].GEOMETRY_NOISE_MACRO,inp[0].GEOMETRY_NOISE_MACRO,inp[1].GEOMETRY_NOISE_MACRO,geometry_center_noise,_GeometryPartitionBias);
            geometry_noise[2] = VertexCenterBias(inp[0].GEOMETRY_NOISE_MACRO,inp[1].GEOMETRY_NOISE_MACRO,inp[2].GEOMETRY_NOISE_MACRO,geometry_center_noise,_GeometryPartitionBias);
            geometry_noise[0] *= geometry_mask[0];
            geometry_noise[1] *= geometry_mask[1];
            geometry_noise[2] *= geometry_mask[2];
        #else
            float3 geometry_center_noise = 0.0;
            float3 geometry_noise[3];
            geometry_noise[0] = GEOMETRY_NOISE_MACRO*geometry_mask[0];
            geometry_noise[1] = GEOMETRY_NOISE_MACRO*geometry_mask[1];
            geometry_noise[2] = GEOMETRY_NOISE_MACRO*geometry_mask[2];
        #endif

        #ifdef _GEOMETRY_SCALE
            #if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScale0,_GeometryScale1,GeometryNoisePingPong(geometry_noise[0],GEOMETRY_OFFSET_MACRO(0),geometry_time)));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScale0,_GeometryScale1,GeometryNoisePingPong(geometry_noise[1],GEOMETRY_OFFSET_MACRO(1),geometry_time)));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScale0,_GeometryScale1,GeometryNoisePingPong(geometry_noise[2],GEOMETRY_OFFSET_MACRO(2),geometry_time)));
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScale0,_GeometryScale1,audiolink_vu*audiolink_mask[0]));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScale0,_GeometryScale1,audiolink_vu*audiolink_mask[1]));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScale0,_GeometryScale1,audiolink_vu*audiolink_mask[2]));
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScale0,_GeometryScale1,triloop(audiolink_chronotensity*audiolink_mask[0])));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScale0,_GeometryScale1,triloop(audiolink_chronotensity*audiolink_mask[1])));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScale0,_GeometryScale1,triloop(audiolink_chronotensity*audiolink_mask[2])));
            #else
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScale0,_GeometryScale1,_GeometryValue));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScale0,_GeometryScale1,_GeometryValue));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScale0,_GeometryScale1,_GeometryValue));
            #endif
        #endif
        #ifdef _GEOMETRY_EXTRUDE
            #if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrude0,_GeometryExtrude1,GeometryNoisePingPong(geometry_noise[0],GEOMETRY_OFFSET_MACRO(0),geometry_time))*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrude0,_GeometryExtrude1,GeometryNoisePingPong(geometry_noise[1],GEOMETRY_OFFSET_MACRO(1),geometry_time))*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrude0,_GeometryExtrude1,GeometryNoisePingPong(geometry_noise[2],GEOMETRY_OFFSET_MACRO(2),geometry_time))*inp[2].world_normal;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrude0,_GeometryExtrude1,audiolink_vu*audiolink_mask[0])*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrude0,_GeometryExtrude1,audiolink_vu*audiolink_mask[1])*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrude0,_GeometryExtrude1,audiolink_vu*audiolink_mask[2])*inp[2].world_normal;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrude0,_GeometryExtrude1,triloop(audiolink_chronotensity*audiolink_mask[0]))*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrude0,_GeometryExtrude1,triloop(audiolink_chronotensity*audiolink_mask[1]))*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrude0,_GeometryExtrude1,triloop(audiolink_chronotensity*audiolink_mask[2]))*inp[2].world_normal;
            #else
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrude0,_GeometryExtrude1,_GeometryValue)*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrude0,_GeometryExtrude1,_GeometryValue)*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrude0,_GeometryExtrude1,_GeometryValue)*inp[2].world_normal;
            #endif
        #endif

        #ifdef _GEOMETRY_ROTATION
            float3 normal_average = (inp[0].world_normal+inp[1].world_normal+inp[2].world_normal)/3.0;
            float rotation_sign = sign(_GeometryRotationReverse*2.0-1.0);
            #if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*GEOMETRY_FUNC_NOISE_MACRO(geometry_noise[0],GEOMETRY_OFFSET_MACRO(0),geometry_time)*UNITY_PI*2.0,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*GEOMETRY_FUNC_NOISE_MACRO(geometry_noise[1],GEOMETRY_OFFSET_MACRO(1),geometry_time)*UNITY_PI*2.0,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*GEOMETRY_FUNC_NOISE_MACRO(geometry_noise[2],GEOMETRY_OFFSET_MACRO(2),geometry_time)*UNITY_PI*2.0,normal_average)+geometry_center;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*audiolink_vu*audiolink_mask[0]*UNITY_PI*2.0,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*audiolink_vu*audiolink_mask[1]*UNITY_PI*2.0,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*audiolink_vu*audiolink_mask[2]*UNITY_PI*2.0,normal_average)+geometry_center;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*audiolink_chronotensity*audiolink_mask[0]*UNITY_PI*2.0,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*audiolink_chronotensity*audiolink_mask[1]*UNITY_PI*2.0,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*audiolink_chronotensity*audiolink_mask[2]*UNITY_PI*2.0,normal_average)+geometry_center;
            #else
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*_GeometryValue*UNITY_PI*2.0,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*_GeometryValue*UNITY_PI*2.0,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*_GeometryValue*UNITY_PI*2.0,normal_average)+geometry_center;
            #endif
        #endif

        #ifdef _ACTIVATE_GEOMETRYMESSY
            float3 orbit[3] = {
                geometry_pos[0]-geometry_center+_GeometryMessyOrbitPosition.xyz,
                geometry_pos[1]-geometry_center+_GeometryMessyOrbitPosition.xyz,
                geometry_pos[2]-geometry_center+_GeometryMessyOrbitPosition.xyz};
            float3 dir_pi2 = float3(_GeometryMessyOrbitRotation,_GeometryMessyOrbitRotationForward,_GeometryMessyOrbitRotationRight)*UNITY_PI*2.0;
            float3 orbit_anim = ORBIT_ROTATION_AUDIOLINK_MACRO;
            float3 geometrymessy_time = GEOMETRYMESSY_TIME_MACRO;
            #if defined(_GEOMETRYMESSYSOURCE_NOISE1ST) || defined(_GEOMETRYMESSYSOURCE_NOISE2ND) || defined(_GEOMETRYMESSYSOURCE_NOISE3RD)
                float3 geometrymessy_center_noise = (inp[0].GEOMETRYMESSY_NOISE_MACRO+inp[1].GEOMETRYMESSY_NOISE_MACRO+inp[2].GEOMETRYMESSY_NOISE_MACRO)/3.0;
                float geometrymessy_mask_offset = (GEOMETRYMESSY_OFFSET_MACRO(0)+GEOMETRYMESSY_OFFSET_MACRO(1)+GEOMETRYMESSY_OFFSET_MACRO(2))/3.0;
                orbit_anim.xyz += GeometryMessyNoisePingPong(geometrymessy_center_noise,geometrymessy_mask_offset,geometrymessy_time)*_GeometryMessyOrbitVariance.xyz;
                float3 audiolink_wave = FUNC_ORBIT_WAVE_AUDIOLINK_WAVE_MACRO(geometrymessy_center_noise);
            #elif defined(_GEOMETRYMESSYSOURCE_PRIMITIVE)
                float random_id = random(id+_GeometryMessySeed);
                orbit_anim.xyz += random_id*_GeometryMessyOrbitVariance.xyz;
                float3 audiolink_wave = FUNC_ORBIT_WAVE_AUDIOLINK_WAVE_MACRO(random_id);

            #else
                orbit_anim.xyz += _GeometryMessyOrbitVariance.xyz;
                float3 audiolink_wave = FUNC_ORBIT_WAVE_AUDIOLINK_WAVE_MACRO(_GeometryValue);
            #endif

            float3 orbit_wave = float3(
                (orbit_anim.x+_GeometryMessyOrbitWaveZPhase+GEOMETRY_ORBIT_Z_TIME_MACRO),
                (orbit_anim.x+_GeometryMessyOrbitWaveXYPhase+GEOMETRY_ORBIT_XY_TIME_MACRO),
                (orbit_anim.x+_GeometryMessyOrbitWaveXYPhase+GEOMETRY_ORBIT_XY_TIME_MACRO)
            );

            float3 orbit_wave_r = float3(
                sin(orbit_wave.x*_GeometryMessyOrbitWaveZFrequency)*_GeometryMessyOrbitWaveZStrength,
                sin(orbit_wave.y*_GeometryMessyOrbitWaveXYFrequency)*_GeometryMessyOrbitWaveXYStrength,
                cos(orbit_wave.z*_GeometryMessyOrbitWaveXYFrequency)*_GeometryMessyOrbitWaveXYStrength
            );

            #ifdef _ORBITWAVEREFAUDIOLINK_VU
                orbit_wave_r *= audiolink_wave;
            #elif _ORBITWAVEREFAUDIOLINK_WAVE
                orbit_wave_r += float3(
                    audiolink_wave.x,
                    audiolink_wave.y*sin(orbit_wave.y*_GeometryMessyOrbitWaveXYFrequency),
                    audiolink_wave.z*cos(orbit_wave.z*_GeometryMessyOrbitWaveXYFrequency)
                );
            #endif

            orbit_anim += dir_pi2+geometrymessy_time;


            float3 orbit_dir = cos(orbit_anim.x)*inp[0].forward_dir*_GeometryMessyOrbitScaleZ + sin(orbit_anim.x)*inp[0].up_dir*_GeometryMessyOrbitScaleY;
            orbit_dir *= _GeometryMessyOrbitPosition.w+scale-1.0;
            float3 right_dir = normalize(cross(inp[0].forward_dir,inp[0].up_dir));

            orbit_dir = RodriguesRotation(orbit_dir,orbit_anim.y,inp[0].forward_dir);
            orbit_dir = RodriguesRotation(orbit_dir,orbit_anim.z,right_dir);
            orbit_dir += mul(UNITY_MATRIX_M,float4(orbit_wave_r*_GeometryMessyOrbitPosition.w,1.0));

            orbit[0] = orbit[0]+orbit_dir;
            orbit[1] = orbit[1]+orbit_dir;
            orbit[2] = orbit[2]+orbit_dir;

            #if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
                geometry_pos[0] = lerp(geometry_pos[0],orbit[0],GeometryNoisePingPong(geometry_noise[0],GEOMETRY_OFFSET_MACRO(0),geometry_time)*geometry_messy_mask[0]);
                geometry_pos[1] = lerp(geometry_pos[1],orbit[1],GeometryNoisePingPong(geometry_noise[1],GEOMETRY_OFFSET_MACRO(1),geometry_time)*geometry_messy_mask[1]);
                geometry_pos[2] = lerp(geometry_pos[2],orbit[2],GeometryNoisePingPong(geometry_noise[2],GEOMETRY_OFFSET_MACRO(2),geometry_time)*geometry_messy_mask[2]);
            #else
                geometry_pos[0] = lerp(geometry_pos[0],orbit[0],_GeometryValue*geometry_messy_mask[0]);
                geometry_pos[1] = lerp(geometry_pos[1],orbit[1],_GeometryValue*geometry_messy_mask[1]);
                geometry_pos[2] = lerp(geometry_pos[2],orbit[2],_GeometryValue*geometry_messy_mask[2]);
            #endif
        #endif
    #endif

    SWITCH_SHADE_WORLDPOS_MACRO float3 world_pos[3];
    float4 pos[3];
    float camera_distance[3];
    float4x4 matrix_v[3];
    [unroll]
    for(int i = 0; i < 3; i++){
        matrix_v[i] = float4x4(inp[i].matrix_v_0,inp[i].matrix_v_1,inp[i].matrix_v_2,0.0,0.0,0.0,1.0);

        #ifdef _PIXELIZATIONSPACE_POSTGEOMETRY
            geometry_pos[i] = Pixelization(geometry_pos[i],(scale));
        #endif

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
    o.fragment_noise = FRAGMENT_STREAM_0_MACRO;
    o.color_noise = COLOR_STREAM_0_MACRO;
    STREAM_VERTEXCOLOR_0_MACRO o.vertex_color = inp[0].vertex_color;
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
    o.fragment_noise = FRAGMENT_STREAM_1_MACRO;
    o.color_noise = COLOR_STREAM_1_MACRO;
    STREAM_VERTEXCOLOR_1_MACRO o.vertex_color = inp[1].vertex_color;
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
    o.fragment_noise = FRAGMENT_STREAM_2_MACRO;
    o.color_noise = COLOR_STREAM_2_MACRO;
    STREAM_VERTEXCOLOR_2_MACRO o.vertex_color = inp[2].vertex_color;
    o.normal = inp[2].normal;
    SWITCH_SHADE_WORLDPOS_MACRO o.world_pos = world_pos[2];
    SWITCH_WORLDNORMAL_MACRO o.world_normal = inp[2].world_normal;
    UNITY_TRANSFER_LIGHTING(o,inp[2].uv)
    UNITY_TRANSFER_INSTANCE_ID(inp[2], o);
    UNITY_TRANSFER_VERTEX_OUTPUT_STEREO(inp[2], o);
    stream.Append(o);

    stream.RestartStrip();

}
