#ifdef _DEFINED_NOISE1ST
    #define NOISE1ST_MACRO o.noise1st_pos = NOISE1ST_POS_MACRO
    #define STRUCT_NOISE1ST_MACRO
    #define TEX2D_NOISE1ST_MACRO

    #ifdef _NOISE1STSPACE_OFFSET
        #define NOISE1ST_POS_MACRO REPLACE_SPACE_OFFSET_MACRO(_Noise1stOffset0,_Noise1stScale0)
    #elif _NOISE1STSPACE_ORIGIN_WORLD
        #define NOISE1ST_POS_MACRO REPLACE_SPACE_ORIGIN_WORLD_MACRO(_Noise1stOffset0,_Noise1stScale0)
    #else
        #ifdef _NOISE1ST_OFFSET_BEFORE_SCALE
            #ifdef _NOISE1STSPACE_MODEL
                #define NOISE1ST_POS_MACRO REPLACE_SPACE_MODEL_1_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #elif _NOISE1STSPACE_WORLD
                #define NOISE1ST_POS_MACRO REPLACE_SPACE_WORLD_1_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #elif _NOISE1STSPACE_MODEL_WORLD
                #define NOISE1ST_POS_MACRO REPLACE_SPACE_MODEL_WORLD_1_MACRO(_Noise1stOffset0,_Noise1stScale0,_Noise1stOffset1,_Noise1stScale1)
            #elif _NOISE1STSPACE_VERTEXCOLOR
                #define NOISE1ST_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_1_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #else
                #define NOISE1ST_POS_MACRO 0.0
            #endif
        #else
            #ifdef _NOISE1STSPACE_MODEL
                #define NOISE1ST_POS_MACRO REPLACE_SPACE_MODEL_0_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #elif _NOISE1STSPACE_WORLD
                #define NOISE1ST_POS_MACRO REPLACE_SPACE_WORLD_0_MACRO(_Noise1stOffset0,_Noise1stScale0)
            #elif _NOISE1STSPACE_MODEL_WORLD
                #define NOISE1ST_POS_MACRO REPLACE_SPACE_MODEL_WORLD_0_MACRO(_Noise1stOffset0,_Noise1stScale0,_Noise1stOffset1,_Noise1stScale1)
            #elif _NOISE1STSPACE_VERTEXCOLOR
                #define NOISE1ST_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_0_MACRO(_Noise1stOffset0,_Noise1stScale0)
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



#ifdef _DEFINED_NOISE2ND
    #define NOISE2ND_MACRO o.noise2nd_pos = NOISE2ND_POS_MACRO
    #define STRUCT_NOISE2ND_MACRO
    #define TEX2D_NOISE2ND_MACRO

    #ifdef _NOISE2NDSPACE_OFFSET
        #define NOISE2ND_POS_MACRO REPLACE_SPACE_OFFSET_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
    #elif _NOISE2NDSPACE_ORIGIN_WORLD
        #define NOISE2ND_POS_MACRO REPLACE_SPACE_ORIGIN_WORLD_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
    #else
        #ifdef _NOISE2ND_OFFSET_BEFORE_SCALE
            #ifdef _NOISE2NDSPACE_MODEL
                #define NOISE2ND_POS_MACRO REPLACE_SPACE_MODEL_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #elif _NOISE2NDSPACE_WORLD
                #define NOISE2ND_POS_MACRO REPLACE_SPACE_WORLD_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #elif _NOISE2NDSPACE_MODEL_WORLD
                #define NOISE2ND_POS_MACRO REPLACE_SPACE_MODEL_WORLD_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0,_Noise2ndOffset1,_Noise2ndScale1)
            #elif _NOISE2NDSPACE_VERTEXCOLOR
                #define NOISE2ND_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #else
                #define NOISE2ND_POS_MACRO 0.0
            #endif
        #else
            #ifdef _NOISE2NDSPACE_MODEL
                #define NOISE2ND_POS_MACRO REPLACE_SPACE_MODEL_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #elif _NOISE2NDSPACE_WORLD
                #define NOISE2ND_POS_MACRO REPLACE_SPACE_WORLD_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
            #elif _NOISE2NDSPACE_MODEL_WORLD
                #define NOISE2ND_POS_MACRO REPLACE_SPACE_MODEL_WORLD_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0,_Noise2ndOffset1,_Noise2ndScale1)
            #elif _NOISE2NDSPACE_VERTEXCOLOR
                #define NOISE2ND_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
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



#ifdef _DEFINED_NOISE3RD
    #define NOISE3RD_MACRO o.noise3rd_pos = NOISE3RD_POS_MACRO
    #define STRUCT_NOISE3RD_MACRO
    #define TEX2D_NOISE3RD_MACRO

    #ifdef _NOISE3RDSPACE_OFFSET
        #define NOISE3RD_POS_MACRO REPLACE_SPACE_OFFSET_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
    #elif _NOISE3RDSPACE_ORIGIN_WORLD
        #define NOISE3RD_POS_MACRO REPLACE_SPACE_ORIGIN_WORLD_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
    #else
        #ifdef _NOISE3RD_OFFSET_BEFORE_SCALE
            #ifdef _NOISE3RDSPACE_MODEL
                #define NOISE3RD_POS_MACRO REPLACE_SPACE_MODEL_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #elif _NOISE3RDSPACE_WORLD
                #define NOISE3RD_POS_MACRO REPLACE_SPACE_WORLD_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #elif _NOISE3RDSPACE_MODEL_WORLD
                #define NOISE3RD_POS_MACRO REPLACE_SPACE_MODEL_WORLD_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0,_Noise3rdOffset1,_Noise3rdScale1)
            #elif _NOISE3RDSPACE_VERTEXCOLOR
                #define NOISE3RD_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #else
                #define NOISE3RD_POS_MACRO 0.0
            #endif
        #else
            #ifdef _NOISE3RDSPACE_MODEL
                #define NOISE3RD_POS_MACRO REPLACE_SPACE_MODEL_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #elif _NOISE3RDSPACE_WORLD
                #define NOISE3RD_POS_MACRO REPLACE_SPACE_WORLD_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
            #elif _NOISE3RDSPACE_MODEL_WORLD
                #define NOISE3RD_POS_MACRO REPLACE_SPACE_MODEL_WORLD_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0,_Noise3rdOffset1,_Noise3rdScale1)
            #elif _NOISE3RDSPACE_VERTEXCOLOR
                #define NOISE3RD_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
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



#define REPLACE_SPACE_MODEL_0_MACRO(t,s) ((v.pos.xyz+t)*s.xyz*s.w)
#define REPLACE_SPACE_WORLD_0_MACRO(t,s) ((o.pos.xyz+t)*s.xyz*s.w)
#define REPLACE_SPACE_MODEL_WORLD_0_MACRO(t0,s0,t1,s1) ((v.pos.xyz+t0.xyz)*s0.xyz*s0.w+(o.pos.xyz+t1.xyz)*s1.xyz*s1.w)
#define REPLACE_SPACE_VERTEXCOLOR_0_MACRO(t,s) ((v.color.xyz+t.xyz)*s.xyz*s.w)

#define REPLACE_SPACE_MODEL_1_MACRO(t,s) (v.pos.xyz*s.xyz*s.w+t)
#define REPLACE_SPACE_WORLD_1_MACRO(t,s) (o.pos.xyz*s.xyz*s.w+t)
#define REPLACE_SPACE_MODEL_WORLD_1_MACRO(t0,s0,t1,s1) ((v.pos.xyz*s0.xyz*s0.w+t0.xyz)+(o.pos.xyz*s1.xyz*s1.w+t1.xyz))
#define REPLACE_SPACE_VERTEXCOLOR_1_MACRO(t,s) (v.color.xyz*s.xyz*s.w+t.xyz)

#define REPLACE_SPACE_OFFSET_MACRO(t,s) (t*s.xyz*s.w)
#define REPLACE_SPACE_ORIGIN_WORLD_MACRO(t,s) (mul(UNITY_MATRIX_M,float4(t.xyz,1.0)).xyz*s.xyz*s.w)



#ifdef _FRAGMENTSOURCE_NOISE1ST
    #define FRAGMENT_NOISE_MACRO noise1st_pos
    #define FRAGMENT_CENTER_MACRO (inp[0].noise1st_pos+inp[1].noise1st_pos+inp[2].noise1st_pos)/3.0
    #define FRAGMENT_TIME_MACRO (_Time.x*_Noise1stTimeMulti+_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO*FRAGMENT_NOISE_AL_MASK_MACRO)

    #define FRAGMENT_FUNC_SEED_MACRO _Noise1stSeed
    #define FRAGMENT_FUNC_VALUECARVE_MACRO _Noise1stValueCurve
    #define FRAGMENT_FUNC_THRESHOLD_MUL_MACRO _Noise1stThresholdMul
    #define FRAGMENT_FUNC_THRESHOLD_ADD_MACRO _Noise1stThresholdAdd
    #define FRAGMENT_FUNC_PHASESCALE_MACRO _Noise1stPhaseScale
    #define FRAGMENT_METHOD_NOISEMAP_MACRO(i,m) NOISE1STMAP01_METHOD_MACRO(i,m)

#elif _FRAGMENTSOURCE_NOISE2ND
    #define FRAGMENT_NOISE_MACRO noise2nd_pos
    #define FRAGMENT_CENTER_MACRO (inp[0].noise2nd_pos+inp[1].noise2nd_pos+inp[2].noise2nd_pos)/3.0
    #define FRAGMENT_TIME_MACRO (_Time.x*_Noise2ndTimeMulti+_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO*FRAGMENT_NOISE_AL_MASK_MACRO)

    #define FRAGMENT_FUNC_SEED_MACRO _Noise2ndSeed
    #define FRAGMENT_FUNC_VALUECARVE_MACRO _Noise2ndValueCurve
    #define FRAGMENT_FUNC_THRESHOLD_MUL_MACRO _Noise2ndThresholdMul
    #define FRAGMENT_FUNC_THRESHOLD_ADD_MACRO _Noise2ndThresholdAdd
    #define FRAGMENT_FUNC_PHASESCALE_MACRO _Noise2ndPhaseScale
    #define FRAGMENT_METHOD_NOISEMAP_MACRO(i,m) NOISE2NDMAP01_METHOD_MACRO(i,m)

#elif _FRAGMENTSOURCE_NOISE3RD
    #define FRAGMENT_NOISE_MACRO noise3rd_pos
    #define FRAGMENT_CENTER_MACRO (inp[0].noise3rd_pos+inp[1].noise3rd_pos+inp[2].noise3rd_pos)/3.0
    #define FRAGMENT_TIME_MACRO (_Time.x*_Noise3rdTimeMulti+_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO*FRAGMENT_NOISE_AL_MASK_MACRO)

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
    #define COLOR_TIME_MACRO (_Time.x*_Noise1stTimeMulti+_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO*COLORING_NOISE_AL_MASK_MACRO)

    #define COLOR_FUNC_SEED_MACRO _Noise1stSeed
    #define COLOR_FUNC_VALUECARVE_MACRO _Noise1stValueCurve
    #define COLOR_FUNC_THRESHOLD_MUL_MACRO _Noise1stThresholdMul
    #define COLOR_FUNC_THRESHOLD_ADD_MACRO _Noise1stThresholdAdd
    #define COLOR_FUNC_PHASESCALE_MACRO _Noise1stPhaseScale
    #define COLOR_METHOD_NOISEMAP_MACRO(i,m) NOISE1STMAP01_METHOD_MACRO(i,m)

#elif _COLORINGSOURCE_NOISE2ND
    #define COLOR_NOISE_MACRO noise2nd_pos
    #define COLOR_CENTER_MACRO (inp[0].noise2nd_pos+inp[1].noise2nd_pos+inp[2].noise2nd_pos)/3.0
    #define COLOR_TIME_MACRO (_Time.x*_Noise2ndTimeMulti+_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO*COLORING_NOISE_AL_MASK_MACRO)

    #define COLOR_FUNC_SEED_MACRO _Noise2ndSeed
    #define COLOR_FUNC_VALUECARVE_MACRO _Noise2ndValueCurve
    #define COLOR_FUNC_THRESHOLD_MUL_MACRO _Noise2ndThresholdMul
    #define COLOR_FUNC_THRESHOLD_ADD_MACRO _Noise2ndThresholdAdd
    #define COLOR_FUNC_PHASESCALE_MACRO _Noise2ndPhaseScale
    #define COLOR_METHOD_NOISEMAP_MACRO(i,m) NOISE2NDMAP01_METHOD_MACRO(i,m)

#elif _COLORINGSOURCE_NOISE3RD
    #define COLOR_NOISE_MACRO noise3rd_pos
    #define COLOR_CENTER_MACRO (inp[0].noise3rd_pos+inp[1].noise3rd_pos+inp[2].noise3rd_pos)/3.0
    #define COLOR_TIME_MACRO (_Time.x*_Noise3rdTimeMulti+_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO*COLORING_NOISE_AL_MASK_MACRO)

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
    #define GEOMETRY_TIME_MACRO (_Time.x*_Noise1stTimeMulti+_Noise1stTimePhase)
    #define GEOMETRY_AUDIOLINK_PHASE_MACRO NOISE1ST_AUDIOLINK_PHASE_MACRO

    #define GEOMETRY_FUNC_SEED_MACRO _Noise1stSeed
    #define GEOMETRY_FUNC_VALUECARVE_MACRO _Noise1stValueCurve
    #define GEOMETRY_FUNC_THRESHOLD_MUL_MACRO _Noise1stThresholdMul
    #define GEOMETRY_FUNC_THRESHOLD_ADD_MACRO _Noise1stThresholdAdd
    #define GEOMETRY_FUNC_PHASESCALE_MACRO _Noise1stPhaseScale
    #define GEOMETRY_METHOD_NOISEMAP_MACRO(i,m) NOISE1STMAP01_METHOD_MACRO(i,m)

#elif _GEOMETRYSOURCE_NOISE2ND
    #define GEOMETRY_NOISE_MACRO noise2nd_pos
    #define GEOMETRY_CENTER_MACRO (inp[0].noise2nd_pos+inp[1].noise2nd_pos+inp[2].noise2nd_pos)/3.0
    #define GEOMETRY_TIME_MACRO (_Time.x*_Noise2ndTimeMulti+_Noise2ndTimePhase)
    #define GEOMETRY_AUDIOLINK_PHASE_MACRO NOISE2ND_AUDIOLINK_PHASE_MACRO

    #define GEOMETRY_FUNC_SEED_MACRO _Noise2ndSeed
    #define GEOMETRY_FUNC_VALUECARVE_MACRO _Noise2ndValueCurve
    #define GEOMETRY_FUNC_THRESHOLD_MUL_MACRO _Noise2ndThresholdMul
    #define GEOMETRY_FUNC_THRESHOLD_ADD_MACRO _Noise2ndThresholdAdd
    #define GEOMETRY_FUNC_PHASESCALE_MACRO _Noise2ndPhaseScale
    #define GEOMETRY_METHOD_NOISEMAP_MACRO(i,m) NOISE2NDMAP01_METHOD_MACRO(i,m)

#elif _GEOMETRYSOURCE_NOISE3RD
    #define GEOMETRY_NOISE_MACRO noise3rd_pos
    #define GEOMETRY_CENTER_MACRO (inp[0].noise3rd_pos+inp[1].noise3rd_pos+inp[2].noise3rd_pos)/3.0
    #define GEOMETRY_TIME_MACRO (_Time.x*_Noise3rdTimeMulti+_Noise3rdTimePhase)
    #define GEOMETRY_AUDIOLINK_PHASE_MACRO NOISE3RD_AUDIOLINK_PHASE_MACRO

    #define GEOMETRY_FUNC_SEED_MACRO _Noise3rdSeed
    #define GEOMETRY_FUNC_VALUECARVE_MACRO _Noise3rdValueCurve
    #define GEOMETRY_FUNC_THRESHOLD_MUL_MACRO _Noise3rdThresholdMul
    #define GEOMETRY_FUNC_THRESHOLD_ADD_MACRO _Noise3rdThresholdAdd
    #define GEOMETRY_FUNC_PHASESCALE_MACRO _Noise3rdPhaseScale
    #define GEOMETRY_METHOD_NOISEMAP_MACRO(i,m) NOISE3RDMAP01_METHOD_MACRO(i,m)
#else
    #define GEOMETRY_NOISE_MACRO _GeometryValue
    #define GEOMETRY_TIME_MACRO (0.0)
    #define GEOMETRY_AUDIOLINK_PHASE_MACRO (0.0)
#endif



#ifdef _ORBITSOURCE_NOISE1ST
    #define ORBIT_NOISE_MACRO noise1st_pos
    #define ORBIT_TIME_MACRO (_Time.x*_Noise1stTimeMulti+_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO*ORBIT_NOISE_AL_MASK_MACRO)

    #define ORBIT_FUNC_SEED_MACRO _Noise1stSeed
    #define ORBIT_FUNC_VALUECARVE_MACRO _Noise1stValueCurve
    #define ORBIT_FUNC_THRESHOLD_MUL_MACRO _Noise1stThresholdMul
    #define ORBIT_FUNC_THRESHOLD_ADD_MACRO _Noise1stThresholdAdd
    #define ORBIT_FUNC_PHASESCALE_MACRO _Noise1stPhaseScale
    #define ORBIT_METHOD_NOISEMAP_MACRO(i,m) NOISE1STMAP01_METHOD_MACRO(i,m)

#elif _ORBITSOURCE_NOISE2ND
    #define ORBIT_NOISE_MACRO noise2nd_pos
    #define ORBIT_TIME_MACRO (_Time.x*_Noise2ndTimeMulti+_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO*ORBIT_NOISE_AL_MASK_MACRO)

    #define ORBIT_FUNC_SEED_MACRO _Noise2ndSeed
    #define ORBIT_FUNC_VALUECARVE_MACRO _Noise2ndValueCurve
    #define ORBIT_FUNC_THRESHOLD_MUL_MACRO _Noise2ndThresholdMul
    #define ORBIT_FUNC_THRESHOLD_ADD_MACRO _Noise2ndThresholdAdd
    #define ORBIT_FUNC_PHASESCALE_MACRO _Noise2ndPhaseScale
    #define ORBIT_METHOD_NOISEMAP_MACRO(i,m) NOISE2NDMAP01_METHOD_MACRO(i,m)

#elif _ORBITSOURCE_NOISE3RD
    #define ORBIT_NOISE_MACRO noise3rd_pos
    #define ORBIT_TIME_MACRO (_Time.x*_Noise3rdTimeMulti+_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO*ORBIT_NOISE_AL_MASK_MACRO)

    #define ORBIT_FUNC_SEED_MACRO _Noise3rdSeed
    #define ORBIT_FUNC_VALUECARVE_MACRO _Noise3rdValueCurve
    #define ORBIT_FUNC_THRESHOLD_MUL_MACRO _Noise3rdThresholdMul
    #define ORBIT_FUNC_THRESHOLD_ADD_MACRO _Noise3rdThresholdAdd
    #define ORBIT_FUNC_PHASESCALE_MACRO _Noise3rdPhaseScale
    #define ORBIT_METHOD_NOISEMAP_MACRO(i,m) NOISE3RDMAP01_METHOD_MACRO(i,m)
#else
    #define ORBIT_TIME_MACRO 0.0
    #define ORBIT_NOISE_MACRO _OrbitValue
#endif

#ifdef _ORBITROTATIONSOURCE_NOISE1ST
    #define ORBITROTATION_NOISE_MACRO noise1st_pos
    #define ORBITROTATION_CENTER_MACRO (inp[0].noise1st_pos+inp[1].noise1st_pos+inp[2].noise1st_pos)/3.0
    #define ORBITROTATION_TIME_MACRO (_Time.x*_Noise1stTimeMulti+_Noise1stTimePhase+NOISE1ST_AUDIOLINK_PHASE_MACRO*ORBIT_ROTATION_NOISE_AL_MASK_MACRO)

    #define ORBITROTATION_FUNC_SEED_MACRO _Noise1stSeed
    #define ORBITROTATION_FUNC_VALUECARVE_MACRO _Noise1stValueCurve
    #define ORBITROTATION_FUNC_THRESHOLD_MUL_MACRO _Noise1stThresholdMul
    #define ORBITROTATION_FUNC_THRESHOLD_ADD_MACRO _Noise1stThresholdAdd
    #define ORBITROTATION_FUNC_PHASESCALE_MACRO _Noise1stPhaseScale
    #define ORBITROTATION_METHOD_NOISEMAP_MACRO(i,m) NOISE1STMAP01_METHOD_MACRO(i,m)

#elif _ORBITROTATIONSOURCE_NOISE2ND
    #define ORBITROTATION_NOISE_MACRO noise2nd_pos
    #define ORBITROTATION_CENTER_MACRO (inp[0].noise2nd_pos+inp[1].noise2nd_pos+inp[2].noise2nd_pos)/3.0
    #define ORBITROTATION_TIME_MACRO (_Time.x*_Noise2ndTimeMulti+_Noise2ndTimePhase+NOISE2ND_AUDIOLINK_PHASE_MACRO*ORBIT_ROTATION_NOISE_AL_MASK_MACRO)

    #define ORBITROTATION_FUNC_SEED_MACRO _Noise2ndSeed
    #define ORBITROTATION_FUNC_VALUECARVE_MACRO _Noise2ndValueCurve
    #define ORBITROTATION_FUNC_THRESHOLD_MUL_MACRO _Noise2ndThresholdMul
    #define ORBITROTATION_FUNC_THRESHOLD_ADD_MACRO _Noise2ndThresholdAdd
    #define ORBITROTATION_FUNC_PHASESCALE_MACRO _Noise2ndPhaseScale
    #define ORBITROTATION_METHOD_NOISEMAP_MACRO(i,m) NOISE2NDMAP01_METHOD_MACRO(i,m)

#elif _ORBITROTATIONSOURCE_NOISE3RD
    #define ORBITROTATION_NOISE_MACRO noise3rd_pos
    #define ORBITROTATION_CENTER_MACRO (inp[0].noise3rd_pos+inp[1].noise3rd_pos+inp[2].noise3rd_pos)/3.0
    #define ORBITROTATION_TIME_MACRO (_Time.x*_Noise3rdTimeMulti+_Noise3rdTimePhase+NOISE3RD_AUDIOLINK_PHASE_MACRO*ORBIT_ROTATION_NOISE_AL_MASK_MACRO)

    #define ORBITROTATION_FUNC_SEED_MACRO _Noise3rdSeed
    #define ORBITROTATION_FUNC_VALUECARVE_MACRO _Noise3rdValueCurve
    #define ORBITROTATION_FUNC_THRESHOLD_MUL_MACRO _Noise3rdThresholdMul
    #define ORBITROTATION_FUNC_THRESHOLD_ADD_MACRO _Noise3rdThresholdAdd
    #define ORBITROTATION_FUNC_PHASESCALE_MACRO _Noise3rdPhaseScale
    #define ORBITROTATION_METHOD_NOISEMAP_MACRO(i,m) NOISE3RDMAP01_METHOD_MACRO(i,m)
#else
    #define ORBITROTATION_TIME_MACRO 0.0
    #define ORBITROTATION_NOISE_MACRO 0.0
#endif

#define NOISE1STMAP01_METHOD_MACRO(i,m) EaseCurveValue(i,m,_Noise1stCurveType)
#define NOISE2NDMAP01_METHOD_MACRO(i,m) EaseCurveValue(i,m,_Noise2ndCurveType)
#define NOISE3RDMAP01_METHOD_MACRO(i,m) EaseCurveValue(i,m,_Noise3rdCurveType)

#ifdef _GEOMETRY_ROTATION_NOISE_REPEAT
    #define GEOMETRY_FUNC_NOISE_MACRO GeometryNoiseRepeat
#else
    #define GEOMETRY_FUNC_NOISE_MACRO GeometryNoisePingPong
#endif



#define NOISE1ST_OFFSET_CONTROL_VERTEX_MACRO CONTROL_MACRO3(_Noise1stOffsetControlTex,_point_repeat,_Noise1stOffsetControl,transform_uv[0],transform_uv[1],transform_uv[2])
#define NOISE1ST_OFFSET_CONTROL_SIDE_MACRO CONTROL_MACRO3(_Noise1stOffsetControlTex,_point_repeat,_Noise1stOffsetControl,uv_side[0],uv_side[1],uv_side[2])
#define NOISE1ST_OFFSET_CONTROL_MESH_MACRO CONTROL_MACRO(_Noise1stOffsetControlTex,_point_repeat,_Noise1stOffsetControl,uv_mesh)

#define NOISE2ND_OFFSET_CONTROL_VERTEX_MACRO CONTROL_MACRO3(_Noise2ndOffsetControlTex,_point_repeat,_Noise2ndOffsetControl,transform_uv[0],transform_uv[1],transform_uv[2])
#define NOISE2ND_OFFSET_CONTROL_SIDE_MACRO CONTROL_MACRO3(_Noise2ndOffsetControlTex,_point_repeat,_Noise2ndOffsetControl,uv_side[0],uv_side[1],uv_side[2])
#define NOISE2ND_OFFSET_CONTROL_MESH_MACRO CONTROL_MACRO(_Noise2ndOffsetControlTex,_point_repeat,_Noise2ndOffsetControl,uv_mesh)

#define NOISE3RD_OFFSET_CONTROL_VERTEX_MACRO CONTROL_MACRO3(_Noise3rdOffsetControlTex,_point_repeat,_Noise3rdOffsetControl,transform_uv[0],transform_uv[1],transform_uv[2])
#define NOISE3RD_OFFSET_CONTROL_SIDE_MACRO CONTROL_MACRO3(_Noise3rdOffsetControlTex,_point_repeat,_Noise3rdOffsetControl,uv_side[0],uv_side[1],uv_side[2])
#define NOISE3RD_OFFSET_CONTROL_MESH_MACRO CONTROL_MACRO(_Noise3rdOffsetControlTex,_point_repeat,_Noise3rdOffsetControl,uv_mesh)



#define NOISE1ST_AL_MASK_CONTROL_VERTEX_MACRO CONTROL_MACRO3(_Noise1stALMaskControlTex,_point_repeat,_Noise1stALMaskControl,transform_uv[0],transform_uv[1],transform_uv[2])
#define NOISE1ST_AL_MASK_CONTROL_SIDE_MACRO CONTROL_MACRO3(_Noise1stALMaskControlTex,_point_repeat,_Noise1stALMaskControl,uv_side[0],uv_side[1],uv_side[2])
#define NOISE1ST_AL_MASK_CONTROL_MESH_MACRO CONTROL_MACRO(_Noise1stALMaskControlTex,_point_repeat,_Noise1stALMaskControl,uv_mesh)

#define NOISE2ND_AL_MASK_CONTROL_VERTEX_MACRO CONTROL_MACRO3(_Noise2ndALMaskControlTex,_point_repeat,_Noise2ndALMaskControl,transform_uv[0],transform_uv[1],transform_uv[2])
#define NOISE2ND_AL_MASK_CONTROL_SIDE_MACRO CONTROL_MACRO3(_Noise2ndALMaskControlTex,_point_repeat,_Noise2ndALMaskControl,uv_side[0],uv_side[1],uv_side[2])
#define NOISE2ND_AL_MASK_CONTROL_MESH_MACRO CONTROL_MACRO(_Noise2ndALMaskControlTex,_point_repeat,_Noise2ndALMaskControl,uv_mesh)

#define NOISE3RD_AL_MASK_CONTROL_VERTEX_MACRO CONTROL_MACRO3(_Noise3rdALMaskControlTex,_point_repeat,_Noise3rdALMaskControl,transform_uv[0],transform_uv[1],transform_uv[2])
#define NOISE3RD_AL_MASK_CONTROL_SIDE_MACRO CONTROL_MACRO3(_Noise3rdALMaskControlTex,_point_repeat,_Noise3rdALMaskControl,uv_side[0],uv_side[1],uv_side[2])
#define NOISE3RD_AL_MASK_CONTROL_MESH_MACRO CONTROL_MACRO(_Noise3rdALMaskControlTex,_point_repeat,_Noise3rdALMaskControl,uv_mesh)