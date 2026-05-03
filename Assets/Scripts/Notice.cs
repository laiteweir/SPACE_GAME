using UnityEngine;

public class Notice : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        spriteRenderer.enabled = true;
    }  
    void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.enabled = false;
    }
}
