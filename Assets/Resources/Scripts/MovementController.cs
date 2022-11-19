using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    public int Speed;

    private Rigidbody2D Rigidbody;
    private Vector2 Direction;

    public void OnMove(InputAction.CallbackContext context)
    {
        Direction = context.ReadValue<Vector2>();
    }

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Rigidbody.position = (new Vector2(transform.position.x, transform.position.y) + Speed * Time.deltaTime * Direction);
    }
}
