using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room7_event_03 : MonoBehaviour
{
    [SerializeField] TextAsset textFile;
    private string[] dialog;
    public GameObject Room7_whiteSlime_1;
    
    public GameObject Room7_whiteSlime_2;
    
    public GameObject Room7_whiteSlime_3;
    public GameObject Room7_event_03_light;
    public GameObject Room7_bigLight;
    public GameObject door_7_1;
    public GameObject door_1_2;
    private float light_intensity_base;
    private int times;
    void Start()
    {
        this.light_intensity_base = 0.2f;
        this.times = 0;
        dialog = textFile.text.Split('\n');
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log(col.name.Contains("Slime"));
        if(col.name == "Room7_whiteSlime_1"){
            Room7_whiteSlime_1.SetActive(false);
            this.times ++;
            this.Room7_event_03_light.GetComponent<Light2D>().intensity = this.light_intensity_base * this.times;
        }
        if(col.name == "Room7_whiteSlime_2"){
            Room7_whiteSlime_2.SetActive(false);
            this.times ++;
            this.Room7_event_03_light.GetComponent<Light2D>().intensity = this.light_intensity_base * this.times;
        }
        if(col.name == "Room7_whiteSlime_3"){
            Room7_whiteSlime_3.SetActive(false);
            this.times ++;
            this.Room7_event_03_light.GetComponent<Light2D>().intensity = this.light_intensity_base * this.times;
        }
        if(this.times == 3){
            door_7_1.GetComponent<Door>().locked = false;
            door_1_2.GetComponent<Door>().locked = false;
            Room7_event_03_light.SetActive(false);
            Room7_bigLight.SetActive(true);
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            this.enabled = false;
        }
    }  

    // Update is called once per frame
    void Update()
    {
        
    }

}
