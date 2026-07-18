using UnityEngine;

public class CaptainSlimeMove : MonoBehaviour
{
    private int count = 0;
    [SerializeField] private GameObject bossSlime;
    // Start is called before the first frame update
    private void Start()
    {
        if (Manager.Instance.Player.TryGetComponent<PlayerController>(out var pc))
        {
            pc.LockMovement();
        }
    }
    private void FixedUpdate()
    {
        if (count <= 100)
        {
            ++count;
            transform.Translate(Vector2.down * Time.fixedDeltaTime);
        }
        else
        {
            gameObject.SetActive(false);
            bossSlime.SetActive(true);
            if (Manager.Instance.Player.TryGetComponent<PlayerController>(out var pc))
            {
                pc.UnlockMovement();
            }
        }
    }
}
