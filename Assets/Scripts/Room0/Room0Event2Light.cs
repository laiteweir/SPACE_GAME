using UnityEngine;

public class Room0Event2Light : Keyitem
{
    [SerializeField] private int lightNum;
    public override void KeyitemEvent()
    {
        // Debug.Log($"Light{lightNum}_touch");
        if (Manager.Instance.room0.Room0Event2VerifyLightSort(lightNum - 1))
        {
            Manager.Instance.room0.Room0Lights[lightNum - 1] = true;
            Manager.Instance.room0.Room0Event2Light[lightNum - 1].color = Color.green;
        }
    }
}
