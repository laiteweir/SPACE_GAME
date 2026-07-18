using UnityEngine;
using UnityEngine.UI;

public class BossFightManager : BaseScene
{
    public static BossFightManager Instance;

    [HideInInspector] public PaddleController paddleController;
    [SerializeField] private Slider playerSlider;
    [SerializeField] private Slider bossSlider;
    [SerializeField] private ItemData shieldData;
    [SerializeField] private GameObject shield;
    public int playerHealth = 5;
    public int bossHealth = 3;

    protected override void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        exitAction = Manager.Instance.PlayerInput.actions["BossFight/Exit"];
        paddleController = Manager.Instance.Player.GetComponent<PaddleController>();
    }
    protected override void OnEnable()
    {
        exitAction.performed += OnExitScene;
    }
    protected override void OnDisable()
    {
        exitAction.performed -= OnExitScene;
    }

    // Start is called before the first frame update
    private void Start()
    {
        int shieldIndex = Manager.Instance.InventoryManager.FindIndexOfItem(shieldData);
        if (shieldIndex != -1)
        {
            playerHealth = 10;
            shield.SetActive(true);
        }
        playerSlider.maxValue = playerHealth;
        bossSlider.maxValue = bossHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        playerSlider.value = playerHealth;
        bossSlider.value = bossHealth;
        if (bossHealth == 0)
        {
            Manager.Instance.room13.isBossDefeated = true;
            ExitScene();
        }
        else if (playerHealth == 0)
        {
            ExitScene();
        }
    }
}
