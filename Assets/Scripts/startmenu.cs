using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject image;
    [SerializeField] GameObject setting;
    public void Start()
    {
        image.SetActive(false);
        setting.SetActive(false);
        Manager.Instance.actionMapPlayer.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Startgame()
    {
        image.SetActive(false);
        Manager.Instance.Startmenu.SetActive(false);
        Manager.Instance.actionMapPlayer.Enable();
    }
    public void Tutorial()
    {
        image.SetActive(true);
    }
    public void Setting()
    {
        setting.SetActive(true);
    }
    public void Back() 
    {
        setting.SetActive(false);
    }
}
