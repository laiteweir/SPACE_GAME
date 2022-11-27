using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNine : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<string, bool> items = new Dictionary<string, bool>();
    void Start()
    {
        items.Add("RedFlower",false);
        items.Add("YellowLeaf",false);
        items.Add("Hair",false);
        items.Add("WhiteJar",false);
        items.Add("Folder",false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool setItem(string itemName){
        bool result = false;
        int dirCount = items.Count;
        int trueCount = 0;
        if(items.ContainsKey(itemName)){
            items[itemName] = true;
        }
        foreach(KeyValuePair<string, bool> kvp in items ){
            if (kvp.Value == true){
                trueCount = trueCount +1;
            }
        }
        if(trueCount == dirCount){
            result = true;
        }
        
        return result;
    }
    public bool itemsAreDone(){
        bool result = false;
        int dirCount = items.Count;
        int trueCount = 0;
        foreach(KeyValuePair<string, bool> kvp in items ){
            if (kvp.Value == true){
                trueCount = trueCount +1;
            }
        }
        if(trueCount == dirCount){
            result = true;
        }
        return result;
    }
}
