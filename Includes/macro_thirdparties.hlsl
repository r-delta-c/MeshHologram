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
        #define NOISE1ST_AUDIOLINK_PHASE_MACRO audiolink_vu
    #elif _NOISE1STPHASEREFAUDIOLINK_CHRONOTENSITY
        #define NOISE1ST_AUDIOLINK_PHASE_MACRO audiolink_chronotensity
    #else
        #define NOISE1ST_AUDIOLINK_PHASE_MACRO 0.0
    #endif

    #ifdef _NOISE2NDPHASEREFAUDIOLINK_VU
        #define NOISE2ND_AUDIOLINK_PHASE_MACRO audiolink_vu
    #elif _NOISE2NDPHASEREFAUDIOLINK_CHRONOTENSITY
        #define NOISE2ND_AUDIOLINK_PHASE_MACRO audiolink_chronotensity
    #else
        #define NOISE2ND_AUDIOLINK_PHASE_MACRO 0.0
    #endif

    #ifdef _NOISE3RDPHASEREFAUDIOLINK_VU
        #define NOISE3RD_AUDIOLINK_PHASE_MACRO audiolink_vu
    #elif _NOISE3RDPHASEREFAUDIOLINK_CHRONOTENSITY
        #define NOISE3RD_AUDIOLINK_PHASE_MACRO audiolink_chronotensity
    #else
        #define NOISE3RD_AUDIOLINK_PHASE_MACRO 0.0
    #endif

    #ifdef _ORBITROTATIONREFAUDIOLINK_VU
        #define ORBIT_ROTATION_AUDIOLINK_MACRO (float3(audiolink_vu*_OrbitRotationAudioLinkStrength.x,audiolink_vu*_OrbitRotationAudioLinkStrength.y,audiolink_vu*_OrbitRotationAudioLinkStrength.z)*_OrbitRotationAudioLinkStrength.w)
    #elif _ORBITROTATIONREFAUDIOLINK_CHRONOTENSITY
        #define ORBIT_ROTATION_AUDIOLINK_MACRO (float3(audiolink_chronotensity*_OrbitRotationAudioLinkStrength.x,audiolink_chronotensity*_OrbitRotationAudioLinkStrength.y,audiolink_chronotensity*_OrbitRotationAudioLinkStrength.z)*_OrbitRotationAudioLinkStrength.w)
    #else
        #define ORBIT_ROTATION_AUDIOLINK_MACRO 0.0
    #endif

    #ifdef _ORBITWAVEREFAUDIOLINK_VU
        #define FUNC_ORBIT_WAVE_AUDIOLINK_SPECTROGRAM_MACRO(n) (audiolink_vu*_OrbitWaveAudioLinkStrength.xyz*_OrbitWaveAudioLinkStrength.w)
    #elif _ORBITWAVEREFAUDIOLINK_SPECTROGRAM
        #define FUNC_ORBIT_WAVE_AUDIOLINK_SPECTROGRAM_MACRO(n) max(_OrbitWaveAudioLinkSpectrogram0,min(_OrbitWaveAudioLinkSpectrogram1,MeshHAudioLinkSpectrogram(n,_OrbitWaveAudioLinkSpectrogramType,_OrbitWaveAudioLinkSpectrogramMirror)*_OrbitWaveAudioLinkStrength.xyz*_OrbitWaveAudioLinkStrength.w))
    #else
        #define FUNC_ORBIT_WAVE_AUDIOLINK_SPECTROGRAM_MACRO(n) 0.0
    #endif
    #ifdef _FRAGMENT_AUDIOLINK_NOISE_SPECTROGRAM
        #define FUNC_FRAGMENT_AUDIOLINK_NOISE_SPECTROGRAM_MACRO(n) max(_FragmentAudioLinkSpectrogram0,min(_FragmentAudioLinkSpectrogram1,MeshHAudioLinkSpectrogram(n,_FragmentAudioLinkSpectrogramType,_FragmentAudioLinkSpectrogramMirror)*_FragmentAudioLinkStrength))
    #else
        #define FUNC_FRAGMENT_AUDIOLINK_NOISE_SPECTROGRAM_MACRO(n) (n)
    #endif
    #ifdef _COLORING_AUDIOLINK_NOISE_SPECTROGRAM
        #define FUNC_COLORING_AUDIOLINK_NOISE_SPECTROGRAM_MACRO(n) max(_ColoringAudioLinkSpectrogram0,min(_ColoringAudioLinkSpectrogram1,MeshHAudioLinkSpectrogram(n,_ColoringAudioLinkSpectrogramType,_ColoringAudioLinkSpectrogramMirror)*_ColoringAudioLinkStrength))
    #else
        #define FUNC_COLORING_AUDIOLINK_NOISE_SPECTROGRAM_MACRO(n) (n)
    #endif
    #ifdef _GEOMETRY_AUDIOLINK_NOISE_SPECTROGRAM
        #define FUNC_GEOMETRY_AUDIOLINK_NOISE_SPECTROGRAM_MACRO(n) max(_GeometryAudioLinkSpectrogram0,min(_GeometryAudioLinkSpectrogram1,MeshHAudioLinkSpectrogram(n,_GeometryAudioLinkSpectrogramType,_GeometryAudioLinkSpectrogramMirror)*_GeometryAudioLinkStrength))
    #else
        #define FUNC_GEOMETRY_AUDIOLINK_NOISE_SPECTROGRAM_MACRO(n) (n)
    #endif
#else
    #define AUDIOLINK_VUBAND_MACRO 0.0
    #define ORBIT_ROTATION_AUDIOLINK_MACRO 0.0
    #define NOISE1ST_AUDIOLINK_PHASE_MACRO 0.0
    #define NOISE2ND_AUDIOLINK_PHASE_MACRO 0.0
    #define NOISE3RD_AUDIOLINK_PHASE_MACRO 0.0
    #define FUNC_ORBIT_WAVE_AUDIOLINK_SPECTROGRAM_MACRO(n) 0.0
    #define FUNC_FRAGMENT_AUDIOLINK_NOISE_SPECTROGRAM_MACRO(n) (n)
    #define FUNC_COLORING_AUDIOLINK_NOISE_SPECTROGRAM_MACRO(n) (n)
    #define FUNC_GEOMETRY_AUDIOLINK_NOISE_SPECTROGRAM_MACRO(n) (n)
#endif
