using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1_event_Slime : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] TextAsset textFile;
    //private TextAsset dialog01;
    private string[] dialog;
    public GameObject Slime;

    void Start()
    {
        //collider = GetComponent<Collider2D>();
        dialog = textFile.text.Split('\n');
        // this_event = GameObject.Find("Robot_01_event_01");
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if( col.gameObject.name == "Player"){
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            //this.first_trigger = false;
            Slime.GetComponent<Room1_event_SlimeMove>().is_move = true;
            StartCoroutine(PlayAudio());
            //Destroy(gameObject);
        }
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }    

    private IEnumerator PlayAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        Debug.Log("play audio");
        yield return new WaitForSeconds(audio.clip.length);
        Destroy(gameObject);
        // audio.clip = otherClip;
        // audio.Play();
    }
}
