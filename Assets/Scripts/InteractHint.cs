using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject hint;
    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("trigger");
        if(collision.gameObject.CompareTag("Player"))
            hint.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision){
        Debug.Log("leave");
        hint.SetActive(false);
    }
}
