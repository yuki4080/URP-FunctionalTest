using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeController : MonoBehaviour
{
    ReflectionProbe probe;

    void Start()
    {
        probe = GetComponent<ReflectionProbe>();
    }

    void Update()
    {
        probe.transform.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y * -1,
            Camera.main.transform.position.z
        );

        probe.RenderProbe();
    }
}
