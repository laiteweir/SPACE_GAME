using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOne : MonoBehaviour
{
    public bool turnOnLight = false;
    [SerializeField] private GameObject room1Light;
    public GameObject room1Event1;
    public GameObject room1Event2;
    public GameObject room1Event3;
    public GameObject room1Event4;
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
        room1Light.SetActive(true);
    }
}
