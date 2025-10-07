#if defined(_AUDIOLINK_ENABLE)
    #include "Packages/com.llealloo.audiolink/Runtime/Shaders/AudioLink.cginc"
#endif

#if defined(_LIGHTVOLUMES_ENABLE)
    #include "Packages/red.sim.lightvolumes/Shaders/LightVolumes.cginc"
#endif

#if defined(_LIGHTVOLUMES_ENABLE)
    #define SWITCH_SHADE_WORLDPOS_MACRO 
#else
    #define SWITCH_SHADE_WORLDPOS_MACRO //
#endif

#if defined(_LIGHTVOLUMES_ENABLE) || defined(_DIRECTIONALLIGHT_INFLUENCE_ENABLE)
    #define SWITCH_WORLDNORMAL_MACRO 
    #define REPLACE_WORLDNORMAL_MACRO UnityObjectToWorldNormal(v.normal)
#else
    #define SWITCH_WORLDNORMAL_MACRO //
    #define REPLACE_WORLDNORMAL_MACRO o.world_normal
#endif
