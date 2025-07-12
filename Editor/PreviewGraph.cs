#if UNITY_EDITOR

using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DeltaField.Shaders.MeshHologram.Editor{
    public class PreviewGraph{
        private int width;
        private int height;
        public Texture2D preview_tex;
        public PreviewGraph(float mul, float add, float curve, bool curve_type, int w = 128, int h = 128)
        {
            width = w;
            height = h;
            preview_tex = new Texture2D(width, height) { wrapMode = TextureWrapMode.Clamp };
            Draw(mul,add,curve,curve_type);
            Rect rect = GUILayoutUtility.GetRect(width, height);
            Rect graph_rect = new Rect(rect) { x = rect.x+48, width = rect.width-48 };
            GUI.DrawTexture(graph_rect, preview_tex, ScaleMode.StretchToFill);

            using (new EditorGUILayout.VerticalScope())
            {
                GUI.DrawTexture(new Rect(rect) { width = 48 }, MakeTex(2, 2, new Color32(30, 40, 50, 255)));
                Rect value_label_rect = new Rect(rect) { width = 44 };
                GUIStyle value_label_style = new GUIStyle() { alignment = TextAnchor.MiddleRight };
                value_label_style.normal.textColor = Color.white;
                float split_y = rect.height / 7.0f;
                GUI.Label(new Rect(value_label_rect) { y = value_label_rect.y - split_y - split_y }, "1.0", value_label_style);
                GUI.Label(value_label_rect, "0.5", value_label_style);
                GUI.Label(new Rect(value_label_rect) { y = value_label_rect.y + split_y + split_y }, "0.0", value_label_style);
            }
        }
        public Texture2D MakeTex(int width, int height, Color32 col)
        {
            Texture2D texture = new Texture2D(width, height);
            NativeArray<Color32> pixel = texture.GetPixelData<Color32>(0);
            for (int i = 0; i < pixel.Length; i++)
            {
                pixel[i] = col;
            }
            texture.Apply();
            return texture;
        }
        public void Draw(float mul, float add, float curve, bool curve_type)
        {
            NativeArray<Color32> pixel = preview_tex.GetPixelData<Color32>(0);
            for (int i = 0; i < pixel.Length; i++)
            {
                Color32 c = new Color32(55, 55, 88, 255);
                int x = i % width;
                int y = (int)Mathf.Floor(i / width);
                float res_x = (float)x / width;
                float res_y = (float)y / height;
                float guide_y = Mathf.Abs(Mathf.Abs(res_y-0.5f) * 3.5f % 1.0f * 2.0f - 1.0f);
                byte guide_y_b = (byte)smoothstep(0.94f,1.00f,guide_y);

                c.r = guide_y_b>0?(byte)11:c.r;
                c.g = guide_y_b>0?(byte)22:c.g;
                c.b = guide_y_b>0?(byte)55:c.b;

                res_y = res_y*1.7f-0.350f;
                float value_x = res_x*mul-mul*0.5f+0.5f+add*(mul+(mul>=0.0f?1.0f:-1.0f))*0.76f;
                value_x = value_x * 1.3f - 0.15f;
                if (curve_type)
                {
                    value_x = value_x > 0.5f ? Mathf.Pow(value_x * 2.0f - 1.0f, curve) * 0.5f + 0.5f : 1.0f - Mathf.Pow(-value_x * 2.0f + 1.0f, curve) * 0.5f-0.5f;
                }
                else
                {
                    value_x = value_x < 0.5f ? Mathf.Pow(Mathf.Clamp01(value_x * 2.0f), curve) * 0.5f : 1.0f - Mathf.Pow(Mathf.Clamp01(value_x * -2.0f + 2.0f), curve) * 0.5f;
                }

                float guide_x = Mathf.Abs(Mathf.Abs(-res_x*1.3f+0.15f) % 1.0f * 2.0f - 1.0f);
                byte guide_x_b = (byte)(smoothstep(0.94f,1.00f,guide_x)*1.1f);

                c.r = guide_x_b>0?(byte)11:c.r;
                c.g = guide_x_b>0?(byte)22:c.g;
                c.b = guide_x_b>0?(byte)55:c.b;

                float res_x_clamp = Mathf.Clamp01(value_x);
                float res_y_value = res_y;
                byte graph = (byte)(plot(res_y_value, value_x)*255);
                byte graph_clamp = (byte)(plot(res_y_value, res_x_clamp)*255);
                byte graph_clamp_r = (byte)(plot(res_y_value, res_x_clamp)*128);
                c.r = graph>0?graph:c.r;
                c.g = graph>0?graph:c.g;
                c.b = graph>0?graph:c.b;
                c.r = graph_clamp>0?graph_clamp_r:c.r;
                c.g = graph_clamp>0?graph_clamp:c.g;
                c.b = graph_clamp>0?graph_clamp:c.b;
                byte gray = (byte)((c.r + c.g + c.b) / 5.0f);
                c.r = 1.0f > res_y ? (res_y > 0.0f ? c.r : gray) : gray;
                c.g = 1.0f > res_y ? (res_y > 0.0f ? c.g : gray) : gray;
                c.b = 1.0f > res_y ? (res_y > 0.0f ? c.b : gray) : gray;
                pixel[i] = c;
            }
            preview_tex.Apply();


            float plot(float width, float t)
            {
                return smoothstep(width - 0.03f, width, t) - smoothstep(width, width + 0.03f, t);
            }

            float smoothstep(float a, float b, float x)
            {
                float t = Mathf.Clamp01((x - a) / (b - a));
                return t * t * (3.0f - (2.0f * t));
            }
        }
    }
}

#endif