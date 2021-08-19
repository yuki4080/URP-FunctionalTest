using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AdditionalLightTest : MonoBehaviour
{
    [SerializeField] UniversalRenderPipelineAsset[] usePipelineAssets;
    [SerializeField] UniversalRenderPipelineAsset defaultPipelineAsset;
    [SerializeField] Text ui;
    Controls input;
    int sw;

    void UpdatePipeline(UniversalRenderPipelineAsset pipelineAsset)
    {
        if (pipelineAsset)
        {
            GraphicsSettings.renderPipelineAsset = pipelineAsset;
        }
    }

    void Awake()
    {
        sw = 0;
        ui.text = "Additional Lights: Per Pixel";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            switch(sw)
            {
                case 0:
                    sw = 1;
                    ui.text = "Additional Lights: Disabled";
                    break;
                case 1:
                    sw = 2;
                    ui.text = "Additional Lights: Per Vertex";
                    break;
                case 2:
                    sw = 0;
                    ui.text = "Additional Lights: Per Pixel";
                    break;
            }
            UpdatePipeline(usePipelineAssets[sw]);
        };
    }

    void OnDisable() => input.Disable();
    void OnDestroy()
    {
        UpdatePipeline(defaultPipelineAsset);
        input.Disable();
    }
    void OnEnable()
    {
        UpdatePipeline(usePipelineAssets[0]);
        input.Enable();
    }
}
