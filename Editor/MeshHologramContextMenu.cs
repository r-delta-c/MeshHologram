#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;
using static DeltaField.Shaders.MeshHologram.Editor.MeshHologramManager;
using static DeltaField.Shaders.MeshHologram.Editor.PropertyBlockManager;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public partial class MeshHologramInspector : ShaderGUI
    {
        private void DrawHeaderButtonGeneral()
        {
            if (DrawContextMenuIcon())
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.RENDERING].GetMainBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.STENCIL].GetMainBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.AUDIOLINK].GetMainBlock()
                    })));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.RENDERING].GetMainBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.STENCIL].GetMainBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.AUDIOLINK].GetMainBlock(),
                    }));
                menu.ShowAsContext();
            }
        }
        private void DrawHeaderButtonMain()
        {
            if (DrawContextMenuIcon())
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.FRAGMENT].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.COLOR].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.GEOMETRY].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_WAVE].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION_OFFSET].GetFullBlock(),
                    })));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.FRAGMENT].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.COLOR].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.GEOMETRY].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_WAVE].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION_OFFSET].GetFullBlock(),
                    }
                ));
                menu.ShowAsContext();
            }
        }
        private void DrawHeaderButtonOthers()
        {
        }

        private void DrawHeaderButtonRendering()
        {
            if (DrawContextMenuIcon())
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.RENDERING].GetMainBlock()
                    })));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.RENDERING].GetMainBlock()
                    }
                ));
                menu.ShowAsContext();
            }
        }
        private void DrawHeaderButtonStencil()
        {
            if (DrawContextMenuIcon())
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.STENCIL].GetMainBlock()
                    })));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                {
                    PropertyBlockNames[PROPERTY_BLOCK.STENCIL].GetMainBlock()
                }
                ));
                menu.ShowAsContext();
            }
        }
        private void DrawHeaderButtonAudioLink()
        {
            if (DrawContextMenuIcon())
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.AUDIOLINK].GetMainBlock()
                    })));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () =>  ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.AUDIOLINK].GetMainBlock()
                    }
                ));
                menu.ShowAsContext();
            }
        }

        private void DrawHeaderButtonFragment()
        {
            if (DrawContextMenuIcon())
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties_specific")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.FRAGMENT].GetMainBlock()
                    })));
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties_all")), false, () => CopyBuffer(CopyBlock(targetMat,PropertyBlockNames[PROPERTY_BLOCK.FRAGMENT].GetFullBlocks())));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties_specific")), false, () => ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.FRAGMENT].GetMainBlock()
                    }
                ));
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties_all")), false, () => ParseBlock(PropertyBlockNames[PROPERTY_BLOCK.FRAGMENT].GetFullBlocks()));
                menu.ShowAsContext();
            }
        }
        private void DrawHeaderButtonColor()
        {
            if (DrawContextMenuIcon())
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties_specific")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.COLOR].GetMainBlock()
                    })));
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties_all")), false, () => CopyBuffer(CopyBlock(targetMat,PropertyBlockNames[PROPERTY_BLOCK.COLOR].GetFullBlocks())));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties_specific")), false, () => ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.COLOR].GetMainBlock()
                    }
                ));
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties_all")), false, () => ParseBlock(PropertyBlockNames[PROPERTY_BLOCK.COLOR].GetFullBlocks()));
                menu.ShowAsContext();
            }
        }
        private void DrawHeaderButtonGeometry()
        {
            if (DrawContextMenuIcon())
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties_specific")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.GEOMETRY].GetMainBlock()
                    })));
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties_all")), false, () => CopyBuffer(CopyBlock(targetMat,PropertyBlockNames[PROPERTY_BLOCK.GEOMETRY].GetFullBlocks())));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties_specific")), false, () => ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.GEOMETRY].GetMainBlock()
                    }
                ));
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties_all")), false, () => ParseBlock(PropertyBlockNames[PROPERTY_BLOCK.GEOMETRY].GetFullBlocks()));
                menu.ShowAsContext();
            }
        }
        private void DrawHeaderButtonOrbit()
        {
            if (DrawContextMenuIcon())
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties_specific")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT].GetMainBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION].GetMainBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_WAVE].GetMainBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION_OFFSET].GetMainBlock(),
                    })));
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties_all")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_WAVE].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION_OFFSET].GetFullBlock()
                    })));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties_specific")), false, () => ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT].GetMainBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION].GetMainBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_WAVE].GetMainBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION_OFFSET].GetMainBlock(),
                    }));
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties_all")), false, () => ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_WAVE].GetFullBlock(),
                        PropertyBlockNames[PROPERTY_BLOCK.ORBIT_ROTATION_OFFSET].GetFullBlock()
                    }));

                menu.ShowAsContext();
            }
        }

        private void DrawHeaderButtonOrbitBlock()
        {
            PROPERTY_BLOCK orbit_block = GetOrbitIndexBlock();
            string name = PropertyBlockNames[orbit_block].name;
            if (DrawContextMenuIcon())
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties_specific")), false, () => CopyBuffer(CopyBlock(targetMat,
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                    {
                        PropertyBlockNames[orbit_block].GetMainBlock()
                    })));
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties_all")), false, () => CopyBuffer(CopyBlock(targetMat, PropertyBlockNames[orbit_block].GetFullBlocks())));
                menu.AddSeparator("");
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties_specific")), false, () => ParseBlock(
                    new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                {
                    PropertyBlockNames[orbit_block].GetMainBlock()
                }
                ));
                menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties_all")), false, () => ParseBlock(PropertyBlockNames[orbit_block].GetFullBlocks()));
                menu.ShowAsContext();
            }
        }

        private void DrawHeaderButtonCommons()
        {
            using (new GUILayout.HorizontalScope(GUILayout.ExpandWidth(false)))
            {
                DrawHeader("Commons");
                if (DrawContextMenuIcon())
                {
                    PROPERTY_BLOCK block = GetMainIndexBlock();
                    GenericMenu menu = new GenericMenu();
                    string name = PropertyBlockNames[block].name;
                    menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                        new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                        {
                            PropertyBlockNames[block].GetCommonBlock(PROPERTY_BLOCK.SOURCE),
                            PropertyBlockNames[block].GetCommonBlock(PROPERTY_BLOCK.AUDIOLINK_SOURCE),
                            PropertyBlockNames[block].GetCommonBlock(PROPERTY_BLOCK.MASK_OFFSET),
                            PropertyBlockNames[block].GetCommonBlock(PROPERTY_BLOCK.MODIFIER)
                        }
                    )));
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                        {
                            PropertyBlockNames[block].GetCommonBlock(PROPERTY_BLOCK.SOURCE),
                            PropertyBlockNames[block].GetCommonBlock(PROPERTY_BLOCK.AUDIOLINK_SOURCE),
                            PropertyBlockNames[block].GetCommonBlock(PROPERTY_BLOCK.MASK_OFFSET),
                            PropertyBlockNames[block].GetCommonBlock(PROPERTY_BLOCK.MODIFIER),
                        }
                    ));
                    menu.ShowAsContext();
                }
            }
        }
        private void DrawHeaderButtonCommon()
        {
            using(new GUILayout.HorizontalScope(GUILayout.ExpandWidth(false)))
            {
                DrawHeader(SubLabels[SubIndex].text);
                if (DrawContextMenuIcon())
                {
                    PROPERTY_BLOCK block = GetMainIndexBlock();
                    string name = PropertyBlockNames[block].name;
                    PROPERTY_BLOCK common_block = GetCommonIndexBlock();

                    GenericMenu menu = new GenericMenu();
                    menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                        new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                        {
                            PropertyBlockNames[block].GetCommonBlock(common_block)
                        })));
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                        {
                            PropertyBlockNames[block].GetCommonBlock(common_block)
                        }
                    ));
                    menu.ShowAsContext();
                }
            }
        }

        private void DrawHeaderButtonOrbitCommons()
        {
            using (new GUILayout.HorizontalScope(GUILayout.ExpandWidth(false)))
            {
                DrawHeader("Commons");
                if (DrawContextMenuIcon())
                {
                    GenericMenu menu = new GenericMenu();
                    PROPERTY_BLOCK orbit_block = GetOrbitIndexBlock();
                    string name = PropertyBlockNames[orbit_block].name;
                    switch (orbit_block)
                    {
                        case PROPERTY_BLOCK.ORBIT:
                            menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                                new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                                {
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.SOURCE),
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.AUDIOLINK_SOURCE),
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.MASK_OFFSET),
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.MODIFIER),
                                }
                            )));
                            menu.AddSeparator("");
                            menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                                {
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.SOURCE),
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.AUDIOLINK_SOURCE),
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.MASK_OFFSET),
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.MODIFIER),
                                }
                            ));
                            menu.ShowAsContext();
                            break;
                        case PROPERTY_BLOCK.ORBIT_ROTATION:
                            menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                                new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                                {
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.SOURCE),
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.MASK_OFFSET)
                                }
                            )));
                            menu.AddSeparator("");
                            menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                                {
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.SOURCE),
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.MASK_OFFSET),
                                }
                            ));
                            menu.ShowAsContext();
                            break;
                        case PROPERTY_BLOCK.ORBIT_WAVE:
                            menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                                new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                                {
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.AUDIOLINK_SOURCE)
                                }
                            )));
                            menu.AddSeparator("");
                            menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                                {
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.AUDIOLINK_SOURCE),
                                }
                            ));
                            menu.ShowAsContext();
                            break;
                        case PROPERTY_BLOCK.ORBIT_ROTATION_OFFSET:
                            menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                                new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                                {
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.AUDIOLINK_SOURCE),
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.MASK_OFFSET)
                                }
                            )));
                            menu.AddSeparator("");
                            menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                                {
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.AUDIOLINK_SOURCE),
                                    PropertyBlockNames[orbit_block].GetCommonBlock(PROPERTY_BLOCK.MASK_OFFSET),
                                }
                            ));
                            menu.ShowAsContext();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void DrawHeaderButtonOrbitCommon()
        {
            using (new GUILayout.HorizontalScope(GUILayout.ExpandWidth(false)))
            {
                string label = SubLabels[SubIndex].text;
                DrawHeader(label);
                if (DrawContextMenuIcon())
                {
                    PROPERTY_BLOCK orbit_block = GetOrbitIndexBlock();
                    string name = PropertyBlockNames[orbit_block].name;
                    PROPERTY_BLOCK common_block = GetCommonIndexBlock();

                    GenericMenu menu = new GenericMenu();
                    if (label == "---")
                    {
                        menu.AddDisabledItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")));
                        menu.AddSeparator("");
                        menu.AddDisabledItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")));
                    }
                    else
                    {
                        menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.copy_properties")), false, () => CopyBuffer(CopyBlock(targetMat,
                            new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                            {
                                PropertyBlockNames[orbit_block].GetCommonBlock(common_block)
                            })));
                        menu.AddSeparator("");
                        menu.AddItem(new GUIContent(LocalizationManager.GetLocalizeText("text.paste_properties")), false, () => ParseBlock(new Tuple<string, MESHHOLOGRAM_PROP_ENUM[], string>[]
                            {
                                PropertyBlockNames[orbit_block].GetCommonBlock(common_block)
                            }
                        ));
                    }
                    menu.ShowAsContext();
                }
            }
        }

        private bool DrawContextMenuIcon()
        {
            return GUILayout.Button("<color=white><b>⋮</b></color>", new GUIStyle(EditorStyles.iconButton) { margin = new RectOffset(4, 0, 2, 0), fontSize = 16, richText = true, alignment = TextAnchor.MiddleCenter }, GUILayout.ExpandWidth(false));
        }

        private PROPERTY_BLOCK GetMainIndexBlock()
        {
            return MainIndex switch
            {
                0 => PROPERTY_BLOCK.FRAGMENT,
                1 => PROPERTY_BLOCK.COLOR,
                2 => PROPERTY_BLOCK.GEOMETRY,
                3 => PROPERTY_BLOCK.ORBIT,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        private PROPERTY_BLOCK GetOrbitIndexBlock()
        {
            return OrbitIndex switch
            {
                0 => PROPERTY_BLOCK.ORBIT,
                1 => PROPERTY_BLOCK.ORBIT_ROTATION,
                2 => PROPERTY_BLOCK.ORBIT_WAVE,
                3 => PROPERTY_BLOCK.ORBIT_ROTATION_OFFSET,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        private PROPERTY_BLOCK GetCommonIndexBlock()
        {
            return SubIndex switch
            {
                0 => PROPERTY_BLOCK.SOURCE,
                1 => PROPERTY_BLOCK.AUDIOLINK_SOURCE,
                2 => PROPERTY_BLOCK.MASK_OFFSET,
                3 => PROPERTY_BLOCK.MODIFIER,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}

#endif