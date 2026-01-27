// DeltaField-Shader-Commons
//
// Copyright 2025 DeltaField
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#if defined(USING_STEREO_MATRICES)
    #ifdef _STEREOMERGEMODE_POSITION
        #define DEFINE_STEREO_MERGE_MATRIX_V BuildObjectMatrix(unity_MatrixV,(unity_StereoMatrixV[0]._m03_m13_m23+unity_StereoMatrixV[1]._m03_m13_m23)*0.5)

    #elif _STEREOMERGEMODE_ROTATION
        #define DEFINE_STEREO_MERGE_MATRIX_V BuildObjectMatrix(RMatAverage((float3x3)unity_StereoMatrixV[0],(float3x3)unity_StereoMatrixV[1]),(unity_MatrixV._m03_m13_m23))

    #elif _STEREOMERGEMODE_POSITION_ROTATION
        #define DEFINE_STEREO_MERGE_MATRIX_V BuildObjectMatrix(RMatAverage((float3x3)unity_StereoMatrixV[0],(float3x3)unity_StereoMatrixV[1]),(unity_StereoMatrixV[0]._m03_m13_m23+unity_StereoMatrixV[1]._m03_m13_m23)*0.5)

    #else
        #define DEFINE_STEREO_MERGE_MATRIX_V unity_MatrixV
    #endif

    #define CAMERA_DISTANCE_MACRO length((unity_StereoWorldSpaceCameraPos[0]+unity_StereoWorldSpaceCameraPos[1])*0.5-o.vertex.xyz)
#else
    #define DEFINE_STEREO_MERGE_MATRIX_V unity_MatrixV
    #define CAMERA_DISTANCE_MACRO length(_WorldSpaceCameraPos-o.vertex.xyz)
#endif

float mod(float x, float y){
    return x-y*floor(x/y);
}
float2 mod(float2 x, float y){
    return x-y*floor(x/y);
}
float3 mod(float3 x, float y){
    return x-y*floor(x/y);
}
float4 mod(float4 x, float y){
    return x-y*floor(x/y);
}

float triloop(float x){
    return abs(mod(x-1.0,2.0)-1.0);
}
float2 triloop(float2 x){
    return abs(mod(x-1.0,2.0)-1.0);
}
float3 triloop(float3 x){
    return abs(mod(x-1.0,2.0)-1.0);
}
float4 triloop(float4 x){
    return abs(mod(x-1.0,2.0)-1.0);
}


float InverseBias01(float x, float t){
    return x*t-(t-1.0)*0.5;
}

float EaseInOutPow(float x, float p){
    return x < 0.5 ? pow(x*2.0,p)*0.5 : 1.0-pow(x*-2.0+2.0,p)*0.5;
}
float2 EaseInOutPow(float2 x, float p){
    return x < 0.5 ? pow(x*2.0,p)*0.5 : 1.0-pow(x*-2.0+2.0,p)*0.5;
}
float3 EaseInOutPow(float3 x, float p){
    return x < 0.5 ? pow(x*2.0,p)*0.5 : 1.0-pow(x*-2.0+2.0,p)*0.5;
}
float4 EaseInOutPow(float4 x, float p){
    return x < 0.5 ? pow(x*2.0,p)*0.5 : 1.0-pow(x*-2.0+2.0,p)*0.5;
}

float EaseInvertInOutPow(float x, float p){
    return x > 0.5 ? pow(x*2.0-1.0,p)*0.5+0.5 : 1.0-pow(-x*2.0+1.0,p)*0.5-0.5;
}
float2 EaseInvertInOutPow(float2 x, float p){
    return x > 0.5 ? pow(x*2.0-1.0,p)*0.5+0.5 : 1.0-pow(-x*2.0+1.0,p)*0.5-0.5;
}
float3 EaseInvertInOutPow(float3 x, float p){
    return x > 0.5 ? pow(x*2.0-1.0,p)*0.5+0.5 : 1.0-pow(-x*2.0+1.0,p)*0.5-0.5;
}
float4 EaseInvertInOutPow(float4 x, float p){
    return x > 0.5 ? pow(x*2.0-1.0,p)*0.5+0.5 : 1.0-pow(-x*2.0+1.0,p)*0.5-0.5;
}

float EasePowInOutBias(float x, float p){
    x = saturate(x);
    float r0 = 1.0-pow(1.0-x,abs(p+1.0));
    float r1 = pow(x,abs(p-1.0));
    return p>0.0?r0:r1;
}

float random(float2 uv){
    return frac(sin(dot(uv.xy,float2(12.9898,78.233))) * 43758.5453123);
}

float hash3D(float3 inputs){
    inputs = frac(inputs*0.3183099+float3(0.1,0.3,0.7));
    inputs *= 17.0;
    return frac(inputs.x*inputs.y*inputs.z*(inputs.x+inputs.y+inputs.z));
}

float ValueNoise3D(float3 inputs, float seed){
    float3 i = floor(inputs);
    float3 f = frac(inputs);

    float rand000 = hash3D(i+float3(0.0,0.0,0.0)+seed);
    float rand100 = hash3D(i+float3(1.0,0.0,0.0)+seed);
    float rand010 = hash3D(i+float3(0.0,1.0,0.0)+seed);
    float rand110 = hash3D(i+float3(1.0,1.0,0.0)+seed);
    float rand001 = hash3D(i+float3(0.0,0.0,1.0)+seed);
    float rand101 = hash3D(i+float3(1.0,0.0,1.0)+seed);
    float rand011 = hash3D(i+float3(0.0,1.0,1.0)+seed);
    float rand111 = hash3D(i+float3(1.0,1.0,1.0)+seed);

    float3 t = smoothstep(0.0,1.0,f);
    float x00 = lerp(rand000,rand100,t.x);
    float x10 = lerp(rand010,rand110,t.x);
    float x01 = lerp(rand001,rand101,t.x);
    float x11 = lerp(rand011,rand111,t.x);
    float y0  = lerp(x00,x10,t.y);
    float y1  = lerp(x01,x11,t.y);

    return lerp(y0,y1,t.z);
}

float4x4 BuildObjectMatrix(float3x3 m, float3 offset){
    return float4x4(
        m[0],offset.x,
        m[1],offset.y,
        m[2],offset.z,
        0.0,0.0,0.0,1.0
    );
}

float3x3 RMatAverage(float3x3 ma, float3x3 mb){
    float3 y;
    float3 z;
    #if SHADER_TARGET_GLSL
        y = (ma._m01_m11_m21 + mb._m01_m11_m21)*0.5;
        z = (ma._m02_m12_m22 + mb._m02_m12_m22)*0.5;
    #else
        y = (ma[1] + mb[1])*0.5;
        z = (ma[2] + mb[2])*0.5;
    #endif
    float3 x = normalize(cross(y,z));
    z = normalize(z);
    y = cross(z,x);
    x = -x;

    #if SHADER_TARGET_GLSL
        return float3x3(
            x[0],y[0],z[0],
            x[1],y[1],z[1],
            x[2],y[2],z[2]
            );
    #else
        return float3x3(x,y,z);
    #endif
}

