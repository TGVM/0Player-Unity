using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isCurrentController = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        if (!isCurrentController) return;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    public void SetCurrentController(bool value){
        isCurrentController = value;
        spriteRenderer.enabled = value;
    }

}
