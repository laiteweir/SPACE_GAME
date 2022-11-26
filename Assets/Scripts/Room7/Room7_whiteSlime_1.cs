using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room7_whiteSlime_1 : MonoBehaviour
{
    [SerializeField] GameObject door_7_1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        door_7_1.GetComponent<Door>().locked = true;
        Debug.Log("try to open door 7_1");
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }   
    // Update is called once per frame
    void Update()
    {
        
    }
}
