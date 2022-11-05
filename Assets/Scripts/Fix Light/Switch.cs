using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject up;
    public bool is_on = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseUp(){
        up.SetActive(is_on);
        is_on = !is_on;
    }
}
