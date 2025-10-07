#if defined(_NOISE1STSPACE_OFFSET)
    #define NOISE1ST_POS_MACRO REPLACE_SPACE_OFFSET_MACRO(_Noise1stOffset0,_Noise1stScale0)
#elif defined(_NOISE1STSPACE_ORIGIN_WORLD)
    #define NOISE1ST_POS_MACRO REPLACE_SPACE_ORIGIN_WORLD_MACRO(_Noise1stOffset0,_Noise1stScale0)
#else
    #if defined(_NOISE1ST_OFFSET_BEFORE_SCALE)
        #if defined(_NOISE1STSPACE_MODEL)
            #define NOISE1ST_POS_MACRO REPLACE_SPACE_MODEL_1_MACRO(_Noise1stOffset0,_Noise1stScale0)
        #elif defined(_NOISE1STSPACE_WORLD)
            #define NOISE1ST_POS_MACRO REPLACE_SPACE_WORLD_1_MACRO(_Noise1stOffset0,_Noise1stScale0)
        #elif defined(_NOISE1STSPACE_MODEL_WORLD)
            #define NOISE1ST_POS_MACRO REPLACE_SPACE_MODEL_WORLD_1_MACRO(_Noise1stOffset0,_Noise1stScale0,_Noise1stOffset1,_Noise1stScale1)
        #elif defined(_NOISE1STSPACE_VERTEXCOLOR)
            #define NOISE1ST_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_1_MACRO(_Noise1stOffset0,_Noise1stScale0)
        #else
            #define NOISE1ST_POS_MACRO 0.0
        #endif
    #else
        #if defined(_NOISE1STSPACE_MODEL)
            #define NOISE1ST_POS_MACRO REPLACE_SPACE_MODEL_0_MACRO(_Noise1stOffset0,_Noise1stScale0)
        #elif defined(_NOISE1STSPACE_WORLD)
            #define NOISE1ST_POS_MACRO REPLACE_SPACE_WORLD_0_MACRO(_Noise1stOffset0,_Noise1stScale0)
        #elif defined(_NOISE1STSPACE_MODEL_WORLD)
            #define NOISE1ST_POS_MACRO REPLACE_SPACE_MODEL_WORLD_0_MACRO(_Noise1stOffset0,_Noise1stScale0,_Noise1stOffset1,_Noise1stScale1)
        #elif defined(_NOISE1STSPACE_VERTEXCOLOR)
            #define NOISE1ST_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_0_MACRO(_Noise1stOffset0,_Noise1stScale0)
        #else
            #define NOISE1ST_POS_MACRO 0.0
        #endif
    #endif
#endif



#if defined(_NOISE2NDSPACE_OFFSET)
    #define NOISE2ND_POS_MACRO REPLACE_SPACE_OFFSET_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
#elif defined(_NOISE2NDSPACE_ORIGIN_WORLD)
    #define NOISE2ND_POS_MACRO REPLACE_SPACE_ORIGIN_WORLD_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
#else
    #if defined(_NOISE2ND_OFFSET_BEFORE_SCALE)
        #if defined(_NOISE2NDSPACE_MODEL)
            #define NOISE2ND_POS_MACRO REPLACE_SPACE_MODEL_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
        #elif defined(_NOISE2NDSPACE_WORLD)
            #define NOISE2ND_POS_MACRO REPLACE_SPACE_WORLD_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
        #elif defined(_NOISE2NDSPACE_MODEL_WORLD)
            #define NOISE2ND_POS_MACRO REPLACE_SPACE_MODEL_WORLD_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0,_Noise2ndOffset1,_Noise2ndScale1)
        #elif defined(_NOISE2NDSPACE_VERTEXCOLOR)
            #define NOISE2ND_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_1_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
        #else
            #define NOISE2ND_POS_MACRO 0.0
        #endif
    #else
        #if defined(_NOISE2NDSPACE_MODEL)
            #define NOISE2ND_POS_MACRO REPLACE_SPACE_MODEL_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
        #elif defined(_NOISE2NDSPACE_WORLD)
            #define NOISE2ND_POS_MACRO REPLACE_SPACE_WORLD_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
        #elif defined(_NOISE2NDSPACE_MODEL_WORLD)
            #define NOISE2ND_POS_MACRO REPLACE_SPACE_MODEL_WORLD_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0,_Noise2ndOffset1,_Noise2ndScale1)
        #elif defined(_NOISE2NDSPACE_VERTEXCOLOR)
            #define NOISE2ND_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_0_MACRO(_Noise2ndOffset0,_Noise2ndScale0)
        #else
            #define NOISE2ND_POS_MACRO 0.0
        #endif
    #endif
#endif



#if defined(_NOISE3RDSPACE_OFFSET)
    #define NOISE3RD_POS_MACRO REPLACE_SPACE_OFFSET_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
#elif defined(_NOISE3RDSPACE_ORIGIN_WORLD)
    #define NOISE3RD_POS_MACRO REPLACE_SPACE_ORIGIN_WORLD_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
#else
    #if defined(_NOISE3RD_OFFSET_BEFORE_SCALE)
        #if defined(_NOISE3RDSPACE_MODEL)
            #define NOISE3RD_POS_MACRO REPLACE_SPACE_MODEL_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
        #elif defined(_NOISE3RDSPACE_WORLD)
            #define NOISE3RD_POS_MACRO REPLACE_SPACE_WORLD_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
        #elif defined(_NOISE3RDSPACE_MODEL_WORLD)
            #define NOISE3RD_POS_MACRO REPLACE_SPACE_MODEL_WORLD_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0,_Noise3rdOffset1,_Noise3rdScale1)
        #elif defined(_NOISE3RDSPACE_VERTEXCOLOR)
            #define NOISE3RD_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_1_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
        #else
            #define NOISE3RD_POS_MACRO 0.0
        #endif
    #else
        #if defined(_NOISE3RDSPACE_MODEL)
            #define NOISE3RD_POS_MACRO REPLACE_SPACE_MODEL_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
        #elif defined(_NOISE3RDSPACE_WORLD)
            #define NOISE3RD_POS_MACRO REPLACE_SPACE_WORLD_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
        #elif defined(_NOISE3RDSPACE_MODEL_WORLD)
            #define NOISE3RD_POS_MACRO REPLACE_SPACE_MODEL_WORLD_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0,_Noise3rdOffset1,_Noise3rdScale1)
        #elif defined(_NOISE3RDSPACE_VERTEXCOLOR)
            #define NOISE3RD_POS_MACRO REPLACE_SPACE_VERTEXCOLOR_0_MACRO(_Noise3rdOffset0,_Noise3rdScale0)
        #else
            #define NOISE3RD_POS_MACRO 0.0
        #endif
    #endif
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

#if defined(_GEOMETRY_ROTATION_NOISE_REPEAT)
    #define GEOMETRY_FUNC_NOISE_MACRO GeometryNoiseRepeat
#else
    #define GEOMETRY_FUNC_NOISE_MACRO GeometryNoisePingPong
#endif
