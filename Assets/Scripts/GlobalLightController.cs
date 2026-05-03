using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightController : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Light2D>().enabled = false;
    }
}
