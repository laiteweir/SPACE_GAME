using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : BaseScene
{
    public static LightManager Instance;
    [SerializeField] private List<GameObject> lights;
    public List<bool> answers;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Check()
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
            Manager.Instance.room1.TurnOnLight();
            ExitScene();
        }
    }
}
