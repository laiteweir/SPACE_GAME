using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] Image image;
    public float fadeTime = 5f;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        image.color = Color.Lerp(Color.black, Color.white, (Time.time - startTime) / fadeTime);
        if ((Time.time - startTime) >= fadeTime && Input.anyKeyDown)
        {
            Debug.Log("END!");
            Application.Quit();
        }
    }
}