using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    Vector2 rightInteractOffset;
    Collider2D interactCollider;

    // Start is called before the first frame update
    void Start()
    {
        rightInteractOffset = transform.position;
        interactCollider = GetComponent<Collider2D>();
        //Debug.Log(interactCollider.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Keyitem"))
        {
            Keyitem ki = other.GetComponent<Keyitem>();

            if (ki != null)
            {
                ki.KeyitemEvent();
            }
        }
    }

    public void InteractRight()
    {
        //Debug.Log("Interact right!");
        interactCollider.enabled = true;
        transform.localPosition = rightInteractOffset;
    }

    public void InteractLeft()
    {
        //Debug.Log("Interact left!");
        interactCollider.enabled = true;
        transform.localPosition = new Vector2(-rightInteractOffset.x, rightInteractOffset.y);
    }

    public void StopInteract()
    {
        interactCollider.enabled = false;
    }
}
