using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewFPS : MonoBehaviour
{
    [SerializeField]
    Text fps;
    int frameCount;
    float prevTime;

    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }

    void Update()
    {
        ++frameCount;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps.text = $"{frameCount / time:000}fps";

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}
