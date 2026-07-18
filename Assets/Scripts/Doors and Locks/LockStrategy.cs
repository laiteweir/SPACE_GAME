using UnityEngine;

public abstract class LockStrategy : ScriptableObject
{
    public abstract void StartUnlock(Door door);
}
