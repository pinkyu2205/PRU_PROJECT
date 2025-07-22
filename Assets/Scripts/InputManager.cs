using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    private InputAction _mousePositionAction;
    private InputAction _mouseAction;

    public static Vector2 MousePosition;

    public static bool WasLeftMousebuttonPressed;
    public static bool WasLeftMousebuttonReleased;
    public static bool IsLeftMousePressed;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        _mousePositionAction = PlayerInput.actions["MousePosition"];
        _mouseAction = PlayerInput.actions["Mouse"];
    }

    private void Update()
    {
        MousePosition = _mousePositionAction.ReadValue<Vector2>();

        WasLeftMousebuttonPressed = _mouseAction.WasPressedThisFrame();
        WasLeftMousebuttonReleased = _mouseAction.WasReleasedThisFrame();
        IsLeftMousePressed = _mouseAction.IsPressed();
    }
}
