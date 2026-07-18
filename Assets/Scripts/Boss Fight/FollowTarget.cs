using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new(0f, 0.3f, 0f);

    private void LateUpdate()
    {
        if (Manager.Instance.Player == null)
        {
            return;
        }
        transform.position = Manager.Instance.Player.transform.position + offset;
    }
}