using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1EventSlime : MonoBehaviour
{
    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    [SerializeField] private GameObject slime;

    // Start is called before the first frame update
    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            slime.GetComponent<Room1EventSlimeMove>().isMoving = true;
            StartCoroutine(PlayAudio());
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

        Manager.Instance.DialogBox.StartTalk(dialog);
        Destroy(gameObject);
    }
}
