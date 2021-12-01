using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float LookSensitivity;

    [SerializeField] new Transform camera;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        transform.Rotate(Vector3.up, input.x * LookSensitivity * Time.deltaTime);
        camera.Rotate(Vector3.left, input.y * LookSensitivity * Time.deltaTime);
    }
}
