using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Movement playerCharacter;
    [SerializeField] private InputActionAsset inputActions;
    private InputAction move;
    private InputAction jump;
    private InputAction grapple;

    public Movement PlayerCharacter { get { return playerCharacter; } }

    private void Awake()
    {
        move = inputActions.FindAction("Move");
        jump = inputActions.FindAction("Jump");
        grapple = inputActions.FindAction("Grapple");
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        Vector2 inputMove = move.ReadValue<Vector2>();
        playerCharacter.InputMove = inputMove.normalized;
        playerCharacter.InputJump = jump.IsPressed();
        playerCharacter.InputGrapple = grapple.IsPressed();
    }
}