[maxvertexcount(3)]
void geom(triangle v2f inp[3], uint id:SV_PRIMITIVEID, inout TriangleStream<g2f> stream){
    g2f o;
    UNITY_INITIALIZE_OUTPUT(g2f,o);
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(inp[0])
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(inp[1])
    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(inp[2])

    float fragment_mask[3];
    float coloring_mask[3];
    float geometry_mask[3];
    float geometry_messy_mask[3];
    TEX2D_NOISE1ST_MACRO float noise1st_offset[3];
    TEX2D_NOISE2ND_MACRO float noise2nd_offset[3];
    TEX2D_NOISE3RD_MACRO float noise3rd_offset[3];
    float audiolink_mask[3];
    fragment_mask[0] = lerp(1.0,tex2Dlod(_FragmentMaskControlTex, float4(inp[0].uv,0.0,0.0)),_FragmentMaskControl);
    fragment_mask[1] = lerp(1.0,tex2Dlod(_FragmentMaskControlTex, float4(inp[1].uv,0.0,0.0)),_FragmentMaskControl);
    fragment_mask[2] = lerp(1.0,tex2Dlod(_FragmentMaskControlTex, float4(inp[2].uv,0.0,0.0)),_FragmentMaskControl);
    coloring_mask[0] = lerp(1.0,tex2Dlod(_ColoringMaskControlTex, float4(inp[0].uv,0.0,0.0)),_ColoringMaskControl);
    coloring_mask[1] = lerp(1.0,tex2Dlod(_ColoringMaskControlTex, float4(inp[1].uv,0.0,0.0)),_ColoringMaskControl);
    coloring_mask[2] = lerp(1.0,tex2Dlod(_ColoringMaskControlTex, float4(inp[2].uv,0.0,0.0)),_ColoringMaskControl);
    geometry_mask[0] = lerp(1.0,tex2Dlod(_GeometryMaskControlTex, float4(inp[0].uv,0.0,0.0)),_GeometryMaskControl);
    geometry_mask[1] = lerp(1.0,tex2Dlod(_GeometryMaskControlTex, float4(inp[1].uv,0.0,0.0)),_GeometryMaskControl);
    geometry_mask[2] = lerp(1.0,tex2Dlod(_GeometryMaskControlTex, float4(inp[2].uv,0.0,0.0)),_GeometryMaskControl);
    geometry_messy_mask[0] = lerp(1.0,tex2Dlod(_GeometryMessyMaskControlTex, float4(inp[0].uv,0.0,0.0)),_GeometryMessyMaskControl);
    geometry_messy_mask[1] = lerp(1.0,tex2Dlod(_GeometryMessyMaskControlTex, float4(inp[1].uv,0.0,0.0)),_GeometryMessyMaskControl);
    geometry_messy_mask[2] = lerp(1.0,tex2Dlod(_GeometryMessyMaskControlTex, float4(inp[2].uv,0.0,0.0)),_GeometryMessyMaskControl);

    #if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYMESSYSOURCE_NOISE1ST)
        TEX2D_NOISE1ST_MACRO noise1st_offset[0] = lerp(1.0,tex2Dlod(_Noise1stMaskControlTex, float4(inp[0].uv,0.0,0.0)),_Noise1stMaskControl);
        TEX2D_NOISE1ST_MACRO noise1st_offset[1] = lerp(1.0,tex2Dlod(_Noise1stMaskControlTex, float4(inp[1].uv,0.0,0.0)),_Noise1stMaskControl);
        TEX2D_NOISE1ST_MACRO noise1st_offset[2] = lerp(1.0,tex2Dlod(_Noise1stMaskControlTex, float4(inp[2].uv,0.0,0.0)),_Noise1stMaskControl);
    #else
        noise1st_offset[0] = 1.0;
        noise1st_offset[1] = 1.0;
        noise1st_offset[2] = 1.0;
    #endif

    #if defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYMESSYSOURCE_NOISE2ND)
        TEX2D_NOISE2ND_MACRO noise2nd_offset[0] = lerp(1.0,tex2Dlod(_Noise2ndMaskControlTex, float4(inp[0].uv,0.0,0.0)),_Noise2ndMaskControl);
        TEX2D_NOISE2ND_MACRO noise2nd_offset[1] = lerp(1.0,tex2Dlod(_Noise2ndMaskControlTex, float4(inp[1].uv,0.0,0.0)),_Noise2ndMaskControl);
        TEX2D_NOISE2ND_MACRO noise2nd_offset[2] = lerp(1.0,tex2Dlod(_Noise2ndMaskControlTex, float4(inp[2].uv,0.0,0.0)),_Noise2ndMaskControl);
    #else
        noise2nd_offset[0] = 1.0;
        noise2nd_offset[1] = 1.0;
        noise2nd_offset[2] = 1.0;
    #endif

    #if defined(_FRAGMENTSOURCE_NOISE3RD) || defined(_COLORINGSOURCE_NOISE3RD) || defined(_GEOMETRYSOURCE_NOISE3RD) || defined(_GEOMETRYMESSYSOURCE_NOISE3RD)
        TEX2D_NOISE3RD_MACRO noise3rd_offset[0] = lerp(1.0,tex2Dlod(_Noise3rdMaskControlTex, float4(inp[0].uv,0.0,0.0)),_Noise3rdMaskControl);
        TEX2D_NOISE3RD_MACRO noise3rd_offset[1] = lerp(1.0,tex2Dlod(_Noise3rdMaskControlTex, float4(inp[1].uv,0.0,0.0)),_Noise3rdMaskControl);
        TEX2D_NOISE3RD_MACRO noise3rd_offset[2] = lerp(1.0,tex2Dlod(_Noise3rdMaskControlTex, float4(inp[2].uv,0.0,0.0)),_Noise3rdMaskControl);
    #else
        noise3rd_offset[0] = 1.0;
        noise3rd_offset[1] = 1.0;
        noise3rd_offset[2] = 1.0;
    #endif

    #ifdef _USE_AUDIOLINK
        audiolink_mask[0] = lerp(1.0,tex2Dlod(_AudioLinkMaskControlTex, float4(inp[0].uv,0.0,0.0)),_AudioLinkMaskControl);
        audiolink_mask[1] = lerp(1.0,tex2Dlod(_AudioLinkMaskControlTex, float4(inp[1].uv,0.0,0.0)),_AudioLinkMaskControl);
        audiolink_mask[2] = lerp(1.0,tex2Dlod(_AudioLinkMaskControlTex, float4(inp[2].uv,0.0,0.0)),_AudioLinkMaskControl);
    #endif

    #if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_FRAGMENTSOURCE_NOISE3RD)
        float3 fragment_noise;
        float3 fragment_center = (inp[0].FRAGMENT_NOISE_MACRO+inp[1].FRAGMENT_NOISE_MACRO+inp[2].FRAGMENT_NOISE_MACRO)/3.0;
        #ifdef _PARTITIONTYPE_VERTEX
            fragment_noise = float3(
                FragmentNoiseMap01(inp[0].FRAGMENT_NOISE_MACRO,FRAGMENT_OFFSET_MACRO(0))LINEFADEMODE_INSTANT_MACRO,
                FragmentNoiseMap01(inp[1].FRAGMENT_NOISE_MACRO,FRAGMENT_OFFSET_MACRO(0))LINEFADEMODE_INSTANT_MACRO,
                FragmentNoiseMap01(inp[2].FRAGMENT_NOISE_MACRO,FRAGMENT_OFFSET_MACRO(0))LINEFADEMODE_INSTANT_MACRO);
            fragment_noise.x = 1.0-(fragment_noise.x)*fragment_mask[0];
            fragment_noise.y = 1.0-(fragment_noise.y)*fragment_mask[1];
            fragment_noise.z = 1.0-(fragment_noise.z)*fragment_mask[2];

            #define FRAGMENT_STREAM_0_MACRO float3(0.0,fragment_noise.x,fragment_noise.x)
            #define FRAGMENT_STREAM_1_MACRO float3(fragment_noise.y,0.0,fragment_noise.y)
            #define FRAGMENT_STREAM_2_MACRO float3(fragment_noise.z,fragment_noise.z,0.0)

        #elif _PARTITIONTYPE_SIDE
            fragment_noise.x = FragmentSidePosNoiseMap(inp[1].FRAGMENT_NOISE_MACRO,inp[2].FRAGMENT_NOISE_MACRO,inp[0].FRAGMENT_NOISE_MACRO,fragment_center,FRAGMENT_OFFSET_MACRO(0))LINEFADEMODE_INSTANT_MACRO;
            fragment_noise.y = FragmentSidePosNoiseMap(inp[2].FRAGMENT_NOISE_MACRO,inp[0].FRAGMENT_NOISE_MACRO,inp[1].FRAGMENT_NOISE_MACRO,fragment_center,FRAGMENT_OFFSET_MACRO(0))LINEFADEMODE_INSTANT_MACRO;
            fragment_noise.z = FragmentSidePosNoiseMap(inp[0].FRAGMENT_NOISE_MACRO,inp[1].FRAGMENT_NOISE_MACRO,inp[2].FRAGMENT_NOISE_MACRO,fragment_center,FRAGMENT_OFFSET_MACRO(0))LINEFADEMODE_INSTANT_MACRO;

            #define FRAGMENT_STREAM_0_MACRO float3(0.0,1.0-fragment_noise.y*fragment_mask[0],1.0-fragment_noise.z*fragment_mask[0])
            #define FRAGMENT_STREAM_1_MACRO float3(1.0-fragment_noise.x*fragment_mask[1],0.0,1.0-fragment_noise.z*fragment_mask[1])
            #define FRAGMENT_STREAM_2_MACRO float3(1.0-fragment_noise.x*fragment_mask[2],1.0-fragment_noise.y*fragment_mask[2],0.0)*fragment_mask[2]

        #elif _PARTITIONTYPE_MESH
            #define FRAGMENT_STREAM_0_MACRO FragmentNoiseMap01(FRAGMENT_CENTER_MACRO,FRAGMENT_OFFSET_MACRO(0))LINEFADEMODE_INSTANT_MACRO*fragment_mask[0]
            #define FRAGMENT_STREAM_1_MACRO FragmentNoiseMap01(FRAGMENT_CENTER_MACRO,FRAGMENT_OFFSET_MACRO(1))LINEFADEMODE_INSTANT_MACRO*fragment_mask[1]
            #define FRAGMENT_STREAM_2_MACRO FragmentNoiseMap01(FRAGMENT_CENTER_MACRO,FRAGMENT_OFFSET_MACRO(2))LINEFADEMODE_INSTANT_MACRO*fragment_mask[2]
        #endif
    #elif defined(_USE_AUDIOLINK) && _FRAGMENTSOURCE_AUDIOLINK_VU
        #define FRAGMENT_STREAM_0_MACRO AUDIOLINK_FILTERED*audiolink_mask[0]
        #define FRAGMENT_STREAM_1_MACRO AUDIOLINK_FILTERED*audiolink_mask[1]
        #define FRAGMENT_STREAM_2_MACRO AUDIOLINK_FILTERED*audiolink_mask[2]
    #elif defined(_USE_AUDIOLINK) && _FRAGMENTSOURCE_AUDIOLINK_CHRONOTENSITY
        #define FRAGMENT_STREAM_0_MACRO triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[0])
        #define FRAGMENT_STREAM_1_MACRO triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[1])
        #define FRAGMENT_STREAM_2_MACRO triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[2])
    #else
        #define FRAGMENT_STREAM_0_MACRO _FragmentValue*fragment_mask[0]
        #define FRAGMENT_STREAM_1_MACRO _FragmentValue*fragment_mask[1]
        #define FRAGMENT_STREAM_2_MACRO _FragmentValue*fragment_mask[2]
    #endif

    #if defined(_COLORINGSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE3RD)
        float3 color_center = (inp[0].COLOR_NOISE_MACRO+inp[1].COLOR_NOISE_MACRO+inp[2].COLOR_NOISE_MACRO)/3.0;
        #ifdef _COLORINGPARTITIONTYPE_VERTEX
            #define COLOR_STREAM_0_MACRO ColorNoiseMap01(inp[0].COLOR_NOISE_MACRO,COLOR_OFFSET_MACRO(0))*coloring_mask[0]
            #define COLOR_STREAM_1_MACRO ColorNoiseMap01(inp[1].COLOR_NOISE_MACRO,COLOR_OFFSET_MACRO(1))*coloring_mask[1]
            #define COLOR_STREAM_2_MACRO ColorNoiseMap01(inp[2].COLOR_NOISE_MACRO,COLOR_OFFSET_MACRO(2))*coloring_mask[2]
        #elif _COLORINGPARTITIONTYPE_SIDE
            float3 color_noise;
            color_noise.x = ColorSidePosNoiseMap(inp[1].COLOR_NOISE_MACRO,inp[2].COLOR_NOISE_MACRO,inp[0].COLOR_NOISE_MACRO,color_center,COLOR_OFFSET_MACRO(0));
            color_noise.y = ColorSidePosNoiseMap(inp[2].COLOR_NOISE_MACRO,inp[0].COLOR_NOISE_MACRO,inp[1].COLOR_NOISE_MACRO,color_center,COLOR_OFFSET_MACRO(1));
            color_noise.z = ColorSidePosNoiseMap(inp[0].COLOR_NOISE_MACRO,inp[1].COLOR_NOISE_MACRO,inp[2].COLOR_NOISE_MACRO,color_center,COLOR_OFFSET_MACRO(2));

            #define COLOR_STREAM_0_MACRO float3(0.0,color_noise.y,color_noise.z)*coloring_mask[0]
            #define COLOR_STREAM_1_MACRO float3(color_noise.x,0.0,color_noise.z)*coloring_mask[1]
            #define COLOR_STREAM_2_MACRO float3(color_noise.x,color_noise.y,0.0)*coloring_mask[2]
        #elif _COLORINGPARTITIONTYPE_MESH
            #define COLOR_STREAM_0_MACRO ColorNoiseMap01(COLOR_CENTER_MACRO,COLOR_OFFSET_MACRO(0))*coloring_mask[0]
            #define COLOR_STREAM_1_MACRO ColorNoiseMap01(COLOR_CENTER_MACRO,COLOR_OFFSET_MACRO(1))*coloring_mask[1]
            #define COLOR_STREAM_2_MACRO ColorNoiseMap01(COLOR_CENTER_MACRO,COLOR_OFFSET_MACRO(2))*coloring_mask[2]
        #endif
    #elif defined(_USE_AUDIOLINK) && _COLORINGSOURCE_AUDIOLINK_VU
        #define COLOR_STREAM_0_MACRO AUDIOLINK_FILTERED*audiolink_mask[0]
        #define COLOR_STREAM_1_MACRO AUDIOLINK_FILTERED*audiolink_mask[1]
        #define COLOR_STREAM_2_MACRO AUDIOLINK_FILTERED*audiolink_mask[2]
    #elif defined(_USE_AUDIOLINK) && _COLORINGSOURCE_AUDIOLINK_CHRONOTENSITY
        #define COLOR_STREAM_0_MACRO triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[0])
        #define COLOR_STREAM_1_MACRO triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[1])
        #define COLOR_STREAM_2_MACRO triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[2])
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
    #if !defined(_GEOMETRYPUSHPULLE_DISABLE) || defined(_ACTIVATE_GEOMETRYMESSY) || !defined(_PIXELIZATIONSPACE_DISABLE)
        float3 origin_pos = inp[0].origin_pos;
        float3 geometry_center = (geometry_pos[0]+geometry_pos[1]+geometry_pos[2])/3.0;
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

        #ifdef _GEOMETRYPUSHPULLE_SCALING
            #if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],ChangeValueRange02(GeometryNoiseMap01(geometry_noise[0],GEOMETRY_OFFSET_MACRO(0))*_GeometryPushPull,_GeometryPushPullBias));
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],ChangeValueRange02(GeometryNoiseMap01(geometry_noise[1],GEOMETRY_OFFSET_MACRO(1))*_GeometryPushPull,_GeometryPushPullBias));
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],ChangeValueRange02(GeometryNoiseMap01(geometry_noise[2],GEOMETRY_OFFSET_MACRO(2))*_GeometryPushPull,_GeometryPushPullBias));
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],InverseBias01(AUDIOLINK_FILTERED*audiolink_mask[0],_GeometryPushPullBias)*_GeometryPushPull);
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],InverseBias01(AUDIOLINK_FILTERED*audiolink_mask[1],_GeometryPushPullBias)*_GeometryPushPull);
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],InverseBias01(AUDIOLINK_FILTERED*audiolink_mask[2],_GeometryPushPullBias)*_GeometryPushPull);
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],InverseBias01(triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[0]),_GeometryPushPullBias)*_GeometryPushPull);
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],InverseBias01(triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[1]),_GeometryPushPullBias)*_GeometryPushPull);
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],InverseBias01(triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[2]),_GeometryPushPullBias)*_GeometryPushPull);
            #else
                geometry_pos[0] = lerp(geometry_center,geometry_pos[0],InverseBias01(_GeometryValue,_GeometryPushPullBias)*_GeometryPushPull);
                geometry_pos[1] = lerp(geometry_center,geometry_pos[1],InverseBias01(_GeometryValue,_GeometryPushPullBias)*_GeometryPushPull);
                geometry_pos[2] = lerp(geometry_center,geometry_pos[2],InverseBias01(_GeometryValue,_GeometryPushPullBias)*_GeometryPushPull);
            #endif
        #elif _GEOMETRYPUSHPULLE_NORMAL_EXTRUDE
            #if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
                geometry_pos[0] = geometry_pos[0]+GeometryNoiseMap01(geometry_noise[0],GEOMETRY_OFFSET_MACRO(0))*_GeometryPushPull*_GeometryPushPullBias*inp[0].normal;
                geometry_pos[1] = geometry_pos[1]+GeometryNoiseMap01(geometry_noise[1],GEOMETRY_OFFSET_MACRO(1))*_GeometryPushPull*_GeometryPushPullBias*inp[1].normal;
                geometry_pos[2] = geometry_pos[2]+GeometryNoiseMap01(geometry_noise[2],GEOMETRY_OFFSET_MACRO(2))*_GeometryPushPull*_GeometryPushPullBias*inp[2].normal;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_VU
                geometry_pos[0] = geometry_pos[0]+AUDIOLINK_FILTERED*audiolink_mask[0]*_GeometryPushPull*_GeometryPushPullBias*inp[0].normal;
                geometry_pos[1] = geometry_pos[1]+AUDIOLINK_FILTERED*audiolink_mask[1]*_GeometryPushPull*_GeometryPushPullBias*inp[1].normal;
                geometry_pos[2] = geometry_pos[2]+AUDIOLINK_FILTERED*audiolink_mask[2]*_GeometryPushPull*_GeometryPushPullBias*inp[2].normal;
            #elif defined(_USE_AUDIOLINK) && _GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY
                geometry_pos[0] = geometry_pos[0]+triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[0])*inp[0].normal*_GeometryPushPull*_GeometryPushPullBias;
                geometry_pos[1] = geometry_pos[1]+triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[1])*inp[1].normal*_GeometryPushPull*_GeometryPushPullBias;
                geometry_pos[2] = geometry_pos[2]+triloop(AUDIOLINK_CHRONOTENSITY*audiolink_mask[2])*inp[2].normal*_GeometryPushPull*_GeometryPushPullBias;
            #else
                geometry_pos[0] = geometry_pos[0]+_GeometryValue*inp[0].normal*_GeometryPushPull*_GeometryPushPullBias;
                geometry_pos[1] = geometry_pos[1]+_GeometryValue*inp[1].normal*_GeometryPushPull*_GeometryPushPullBias;
                geometry_pos[2] = geometry_pos[2]+_GeometryValue*inp[2].normal*_GeometryPushPull*_GeometryPushPullBias;
            #endif
        #endif

        #ifdef _ACTIVATE_GEOMETRYMESSY
            float3 orbit[3] = {
                geometry_pos[0]-geometry_center+_GeometryMessyOrbitPosition.xyz,
                geometry_pos[1]-geometry_center+_GeometryMessyOrbitPosition.xyz,
                geometry_pos[2]-geometry_center+_GeometryMessyOrbitPosition.xyz};
            float3 dir_pi2 = float3(_GeometryMessyOrbitRotation,_GeometryMessyOrbitRotationForward,_GeometryMessyOrbitRotationRight)*UNITY_PI*2.0;
            float3 orbit_anim = GEOMETRY_TIME_MACRO+ORBIT_ROTATION_MACRO;

            #if defined(_GEOMETRYMESSYSOURCE_NOISE1ST) || defined(_GEOMETRYMESSYSOURCE_NOISE2ND) || defined(_GEOMETRYMESSYSOURCE_NOISE3RD)
                float3 geometrymessy_center_noise = (inp[0].GEOMETRYMESSY_NOISE_MACRO+inp[1].GEOMETRYMESSY_NOISE_MACRO+inp[2].GEOMETRYMESSY_NOISE_MACRO)/3.0;
                float geometrymessy_mask_offset = (GEOMETRYMESSY_OFFSET_MACRO(0)+GEOMETRYMESSY_OFFSET_MACRO(1)+GEOMETRYMESSY_OFFSET_MACRO(2)/3.0);
                orbit_anim.xy += GeometryMessyNoiseMap01(geometrymessy_center_noise,geometrymessy_mask_offset)*_GeometryMessyOrbitVariance.xy;
                orbit_anim.z = sin(GeometryMessyNoiseMap01(geometrymessy_center_noise,geometrymessy_mask_offset)*_GeometryMessyOrbitVariance.z+orbit_anim.z)*_GeometryMessyOrbitVariance.w;
            #elif defined(_GEOMETRYMESSYSOURCE_PRIMITIVE)
                orbit_anim.xy += random(id+_GeometryMessySeed)*_GeometryMessyOrbitVariance.xy;
                orbit_anim.z = sin(random(id+_GeometryMessySeed)*_GeometryMessyOrbitVariance.z+orbit_anim.z)*_GeometryMessyOrbitVariance.w;
            #else
                orbit_anim.xy += _GeometryMessyOrbitVariance.xy;
                orbit_anim.z = sin(_GeometryMessyOrbitVariance.z+orbit_anim.z)*_GeometryMessyOrbitVariance.w;
            #endif

            float3 orbit_dir = cos(orbit_anim.x+dir_pi2.x)*inp[0].forward_dir*_GeometryMessyOrbitScaleZ + sin(orbit_anim.x+dir_pi2.x)*inp[0].up_dir*_GeometryMessyOrbitScaleY;
            float3 right_dir = normalize(cross(inp[0].forward_dir,inp[0].up_dir));

            float2 s = float2(sin(dir_pi2.y+orbit_anim.y),sin(dir_pi2.z+orbit_anim.z));
            float2 c = float2(cos(dir_pi2.y+orbit_anim.y),cos(dir_pi2.z+orbit_anim.z));

            orbit_dir = orbit_dir*c.x + cross(inp[0].forward_dir,orbit_dir)*s.x + inp[0].forward_dir*dot(inp[0].forward_dir,orbit_dir)*(1.0-c.x);

            orbit_dir = orbit_dir*c.y + cross(right_dir,orbit_dir)*s.y + right_dir*dot(right_dir,orbit_dir)*(1.0-c.y);

            orbit_dir *= _GeometryMessyOrbitPosition.w;

            orbit[0] = orbit[0]+mul(UNITY_MATRIX_M,float4(orbit_dir,1.0));
            orbit[1] = orbit[1]+mul(UNITY_MATRIX_M,float4(orbit_dir,1.0));
            orbit[2] = orbit[2]+mul(UNITY_MATRIX_M,float4(orbit_dir,1.0));

            #if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
                geometry_pos[0] = lerp(geometry_pos[0],orbit[0],GeometryNoiseMap01(geometry_noise[0],GEOMETRY_OFFSET_MACRO(0))*geometry_messy_mask[0]);
                geometry_pos[1] = lerp(geometry_pos[1],orbit[1],GeometryNoiseMap01(geometry_noise[1],GEOMETRY_OFFSET_MACRO(1))*geometry_messy_mask[1]);
                geometry_pos[2] = lerp(geometry_pos[2],orbit[2],GeometryNoiseMap01(geometry_noise[2],GEOMETRY_OFFSET_MACRO(2))*geometry_messy_mask[2]);
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
            geometry_pos[i] = Pixelization(geometry_pos[i]);
        #endif

        SWITCH_SHADE_WORLDPOS_MACRO world_pos[i] = geometry_pos[i];
        camera_distance[i] = HOLOGRAM_CAMERA_DISTANCE_MACRO(i);

        pos[i] = mul(matrix_v[i],float4(geometry_pos[i],1.0));
        pos[i] = mul(UNITY_MATRIX_P,pos[i]);
    }

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
