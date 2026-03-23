using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room5Event0 : MonoBehaviour
{
    //new Collider2D collider;
    [SerializeField] private GameObject next;

    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    private bool triggerFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
        dialog = textFile.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        // enable next process
        if (Manager.Instance.DialogBoxUI.activeSelf == false && triggerFirst == false)
        {
            next.SetActive(true);
            gameObject.SetActive(false);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (triggerFirst && col.gameObject.CompareTag("Player"))
        {
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.StartTalk(dialog);
            triggerFirst = false;
        }
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }
}
