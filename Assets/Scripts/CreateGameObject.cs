using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject objToSpawn;
    public GameObject target;
    bool generate_card = true;
    public GameObject Source;
    void Start()
    {
        //  objToSpawn.AddComponent<BoxCollider>();
        //  objToSpawn.AddComponent<SpriteRenderer>();
        //  objToSpawn.AddComponent<Transform>();
        //  objToSpawn.AddComponent<ScriptableObject>("ItemOnWorld.cs"); 
         
    }
    void Update(){
        // if(Source.GetComponent<DialogBox>().is_trigger && generate_card){
        //     // CreateObject();
        //     generate_card = false;
        // }
    }

    // Update is called once per frame
    public void CreateObject()
    {
        objToSpawn = Instantiate(target);
        // objToSpawn.GetComponent<SpriteRenderer>().sprite = target.GetComponent<SpriteRenderer>().sprite;
        // objToSpawn.GetComponent<SpriteRenderer>().sortingOrder= target.GetComponent<SpriteRenderer>().sortingOrder;
        // objToSpawn.GetComponent<Transform>().position= target.GetComponent<Transform>().position;
        // objToSpawn.GetComponent<Transform>().localScale= target.GetComponent<Transform>().localScale;
        return;
    }

}
