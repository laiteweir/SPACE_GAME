using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1EventSlime : MonoBehaviour
{

    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    [SerializeField] private GameObject slime;
    // public bool destroy = false;

    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
        dialog = textFile.text.Split('\n');
        // this_event = GameObject.Find("Robot_01_event_01");
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // Manager.Instance.ui.SetActive(true);
            // Manager.Instance.dialogBox.StartTalk(dialog);
            //this.first_trigger = false;
            slime.GetComponent<Room1EventSlimeMove>().isMoving = true;
            StartCoroutine(PlayAudio());
            //Destroy(gameObject);
        }
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }    

    private IEnumerator PlayAudio()
    {
        Manager.Instance.SwitchToUI();
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        // Debug.Log("play audio");
        yield return new WaitForSeconds(audio.clip.length);

        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.StartTalk(dialog);
        Destroy(gameObject);
        // audio.clip = otherClip;
        // audio.Play();
    }
}
