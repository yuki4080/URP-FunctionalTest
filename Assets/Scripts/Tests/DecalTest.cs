using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DecalTest : MonoBehaviour
{
    [SerializeField] UniversalRenderPipelineAsset usePipelineAsset;
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
        UniversalAdditionalCameraData additionalCameraData = GetComponent<UniversalAdditionalCameraData>();
        sw = 0;
        ui.text = "Technique: Automatic";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            switch (sw)
            {
                case 0:
                    sw = 1;
                    ui.text = "Technique: DBuffer";
                    break;
                case 1:
                    sw = 2;
                    ui.text = "Technique: Screen Space";
                    break;
                case 2:
                    sw = 0;
                    ui.text = "Technique: Automatic";
                    break;
            }
            additionalCameraData.SetRenderer(sw);
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
