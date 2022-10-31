using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    public static InputActionMap actionMapPlayer;
    public static Keyitem returnKeyitem;
    void Awake()
    {
        actionMapPlayer = GameObject.Find("Player").GetComponent<PlayerInput>().actions.FindActionMap("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc");
            Pause.PManu.SetActive(true);
        }
    }

    public static void OpenScene(string name, Keyitem keyitem)
    {
        returnKeyitem = keyitem;
        actionMapPlayer.Disable();
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public static void CloseScene(string name)
    {
        SceneManager.UnloadSceneAsync(name);
        actionMapPlayer.Enable();
    }
}
