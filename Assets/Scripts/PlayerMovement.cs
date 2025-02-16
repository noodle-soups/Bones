using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    // cache
    private Rigidbody rb;
    private GameObject playerChild;
    private Animator anim;

    [Header("States")]
    public bool isIdle;
    public bool isWalking;
    public bool isRunning;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSmoothing;
    private Vector3 moveDirection;
    private float xMoveAmount;
    private float zMoveAmount;

    // input actions
    [Header("Input Actions")]
    [SerializeField] private InputAction testInput;
    [SerializeField] private InputAction movementInput;

    private void OnEnable()
    {
        testInput.Enable();
        movementInput.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }


    private void FixedUpdate()
    {
        //TestInputAction();
        HandleMovement();
        HandleAnimations();

    }

    private void TestInputAction()
    {
        if (testInput.IsPressed())
        {
            Debug.Log("Input success");
        }
    }

    private void HandleMovement()
    {
        // read input
        Vector2 _movementVector = movementInput.ReadValue<Vector2>();

        // compute moveDirection
        xMoveAmount = _movementVector.x;
        zMoveAmount = _movementVector.y;
        moveDirection = new Vector3(xMoveAmount, 0, zMoveAmount);

        if (moveDirection == Vector3.zero)
        {
            isIdle = true;
            isWalking = false;
            isRunning = false;
        }

        // execute move
        if (movementInput.IsPressed())
        {
            isIdle = false;

            // apply walking logic
            float _walkMultiplier = Mathf.Clamp01(Mathf.Abs(xMoveAmount) + Mathf.Abs(zMoveAmount));
            if (_walkMultiplier > 0 && _walkMultiplier <= 0.9f)
            {
                _walkMultiplier = 0.5f;
                isWalking = true;
                isRunning = false;
            }
            else if (_walkMultiplier > 0.9f && _walkMultiplier <= 1)
            {
                _walkMultiplier = 1;
                isWalking = false;
                isRunning = true;
            }

            // rotate
            Quaternion _targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, rotationSmoothing * Time.fixedDeltaTime);

            // move forward
            transform.Translate(Vector3.forward * (moveSpeed * _walkMultiplier) * Time.fixedDeltaTime, Space.Self);

        }


    }


    private void HandleAnimations()
    {
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
    }

}
