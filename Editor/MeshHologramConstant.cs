#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static class MeshHologramConstant
    {
        public static string resolve_path { get; private set; }
        public static UnityEditor.PackageManager.PackageInfo packageInfo { get; private set; }
        public static string shader_base_path { get; private set; }
        public static string shader_keyword_path { get; private set; }

        [InitializeOnLoadMethod]
        private static void WaitForPackage()
        {
            EditorApplication.update += CheckPackageInfo;
        }

        private static void CheckPackageInfo()
        {
            packageInfo = UnityEditor.PackageManager.PackageInfo.FindForAssetPath("Packages/com.deltafield.meshhologram");
            if (packageInfo != null)
            {
                resolve_path = packageInfo.resolvedPath.Replace("\\","/");
                shader_base_path = resolve_path+"/Editor/temp/base.dfshader";
                shader_keyword_path = resolve_path+"/Editor/temp/keywords.dfshader";
                EditorApplication.update -= CheckPackageInfo;
            }
        }

        public static readonly MeshHologramCommonProps FragmentCommonPropIDs = new MeshHologramCommonProps(
            MAIN_CATEGORY.FRAGMENT,
            new MeshHologramSourceProps(
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_FIXED_VALUE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_OFFSET0,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_SCALE0,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_OFFSET1,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_SCALE1,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_OFFSET_BEFORE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_SPACE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_SEED,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_TIME_SPEED,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_TIME_PHASE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_NOISE_VALUE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_LITE_NOISE_MAP,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_LITE_NOISE_MAP_ST
            ),
            new MeshHologramAudioLinkProps(
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_VU_BAND,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_VU_SMOOTHING,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_VU_PANNING,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_VU_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_MODE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_BAND,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_SPECTRUM_MIRROR,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_SPECTRUM_STRENGTH
            ),
            new MeshHologramMaskOffsetProps(
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MASK_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_OFFSET_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_OFFSET_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_OFFSET_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_MASK_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_AUDIOLINK_MASK_CONTROL
            ),
            new MeshHologramModifierProps(
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_PHASE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_EASE_MODE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_EASE_CURVE,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MID_MUL,
                MESHHOLOGRAM_PROP_ENUM._FRAGMENT_MID_ADD
            )
        );

        public static readonly MeshHologramCommonProps ColorCommonPropIDs = new MeshHologramCommonProps(
            MAIN_CATEGORY.COLOR,
            new MeshHologramSourceProps(
                MESHHOLOGRAM_PROP_ENUM._COLORING_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_FIXED_VALUE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_OFFSET0,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_SCALE0,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_OFFSET1,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_SCALE1,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_OFFSET_BEFORE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_SPACE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_SEED,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_TIME_SPEED,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_TIME_PHASE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_NOISE_VALUE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_LITE_NOISE_MAP,
                MESHHOLOGRAM_PROP_ENUM._COLORING_LITE_NOISE_MAP_ST
            ),
            new MeshHologramAudioLinkProps(
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_VU_BAND,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_VU_SMOOTHING,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_VU_PANNING,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_VU_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_CHRONO_TENSITY_MODE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_CHRONO_TENSITY_BAND,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_SPECTRUM_MIRROR,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_SPECTRUM_STRENGTH
            ),
            new MeshHologramMaskOffsetProps(
                MESHHOLOGRAM_PROP_ENUM._COLORING_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._COLORING_MASK_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._COLORING_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._COLORING_OFFSET_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._COLORING_OFFSET_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._COLORING_OFFSET_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_MASK_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._COLORING_AUDIOLINK_MASK_CONTROL
            ),
            new MeshHologramModifierProps(
                MESHHOLOGRAM_PROP_ENUM._COLORING_PHASE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_EASE_MODE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_EASE_CURVE,
                MESHHOLOGRAM_PROP_ENUM._COLORING_MID_MUL,
                MESHHOLOGRAM_PROP_ENUM._COLORING_MID_ADD
            )
        );

        public static readonly MeshHologramCommonProps GeometryCommonPropIDs = new MeshHologramCommonProps(
            MAIN_CATEGORY.GEOMETRY,
            new MeshHologramSourceProps(
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_FIXED_VALUE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_OFFSET0,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_SCALE0,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_OFFSET1,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_SCALE1,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_OFFSET_BEFORE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_SPACE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_SEED,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_TIME_SPEED,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_TIME_PHASE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_NOISE_VALUE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_LITE_NOISE_MAP,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_LITE_NOISE_MAP_ST
            ),
            new MeshHologramAudioLinkProps(
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_VU_BAND,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_VU_SMOOTHING,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_VU_PANNING,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_VU_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_MODE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_BAND,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_SPECTRUM_MIRROR,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_SPECTRUM_STRENGTH
            ),
            new MeshHologramMaskOffsetProps(
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_MASK_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_OFFSET_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_OFFSET_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_OFFSET_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_MASK_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_AUDIOLINK_MASK_CONTROL
            ),
            new MeshHologramModifierProps(
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_PHASE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_EASE_MODE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_EASE_CURVE,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_MID_MUL,
                MESHHOLOGRAM_PROP_ENUM._GEOMETRY_MID_ADD
            )
        );

        public static readonly MeshHologramCommonProps OrbitCommonPropIDs = new MeshHologramCommonProps(
            MAIN_CATEGORY.ORBIT,
            new MeshHologramSourceProps(
                MESHHOLOGRAM_PROP_ENUM._ORBIT_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_FIXED_VALUE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_OFFSET0,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_SCALE0,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_OFFSET1,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_SCALE1,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_OFFSET_BEFORE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_SPACE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_SEED,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_TIME_SPEED,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_TIME_PHASE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_NOISE_VALUE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_LITE_NOISE_MAP,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_LITE_NOISE_MAP_ST
            ),
            new MeshHologramAudioLinkProps(
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_VU_BAND,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_VU_SMOOTHING,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_VU_PANNING,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_VU_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_CHRONO_TENSITY_MODE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_CHRONO_TENSITY_BAND,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_CHRONO_TENSITY_STRENGTH,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_SPECTRUM_MIRROR,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_SPECTRUM_STRENGTH
            ),
            new MeshHologramMaskOffsetProps(
                MESHHOLOGRAM_PROP_ENUM._ORBIT_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_MASK_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_OFFSET_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_OFFSET_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_OFFSET_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_MASK_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_AUDIOLINK_MASK_CONTROL
            ),
            new MeshHologramModifierProps(
                MESHHOLOGRAM_PROP_ENUM._ORBIT_PHASE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_LOOP_MODE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_EASE_MODE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_EASE_CURVE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_MID_MUL,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_MID_ADD
            )
        );

        public static readonly MeshHologramCommonProps OrbitRotationCommonPropIDs = new MeshHologramCommonProps(
            MAIN_CATEGORY.ORBIT_ROTATION,
            new MeshHologramSourceProps(
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_SOURCE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_FIXED_VALUE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_OFFSET0,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_SCALE0,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_OFFSET1,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_SCALE1,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_OFFSET_BEFORE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_SPACE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_SEED,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_TIME_SPEED,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_TIME_PHASE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_NOISE_VALUE_SCALE,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_LITE_NOISE_MAP,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_LITE_NOISE_MAP_ST
            ),
            new MeshHologramAudioLinkProps(
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY
            ),
            new MeshHologramMaskOffsetProps(
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_MASK_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_MASK_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_MASK_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_CONTROL_TEX,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_CONTROL_TEX_ST,
                MESHHOLOGRAM_PROP_ENUM._ORBIT_ROTATION_OFFSET_CONTROL,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY
            ),
            new MeshHologramModifierProps(
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY,
                MESHHOLOGRAM_PROP_ENUM._DUMMY
            )
        );

        public const string built_in_temp = 
            "Shader \"DeltaField/shaders/write_test\"{ \n"+
            "   Properties{}\n"+
            "   SubShader{\n"+
            "       Pass{\n"+
            "           Name \"Built-in\"\n"+
            "           Tags{ \"RenderType\"=\"Opaque\" \"Queue\"=\"Geometry\"}\n"+
            "           Cull [_Cull]\n"+
            "           ZWrite On\n"+
            "           HLSLPROGRAM\n"+
            "           #pragma vertex vert\n"+
            "           #pragma fragment frag\n"+
            "           #include \"UnityCG.cginc\"\n"+
            "           struct appdata{float4 vertex : POSITION;};\n"+
            "           struct v2f{float4 vertex : SV_POSITION;};\n"+
            "           v2f vert (appdata v){\n"+
            "               v2f o;\n"+
            "               o.vertex = UnityObjectToClipPos(v.vertex);\n"+
            "               return o;\n"+
            "           }\n"+
            "           fixed4 frag (v2f i) : SV_Target{\n"+
            "               return fixed4(0.0,1.0,0.0,1.0);\n"+
            "           }\n"+
            "           ENDHLSL\n"+
            "       }\n"+
            "   }\n"+
            "}";

        public const string urp_temp = 
            "Shader \"DeltaField/shaders/write_test\"{ \n"+
            "   Properties{}\n"+
            "   SubShader{\n"+
            "       Pass{\n"+
            "           Name \"URP\"\n"+
            "           Tags{ \"RenderType\"=\"Opaque\" \"Queue\"=\"Geometry\"}\n"+
            "           Cull [_Cull]\n"+
            "           ZWrite On\n"+
            "           HLSLPROGRAM\n"+
            "           #pragma vertex vert\n"+
            "           #pragma fragment frag\n"+
            "           #include \"UnityCG.cginc\"\n"+
            "           struct appdata{float4 vertex : POSITION;};\n"+
            "           struct v2f{float4 vertex : SV_POSITION;};\n"+
            "           v2f vert (appdata v){\n"+
            "               v2f o;\n"+
            "               o.vertex = UnityObjectToClipPos(v.vertex);\n"+
            "               return o;\n"+
            "           }\n"+
            "           fixed4 frag (v2f i) : SV_Target{\n"+
            "               return fixed4(0.0,1.0,0.0,1.0);\n"+
            "           }\n"+
            "           ENDHLSL\n"+
            "       }\n"+
            "   }\n"+
            "}";

    }
}

#endif