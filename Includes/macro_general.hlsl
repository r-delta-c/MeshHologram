#if defined(_MANUAL_LINE_SCALING_ENABLE)
    #define LINE_SCALE_MACRO max(_FragmentLineScale,1e-4)
#else
    #define LINE_SCALE_MACRO i.model_scale
#endif

#if defined(_LINEANIMATIONMODE_INSTANT)
    #define LINEANIMATIONMODE_INSTANT_MACRO >0.5
#else
    #define LINEANIMATIONMODE_INSTANT_MACRO
#endif

#if defined(_COLORINGPARTITIONMODE_SIDE)
    #define STRUCT_COLOR_NOISE_MACRO(i) float3 color_noise : TEXCOORDi
#else
    #define STRUCT_COLOR_NOISE_MACRO(i) float color_noise : TEXCOORDi
#endif

#if defined(_COLORSOURCE_VERTEXCOLOR)
    #define STRUCT_VERTEXCOLOR_MACRO
#else
    #define STRUCT_VERTEXCOLOR_MACRO //
#endif

#define ORBIT_ROTATION_TIME_MACRO (_Time.x*_OrbitRotationSpeed.xyz*_OrbitRotationSpeed.w)
#define ORBIT_WAVE_X_TIME_MACRO (_Time.x*_OrbitWaveSpeed.x)
#define ORBIT_WAVE_YZ_TIME_MACRO (_Time.x*_OrbitWaveSpeed.y)

#if defined(_PIXELIZATIONSPACE_MODEL)
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
