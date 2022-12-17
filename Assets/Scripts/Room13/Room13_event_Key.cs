using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room13_event_Key : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextAsset textFile;
    //private TextAsset dialog01;
    private string[] dialog;
    public GameObject Captain;
    public GameObject slime;
    //public bool destroy = false;
    private bool trigger_first = true;
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if( col.gameObject.name == "Player"){
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            trigger_first = false;
        }
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    } 
    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.dialogBox.TextIsOn == false && trigger_first == false){
            slime.GetComponent<Slime_boss_move>().is_move = true;
            slime.SetActive(true);
            Destroy(Captain.gameObject);
        }
    }

    // private IEnumerator PlayAudio()
    // {
    //     AudioSource audio = GetComponent<AudioSource>();

    //     audio.Play();
    //     Debug.Log("play audio");
    //     yield return new WaitForSeconds(audio.clip.length);
    //     Manager.Instance.ui.SetActive(true);
    //     Manager.Instance.dialogBox.TextIsOn = true;
    //     Manager.Instance.dialogBox.StartTalk(dialog);
    //     Destroy(gameObject);
    //     // audio.clip = otherClip;
    //     // audio.Play();
    // }
}
