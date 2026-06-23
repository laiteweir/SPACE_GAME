using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Boss;
    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject shield;
    public bool win = false;
    private int playerhealth = 5;
    public string keyword;
    private Slider slide;
    private void Start()
    {
        Boss.GetComponent<BossSmile>().bossHealth = 4;
        for (int i = 0; i < Manager.Instance.InventoryManager.items.Count; ++i)
        {
            if (Manager.Instance.InventoryManager.items[i].itemName == keyword)
            {
                    playerhealth = 10;
                    shield.SetActive(true);
            }
        }
        Player.GetComponent<BreakController>().health = playerhealth;
        slide = slider.GetComponent<Slider>();
        slide.maxValue = playerhealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Boss.GetComponent<BossSmile>().bossHealth == 0)
        {
            Manager.Instance.iswin = true;
            backScene();
        }
        else if (Player.GetComponent<BreakController>().health == 0)
        {
            backScene();
        }
    }

    private void backScene(){
        Manager.Instance.returnKeyitem.EndKeyitemEvent();
    }
}
