using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SlideControl : MonoBehaviour
{
    private Slider slider;
    private float speed = 0f;
    private int point = 0;
    [SerializeField] private int successPoint = 5;
    private int count = 0;
    [SerializeField] private int limitCount = 10;
    [SerializeField] private bool flip = false;
    private Condition condition = Condition.Second;
    [SerializeField] private List<Sprite> mode;
    [SerializeField] private Image target;

    private enum Condition
    {
        First,
        Second,
        Third
    }

    private InputAction flipAction;

    private void Awake()
    {
        flipAction = Manager.Instance.PlayerInput.actions["UI/Submit"];
    }
    private void OnEnable()
    {
        flipAction.performed += OnFlip;
    }
    private void OnDisable()
    {
        flipAction.performed -= OnFlip;
    }
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0f;
        speed = Random.Range(0.05f, 0.1f);
    }
    // Update is called once per frame
    private void Update()
    {
        if (slider.value == 10f)
        {
            CookManager.Instance.Burnt = true;
            CookManager.Instance.ExitScene();
        }
    }
    private void FixedUpdate()
    {
        slider.value += speed;
    }

    private void OnFlip(InputAction.CallbackContext context)
    {
        ++count;
        if (condition == Condition.First && slider.value >= 8)
        {
            ++point;
        }
        else if (condition == Condition.Second && slider.value >= 3 && slider.value <= 6)
        {
            ++point;
        }
        else if (condition == Condition.Third && slider.value >= 5.5 && slider.value <= 7.5)
        {
            ++point;
        }

        if (count >= limitCount)
        {
            CookManager.Instance.Undercooked = true;
            CookManager.Instance.ExitScene();
        }

        flip = !flip;
        CookManager.Instance.UpwardFire.SetActive(!flip);
        CookManager.Instance.DownwardFire.SetActive(flip);
        if (point >= successPoint)
        {
            CookManager.Instance.Cooked = true;
            CookManager.Instance.Food.SetActive(false);
            CookManager.Instance.CookedFood.SetActive(true);
        }

        slider.value = 0f;
        speed = Random.Range(0.05f, 0.1f);

        int c = Random.Range(0, 9);
        c %= 3;
        target.sprite = mode[c];
        if (c == 0)
        {
            condition = Condition.First;
        }
        else if (c == 1)
        {
            condition = Condition.Second;
        }
        else if (c == 2)
        {
            condition = Condition.Third;
        }
    }
}
