using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackManager : MonoBehaviour
{

    // cache
    private Animator anim;

    // scripts
    private PlayerMovementManager playerMovementManager;

    [Header("States")]
    public bool isAttacking;

    [Header("Input Actions")]
    [SerializeField] private InputAction inputAttack;


    private void OnEnable()
    {
        inputAttack.Enable();
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerMovementManager = GetComponent<PlayerMovementManager>();
    }


    private void Update()
    {
        OnStartAttack();
        HandleAnimations();
    }

    private void OnStartAttack()
    {
        if (inputAttack.IsPressed())
        {
            Debug.Log("Attack");
            // change state
            playerMovementManager.isIdle = false;
            playerMovementManager.isWalking = false;
            playerMovementManager.isRunning = false;
            //isAttacking = true;
        }
    }

    private void HandleAnimations()
    {
        anim.SetBool("isAttacking", isAttacking);
    }



}
