struct appdata{
    float4 pos : POSITION;
    float4 color : COLOR;
    float3 normal : NORMAL;
    float2 uv : TEXCOORD0;

    UNITY_VERTEX_INPUT_INSTANCE_ID
};
struct v2f{
    float4 pos : SV_POSITION;
    float2 uv : TEXCOORD0;
    STRUCT_NOISE1ST_MACRO float3 noise1st_pos:TEXCOORD1;
    STRUCT_NOISE2ND_MACRO float3 noise2nd_pos:TEXCOORD2;
    STRUCT_NOISE3RD_MACRO float3 noise3rd_pos:TEXCOORD3;

    SWITCH_SHADE_WORLDPOS_MACRO float3 world_pos : TEXCOORD4;
    float3 origin_pos : TEXCOORD5;

    float4 vertex_color : TEXCOORD6;
    float alpha : TEXCOORD7;
    float3 forward_dir : TEXCOORD8;
    float3 up_dir : TEXCOORD9;

    float4 matrix_v_0:TEXCOORD11;
    float4 matrix_v_1:TEXCOORD12;
    float4 matrix_v_2:TEXCOORD13;

    float3 normal : NORMAL0;
    SWITCH_WORLDNORMAL_MACRO float3 world_normal : NORMAL1;

    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};

struct g2f{
    float4 pos : SV_POSITION;
    float3 fragment_noise : TEXCOORD2;
    STRUCT_COLOR_NOISE_MACRO(3);
    SWITCH_SHADE_WORLDPOS_MACRO float3 world_pos : TEXCOORD4;

    float3 baryCentricCoords : TEXCOORD5;
    STRUCT_VERTEXCOLOR_MACRO fixed4 vertex_color : TEXCOORD6;
    fixed alpha :TEXCOORD7;
    float camera_distance : TEXCOORD8;

    float3 normal : TEXCOORD9;
    SWITCH_WORLDNORMAL_MACRO float3 world_normal : TEXCOORD10;

    UNITY_LIGHTING_COORDS(14,15)

    UNITY_VERTEX_INPUT_INSTANCE_ID
    UNITY_VERTEX_OUTPUT_STEREO
};
