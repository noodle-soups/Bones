using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    // components
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Transform tr;

    // scripts
    [SerializeField] private PlayerData playerData;

    //  states
    public PlayerBaseState currentState;
    public PlayerIdleState idleState;
    public PlayerRunningState runningState;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        idleState = new PlayerIdleState();
        runningState = new PlayerRunningState(playerData);
    }

    private void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    public void ChangeState(PlayerBaseState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
            currentState.EnterState(this);
        }
    }

}
