using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private List<GameObject> slimes;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float timeToInstantiateNewSlime = 3f;
    private readonly float slimeForceMagnitude = 1.35f;

    private float timer = 0f;
    private Vector2 direction = Vector2.left;
    private Vector2 slimeForceDirection;
    private bool stage2 = false;

    // Start is called before the first frame update
    private void Start()
    {
        slimeForceDirection.y = BossFightManager.Instance.paddleController.transform.position.y - transform.position.y;
    }
    // Update is called once per frame
    private void Update()
    {
        if (timer > timeToInstantiateNewSlime)
        {
            timer = 0f;
            Invoke(nameof(InstantiateNewSlime), 0.1f);
        }
        timer += Time.deltaTime;

        if (!stage2 && BossFightManager.Instance.bossHealth <= 1)
        {
            speed = 2f;
            stage2 = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WhiteSlime"))
        {
            if (other.TryGetComponent<Slime>(out var slime))
            {
                if (slime.isEjected)
                {
                    --BossFightManager.Instance.bossHealth;
                }
            }
        }
    }

    private void InstantiateNewSlime()
    {
        int number = Random.Range(0, 2);
        GameObject newSmile = Instantiate(slimes[number]);
        newSmile.transform.position = transform.position;
        slimeForceDirection.x = BossFightManager.Instance.paddleController.transform.position.x - transform.position.x;
        if (BossFightManager.Instance.paddleController.moving)
        {
            if (BossFightManager.Instance.paddleController.right)
            {
                slimeForceDirection.x += 0.3f;
            }
            else
            {
                slimeForceDirection.x -= 0.3f;
            }
        }
        newSmile.GetComponent<Rigidbody2D>().AddForce(slimeForceDirection.normalized * slimeForceMagnitude);
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= 97 || transform.position.x >= 101)
        {
            direction *= -1f;
        }
        transform.Translate(speed * Time.fixedDeltaTime * direction);
    }
}
