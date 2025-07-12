#if UNITY_EDITOR

using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public class GradientMapManager : Object
    {
        public GradientMapManager()
        {
        }
        public Texture2D Export(Gradient gradient)
        {
            string path = EditorUtility.SaveFilePanel("Export Gradient as Image", "", "Gradient", "png");
            if (path == "") return null;

            Texture2D texture = CreateTexture(gradient);
            byte[] binaries = texture.EncodeToPNG();
            DestroyImmediate(texture);

            File.WriteAllBytes(path, binaries);
            AssetDatabase.Refresh();
            path = path.Replace("\\", "/").Replace(Application.dataPath, "Assets");
            TextureImporter importer = (TextureImporter)AssetImporter.GetAtPath(path);
            importer.mipmapFilter = TextureImporterMipFilter.KaiserFilter;
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            return AssetDatabase.LoadAssetAtPath<Texture2D>(path);
        }

        public Texture2D CreateTexture(Gradient gradient)
        {
            Texture2D texture = new Texture2D(256, 2);
            NativeArray<Color32> pixel = texture.GetPixelData<Color32>(0);
            for (int i = 0; i < pixel.Length / 2; i++)
            {
                float time = (float)i / (pixel.Length / 2 - 1);
                pixel[i] = gradient.Evaluate(time);
                pixel[i + 256] = gradient.Evaluate(time);
            }
            texture.Apply();
            return texture;
        }
    }
}

#endif