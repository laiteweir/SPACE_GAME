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

    public void StartTalk(string[] inputTxt)
    {
        str = inputTxt;
        StartCoroutine(Talk());
    }
    private IEnumerator Talk()
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
                dialog.text = "";
                
                //is_trigger = true;
                Manager.Instance.SwitchToPlayer();
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }

    public void StartTalkAndOpenScene(string[] inputTxt, string sceneName, Keyitem keyitem)
    {
        str = inputTxt;
        StartCoroutine(TalkAndOpenScene(sceneName, keyitem));
    }
    private IEnumerator TalkAndOpenScene(string sceneName, Keyitem keyitem)
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
                dialog.text = "";
                Manager.Instance.SwitchToPlayer();
                Manager.Instance.OpenScene(sceneName, keyitem);
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }

    public void StartTalkAndOpenSceneUI(string[] inputTxt, string sceneName, Keyitem keyitem)
    {
        str = inputTxt;
        StartCoroutine(TalkAndOpenSceneUI(sceneName, keyitem));
    }
    private IEnumerator TalkAndOpenSceneUI(string sceneName, Keyitem keyitem)
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
                dialog.text = "";
                // Manager.Instance.SwitchToPlayer();
                Manager.Instance.OpenScene(sceneName, keyitem);
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
}
