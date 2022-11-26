using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room9_event_03 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextAsset textFile;
    // Start is called before the first frame update
    private string[] dialog;
    [SerializeField] GameObject Room9_event_01;
    [SerializeField] GameObject Room9_event_02;
    [SerializeField] GameObject Room9_event_04;
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(Manager.Instance.room9.itemsAreDone()){
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            Room9_event_01.SetActive(false);
            Room9_event_04.SetActive(true);
        }

        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }  

    // Update is called once per frame
    void Update()
    {
        
    }
}
