float3 Pixelization(float3 inputs){
    float n = _Pixelization;
    return n > 0.0 ? floor((inputs+0.5*n)/n)*n : inputs;
}

float3 VertexCenterBias(float3 v0, float3 v1, float3 v, float3 c, float t){
    return lerp(lerp(v,c,min(0.5,t)*2.0),(v0+v1)*0.5,max(0.0,((t-0.5)*2.0)));
}

float ChangeValueRange02(float n, float t){
    return n*(2.0-abs(t))+max(0.0,t);
}
