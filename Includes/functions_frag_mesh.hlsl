#if defined(_DIRECTIONALLIGHT_INFLUENCE_ENABLE)
    UNITY_LIGHT_ATTENUATION(attenuation,i,i.world_normal);
    float3 light = max(0.0,dot(i.world_normal,_WorldSpaceLightPos0.xyz))*_LightColor0*attenuation;

    c.rgb += lerp(0.0,light,_DirectionalLightInfluence);
#endif

#if defined(_AMBIENT_INFLUENCE_ENABLE) && !defined(_LIGHTVOLUMES_ENABLE)
    float3 ambient = saturate(ShadeSH9(float4(i.world_normal,1.0)));

    c.rgb += ambient*_AmbientInfluence;
#elif defined(_LIGHTVOLUMES_ENABLE)
    float3 L01 = 0.0;
    float3 L1r = 0.0;
    float3 L1g = 0.0;
    float3 L1b = 0.0;
    LightVolumeSH(i.world_pos,L01,L1r,L1g,L1b);
    float3 volume_light = LightVolumeEvaluate(normalize(i.world_normal),L01,L1r,L1g,L1b);

    c.rgb += volume_light*_LightVolumesInfluence;
#endif


    #if defined(_PREVIEW_ENABLE)
        c.rgb = saturate(draw*c.rgb);
        c.a = 1.0;
    #else
        c.a = saturate(draw)*i.alpha*c.a;
        #if defined(_ANTI_ALIASING_ENABLE)
            float diff_pixel = fwidth(c.a)*0.5;
            c.a = lerp(c.a,saturate(c.a+diff_pixel),diff_pixel);
        #endif
    #endif

    c.rgb *= saturate(c.rgb)*(max(0.0,_Emission)+1.0);

    return c;