using UnityEngine;

public class Room13Event2 : Keyitem
{
    public override void KeyitemEvent()
    {
        Manager.Instance.OpenSceneBossFight("Boss Fight", this);
    }
    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseSceneBossFight("Boss Fight");
        if (Manager.Instance.room13.isBossDefeated)
        {
            transform.parent.gameObject.SetActive(false);
            Manager.Instance.room13.OnBossDefeated();
        }
    }
}
