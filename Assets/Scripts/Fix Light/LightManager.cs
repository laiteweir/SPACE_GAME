using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Lights;
    public List<bool> answers;
    bool answer = false;

    // Update is called once per frame
    void Update()
    {
        if (!answer)
        {
            Check();
        }
    }
    private void Check()
    {
        int correct = 0;
        for (int i = 0; i < Lights.Count; ++i)
        {
            if (Lights[i].GetComponent<Switch>().is_on == answers[i])
            {
                ++correct;
            }
        }
        if (correct == Lights.Count)
        {
            answer = true;
            // correct = 0;
            Manager.Instance.returnKeyitem.EndKeyitemEvent();
        }
    }
}
