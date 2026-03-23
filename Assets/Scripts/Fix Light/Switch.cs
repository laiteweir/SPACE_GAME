using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject up;
    public GameObject down;
    public bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
         up.SetActive(!isOn);
         down.SetActive(isOn);
    }
    private void OnMouseUp(){
        up.SetActive(isOn);
        down.SetActive(!isOn);
        isOn = !isOn;
    }
}
