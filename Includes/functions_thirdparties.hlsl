#ifdef _USE_AUDIOLINK

float MeshHAudioLinkWave(float n, float type, float mirror){
    n = lerp(n,abs(n*2.0-1.0),mirror);
    return lerp(
        AudioLinkLerpMultiline(ALPASS_DFT+float2(n*AUDIOLINK_ETOTALBINS,0.0)).b,
        AudioLinkLerp(ALPASS_AUTOCORRELATOR+float2(n*AUDIOLINK_WIDTH,0.0)).r,
        type);
}

#endif