using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room9_event_04 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextAsset textFile;
    // Start is called before the first frame update
    private string[] dialog;
    [SerializeField] GameObject Room9_event_01;
    [SerializeField] GameObject Room9_event_02;
    [SerializeField] GameObject Room9_event_03;
    [SerializeField] GameObject Room9_PC;
    [SerializeField] GameObject whiteSlime;
    [SerializeField] GameObject Room9_bigLight;
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        Room9_event_03.SetActive(false);
        Room9_event_02.SetActive(false);
        Room9_event_01.SetActive(false);
        Room9_PC.SetActive(false);
        whiteSlime.SetActive(true);
        this.Room9_bigLight.SetActive((true));
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }  

    // Update is called once per frame
    void Update()
    {
        
    }
}
