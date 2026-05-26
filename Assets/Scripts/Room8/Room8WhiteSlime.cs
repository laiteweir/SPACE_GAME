using UnityEngine;

public class Room8WhiteSlime : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject other = col.gameObject;
        if (other.CompareTag("GlowingContainer"))
        {
            if (other.TryGetComponent<Room8Event1>(out var container))
            {
                Destroy(gameObject);
                container.FillContainer();
            }
        }
    }
}
