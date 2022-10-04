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
    
    // Update is called once per frame
    void Update()
    {
        Codecontext.text = codevalue;
    }
    public void AddValue(string digit){
        codevalue+=digit;
        Debug.Log(codevalue);
    }
}
