using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomFour : MonoBehaviour
{
    [SerializeField] private Light2D room4BigLight;
    [SerializeField] private Door nextDoor;
    [SerializeField] private GameObject room4Strongbox;
    [SerializeField] private GameObject room4Event1;
    [SerializeField] private GameObject room4Event2;
    [SerializeField] private GameObject room4Event3;
    [SerializeField] private GameObject room4Event4;

    public Light2D Room4BigLight { get => room4BigLight; }
    // public Door NextDoor { get => nextDoor; }
    public GameObject Room4Strongbox { get => room4Strongbox; }
    public GameObject Event1 { get => room4Event1; }
    public GameObject Event2 { get => room4Event2; }
    public GameObject Event3 { get => room4Event3; }
    public GameObject Event4 { get => room4Event4; }
}
