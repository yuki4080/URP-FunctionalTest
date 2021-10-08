using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class EnlightenGITest : MonoBehaviour
{
    [SerializeField] LightingSettings lightingSettings;
    [SerializeField] Text ui;
    Controls input;
    bool sw;

    void Awake()
    {
        sw = true;
        ui.text = "Effect: Enable";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            sw = !sw;
            //additionalCameraData.renderPostProcessing = sw;
            lightingSettings.realtimeGI = sw;
            ui.text = "Effect: " + (sw ? "Enable" : "Disable");
        };
    }

    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();
    void OnEnable() => input.Enable();
}
