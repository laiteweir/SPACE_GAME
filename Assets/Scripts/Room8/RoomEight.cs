using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomEight : MonoBehaviour
{
    [SerializeField] private Light2D room8BigLight;
    [SerializeField] private Light2D room8Event1Light;
    [SerializeField] private GameObject room8Event2;
    [SerializeField] private GameObject room8WhiteSlime1;
    [SerializeField] private GameObject room8WhiteSlime2;
    [SerializeField] private GameObject room8WhiteSlime3;
    [SerializeField] private Door door8_1;
    [SerializeField] private Door door1_2;

    public Light2D Room8BigLight { get => room8BigLight; }
    public Light2D Room8Event1Light { get => room8Event1Light; }
    public GameObject Room8Event2 { get => room8Event2; }
    public GameObject Room8WhiteSlime1 { get => room8WhiteSlime1; }
    public GameObject Room8WhiteSlime2 { get => room8WhiteSlime2; }
    public GameObject Room8WhiteSlime3 { get => room8WhiteSlime3; }
    public Door Door8_1 { get => door8_1; }
    public Door Door1_2 { get => door1_2; }
}
