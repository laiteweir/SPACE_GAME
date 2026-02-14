using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : Keyitem
{
    public bool locked = false;
    [SerializeField] bool lockedByPassword = false;
    [SerializeField] bool lockedByKeycard = false;
    [SerializeField] string keycardName;
    [SerializeField] TextAsset textFile;

    new Collider2D collider;
    Animator animator;
    private string[] dialog;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        if (locked)
        {
            Manager.Instance.dialogBoxUI.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
        }
        else if (lockedByPassword)
        {
            StartCoroutine(TryUnlockWithPassword());
        }
        else if (lockedByKeycard)
        {
            TryUnlockWithKeycard(Manager.Instance.myBag);
        }
        else
        {
            collider.enabled = false;
            animator.SetTrigger("doorIsOpened");
            StartCoroutine(PlayAudio());
        }
    }

    public override void EndKeyitemEvent()
    {
        collider.enabled = true;
        lockedByPassword = false;
        lockedByKeycard = false;
    }

    private IEnumerator TryUnlockWithPassword()
    {
        Manager.Instance.codePanel.GetComponent<CodePanel>().OpenCodePanel();
        while (true)
        {
            if (!Manager.Instance.codePanel.activeSelf)
            {
                Manager.Instance.codePanel.GetComponent<CodePanel>().Clear();
                yield break;
            }
            else if (Manager.Instance.codePanel.GetComponent<CodePanel>().GetDoorOpen())
            {
                Manager.Instance.uiManager.Back();
                collider.enabled = false;
                animator.SetTrigger("doorIsOpened");
                StartCoroutine(PlayAudio());
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }

    private void TryUnlockWithKeycard(Inventory bag)
    {
        for (int i = 0; i < bag.itemList.Count; ++i)
        {
            if (bag.itemList[i].itemName == keycardName)
            {
                collider.enabled = false;
                animator.SetTrigger("doorIsOpened");
                StartCoroutine(PlayAudio());
                return;
            }
        }
        Debug.Log("You don't have the keycard!");
    }

    private IEnumerator PlayAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }
}
