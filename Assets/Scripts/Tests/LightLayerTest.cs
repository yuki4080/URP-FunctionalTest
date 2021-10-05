using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LightLayerTest : MonoBehaviour
{
    [SerializeField] UniversalRenderPipelineAsset useAdditionalLight_PipelineAsset;
    [SerializeField] UniversalRenderPipelineAsset useLightLayer_PipelineAsset;
    [SerializeField] UniversalRenderPipelineAsset defaultPipelineAsset;
    [SerializeField] Text ui;
    Controls input;
    bool sw;

    void UpdatePipeline(UniversalRenderPipelineAsset pipelineAsset)
    {
        if (pipelineAsset)
        {
            GraphicsSettings.renderPipelineAsset = pipelineAsset;
        }
    }

    void Awake()
    {
        UniversalAdditionalCameraData additionalCameraData = GetComponent<UniversalAdditionalCameraData>();
        sw = true;
        ui.text = "LightLayer: Enable";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            sw = !sw;
            if (sw)
                UpdatePipeline(useLightLayer_PipelineAsset);
            else
                UpdatePipeline(useAdditionalLight_PipelineAsset);
            ui.text = "LightLayer: " + (sw ? "Enable" : "Disable");
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
        UpdatePipeline(useLightLayer_PipelineAsset);
        input.Enable();
    }
}
