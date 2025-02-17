using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRb;
    private Vector2 _moveVector;
    private bool _isFacingRight;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _runSpeed;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed = _runSpeed;
        }

        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.y = Input.GetAxis("Vertical");

        if (_moveVector.x > 0.01f)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        else if (_moveVector.x < -0.01f)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        _playerRb.linearVelocity = _moveVector * _moveSpeed;
    }
}
