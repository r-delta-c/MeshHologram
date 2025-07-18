Shader "DeltaField/shaders/MeshHologram/bounds_guide"{
    Properties{}
    SubShader{
        Pass{
            Tags{ "RenderType"="Transparent" "Queue"="Transparent"}
            Blend SrcAlpha OneMinusSrcAlpha
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata{
                float4 vertex : POSITION;
            };

            struct v2f{
                float4 vertex : SV_POSITION;
            };
    
            v2f vert (appdata v){
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }
    
            fixed4 frag(v2f i):SV_Target{
                return fixed4(0.0,0.5,0.0,0.2);
            }
            ENDHLSL
        }
    }
}