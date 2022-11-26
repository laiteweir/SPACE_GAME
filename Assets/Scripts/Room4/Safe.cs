using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : Keyitem
{
    // Start is called before the first frame update
    private bool keepTrying = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void KeyitemEvent()
    {
        StartCoroutine(TryUnlockWithPassword());
    }

    public override void EndKeyitemEvent()
    {

    }

    private IEnumerator TryUnlockWithPassword()
    {
        Manager.Instance.actionMapPlayer.Disable();
        Manager.Instance.codePanel.SetActive(true);
        while (true)
        {
        if (!keepTrying)
        {
            keepTrying = true;
            Manager.Instance.codePanel.SetActive(false);
            Manager.Instance.actionMapPlayer.Enable();
            yield break;
        }
        else if (Manager.Instance.codePanel.GetComponent<CodePanel>().GetDoorOpen())
        {
            Manager.Instance.codePanel.SetActive(false);
            Manager.Instance.actionMapPlayer.Enable();
            
            yield break;
        }
        else if (Input.GetKeyDown("X"))
        {
            Manager.Instance.codePanel.SetActive(false);
            Manager.Instance.actionMapPlayer.Enable();
        }
        else
        {
            yield return null;
        }
        }
    }
}
