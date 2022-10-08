using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Keyitem
{
    [SerializeField] bool switchControl = false;
    [SerializeField] PlayerController controller;

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
        collider.enabled = false;
        animator.SetTrigger("doorIsOpened");
        if (switchControl)
        {
            controller.enabled = false;
        }
    }

    public override void EndKeyitemEvent()
    {
        collider.enabled = true;
        if (switchControl)
        {
            controller.enabled = true;
        }
    }
}