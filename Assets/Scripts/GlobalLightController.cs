using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightController : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<Light2D>().enabled = false;
    }
}
