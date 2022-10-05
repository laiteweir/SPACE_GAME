using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public string  passward="1234";
    [SerializeField]
    Text Codecontext;
    string  codevalue="";
    bool door_open= false;
    
    // Update is called once per frame
    void Update()
    {
        Codecontext.text = codevalue;
        if(codevalue.Length>=5)
            Delete();
    }
    public void AddValue(string digit){
        if(codevalue.Length<=4){
            codevalue+=digit;
            Debug.Log(codevalue);
        }
    }
    public void Confirm(){
        if(codevalue==passward){
            door_open = true;
            Debug.Log("the door is open\n");
        }
    }
    public void Delete(){
        string result = codevalue.Substring(0,codevalue.Length-1);
        codevalue = result;
        Debug.Log(codevalue);
    }
}
