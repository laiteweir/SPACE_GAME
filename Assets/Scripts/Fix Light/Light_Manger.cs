using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Manger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> Lights;
    public List<bool> answers;
    bool answer = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!answer)
            check();
    }
    void check(){
        int correct =0;
        for(int i=0 ;i< Lights.Count ;i++){
            if(Lights[i].GetComponent<Switch>().is_on == answers[i]){
                    correct++;
            }
        }
        if(correct == Lights.Count){
            answer = true;
            Debug.Log("correct");
        }
    }
}
