using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class SSAOTest : MonoBehaviour
{
    [SerializeField]
    Text ui;
    Controls input;
    bool sw;

    void Awake()
    {
        UniversalAdditionalCameraData additionalCameraData = GetComponent<UniversalAdditionalCameraData>();
        sw = true;
        ui.text = "SSAO: Enable";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            sw = !sw;
            if (sw)
                additionalCameraData.SetRenderer(1);
            else
                additionalCameraData.SetRenderer(-1);
            ui.text = "SSAO: " + (sw ? "Enable" : "Disable");
        };
    }

    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();
    void OnEnable() => input.Enable();
}
