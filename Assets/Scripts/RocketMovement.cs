using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private bool _isBoosted;
    private readonly float SPEED = 5f;
    private readonly float ROTATIONSPEED = 0.01f;


    private Quaternion rotation;
    public bool IsBoosted => _isBoosted;
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    public void ApplyMovement(Vector2 direction)
    {
        // TODO : 회전을 적용하고 이동을 적용함 -> 이에 대한 구현을 아래에서 진행할 것
        Rotate(direction);
         if (direction.y > 0)
         {
             Move();
         }
    }

    public void ApplyBoost(bool isPressed)
    {
        _isBoosted = isPressed;
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ;
        if (direction.x == 0)
        {
            rotZ = 0f;
        }
        else
        {
        //    rotZ = direction.x > 0 ? Mathf.Atan2(direction.y, direction.x) : Mathf.Atan2(direction.x, direction.y);
       //     rotZ *= -Mathf.Rad2Deg;
            rotZ = Mathf.Atan2( direction.y, direction.x) * Mathf.Rad2Deg;
            rotZ -= 90;
        }

        Debug.Log($"dir  {direction}  rot {rotZ}");
        rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void Move()
    {
        float boostSpeed = _isBoosted ? 3f : 1f;
       _rb2d.velocity = transform.up * (SPEED * boostSpeed);
    }   
    
    private void FixedUpdate()
    {
        Quaternion currentRot = transform.rotation;
        transform.rotation = Quaternion.Slerp(currentRot, rotation, ROTATIONSPEED);
    }
}