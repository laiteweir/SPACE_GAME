using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOne : MonoBehaviour
{
    // Start is called before the first frame update
    bool isopen = true;
    [SerializeField] GameObject room_1_light;
    public GameObject room1_event1;
    public GameObject room1_event2;
    public GameObject room1_event3;
    public GameObject room1_event4;
    void Start(){
        Room_1Data.turn_on_light = false;
        //Manager.Instance.SetDebugMode(true,7.00f,0.0f);  
    }
 
    void Update()
    {
        //Debug.Log(Room_1Data.turn_on_light);
        if(Room_1Data.turn_on_light && isopen){
            isopen = false;
            Turn_on_light();
        }
    }

    // Update is called once per frame
    
    public void Turn_on_light(){
        room_1_light.SetActive(true);
    }
}
