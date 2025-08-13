#ifdef _ACTIVATE_DIRECTIONALLIGHT_INFLUENCE
    UNITY_LIGHT_ATTENUATION(attenuation,i,i.world_normal);
    float3 light = max(0.0,dot(i.world_normal,_WorldSpaceLightPos0.xyz))*_LightColor0*attenuation;

    c.rgb += lerp(0.0,light,_DirectionalLightInfluence);
#endif

#if defined(_ACTIVATE_AMBIENT_INFLUENCE) && !defined(_ACTIVATE_LIGHTVOLUMES)
    float3 ambient = saturate(ShadeSH9(float4(i.world_normal,1.0)));

    c.rgb += ambient*_AmbientInfluence;
#elif defined(_ACTIVATE_LIGHTVOLUMES)
    float3 L01 = 0.0;
    float3 L1r = 0.0;
    float3 L1g = 0.0;
    float3 L1b = 0.0;
    LightVolumeSH(i.world_pos,L01,L1r,L1g,L1b);
    float3 volume_light = LightVolumeEvaluate(normalize(i.world_normal),L01,L1r,L1g,L1b);

    c.rgb += volume_light*_LightVolumesInfluence;
#endif


    #ifdef _PREVIEW_MODE
        c.rgb = saturate(draw*c.rgb);
        c.a = 1.0;
    #else
        c.a = saturate((saturate(draw)*i.alpha*c.a));
    #endif

    c.rgb *= saturate(c.rgb)*(max(0.0,_Emission)+1.0);

    return c;