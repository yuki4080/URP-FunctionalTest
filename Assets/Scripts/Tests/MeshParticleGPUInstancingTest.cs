using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeshParticleGPUInstancingTest : MonoBehaviour
{
    [SerializeField]
    Text ui;
    Controls input;
    bool sw;

    void Awake()
    {
        sw = true;
        ui.text = "GPUInstancing: Enable";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            sw = !sw;
            GetComponent<ParticleSystemRenderer>().enableGPUInstancing = sw;
            ui.text = "GPUInstancing: " + (sw ? "Enable" : "Disable");
        };
    }

    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();
    void OnEnable() => input.Enable();
}
