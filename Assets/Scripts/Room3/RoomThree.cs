using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomThree : MonoBehaviour
{
    [SerializeField] private Light2D room3BigLight;
    [SerializeField] private Light2D consoleLight;
    [SerializeField] private GameObject consoleMarker;

    [SerializeField] private GameObject file1;
    [SerializeField] private GameObject file2;
    [SerializeField] private GameObject file3;
    [SerializeField] private GameObject file4;
    [SerializeField] private GameObject file5;
    [SerializeField] private GameObject room3Event2;
    [SerializeField] private GameObject room3Event3;
    [SerializeField] private Door finalDoor1;
    [SerializeField] private Door finalDoor2;
    [SerializeField] private Door finalDoor3;

    public Light2D Room3BigLight { get => room3BigLight; }
    public Light2D ConsoleLight { get => consoleLight; }
    public GameObject ConsoleMarker { get => consoleMarker; }
    public GameObject File1 { get => file1; }
    public GameObject File2 { get => file2; }
    public GameObject File3 { get => file3; }
    public GameObject File4 { get => file4; }
    public GameObject File5 { get => file5; }
    public GameObject Event2 { get => room3Event2; }
    public GameObject Event3 { get => room3Event3; }

    // public void UnlockRoom4Door()
    // {
    //     Manager.Instance.room4.NextDoor.UnlockDoor();
    //     finalDoor1.UnlockDoor();
    //     finalDoor2.UnlockDoor();
    //     finalDoor3.UnlockDoor();
    // }
}
