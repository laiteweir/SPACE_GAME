using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        gameObject.SetActive(false);
        Manager.Instance.SwitchToPlayer();
    }
}
