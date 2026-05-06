#if UNITY_EDITOR
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public partial class MeshHologramInspector : ShaderGUI
    {
        private static void UpdateTabLabels()
        {
            MenuLabels[0].text = LocalizationManager.GetLocalizeText("label.general");
            MenuLabels[1].text = LocalizationManager.GetLocalizeText("label.main");
            MenuLabels[2].text = LocalizationManager.GetLocalizeText("label.others");

            GeneralLabels[0].text = LocalizationManager.GetLocalizeText("label.rendering");
            GeneralLabels[1].text = LocalizationManager.GetLocalizeText("label.stencil");
            GeneralLabels[2].text = LocalizationManager.GetLocalizeText("label.audiolink");

            MainLabels[0].text = LocalizationManager.GetLocalizeText("label.fragment");
            MainLabels[1].text = LocalizationManager.GetLocalizeText("label.color");
            MainLabels[2].text = LocalizationManager.GetLocalizeText("label.geometry");
            MainLabels[3].text = LocalizationManager.GetLocalizeText("label.orbit");

            UpdateSubTabLabels();

            OrbitLabels[0].text = LocalizationManager.GetLocalizeText("label.orbit");
            OrbitLabels[1].text = LocalizationManager.GetLocalizeText("label.orbit_rotation");
            OrbitLabels[2].text = LocalizationManager.GetLocalizeText("label.orbit_wave");
            OrbitLabels[3].text = LocalizationManager.GetLocalizeText("label.orbit_rotation_offset");
        }

        private static void UpdateSubTabLabels()
        {
            if (MainIndex == 3)
            {
                switch (OrbitIndex)
                {
                    case 0:
                        SubLabels[0].text = LocalizationManager.GetLocalizeText("label.source");
                        SubLabels[1].text = LocalizationManager.GetLocalizeText("label.audiolink_source");
                        SubLabels[2].text = LocalizationManager.GetLocalizeText("label.mask_offset");
                        SubLabels[3].text = LocalizationManager.GetLocalizeText("label.modifiers");
                        break;
                    case 1:
                        SubLabels[0].text = LocalizationManager.GetLocalizeText("label.source");
                        SubLabels[1].text = "---";
                        SubLabels[2].text = LocalizationManager.GetLocalizeText("label.mask_offset");
                        SubLabels[3].text = "---";
                        break;
                    case 2:
                        SubLabels[0].text = "---";
                        SubLabels[1].text = LocalizationManager.GetLocalizeText("label.audiolink_source");
                        SubLabels[2].text = "---";
                        SubLabels[3].text = "---";
                        break;
                    case 3:
                        SubLabels[0].text = "---";
                        SubLabels[1].text = LocalizationManager.GetLocalizeText("label.audiolink_source");
                        SubLabels[2].text = LocalizationManager.GetLocalizeText("label.mask_offset");
                        SubLabels[3].text = "---";
                        break;
                    default:
                        SubLabels[0].text = "---";
                        SubLabels[1].text = "---";
                        SubLabels[2].text = "---";
                        SubLabels[3].text = "---";
                        break;
                }
            }
            else
            {
                SubLabels[0].text = LocalizationManager.GetLocalizeText("label.source");
                SubLabels[1].text = LocalizationManager.GetLocalizeText("label.audiolink_source");
                SubLabels[2].text = LocalizationManager.GetLocalizeText("label.mask_offset");
                SubLabels[3].text = LocalizationManager.GetLocalizeText("label.modifiers");
            }
        }

        private void PreviewGraph(float phase_scale, uint loop_mode, float mul, float add, uint ease_mode, float curve)
        {
            using (new EditorGUILayout.VerticalScope("HelpBox"))
            {
                PreviewGraph0 = new PreviewGraph(phase_scale, loop_mode, mul, add, ease_mode, curve);
            }
        }

        private void DrawShaderProperty(MESHHOLOGRAM_PROP_ENUM key)
        {
            editor.ShaderProperty(MeshHologramProps[key].var, MeshHologramProps[key].property);
        }

        private bool DrawKeywordToggle(MaterialKeyword keyword, bool isLeft = false)
        {
            ToggleKeyword data = keyword as ToggleKeyword;
            string label = LocalizationManager.GetLocalizeText(data.label);
            EditorGUI.showMixedValue = data.hasMixedValue;
            EditorGUI.BeginChangeCheck();
            if(isLeft) EditorGUILayout.ToggleLeft(label,data.value);
            else EditorGUILayout.Toggle(label,data.value);
            if(EditorGUI.EndChangeCheck()) data.apply = true;
            EditorGUI.showMixedValue = true;
            return data._value;
        }

        private void DrawLine()
        {
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));
        }

        private void DrawPartitionLine(int space)
        {
            EditorGUILayout.Space(space);
            DrawLine();
            EditorGUILayout.Space(space);
        }

        private void DrawHeader(string text)
        {
            GUILayout.Label("<color=white>" + text + "</color>", CustomGUIStyle[GUI_STYLE.HEADER0], GUILayout.ExpandWidth(false));
        }

        private void DrawHeaderLabel(string label, GUIStyle style)
        {
            EditorGUILayout.LabelField("<color=silver>" + label + "</color>", style);
        }

        private void DrawSubMenu(MeshHologramCommonProps props)
        {
            switch (SubIndex)
            {
                case 0:
                    DrawShaderProperty(props.source.source);
                    switch(GetPropertyFloat(targetMat, props.source.source))
                    {
                        case 0:
                            DrawShaderProperty(props.source.fixed_value); break;
                        case 1:
                            DrawNoiseProps(MAIN_CATEGORY.FRAGMENT,props.source); break;
                        default:
                            break;
                    }
                    break;
                case 1:
                    DrawAudioLinkSource(props.audiolink); break;
                case 2:
                    DrawMaskOffsetTex(
                        props.mask_offset.mask_tex,
                        props.mask_offset.mask_st,
                        props.mask_offset.mask_strength
                    );
                    DrawPartitionLine(4);
                    DrawMaskOffsetTex(
                        props.mask_offset.offset_tex,
                        props.mask_offset.offset_st,
                        props.mask_offset.offset_strength
                    );
                    DrawPartitionLine(4);
                    DrawMaskOffsetTex(
                        props.mask_offset.audiolink_mask_tex,
                        props.mask_offset.audiolink_mask_st,
                        props.mask_offset.audiolink_mask_strength
                    );
                    break;
                case 3: 
                    DrawModifiers(props.modifier); break;
                default: 
                    break;
            }
        }

        private void DrawMaskOffsetTex(MESHHOLOGRAM_PROP_ENUM tex, MESHHOLOGRAM_PROP_ENUM st, MESHHOLOGRAM_PROP_ENUM strength = MESHHOLOGRAM_PROP_ENUM._DUMMY)
        {
            DrawShaderProperty(tex);
            if(strength != MESHHOLOGRAM_PROP_ENUM._DUMMY) DrawShaderProperty(strength);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
            DrawShaderProperty(st);
            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight*3.0f);
            CheckSRGBTexture(tex);
        }

        private void CheckSRGBTexture(MESHHOLOGRAM_PROP_ENUM tex)
        {
            Texture2D texture = targetMat.GetTexture(MeshHologramProps[tex].property) as Texture2D;
            if (texture == null) return;
            string path = AssetDatabase.GetAssetPath(texture);
            if (string.IsNullOrEmpty(path)) return;
            TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
            if (importer.sRGBTexture)
            {
                EditorGUILayout.HelpBox(LocalizationManager.GetLocalizeText("label.warning.texture_importer_srgb"), MessageType.Warning);
            }
        }

        private void DrawAudioLinkSource(MeshHologramAudioLinkProps props)
        {
            DrawShaderProperty(props.source);
            switch (GetPropertyFloat(targetMat, props.source))
            {
                case 1:
                    DrawShaderProperty(props.vu_band);
                    DrawShaderProperty(props.vu_smoothing);
                    DrawShaderProperty(props.vu_panning);
                    DrawShaderProperty(props.vu_strength);
                    break;
                case 2:
                    DrawShaderProperty(props.vu_band);
                    DrawShaderProperty(props.vu_smoothing);
                    DrawShaderProperty(props.vu_panning);
                    break;
                case 3:
                    DrawShaderProperty(props.chrono_tensity_band);
                    DrawShaderProperty(props.chrono_tensity_mode);
                    DrawShaderProperty(props.chrono_tensity_strength);
                    break;
                case 4:
                    DrawShaderProperty(props.spectrum_mirror);
                    DrawShaderProperty(props.spectrum_strength);
                    break;
                default:
                    break;
            }
        }

        private void DrawModifiers(MeshHologramModifierProps props)
        {
            DrawShaderProperty(props.phase_scale);
            DrawShaderProperty(props.loop_mode);
            DrawShaderProperty(props.mid_mul);
            DrawShaderProperty(props.mid_add);
            DrawShaderProperty(props.ease_mode);
            DrawShaderProperty(props.ease_curve);
            PreviewGraph(
                GetPropertyFloat(targetMat, props.phase_scale),
                (uint)GetPropertyFloat(targetMat, props.loop_mode),
                GetPropertyFloat(targetMat, props.mid_mul),
                GetPropertyFloat(targetMat, props.mid_add),
                (uint)GetPropertyFloat(targetMat, props.ease_mode),
                GetPropertyFloat(targetMat, props.ease_curve)
            );
        }

        private void DrawNoiseProps(
            MAIN_CATEGORY cat,
            MeshHologramSourceProps props
            )
        {
            DrawShaderProperty(props.offset0);
            DrawShaderProperty(props.scale0);
            using (new EditorGUI.DisabledGroupScope(GetPropertyFloat(targetMat, props.space) != 4))
            {
                DrawShaderProperty(props.offset1);
                DrawShaderProperty(props.scale1);
            }
            DrawShaderProperty(props.offset_before_scale);
            DrawShaderProperty(props.space);
            DrawShaderProperty(props.time_speed);
            DrawShaderProperty(props.time_phase);
            DrawShaderProperty(props.value_scale);
            EditorGUILayout.Space(16);
            DrawNoiseLiteModeGroupButtons(cat);
            if ((MeshHologramKeywords[NoiseLiteModeCat[(int)cat]] as EnumKeyword)._value != 0) DrawMaskOffsetTex(props.map,props.map_st);
            else DrawShaderProperty(props.seed);
        }

        private void DrawNoiseLiteModeGroupButtons(MAIN_CATEGORY CAT = (MAIN_CATEGORY)(-1))
        {
            int cat = (int)CAT;
            bool changed = false;

            using(new EditorGUILayout.VerticalScope())
            {
                Rect rect = EditorGUILayout.GetControlRect();
                Rect toggle_rect = new Rect(rect);
                float toggle_width = 48.0f;
                float label_width = rect.width - (toggle_width*3.0f);
                float toggle_start_x = rect.x + label_width;
                rect.width = label_width;
                toggle_rect.x = toggle_start_x;
                toggle_rect.width -= label_width;

                int radio_offset = (int)(toggle_rect.width/6.0f);
                toggle_rect.x += radio_offset;
                toggle_rect.width -= radio_offset;
                GUIStyle center_radio = new GUIStyle("Radio");
                center_radio.fixedWidth = center_radio.lineHeight;
                center_radio.margin = new RectOffset(0,radio_offset,0,0);

                string[] labels = new string[5]{"Fragment","Color","Geometry","Orbit","OrbitRotation"};

                EditorGUI.LabelField(rect,"Noise Lite Mode");
                if(cat!=-1) DrawNoiseLiteModeRadio(MeshHologramKeywords[NoiseLiteModeCat[cat]] as EnumKeyword);
                else for(int i = 0; i < 5; i++) DrawNoiseLiteModeRadio(MeshHologramKeywords[NoiseLiteModeCat[cat]] as EnumKeyword);
                // if (element > -1 && element <= 5) DrawNoiseLiteModeRadio(element);
                // else for(int i = 0; i < 5; i++) DrawNoiseLiteModeRadio(i);

                void DrawNoiseLiteModeRadio(EnumKeyword data)
                {
                    rect.y += 20.0f;
                    toggle_rect.y += 20.0f;
                    EditorGUILayout.Space(20);
                    EditorGUI.LabelField(rect,data.label);
                    data.value = GUI.Toolbar(toggle_rect,data.value,new string[3]{"","",""},center_radio);
                    if(data.value!=data._value) changed = true;
                    // _NoiseLiteMode[i] = GUI.Toolbar(toggle_rect,_NoiseLiteMode[i],new string[3]{"","",""},center_radio);
                }

                toggle_rect.x -= radio_offset;
                toggle_rect.width += radio_offset;
                toggle_rect.y += 24.0f;
                EditorGUILayout.Space(24);
                toggle_rect.width *= 0.5f;
                Rect revert_button_rect = new Rect(toggle_rect);
                Rect apply_button_rect = new Rect(toggle_rect);
                apply_button_rect.x += apply_button_rect.width;

                using(new EditorGUI.DisabledScope(!changed))
                {
                    bool revert = GUI.Button(revert_button_rect, "Revert");
                    bool apply = GUI.Button(apply_button_rect, "Apply");
                    if (revert || apply)
                    {
                        EnumKeyword[] keywords = new EnumKeyword[NoiseLiteModeCat.Length];
                        for(int i = 0; i < NoiseLiteModeCat.Length; i++)
                        {
                            keywords[i] = MeshHologramKeywords[NoiseLiteModeCat[i]] as EnumKeyword;
                        }
                        if(revert) foreach(EnumKeyword data in keywords) data.refresh = true;

                        if (apply)
                        {
                            bool dialog_frag = false, apply_frag = false;
                            foreach(EnumKeyword data in keywords)
                            {
                                if(data.value == 0 && data._value != 0)
                                {
                                    dialog_frag = true;
                                }
                            }
                            if (dialog_frag)
                            {
                            apply_frag = EditorUtility.DisplayDialog(
                                "tes",
                                "tes",
                                "OK",
                                "Cancel"
                                );
                            }
                            else apply_frag = true;
                            if(apply_frag) foreach(EnumKeyword data in keywords)
                            {
                                data.CheckApplyFrag();
                            }
                        }
                    }
                }
            }
        }

        private void CheckKeywords(bool force)
        {
            if(!force) foreach(MaterialKeyword keyword in MeshHologramKeywords.Values) keyword.RefreshState(targetMat);
            else foreach(MaterialKeyword keyword in MeshHologramKeywords.Values) keyword.ForceRefreshState(targetMat);
            foreach(Material m in targetMats)
            {
                foreach(MaterialKeyword keyword in MeshHologramKeywords.Values) keyword.CheckState(m);
            }
        }

    }
}

#endif