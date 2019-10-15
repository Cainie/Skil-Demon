
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float offset;

    public Rigidbody2D rb;
    public Camera cam;

    private Vector2 _movement;
    private Vector2 _mousePosition;
    

    // Update is called once per frame
    void Update(){
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + Time.deltaTime * movementSpeed * _movement);

        Vector2 lookDirection = _mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg - offset;
        rb.rotation = angle;
    }
}
