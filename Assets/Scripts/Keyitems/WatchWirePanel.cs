using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class WatchWirePanel : Keyitem
{

    [SerializeField] private ItemData itemData;
    private Item item;

    [SerializeField] private GameObject viewObject;
    [SerializeField] private GameObject wirePanelPrefab;
    private WirePanel wirePanel;
    private InputAction exitAction;

    private void Awake()
    {
        item = Manager.Instance.InventoryManager.InstantiateItem(itemData);
        exitAction = Manager.Instance.PlayerInput.actions["UI/Cancel"];
    }
    private void OnEnable()
    {
        exitAction.performed += OnExit;
    }
    private void OnDisable()
    {
        exitAction.performed -= OnExit;
    }

    public override void KeyitemEvent()
    {
        GameObject temp = Instantiate(wirePanelPrefab, viewObject.transform.position, Quaternion.identity);
        temp.transform.SetParent(viewObject.transform);
        wirePanel = temp.GetComponent<WirePanel>();
        // See.transform.localscale = new Vector3(0.5, 0.5,0.5);
        
        Manager.Instance.SwitchToUI();
        wirePanel.wirePanelItem = item;
        wirePanel.wirePanelImage.sprite = item.itemImage;
    }

    private void OnExit(InputAction.CallbackContext context)
    {
        if (wirePanel != null)
        {
            Manager.Instance.SwitchToPlayer();
            Destroy(wirePanel.gameObject);
        }
    }
}

public class WirePanel : MonoBehaviour
{
    public Item wirePanelItem;
    public Image wirePanelImage;
}