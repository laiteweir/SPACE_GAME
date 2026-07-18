using UnityEngine;

public class Deadline : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject other = col.gameObject;
        if (other.CompareTag("BlackSlime") || other.CompareTag("WhiteSlime"))
        {
            Destroy(other);
        }
    }
}
