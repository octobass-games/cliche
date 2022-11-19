using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    public int Speed;
    public Animator Animator;
    public SpriteRenderer SpriteRenderer;

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

    void Update()
    {
        var notMoving = Direction == Vector2.zero;
        var right = Direction == Vector2.right || Direction == Vector2.zero;

        Animator.SetBool("Run", !notMoving);
        SpriteRenderer.flipX = !right;
    }

    void FixedUpdate()
    {
        Rigidbody.position = (new Vector2(transform.position.x, transform.position.y) + Speed * Time.deltaTime * Direction);
    }
}
