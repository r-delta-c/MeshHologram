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

    float2 transform_uv[3];
    float2 uv_mesh;
    float2 uv_side[3];

    #ifdef _PARTITIONTYPE_VERTEX
        CONTROL_VERTEX_MACRO(_FragmentMaskControlTex);
        float fragment_mask[3] = CONTROL_MACRO3(
            _FragmentMaskControlTex,_point_repeat,_FragmentMaskControl,transform_uv[0],transform_uv[1],transform_uv[2]);
        #ifdef _FRAGMENTSOURCE_NOISE1ST
            CONTROL_VERTEX_MACRO(_Noise1stOffsetControlTex);
            float fragment_offset[3] = NOISE1ST_OFFSET_CONTROL_VERTEX_MACRO;
            CONTROL_VERTEX_MACRO(_Noise1stALMaskControlTex)
            float fragment_noise_al_mask[3] = NOISE1ST_AL_MASK_CONTROL_VERTEX_MACRO;
        #elif _FRAGMENTSOURCE_NOISE2ND
            CONTROL_VERTEX_MACRO(_Noise2ndOffsetControlTex);
            float fragment_offset[3] = NOISE2ND_OFFSET_CONTROL_VERTEX_MACRO;
            CONTROL_VERTEX_MACRO(_Noise2ndALMaskControlTex)
            float fragment_noise_al_mask[3] = NOISE2ND_AL_MASK_CONTROL_VERTEX_MACRO;
        #elif _FRAGMENTSOURCE_NOISE3RD
            CONTROL_VERTEX_MACRO(_Noise3rdOffsetControlTex);
            float fragment_offset[3] = NOISE3RD_OFFSET_CONTROL_VERTEX_MACRO;
            CONTROL_VERTEX_MACRO(_Noise3rdALMaskControlTex)
            float fragment_noise_al_mask[3] = NOISE3RD_AL_MASK_CONTROL_VERTEX_MACRO;
        #endif

        #define FRAGMENT_NOISE_AL_MASK_MACRO float3(fragment_noise_al_mask[0],fragment_noise_al_mask[1],fragment_noise_al_mask[2])

    #elif _PARTITIONTYPE_SIDE
        CONTROL_SIDE_MACRO(_FragmentMaskControlTex);
        float fragment_mask[3] = CONTROL_MACRO3(
            _FragmentMaskControlTex,_point_repeat,_FragmentMaskControl,uv_side[0],uv_side[1],uv_side[2]);
        #ifdef _FRAGMENTSOURCE_NOISE1ST
            CONTROL_SIDE_MACRO(_Noise1stOffsetControlTex);
            float fragment_offset[3] = NOISE1ST_OFFSET_CONTROL_SIDE_MACRO;
            CONTROL_SIDE_MACRO(_Noise1stALMaskControlTex)
            float fragment_noise_al_mask[3] = NOISE1ST_AL_MASK_CONTROL_SIDE_MACRO;
        #elif _FRAGMENTSOURCE_NOISE2ND
            CONTROL_SIDE_MACRO(_Noise2ndOffsetControlTex);
            float fragment_offset[3] = NOISE2ND_OFFSET_CONTROL_SIDE_MACRO;
            CONTROL_SIDE_MACRO(_Noise2ndALMaskControlTex)
            float fragment_noise_al_mask[3] = NOISE2ND_AL_MASK_CONTROL_SIDE_MACRO;
        #elif _FRAGMENTSOURCE_NOISE3RD
            CONTROL_SIDE_MACRO(_Noise3rdOffsetControlTex);
            float fragment_offset[3] = NOISE3RD_OFFSET_CONTROL_SIDE_MACRO;
            CONTROL_SIDE_MACRO(_Noise3rdALMaskControlTex)
            float fragment_noise_al_mask[3] = NOISE3RD_AL_MASK_CONTROL_SIDE_MACRO;
        #endif

        #define FRAGMENT_NOISE_AL_MASK_MACRO float3(fragment_noise_al_mask[0],fragment_noise_al_mask[1],fragment_noise_al_mask[2])

    #elif _PARTITIONTYPE_MESH
        CONTROL_MESH_MACRO(_FragmentMaskControlTex);
        float fragment_mask = CONTROL_MACRO(_FragmentMaskControlTex,_point_repeat,_FragmentMaskControl,uv_mesh);
        #ifdef _FRAGMENTSOURCE_NOISE1ST
            CONTROL_MESH_MACRO(_Noise1stOffsetControlTex);
            float fragment_offset = NOISE1ST_OFFSET_CONTROL_MESH_MACRO;
            CONTROL_MESH_MACRO(_Noise1stALMaskControlTex)
            float fragment_noise_al_mask = NOISE1ST_AL_MASK_CONTROL_MESH_MACRO;
        #elif _FRAGMENTSOURCE_NOISE2ND
            CONTROL_MESH_MACRO(_Noise2ndOffsetControlTex);
            float fragment_offset = NOISE2ND_OFFSET_CONTROL_MESH_MACRO;
            CONTROL_MESH_MACRO(_Noise2ndALMaskControlTex)
            float fragment_noise_al_mask = NOISE2ND_AL_MASK_CONTROL_MESH_MACRO;
        #elif _FRAGMENTSOURCE_NOISE3RD
            CONTROL_MESH_MACRO(_Noise3rdOffsetControlTex);
            float fragment_offset = NOISE3RD_OFFSET_CONTROL_MESH_MACRO;
            CONTROL_MESH_MACRO(_Noise3rdALMaskControlTex)
            float fragment_noise_al_mask = NOISE3RD_AL_MASK_CONTROL_MESH_MACRO;
        #endif

        #define FRAGMENT_NOISE_AL_MASK_MACRO fragment_noise_al_mask

    #endif

    #ifdef _COLORINGPARTITIONTYPE_VERTEX
        CONTROL_VERTEX_MACRO(_ColoringMaskControlTex);
        float coloring_mask[3] = CONTROL_MACRO3(
            _ColoringMaskControlTex,_point_repeat,_ColoringMaskControl,transform_uv[0],transform_uv[1],transform_uv[2]);
        #ifdef _COLORINGSOURCE_NOISE1ST
            CONTROL_VERTEX_MACRO(_Noise1stOffsetControlTex);
            float coloring_offset[3] = NOISE1ST_OFFSET_CONTROL_VERTEX_MACRO;
            CONTROL_VERTEX_MACRO(_Noise1stALMaskControlTex);
            float coloring_noise_al_mask[3] = NOISE1ST_AL_MASK_CONTROL_VERTEX_MACRO;
        #elif _COLORINGSOURCE_NOISE2ND
            CONTROL_VERTEX_MACRO(_Noise2ndOffsetControlTex);
            float coloring_offset[3] = NOISE2ND_OFFSET_CONTROL_VERTEX_MACRO;
            CONTROL_VERTEX_MACRO(_Noise2ndALMaskControlTex);
            float coloring_noise_al_mask[3] = NOISE2ND_AL_MASK_CONTROL_VERTEX_MACRO;
        #elif _COLORINGSOURCE_NOISE3RD
            CONTROL_VERTEX_MACRO(_Noise3rdOffsetControlTex);
            float coloring_offset[3] = NOISE3RD_OFFSET_CONTROL_VERTEX_MACRO;
            CONTROL_VERTEX_MACRO(_Noise3rdALMaskControlTex);
            float coloring_noise_al_mask[3] = NOISE3RD_AL_MASK_CONTROL_VERTEX_MACRO;
        #endif

        #define COLORING_MASK_MACRO float3(coloring_mask[0],coloring_mask[1],coloring_mask[2])
        #define COLORING_NOISE_AL_MASK_MACRO float3(coloring_noise_al_mask[0],coloring_noise_al_mask[1],coloring_noise_al_mask[2])

    #elif _COLORINGPARTITIONTYPE_SIDE
        CONTROL_SIDE_MACRO(_ColoringMaskControlTex);
        float coloring_mask[3] = CONTROL_MACRO3(
            _ColoringMaskControlTex,_point_repeat,_ColoringMaskControl,uv_side[0],uv_side[1],uv_side[2]);
        #ifdef _COLORINGSOURCE_NOISE1ST
            CONTROL_SIDE_MACRO(_Noise1stOffsetControlTex);
            float coloring_offset[3] = NOISE1ST_OFFSET_CONTROL_SIDE_MACRO;
            CONTROL_SIDE_MACRO(_Noise1stALMaskControlTex);
            float coloring_noise_al_mask[3] = NOISE1ST_AL_MASK_CONTROL_SIDE_MACRO;
        #elif _COLORINGSOURCE_NOISE2ND
            CONTROL_SIDE_MACRO(_Noise2ndOffsetControlTex);
            float coloring_offset[3] = NOISE2ND_OFFSET_CONTROL_SIDE_MACRO;
            CONTROL_SIDE_MACRO(_Noise2ndALMaskControlTex);
            float coloring_noise_al_mask[3] = NOISE2ND_AL_MASK_CONTROL_SIDE_MACRO;
        #elif _COLORINGSOURCE_NOISE3RD
            CONTROL_SIDE_MACRO(_Noise3rdOffsetControlTex);
            float coloring_offset[3] = NOISE3RD_OFFSET_CONTROL_SIDE_MACRO;
            CONTROL_SIDE_MACRO(_Noise3rdALMaskControlTex);
            float coloring_noise_al_mask[3] = NOISE3RD_AL_MASK_CONTROL_SIDE_MACRO;
        #endif

        #define COLORING_MASK_MACRO float3(coloring_mask[0],coloring_mask[1],coloring_mask[2])
        #define COLORING_NOISE_AL_MASK_MACRO float3(coloring_noise_al_mask[0],coloring_noise_al_mask[1],coloring_noise_al_mask[2])

    #elif _COLORINGPARTITIONTYPE_MESH
        CONTROL_MESH_MACRO(_ColoringMaskControlTex);
        float coloring_mask = CONTROL_MACRO(_ColoringMaskControlTex,_point_repeat,_ColoringMaskControl,uv_mesh);
        #ifdef _COLORINGSOURCE_NOISE1ST
            CONTROL_MESH_MACRO(_Noise1stOffsetControlTex);
            float coloring_offset = NOISE1ST_OFFSET_CONTROL_MESH_MACRO;
            CONTROL_MESH_MACRO(_Noise1stALMaskControlTex);
            float coloring_noise_al_mask = NOISE1ST_AL_MASK_CONTROL_MESH_MACRO;
        #elif _COLORINGSOURCE_NOISE2ND
            CONTROL_MESH_MACRO(_Noise2ndOffsetControlTex);
            float coloring_offset = NOISE2ND_OFFSET_CONTROL_MESH_MACRO;
            CONTROL_MESH_MACRO(_Noise2ndALMaskControlTex);
            float coloring_noise_al_mask = NOISE2ND_AL_MASK_CONTROL_MESH_MACRO;
        #elif _COLORINGSOURCE_NOISE3RD
            CONTROL_MESH_MACRO(_Noise3rdOffsetControlTex);
            float coloring_offset = NOISE3RD_OFFSET_CONTROL_MESH_MACRO;
            CONTROL_MESH_MACRO(_Noise3rdALMaskControlTex);
            float coloring_noise_al_mask = NOISE3RD_AL_MASK_CONTROL_MESH_MACRO;
        #endif

        #define COLORING_MASK_MACRO coloring_mask
        #define COLORING_NOISE_AL_MASK_MACRO coloring_noise_al_mask

    #endif

    CONTROL_MESH_MACRO(_GeometryMaskControlTex);
    float geometry_mask = CONTROL_MACRO(_GeometryMaskControlTex,_point_repeat,_GeometryMaskControl,uv_mesh);

    float2 geometry_uv[3];
    geometry_uv[0] = VertexCenterBias(transform_uv[1],transform_uv[2],transform_uv[0],uv_mesh,_GeometryPartitionBias);
    geometry_uv[1] = VertexCenterBias(transform_uv[2],transform_uv[0],transform_uv[1],uv_mesh,_GeometryPartitionBias);
    geometry_uv[2] = VertexCenterBias(transform_uv[0],transform_uv[1],transform_uv[2],uv_mesh,_GeometryPartitionBias);
    float geometry_pushpull_mask[3] = CONTROL_MACRO3(
            _GeometryMaskControlTex,_point_repeat,_GeometryALMaskControl,geometry_uv[0],geometry_uv[1],geometry_uv[2]);

    #ifdef _GEOMETRYSOURCE_NOISE1ST
        CONTROL_MESH_MACRO(_Noise1stOffsetControlTex);
        float geometry_offset = NOISE1ST_OFFSET_CONTROL_MESH_MACRO;
        CONTROL_MESH_MACRO(_Noise1stALMaskControlTex);
        float geometry_al_mask = NOISE1ST_AL_MASK_CONTROL_MESH_MACRO;
        geometry_uv[0] = VertexCenterBias(transform_uv[1],transform_uv[2],transform_uv[0],uv_mesh,_GeometryPartitionBias);
        geometry_uv[1] = VertexCenterBias(transform_uv[2],transform_uv[0],transform_uv[1],uv_mesh,_GeometryPartitionBias);
        geometry_uv[2] = VertexCenterBias(transform_uv[0],transform_uv[1],transform_uv[2],uv_mesh,_GeometryPartitionBias);
        float geometry_pushpull_offset[3] = CONTROL_MACRO3(
            _Noise1stOffsetControlTex,_point_repeat,_Noise1stOffsetControl,geometry_uv[0],geometry_uv[1],geometry_uv[2]);
        float geometry_pushpull_al_mask[3] = CONTROL_MACRO3(
            _Noise1stALMaskControlTex,_point_repeat,_Noise1stALMaskControl,geometry_uv[0],geometry_uv[1],geometry_uv[2]);
        #define GEOMETRY_PUSHPULL_AL_MASK_MACRO(n) geometry_pushpull_al_mask[n]
    #elif _GEOMETRYSOURCE_NOISE2ND
        CONTROL_MESH_MACRO(_Noise2ndOffsetControlTex);
        float geometry_offset = NOISE2ND_OFFSET_CONTROL_MESH_MACRO;
        CONTROL_MESH_MACRO(_Noise2ndALMaskControlTex);
        float geometry_al_mask = NOISE2ND_AL_MASK_CONTROL_MESH_MACRO;
        geometry_uv[0] = VertexCenterBias(transform_uv[1],transform_uv[2],transform_uv[0],uv_mesh,_GeometryPartitionBias);
        geometry_uv[1] = VertexCenterBias(transform_uv[2],transform_uv[0],transform_uv[1],uv_mesh,_GeometryPartitionBias);
        geometry_uv[2] = VertexCenterBias(transform_uv[0],transform_uv[1],transform_uv[2],uv_mesh,_GeometryPartitionBias);
        float geometry_pushpull_offset[3] = CONTROL_MACRO3(
            _Noise2ndOffsetControlTex,_point_repeat,_Noise2ndOffsetControl,geometry_uv[0],geometry_uv[1],geometry_uv[2]);
        float geometry_pushpull_al_mask[3] = CONTROL_MACRO3(
            _Noise2ndALMaskControlTex,_point_repeat,_Noise2ndALMaskControl,geometry_uv[0],geometry_uv[1],geometry_uv[2]);
        #define GEOMETRY_PUSHPULL_AL_MASK_MACRO(n) geometry_pushpull_al_mask[n]
    #elif _GEOMETRYSOURCE_NOISE3RD
        CONTROL_MESH_MACRO(_Noise3rdOffsetControlTex);
        float geometry_offset = NOISE3RD_OFFSET_CONTROL_MESH_MACRO;
        CONTROL_MESH_MACRO(_Noise3rdALMaskControlTex);
        float geometry_al_mask = NOISE3RD_AL_MASK_CONTROL_MESH_MACRO;
        geometry_uv[0] = VertexCenterBias(transform_uv[1],transform_uv[2],transform_uv[0],uv_mesh,_GeometryPartitionBias);
        geometry_uv[1] = VertexCenterBias(transform_uv[2],transform_uv[0],transform_uv[1],uv_mesh,_GeometryPartitionBias);
        geometry_uv[2] = VertexCenterBias(transform_uv[0],transform_uv[1],transform_uv[2],uv_mesh,_GeometryPartitionBias);
        float geometry_pushpull_offset[3] = CONTROL_MACRO3(
            _Noise3rdOffsetControlTex,_point_repeat,_Noise3rdOffsetControl,geometry_uv[0],geometry_uv[1],geometry_uv[2]);
        float geometry_pushpull_al_mask[3] = CONTROL_MACRO3(
            _Noise3rdALMaskControlTex,_point_repeat,_Noise3rdALMaskControl,geometry_uv[0],geometry_uv[1],geometry_uv[2]);
        #define GEOMETRY_PUSHPULL_AL_MASK_MACRO(n) geometry_pushpull_al_mask[n]
    #else
        float geometry_al_mask = 1.0;
        float geometry_pushpull_al_mask = 1.0;
        #define GEOMETRY_PUSHPULL_AL_MASK_MACRO(n) geometry_pushpull_al_mask
    #endif

    CONTROL_MESH_MACRO(_OrbitMaskControlTex);
    float orbit_mask = CONTROL_MACRO(_OrbitMaskControlTex,_point_repeat,_OrbitMaskControl,uv_mesh);
    #ifdef _ORBITSOURCE_NOISE1ST
        CONTROL_MESH_MACRO(_Noise1stOffsetControlTex);
        float orbit_offset = NOISE1ST_OFFSET_CONTROL_MESH_MACRO;
    #elif _ORBITSOURCE_NOISE2ND
        CONTROL_MESH_MACRO(_Noise2ndOffsetControlTex);
        float orbit_offset = NOISE2ND_OFFSET_CONTROL_MESH_MACRO;
    #elif _ORBITSOURCE_NOISE3RD
        CONTROL_MESH_MACRO(_Noise3rdOffsetControlTex);
        float orbit_offset = NOISE3RD_OFFSET_CONTROL_MESH_MACRO;
    #endif

    float orbit_rotation_al_mesh = 1.0;
    #ifdef _ORBITROTATIONSOURCE_NOISE1ST
        CONTROL_MESH_MACRO(_Noise1stOffsetControlTex);
        float orbit_rotation_offset = NOISE1ST_OFFSET_CONTROL_MESH_MACRO;
        #ifdef _USE_AUDIOLINK
            orbit_rotation_al_mesh = NOISE1ST_AL_MASK_CONTROL_MESH_MACRO;
        #endif
    #elif _ORBITROTATIONSOURCE_NOISE2ND
        CONTROL_MESH_MACRO(_Noise2ndOffsetControlTex);
        float orbit_rotation_offset = NOISE2ND_OFFSET_CONTROL_MESH_MACRO;
        #ifdef _USE_AUDIOLINK
            orbit_rotation_al_mesh = NOISE2ND_AL_MASK_CONTROL_MESH_MACRO;
        #endif
    #elif _ORBITROTATIONSOURCE_NOISE3RD
        CONTROL_MESH_MACRO(_Noise3rdOffsetControlTex);
        float orbit_rotation_offset = NOISE3RD_OFFSET_CONTROL_MESH_MACRO;
        #ifdef _USE_AUDIOLINK
            orbit_rotation_al_mesh = NOISE3RD_AL_MASK_CONTROL_MESH_MACRO;
        #endif
    #endif

    #ifdef _USE_AUDIOLINK
        float4 audiolink_vu_band = lerp(AudioLinkData(ALPASS_FILTEREDAUDIOLINK+uint2(_AudioLinkVUSmooth,_AudioLinkVUBand)),AudioLinkData(ALPASS_FILTEREDVU_INTENSITY),max(0.0,_AudioLinkVUBand-3.0));
        float audiolink_vu = saturate(lerp(audiolink_vu_band.r,audiolink_vu_band.b,_AudioLinkVUPanning)*_AudioLinkVUGainMul+_AudioLinkVUGainAdd);
        float audiolink_chronotensity = (AudioLinkDecodeDataAsUInt(ALPASS_CHRONOTENSITY+uint2(_AudioLinkChronoTensityType,_AudioLinkChronoTensityBand)).r/_AudioLinkChronoTensityScale);
    #endif

    float3 fragment_stream[3];
    float3 fragment_value;
    #ifdef _DEFINED_FRAGMENT_NOISE
        float fragment_center = (inp[0].FRAGMENT_NOISE_MACRO+inp[1].FRAGMENT_NOISE_MACRO+inp[2].FRAGMENT_NOISE_MACRO)/3.0;
        float3 fragment_time = FRAGMENT_TIME_MACRO;
        #ifdef _PARTITIONTYPE_VERTEX
            fragment_value = float3(
                FragmentNoisePingPong(inp[0].FRAGMENT_NOISE_MACRO,fragment_offset[0],fragment_time.x)LINEFADEMODE_INSTANT_MACRO,
                FragmentNoisePingPong(inp[1].FRAGMENT_NOISE_MACRO,fragment_offset[1],fragment_time.y)LINEFADEMODE_INSTANT_MACRO,
                FragmentNoisePingPong(inp[2].FRAGMENT_NOISE_MACRO,fragment_offset[2],fragment_time.z)LINEFADEMODE_INSTANT_MACRO);
        #elif _PARTITIONTYPE_SIDE
            fragment_value = float3(
            FragmentSidePosNoisePingPong(inp[1].FRAGMENT_NOISE_MACRO,inp[2].FRAGMENT_NOISE_MACRO,inp[0].FRAGMENT_NOISE_MACRO,fragment_center,fragment_offset[0],fragment_time.x)LINEFADEMODE_INSTANT_MACRO,
            FragmentSidePosNoisePingPong(inp[2].FRAGMENT_NOISE_MACRO,inp[0].FRAGMENT_NOISE_MACRO,inp[1].FRAGMENT_NOISE_MACRO,fragment_center,fragment_offset[1],fragment_time.y)LINEFADEMODE_INSTANT_MACRO,
            FragmentSidePosNoisePingPong(inp[0].FRAGMENT_NOISE_MACRO,inp[1].FRAGMENT_NOISE_MACRO,inp[2].FRAGMENT_NOISE_MACRO,fragment_center,fragment_offset[2],fragment_time.z)LINEFADEMODE_INSTANT_MACRO
            );
        #elif _PARTITIONTYPE_MESH
            fragment_value = float3(
                FragmentNoisePingPong(FRAGMENT_CENTER_MACRO,fragment_offset,fragment_time.x)LINEFADEMODE_INSTANT_MACRO,
                FragmentNoisePingPong(FRAGMENT_CENTER_MACRO,fragment_offset,fragment_time.y)LINEFADEMODE_INSTANT_MACRO,
                FragmentNoisePingPong(FRAGMENT_CENTER_MACRO,fragment_offset,fragment_time.z)LINEFADEMODE_INSTANT_MACRO
            );
        #endif
    #else
        fragment_value = _FragmentValue;
    #endif

    #if defined(_USE_AUDIOLINK) && defined(_FRAGMENTSOURCE_AUDIOLINK_VU)
        fragment_value *= audiolink_vu;
    #elif defined(_USE_AUDIOLINK) && defined(_FRAGMENTSOURCE_AUDIOLINK_CHRONOTENSITY)
        fragment_value.x *= triloop(audiolink_chronotensity);
        fragment_value.y *= triloop(audiolink_chronotensity);
        fragment_value.z *= triloop(audiolink_chronotensity);
    #endif

    #ifdef _PARTITIONTYPE_VERTEX
        fragment_stream[0] = float3(0.0,fragment_value.x,fragment_value.x);
        fragment_stream[1] = float3(fragment_value.y,0.0,fragment_value.y);
        fragment_stream[2] = float3(fragment_value.z,fragment_value.z,0.0);
    #elif _PARTITIONTYPE_SIDE
        fragment_stream[0] = float3(0.0,fragment_value.y,fragment_value.z);
        fragment_stream[1] = float3(fragment_value.x,0.0,fragment_value.z);
        fragment_stream[2] = float3(fragment_value.x,fragment_value.y,0.0);
    #else
        fragment_stream[0] = fragment_value.x;
        fragment_stream[1] = fragment_value.y;
        fragment_stream[2] = fragment_value.z;
    #endif
    fragment_stream[0] = saturate(lerp(fragment_stream[0],1.0-fragment_stream[0],_FragmentInverse));
    fragment_stream[1] = saturate(lerp(fragment_stream[1],1.0-fragment_stream[1],_FragmentInverse));
    fragment_stream[2] = saturate(lerp(fragment_stream[2],1.0-fragment_stream[2],_FragmentInverse));

    float3 color_stream[3];
    float3 coloring_value;
    #ifdef _DEFINED_COLORING_NOISE
        float3 color_center = (inp[0].COLOR_NOISE_MACRO+inp[1].COLOR_NOISE_MACRO+inp[2].COLOR_NOISE_MACRO)/3.0;
        float3 color_time = COLOR_TIME_MACRO;
        #ifdef _COLORINGPARTITIONTYPE_VERTEX
            coloring_value = float3(
                ColorNoisePingPong(inp[0].COLOR_NOISE_MACRO,coloring_offset[0],color_time.x),
                ColorNoisePingPong(inp[1].COLOR_NOISE_MACRO,coloring_offset[1],color_time.y),
                ColorNoisePingPong(inp[2].COLOR_NOISE_MACRO,coloring_offset[2],color_time.z)
            );
        #elif _COLORINGPARTITIONTYPE_SIDE
            coloring_value = float3(
                ColorSidePosNoisePingPong(inp[1].COLOR_NOISE_MACRO,inp[2].COLOR_NOISE_MACRO,inp[0].COLOR_NOISE_MACRO,color_center,coloring_offset[0],color_time.x),
                ColorSidePosNoisePingPong(inp[2].COLOR_NOISE_MACRO,inp[0].COLOR_NOISE_MACRO,inp[1].COLOR_NOISE_MACRO,color_center,coloring_offset[1],color_time.y),
                ColorSidePosNoisePingPong(inp[0].COLOR_NOISE_MACRO,inp[1].COLOR_NOISE_MACRO,inp[2].COLOR_NOISE_MACRO,color_center,coloring_offset[2],color_time.z)
            );
        #elif _COLORINGPARTITIONTYPE_MESH
            coloring_value = float3(
                ColorNoisePingPong(COLOR_CENTER_MACRO,coloring_offset,color_time.x),
                ColorNoisePingPong(COLOR_CENTER_MACRO,coloring_offset,color_time.y),
                ColorNoisePingPong(COLOR_CENTER_MACRO,coloring_offset,color_time.z)
            );
        #endif
    #else
        coloring_value = _ColoringValue;
    #endif

    #if defined(_USE_AUDIOLINK) && _COLORINGSOURCE_AUDIOLINK_VU
        coloring_value *= audiolink_vu;
    #elif defined(_USE_AUDIOLINK) && _COLORINGSOURCE_AUDIOLINK_CHRONOTENSITY
        coloring_value.x *= triloop(audiolink_chronotensity);
        coloring_value.y *= triloop(audiolink_chronotensity);
        coloring_value.z *= triloop(audiolink_chronotensity);
    #endif

    coloring_value *= COLORING_MASK_MACRO;

    #ifdef _COLORINGPARTITIONTYPE_VERTEX
        color_stream[0] = coloring_value.x;
        color_stream[1] = coloring_value.y;
        color_stream[2] = coloring_value.z;
    #elif _COLORINGPARTITIONTYPE_SIDE
        color_stream[0] = float3(0.0,coloring_value.y,coloring_value.z);
        color_stream[1] = float3(coloring_value.x,0.0,coloring_value.z);
        color_stream[2] = float3(coloring_value.x,coloring_value.y,0.0);
    #else
        color_stream[0] = coloring_value.x;
        color_stream[1] = coloring_value.y;
        color_stream[2] = coloring_value.z;
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
        float geometry_time_raw = GEOMETRY_TIME_MACRO;
        #if defined(_GEOMETRY_SCALE) || defined(_GEOMETRY_ROTATION)
            float geometry_time = geometry_time_raw+GEOMETRY_AUDIOLINK_PHASE_MACRO*geometry_al_mask;
        #endif
        #if defined(_GEOMETRY_EXTRUDE)
            float geometry_pushpull_time[3] = {
                geometry_time_raw+GEOMETRY_AUDIOLINK_PHASE_MACRO*GEOMETRY_PUSHPULL_AL_MASK_MACRO(0),
                geometry_time_raw+GEOMETRY_AUDIOLINK_PHASE_MACRO*GEOMETRY_PUSHPULL_AL_MASK_MACRO(1),
                geometry_time_raw+GEOMETRY_AUDIOLINK_PHASE_MACRO*GEOMETRY_PUSHPULL_AL_MASK_MACRO(2),
            };
        #endif
        float3 geometry_noise[3];
        #ifdef _DEFINED_GEOMETRY_NOISE
            float3 geometry_center_pos = (inp[0].GEOMETRY_NOISE_MACRO+inp[1].GEOMETRY_NOISE_MACRO+inp[2].GEOMETRY_NOISE_MACRO)/3.0;
            geometry_noise[0] = VertexCenterBias(inp[1].GEOMETRY_NOISE_MACRO,inp[2].GEOMETRY_NOISE_MACRO,inp[0].GEOMETRY_NOISE_MACRO,geometry_center_pos,_GeometryPartitionBias);
            geometry_noise[1] = VertexCenterBias(inp[2].GEOMETRY_NOISE_MACRO,inp[0].GEOMETRY_NOISE_MACRO,inp[1].GEOMETRY_NOISE_MACRO,geometry_center_pos,_GeometryPartitionBias);
            geometry_noise[2] = VertexCenterBias(inp[0].GEOMETRY_NOISE_MACRO,inp[1].GEOMETRY_NOISE_MACRO,inp[2].GEOMETRY_NOISE_MACRO,geometry_center_pos,_GeometryPartitionBias);

            float3 geometry_pushpull_noise[3] = {geometry_noise[0],geometry_noise[1],geometry_noise[2]};
            geometry_noise[0] *= geometry_mask;
            geometry_noise[1] *= geometry_mask;
            geometry_noise[2] *= geometry_mask;
            geometry_pushpull_noise[0] *= geometry_pushpull_mask[0];
            geometry_pushpull_noise[1] *= geometry_pushpull_mask[1];
            geometry_pushpull_noise[2] *= geometry_pushpull_mask[2];
        #else
            float3 geometry_pushpull_noise[3] = {geometry_noise[0],geometry_noise[1],geometry_noise[2]};
            geometry_noise[0] = GEOMETRY_NOISE_MACRO*geometry_mask;
            geometry_noise[1] = GEOMETRY_NOISE_MACRO*geometry_mask;
            geometry_noise[2] = GEOMETRY_NOISE_MACRO*geometry_mask;
            geometry_pushpull_noise[0] = GEOMETRY_NOISE_MACRO*geometry_pushpull_mask[0];
            geometry_pushpull_noise[1] = GEOMETRY_NOISE_MACRO*geometry_pushpull_mask[1];
            geometry_pushpull_noise[2] = GEOMETRY_NOISE_MACRO*geometry_pushpull_mask[2];
        #endif

        #ifdef _GEOMETRY_SCALE
            #ifdef _DEFINED_GEOMETRY_NOISE
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,GeometryNoisePingPong(geometry_noise[0],geometry_offset,geometry_time)));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,GeometryNoisePingPong(geometry_noise[1],geometry_offset,geometry_time)));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,GeometryNoisePingPong(geometry_noise[2],geometry_offset,geometry_time)));
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,audiolink_vu*geometry_mask));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,audiolink_vu*geometry_mask));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,audiolink_vu*geometry_mask));
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,triloop(audiolink_chronotensity*geometry_mask)));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,triloop(audiolink_chronotensity*geometry_mask)));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,triloop(audiolink_chronotensity*geometry_mask)));
            #else
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,geometry_noise[0]));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,geometry_noise[1]));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],lerp(_GeometryScaleRange.x,_GeometryScaleRange.y,geometry_noise[2]));
            #endif
        #endif
        #ifdef _GEOMETRY_EXTRUDE
            #ifdef _DEFINED_GEOMETRY_NOISE
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,GeometryNoisePingPong(geometry_pushpull_noise[0],geometry_pushpull_offset[0],geometry_pushpull_time[0]))*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,GeometryNoisePingPong(geometry_pushpull_noise[1],geometry_pushpull_offset[1],geometry_pushpull_time[1]))*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,GeometryNoisePingPong(geometry_pushpull_noise[2],geometry_pushpull_offset[2],geometry_pushpull_time[2]))*inp[2].world_normal;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,audiolink_vu*geometry_pushpull_mask[0])*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,audiolink_vu*geometry_pushpull_mask[1])*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,audiolink_vu*geometry_pushpull_mask[2])*inp[2].world_normal;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,triloop(audiolink_chronotensity*geometry_pushpull_mask[0]))*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,triloop(audiolink_chronotensity*geometry_pushpull_mask[1]))*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,triloop(audiolink_chronotensity*geometry_pushpull_mask[2]))*inp[2].world_normal;
            #else
                geometry_pos[0] = geometry_pos[0]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,geometry_pushpull_noise[0])*inp[0].world_normal;
                geometry_pos[1] = geometry_pos[1]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,geometry_pushpull_noise[1])*inp[1].world_normal;
                geometry_pos[2] = geometry_pos[2]+lerp(_GeometryExtrudeRange.x,_GeometryExtrudeRange.y,geometry_pushpull_noise[2])*inp[2].world_normal;
            #endif
        #endif
        #ifdef _GEOMETRY_ROTATION
            float3 normal_average = (inp[0].world_normal+inp[1].world_normal+inp[2].world_normal)/3.0;
            float rotation_sign = sign(_GeometryRotationReverse*2.0-1.0);
            #ifdef _DEFINED_GEOMETRY_NOISE
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*GEOMETRY_FUNC_NOISE_MACRO(geometry_noise[0],geometry_offset,geometry_time)*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*GEOMETRY_FUNC_NOISE_MACRO(geometry_noise[1],geometry_offset,geometry_time)*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*GEOMETRY_FUNC_NOISE_MACRO(geometry_noise[2],geometry_offset,geometry_time)*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*audiolink_vu*geometry_mask*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*audiolink_vu*geometry_mask*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*audiolink_vu*geometry_mask*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*audiolink_chronotensity*geometry_mask*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*audiolink_chronotensity*geometry_mask*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*audiolink_chronotensity*geometry_mask*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
            #else
                geometry_pos[0] = RodriguesRotation(geometry_pos[0]-geometry_center,rotation_sign*geometry_noise[0]*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[1] = RodriguesRotation(geometry_pos[1]-geometry_center,rotation_sign*geometry_noise[1]*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
                geometry_pos[2] = RodriguesRotation(geometry_pos[2]-geometry_center,rotation_sign*geometry_noise[2]*UNITY_TWO_PI*_GeometryRotationInfluence,normal_average)+geometry_center;
            #endif
        #endif

        #ifdef _ACTIVATE_ORBIT
            float3 orbit[3] = {
                geometry_pos[0]-geometry_center+_OrbitOffset.xyz,
                geometry_pos[1]-geometry_center+_OrbitOffset.xyz,
                geometry_pos[2]-geometry_center+_OrbitOffset.xyz};
            float3 dir_pi2 = float3(_OrbitRotation.x,_OrbitRotation.y,_OrbitRotation.z)*UNITY_TWO_PI;
            float3 orbit_anim = ORBIT_ROTATION_AUDIOLINK_MACRO*orbit_rotation_al_mesh;
            float3 orbit_rotation_time = ORBIT_ROTATION_TIME_MACRO;
            #ifdef _DEFINED_ORBITROTATION_NOISE
                float3 orbit_rotation_center_noise = (inp[0].ORBITROTATION_NOISE_MACRO+inp[1].ORBITROTATION_NOISE_MACRO+inp[2].ORBITROTATION_NOISE_MACRO)/3.0;
                orbit_anim.xyz += OrbitRotationNoisePingPong(orbit_rotation_center_noise,orbit_rotation_offset,orbit_rotation_time)*_OrbitRotationVariance.xyz;
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
                (orbit_anim.x+_OrbitWavePhase.x+ORBIT_WAVE_X_TIME_MACRO)*_OrbitWaveFrequency.x,
                (orbit_anim.x+_OrbitWavePhase.y+ORBIT_WAVE_YZ_TIME_MACRO)*_OrbitWaveFrequency.y,
                (orbit_anim.x+_OrbitWavePhase.y+ORBIT_WAVE_YZ_TIME_MACRO)*_OrbitWaveFrequency.y
            );

            orbit_anim += dir_pi2+orbit_rotation_time;

            float3 orbit_wave_r = float3(
                sin(orbit_wave.x)*_OrbitWaveStrength.x*orbit_rotation_al_mesh,
                cos(orbit_anim.x)*sin(orbit_wave.y)*_OrbitWaveStrength.y*orbit_rotation_al_mesh,
                sin(orbit_anim.x)*sin(orbit_wave.z)*_OrbitWaveStrength.y*orbit_rotation_al_mesh
            );

            #ifdef _ORBITWAVEREFAUDIOLINK_VU
                orbit_wave_r *= audiolink_spectrum;
            #elif _ORBITWAVEREFAUDIOLINK_SPECTRUM
                orbit_wave_r += float3(
                    audiolink_spectrum.x,
                    cos(orbit_anim.x)*audiolink_spectrum.y,
                    sin(orbit_anim.x)*audiolink_spectrum.z
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
                geometry_pos[0] = lerp(geometry_pos[0],orbit[0],OrbitNoisePingPong(orbit_noise,orbit_offset,orbit_time)*orbit_mask);
                geometry_pos[1] = lerp(geometry_pos[1],orbit[1],OrbitNoisePingPong(orbit_noise,orbit_offset,orbit_time)*orbit_mask);
                geometry_pos[2] = lerp(geometry_pos[2],orbit[2],OrbitNoisePingPong(orbit_noise,orbit_offset,orbit_time)*orbit_mask);
            #elif _ORBITSOURCE_PRIMITIVE
                float orbit_random = random(id+_OrbitSeed)>=_OrbitPrimitiveThreshold;
                geometry_pos[0] = lerp(geometry_pos[0],orbit[0],orbit_random*orbit_mask);
                geometry_pos[1] = lerp(geometry_pos[1],orbit[1],orbit_random*orbit_mask);
                geometry_pos[2] = lerp(geometry_pos[2],orbit[2],orbit_random*orbit_mask);
            #else
                geometry_pos[0] = lerp(geometry_pos[0],orbit[0],_OrbitValue*orbit_mask);
                geometry_pos[1] = lerp(geometry_pos[1],orbit[1],_OrbitValue*orbit_mask);
                geometry_pos[2] = lerp(geometry_pos[2],orbit[2],_OrbitValue*orbit_mask);
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
