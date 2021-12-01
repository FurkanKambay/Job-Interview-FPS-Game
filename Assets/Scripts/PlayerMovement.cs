using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    private CharacterController character;
    private Vector2 movement;

    private void Awake() => character = GetComponent<CharacterController>();

    private void Update()
    {
        Vector3 lateralVelocity = transform.TransformVector(movement.x, 0f, movement.y);
        character.SimpleMove(lateralVelocity * (Speed * Time.deltaTime));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // if (context.performed)
            movement = context.ReadValue<Vector2>();
        // else if (context.canceled)
        //     movement = Vector2.zero;
    }
}
