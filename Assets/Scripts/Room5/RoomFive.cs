using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomFive : MonoBehaviour
{
    [SerializeField] private Light2D room5BigLight;
    [SerializeField] private GameObject food1;
    [SerializeField] private GameObject food2;

    public Light2D Room5BigLight { get => room5BigLight; }
    public GameObject Food1 { get => food1; }
    public GameObject Food2 { get => food2; }
}
