using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static int winPoints = 4;
    private static int count = 0;

    // Update is called once per frame
    public static void AddPoints(int points)
    {
        count += points;
        if (count == winPoints)
        {
            Debug.Log("You win!");
        }
    }
}
