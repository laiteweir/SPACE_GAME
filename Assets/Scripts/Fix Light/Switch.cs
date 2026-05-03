using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject up;
    public GameObject down;
    public bool isOn = false;

    // Start is called before the first frame update
    private void Start()
    {
         up.SetActive(!isOn);
         down.SetActive(isOn);
    }

    private void OnMouseUp()
    {
        up.SetActive(isOn);
        down.SetActive(!isOn);
        isOn = !isOn;
        LightManager.Instance.Check();
    }
}
