#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static DeltaField.Shaders.MeshHologram.Editor.Initializer;

namespace DeltaField.Shaders.MeshHologram.Editor
{
    public static class PipelineManager
    {
        private static string state;
        public static PIPELINE pipeline{get; private set;}

        [InitializeOnLoadMethod]
        private static void Init()
        {
            EditorApplication.update += PipelineUpdate;
        }

        private static void PipelineUpdate()
        {
            if(!IsInitialized) return;
            string current_state;
            if(GraphicsSettings.currentRenderPipeline!=null) current_state = GraphicsSettings.currentRenderPipeline.name;
            else current_state = "";
            if(state != current_state)
            {
                pipeline = current_state switch
                {
                    "URP" => PIPELINE.URP,
                    "HDRP" => PIPELINE.HDRP,
                    _ => PIPELINE.BUILTIN
                };
                ConfigManager.SetPipelineState(pipeline);
                MeshHologramManager.ShaderCodeGenerate();
                state = current_state;
            }
        }
    }
}

#endif