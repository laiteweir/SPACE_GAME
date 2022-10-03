using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static GameObject text;
    public static bool TextIsOn = false;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("UI");
        text.SetActive(false);
    }
    

}
