using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room10_event_01 : MonoBehaviour
{
    [SerializeField] TextAsset textFile;
    private string[] dialog;
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    void Update()
    {
        if (Manager.Instance.player.transform.position.y < -14f)
        {
            // Manager.Instance.room10.engine0_Light.enabled = true;
            // Manager.Instance.room10.engine1_Light.enabled = true;
            // Manager.Instance.room10.refillStation_Light.enabled = true;
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            Manager.Instance.room10.room10_event_01.SetActive(false);
            Manager.Instance.room10.room10_event_02.SetActive(true);
            Destroy(this);
        }
    }
}
