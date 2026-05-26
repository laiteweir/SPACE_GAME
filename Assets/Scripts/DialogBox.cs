using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    private InputAction nextDialogAction;
    private bool moveNext = false;
    private bool endDialog = false;
    private int count;
    private string[] str;
    [SerializeField] private TMP_Text dialog;
    public bool TextIsOn = false;

    private void Awake()
    {
        nextDialogAction = Manager.Instance.PlayerInput.actions["UI/Submit"];
    }
    private void OnEnable()
    {
        nextDialogAction.performed += OnNextDialog;
    }
    private void OnDisable()
    {
        nextDialogAction.performed -= OnNextDialog;
    }

    private void OnNextDialog(InputAction.CallbackContext context)
    {
        // Debug.Log("get dialog length: " + str.GetLength(0).ToString());
        if (count < str.GetLength(0))
        {
            // string lines = str[count];
            // Text nextline.text = lines;
            moveNext = true;
        }
        else
        {
            endDialog = true;
        }
    }

    private IEnumerator Talk(Action OnEndDialog = null)
    {
        Manager.Instance.SwitchToUI();
        dialog.text = str[count];
        ++count;
        while (true)
        {
            if (moveNext)
            {
                moveNext = false;
                dialog.text = str[count];
                ++count;
                yield return null;
            }
            else if (endDialog)
            {
                endDialog = false;
                gameObject.SetActive(false);
                count = 0;
                dialog.text = string.Empty;
                Manager.Instance.SwitchToPlayer();
                OnEndDialog?.Invoke();
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }

    private IEnumerator TalkAndOpenScene(string sceneName, Keyitem keyitem, Action OnEndDialog = null)
    {
        yield return StartCoroutine(Talk(OnEndDialog));
        yield return Manager.Instance.StartCoroutine(Manager.Instance.OpenSceneRoutine(sceneName, keyitem));
    }
    private IEnumerator TalkAndOpenSceneUI(string sceneName, Keyitem keyitem, Action OnEndDialog = null)
    {
        yield return StartCoroutine(Talk(OnEndDialog));
        yield return Manager.Instance.StartCoroutine(Manager.Instance.OpenSceneUIRoutine(sceneName, keyitem));
    }

    public void StartTalk(string[] inputTxt, Action OnEndDialog = null)
    {
        str = inputTxt;
        gameObject.SetActive(true);
        StartCoroutine(Talk(OnEndDialog));
    }
    public void StartTalkAndOpenScene(string[] inputTxt, string sceneName, Keyitem keyitem, Action OnEndDialog = null)
    {
        str = inputTxt;
        gameObject.SetActive(true);
        Manager.Instance.StartCoroutine(TalkAndOpenScene(sceneName, keyitem, OnEndDialog));
    }
    public void StartTalkAndOpenSceneUI(string[] inputTxt, string sceneName, Keyitem keyitem, Action OnEndDialog = null)
    {
        str = inputTxt;
        gameObject.SetActive(true);
        Manager.Instance.StartCoroutine(TalkAndOpenSceneUI(sceneName, keyitem, OnEndDialog));
    }
}
