using UnityEngine;
using UnityEngine.InputSystem;

public class TouchDeviceSupport : MonoBehaviour
{
    [SerializeField] GameObject screenButton;

    void Awake()
    {
        if (Touchscreen.current == null)
            screenButton.SetActive(false);
        else
            screenButton.SetActive(true);
    }
}
