v2f vert (appdata v){
    v2f o;
    UNITY_SETUP_INSTANCE_ID(v);
    UNITY_INITIALIZE_OUTPUT(v2f,o);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

    o.uv = v.uv;
    o.normal = v.normal;
    float4x4 Stereo_Merge_Matrix_V = DEFINE_STEREO_MERGE_MATRIX_V;
    float3 scale = float3(
        length(UNITY_MATRIX_M._m00_m01_m02),
        length(UNITY_MATRIX_M._m10_m11_m12),
        length(UNITY_MATRIX_M._m20_m21_m22)
    );
    [branch]if(_BillboardEnable==0){
        o.alpha = v.color.a;
        [branch]if(_GeometryPixelizationSpace==1) v.pos.xyz = Pixelization(v.pos.xyz, float3(1.0,1.0,1.0));
        o.pos = mul(UNITY_MATRIX_M,v.pos);
        [branch]if(_GeometryPixelizationSpace==2) o.pos.xyz = Pixelization(o.pos.xyz, scale);
    }else{
        o.alpha = 1.0;
        float4x4 Billboard_Matrix_M = {
            1.0,0.0,0.0,0.0,
            0.0,1.0,0.0,0.0,
            0.0,0.0,1.0,0.0,
            0.0,0.0,0.0,1.0
        };

        Billboard_Matrix_M._m00_m10_m20 = Stereo_Merge_Matrix_V[0].xyz*scale.x;
        Billboard_Matrix_M._m01_m11_m21 = Stereo_Merge_Matrix_V[1].xyz*scale.y;
        Billboard_Matrix_M._m02_m12_m22 = -Stereo_Merge_Matrix_V[2].xyz*scale.z*(1.0-_Forced_Z_Scale_Zero);
        Billboard_Matrix_M._m03_m13_m23 = UNITY_MATRIX_M._m03_m13_m23;

        [branch]if(_GeometryPixelizationSpace==1) v.pos.xyz = Pixelization(v.pos.xyz, float3(1.0,1.0,1.0));
        o.pos = mul(Billboard_Matrix_M,v.pos);
        [branch]if(_GeometryPixelizationSpace==2) o.pos.xyz = Pixelization(o.pos.xyz, scale);
    }

    NOISE_SPACE_POS_MACRO(o.fragment_pos,_FragmentNoiseSpace,_FragmentNoiseOffsetBeforeScale,_FragmentNoiseOffset0,_FragmentNoiseOffset1,_FragmentNoiseScale0,_FragmentNoiseScale1);
    NOISE_SPACE_POS_MACRO(o.coloring_pos,_ColoringNoiseSpace,_ColoringNoiseOffsetBeforeScale,_ColoringNoiseOffset0,_ColoringNoiseOffset1,_ColoringNoiseScale0,_ColoringNoiseScale1);
    NOISE_SPACE_POS_MACRO(o.geometry_pos,_GeometryNoiseSpace,_GeometryNoiseOffsetBeforeScale,_GeometryNoiseOffset0,_GeometryNoiseOffset1,_GeometryNoiseScale0,_GeometryNoiseScale1);
    NOISE_SPACE_POS_MACRO(o.orbit_pos,_OrbitNoiseSpace,_OrbitNoiseOffsetBeforeScale,_OrbitNoiseOffset0,_OrbitNoiseOffset1,_OrbitNoiseScale0,_OrbitNoiseScale1);
    NOISE_SPACE_POS_MACRO(o.orbit_rotation_pos,_OrbitRotationNoiseSpace,_OrbitRotationNoiseOffsetBeforeScale,_OrbitRotationNoiseOffset0,_OrbitRotationNoiseOffset1,_OrbitRotationNoiseScale0,_OrbitRotationNoiseScale1);
    SWITCH_SHADE_WORLDPOS_MACRO o.world_pos = o.pos;
    o.origin_pos = unity_ObjectToWorld._m03_m13_m23;
    SWITCH_WORLDNORMAL_MACRO o.world_normal = UnityObjectToWorldNormal(v.normal);

    o.matrix_v_0 = Stereo_Merge_Matrix_V._m00_m01_m02_m03;
    o.matrix_v_1 = Stereo_Merge_Matrix_V._m10_m11_m12_m13;
    o.matrix_v_2 = Stereo_Merge_Matrix_V._m20_m21_m22_m23;

    o.vertex_color = v.color;

    return o;
}
