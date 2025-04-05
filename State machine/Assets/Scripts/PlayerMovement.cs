using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    public void Move(Vector2 direction)
    {
        if (direction.magnitude > 0)
            rb.velocity = direction.normalized * moveSpeed;
        else
            rb.velocity = Vector2.zero;
    }
}