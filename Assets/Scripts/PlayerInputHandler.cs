using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool JumpTriggered { get; private set; }



    // InputSystem
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    // InputSystem
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            JumpTriggered = true;
    }

    public void ConsumeJump()
    {
        JumpTriggered = false;
    }
}
