using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room9_event_04 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextAsset textFile;
    // Start is called before the first frame update
    private string[] dialog;
    [SerializeField] GameObject Room9_event_03;
    [SerializeField] GameObject whiteSlime;
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
        whiteSlime.SetActive(true);

        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }  

    // Update is called once per frame
    void Update()
    {
        
    }
}
