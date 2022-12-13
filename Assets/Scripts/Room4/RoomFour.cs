using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFour : MonoBehaviour
{
    public GameObject room4_event1_1;
    public GameObject room4_event1_2;
    public GameObject room4_event1_3;
    public GameObject room4_event1_4;
    public GameObject safe;
    public GameObject door;
    public bool event1 = false;
    public bool event2 = false;
    public bool event3 = false;
    public bool event4 = false;
    public bool safeon = false;
    // Start is called before the first frame update
    void Start()
    {
        safe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (event1 ==true && event2 == true && event3 == true && event4 == true)
        {
            safeon = true;
            safe.SetActive(true);
        }
        else 
        {
            safeon = false;
        }

    }
}
