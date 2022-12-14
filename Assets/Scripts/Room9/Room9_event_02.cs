using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room9_event_02 : MonoBehaviour
{
    [SerializeField] TextAsset textFile;
    // Start is called before the first frame update
    private string[] dialog;
    [SerializeField] GameObject Room9_PC_light_1;
    [SerializeField] GameObject Room9_desk_light_1;
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    void OnTriggerEnter2D(Collider2D col)
    {
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            Room9_PC_light_1.GetComponent<Light2D>().enabled = false;
            // Room9_desk_light_1.GetComponent<Light2D>().enabled = true;
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }  
    // Update is called once per frame
    void Update()
    {
        
    }
}
