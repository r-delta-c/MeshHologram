#ifdef _USE_AUDIOLINK
    #include "Packages/com.llealloo.audiolink/Runtime/Shaders/AudioLink.cginc"
#endif

#ifdef _ACTIVATE_LIGHTVOLUMES
    #include "Packages/red.sim.lightvolumes/Shaders/LightVolumes.cginc"
#endif

#ifdef _ACTIVATE_LIGHTVOLUMES
    #define SWITCH_SHADE_WORLDPOS_MACRO 
#else
    #define SWITCH_SHADE_WORLDPOS_MACRO //
#endif

#if defined(_ACTIVATE_LIGHTVOLUMES_) || defined(_ACTIVATE_DIRECTIONALLIGHT_INFLUENCE)
    #define SWITCH_WORLDNORMAL_MACRO 
    #define DEFINE_WORLDNORMAL_MACRO UnityObjectToWorldNormal(v.normal)
#else
    #define SWITCH_WORLDNORMAL_MACRO //
    #define DEFINE_WORLDNORMAL_MACRO o.world_normal
#endif



#ifdef _USE_AUDIOLINK
    #ifdef _NOISE1STPHASEREFAUDIOLINK_VU
        #define NOISE1ST_AUDIOLINK_PHASE_MACRO AUDIOLINK_FILTERED
    #elif _NOISE1STPHASEREFAUDIOLINK_CHRONOTENSITY
        #define NOISE1ST_AUDIOLINK_PHASE_MACRO AUDIOLINK_CHRONOTENSITY
    #else
        #define NOISE1ST_AUDIOLINK_PHASE_MACRO 0.0
    #endif

    #ifdef _NOISE2NDPHASEREFAUDIOLINK_VU
        #define NOISE2ND_AUDIOLINK_PHASE_MACRO AUDIOLINK_FILTERED
    #elif _NOISE2NDPHASEREFAUDIOLINK_CHRONOTENSITY
        #define NOISE2ND_AUDIOLINK_PHASE_MACRO AUDIOLINK_CHRONOTENSITY
    #else
        #define NOISE2ND_AUDIOLINK_PHASE_MACRO 0.0
    #endif

    #ifdef _NOISE3RDPHASEREFAUDIOLINK_VU
        #define NOISE3RD_AUDIOLINK_PHASE_MACRO AUDIOLINK_FILTERED
    #elif _NOISE3RDPHASEREFAUDIOLINK_CHRONOTENSITY
        #define NOISE3RD_AUDIOLINK_PHASE_MACRO AUDIOLINK_CHRONOTENSITY
    #else
        #define NOISE3RD_AUDIOLINK_PHASE_MACRO 0.0
    #endif

    #ifdef _AUDIOLINKVUBAND_BASS
        #define AUDIOLINK_VUBAND_MACRO AudioLinkData(ALPASS_FILTEREDAUDIOLINK+uint2(_AudioLinkVUSmooth,0))
    #elif _AUDIOLINKVUBAND_LOW_MID
        #define AUDIOLINK_VUBAND_MACRO AudioLinkData(ALPASS_FILTEREDAUDIOLINK+uint2(_AudioLinkVUSmooth,1))
    #elif _AUDIOLINKVUBAND_HIGH_MID
        #define AUDIOLINK_VUBAND_MACRO AudioLinkData(ALPASS_FILTEREDAUDIOLINK+uint2(_AudioLinkVUSmooth,2))
    #elif _AUDIOLINKVUBAND_TREBLE
        #define AUDIOLINK_VUBAND_MACRO AudioLinkData(ALPASS_FILTEREDAUDIOLINK+uint2(_AudioLinkVUSmooth,3))
    #elif _AUDIOLINKVUBAND_AVERAGE
        #define AUDIOLINK_VUBAND_MACRO AudioLinkData(ALPASS_FILTEREDVU_INTENSITY)
    #endif

    #ifdef _ORBITROTATIONREFAUDIOLINK_VU
        #define ORBIT_ROTATION_MACRO (float3(AUDIOLINK_FILTERED*_GeometryMessyOrbitAudioLinkStrength.x,AUDIOLINK_FILTERED*_GeometryMessyOrbitAudioLinkStrength.y,AUDIOLINK_FILTERED*_GeometryMessyOrbitAudioLinkStrength.z)*_GeometryMessyOrbitAudioLinkStrength.w)
    #elif _ORBITROTATIONREFAUDIOLINK_CHRONOTENSITY
        #define ORBIT_ROTATION_MACRO (float3(AUDIOLINK_CHRONOTENSITY*_GeometryMessyOrbitAudioLinkStrength.x,AUDIOLINK_CHRONOTENSITY*_GeometryMessyOrbitAudioLinkStrength.y,AUDIOLINK_CHRONOTENSITY*_GeometryMessyOrbitAudioLinkStrength.z)*_GeometryMessyOrbitAudioLinkStrength.w)
    #else
        #define ORBIT_ROTATION_MACRO 0.0
    #endif
#else
    #define AUDIOLINK_VUBAND_MACRO 0.0
    #define ORBIT_ROTATION_MACRO 0.0
    #define NOISE1ST_AUDIOLINK_PHASE_MACRO 0.0
    #define NOISE2ND_AUDIOLINK_PHASE_MACRO 0.0
    #define NOISE3RD_AUDIOLINK_PHASE_MACRO 0.0
#endif



#define AUDIOLINK_FILTERED saturate(lerp(AUDIOLINK_VUBAND_MACRO.r,AUDIOLINK_VUBAND_MACRO.b,_AudioLinkVUPanning)*_AudioLinkVUGainMul+_AudioLinkVUGainAdd)
#define AUDIOLINK_CHRONOTENSITY (AudioLinkDecodeDataAsUInt(ALPASS_CHRONOTENSITY+uint2(_AudioLinkChronoTensityType,_AudioLinkChronoTensityBand)).r/_AudioLinkChronoTensityScale)
