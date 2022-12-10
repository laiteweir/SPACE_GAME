using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room9_event_03_notice : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
