#if defined(_FRAGMENTSOURCE_NOISE1ST) || defined(_COLORINGSOURCE_NOISE1ST) || defined(_GEOMETRYSOURCE_NOISE1ST) || defined(_GEOMETRYMESSYSOURCE_NOISE1ST)
    #define NOISE1ST_MACRO o.noise1st_pos = NOISE1ST_POS_MACRO
    #define STRUCT_NOISE1ST_MACRO
    #define TEX2D_NOISE1ST_MACRO

    #ifdef _NOISE1STSPACE_OFFSET
        #define NOISE1ST_POS_MACRO DEFINE_SPACE_OFFSET_MACRO(_Noise1stOffset0,_Noise1stScale0)
    #elif _NOISE1STSPACE_ORIGIN_WORLD
        #define NOISE1ST_POS_MACRO DEFINE_SPACE_ORIGIN_WORLD_MACRO(_Noise1stOffset0,_Noise1stScale0)
    #else
        #ifdef _NOISE1ST_OFFSET_BEFORE_SCALE
            #ifdef _NOISE1STSPACE_MODEL
                #define NOISE1ST_POS_MACRO DEFINE_SPACE_MODEL_1_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #elif _NOISE1STSPACE_WORLD
                #define NOISE1ST_POS_MACRO DEFINE_SPACE_WORLD_1_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #elif _NOISE1STSPACE_MODEL_WORLD
                #define NOISE1ST_POS_MACRO DEFINE_SPACE_MODEL_WORLD_1_MACRO(_Noise1stOffset0,_Noise1stScale0,_Noise1stOffset1,_Noise1stScale1)
            #elif _NOISE1STSPACE_VERTEXCOLOR
                #define NOISE1ST_POS_MACRO DEFINE_SPACE_VERTEXCOLOR_1_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #else
                #define NOISE1ST_POS_MACRO 0.0
            #endif
        #else
            #ifdef _NOISE1STSPACE_MODEL
                #define NOISE1ST_POS_MACRO DEFINE_SPACE_MODEL_0_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #elif _NOISE1STSPACE_WORLD
                #define NOISE1ST_POS_MACRO DEFINE_SPACE_WORLD_0_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #elif _NOISE1STSPACE_MODEL_WORLD
                #define NOISE1ST_POS_MACRO DEFINE_SPACE_MODEL_WORLD_0_MACRO(_Noise1stOffset0,_Noise1stScale0,_Noise1stOffset1,_Noise1stScale1)
            #elif _NOISE1STSPACE_VERTEXCOLOR
                #define NOISE1ST_POS_MACRO DEFINE_SPACE_VERTEXCOLOR_0_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #else
                #define NOISE1ST_POS_MACRO 0.0
            #endif
        #endif
    #endif

#else
    #define NOISE1ST_MACRO //
    #define STRUCT_NOISE1ST_MACRO //
    #define TEX2D_NOISE1ST_MACRO //
#endif



#if defined(_FRAGMENTSOURCE_NOISE2ND) || defined(_COLORINGSOURCE_NOISE2ND) || defined(_GEOMETRYSOURCE_NOISE2ND) || defined(_GEOMETRYMESSYSOURCE_NOISE2ND)
    #define NOISE2ND_MACRO o.noise2nd_pos = NOISE2ND_POS_MACRO
    #define STRUCT_NOISE2ND_MACRO
    #define TEX2D_NOISE2ND_MACRO

    #ifdef _NOISE2NDSPACE_OFFSET
        #define NOISE2ND_POS_MACRO DEFINE_SPACE_OFFSET_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
    #elif _NOISE2NDSPACE_ORIGIN_WORLD
        #define NOISE2ND_POS_MACRO DEFINE_SPACE_ORIGIN_WORLD_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
    #else
        #ifdef _NOISE2ND_OFFSET_BEFORE_SCALE
            #ifdef _NOISE2NDSPACE_MODEL
                #define NOISE2ND_POS_MACRO DEFINE_SPACE_MODEL_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #elif _NOISE2NDSPACE_WORLD
                #define NOISE2ND_POS_MACRO DEFINE_SPACE_WORLD_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #elif _NOISE2NDSPACE_MODEL_WORLD
                #define NOISE2ND_POS_MACRO DEFINE_SPACE_MODEL_WORLD_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0,_Noise2ndOffset1,_Noise2ndScale1)
            #elif _NOISE2NDSPACE_VERTEXCOLOR
                #define NOISE2ND_POS_MACRO DEFINE_SPACE_VERTEXCOLOR_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #else
                #define NOISE2ND_POS_MACRO 0.0
            #endif
        #else
            #ifdef _NOISE2NDSPACE_MODEL
                #define NOISE2ND_POS_MACRO DEFINE_SPACE_MODEL_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #elif _NOISE2NDSPACE_WORLD
                #define NOISE2ND_POS_MACRO DEFINE_SPACE_WORLD_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #elif _NOISE2NDSPACE_MODEL_WORLD
                #define NOISE2ND_POS_MACRO DEFINE_SPACE_MODEL_WORLD_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0,_Noise2ndOffset1,_Noise2ndScale1)
            #elif _NOISE2NDSPACE_VERTEXCOLOR
                #define NOISE2ND_POS_MACRO DEFINE_SPACE_VERTEXCOLOR_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #else
                #define NOISE2ND_POS_MACRO 0.0
            #endif
        #endif
    #endif

#else
    #define NOISE2ND_MACRO //
    #define STRUCT_NOISE2ND_MACRO //
    #define TEX2D_NOISE2ND_MACRO //
#endif



#if defined(_FRAGMENTSOURCE_NOISE3RD) || defined(_COLORINGSOURCE_NOISE3RD) || defined(_GEOMETRYSOURCE_NOISE3RD) || defined(_GEOMETRYMESSYSOURCE_NOISE3RD)
    #define NOISE3RD_MACRO o.noise3rd_pos = NOISE3RD_POS_MACRO
    #define STRUCT_NOISE3RD_MACRO
    #define TEX2D_NOISE3RD_MACRO

    #ifdef _NOISE3RDSPACE_OFFSET
        #define NOISE3RD_POS_MACRO DEFINE_SPACE_OFFSET_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
    #elif _NOISE3RDSPACE_ORIGIN_WORLD
        #define NOISE3RD_POS_MACRO DEFINE_SPACE_ORIGIN_WORLD_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
    #else
        #ifdef _NOISE3RD_OFFSET_BEFORE_SCALE
            #ifdef _NOISE3RDSPACE_MODEL
                #define NOISE3RD_POS_MACRO DEFINE_SPACE_MODEL_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #elif _NOISE3RDSPACE_WORLD
                #define NOISE3RD_POS_MACRO DEFINE_SPACE_WORLD_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #elif _NOISE3RDSPACE_MODEL_WORLD
                #define NOISE3RD_POS_MACRO DEFINE_SPACE_MODEL_WORLD_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0,_Noise3rdOffset1,_Noise3rdScale1)
            #elif _NOISE3RDSPACE_VERTEXCOLOR
                #define NOISE3RD_POS_MACRO DEFINE_SPACE_VERTEXCOLOR_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #else
                #define NOISE3RD_POS_MACRO 0.0
            #endif
        #else
            #ifdef _NOISE3RDSPACE_MODEL
                #define NOISE3RD_POS_MACRO DEFINE_SPACE_MODEL_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #elif _NOISE3RDSPACE_WORLD
                #define NOISE3RD_POS_MACRO DEFINE_SPACE_WORLD_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #elif _NOISE3RDSPACE_MODEL_WORLD
                #define NOISE3RD_POS_MACRO DEFINE_SPACE_MODEL_WORLD_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0,_Noise3rdOffset1,_Noise3rdScale1)
            #elif _NOISE3RDSPACE_VERTEXCOLOR
                #define NOISE3RD_POS_MACRO DEFINE_SPACE_VERTEXCOLOR_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #else
                #define NOISE3RD_POS_MACRO 0.0
            #endif
        #endif
    #endif

#else
    #define NOISE3RD_MACRO //
    #define STRUCT_NOISE3RD_MACRO //
    #define TEX2D_NOISE3RD_MACRO //
#endif



#define DEFINE_SPACE_MODEL_0_MACRO(t,s) ((v.pos.xyz+t)*s.xyz*s.w)
#define DEFINE_SPACE_WORLD_0_MACRO(t,s) ((o.pos.xyz+t)*s.xyz*s.w)
#define DEFINE_SPACE_MODEL_WORLD_0_MACRO(t0,s0,t1,s1) ((v.pos.xyz+t0.xyz)*s0.xyz*s0.w+(o.pos.xyz+t1.xyz)*s1.xyz*s1.w)
#define DEFINE_SPACE_VERTEXCOLOR_0_MACRO(t,s) ((v.color.xyz+t.xyz)*s.xyz*s.w)

#define DEFINE_SPACE_MODEL_1_MACRO(t,s) (v.pos.xyz*s.xyz*s.w+t)
#define DEFINE_SPACE_WORLD_1_MACRO(t,s) (o.pos.xyz*s.xyz*s.w+t)
#define DEFINE_SPACE_MODEL_WORLD_1_MACRO(t0,s0,t1,s1) ((v.pos.xyz*s0.xyz*s0.w+t0.xyz)+(o.pos.xyz*s1.xyz*s1.w+t1.xyz))
#define DEFINE_SPACE_VERTEXCOLOR_1_MACRO(t,s) (v.color.xyz*s.xyz*s.w+t.xyz)

#define DEFINE_SPACE_OFFSET_MACRO(t,s) (t*s.xyz*s.w)
#define DEFINE_SPACE_ORIGIN_WORLD_MACRO(t,s) (mul(UNITY_MATRIX_M,float4(t.xyz,1.0)).xyz*s.xyz*s.w)



#ifdef _FRAGMENTSOURCE_NOISE1ST
    #define FRAGMENT_NOISE_MACRO noise1st_pos
    #define FRAGMENT_CENTER_MACRO (inp[0].noise1st_pos+inp[1].noise1st_pos+inp[2].noise1st_pos)/3.0
    #define FRAGMENT_OFFSET_MACRO(n) noise1st_offset[n]

    #ifdef _NOISE1STREFERENCETIME_SHADERTIME
        #define FRAGMENT_FUNC_TIME_MACRO (_Time.x*_Noise1stTimeMulti+_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO)
    #else
        #define FRAGMENT_FUNC_TIME_MACRO (_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO)
    #endif

    #define FRAGMENT_FUNC_SEED_MACRO _Noise1stSeed
    #define FRAGMENT_FUNC_VALUECARVE_MACRO _Noise1stValueCurve
    #define FRAGMENT_FUNC_THRESHOLD_MUL_MACRO _Noise1stThresholdMul
    #define FRAGMENT_FUNC_THRESHOLD_ADD_MACRO _Noise1stThresholdAdd
    #define FRAGMENT_FUNC_PHASESCALE_MACRO _Noise1stPhaseScale
    #define FRAGMENT_METHOD_NOISEMAP_MACRO(i,m) NOISE1STMAP01_METHOD_MACRO(i,m)

#elif _FRAGMENTSOURCE_NOISE2ND
    #define FRAGMENT_NOISE_MACRO noise2nd_pos
    #define FRAGMENT_CENTER_MACRO (inp[0].noise2nd_pos+inp[1].noise2nd_pos+inp[2].noise2nd_pos)/3.0
    #define FRAGMENT_OFFSET_MACRO(n) noise2nd_offset[n]

    #ifdef _NOISE2NDREFERENCETIME_SHADERTIME
        #define FRAGMENT_FUNC_TIME_MACRO (_Time.x*_Noise2ndTimeMulti+_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO)
    #else
        #define FRAGMENT_FUNC_TIME_MACRO (_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO)
    #endif

    #define FRAGMENT_FUNC_SEED_MACRO _Noise2ndSeed
    #define FRAGMENT_FUNC_VALUECARVE_MACRO _Noise2ndValueCurve
    #define FRAGMENT_FUNC_THRESHOLD_MUL_MACRO _Noise2ndThresholdMul
    #define FRAGMENT_FUNC_THRESHOLD_ADD_MACRO _Noise2ndThresholdAdd
    #define FRAGMENT_FUNC_PHASESCALE_MACRO _Noise2ndPhaseScale
    #define FRAGMENT_METHOD_NOISEMAP_MACRO(i,m) NOISE2NDMAP01_METHOD_MACRO(i,m)

#elif _FRAGMENTSOURCE_NOISE3RD
    #define FRAGMENT_NOISE_MACRO noise3rd_pos
    #define FRAGMENT_CENTER_MACRO (inp[0].noise3rd_pos+inp[1].noise3rd_pos+inp[2].noise3rd_pos)/3.0
    #define FRAGMENT_OFFSET_MACRO(n) noise3rd_offset[n]

    #ifdef _NOISE3RDREFERENCETIME_SHADERTIME
        #define FRAGMENT_FUNC_TIME_MACRO (_Time.x*_Noise3rdTimeMulti+_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO)
    #else
        #define FRAGMENT_FUNC_TIME_MACRO (_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO)
    #endif

    #define FRAGMENT_FUNC_SEED_MACRO _Noise3rdSeed
    #define FRAGMENT_FUNC_VALUECARVE_MACRO _Noise3rdValueCurve
    #define FRAGMENT_FUNC_THRESHOLD_MUL_MACRO _Noise3rdThresholdMul
    #define FRAGMENT_FUNC_THRESHOLD_ADD_MACRO _Noise3rdThresholdAdd
    #define FRAGMENT_FUNC_PHASESCALE_MACRO _Noise3rdPhaseScale
    #define FRAGMENT_METHOD_NOISEMAP_MACRO(i,m) NOISE3RDMAP01_METHOD_MACRO(i,m)
#endif



#ifdef _COLORINGSOURCE_NOISE1ST
    #define COLOR_NOISE_MACRO noise1st_pos
    #define COLOR_CENTER_MACRO (inp[0].noise1st_pos+inp[1].noise1st_pos+inp[2].noise1st_pos)/3.0
    #define COLOR_OFFSET_MACRO(n) noise1st_offset[n]

    #ifdef _NOISE1STREFERENCETIME_SHADERTIME
        #define COLOR_FUNC_TIME_MACRO (_Time.x*_Noise1stTimeMulti+_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO)
    #else
        #define COLOR_FUNC_TIME_MACRO (_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO)
    #endif

    #define COLOR_FUNC_SEED_MACRO _Noise1stSeed
    #define COLOR_FUNC_VALUECARVE_MACRO _Noise1stValueCurve
    #define COLOR_FUNC_THRESHOLD_MUL_MACRO _Noise1stThresholdMul
    #define COLOR_FUNC_THRESHOLD_ADD_MACRO _Noise1stThresholdAdd
    #define COLOR_FUNC_PHASESCALE_MACRO _Noise1stPhaseScale
    #define COLOR_METHOD_NOISEMAP_MACRO(i,m) NOISE1STMAP01_METHOD_MACRO(i,m)

#elif _COLORINGSOURCE_NOISE2ND
    #define COLOR_NOISE_MACRO noise2nd_pos
    #define COLOR_CENTER_MACRO (inp[0].noise2nd_pos+inp[1].noise2nd_pos+inp[2].noise2nd_pos)/3.0
    #define COLOR_OFFSET_MACRO(n) noise2nd_offset[n]

    #ifdef _NOISE2NDREFERENCETIME_SHADERTIME
        #define COLOR_FUNC_TIME_MACRO (_Time.x*_Noise2ndTimeMulti+_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO)
    #else
        #define COLOR_FUNC_TIME_MACRO (_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO)
    #endif

    #define COLOR_FUNC_SEED_MACRO _Noise2ndSeed
    #define COLOR_FUNC_VALUECARVE_MACRO _Noise2ndValueCurve
    #define COLOR_FUNC_THRESHOLD_MUL_MACRO _Noise2ndThresholdMul
    #define COLOR_FUNC_THRESHOLD_ADD_MACRO _Noise2ndThresholdAdd
    #define COLOR_FUNC_PHASESCALE_MACRO _Noise2ndPhaseScale
    #define COLOR_METHOD_NOISEMAP_MACRO(i,m) NOISE2NDMAP01_METHOD_MACRO(i,m)

#elif _COLORINGSOURCE_NOISE3RD
    #define COLOR_NOISE_MACRO noise3rd_pos
    #define COLOR_CENTER_MACRO (inp[0].noise3rd_pos+inp[1].noise3rd_pos+inp[2].noise3rd_pos)/3.0
    #define COLOR_OFFSET_MACRO(n) noise3rd_offset[n]

    #ifdef _NOISE3RDREFERENCETIME_SHADERTIME
        #define COLOR_FUNC_TIME_MACRO (_Time.x*_Noise3rdTimeMulti+_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO)
    #else
        #define COLOR_FUNC_TIME_MACRO (_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO)
    #endif

    #define COLOR_FUNC_SEED_MACRO _Noise3rdSeed
    #define COLOR_FUNC_VALUECARVE_MACRO _Noise3rdValueCurve
    #define COLOR_FUNC_THRESHOLD_MUL_MACRO _Noise3rdThresholdMul
    #define COLOR_FUNC_THRESHOLD_ADD_MACRO _Noise3rdThresholdAdd
    #define COLOR_FUNC_PHASESCALE_MACRO _Noise3rdPhaseScale
    #define COLOR_METHOD_NOISEMAP_MACRO(i,m) NOISE3RDMAP01_METHOD_MACRO(i,m)
#endif



#ifdef _GEOMETRYSOURCE_NOISE1ST
    #define GEOMETRY_NOISE_MACRO noise1st_pos
    #define GEOMETRY_CENTER_MACRO (inp[0].noise1st_pos+inp[1].noise1st_pos+inp[2].noise1st_pos)/3.0
    #define GEOMETRY_OFFSET_MACRO(n) noise1st_offset[n]

    #ifdef _NOISE1STREFERENCETIME_SHADERTIME
        #define GEOMETRY_FUNC_TIME_MACRO (_Time.x*_Noise1stTimeMulti+_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO)
    #else
        #define GEOMETRY_FUNC_TIME_MACRO (_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO)
    #endif

    #define GEOMETRY_FUNC_SEED_MACRO _Noise1stSeed
    #define GEOMETRY_FUNC_VALUECARVE_MACRO _Noise1stValueCurve
    #define GEOMETRY_FUNC_THRESHOLD_MUL_MACRO _Noise1stThresholdMul
    #define GEOMETRY_FUNC_THRESHOLD_ADD_MACRO _Noise1stThresholdAdd
    #define GEOMETRY_FUNC_PHASESCALE_MACRO _Noise1stPhaseScale
    #define GEOMETRY_METHOD_NOISEMAP_MACRO(i,m) NOISE1STMAP01_METHOD_MACRO(i,m)

#elif _GEOMETRYSOURCE_NOISE2ND
    #define GEOMETRY_NOISE_MACRO noise2nd_pos
    #define GEOMETRY_CENTER_MACRO (inp[0].noise2nd_pos+inp[1].noise2nd_pos+inp[2].noise2nd_pos)/3.0
    #define GEOMETRY_OFFSET_MACRO(n) noise2nd_offset[n]

    #ifdef _NOISE2NDREFERENCETIME_SHADERTIME
        #define GEOMETRY_FUNC_TIME_MACRO (_Time.x*_Noise2ndTimeMulti+_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO)
    #else
        #define GEOMETRY_FUNC_TIME_MACRO (_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO)
    #endif

    #define GEOMETRY_FUNC_SEED_MACRO _Noise2ndSeed
    #define GEOMETRY_FUNC_VALUECARVE_MACRO _Noise2ndValueCurve
    #define GEOMETRY_FUNC_THRESHOLD_MUL_MACRO _Noise2ndThresholdMul
    #define GEOMETRY_FUNC_THRESHOLD_ADD_MACRO _Noise2ndThresholdAdd
    #define GEOMETRY_FUNC_PHASESCALE_MACRO _Noise2ndPhaseScale
    #define GEOMETRY_METHOD_NOISEMAP_MACRO(i,m) NOISE2NDMAP01_METHOD_MACRO(i,m)

#elif _GEOMETRYSOURCE_NOISE3RD
    #define GEOMETRY_NOISE_MACRO noise3rd_pos
    #define GEOMETRY_CENTER_MACRO (inp[0].noise3rd_pos+inp[1].noise3rd_pos+inp[2].noise3rd_pos)/3.0
    #define GEOMETRY_OFFSET_MACRO(n) noise3rd_offset[n]

    #ifdef _NOISE3RDREFERENCETIME_SHADERTIME
        #define GEOMETRY_FUNC_TIME_MACRO (_Time.x*_Noise3rdTimeMulti+_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO)
    #else
        #define GEOMETRY_FUNC_TIME_MACRO (_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO)
    #endif

    #define GEOMETRY_FUNC_SEED_MACRO _Noise3rdSeed
    #define GEOMETRY_FUNC_VALUECARVE_MACRO _Noise3rdValueCurve
    #define GEOMETRY_FUNC_THRESHOLD_MUL_MACRO _Noise3rdThresholdMul
    #define GEOMETRY_FUNC_THRESHOLD_ADD_MACRO _Noise3rdThresholdAdd
    #define GEOMETRY_FUNC_PHASESCALE_MACRO _Noise3rdPhaseScale
    #define GEOMETRY_METHOD_NOISEMAP_MACRO(i,m) NOISE3RDMAP01_METHOD_MACRO(i,m)
#else
    #define GEOMETRY_NOISE_MACRO _GeometryValue
#endif



#ifdef _GEOMETRYMESSYSOURCE_NOISE1ST
    #define GEOMETRYMESSY_NOISE_MACRO noise1st_pos
    #define GEOMETRYMESSY_CENTER_MACRO (inp[0].noise1st_pos+inp[1].noise1st_pos+inp[2].noise1st_pos)/3.0
    #define GEOMETRYMESSY_OFFSET_MACRO(n) noise1st_offset[n]

    #ifdef _NOISE1STREFERENCETIME_SHADERTIME
        #define GEOMETRYMESSY_FUNC_TIME_MACRO (_Time.x*_Noise1stTimeMulti+_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO)
    #else
        #define GEOMETRYMESSY_FUNC_TIME_MACRO (_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO)
    #endif

    #define GEOMETRYMESSY_FUNC_SEED_MACRO _Noise1stSeed
    #define GEOMETRYMESSY_FUNC_VALUECARVE_MACRO _Noise1stValueCurve
    #define GEOMETRYMESSY_FUNC_THRESHOLD_MUL_MACRO _Noise1stThresholdMul
    #define GEOMETRYMESSY_FUNC_THRESHOLD_ADD_MACRO _Noise1stThresholdAdd
    #define GEOMETRYMESSY_FUNC_PHASESCALE_MACRO _Noise1stPhaseScale
    #define GEOMETRYMESSY_METHOD_NOISEMAP_MACRO(i,m) NOISE1STMAP01_METHOD_MACRO(i,m)

#elif _GEOMETRYMESSYSOURCE_NOISE2ND
    #define GEOMETRYMESSY_NOISE_MACRO noise2nd_pos
    #define GEOMETRYMESSY_CENTER_MACRO (inp[0].noise2nd_pos+inp[1].noise2nd_pos+inp[2].noise2nd_pos)/3.0
    #define GEOMETRYMESSY_OFFSET_MACRO(n) noise2nd_offset[n]

    #ifdef _NOISE2NDREFERENCETIME_SHADERTIME
        #define GEOMETRYMESSY_FUNC_TIME_MACRO (_Time.x*_Noise2ndTimeMulti+_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO)
    #else
        #define GEOMETRYMESSY_FUNC_TIME_MACRO (_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO)
    #endif

    #define GEOMETRYMESSY_FUNC_SEED_MACRO _Noise2ndSeed
    #define GEOMETRYMESSY_FUNC_VALUECARVE_MACRO _Noise2ndValueCurve
    #define GEOMETRYMESSY_FUNC_THRESHOLD_MUL_MACRO _Noise2ndThresholdMul
    #define GEOMETRYMESSY_FUNC_THRESHOLD_ADD_MACRO _Noise2ndThresholdAdd
    #define GEOMETRYMESSY_FUNC_PHASESCALE_MACRO _Noise2ndPhaseScale
    #define GEOMETRYMESSY_METHOD_NOISEMAP_MACRO(i,m) NOISE2NDMAP01_METHOD_MACRO(i,m)

#elif _GEOMETRYMESSYSOURCE_NOISE3RD
    #define GEOMETRYMESSY_NOISE_MACRO noise3rd_pos
    #define GEOMETRYMESSY_CENTER_MACRO (inp[0].noise3rd_pos+inp[1].noise3rd_pos+inp[2].noise3rd_pos)/3.0
    #define GEOMETRYMESSY_OFFSET_MACRO(n) noise3rd_offset[n]

    #ifdef _NOISE3RDREFERENCETIME_SHADERTIME
        #define GEOMETRYMESSY_FUNC_TIME_MACRO (_Time.x*_Noise3rdTimeMulti+_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO)
    #else
        #define GEOMETRYMESSY_FUNC_TIME_MACRO (_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO)
    #endif

    #define GEOMETRYMESSY_FUNC_SEED_MACRO _Noise3rdSeed
    #define GEOMETRYMESSY_FUNC_VALUECARVE_MACRO _Noise3rdValueCurve
    #define GEOMETRYMESSY_FUNC_THRESHOLD_MUL_MACRO _Noise3rdThresholdMul
    #define GEOMETRYMESSY_FUNC_THRESHOLD_ADD_MACRO _Noise3rdThresholdAdd
    #define GEOMETRYMESSY_FUNC_PHASESCALE_MACRO _Noise3rdPhaseScale
    #define GEOMETRYMESSY_METHOD_NOISEMAP_MACRO(i,m) NOISE3RDMAP01_METHOD_MACRO(i,m)
#else
    #define GEOMETRYMESSY_NOISE_MACRO _GeometryMessyValue
#endif



#ifdef _NOISE1ST_CURVE_INVERSE
    #define NOISE1STMAP01_METHOD_MACRO(i,m) EaseInOutPowInverse(i,m)
#else
    #define NOISE1STMAP01_METHOD_MACRO(i,m) EaseInOutPow(i,m)
#endif

#ifdef _NOISE2ND_CURVE_INVERSE
    #define NOISE2NDMAP01_METHOD_MACRO(i,m) EaseInOutPowInverse(i,m)
#else
    #define NOISE2NDMAP01_METHOD_MACRO(i,m) EaseInOutPow(i,m)
#endif

#ifdef _NOISE3RD_CURVE_INVERSE
    #define NOISE3RDMAP01_METHOD_MACRO(i,m) EaseInOutPowInverse(i,m)
#else
    #define NOISE3RDMAP01_METHOD_MACRO(i,m) EaseInOutPow(i,m)
#endif
