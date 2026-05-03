using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    private AudioSource sound;

    // Start is called before the first frame update
    private void Start()
    {
        // Fetch the AudioSource from the GameObject
        sound = GetComponent<AudioSource>();
    }

    public void PlayWalkingSound()
    {
        if (!sound.isPlaying)
        {
            // Play the audio you attach to the AudioSource component
            sound.Play();
        }
    }
    public void StopWalkingSound()
    {
        if (sound.isPlaying)
        {
            // Stop the audio
            sound.Stop();
        }
    }
}
