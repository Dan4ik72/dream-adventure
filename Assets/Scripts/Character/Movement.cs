using DialogueEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 55;
    [SerializeField] private float _stopSpeed = 1;
    [SerializeField] private Vector3 _limitVelocity = new Vector3(4f, 4f, 4f);
    [SerializeField] private float _visualModelRotationSpeed = 10f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _jumpSpeed = 75;
    [SerializeField] private float _jumpDownAcceleration = 200;

    [SerializeField] private Animator _charAnimator;

    private bool _isGrounded = false;
    private Rigidbody _rigidbody;
    private float _horizontalSpeed;
    private float _verticalSpeed;
    private Vector3 _targetSpeed;

    private Vector3 _prevVelocity;
    private bool _g;

    public bool IsMoving => _rigidbody.velocity != Vector3.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
        _charAnimator.SetBool("isRunning", false);
    }

    private void FixedUpdate()
    {

        if (_g == true)
        {
            _rigidbody.velocity = new Vector3(_prevVelocity.x, _rigidbody.velocity.y, _prevVelocity.z);
            _g = false;
        }

        _horizontalSpeed = Input.GetAxisRaw("Horizontal") * _speed;
        _verticalSpeed = Input.GetAxisRaw("Vertical") * _speed;

        Move();

        if (_rigidbody.velocity.y < 0f && _isGrounded == false)
        {
            _rigidbody.AddForce(-Vector3.up * _jumpDownAcceleration, ForceMode.Force);
        }

        _prevVelocity = _rigidbody.velocity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _isGrounded = true;
            _g = true;
            _charAnimator.SetBool("isGrounded", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _isGrounded = false;
        }
    }


    private void Jump()
    {
        if (_isGrounded == true)
        {
            _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);

            _charAnimator.SetBool("isGrounded", false);
        }
    }

    private void Move()
    {
        _targetSpeed = new Vector3(_horizontalSpeed * Time.fixedDeltaTime, 0f, _verticalSpeed * Time.fixedDeltaTime);

        if (_targetSpeed != Vector3.zero)
        {
            _rigidbody.velocity += _targetSpeed;
            LimitVelocity(_limitVelocity);

            Vector3 tar = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
            var angle = Quaternion.Euler(new Vector3(0, -Vector3.SignedAngle(tar, Vector3.forward, Vector3.up)));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, _visualModelRotationSpeed);
            _charAnimator.SetBool("isRunning", true);
        }
        else
        {
            Vector3 target = new Vector3(0, _rigidbody.velocity.y, 0);
            _rigidbody.velocity = Vector3.MoveTowards(_rigidbody.velocity, target, _stopSpeed);
            _charAnimator.SetBool("isRunning", false);
        }
    }

    private void LimitVelocity(Vector3 limit)
    {
        Vector2 vel = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.z);

        if (vel.magnitude > limit.magnitude)
        {
            vel = Vector2.ClampMagnitude(vel, limit.magnitude);
            _rigidbody.velocity = new Vector3(vel.x, _rigidbody.velocity.y, vel.y);
        }
    }
}