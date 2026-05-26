using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightController : MonoBehaviour
{
    public bool lightOn = false;
    private void Awake()
    {
        gameObject.GetComponent<Light2D>().enabled = lightOn;
    }
}
