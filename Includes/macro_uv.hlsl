#define CONTROL_VERTEX_MACRO(tex) \
    TRANSFORM_TEX_MACRO(tex)

#define CONTROL_EDGE_MACRO(tex) \
    TRANSFORM_TEX_MACRO(tex) \
    UV_MESH_MACRO; \
    UV_EDGE_MACRO(tex)

#define CONTROL_MESH_MACRO(tex) \
    TRANSFORM_TEX_MACRO(tex) \
    UV_MESH_MACRO;

#define TRANSFORM_TEX_MACRO(tex) \
    transform_uv[0] = TRANSFORM_TEX(inp[0].uv,tex);\
    transform_uv[1] = TRANSFORM_TEX(inp[1].uv,tex);\
    transform_uv[2] = TRANSFORM_TEX(inp[2].uv,tex);

#define UV_MESH_MACRO uv_mesh = (transform_uv[0]+transform_uv[1]+transform_uv[2])/3.0

#define UV_EDGE_MACRO(tex) \
    uv_edge[0] = EdgeCenterPos(transform_uv[1],transform_uv[2],transform_uv[0],uv_mesh); \
    uv_edge[1] = EdgeCenterPos(transform_uv[2],transform_uv[0],transform_uv[1],uv_mesh); \
    uv_edge[2] = EdgeCenterPos(transform_uv[0],transform_uv[1],transform_uv[2],uv_mesh);

#define MASK_CONTROL_MACRO3(tex,state,control) float3( \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,transform_uv[0],0.0).x,control), \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,transform_uv[1],0.0).x,control), \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,transform_uv[2],0.0).x,control) \
)
#define MASK_CONTROL_MACRO3_MESH(tex,state,control) float3( \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv_mesh,0.0).x,control), \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv_mesh,0.0).x,control), \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv_mesh,0.0).x,control) \
)
#define OFFSET_CONTROL_MACRO3(tex,state,control) float3( \
    UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,transform_uv[0],0.0).x, \
    UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,transform_uv[1],0.0).x, \
    UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,transform_uv[2],0.0).x \
)*control
#define OFFSET_CONTROL_MACRO3_MESH(tex,state,control) float3( \
    UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv_mesh,0.0).x, \
    UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv_mesh,0.0).x, \
    UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv_mesh,0.0).x \
)*control

#define MASK_CONTROL_MACRO3_UV(tex,state,control,uv) float3( \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv[0],0.0).x,control), \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv[1],0.0).x,control), \
    lerp(1.0,UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv[2],0.0).x,control) \
)
#define OFFSET_CONTROL_MACRO3_UV(tex,state,control,uv) float3( \
    UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv[0],0.0).x, \
    UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv[1],0.0).x, \
    UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex,state,uv[2],0.0).x \
)*control