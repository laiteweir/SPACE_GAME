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
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
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
    }

    private IEnumerator TryUnlock()
    {
        controller.enabled = false;
        codePanel.SetActive(true);
        while (true)
        {
            
            yield return new WaitUntil(codePanel.GetComponent<CodePanel>().GetDoorOpen);
            codePanel.SetActive(false);
            controller.enabled = true;
        }
    }
}
