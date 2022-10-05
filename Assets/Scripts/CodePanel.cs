using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Text Codecontext;
    string  codevalue="";
    bool door_open= false;
    
    // Update is called once per frame
    void Update()
    {
        Codecontext.text = codevalue;
        if(codevalue=="1234"){
            door_open = true;
        }
    }
    public void AddValue(string digit){
        codevalue+=digit;
        Debug.Log(codevalue);
    }
}
