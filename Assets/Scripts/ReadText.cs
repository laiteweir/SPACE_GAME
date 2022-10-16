using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadText : MonoBehaviour
{
    // Start is called before the first frame update
    public int count = 0;
    public string[] str;
    public Text dialog;
    public Text nextline;
    void Start()
    {
        var TXT = Resources.Load<TextAsset>("dialog");
        str = TXT.text.Split('\n');

        
    }

    // Update is called once per frame
    void Update()
    {
        if (UI.TextIsOn == true)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                if (count < str.GetLength(0))
                {
                    //string lines = str[count];
                    //Text nextline.text = lines;
                    dialog.text = str[count];
                    count += 1;
                }
                else
                {
                    UI.text.SetActive(false);
                    UI.TextIsOn = false;
                    count = 0;
                    dialog.text = "";
                }
            }
        }
    }
}
