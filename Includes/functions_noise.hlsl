#if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_FRAGMENTSOURCE_NOISE3RD)
    float FragmentNoiseRaw(float3 inputs, float offset, float time){
        float n = GenNoise(
            inputs,
            offset,
            time,
            FRAGMENT_FUNC_SEED_MACRO,
            FRAGMENT_FUNC_PHASESCALE_MACRO
        );
        return ThresholdFormula(
            triloop(n),
            FRAGMENT_FUNC_THRESHOLD_MUL_MACRO,
            FRAGMENT_FUNC_THRESHOLD_ADD_MACRO
        );
    }

    // float FragmentRepeatNoiseRaw(float3 inputs, float offset, float time){
    //     float n = GenNoise(
    //         inputs,
    //         offset,
    //         time,
    //         FRAGMENT_FUNC_SEED_MACRO,
    //         FRAGMENT_FUNC_PHASESCALE_MACRO
    //     );
    //     float r = ThresholdFormula(
    //         triloop(n),
    //         FRAGMENT_FUNC_THRESHOLD_MUL_MACRO,
    //         FRAGMENT_FUNC_THRESHOLD_ADD_MACRO
    //     );
    //     return Inverse12(n,r);
    // }

    float FragmentNoisePingPong(float3 inputs, float offset, float time){
        float r = saturate(FRAGMENT_METHOD_NOISEMAP_MACRO(FragmentNoiseRaw(inputs,offset,time),FRAGMENT_FUNC_VALUECARVE_MACRO));
        return FUNC_FRAGMENT_AUDIOLINK_NOISE_WAVE_MACRO(r);
    }
    // float FragmentNoiseRepeat(float3 inputs, float offset, float time){
    //     return saturate(FRAGMENT_METHOD_NOISEMAP_MACRO(FragmentRepeatNoiseRaw(inputs,offset,time),FRAGMENT_FUNC_VALUECARVE_MACRO));
    // }

    float FragmentSidePosNoise(float3 v0, float3 v1, float3 v, float3 c, float offset, float time){
        float3 side_center = (v0+v1+VertexCenterBias(v0,v1,v,c,saturate(_TriangleComp/26.0)*0.5+0.5))/3.0;
        float r = FragmentNoiseRaw(side_center, offset, time);
        return FUNC_FRAGMENT_AUDIOLINK_NOISE_WAVE_MACRO(r);
    }
#endif

#if defined(_COLORINGSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE3RD)
    float ColorNoiseRaw(float3 inputs, float offset, float time){
        float n = GenNoise(
            inputs,
            offset,
            time,
            COLOR_FUNC_SEED_MACRO,
            COLOR_FUNC_PHASESCALE_MACRO
        );
        return ThresholdFormula(
            triloop(n),
            COLOR_FUNC_THRESHOLD_MUL_MACRO,
            COLOR_FUNC_THRESHOLD_ADD_MACRO
        );
    }

    float ColorNoisePingPong(float3 inputs, float offset, float time){
        float r = saturate(COLOR_METHOD_NOISEMAP_MACRO(ColorNoiseRaw(inputs,offset,time),COLOR_FUNC_VALUECARVE_MACRO));
        return FUNC_COLORING_AUDIOLINK_NOISE_WAVE_MACRO(r);
    }

    float ColorSidePosNoisePingPong(float3 v0, float3 v1, float3 v, float3 c, float offset, float time){
        float3 side_center = (v0+v1+VertexCenterBias(v0,v1,v,c,saturate(_TriangleComp/26.0)*0.5+0.5))/3.0;
        float r = ColorNoisePingPong(side_center,offset,time);
        return FUNC_COLORING_AUDIOLINK_NOISE_WAVE_MACRO(r);
    }

#endif

#if defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE3RD)
    float GeometryNoiseRaw(float3 inputs, float offset, float time){
        float n = GenNoise(
            inputs,
            offset,
            time,
            GEOMETRY_FUNC_SEED_MACRO,
            GEOMETRY_FUNC_PHASESCALE_MACRO
        );
        return ThresholdFormula(
            triloop(n),
            GEOMETRY_FUNC_THRESHOLD_MUL_MACRO,
            GEOMETRY_FUNC_THRESHOLD_ADD_MACRO
        );
    }

    float GeometryRepeatNoiseRaw(float3 inputs, float offset, float time){
        float n = GenNoise(
            inputs,
            offset,
            time,
            GEOMETRY_FUNC_SEED_MACRO,
            GEOMETRY_FUNC_PHASESCALE_MACRO
        );
        float r = ThresholdFormula(
            triloop(n),
            GEOMETRY_FUNC_THRESHOLD_MUL_MACRO,
            GEOMETRY_FUNC_THRESHOLD_ADD_MACRO
        );
        return Inverse12(n,r);
    }

    float GeometryNoisePingPong(float3 inputs, float offset, float time){
        float r = saturate(GEOMETRY_METHOD_NOISEMAP_MACRO(GeometryNoiseRaw(inputs,offset,time),GEOMETRY_FUNC_VALUECARVE_MACRO));
        return FUNC_GEOMETRY_AUDIOLINK_NOISE_WAVE_MACRO(r);
    }
    float GeometryNoiseRepeat(float3 inputs, float offset, float time){
        float r = saturate(GEOMETRY_METHOD_NOISEMAP_MACRO(GeometryRepeatNoiseRaw(inputs,offset,time),GEOMETRY_FUNC_VALUECARVE_MACRO));
        return FUNC_GEOMETRY_AUDIOLINK_NOISE_WAVE_MACRO(r);
    }

#endif

#if defined(_GEOMETRYMESSYSOURCE_NOISE1ST) || defined(_GEOMETRYMESSYSOURCE_NOISE2ND) || defined(_GEOMETRYMESSYSOURCE_NOISE3RD)
    float GeometryMessyNoiseRaw(float3 inputs, float offset, float time){
        float n = GenNoise(
            inputs,
            offset,
            time,
            GEOMETRYMESSY_FUNC_SEED_MACRO,
            GEOMETRYMESSY_FUNC_PHASESCALE_MACRO
        );
        return ThresholdFormula(
            triloop(n),
            GEOMETRYMESSY_FUNC_THRESHOLD_MUL_MACRO,
            GEOMETRYMESSY_FUNC_THRESHOLD_ADD_MACRO
        );
    }

    // float GeometryMessyRepeatNoiseRaw(float3 inputs, float offset, float time){
    //     float n = GenNoise(
    //         inputs,
    //         offset,
    //         time,
    //         GEOMETRYMESSY_FUNC_SEED_MACRO,
    //         GEOMETRYMESSY_FUNC_PHASESCALE_MACRO
    //     );
    //     float r = ThresholdFormula(
    //         triloop(n),
    //         GEOMETRYMESSY_FUNC_THRESHOLD_MUL_MACRO,
    //         GEOMETRYMESSY_FUNC_THRESHOLD_ADD_MACRO
    //     );
    //     return Inverse12(n,r);
    // }

    float GeometryMessyNoisePingPong(float3 inputs, float offset, float time){
        return saturate(GEOMETRYMESSY_METHOD_NOISEMAP_MACRO(GeometryMessyNoiseRaw(inputs,offset,time),GEOMETRYMESSY_FUNC_VALUECARVE_MACRO));
    }
    // float GeometryMessyNoiseRepeat(float3 inputs, float offset, float time){
    //     return saturate(GEOMETRYMESSY_METHOD_NOISEMAP_MACRO(GeometryMessyRepeatNoiseRaw(inputs,offset,time),GEOMETRYMESSY_FUNC_VALUECARVE_MACRO));
    // }

#endif
