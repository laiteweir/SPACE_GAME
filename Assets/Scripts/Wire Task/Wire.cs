using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] SpriteRenderer wireEnd;
    [SerializeField] GameObject lightOn;
    Vector3 rootPosition;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rootPosition = transform.parent.position;
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void OnMouseDrag()
    {
        Vector3 newPosition = TaskManager.wireTaskCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        // Snap this wire to a connection and check if the colors match when the hitboxes are close enough
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            // If the collider isn't this wire's own collider
            if (collider.gameObject != gameObject)
            {
                UpdateWire(collider.transform.position);
                // If the colors of the two wires match
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    TaskManager.AddPoints(1);
                    collider.GetComponent<Wire>().Done();
                    Done();
                }
                return;
            }
        }
        UpdateWire(newPosition);
    }

    private void OnMouseUp()
    {
        UpdateWire(startPosition);
    }

    private void UpdateWire(Vector3 newPosition)
    {
        // Update position
        transform.position = newPosition;

        // Update direction
        Vector3 direction = newPosition - rootPosition;
        transform.right = direction * transform.lossyScale.x;

        // Update scale
        float distance = Vector2.Distance(rootPosition, newPosition) + 0.16f;
        wireEnd.size = new Vector2(distance, wireEnd.size.y);
    }

    private void Done()
    {
        lightOn.SetActive(true);
        Destroy(this);
    }
}
