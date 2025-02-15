using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] InputAction testInput;

    private void OnEnable()
    {
        testInput.Enable();
    }


    private void Update()
    {
        if (testInput.IsPressed())
        {
            Debug.Log("Input success");
        }
    }

}
