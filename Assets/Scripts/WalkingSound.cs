using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    private AudioSource sound;

    //Play the music
    [HideInInspector] public bool walkingSoundPlay;
    //Detect when you use the toggle, ensures music isn¡¦t played multiple times
    [HideInInspector] public bool walkingSoundToggleChange;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        sound = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        walkingSoundPlay = false;
        walkingSoundToggleChange = false;
    }

    void Update()
    {
        //Check to see if you just set the toggle to positive
        if (walkingSoundPlay == true && walkingSoundToggleChange == true)
        {
            //Play the audio you attach to the AudioSource component
            sound.Play();
            //Ensure audio doesn¡¦t play more than once
            walkingSoundToggleChange = false;
        }
        //Check if you just set the toggle to false
        if (walkingSoundPlay == false && walkingSoundToggleChange == true)
        {
            //Stop the audio
            sound.Stop();
            //Ensure audio doesn¡¦t play more than once
            walkingSoundToggleChange = false;
        }
    }
}
