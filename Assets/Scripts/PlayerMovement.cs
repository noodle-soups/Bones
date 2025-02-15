using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    // cache
    private Rigidbody rb;

    // parameters
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSmoothing;
    private Vector2 movementVector;
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
    }


    private void FixedUpdate()
    {
        //TestInputAction();
        HandleMovement();
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
        movementVector = movementInput.ReadValue<Vector2>();

        // comput moveDirection
        moveDirection = new Vector3(movementVector.x, 0, movementVector.y);

        // execute move
        if (movementInput.IsPressed())
        {
            // rotate
            Quaternion _targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, rotationSmoothing * Time.fixedDeltaTime);

            // move forward
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        }
    }

}
