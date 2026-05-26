using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] private SpriteRenderer wireEnd;
    [SerializeField] private SpriteRenderer lightOn;
    private Vector3 rootPosition;
    private Vector3 startPosition;

    // Start is called before the first frame update
    private void Start()
    {
        rootPosition = transform.parent.position;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = WireTaskManager.Instance.pointAction.ReadValue<Vector2>();
        Vector3 newPosition = WireTaskManager.Instance.wireTaskCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -WireTaskManager.Instance.wireTaskCamera.transform.position.z));

        // Snap this wire to a connection and check if the colors match when the hitboxes are close enough
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            // If the collider isn't this wire's own collider
            if (collider.gameObject != gameObject)
            {
                UpdateWire(collider.transform.position);
                // If the colors of the two wires match
                if (transform.parent.CompareTag(collider.transform.parent.tag))
                {
                    WireTaskManager.Instance.AddPoint();
                    Done();
                    if (collider.TryGetComponent<Wire>(out var wire))
                    {
                        wire.Done();
                    }
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
        lightOn.enabled = true;
        Destroy(this);
    }
}
