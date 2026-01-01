#if defined(USING_STEREO_MATRICES)
    #define HOLOGRAM_CAMERA_DISTANCE_MACRO(i) length((unity_StereoWorldSpaceCameraPos[0]+unity_StereoWorldSpaceCameraPos[1])*0.5-vertex_pos[i])
#else
    #define HOLOGRAM_CAMERA_DISTANCE_MACRO(i) length(_WorldSpaceCameraPos-vertex_pos[i])
#endif

#define SELECTOR_MACRO(n,cond) max(0,1-abs(n-cond))