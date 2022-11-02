using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadText : MonoBehaviour
{
    // Start is called before the first frame update
    private int count;
    public string[] str;
    public Text dialog;
    public Text nextline;
    public string Objectname;
    bool is_trigger = true;

    private string dialog_text = "";

    void Start()
    {
        // var TXT = Resources.Load<TextAsset>("dialog");
        // str = TXT.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
    
        if (UI.TextIsOn == true)
        {
            Manager.actionMapPlayer.Disable();
            if (Input.GetKeyDown(KeyCode.Space))
            {

                // Debug.Log("get dialog length: "+str.GetLength(0).ToString());
                if (count < str.GetLength(0))
                {
                    //string lines = str[count];
                    //Text nextline.text = lines;

                    dialog.text = str[count];
                    count++;
                }
                else
                {
                    UI.text.SetActive(false);
                    UI.TextIsOn = false;
                    count = 0;
                    is_trigger = true;
                    dialog.text = "";
                    // if(is_trigger){
                    //     GameObject.Find(Objectname).GetComponent<CreateGameObject>().CreateObject();
                    //     is_trigger = false;
                    // }
                }
            }
            
        }
        else{
            Manager.actionMapPlayer.Enable();
        }
    }

    public bool setDialog(string input){
        this.dialog_text = input;
        str = this.dialog_text.Split('\n');
        return true;
    }
}
