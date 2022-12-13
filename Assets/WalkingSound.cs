using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    private AudioSource sound;

    //Play the music
    [HideInInspector] public bool m_Play;
    //Detect when you use the toggle, ensures music isn¡¦t played multiple times
    [HideInInspector] public bool m_ToggleChange;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        sound = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        m_Play = false;
        m_ToggleChange = false;
    }

    void Update()
    {
        //Check to see if you just set the toggle to positive
        if (m_Play == true && m_ToggleChange == true)
        {
            //Play the audio you attach to the AudioSource component
            sound.Play();
            //Ensure audio doesn¡¦t play more than once
            m_ToggleChange = false;
        }
        //Check if you just set the toggle to false
        if (m_Play == false && m_ToggleChange == true)
        {
            //Stop the audio
            sound.Stop();
            //Ensure audio doesn¡¦t play more than once
            m_ToggleChange = false;
        }
    }
}
