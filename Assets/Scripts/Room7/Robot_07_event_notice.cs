using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_07_event_notice : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        this.spriteRenderer.enabled = true;
    }  
    void OnTriggerExit2D(Collider2D col)
    {
        this.spriteRenderer.enabled = false;
    }  
}
