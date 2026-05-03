using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomNine : MonoBehaviour
{
    [SerializeField] private Light2D room9BigLight;
    [SerializeField] private Light2D room9PCLight;
    [SerializeField] private GameObject redFlowerEvent;
    [SerializeField] private GameObject yellowLeafEvent;
    [SerializeField] private GameObject hairEvent;
    [SerializeField] private GameObject whiteJarEvent;
    [SerializeField] private GameObject folderEvent;
    [SerializeField] private ItemData redFlowerData;
    [SerializeField] private ItemData yellowLeafData;
    [SerializeField] private ItemData hairData;
    [SerializeField] private ItemData whiteJarData;
    [SerializeField] private ItemData folderData;

    public Light2D Room9BigLight { get => room9BigLight; }
    public Light2D Room9PCLight { get => room9PCLight; }
    public GameObject RedFlowerEvent { get => redFlowerEvent; }
    public GameObject YellowLeafEvent { get => yellowLeafEvent; }
    public GameObject HairEvent { get => hairEvent; }
    public GameObject WhiteJarEvent { get => whiteJarEvent; }
    public GameObject FolderEvent { get => folderEvent; }
    public ItemData RedFlowerData { get => redFlowerData; }
    public ItemData YellowLeafData { get => yellowLeafData; }
    public ItemData HairData { get => hairData; }
    public ItemData WhiteJarData { get => whiteJarData; }
    public ItemData FolderData { get => folderData; }
}
