using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Lights;
    public List<bool> answers;
    bool answer = false;
    [SerializeField] GameObject result;

    // Update is called once per frame
    void Update()
    {
        if (!answer)
        {
            Check();
        }
        if(Input.GetKeyDown(KeyCode.X))
            backScene();
    }
    void backScene(){
        Manager.Instance.returnKeyitem.EndKeyitemEvent();
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
            Room_1Data.turn_on_light = true;
            Manager.Instance.returnKeyitem.EndKeyitemEvent();
        }
    }
}
