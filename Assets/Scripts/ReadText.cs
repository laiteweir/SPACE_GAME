using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadText : MonoBehaviour
{
    //public string Objectname;
    private bool moveNext = false;
    private bool endDialog = false;
    private int count;
    private string[] str;
    public Text dialog;
    //private Text nextline;
    //private string dialog_text = "";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Manager.Instance.dialogBox.TextIsOn == true)
        {
            // Debug.Log("get dialog length: "+str.GetLength(0).ToString());
            if (count < str.GetLength(0))
            {
            //string lines = str[count];
            //Text nextline.text = lines;
                moveNext = true;
            }
            else
            {
                endDialog = true;
            }
        }
    }

    /*public bool setDialog(string input){
        this.dialog_text = input;
        str = this.dialog_text.Split('\n');
        return true;
    }*/

    public void StartTalk(TextAsset inputTxt)
    {
        str = inputTxt.text.Split('\n');
        StartCoroutine(Talk());
    }

    private IEnumerator Talk()
    {
        Manager.Instance.actionMapPlayer.Disable();
        while (true)
        {
            if (moveNext)
            {
                moveNext = false;
                dialog.text = str[count];
                count++;
                yield return null;
            }
            else if (endDialog)
            {
                endDialog = false;
                Manager.Instance.ui.SetActive(false);
                Manager.Instance.dialogBox.TextIsOn = false;
                count = 0;
                dialog.text = "";
                // if(is_trigger){
                //     GameObject.Find(Objectname).GetComponent<CreateGameObject>().CreateObject();
                //     is_trigger = false;
                Manager.Instance.actionMapPlayer.Enable();
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
}
