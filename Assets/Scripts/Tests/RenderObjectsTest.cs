using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RenderObjectsTest : MonoBehaviour
{
    [SerializeField] UniversalRenderPipelineAsset usePipelineAsset;
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
        ui.text = "Customize: Enable";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            sw = !sw;
            if (sw)
                additionalCameraData.SetRenderer(-1);
            else
                additionalCameraData.SetRenderer(1);
            ui.text = "Customize: " + (sw ? "Enable" : "Disable");
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
        UpdatePipeline(usePipelineAsset);
        input.Enable();
    }
}
