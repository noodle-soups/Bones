using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementManager : MonoBehaviour
{

    // cache
    private Rigidbody rb;
    private Animator anim;

    // scripts
    private PlayerInputManager playerInputManager;

    [Header("States")]
    public bool isIdle;
    public bool isWalking;
    public bool isRunning;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private float moveSpeedMultiplier = 1;
    [SerializeField] private float rotationSmoothing;
    private Vector3 moveDirection;
    private float xMoveAmount;
    private float zMoveAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleStates();
        HandleAnimations();
    }

    private void HandleMovement()
    {
        // read input
        Vector2 _movementVector = playerInputManager.movement.ReadValue<Vector2>();

        // compute moveDirection
        xMoveAmount = _movementVector.x;
        zMoveAmount = _movementVector.y;
        moveDirection = new Vector3(xMoveAmount, 0, zMoveAmount);

        // clamp walking & running
        float _walkSpeedThreshold = Mathf.Clamp01(Mathf.Abs(xMoveAmount) + Mathf.Abs(zMoveAmount));
        if (_walkSpeedThreshold > 0 && _walkSpeedThreshold <= 0.9f)
            moveSpeedMultiplier = 0.5f;
        else if (_walkSpeedThreshold > 0.9f && _walkSpeedThreshold <= 1)
            moveSpeedMultiplier = 1;

        // on move start
        if (moveDirection.sqrMagnitude > 0.01f)
            OnMovementStart();
    }

    private void OnMovementStart()
    {
        // rotate
        Quaternion _targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, rotationSmoothing * Time.fixedDeltaTime);

        // move forward
        transform.Translate(Vector3.forward * (moveSpeed * moveSpeedMultiplier) * Time.fixedDeltaTime, Space.Self);
    }

    private void HandleStates()
    {
        if (moveDirection.sqrMagnitude <= 0.01f)
        {
            isIdle = true;
            isWalking = !isIdle;
            isRunning = !isIdle;
        }
        else if (moveDirection.sqrMagnitude > 0.01f)
        {
            isIdle = false;
            if (moveSpeedMultiplier == 0.5f)
            {
                isWalking = true;
                isRunning = false;
            }
            else if (moveSpeedMultiplier == 1)
            {
                isWalking = false;
                isRunning = true;
            }
        }
    }

    private void HandleAnimations()
    {
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
    }

}
