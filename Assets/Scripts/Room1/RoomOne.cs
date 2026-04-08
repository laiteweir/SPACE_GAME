using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomOne : MonoBehaviour
{
    public bool turnOnLight = false;
    [SerializeField] private Light2D room1BigLight;
    [SerializeField] private Door nextDoor;
    public WirePanel wirePanel;
    // Start is called before the first frame update
    void Start(){
        //Manager.Instance.room1.turnOnLight = false;
        //Manager.Instance.SetDebugMode(true,7.00f,0.0f);  
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Room_1Data.turn_on_light);
        if(Manager.Instance.room1.turnOnLight)
        {
            TurnOnLight();
        }
    }
    public void TurnOnLight()
    {
        room1BigLight.enabled = true;
        nextDoor.locked = false;
    }
}
