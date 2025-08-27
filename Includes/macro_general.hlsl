#ifdef _MANUAL_LINE_SCALING
    #define LINE_SCALE_MACRO max(_LineScale,1e-4)
#else
    #define LINE_SCALE_MACRO i.model_scale
#endif

#ifdef _LINEFADEMODE_INSTANT
    #define LINEFADEMODE_INSTANT_MACRO >0.5
#else
    #define LINEFADEMODE_INSTANT_MACRO
#endif

#ifdef _COLORINGPARTITIONTYPE_SIDE
    #define STRUCT_COLOR_NOISE_MACRO(i) float3 color_noise : TEXCOORDi
#else
    #define STRUCT_COLOR_NOISE_MACRO(i) float color_noise : TEXCOORDi
#endif

#ifdef _COLORSOURCE_VERTEXCOLOR
    #define STRUCT_VERTEXCOLOR_MACRO
#else
    #define STRUCT_VERTEXCOLOR_MACRO //
#endif

#define GEOMETRYMESSY_TIME_MACRO (_Time.x*_GeometryMessyOrbitRotationTimeMultiplier.xyz*_GeometryMessyOrbitRotationTimeMultiplier.w)
#define GEOMETRY_ORBIT_Z_TIME_MACRO (_Time.x*_GeometryMessyOrbitWaveZTimeMultiplier)
#define GEOMETRY_ORBIT_XY_TIME_MACRO (_Time.x*_GeometryMessyOrbitWaveXYTimeMultiplier)

#ifdef _PIXELIZATIONSPACE_MODEL
    #define VERTEX_PIXELIZATION_MODEL_MACRO v.pos.xyz = Pixelization(v.pos.xyz, float3(1.0,1.0,1.0))
    #define VERTEX_PIXELIZATION_WORLD_MACRO //
#elif defined(_PIXELIZATIONSPACE_WORLD)
    #define VERTEX_PIXELIZATION_MODEL_MACRO //
    #define VERTEX_PIXELIZATION_WORLD_MACRO o.pos.xyz = Pixelization(o.pos.xyz, scale)
#else
    #define VERTEX_PIXELIZATION_MODEL_MACRO
    #define VERTEX_PIXELIZATION_WORLD_MACRO
#endif

#if defined(USING_STEREO_MATRICES)
    #define HOLOGRAM_CAMERA_DISTANCE_MACRO(i) length((unity_StereoWorldSpaceCameraPos[0]+unity_StereoWorldSpaceCameraPos[1])*0.5-geometry_pos[i])
#else
    #define HOLOGRAM_CAMERA_DISTANCE_MACRO(i) length(_WorldSpaceCameraPos-geometry_pos[i])
#endif