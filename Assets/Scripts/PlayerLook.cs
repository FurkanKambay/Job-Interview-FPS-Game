using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float LookSensitivity;

    [SerializeField] new Transform camera;
    private float cameraTilt;

    private void OnEnable() => Cursor.lockState = CursorLockMode.Locked;
    private void OnDisable() => Cursor.lockState = CursorLockMode.None;

    public void OnLook(InputAction.CallbackContext context)
    {
        if (!enabled) return;

        Vector2 input = context.ReadValue<Vector2>();

        Transform player = transform;
        player.Rotate(Vector3.up, input.x * LookSensitivity * Time.deltaTime);

        if (player.eulerAngles != transform.eulerAngles)
            Debug.Break();

        float lookDelta = input.y * LookSensitivity * Time.deltaTime;
        cameraTilt = Mathf.Clamp(cameraTilt - lookDelta, -90f, 90f);

        Vector3 targetEuler = player.eulerAngles;
        targetEuler.x = cameraTilt;
        camera.eulerAngles = targetEuler;
    }
}
