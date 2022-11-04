using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTaskManager : MonoBehaviour
{
    public static WireTaskManager Instance;

    public Camera wireTaskCamera;
    private readonly int winPoints = 4;
    private int count = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddPoints(int points)
    {
        count += points;
        if (count == winPoints)
        {
            //Debug.Log("You win!");
            count = 0;
            Manager.Instance.returnKeyitem.EndKeyitemEvent();
        }
    }
}
