using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        bgm.volume = 0.5f;
        slider.value = bgm.volume;
    }
    public void VoiceChanged()
    {
        bgm.volume = slider.value;
    } 
}
