using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Keyitem
{
    public bool locked = false;
    [SerializeField] bool lockedByPassword = false;
    [SerializeField] bool lockedByKeycard = false;
    [SerializeField] string keycardName;
    [SerializeField] TextAsset textFile;

    new Collider2D collider;
    Animator animator;
    private bool isTryingOpen = false;
    private bool keepTrying = true;
    private string[] dialog;
    
    //public AudioClip otherClip;
    // public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        dialog = textFile.text.Split('\n');
        //source = GetComponent<AudioSource>();
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
        if (locked)
        {
            Manager.Instance.ui.SetActive(true);
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
                StartCoroutine(PlayAudio());
                isTryingOpen = false;
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
        // audio.clip = otherClip;
        // audio.Play();
    }
}
