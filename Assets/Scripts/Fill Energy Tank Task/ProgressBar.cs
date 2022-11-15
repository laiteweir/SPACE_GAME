using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProgressBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] SpriteRenderer energyBar;
    [SerializeField] float fullRefill = 100f;
    bool isPressed = false;
    float startPressed;

    void Update()
    {
        if (isPressed)
        {
            energyBar.size = new Vector2(energyBar.size.x, energyBar.size.y + (Time.time - startPressed) / fullRefill);
            if (energyBar.size.y >= 3.4f)
            {
                energyBar.size = new Vector2(energyBar.size.x, 0.6f);
                FETTManager.Instance.Done();
            }
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isPressed = true;
        startPressed = Time.time;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isPressed = false;
    }
}
