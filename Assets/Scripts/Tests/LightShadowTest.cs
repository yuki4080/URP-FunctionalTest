using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightShadowTest : MonoBehaviour
{
    [SerializeField] Text ui;
    [SerializeField] Light[] lights;
    Controls input;
    bool sw;

    void Awake()
    {
        sw = true;
        ui.text = "Shadow: Enable";
        input = new Controls();
        input.UI.Submit.started += ctx =>
        {
            sw = !sw;
            if (sw)
            {
                for (int i = 0; i < lights.Length; i++)
                    lights[i].shadows = LightShadows.Soft;
            }
            else
            {
                for (int i = 0; i < lights.Length; i++)
                    lights[i].shadows = LightShadows.None;
            }
            ui.text = "Shadow: " + (sw ? "Enable" : "Disable");
        };
    }

    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();
    void OnEnable() => input.Enable();
}
