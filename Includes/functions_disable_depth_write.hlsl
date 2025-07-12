struct appdata{
    float4 pos:POSITION;
};
struct v2f{
    float4 pos:SV_POSITION;
};
v2f vert(appdata v){
    v2f o;
    o.pos=v.pos;
    return o;
}
[maxvertexcount(3)]
void geom(triangle v2f i[3]){

}
fixed4 frag(v2f i):SV_Target{
    return 0;
}
