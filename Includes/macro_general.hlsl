#define ORBIT_ROTATION_TIME_MACRO (_Time.x*_OrbitRotationSpeed.xyz*_OrbitRotationSpeed.w)
#define ORBIT_WAVE_X_TIME_MACRO (_Time.x*_OrbitWaveSpeed.x)
#define ORBIT_WAVE_YZ_TIME_MACRO (_Time.x*_OrbitWaveSpeed.y)

#if defined(USING_STEREO_MATRICES)
    #define HOLOGRAM_CAMERA_DISTANCE_MACRO(i) length((unity_StereoWorldSpaceCameraPos[0]+unity_StereoWorldSpaceCameraPos[1])*0.5-geometry_pos[i])
#else
    #define HOLOGRAM_CAMERA_DISTANCE_MACRO(i) length(_WorldSpaceCameraPos-geometry_pos[i])
#endif
