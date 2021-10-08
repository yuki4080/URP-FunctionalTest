using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearCoatTest : MonoBehaviour
{
    [SerializeField] Text ui;
    Controls input;
    bool sw;

    void Awake()
    {
        sw = true;
        ui.text = "Clear Coat: Enable";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            sw = !sw;
            if (sw)
                GetComponent<Renderer>().material.EnableKeyword("_CLEARCOAT");
            else
                GetComponent<Renderer>().material.DisableKeyword("_CLEARCOAT");
            ui.text = "Clear Coat: " + (sw ? "Enable" : "Disable");
        };
    }

    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();
    void OnEnable() => input.Enable();
}
