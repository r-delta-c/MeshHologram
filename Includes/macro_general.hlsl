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

#ifdef _PIXELIZATIONSPACE_MODEL
    #define VERTEX_PIXELIZATION_MODEL_MACRO v.pos.xyz = Pixelization(v.pos.xyz)
    #define VERTEX_PIXELIZATION_WORLD_MACRO //
#elif defined(_PIXELIZATIONSPACE_WORLD) || defined(_PIXELIZATIONSPACE_POSTGEOMETRY)
    #define VERTEX_PIXELIZATION_MODEL_MACRO //
    #define VERTEX_PIXELIZATION_WORLD_MACRO o.pos.xyz = Pixelization(o.pos.xyz)
#else
    #define VERTEX_PIXELIZATION_MODEL_MACRO
    #define VERTEX_PIXELIZATION_WORLD_MACRO
#endif

#if defined(USING_STEREO_MATRICES)
    #define HOLOGRAM_CAMERA_DISTANCE_MACRO(i) length((unity_StereoWorldSpaceCameraPos[0]+unity_StereoWorldSpaceCameraPos[1])*0.5-geometry_pos[i])
#else
    #define HOLOGRAM_CAMERA_DISTANCE_MACRO(i) length(_WorldSpaceCameraPos-geometry_pos[i])
#endif