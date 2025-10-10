#define NOISE_SPACE_POS_MACRO(r,space,before_scaling,offset0,offset1,scale0,scale1) \
    [branch]switch(space){ \
        default: \
            r = offset0*scale0.xyz*scale0.w; \
            break; \
        case 1: \
            r = lerp((v.pos.xyz+offset0)*scale0.xyz*scale0.w,v.pos.xyz*scale0.xyz*scale0.w+offset0,before_scaling); \
            break; \
        case 2: \
            r = lerp((o.pos.xyz+offset0)*scale0.xyz*scale0.w,o.pos.xyz*scale0.xyz*scale0.w+offset0,before_scaling); \
            break; \
        case 3: \
            r = (mul(UNITY_MATRIX_M,float4(offset0.xyz,1.0)).xyz*scale0.xyz*scale0.w); \
            break; \
        case 4: \
            r = lerp((v.pos.xyz+offset0.xyz)*scale0.xyz*scale0.w+(o.pos.xyz+offset1.xyz)*scale1.xyz*scale1.w,(v.pos.xyz*scale0.xyz*scale0.w+offset0.xyz)+(o.pos.xyz*scale1.xyz*scale1.w+offset1.xyz),before_scaling); \
            break; \
        case 5: \
            r = lerp((v.color.xyz+offset0.xyz)*scale0.xyz*scale0.w,v.color.xyz*scale0.xyz*scale0.w+offset0.xyz,before_scaling); \
            break; \
    }
