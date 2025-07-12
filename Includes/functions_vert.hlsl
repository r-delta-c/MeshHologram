v2f vert (appdata v){
    v2f o;
    UNITY_SETUP_INSTANCE_ID(v);
    UNITY_INITIALIZE_OUTPUT(v2f,o);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

    o.uv = v.uv;
    o.normal = v.normal;
    float4x4 Stereo_Merge_Matrix_V = DEFINE_STEREO_MERGE_MATRIX_V;
    #ifdef _BILLBOARD_MODE
        o.alpha = 1.0;
        float4x4 Billboard_Matrix_M = {
            1.0,0.0,0.0,0.0,
            0.0,1.0,0.0,0.0,
            0.0,0.0,1.0,0.0,
            0.0,0.0,0.0,1.0
        };

        Billboard_Matrix_M._m00_m10_m20 = Stereo_Merge_Matrix_V[0].xyz*length(unity_ObjectToWorld._m00_m10_m20);
        Billboard_Matrix_M._m01_m11_m21 = Stereo_Merge_Matrix_V[1].xyz*length(unity_ObjectToWorld._m01_m11_m21);
        Billboard_Matrix_M._m02_m12_m22 = -Stereo_Merge_Matrix_V[2].xyz*length(unity_ObjectToWorld._m02_m12_m22)*(1.0-_Forced_Z_Scale_Zero);
        Billboard_Matrix_M._m03_m13_m23 = unity_ObjectToWorld._m03_m13_m23;

        VERTEX_PIXELIZATION_MODEL_MACRO;
        o.pos = mul(Billboard_Matrix_M,v.pos);
        VERTEX_PIXELIZATION_WORLD_MACRO;
    #else
        o.alpha = v.color.a;
        VERTEX_PIXELIZATION_MODEL_MACRO;
        o.pos = mul(UNITY_MATRIX_M,v.pos);
        VERTEX_PIXELIZATION_WORLD_MACRO;
    #endif

    NOISE1ST_MACRO;
    NOISE2ND_MACRO;
    NOISE3RD_MACRO;
    o.forward_dir = normalize(unity_WorldToObject._m20_m21_m22);
    o.up_dir = normalize(unity_WorldToObject._m10_m11_m12);
    SWITCH_SHADE_WORLDPOS_MACRO o.world_pos = o.pos;
    o.origin_pos = unity_ObjectToWorld._m03_m13_m23;
    SWITCH_WORLDNORMAL_MACRO o.world_normal = UnityObjectToWorldNormal(v.normal);

    o.matrix_v_0 = Stereo_Merge_Matrix_V._m00_m01_m02_m03;
    o.matrix_v_1 = Stereo_Merge_Matrix_V._m10_m11_m12_m13;
    o.matrix_v_2 = Stereo_Merge_Matrix_V._m20_m21_m22_m23;

    o.vertex_color = v.color;

    return o;
}
