using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room7_event_02 : MonoBehaviour
{
    [SerializeField] TextAsset textFile;
    //private TextAsset dialog01;
    private string[] dialog;

    private bool first_trigger = true;
    [SerializeField] GameObject alien1;
    [SerializeField] GameObject alien2;
    [SerializeField] GameObject alien3;
    [SerializeField] GameObject alien4;
    [SerializeField] GameObject alien5;

    [SerializeField] GameObject alien6;
    [SerializeField] GameObject alien7;
    [SerializeField] GameObject alien8;
    [SerializeField] GameObject alien9;
    [SerializeField] GameObject alien10;
    // Start is called before the first frame update
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if(this.first_trigger && col.gameObject.name == "Player"){
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            this.first_trigger = false;
            Manager.Instance.room7.room7_event_01.SetActive(false);
            this.stop_aliens();
        }
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }  

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stop_aliens(){
        this.alien1.SetActive(false);
        this.alien2.SetActive(false);
        this.alien3.SetActive(false);
        this.alien4.SetActive(false);
        this.alien5.SetActive(false);
        this.alien6.SetActive(false);
        this.alien7.SetActive(false);
        this.alien8.SetActive(false);
        this.alien9.SetActive(false);
        this.alien10.SetActive(false);
    }
}
