using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Keyitem
{
    [SerializeField] bool lockedByPassword = false;
    [SerializeField] PlayerController controller;
    [SerializeField] GameObject codePanel;

    new Collider2D collider;
    Animator animator;
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            //Debug.Log("I give up!");
            keepTrying = false;
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
        controller.enabled = false;
        codePanel.SetActive(true);
        while (true)
        {
            if (!keepTrying)
            {
                codePanel.SetActive(false);
                controller.enabled = true;
                yield break;
            }
            else if (codePanel.GetComponent<CodePanel>().GetDoorOpen())
            {
                codePanel.SetActive(false);
                controller.enabled = true;
                collider.enabled = false;
                animator.SetTrigger("doorIsOpened");
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
}
