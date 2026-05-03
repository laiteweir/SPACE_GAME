using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSeven : MonoBehaviour
{
    [SerializeField] private List<GameObject> aliens;

    public List<GameObject> Aliens { get => aliens; }

    public void ActiveAliens()
    {
        foreach (GameObject alien in Aliens)
        {
            alien.SetActive(true);
        }
    }
    public void DeactiveAliens()
    {
        foreach (GameObject alien in Aliens)
        {
            alien.SetActive(false);
        }
    }

}
