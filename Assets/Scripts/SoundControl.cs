using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource bgm;
    [SerializeField] Slider slider;
    void Start()
    {
        bgm.volume = 0.5f;
        slider.value = bgm.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VoiceChanged()
    {
        bgm.volume = slider.value;
    } 
}
