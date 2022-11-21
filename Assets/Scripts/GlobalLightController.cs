using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightController : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
        gameObject.GetComponent<Light2D>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
