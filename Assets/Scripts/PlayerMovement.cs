using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    [SerializeField] private InputActionAsset actionsAsset;
    [SerializeField] private InputActionReference MovementAction;

    private CharacterController character;
    private Vector3 movement;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        character.SimpleMove(movement * (Speed * Time.deltaTime));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        movement = new Vector3(input.x, 0f, input.y);
    }
}
