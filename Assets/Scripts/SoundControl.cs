using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource bgm;
    void Start()
    {
        bgm.volume = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VoiceChanged(float newvolumn) 
    {
        bgm.volume = newvolumn;
        Debug.Log(newvolumn);
    } 
}
