using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : Keyitem
{
    private TextAsset first;
    private string[] dialogFirst;
    [SerializeField] Image image;
    // private Color imageColor;
    private bool startFadeOut = false;
    private float startTime;
    public float fadeTime = 5f;

    private void Start()
    {
        first = Resources.Load<TextAsset>("Ending");
        dialogFirst = first.text.Split('\n');
        // imageColor = image.color;
    }
    private void Update()
    {
        if (startFadeOut)
        {
            image.color = Color.Lerp(Color.clear, Color.black, (Time.time - startTime) / fadeTime);
            if ((Time.time - startTime) >= fadeTime)
            {
                startFadeOut = false;
            }
        }
    }
    public override void KeyitemEvent()
    {
        startFadeOut = true;
        startTime = Time.time;
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalkAndOpenScene(dialogFirst, "Ending", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseScene("Ending");
    }
}
