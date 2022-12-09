using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    private SpriteRenderer hint;

    // Start is called before the first frame update
    void Start()
    {
        hint = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("trigger");
        if(collision.gameObject.CompareTag("Player"))
        {
            hint.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Debug.Log("leave");
        if (collision.gameObject.CompareTag("Player"))
        {
            hint.enabled = false;
        }
    }
}
