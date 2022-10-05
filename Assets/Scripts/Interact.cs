using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    Vector2 rightInteractOffset;
    Vector2 topInteractOffset;
    Collider2D interactCollider;

    // Start is called before the first frame update
    void Start()
    {
        rightInteractOffset = new Vector2(transform.position.x, 0f);
        topInteractOffset = new Vector2(0f, transform.position.y);
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

        if (other.CompareTag("Room1Door"))
        {
            Debug.Log("Touch room1 door");
            Room1Door door = other.GetComponent<Room1Door>();

            if (door != null)
            {
                door.Room1DoorEvent();
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

    public void InteractTop()
    {
        //Debug.Log("Interact top!");
        interactCollider.enabled = true;
        transform.localPosition = topInteractOffset;
    }

    public void InteractDown()
    {
        //Debug.Log("Interact down!");
        interactCollider.enabled = true;
        transform.localPosition = new Vector2(topInteractOffset.x, -topInteractOffset.y);
    }

    public void StopInteract()
    {
        interactCollider.enabled = false;
    }
}
