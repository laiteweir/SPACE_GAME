using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room10_event_02 : MonoBehaviour
{
    [SerializeField] Item hintMap;
    [SerializeField] Door nextDoor;
    [SerializeField] TextAsset textFile;
    private string[] dialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.room10.isEngine0Fixed && Manager.Instance.room10.isEngine1Fixed && !Manager.Instance.dialogBox.TextIsOn)
        {
            // Debug.Log("You have fixed both engines!");
            Manager.Instance.room10.room10_bigLight.enabled = true;
            Manager.Instance.room2.room2_bigLight.enabled = true;
            hintMap.itemHeld = 0;
            nextDoor.locked = false;
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            Manager.Instance.room10.room10_event_02.SetActive(false);

            Destroy(this);
        }
    }
}
