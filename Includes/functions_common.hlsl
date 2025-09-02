float3 Pixelization(float3 inputs, float3 scale){
    float3 n = (_Pixelization.xyz+_Pixelization.w)*scale;
    return n > 0.0 ? floor((inputs+0.5*n)/n)*n : inputs;
}

float3 VertexCenterBias(float3 v0, float3 v1, float3 v, float3 c, float t){
    return lerp(lerp(v,c,min(0.5,t)*2.0),(v0+v1)*0.5,max(0.0,((t-0.5)*2.0)));
}

float ChangeValueRange02(float n, float t){
    return n*(2.0-abs(t))+max(0.0,t);
}

float3 RodriguesRotation(float3 rot, float theta, float3 axis){
    return rot*cos(theta) + cross(axis,rot)*sin(theta) + axis*dot(axis,rot)*(1.0-cos(theta));
}

float ThresholdFormula(float n, float mul, float add){
    return saturate(n*mul-mul*0.5+0.5+add*(mul+(mul>=0.0?1.0:-1.0)));
}

float Inverse12(float x, float r){
    return 1.0>mod(x,2.0)?r:-r+1.0;
}

float GenNoise(float3 inputs, float offset, float time, float seed, float phasescale){
    return (ValueNoise3D(inputs,seed)+offset)*phasescale+time;
}

float EaseCurveValue(float i, float m, bool b){
    return b?EaseInOutPowInverse(i,m):EaseInOutPow(i,m);
}