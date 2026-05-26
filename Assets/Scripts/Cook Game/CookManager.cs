using UnityEngine;

public class CookManager : BaseScene
{
    public static CookManager Instance;
    private bool cooked = false;
    private bool burnt = false;
    private bool undercooked = false;
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject cookedFood;
    [SerializeField] private GameObject upwardFire;
    [SerializeField] private GameObject downwardFire;

    public bool Cooked { get => cooked; set => cooked = value; }
    public bool Burnt { get => burnt; set => burnt = value; }
    public bool Undercooked { get => undercooked; set => undercooked = value; }
    public GameObject Food { get => food; }
    public GameObject CookedFood { get => cookedFood; }
    public GameObject UpwardFire { get => upwardFire; }
    public GameObject DownwardFire { get => downwardFire; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // Debug.Log(Cooked);
        // Debug.Log(Burnt);
        // Debug.Log(Undercooked);
    }
}
