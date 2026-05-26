using UnityEngine;

public class Room1EventSlimeMove : MonoBehaviour
{
    public bool isMoving = false;
    private int count = 0;
    private void FixedUpdate()
    {
        if (isMoving)
        {
            ++count;
            transform.Translate(Vector2.up * Time.deltaTime); // 位移方法
        }
        if (count > 100) { Destroy(gameObject); }
    }
}
