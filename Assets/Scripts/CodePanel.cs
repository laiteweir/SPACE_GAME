using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    public string passward = "1234";
    [SerializeField] Text Codecontext;
    string codevalue = "";
    private bool door_open = false;

    // door_open Getter
    public bool GetDoorOpen()
    {
        return door_open;
    }
    // door_open Setter
    public void SetDoorOpen(bool input)
    {
        door_open = input;
    }
    // Update is called once per frame
    void Update()
    {
        Codecontext.text = codevalue;
        if(codevalue.Length >= 5)
        {
            Delete();
        }
    }
    public void AddValue(string digit)
    {
        if (codevalue.Length <= 4)
        {
            codevalue += digit;
            Debug.Log(codevalue);
        }
    }
    public void Confirm()
    {
        if (codevalue == passward)
        {
            SetDoorOpen(true);
            Debug.Log("The door is opened");
        }
    }
    public void Delete()
    {
        string result = codevalue[0..^1];
        codevalue = result;
        Debug.Log(codevalue);
    }
}
