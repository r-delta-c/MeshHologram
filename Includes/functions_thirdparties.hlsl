#if defined(_AUDIOLINK_ENABLE)

float ToggleSpectrum(float n, bool toggle){
    return lerp(
        AudioLinkLerpMultiline(ALPASS_DFT+float2(n*AUDIOLINK_ETOTALBINS,0.0)).b,
        AudioLinkLerp(ALPASS_AUTOCORRELATOR+float2(n*AUDIOLINK_WIDTH,0.0)).g*0.25,
        toggle);
}

float3 MeshHAudioLinkSpectrum(float3 n, bool mirror, bool toggle){
    n = mod(lerp(n,abs(n*2.0-1.0),mirror),1.0);
    return float3(ToggleSpectrum(n.x,toggle),ToggleSpectrum(n.y,toggle),ToggleSpectrum(n.z,toggle));
}

#endif