using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room0LightNotice : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        spriteRenderer.enabled = true;
    }  
    void OnTriggerExit2D(Collider2D col)
    {
        spriteRenderer.enabled = false;
    }
}
