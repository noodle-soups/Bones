using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    // components
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Transform tr;

    // scripts
    [HideInInspector] public PlayerAnimationManager anim;

    // scriptable objects
    [SerializeField] private PlayerData playerData;

    //  states
    public PlayerBaseState currentState;
    public PlayerIdleState idleState;
    public PlayerRunningState runningState;
    public PlayerAttackingState attackingState;


    private void Awake()
    {
        // components
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        // scripts
        anim = GetComponent<PlayerAnimationManager>();

        // states
        idleState = new PlayerIdleState();
        runningState = new PlayerRunningState(playerData);
        attackingState = new PlayerAttackingState();
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
            currentState.ExitState(this);
            currentState = newState;
            currentState.EnterState(this);
        }
    }

}
