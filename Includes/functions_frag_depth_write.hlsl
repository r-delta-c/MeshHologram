fixed4 frag(g2f i):SV_Target{
    #include "Packages/com.deltafield.meshhologram/Includes/functions_frag.hlsl"
    #if defined(_PREVIEW_ENABLE)
        c.rgb = saturate(draw*c.rgb);
        c.a = 1.0;
    #else
        c.a = saturate((saturate(draw)*i.alpha*c.a));
    #endif

    c.rgb = saturate(c.rgb)*(max(0.0,_Emission)+1.0);

    clip(c.a>=0.5?0.0:-1.0);
    return c;
}
