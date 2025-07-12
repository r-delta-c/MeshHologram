#if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_FRAGMENTSOURCE_NOISE3RD)
    float FragmentNoiseMapRaw(float3 inputs, float offset){
        return triloop((ValueNoise3D((inputs),FRAGMENT_FUNC_SEED_MACRO)+offset)*FRAGMENT_FUNC_PHASESCALE_MACRO+FRAGMENT_FUNC_TIME_MACRO)*FRAGMENT_FUNC_THRESHOLD_MUL_MACRO-FRAGMENT_FUNC_THRESHOLD_MUL_MACRO*0.5+0.5+
        FRAGMENT_FUNC_THRESHOLD_ADD_MACRO*(FRAGMENT_FUNC_THRESHOLD_MUL_MACRO+sign(FRAGMENT_FUNC_THRESHOLD_MUL_MACRO>=0.0?1.0:-1.0));
    }

    float FragmentNoiseMap01(float3 inputs, float offset){
        return saturate(FRAGMENT_METHOD_NOISEMAP_MACRO(saturate(FragmentNoiseMapRaw(inputs,offset)),FRAGMENT_FUNC_VALUECARVE_MACRO));
    }

    float FragmentSidePosNoiseMap(float3 v0, float3 v1, float3 v, float3 c, float offset){
        float3 side_center = (v0+v1+VertexCenterBias(v0,v1,v,c,saturate(_TriangleComp/26.0)*0.5+0.5))/3.0;
        return FragmentNoiseMap01(side_center, offset);
    }
#endif

#if defined(_COLORINGSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE3RD)
    float ColorNoiseMapRaw(float3 inputs, float offset){
        return triloop((ValueNoise3D((inputs),COLOR_FUNC_SEED_MACRO)+offset)*COLOR_FUNC_PHASESCALE_MACRO+COLOR_FUNC_TIME_MACRO)*COLOR_FUNC_THRESHOLD_MUL_MACRO-COLOR_FUNC_THRESHOLD_MUL_MACRO*0.5+0.5+
        COLOR_FUNC_THRESHOLD_ADD_MACRO*(COLOR_FUNC_THRESHOLD_MUL_MACRO+sign(COLOR_FUNC_THRESHOLD_MUL_MACRO>=0.0?1.0:-1.0));
    }

    float ColorNoiseMap01(float3 inputs, float offset){
        return saturate(COLOR_METHOD_NOISEMAP_MACRO(saturate(ColorNoiseMapRaw(inputs,offset)),COLOR_FUNC_VALUECARVE_MACRO));
    }

    float ColorSidePosNoiseMap(float3 v0, float3 v1, float3 v, float3 c, float offset){
        float3 side_center = (v0+v1+VertexCenterBias(v0,v1,v,c,saturate(_TriangleComp/26.0)*0.5+0.5))/3.0;
        return ColorNoiseMap01(side_center,offset);
    }
#endif


#if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
    float GeometryNoiseMapRaw(float3 inputs, float offset){
        return triloop((ValueNoise3D((inputs),GEOMETRY_FUNC_SEED_MACRO)+offset)*GEOMETRY_FUNC_PHASESCALE_MACRO+GEOMETRY_FUNC_TIME_MACRO)
        *GEOMETRY_FUNC_THRESHOLD_MUL_MACRO-GEOMETRY_FUNC_THRESHOLD_MUL_MACRO*0.5+0.5+
        GEOMETRY_FUNC_THRESHOLD_ADD_MACRO*(GEOMETRY_FUNC_THRESHOLD_MUL_MACRO+sign(GEOMETRY_FUNC_THRESHOLD_MUL_MACRO>=0.0?1.0:-1.0));
    }

    float GeometryNoiseMap01(float3 inputs, float offset){
        return saturate(GEOMETRY_METHOD_NOISEMAP_MACRO(saturate(GeometryNoiseMapRaw(inputs,offset)),GEOMETRY_FUNC_VALUECARVE_MACRO));
    }
#endif

#if defined(_GEOMETRYMESSYSOURCE_NOISE1ST) || defined(_GEOMETRYMESSYSOURCE_NOISE2ND) || defined(_GEOMETRYMESSYSOURCE_NOISE3RD)
    float GeometryMessyNoiseMapRaw(float3 inputs, float offset){
        return triloop((ValueNoise3D((inputs),GEOMETRYMESSY_FUNC_SEED_MACRO)+offset)*GEOMETRYMESSY_FUNC_PHASESCALE_MACRO+GEOMETRYMESSY_FUNC_TIME_MACRO)
        *GEOMETRYMESSY_FUNC_THRESHOLD_MUL_MACRO-GEOMETRYMESSY_FUNC_THRESHOLD_MUL_MACRO*0.5+0.5+
        GEOMETRYMESSY_FUNC_THRESHOLD_ADD_MACRO*(GEOMETRYMESSY_FUNC_THRESHOLD_MUL_MACRO+sign(GEOMETRYMESSY_FUNC_THRESHOLD_MUL_MACRO>=0.0?1.0:-1.0));
    }

    float GeometryMessyNoiseMap01(float3 inputs, float offset){
        return saturate(GEOMETRYMESSY_METHOD_NOISEMAP_MACRO(saturate(GeometryMessyNoiseMapRaw(inputs,offset)),GEOMETRYMESSY_FUNC_VALUECARVE_MACRO));
    }
#endif
