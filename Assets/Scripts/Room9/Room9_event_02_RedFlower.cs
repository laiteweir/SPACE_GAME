using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room9_event_02_RedFlower : MonoBehaviour
{
    [SerializeField] TextAsset textFile;
    // Start is called before the first frame update
    private string[] dialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        bool result = Manager.Instance.room9.setItem("RedFlower");
        Debug.Log(result);
    }  
    // Update is called once per frame
    void Update()
    {
        
    }
}
