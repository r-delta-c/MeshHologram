#define CONTROL_VERTEX_MACRO(tex) \
    TRANSFORM_TEX_MACRO(tex)

#define CONTROL_SIDE_MACRO(tex) \
    TRANSFORM_TEX_MACRO(tex) \
    UV_MESH_MACRO; \
    UV_SIDE_MACRO(tex)

#define CONTROL_MESH_MACRO(tex) \
    TRANSFORM_TEX_MACRO(tex) \
    UV_MESH_MACRO;

#define TRANSFORM_TEX_MACRO(tex) \
    transform_uv[0] = TRANSFORM_TEX(inp[0].uv,tex);\
    transform_uv[1] = TRANSFORM_TEX(inp[1].uv,tex);\
    transform_uv[2] = TRANSFORM_TEX(inp[2].uv,tex);

#define UV_MESH_MACRO uv_mesh = (transform_uv[0]+transform_uv[1]+transform_uv[2])/3.0

#define UV_SIDE_MACRO(tex) \
    uv_side[0] = SideCenterPos(transform_uv[1],transform_uv[2],transform_uv[0],uv_mesh); \
    uv_side[1] = SideCenterPos(transform_uv[2],transform_uv[0],transform_uv[1],uv_mesh); \
    uv_side[2] = SideCenterPos(transform_uv[0],transform_uv[1],transform_uv[2],uv_mesh);

#define CONTROL_MACRO(tex,state,control,uv) lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv,0.0).x,control)
#define CONTROL_MACRO3(tex,state,control,uv0,uv1,uv2) { \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv0,0.0).x,control), \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv1,0.0).x,control), \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv2,0.0).x,control) \
}