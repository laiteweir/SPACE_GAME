using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSix : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject room6_event1;
    private bool clear = false;
    [SerializeField] GameObject nextDoor;
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(room6_event1.GetComponent<Room6_event_1>().exist && !clear){
            clear = true;
            nextDoor.GetComponent<Door>().locked = false;
            Destroy(room6_event1);
        }
    }
}
