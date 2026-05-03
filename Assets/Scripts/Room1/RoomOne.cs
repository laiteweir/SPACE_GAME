using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomOne : MonoBehaviour
{
    [SerializeField] private Light2D room1BigLight;
    [SerializeField] private GameObject room1Computer;
    [SerializeField] private GameObject room1WirePanel;
    [SerializeField] private WirePanel room1WirePanelUI;
    [SerializeField] private Notice robot2Notice;
    [SerializeField] private Door nextDoor;

    public Light2D Room1BigLight { get => room1BigLight; }
    public GameObject Room1Computer { get => room1Computer; }
    public GameObject Room1WirePanel { get => room1WirePanel; }
    public WirePanel Room1WirePanelUI { get => room1WirePanelUI; }
    public Notice Robot2Notice { get => robot2Notice; }

    public void TurnOnLight()
    {
        Room1Computer.SetActive(false);
        Room1WirePanel.SetActive(false);
        room1BigLight.enabled = true;
        Room1Computer.GetComponent<ManageFixLight>().currentEvent.SetActive(false);
        Room1Computer.GetComponent<ManageFixLight>().next.SetActive(true);
        nextDoor.locked = false;
    }
}
