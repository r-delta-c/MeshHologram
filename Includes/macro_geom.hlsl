#define FUNC_GEOMETRY_PROCESS(value,fixed_value,source,n1st,n2nd,n3rd,mask,offset) \
    value += fixed_value*SELECTOR_MACRO(source,0); \
    value += n1st*SELECTOR_MACRO(source,1); \
    value += n2nd*SELECTOR_MACRO(source,2); \
    value += n3rd*SELECTOR_MACRO(source,3); \
    value *= mask; \
    value += offset;

#define FUNC_GEOMETRY_AUDIOLINK_PROCESS(value,al_mask,source,vu_add,chrono,spectrum,mirror,type) \
    value += audiolink_vu*vu_add*al_mask*SELECTOR_MACRO(source,1); \
    value = lerp(value,value*audiolink_vu*al_mask,SELECTOR_MACRO(source,2)); \
    value += audiolink_chronotensity*chrono*al_mask*SELECTOR_MACRO(source,3); \
    value = lerp(value,MeshHAudioLinkSpectrum(value,mirror,type),SELECTOR_MACRO(source,4)*al_mask)*spectrum;

#define FUNC_GEOMETRY_MODIFIER_PROCESS(value,phasescale,loopmode,mul,add,curve,easemode) \
    value *= phasescale; \
    value = lerp(value,mod(value,1.0),SELECTOR_MACRO(loopmode,1)); \
    value = lerp(value,triloop(value),SELECTOR_MACRO(loopmode,2)); \
    value = ThresholdFormula(value,mul,add); \
    value = EasingSelector(value,curve,easemode);



#if defined(_FRAGMENTPARTITIONTYPE_VERTEX)
    #define REPLACE_FRAGMENT_NOISE1ST_PARTITION noise1st_vertex_value
    #define REPLACE_FRAGMENT_NOISE2ND_PARTITION noise2nd_vertex_value
    #define REPLACE_FRAGMENT_NOISE3RD_PARTITION noise3rd_vertex_value
#elif defined(_FRAGMENTPARTITIONTYPE_SIDE)
    #define REPLACE_FRAGMENT_NOISE1ST_PARTITION noise1st_side_value
    #define REPLACE_FRAGMENT_NOISE2ND_PARTITION noise2nd_side_value
    #define REPLACE_FRAGMENT_NOISE3RD_PARTITION noise3rd_side_value
#elif defined(_FRAGMENTPARTITIONTYPE_MESH)
    #define REPLACE_FRAGMENT_NOISE1ST_PARTITION noise1st_mesh_value
    #define REPLACE_FRAGMENT_NOISE2ND_PARTITION noise2nd_mesh_value
    #define REPLACE_FRAGMENT_NOISE3RD_PARTITION noise3rd_mesh_value
#endif

#if defined(_COLORINGPARTITIONTYPE_VERTEX)
    #define REPLACE_COLORING_NOISE1ST_PARTITION noise1st_vertex_value
    #define REPLACE_COLORING_NOISE2ND_PARTITION noise2nd_vertex_value
    #define REPLACE_COLORING_NOISE3RD_PARTITION noise3rd_vertex_value
#elif defined(_COLORINGPARTITIONTYPE_SIDE)
    #define REPLACE_COLORING_NOISE1ST_PARTITION noise1st_side_value
    #define REPLACE_COLORING_NOISE2ND_PARTITION noise2nd_side_value
    #define REPLACE_COLORING_NOISE3RD_PARTITION noise3rd_side_value
#elif defined(_COLORINGPARTITIONTYPE_MESH)
    #define REPLACE_COLORING_NOISE1ST_PARTITION noise1st_mesh_value
    #define REPLACE_COLORING_NOISE2ND_PARTITION noise2nd_mesh_value
    #define REPLACE_COLORING_NOISE3RD_PARTITION noise3rd_mesh_value
#endif

#define SELECTOR_MACRO(n,i) (max(0.0,1.0-abs(n-i)))