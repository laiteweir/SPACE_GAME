using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : Keyitem
{
    // Start is called before the first frame update
    private bool keepTrying = false;
    public bool istriggered = false;
    [SerializeField] TextAsset file;
    private string[] dialog1;
    void Start()
    {
        dialog1 = file.text.Split("\n");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void KeyitemEvent()
    {
        istriggered = true;
        Manager.Instance.dialogBox.StartTalk(dialog1);
    }

    public override void EndKeyitemEvent()
    {

    }
    public bool trigger()
    {
        return istriggered;
    }
    private IEnumerator TryUnlockWithPassword()
    {
        Manager.Instance.actionMapPlayer.Disable();
        Manager.Instance.codePanel.SetActive(true);
        while (true)
        {
            if (!keepTrying)
            {
                keepTrying = true;
                Manager.Instance.codePanel.SetActive(false);
                Manager.Instance.actionMapPlayer.Enable();
                yield break;
            }
            else if (Manager.Instance.codePanel.GetComponent<CodePanel>().GetDoorOpen())
            {
                Manager.Instance.codePanel.SetActive(false);
                Manager.Instance.actionMapPlayer.Enable();
                istriggered = true;
                Manager.Instance.dialogBox.StartTalk(dialog1);
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }


}
