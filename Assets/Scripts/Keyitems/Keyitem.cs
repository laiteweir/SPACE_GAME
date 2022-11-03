using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyitem : MonoBehaviour
{
    public virtual void KeyitemEvent()
    {
        Debug.Log("Something is happening!");
    }

    public virtual void EndKeyitemEvent()
    {
        Debug.Log("Something has happened!");
    }
}
