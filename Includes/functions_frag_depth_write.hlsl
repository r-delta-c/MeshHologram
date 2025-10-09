fixed4 frag(g2f i):SV_Target{
    #include "Packages/com.deltafield.meshhologram/Includes/functions_frag.hlsl"
    [branch]if(_PreviewEnable==0){
        c.a = saturate((saturate(draw)*i.alpha*c.a));
    }else{
        c.rgb = saturate(draw*c.rgb);
        c.a = 1.0;
    }

    c.rgb = saturate(c.rgb)*(max(0.0,_Emission)+1.0);

    clip(c.a>=0.5?0.0:-1.0);
    return c;
}
