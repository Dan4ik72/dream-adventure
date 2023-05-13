using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotationSpeed = 10f;

    [SerializeField] GroundTrigger _groundTrigger;

    private readonly Vector3 _velocityLimit = new Vector3(4f, 4f, 4f);

    private Rigidbody _rigidbody;

    private float _stopTime = 2f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 direction)
    {
        if(direction != Vector2.zero)
        {
            Vector3 targetSpeed = new Vector3(direction.x * _moveSpeed * Time.fixedDeltaTime, 0, direction.y * _moveSpeed * Time.fixedDeltaTime);

            _rigidbody.velocity += targetSpeed;

            LimitVelocity();

            Rotate();
        }
        else
        {
            _rigidbody.velocity = Vector3.MoveTowards(_rigidbody.velocity, new Vector3(0 , _rigidbody.velocity.y, 0), _stopTime);
        }
    }

    public void Jump()
    {
        if(_groundTrigger.IsGrounded)
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
    }

    private void LimitVelocity()
    {
        if (_rigidbody.velocity.magnitude > _velocityLimit.magnitude)
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _velocityLimit.magnitude);
    }

    private void Rotate()
    {
        var angle = Quaternion.Euler(new Vector3(0, -Vector3.SignedAngle(_rigidbody.velocity, Vector3.forward, Vector3.up)));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, _rotationSpeed);
    }
}
