#define FUNC_GEOMETRY_PROCESS(value,fixed_value,source,n1st,n2nd,n3rd,mask,offset) \
    if(source==0) value = fixed_value; \
    if(source==1) value = n1st; \
    if(source==2) value = n2nd; \
    if(source==3) value = n3rd; \
    value *= mask; \
    value += offset;

#if defined(_AUDIOLINK_ENABLE)
    #define FUNC_GEOMETRY_AUDIOLINK_PROCESS(value,al_mask,source,vu_add,chrono,spectrum,mirror,type) \
        if(source==1) value += audiolink_vu*vu_add*al_mask; \
        if(source==2) value = value*audiolink_vu*al_mask; \
        if(source==3) value += audiolink_chronotensity*chrono*al_mask; \
        if(source==4) value = MeshHAudioLinkSpectrum(value,mirror,type)*al_mask*spectrum;
#else
    #define FUNC_GEOMETRY_AUDIOLINK_PROCESS(value,al_mask,source,vu_add,chrono,spectrum,mirror,type) //
#endif

#define FUNC_GEOMETRY_MODIFIER_PROCESS(value,phasescale,loopmode,mul,add,curve,easemode) \
    value *= phasescale; \
    if(loopmode==1) value = mod(value,1.0); \
    if(loopmode==2) value = triloop(value); \
    value = ThresholdFormula(value,mul,add); \
    value = EasingSelector(value,curve,easemode);



#if defined(_FRAGMENTPARTITIONMODE_VERTEX)
    #define REPLACE_FRAGMENT_NOISE1ST_PARTITION noise1st_vertex_value
    #define REPLACE_FRAGMENT_NOISE2ND_PARTITION noise2nd_vertex_value
    #define REPLACE_FRAGMENT_NOISE3RD_PARTITION noise3rd_vertex_value
#elif defined(_FRAGMENTPARTITIONMODE_SIDE)
    #define REPLACE_FRAGMENT_NOISE1ST_PARTITION noise1st_side_value
    #define REPLACE_FRAGMENT_NOISE2ND_PARTITION noise2nd_side_value
    #define REPLACE_FRAGMENT_NOISE3RD_PARTITION noise3rd_side_value
#elif defined(_FRAGMENTPARTITIONMODE_MESH)
    #define REPLACE_FRAGMENT_NOISE1ST_PARTITION noise1st_mesh_value
    #define REPLACE_FRAGMENT_NOISE2ND_PARTITION noise2nd_mesh_value
    #define REPLACE_FRAGMENT_NOISE3RD_PARTITION noise3rd_mesh_value
#endif

#if defined(_COLORINGPARTITIONMODE_VERTEX)
    #define REPLACE_COLORING_NOISE1ST_PARTITION noise1st_vertex_value
    #define REPLACE_COLORING_NOISE2ND_PARTITION noise2nd_vertex_value
    #define REPLACE_COLORING_NOISE3RD_PARTITION noise3rd_vertex_value
#elif defined(_COLORINGPARTITIONMODE_SIDE)
    #define REPLACE_COLORING_NOISE1ST_PARTITION noise1st_side_value
    #define REPLACE_COLORING_NOISE2ND_PARTITION noise2nd_side_value
    #define REPLACE_COLORING_NOISE3RD_PARTITION noise3rd_side_value
#elif defined(_COLORINGPARTITIONMODE_MESH)
    #define REPLACE_COLORING_NOISE1ST_PARTITION noise1st_mesh_value
    #define REPLACE_COLORING_NOISE2ND_PARTITION noise2nd_mesh_value
    #define REPLACE_COLORING_NOISE3RD_PARTITION noise3rd_mesh_value
#endif

#define SELECTOR_MACRO(n,i) (max(0.0,1.0-abs(n-i)))