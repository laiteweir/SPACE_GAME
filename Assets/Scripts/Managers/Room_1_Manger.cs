using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_1_Manger : MonoBehaviour
{
    public static Room_1_Manger Instance;
    bool isopen = true;
    [SerializeField] GameObject room_1_light;
    void Start(){
        Room_1Data.turn_on_light = false;
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
