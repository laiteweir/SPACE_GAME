using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomZero : MonoBehaviour
{    
    public Door nextDoor;
    [SerializeField] private Notice robot1Notice;
    private bool[] room0Lights = { false, false, false, false };
    [SerializeField] private List<Light2D> room0Event2Light;
    [SerializeField] private List<Notice> room0Event2LightNotice;
    [SerializeField] private Light2D room0BigLight;
    [SerializeField] private GameObject keyCard;

    public Notice Robot1Notice { get => robot1Notice; }
    public bool[] Room0Lights { get => room0Lights; }
    public List<Light2D> Room0Event2Light { get => room0Event2Light; }
    public List<Notice> Room0Event2LightNotice { get => room0Event2LightNotice; }

    public bool Room0TurnOffLightsWithRedLight()
    {
        foreach (Light2D light in Room0Event2Light)
        {
            light.enabled = true;
            light.color = Color.red;
        }
        foreach (Notice lightNotice in Room0Event2LightNotice)
        {
            lightNotice.gameObject.SetActive(true);
        }
        return true;
    }
    public bool Room0TurnOnBigLight()
    {
        foreach (Light2D light in Room0Event2Light)
        {
            light.enabled = false;
        }
        foreach (Notice lightNotice in Room0Event2LightNotice)
        {
            lightNotice.gameObject.SetActive(false);
        }
        room0BigLight.enabled = true;
        Instantiate(keyCard);
        return true;
    }
    public bool Room0Event2VerifyLightSort(int sortNum)
    {
        // sort num mapping [light1,light2,light3,light4]
        bool result = true;
        for (int i = 0; i < sortNum; ++i)
        {
            if (Room0Lights[i] != true){
                result = false;
                Room0TurnOffLightsWithRedLight();
            }
        }
        return result;
    }
}
