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
    float orbit_mask[3];
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
    orbit_mask[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_OrbitMaskControlTex,_point_clamp, inp[0].uv, 0.0),_OrbitMaskControl);
    orbit_mask[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_OrbitMaskControlTex,_point_clamp, inp[1].uv, 0.0),_OrbitMaskControl);
    orbit_mask[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_OrbitMaskControlTex,_point_clamp, inp[2].uv, 0.0),_OrbitMaskControl);

    #ifdef _DEFINED_NOISE1ST
        TEX2D_NOISE1ST_MACRO noise1st_offset[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise1stOffsetControlTex, _point_clamp, inp[0].uv, 0.0),_Noise1stOffsetControl);
        TEX2D_NOISE1ST_MACRO noise1st_offset[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise1stOffsetControlTex, _point_clamp, inp[1].uv, 0.0),_Noise1stOffsetControl);
        TEX2D_NOISE1ST_MACRO noise1st_offset[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise1stOffsetControlTex, _point_clamp, inp[2].uv, 0.0),_Noise1stOffsetControl);
    #else
        noise1st_offset[0] = 1.0;
        noise1st_offset[1] = 1.0;
        noise1st_offset[2] = 1.0;
    #endif

    #ifdef _DEFINED_NOISE2ND
        TEX2D_NOISE2ND_MACRO noise2nd_offset[0] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise2ndOffsetControlTex, _point_clamp, inp[0].uv, 0.0),_Noise2ndOffsetControl);
        TEX2D_NOISE2ND_MACRO noise2nd_offset[1] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise2ndOffsetControlTex, _point_clamp, inp[1].uv, 0.0),_Noise2ndOffsetControl);
        TEX2D_NOISE2ND_MACRO noise2nd_offset[2] = lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_Noise2ndOffsetControlTex, _point_clamp, inp[2].uv, 0.0),_Noise2ndOffsetControl);
    #else
        noise2nd_offset[0] = 1.0;
        noise2nd_offset[1] = 1.0;
        noise2nd_offset[2] = 1.0;
    #endif

    #ifdef _DEFINED_NOISE3RD
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

    float3 fragment_stream[3];
    #ifdef _DEFINED_FRAGMENT_NOISE
        float3 fragment_noise;
        float3 fragment_center = (inp[0].FRAGMENT_NOISE_MACRO+inp[1].FRAGMENT_NOISE_MACRO+inp[2].FRAGMENT_NOISE_MACRO)/3.0;
        float fragment_time = FRAGMENT_TIME_MACRO;
        #ifdef _PARTITIONTYPE_VERTEX
            fragment_noise = float3(
                FragmentNoisePingPong(inp[0].FRAGMENT_NOISE_MACRO,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO,
                FragmentNoisePingPong(inp[1].FRAGMENT_NOISE_MACRO,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO,
                FragmentNoisePingPong(inp[2].FRAGMENT_NOISE_MACRO,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO);
            fragment_noise.x = fragment_noise.x*fragment_mask[0];
            fragment_noise.y = fragment_noise.y*fragment_mask[1];
            fragment_noise.z = fragment_noise.z*fragment_mask[2];
            fragment_noise.x = lerp(fragment_noise.x,1.0-fragment_noise.x,_FragmentInverse);
            fragment_noise.y = lerp(fragment_noise.y,1.0-fragment_noise.y,_FragmentInverse);
            fragment_noise.z = lerp(fragment_noise.z,1.0-fragment_noise.z,_FragmentInverse);

            fragment_stream[0] = float3(0.0,fragment_noise.x,fragment_noise.x);
            fragment_stream[1] = float3(fragment_noise.y,0.0,fragment_noise.y);
            fragment_stream[2] = float3(fragment_noise.z,fragment_noise.z,0.0);

        #elif _PARTITIONTYPE_SIDE
            fragment_noise.x = FragmentSidePosNoisePingPong(inp[1].FRAGMENT_NOISE_MACRO,inp[2].FRAGMENT_NOISE_MACRO,inp[0].FRAGMENT_NOISE_MACRO,fragment_center,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO;
            fragment_noise.y = FragmentSidePosNoisePingPong(inp[2].FRAGMENT_NOISE_MACRO,inp[0].FRAGMENT_NOISE_MACRO,inp[1].FRAGMENT_NOISE_MACRO,fragment_center,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO;
            fragment_noise.z = FragmentSidePosNoisePingPong(inp[0].FRAGMENT_NOISE_MACRO,inp[1].FRAGMENT_NOISE_MACRO,inp[2].FRAGMENT_NOISE_MACRO,fragment_center,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO;

            fragment_noise.x = lerp(1.0-fragment_noise.x,fragment_noise.x,_FragmentInverse);
            fragment_noise.y = lerp(1.0-fragment_noise.y,fragment_noise.y,_FragmentInverse);
            fragment_noise.z = lerp(1.0-fragment_noise.z,fragment_noise.z,_FragmentInverse);

            fragment_stream[0] = float3(0.0,1.0-fragment_noise.y*fragment_mask[0],1.0-fragment_noise.z*fragment_mask[0])*fragment_mask[0];
            fragment_stream[1] = float3(1.0-fragment_noise.x*fragment_mask[1],0.0,1.0-fragment_noise.z*fragment_mask[1])*fragment_mask[1];
            fragment_stream[2] = float3(1.0-fragment_noise.x*fragment_mask[2],1.0-fragment_noise.y*fragment_mask[2],0.0)*fragment_mask[2];

        #elif _PARTITIONTYPE_MESH
            fragment_stream[0] = FragmentNoisePingPong(FRAGMENT_CENTER_MACRO,FRAGMENT_OFFSET_MACRO(0),fragment_time)LINEFADEMODE_INSTANT_MACRO*fragment_mask[0];
            fragment_stream[1] = FragmentNoisePingPong(FRAGMENT_CENTER_MACRO,FRAGMENT_OFFSET_MACRO(1),fragment_time)LINEFADEMODE_INSTANT_MACRO*fragment_mask[1];
            fragment_stream[2] = FragmentNoisePingPong(FRAGMENT_CENTER_MACRO,FRAGMENT_OFFSET_MACRO(2),fragment_time)LINEFADEMODE_INSTANT_MACRO*fragment_mask[2];
        #endif
    #elif defined(_USE_AUDIOLINK) && _FRAGMENTSOURCE_AUDIOLINK_VU
        fragment_stream[0] = audiolink_vu*audiolink_mask[0];
        fragment_stream[1] = audiolink_vu*audiolink_mask[1];
        fragment_stream[2] = audiolink_vu*audiolink_mask[2];
    #elif defined(_USE_AUDIOLINK) && _FRAGMENTSOURCE_AUDIOLINK_CHRONOTENSITY
        fragment_stream[0] = triloop(audiolink_chronotensity*audiolink_mask[0]);
        fragment_stream[1] = triloop(audiolink_chronotensity*audiolink_mask[1]);
        fragment_stream[2] = triloop(audiolink_chronotensity*audiolink_mask[2]);
    #else
        fragment_stream[0] = _FragmentValue*fragment_mask[0];
        fragment_stream[1] = _FragmentValue*fragment_mask[1];
        fragment_stream[2] = _FragmentValue*fragment_mask[2];
    #endif

    fragment_stream[0] = saturate(lerp(fragment_stream[0],1.0-fragment_stream[0],_FragmentInverse));
    fragment_stream[1] = saturate(lerp(fragment_stream[1],1.0-fragment_stream[1],_FragmentInverse));
    fragment_stream[2] = saturate(lerp(fragment_stream[2],1.0-fragment_stream[2],_FragmentInverse));

    float3 color_stream[3];
    #ifdef _DEFINED_COLORING_NOISE
        float3 color_center = (inp[0].COLOR_NOISE_MACRO+inp[1].COLOR_NOISE_MACRO+inp[2].COLOR_NOISE_MACRO)/3.0;
        float color_time = COLOR_TIME_MACRO;
        #ifdef _COLORINGPARTITIONTYPE_VERTEX
            color_stream[0] = ColorNoisePingPong(inp[0].COLOR_NOISE_MACRO,COLOR_OFFSET_MACRO(0),color_time)*coloring_mask[0];
            color_stream[1] = ColorNoisePingPong(inp[1].COLOR_NOISE_MACRO,COLOR_OFFSET_MACRO(1),color_time)*coloring_mask[1];
            color_stream[2] = ColorNoisePingPong(inp[2].COLOR_NOISE_MACRO,COLOR_OFFSET_MACRO(2),color_time)*coloring_mask[2];
        #elif _COLORINGPARTITIONTYPE_SIDE
            float3 color_noise;
            color_noise.x = ColorSidePosNoisePingPong(inp[1].COLOR_NOISE_MACRO,inp[2].COLOR_NOISE_MACRO,inp[0].COLOR_NOISE_MACRO,color_center,COLOR_OFFSET_MACRO(0),color_time);
            color_noise.y = ColorSidePosNoisePingPong(inp[2].COLOR_NOISE_MACRO,inp[0].COLOR_NOISE_MACRO,inp[1].COLOR_NOISE_MACRO,color_center,COLOR_OFFSET_MACRO(1),color_time);
            color_noise.z = ColorSidePosNoisePingPong(inp[0].COLOR_NOISE_MACRO,inp[1].COLOR_NOISE_MACRO,inp[2].COLOR_NOISE_MACRO,color_center,COLOR_OFFSET_MACRO(2),color_time);

            color_stream[0] = float3(0.0,color_noise.y,color_noise.z)*coloring_mask[0];
            color_stream[1] = float3(color_noise.x,0.0,color_noise.z)*coloring_mask[1];
            color_stream[2] = float3(color_noise.x,color_noise.y,0.0)*coloring_mask[2];
        #elif _COLORINGPARTITIONTYPE_MESH
            color_stream[0] = ColorNoisePingPong(COLOR_CENTER_MACRO,COLOR_OFFSET_MACRO(0),color_time)*coloring_mask[0];
            color_stream[1] = ColorNoisePingPong(COLOR_CENTER_MACRO,COLOR_OFFSET_MACRO(1),color_time)*coloring_mask[1];
            color_stream[2] = ColorNoisePingPong(COLOR_CENTER_MACRO,COLOR_OFFSET_MACRO(2),color_time)*coloring_mask[2];
        #endif
    #elif defined(_USE_AUDIOLINK) && _COLORINGSOURCE_AUDIOLINK_VU
        color_stream[0] = audiolink_vu*audiolink_mask[0];
        color_stream[1] = audiolink_vu*audiolink_mask[1];
        color_stream[2] = audiolink_vu*audiolink_mask[2];
    #elif defined(_USE_AUDIOLINK) && _COLORINGSOURCE_AUDIOLINK_CHRONOTENSITY
        color_stream[0] = triloop(audiolink_chronotensity*audiolink_mask[0]);
        color_stream[1] = triloop(audiolink_chronotensity*audiolink_mask[1]);
        color_stream[2] = triloop(audiolink_chronotensity*audiolink_mask[2]);
    #else
        color_stream[0] = _ColoringValue*coloring_mask[0];
        color_stream[1] = _ColoringValue*coloring_mask[1];
        color_stream[2] = _ColoringValue*coloring_mask[2];
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
    #if defined(_GEOMETRY_SCALE) || defined(_GEOMETRY_EXTRUDE) || defined(_GEOMETRY_ROTATION) || defined(_ACTIVATE_ORBIT)
        float3 origin_pos = inp[0].origin_pos;
        float3 geometry_center = (geometry_pos[0]+geometry_pos[1]+geometry_pos[2])/3.0;
        float geometry_time = GEOMETRY_TIME_MACRO;
        #ifdef _DEFINED_GEOMETRY_NOISE
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
            #ifdef _DEFINED_GEOMETRY_NOISE
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,GeometryNoisePingPong(geometry_noise[0],GEOMETRY_OFFSET_MACRO(0),geometry_time)));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,GeometryNoisePingPong(geometry_noise[1],GEOMETRY_OFFSET_MACRO(1),geometry_time)));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,GeometryNoisePingPong(geometry_noise[2],GEOMETRY_OFFSET_MACRO(2),geometry_time)));
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,audiolink_vu*audiolink_mask[0]));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,audiolink_vu*audiolink_mask[1]));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,audiolink_vu*audiolink_mask[2]));
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,triloop(audiolink_chronotensity*audiolink_mask[0])));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,triloop(audiolink_chronotensity*audiolink_mask[1])));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,triloop(audiolink_chronotensity*audiolink_mask[2])));
            #else
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,_GeometryValue));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,_GeometryValue));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,_GeometryValue));
            #endif
        #endif
        #ifdef _GEOMETRY_EXTRUDE
            #ifdef _DEFINED_GEOMETRY_NOISE
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,GeometryNoisePingPong(geometry_noise[0],GEOMETRY_OFFSET_MACRO(0),geometry_time))*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,GeometryNoisePingPong(geometry_noise[1],GEOMETRY_OFFSET_MACRO(1),geometry_time))*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,GeometryNoisePingPong(geometry_noise[2],GEOMETRY_OFFSET_MACRO(2),geometry_time))*inp[2].world_normal;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,audiolink_vu*audiolink_mask[0])*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,audiolink_vu*audiolink_mask[1])*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,audiolink_vu*audiolink_mask[2])*inp[2].world_normal;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,triloop(audiolink_chronotensity*audiolink_mask[0]))*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,triloop(audiolink_chronotensity*audiolink_mask[1]))*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,triloop(audiolink_chronotensity*audiolink_mask[2]))*inp[2].world_normal;
            #else
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,_GeometryValue)*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,_GeometryValue)*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,_GeometryValue)*inp[2].world_normal;
            #endif
        #endif

        #ifdef _GEOMETRY_ROTATION
            float3 normal_average = (inp[0].world_normal+inp[1].world_normal+inp[2].world_normal)/3.0;
            float rotation_sign = sign(_GeometryRotationReverse*2.0-1.0);
            #ifdef _DEFINED_GEOMETRY_NOISE
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*GEOMETRY_FUNC_NOISE_MACRO(geometry_noise[0],GEOMETRY_OFFSET_MACRO(0),geometry_time)*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*GEOMETRY_FUNC_NOISE_MACRO(geometry_noise[1],GEOMETRY_OFFSET_MACRO(1),geometry_time)*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*GEOMETRY_FUNC_NOISE_MACRO(geometry_noise[2],GEOMETRY_OFFSET_MACRO(2),geometry_time)*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*audiolink_vu*audiolink_mask[0]*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*audiolink_vu*audiolink_mask[1]*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*audiolink_vu*audiolink_mask[2]*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*audiolink_chronotensity*audiolink_mask[0]*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*audiolink_chronotensity*audiolink_mask[1]*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*audiolink_chronotensity*audiolink_mask[2]*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
            #else
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*_GeometryValue*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*_GeometryValue*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*_GeometryValue*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
            #endif
        #endif

        #ifdef _ACTIVATE_ORBIT
            float3 orbit[3] = {
                geometry_pos[0]-geometry_center+_OrbitOffset.xyz,
                geometry_pos[1]-geometry_center+_OrbitOffset.xyz,
                geometry_pos[2]-geometry_center+_OrbitOffset.xyz};
            float3 dir_pi2 = float3(_OrbitRotation.x,_OrbitRotation.y,_OrbitRotation.z)*UNITY_TWO_PI;
            float3 orbit_anim = ORBIT_ROTATION_AUDIOLINK_MACRO;
            float3 orbit_rotation_time = ORBIT_ROTATION_TIME_MACRO;
            #ifdef _DEFINED_ORBITROTATION_NOISE
                float3 orbit_rotation_center_noise = (inp[0].ORBITROTATION_NOISE_MACRO+inp[1].ORBITROTATION_NOISE_MACRO+inp[2].ORBITROTATION_NOISE_MACRO)/3.0;
                float orbit_rotation_mask_offset = (ORBITROTATION_OFFSET_MACRO(0)+ORBITROTATION_OFFSET_MACRO(1)+ORBITROTATION_OFFSET_MACRO(2))/3.0;
                orbit_anim.xyz += OrbitRotationNoisePingPong(orbit_rotation_center_noise,orbit_rotation_mask_offset,orbit_rotation_time)*_OrbitRotationVariance.xyz;
                float3 audiolink_spectrum = FUNC_ORBIT_WAVE_AUDIOLINK_SPECTRUM_MACRO(orbit_rotation_center_noise);
            #elif defined(_ORBITROTATIONSOURCE_PRIMITIVE)
                float orbit_rotation_random = random(id+_OrbitRotationSeed);
                orbit_anim.xyz += orbit_rotation_random*_OrbitRotationVariance.xyz;
                float3 audiolink_spectrum = FUNC_ORBIT_WAVE_AUDIOLINK_SPECTRUM_MACRO(orbit_rotation_random);

            #else
                orbit_anim.xyz += _OrbitRotationVariance.xyz;
                float3 audiolink_spectrum = FUNC_ORBIT_WAVE_AUDIOLINK_SPECTRUM_MACRO(0.0);
            #endif

            float3 orbit_wave = float3(
                (orbit_anim.x+_OrbitWavePhase.y+ORBIT_WAVE_Z_TIME_MACRO)*_OrbitWaveFrequency.y,
                (orbit_anim.x+_OrbitWavePhase.x+ORBIT_WAVE_XY_TIME_MACRO)*_OrbitWaveFrequency.x,
                (orbit_anim.x+_OrbitWavePhase.x+ORBIT_WAVE_XY_TIME_MACRO)*_OrbitWaveFrequency.x
            );

            float3 orbit_wave_r = float3(
                sin(orbit_wave.x)*_OrbitWaveStrength.y,
                sin(orbit_anim.x)*sin(orbit_wave.y)*_OrbitWaveStrength.x,
                cos(orbit_anim.x)*sin(orbit_wave.z)*_OrbitWaveStrength.x
            );

            orbit_anim += dir_pi2+orbit_rotation_time;

            #ifdef _ORBITWAVEREFAUDIOLINK_VU
                orbit_wave_r *= audiolink_spectrum;
            #elif _ORBITWAVEREFAUDIOLINK_SPECTRUM
                orbit_wave_r += float3(
                    audiolink_spectrum.x,
                    sin(orbit_anim.x)*audiolink_spectrum.y,
                    cos(orbit_anim.x)*audiolink_spectrum.z
                );
            #endif

            float3 orbit_dir = cos(orbit_anim.x)*float3(0.0,1.0,0.0)*_OrbitScale.y + sin(orbit_anim.x)*float3(0.0,0.0,1.0)*_OrbitScale.z;
            orbit_dir *= _OrbitScale.w;

            orbit_dir += orbit_wave_r*_OrbitScale.w;
            orbit_dir = RodriguesRotation(orbit_dir,orbit_anim.y,float3(0.0,1.0,0.0));
            orbit_dir = RodriguesRotation(orbit_dir,orbit_anim.z,float3(0.0,0.0,1.0));
            orbit_dir = mul(UNITY_MATRIX_M,float4(orbit_dir,1.0));

            orbit[0] = orbit[0]+orbit_dir;
            orbit[1] = orbit[1]+orbit_dir;
            orbit[2] = orbit[2]+orbit_dir;

            #ifdef _DEFINED_ORBIT_NOISE
                float orbit_time = ORBIT_TIME_MACRO;
                float3 orbit_noise = (inp[0].ORBIT_NOISE_MACRO+inp[1].ORBIT_NOISE_MACRO+inp[2].ORBIT_NOISE_MACRO)/3.0;
                geometry_pos[0] = lerp(geometry_pos[0],orbit[0],OrbitNoisePingPong(orbit_noise,ORBIT_OFFSET_MACRO(0),orbit_time)*orbit_mask[0]);
                geometry_pos[1] = lerp(geometry_pos[1],orbit[1],OrbitNoisePingPong(orbit_noise,ORBIT_OFFSET_MACRO(1),orbit_time)*orbit_mask[1]);
                geometry_pos[2] = lerp(geometry_pos[2],orbit[2],OrbitNoisePingPong(orbit_noise,ORBIT_OFFSET_MACRO(2),orbit_time)*orbit_mask[2]);
            #elif _ORBITSOURCE_PRIMITIVE
                float orbit_random = random(id+_OrbitSeed)>=_OrbitPrimitiveThreshold;
                geometry_pos[0] = lerp(geometry_pos[0],orbit[0],orbit_random*orbit_mask[0]);
                geometry_pos[1] = lerp(geometry_pos[1],orbit[1],orbit_random*orbit_mask[1]);
                geometry_pos[2] = lerp(geometry_pos[2],orbit[2],orbit_random*orbit_mask[2]);
            #else
                geometry_pos[0] = lerp(geometry_pos[0],orbit[0],_OrbitValue*orbit_mask[0]);
                geometry_pos[1] = lerp(geometry_pos[1],orbit[1],_OrbitValue*orbit_mask[1]);
                geometry_pos[2] = lerp(geometry_pos[2],orbit[2],_OrbitValue*orbit_mask[2]);
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
    o.fragment_noise = fragment_stream[0];
    o.color_noise = color_stream[0];
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
    o.fragment_noise = fragment_stream[1];
    o.color_noise = color_stream[1];
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
    o.fragment_noise = fragment_stream[2];
    o.color_noise = color_stream[2];
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
