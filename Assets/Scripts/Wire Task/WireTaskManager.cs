using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTaskManager : MonoBehaviour
{
    private static readonly int winPoints = 4;
    private static int count = 0;
    public static Camera wireTaskCamera;

    private void Awake()
    {
        wireTaskCamera = GameObject.Find("WireTaskCamera").GetComponent<Camera>();
    }

    public static void AddPoints(int points)
    {
        count += points;
        if (count == winPoints)
        {
            //Debug.Log("You win!");
            count = 0;
            Manager.returnKeyitem.EndKeyitemEvent();
        }
    }
}
