using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanarReflectionTest : MonoBehaviour
{
    [SerializeField]
    Text ui;
    Controls input;
    bool sw;

    void Awake()
    {
        sw = true;
        ui.text = "Reflection: Enable";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            sw = !sw;
            GetComponent<PlanarReflections>().enabled = sw;
            ui.text = "Reflection: " + (sw ? "Enable" : "Disable");
        };
    }

    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();
    void OnEnable() => input.Enable();
}
