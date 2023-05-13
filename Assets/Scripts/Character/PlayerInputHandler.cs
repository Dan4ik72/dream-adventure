using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private CharacterMovement _movement;

    private void FixedUpdate()
    {
        GetMoveIpnut();
        TryGetJumpKey();
    }

    private void TryGetJumpKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _movement.Jump();
    }

    private void GetMoveIpnut()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        _movement.Move(direction);
    }
}
