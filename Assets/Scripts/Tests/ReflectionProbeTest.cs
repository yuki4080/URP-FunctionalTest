using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ReflectionProbeTest : MonoBehaviour
{
    [SerializeField] UniversalRenderPipelineAsset[] pipelineAssets;
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
        ui.text = "Settings: None";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            switch (sw)
            {
                case 0:
                    sw = 1;
                    ui.text = "Settings: Box Projection";
                    break;
                case 1:
                    sw = 2;
                    ui.text = "Settings: Blending";
                    break;
                case 2:
                    sw = 3;
                    ui.text = "Settings: Blending / Box Projection";
                    break;
                case 3:
                    sw = 0;
                    ui.text = "Settings: None";
                    break;
            }
            UpdatePipeline(pipelineAssets[sw]);
        };
    }

    void OnDisable() => input.Disable();
    void OnDestroy()
    {
        UpdatePipeline(pipelineAssets[0]);
        input.Disable();
    }
    void OnEnable() => input.Enable();
}
