#if UNITY_EDITOR

using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static partial class MeshHologramManager
    {
        private const string target = "            #pragma target 4.0\n";

        private const string feature_main =
            "            Cull [_Cull]\n"+
            "            ZWrite [_ZWrite]\n"+
            "            BlendOp [_BlendOp], [_BlendOpAlpha]\n"+
            "            Blend [_SrcBlend] [_DstBlend], [_SrcBlendAlpha] [_DstBlendAlpha]\n"+
            "            ZClip [_ZClip]\n"+
            "            ZTest [_ZTest]\n"+
            "            ColorMask [_ColorMask]\n"+
            "            Offset [_OffsetFactor], [_OffsetUnits]\n"+
            "            AlphaToMask [_AlphaToMask]\n";

        private const string feature_shadowcaster = 
            "            Cull [_Cull]\n"+
            "            ZWrite On\n"+
            "            ZClip [_ZClip]\n"+
            "            ZTest [_ZTest]\n";

        private const string stencil =
            "            Stencil{\n"+
            "                Ref [_StencilRef]\n"+
            "                ReadMask [_StencilReadMask]\n"+
            "                WriteMask [_StencilWriteMask]\n"+
            "                Comp [_StencilComp]\n"+
            "                Pass [_StencilPass]\n"+
            "                Fail [_StencilFail]\n"+
            "                ZFail [_StencilZFail]\n"+
            "            }\n";

        private const string pragma_func = 
            "            #pragma vertex vert\n"+
            "            #pragma fragment frag\n"+
            "            #pragma geometry geom\n";

        private const string pragma_multi_compile_main =
            "            #pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight\n";
        private const string pragma_multi_compile_shadowcaster =
            "            #pragma multi_compile_shadowcaster\n";

        private const string define_builtin = 
            "            #define MESHHOLOGRAM_BUILTIN\n";
        private const string define_urp = 
            "            #define MESHHOLOGRAM_URP\n";
        private const string define_hdrp = 
            "            #define MESHHOLOGRAM_HDRP\n";

        private const string unity_include_urp = 
            "            #include \"Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl\"\n"+
            "            #include \"Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl\"\n";
        private const string unity_include_hdrp = 
            "            #include \"Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl\"\n"+
            "            #include \"Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl\"\n"+
            "            #include \"Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/EditorShaderVariables.hlsl\"\n";

        private const string unity_include_builtin = 
            "            #include \"UnityCG.cginc\"\n"+
            "            #include \"AutoLight.cginc\"\n";

        private const string includes =
            "            #include \"../Includes/macro_replace.hlsl\"\n"+

            "            #include \"../Includes/macro_general.hlsl\"\n"+
            "            #include \"../Includes/macro_noise.hlsl\"\n"+
            "            #include \"../Includes/macro_uv.hlsl\"\n"+
            "            #include \"../Includes/macro_geom.hlsl\"\n"+

            "            #include \"../Includes/Thirdparties/AudioLink.cginc\"\n"+
            "            #include \"../Includes/Thirdparties/LightVolumes.cginc\"\n"+
            "            #include \"../Includes/Thirdparties/DeltaField-Shader-Commons.hlsl\"\n"+

            "            #include \"../Includes/functions_common.hlsl\"\n"+
            "            #include \"../Includes/functions_thirdparties.hlsl\"\n"+
            "            #include \"../Includes/functions_noise.hlsl\"\n"+

            "            #include \"../Includes/structs.hlsl\"\n"+
            "            #include \"../Includes/functions_vert.hlsl\"\n"+
            "            #include \"../Includes/functions_geom.hlsl\"\n";

        private const string include_frag_shadowcaster = 
            "            #include \"../Includes/functions_frag_depth_write.hlsl\"\n";
        private const string include_frag_main = 
            "            half4 frag(g2f i) : SV_Target{\n"+
            "                #include \"../Includes/functions_frag.hlsl\"\n"+
            "                #include \"../Includes/functions_frag_mesh.hlsl\"\n"+
            "            }\n";

        private const string others_variable =
            "uniform half4 _LightColor0;\n"+
            "SamplerState _point_repeat;\n"+
            "SamplerState _linear_repeat;\n";

        public static (string,string) GeneratePropertyShaderCode()
        {
            string prop = "    Properties{\n", var = "";
            foreach(MESHHOLOGRAM_PROP_ENUM value in Enum.GetValues(typeof(MESHHOLOGRAM_PROP_ENUM)))
            {
                ShaderParameterAttribute meta = (ShaderParameterAttribute)typeof(MESHHOLOGRAM_PROP_ENUM).GetField(value.ToString()).GetCustomAttribute<Attribute>();
                prop += "        "+meta.GetPropertyCode()+"\n";
                var += meta.GetVariableCode()+"\n";
            }
            prop += "    }";
            return (prop,var);
        }

        public static string GenerateKeywordsShaderCode()
        {
            string code = "";
            foreach(string name in Enum.GetNames(typeof(MESHHOLOGRAM_KEYWORD_ENUM)))
            {
                MeshHologramKeywordMeta meta = typeof(MESHHOLOGRAM_KEYWORD_ENUM).GetField(name).GetCustomAttribute<MeshHologramKeywordMeta>();
                code += "            #pragma shader_feature_local "+String.Join(' ',meta.keywords)+"\n";
            }
            return code;
        }

        [MenuItem("Tools/DeltaField/_dev/Shader Code Generate")]
        public static void ShaderCodeGenerate()
        {
            (string,string) text = GeneratePropertyShaderCode();
            string shader_path = "Shader \"DeltaField/MeshHologram\"{\n";
            string shader_def_editor_path = "Shader DeltaField/MeshHologram_DisableCustomEditor{\n";
            string output = text.Item1+"\n    SubShader{\n";
            string output_var = "";

            switch (PipelineManager.pipeline)
            {
                case PIPELINE.URP:
                    output += "        Tags{\"Renderpipeline\"=\"UniversalPipeline\"}\n";
                    output += GeneratePassCode(
                        "ShadowCaster",
                        "Geometry","Opaque","ShadowCaster",
                        feature_shadowcaster,pragma_multi_compile_shadowcaster,
                        unity_include_urp,define_urp,true,
                        include_frag_shadowcaster
                    );
                    output += GeneratePassCode(
                        "MainRender",
                        "Transparent","Transparent","UniversalForward",
                        feature_main,pragma_multi_compile_main,
                        unity_include_urp,define_urp,true,
                        include_frag_main
                    );
                    break;
                case PIPELINE.HDRP:
                    output += "        Tags{\"Renderpipeline\"=\"HDRenderPipeline\"}\n";
                    output += GeneratePassCode(
                        "ShadowCaster",
                        "Geometry","Opaque","ShadowCaster",
                        feature_shadowcaster,pragma_multi_compile_shadowcaster,
                        unity_include_hdrp,define_hdrp,true,
                        include_frag_shadowcaster
                    );
                    output += GeneratePassCode(
                        "MainRender",
                        "Transparent","Transparent","Forward",
                        feature_main,pragma_multi_compile_main,
                        unity_include_hdrp,define_hdrp,true,
                        include_frag_main
                    );
                    break;
                default:
                    output += GeneratePassCode(
                        "ShadowCaster",
                        "Geometry","Opaque","ShadowCaster",
                        feature_shadowcaster,pragma_multi_compile_shadowcaster,
                        unity_include_builtin,define_builtin,false,
                        include_frag_shadowcaster
                    );
                    output += GeneratePassCode(
                        "MainRender",
                        "Transparent","Transparent","ForwardBase",
                        feature_main,pragma_multi_compile_main,
                        unity_include_builtin,define_builtin,false,
                        include_frag_main
                    );
                    break;
            }

            string GeneratePassCode(
                string name,
                string rendertype, string queue, string lightmode,
                string feature,
                string pragma_multi_compile,
                string unity_include,
                string define,
                bool enable_cbuffer,
                string include_frag
            )
            {
                string output = "";
                output += "        Pass{\n";
                output += "            Name \""+name+"\"\n";
                output += "            Tags{";
                output += GenerateTagCode("RenderType",rendertype);
                output += GenerateTagCode("Queue",queue);
                output += GenerateTagCode("LightMode",lightmode);
                output += "}\n";
                output += feature;
                output += stencil;
                output += "            HLSLPROGRAM\n";
                output += target;
                output += pragma_func;
                output += pragma_multi_compile;
                output += unity_include;
                output += GenerateKeywordsShaderCode()+"\n";
                output += define+"\n";
                if(enable_cbuffer) output += "            CBUFFER_START(UnityPerMaterial)\n";
                output += "            #include \"../Includes/variables.hlsl\"\n";
                if(enable_cbuffer) output += "            CBUFFER_END\n\n";
                output += includes;
                output += include_frag;
                output += "            ENDHLSL\n        }\n";
                return output;
            }

            string GenerateTagCode(string type, string value) => $"\"{type}\"=\"{value}\"";

            output += "    }\n";
            output += "    Fallback \"Mobile/Particle/Alpha Blended\"\n";

            string output1 = output;
            output += "    CustomEditor \"DeltaField.Shaders.MeshHologram.Editor.MeshHologramInspector\"\n"+"}";
            output1 += "}";
            output = shader_path+output;
            output1 = shader_def_editor_path+output1;
            output_var += text.Item2+"\n"+others_variable;

            using(StreamWriter file = new StreamWriter(MeshHologramConstant.resolve_path + "/Shaders/mesh_hologram.shader"))
            {
                file.NewLine = "\n";
                file.WriteLine(output);
            }
            using(StreamWriter file = new StreamWriter(MeshHologramConstant.resolve_path + "/Includes/variables.hlsl"))
            {
                file.NewLine = "\n";
                file.WriteLine(output_var);
            }
        }
    }
}

#endif