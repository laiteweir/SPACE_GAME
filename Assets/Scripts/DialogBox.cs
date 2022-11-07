using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    //public string Objectname;
    private bool moveNext = false;
    private bool endDialog = false;
    private int count;
    private string[] str;
    public Text dialog;
    public bool TextIsOn = false;
    //private Text nextline;
    //private string dialog_text = "";
    public bool is_trigger; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TextIsOn == true)
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

    public void StartTalk(string[] inputTxt)
    {
        str = inputTxt;
        StartCoroutine(Talk());

    }

    private IEnumerator Talk()
    {
        Manager.Instance.actionMapPlayer.Disable();
        dialog.text = str[count];
        ++count;
        while (true)
        {
            if (moveNext)
            {
                moveNext = false;
                dialog.text = str[count];
                ++count;
                yield return null;
            }
            else if (endDialog)
            {
                endDialog = false;
                gameObject.SetActive(false);
                TextIsOn = false;
                count = 0;
                dialog.text = "";
                
                is_trigger = true;
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
