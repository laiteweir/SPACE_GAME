using UnityEngine;

public class Slime : MonoBehaviour
{
    public bool isEjected = false;
    private void OnTriggerExit2D(Collider2D other)
    {
        isEjected = true;
    }
}
