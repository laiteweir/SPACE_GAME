using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomTen : MonoBehaviour
{
    [SerializeField] private Light2D room10BigLight;

    public GameObject refillStationHint;
    [SerializeField] private GameObject engine1;
    [SerializeField] private GameObject engine2;
    [SerializeField] private GameObject room10Event2;

    [HideInInspector] public bool isEngine1Fixed = false;
    [HideInInspector] public bool isEngine2Fixed = false;

    [SerializeField] private Door nextDoor;

    public Light2D Room10BigLight { get => room10BigLight; }
    public GameObject Engine1 { get => engine1; }
    public GameObject Engine2 { get => engine2; }
    public GameObject Room10Event2 { get => room10Event2; }

    public void UnlockRoom3Door()
    {
        nextDoor.UnlockDoor();
        Manager.Instance.room3.ConsoleLight.enabled = true;
        Manager.Instance.room3.ConsoleMarker.SetActive(true);
    }
}
