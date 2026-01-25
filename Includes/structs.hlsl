struct appdata{
    float4 pos : POSITION;
    float4 color : COLOR;
    float3 normal : NORMAL;
    float2 uv : TEXCOORD0;

    UNITY_VERTEX_INPUT_INSTANCE_ID
};
struct v2f{
    float4 pos : SV_POSITION;
    float4 fragment_pos:TEXCOORD0;          // fragment_pos.xyz
    float4 coloring_pos:TEXCOORD1;          // coloring_pos.xyz
    float4 geometry_pos:TEXCOORD2;          // geometry_pos.xyz
    float4 orbit_pos:TEXCOORD3;             // orbit_pos.xyz
    float4 orbit_rotation_pos:TEXCOORD4;    // orbit_rotation_pos.xyz
    float2 uv:TEXCOORD10;                   // uv.xy
    float4 color:TEXCOORD11;                // color.rgba
    float4 scale:TEXCOORD12;                // scale.xyz, scale.w
    float3 normal:TEXCOORD15;               // normal.xyz
    float3 world_normal:TEXCOORD16;         // world_normal.xyz
    float4 matrix_v_0:TEXCOORD20;           // matrix_v_0.xyzw
    float4 matrix_v_1:TEXCOORD21;           // matrix_v_1.xyzw
    float4 matrix_v_2:TEXCOORD22;           // matrix_v_2.xyzw

    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};

struct g2f{
    float4 pos : SV_POSITION;
    float3 fragment_noise : TEXCOORD2;
    float3 color_noise : TEXCOORD3;
    float3 world_pos : TEXCOORD4;

    float3 baryCentricCoords : TEXCOORD5;
    fixed4 color : TEXCOORD6;
    float camera_distance : TEXCOORD8;
    float model_scale : TEXCOORD9;

    float3 normal : TEXCOORD10;
    float3 world_normal : TEXCOORD11;

    UNITY_LIGHTING_COORDS(14,15)

    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};
