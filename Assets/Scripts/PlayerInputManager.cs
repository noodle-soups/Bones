using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{

    // singleton
    public static PlayerInputManager Instance { get; private set; }

    // input actions
    [Header("Input Actions")]
    [SerializeField] public InputAction movement;
    [SerializeField] public InputAction inputTest1;
    [SerializeField] public InputAction inputTest2;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void OnEnable()
    {
        movement.Enable();
        inputTest1.Enable();
        inputTest2.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        inputTest1.Disable();
        inputTest2.Disable();
    }

}
