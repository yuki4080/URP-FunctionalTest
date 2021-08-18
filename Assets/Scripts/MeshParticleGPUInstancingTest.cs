using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshParticleGPUInstancingTest : MonoBehaviour
{
    Controls input;
    bool sw;

    void Awake()
    {
        sw = true;
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            sw = !sw;
            GetComponent<ParticleSystemRenderer>().enableGPUInstancing = sw;
        };
    }

    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();
    void OnEnable() => input.Enable();
}
