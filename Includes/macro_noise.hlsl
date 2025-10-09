#define NOISE_SPACE_POS_MACRO(r,space,before_scaling,offset0,offset1,scale0,scale1) \
    [branch]switch(space){ \
        default: \
            r = offset0*scale0.xyz*scale0.w; \
            break; \
        case 1: \
            [flatten]if(before_scaling==0){ \
                r = ((v.pos.xyz+offset0)*scale0.xyz*scale0.w); \
            }else{ \
                r = (v.pos.xyz*scale0.xyz*scale0.w+offset0); \
            } \
            break; \
        case 2: \
            [flatten]if(before_scaling==0){ \
                r = ((o.pos.xyz+offset0)*scale0.xyz*scale0.w); \
            }else{ \
                r = (o.pos.xyz*scale0.xyz*scale0.w+offset0); \
            } \
            break; \
        case 3: \
            r = (mul(UNITY_MATRIX_M,float4(offset0.xyz,1.0)).xyz*scale0.xyz*scale0.w); \
            break; \
        case 4: \
            [flatten]if(before_scaling==0){ \
                r = ((v.pos.xyz+offset0.xyz)*scale0.xyz*scale0.w+(o.pos.xyz+offset1.xyz)*scale1.xyz*scale1.w); \
            }else{ \
                r = ((v.pos.xyz*scale0.xyz*scale0.w+offset0.xyz)+(o.pos.xyz*scale1.xyz*scale1.w+offset1.xyz)); \
            } \
            break; \
        case 5: \
            [flatten]if(before_scaling==0){ \
                r = ((v.color.xyz+offset0.xyz)*scale0.xyz*scale0.w); \
            }else{ \
                r = (v.color.xyz*scale0.xyz*scale0.w+offset0.xyz); \
            } \
            break; \
    }
