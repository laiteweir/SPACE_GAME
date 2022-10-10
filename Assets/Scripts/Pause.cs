using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update'
    public static GameObject PManu;
    public static bool PMOn = false;
    void Start()
    {
        PManu = GameObject.Find("PausePanel");
        PManu.SetActive(false);
    }


}
