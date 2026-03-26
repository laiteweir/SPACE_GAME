using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomTen : MonoBehaviour
{
    public GameObject room10Event1;
    public GameObject room10Event2;
    public Light2D room10BigLight;
    public GameObject engine0Hint;
    public GameObject engine1Hint;
    public GameObject refillStationHint;
    [SerializeField] private Door nextDoor;
    [HideInInspector] public bool isEngine0Fixed = false;
    [HideInInspector] public bool isEngine1Fixed = false;
    // Update is called once per frame
    public void UnlockDoor()
    {
        nextDoor.locked = false;
    }
}
