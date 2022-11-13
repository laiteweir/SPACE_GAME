using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSix : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject room6_event1;
    [SerializeField] GameObject nextDoor;
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(room6_event1.GetComponent<Room6_event_1>().exist){
            nextDoor.GetComponent<Door>().enabled = true;
        }
    }
}
