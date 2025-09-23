#if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_ORBITSOURCE_NOISE1ST) || defined(_ORBITROTATIONSOURCE_NOISE1ST)
    #define _DEFINED_NOISE1ST
#endif

#if defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_ORBITSOURCE_NOISE2ND) || defined(_ORBITROTATIONSOURCE_NOISE2ND)
    #define _DEFINED_NOISE2ND
#endif

#if defined(_FRAGMENTSOURCE_NOISE3RD) || defined(_COLORINGSOURCE_NOISE3RD) || defined(_GEOMETRYSOURCE_NOISE3RD) || defined(_ORBITSOURCE_NOISE3RD) || defined(_ORBITROTATIONSOURCE_NOISE3RD)
    #define _DEFINED_NOISE3RD
#endif

#if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_FRAGMENTSOURCE_NOISE3RD)
    #define _DEFINED_FRAGMENT_NOISE
#endif
#if defined(_COLORINGSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE3RD)
    #define _DEFINED_COLORING_NOISE
#endif
#if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
    #define _DEFINED_GEOMETRY_NOISE
#endif
#if defined(_ORBITSOURCE_NOISE1ST) || defined(_ORBITSOURCE_NOISE2ND) || defined(_ORBITSOURCE_NOISE3RD)
    #define _DEFINED_ORBIT_NOISE
#endif
#if defined(_ORBITROTATIONSOURCE_NOISE1ST) || defined(_ORBITROTATIONSOURCE_NOISE2ND) || defined(_ORBITROTATIONSOURCE_NOISE3RD)
    #define _DEFINED_ORBITROTATION_NOISE
#endif

#if defined(_PARTITIONTYPE_VERTEX) || defined(_COLORINGPARTITIONTYPE_VERTEX)
    #define _DEFINED_REF_UV_VERTEX
#endif
#if defined(_PARTITIONTYPE_SIDE) || defined(_COLORINGPARTITIONTYPE_SIDE)
    #define _DEFINED_REF_UV_SIDE
#endif



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

#define ORBIT_ROTATION_TIME_MACRO (_Time.x*_OrbitRotationTimeMultiplier.xyz*_OrbitRotationTimeMultiplier.w)
#define ORBIT_WAVE_X_TIME_MACRO (_Time.x*_OrbitWaveTimeMultiplier.x)
#define ORBIT_WAVE_YZ_TIME_MACRO (_Time.x*_OrbitWaveTimeMultiplier.y)

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
