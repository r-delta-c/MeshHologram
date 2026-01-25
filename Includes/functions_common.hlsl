float3 Pixelization(float3 inputs, float3 scale){
    float3 n = (_GeometryPixelization.xyz+_GeometryPixelization.w)*scale;
    return n > 0.0 ? floor((inputs+0.5*n)/n)*n : inputs;
}

float VertexCenterBias(float n0, float n1, float n, float c, float t){
    return lerp(lerp(n,c,min(0.5,t)*2.0),(n0+n1)*0.5,max(0.0,((t-0.5)*2.0)));
}

float2 VertexCenterBias(float2 uv0, float2 uv1, float2 uv, float2 c, float t){
    return lerp(lerp(uv,c,min(0.5,t)*2.0),(uv0+uv1)*0.5,max(0.0,((t-0.5)*2.0)));
}

float3 VertexCenterBias(float3 p0, float3 p1, float3 p, float3 c, float t){
    return lerp(lerp(p,c,min(0.5,t)*2.0),(p0+p1)*0.5,max(0.0,((t-0.5)*2.0)));
}

float ChangeValueRange02(float n, float t){
    return n*(2.0-abs(t))+max(0.0,t);
}

float3 RodriguesRotation(float3 rot, float theta, float3 axis){
    return rot*cos(theta) + cross(axis,rot)*sin(theta) + axis*dot(axis,rot)*(1.0-cos(theta));
}

float3 ThresholdFormula(float3 n, float mul, float add){
    return saturate(n*mul-mul*0.5+0.5+add*(mul+(mul>=0.0?1.0:-1.0)));
}

float Inverse12(float x, float r){
    return 1.0>mod(x,2.0)?r:-r+1.0;
}

float Texture3PosNoise(float3 p, Texture2D tex, float4 st){
    p.xy += p.z;
    p.xy = p.xy*st.xy+st.zw;
    return UNITY_SAMPLE_TEX2D_SAMPLER_LOD(tex, _linear_repeat, p.xy, 0.0);
}

float Texture3BlendNoise(float3 p, Texture2D tex, float4 st){
    p.xy = p.xy*st.xy+st.zw;
    float r0 = UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_ColoringLiteNoiseMap, _linear_repeat, p.xy, 0.0);
    float r1 = UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_ColoringLiteNoiseMap, _linear_repeat, p.yz, 0.0);
    float r2 = UNITY_SAMPLE_TEX2D_SAMPLER_LOD(_ColoringLiteNoiseMap, _linear_repeat, p.zx, 0.0);
    float2 t = min(1.0,float2(
        (r0-1.0)*(r0-1.0),
        (r1-1.0)*(r1-1.0)
    )+0.1);
    return lerp(r0,lerp(r1,r2,(t.y)),(t.x));
}

float EdgeCenterPos(float n0, float n1, float n, float2 c){
    return (n0+n1+VertexCenterBias(n0,n1,n,c,saturate(_FragmentTriangleCompression/26.0)*0.5+0.5))/3.0;
}

float2 EdgeCenterPos(float2 uv0, float2 uv1, float2 uv, float2 c){
    return (uv0+uv1+VertexCenterBias(uv0,uv1,uv,c,saturate(_FragmentTriangleCompression/26.0)*0.5+0.5))/3.0;
}

float3 EdgeCenterPos(float3 p0, float3 p1, float3 p, float3 c){
    return (p0+p1+VertexCenterBias(p0,p1,p,c,saturate(_FragmentTriangleCompression/26.0)*0.5+0.5))/3.0;
}