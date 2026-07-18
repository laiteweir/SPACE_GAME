using UnityEngine;
using UnityEngine.InputSystem;

public class WireTaskManager : BaseScene
{
    public static WireTaskManager Instance;

    public Camera wireTaskCamera;
    [HideInInspector] public InputAction pointAction;

    private readonly int winPoints = 4;
    private int count = 0;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        pointAction = Manager.Instance.PlayerInput.actions["UI/Point"];
    }

    public void AddPoint()
    {
        ++count;
        if (count == winPoints)
        {
            // Debug.Log("You win!");
            count = 0;
            Manager.Instance.room10.isEngine2Fixed = true;
            ExitScene();
        }
    }
}
