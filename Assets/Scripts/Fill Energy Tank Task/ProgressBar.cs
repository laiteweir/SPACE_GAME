using UnityEngine;
using UnityEngine.EventSystems;

public class ProgressBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private SpriteRenderer energyBar;
    [SerializeField] private float fullRefill = 100f;
    private bool isPressed = false;
    private float startPressTime;

    private void Update()
    {
        if (isPressed)
        {
            energyBar.size = new Vector2(energyBar.size.x, energyBar.size.y + (Time.time - startPressTime) / fullRefill);
            if (energyBar.size.y >= 5.4f)
            {
                energyBar.size = new Vector2(energyBar.size.x, 0.2f);
                FETTManager.Instance.CompleteFilling();
            }
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isPressed = true;
        startPressTime = Time.time;
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isPressed = false;
    }
}
