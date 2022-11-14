using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOne : MonoBehaviour
{
    // Start is called before the first frame update
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
