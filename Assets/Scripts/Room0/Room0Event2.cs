using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room0Event2 : Keyitem
{
    [SerializeField] private GameObject next;
    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    // Start is called before the first frame update
    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    // Update is called once per frame
    private void Update()
    {
        if (TrueForAll(Manager.Instance.room0.room0Lights))
        {
            Manager.Instance.room0.Room0TurnOnBigLight();
            gameObject.SetActive(false);
            next.SetActive(true);
        }
    }

    private bool TrueForAll(bool[] allLights)
    {
        for (int i = 0; i < allLights.Length; ++i)
        {
            if (allLights[i] == false)
            {
                return false;
            }
        }
        return true;
    }
    public override void KeyitemEvent()
    {
        //enable next process
        Manager.Instance.DialogBox.StartTalk(dialog);
        //Debug.Log(Manager.Instance.DialogBoxUI.activeSelf);
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
