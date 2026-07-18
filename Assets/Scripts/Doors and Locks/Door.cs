using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Keyitem
{
    [SerializeField] private bool locked = false;
    [SerializeField] private TextAsset textFile;
    [HideInInspector] public string[] dialog;
    [SerializeField] private LockStrategy lockStrategy;
    public ItemData keyCardData;

    private new Collider2D collider;
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        if (!locked)
        {
            OpenDoor();
            return;
        }
        lockStrategy.StartUnlock(this);
    }
    public override void EndKeyitemEvent()
    {
        collider.enabled = true;
    }

    private IEnumerator PlayAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }

    public void UnlockDoor()
    {
        locked = false;
    }
    public void OpenDoor()
    {
        collider.enabled = false;
        animator.SetTrigger("doorIsOpened");
        StartCoroutine(PlayAudio());
    }
}
