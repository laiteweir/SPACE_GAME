using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Keyitem : MonoBehaviour
{
    public abstract void KeyitemEvent();
    // {
    //     Debug.Log("Something is happening!");
    // }

    public virtual void EndKeyitemEvent()
    {
        Debug.Log("Something has happened!");
    }
}
