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

float GenNoise(float3 inputs, float offset, float time, float seed, float phasescale){
    return (ValueNoise3D(inputs,seed)+offset)*phasescale+time;
}


float EasingSelector(float i, float m, uint b){
    float r = 0.0;
    r += pow(i,m)*SELECTOR_MACRO(b,0);
    r += (1.0-pow(1.0-i,m))*SELECTOR_MACRO(b,1);
    r += EaseInOutPow(i,m)*SELECTOR_MACRO(b,2);
    r += EaseInOutPowInverse(i,m)*SELECTOR_MACRO(b,3);
    return r;
}

float3 EasingSelector(float3 i, float m, uint b){
    float3 r = 0.0;
    r += pow(i,m)*SELECTOR_MACRO(b,0);
    r += (1.0-pow(1.0-i,m))*SELECTOR_MACRO(b,1);
    r += EaseInOutPow(i,m)*SELECTOR_MACRO(b,2);
    r += EaseInOutPowInverse(i,m)*SELECTOR_MACRO(b,3);
    return r;
}

float SideCenterPos(float n0, float n1, float n, float2 c){
    return (n0+n1+VertexCenterBias(n0,n1,n,c,saturate(_FragmentTriangleCompression/26.0)*0.5+0.5))/3.0;
}

float2 SideCenterPos(float2 uv0, float2 uv1, float2 uv, float2 c){
    return (uv0+uv1+VertexCenterBias(uv0,uv1,uv,c,saturate(_FragmentTriangleCompression/26.0)*0.5+0.5))/3.0;
}

float3 SideCenterPos(float3 p0, float3 p1, float3 p, float3 c){
    return (p0+p1+VertexCenterBias(p0,p1,p,c,saturate(_FragmentTriangleCompression/26.0)*0.5+0.5))/3.0;
}