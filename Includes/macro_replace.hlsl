#if defined(MESHHOLOGRAM_URP)
    #define REPLACE_DATA_INITIALIZE(type,o) ZERO_INITIALIZE(type,o)
    #define UNITY_LIGHTING_COORDS(i,j) //
#elif defined(MESHHOLOGRAM_HDRP)
    #define REPLACE_DATA_INITIALIZE(type,o) ZERO_INITIALIZE(type,o)
    #define UNITY_LIGHTING_COORDS(i,j) //

#else
    #define REPLACE_DATA_INITIALIZE(type,o) UNITY_INITIALIZE_OUTPUT(type,o)

#endif

