using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CookManager : BaseScene
{
    public static CookManager Instance;
    public int situation;
    [SerializeField] private GameObject slide;
    [SerializeField] private float limitPoint;
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject cookedFood;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if (slide.GetComponent<SlideControl>().isDone)
        {
            if (slide.GetComponent<SlideControl>().points >= limitPoint)
            {
                situation = 1;
                // win = true;
                SceneExit();
            }
            else
            {
                situation = 3;
                SceneExit();
            }
        }
        if (slide.GetComponent<Slider>().value == 10)
        {
            // overcooked = true;
            situation = 2;
            SceneExit();
        }

        if (slide.GetComponent<SlideControl>().points >= limitPoint)
        {
            food.SetActive(false);
            cookedFood.SetActive(true);
        } 
    }
}
