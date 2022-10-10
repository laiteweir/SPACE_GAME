using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update'
    public static GameObject PMaun;
    public static bool PMOn = false;
    void Start()
    {
        PMaun = GameObject.Find("PausePanel");
        PMaun.SetActive(false);
    }


}
