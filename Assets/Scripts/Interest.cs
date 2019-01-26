using UnityEngine;

public enum Need {
    WatchTV,
    Read,
    Toilet,
    Food,
    Games,
    Sleep,
    FreshAir,
    ListenRadio,
    None
}

[RequireComponent(typeof(Elderly))]
public class Interest : MonoBehaviour {
    [SerializeField] private float startHomefulness, homefulnessCap;
    public float Homefulness { get { return startHomefulness; } set { startHomefulness = startHomefulness <= homefulnessCap ? value : homefulnessCap; } }
    [SerializeField] private float homefullnessReduction;
    public float HomefulnessReduction { get { return homefullnessReduction; } }

    public Need CurrentNeed { get; private set; }
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [Range(0, 100)][SerializeField] private int chanceForANeed;
    private float elapsed;
    private Elderly me;
    private Transform exit;

    private void Awake() {
        me = GetComponent<Elderly>();
        exit = FindObjectOfType<Exit>().transform;
    }

    private void Start() {
        elapsed = Random.Range(0, maxTime);
    }

    private void FixedUpdate() {
        elapsed -= Time.fixedDeltaTime;
        if (elapsed <= 0) {
            if (chanceForANeed >= Random.Range(0, 100)) {
                CurrentNeed = (Need)Random.Range(0, (int)Need.ListenRadio);
                Debug.Log(transform.name + ": I need to " + CurrentNeed);
            }
            else CurrentNeed = Need.None;
            elapsed = Random.Range(minTime, maxTime);
        }
        if (CurrentNeed != Need.None) Homefulness -= homefullnessReduction;
        if (Homefulness <= 0) me.SetTarget(exit, TargetPriority.HIGH);
    }
}