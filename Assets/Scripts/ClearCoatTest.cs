using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClearCoatTest : MonoBehaviour
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
            if (sw)
                GetComponent<Renderer>().material.EnableKeyword("_CLEARCOAT");
            else
                GetComponent<Renderer>().material.DisableKeyword("_CLEARCOAT");
        };
    }

    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();
    void OnEnable() => input.Enable();
}
