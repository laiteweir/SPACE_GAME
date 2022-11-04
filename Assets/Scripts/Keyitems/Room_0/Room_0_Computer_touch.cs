using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room_0_Computer_touch : Keyitem
{
    //new Collider2D collider;
    [SerializeField] GameObject computer_light;
    private TextAsset dialog01;
    private string[] dialog;

    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
        TextAsset textFile = (TextAsset)Resources.Load("Room_0_Computer_touch");
        Debug.Log(textFile);
        // dialog01 = Resources.Load<TextAsset>("Room_0_Computer_touch.txt");
        dialog = textFile.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //     Debug.Log("x");
        // }
    }
    public override void KeyitemEvent()
    {
        computer_light.GetComponent<Light2D>().color = Color.green;
        // Debug.Log("touch robot 01 in room 0");
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
