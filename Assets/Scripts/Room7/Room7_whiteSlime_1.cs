using UnityEngine;

public class Room7_whiteSlime_1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject other = col.gameObject;
        if (other.CompareTag("GlowingContainer"))
        {
            gameObject.SetActive(false);
            if (other.TryGetComponent<Room8Event1>(out var container))
            {
                container.FillContainer();
            }
        }
    }
}
