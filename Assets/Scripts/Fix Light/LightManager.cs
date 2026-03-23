using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : BaseScene
{
    [SerializeField] List<GameObject> lights;
    public List<bool> answers;
    private bool isCorrect = false;
    // [SerializeField] GameObject result;

    // Update is called once per frame
    void Update()
    {
        if (!isCorrect)
        {
            Check();
        }
    }

    private void Check()
    {
        int correct = 0;
        for (int i = 0; i < lights.Count; ++i)
        {
            if (lights[i].GetComponent<Switch>().isOn == answers[i])
            {
                ++correct;
            }
        }
        if (correct == lights.Count)
        {
            isCorrect = true;
            // correct = 0;
            Manager.Instance.room1.turnOnLight = true;
            SceneExit();
        }
    }
}
