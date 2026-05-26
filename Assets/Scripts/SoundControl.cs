using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    private void Start()
    {
        bgm.volume = 0.5f;
        slider.value = bgm.volume;
    }

    public void VoiceChanged()
    {
        bgm.volume = slider.value;
    } 
}
