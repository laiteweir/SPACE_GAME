using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SlideControl : MonoBehaviour
{
    private Slider slider;
    public float points = 0;
    public bool isDone = false;
    private int count = 30;
    private bool timerStarted;
    private bool flip = true;
    private int t = 0;
    [SerializeField] private GameObject fireup;
    [SerializeField] private GameObject firedown;
    private float speed = 0;
    [SerializeField] private List<Sprite> mode;
    [SerializeField] private Image target;

    private InputAction flipAction;

    private void Awake()
    {
        flipAction = Manager.Instance.PlayerInput.actions["UI/Submit"];
    }
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
        fireup.SetActive(flip);
        firedown.SetActive(!flip);
        speed = Random.Range(0.05f, 0.1f);
        timerStarted = true;
    }

    private void OnEnable()
    {
        flipAction.performed += OnFlip;
    }
    private void OnDisable()
    {
        flipAction.performed -= OnFlip;
    }

    // Update is called once per frame
    private void Update()
    {
        // time += Time.deltaTime;
        // if (time > 1)
        // {
        //     time = 0;
        //     slide.value += 1;
        // }

        if (timerStarted)
        {
            StartCoroutine("CountDown");
            timerStarted = false;
            // Debug.Log(count);
            if (count == 0)
            {
                // points += slider.value;
                slider.value = 0;
                isDone = true;
                // Debug.Log(points);
                // Destroy(this);
            }
        }
    }
    private void FixedUpdate()
    {
        slider.value += speed;
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        --count;
        timerStarted = true;
    }

    private void OnFlip(InputAction.CallbackContext context)
    {
        speed = Random.Range(0.05f, 0.1f);
        //slide.value = 0;
        flip = !flip;
        fireup.SetActive(flip);
        firedown.SetActive(!flip);
        if (t == 0 && slider.value >= 8)
        {
            points += 1;
        }
        else if (t == 2 && slider.value >= 5.5 && slider.value <= 7.5)
        {
            points += 1;
        }
        else if (t == 1 && slider.value >= 3 && slider.value <= 6)
        {
            points += 1;
        }
        t = Random.Range(0, 9);
        t %= 3;
        Sprite image = mode[t];
        target.sprite = image;
        slider.value = 0;
    }
}
