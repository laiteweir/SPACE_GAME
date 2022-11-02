using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Keyitem
{
    [SerializeField] bool lockedByPassword = false;

    new Collider2D collider;
    Animator animator;
    private bool isTryingOpen = false;
    private bool keepTrying = true;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && isTryingOpen)
        {
            //Debug.Log("I give up!");
            keepTrying = false;
            Manager.Instance.codePanel.GetComponent<CodePanel>().Clear();
        }
    }

    public override void KeyitemEvent()
    {
        if (lockedByPassword)
        {
            StartCoroutine(TryUnlock());
        }
        else
        {
            collider.enabled = false;
            animator.SetTrigger("doorIsOpened");
        }
    }

    public override void EndKeyitemEvent()
    {
        collider.enabled = true;
        lockedByPassword = false;
    }

    private IEnumerator TryUnlock()
    {
        isTryingOpen = true;
        Manager.Instance.actionMapPlayer.Disable();
        Manager.Instance.codePanel.SetActive(true);
        while (true)
        {
            if (!keepTrying)
            {
                keepTrying = true;
                Manager.Instance.codePanel.SetActive(false);
                Manager.Instance.actionMapPlayer.Enable();
                isTryingOpen = false;
                yield break;
            }
            else if (Manager.Instance.codePanel.GetComponent<CodePanel>().GetDoorOpen())
            {
                Manager.Instance.codePanel.SetActive(false);
                Manager.Instance.actionMapPlayer.Enable();
                collider.enabled = false;
                animator.SetTrigger("doorIsOpened");
                isTryingOpen = false;
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
}
