﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovementC : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private readonly float SPEED = 10f;
    private readonly float ROTATIONSPEED = 0.02f;

    private float highScore = -1;

    public static Action<float> OnHighScoreChanged;

    private Quaternion _rotation;
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        if (_rotation != Quaternion.Euler(0, 0, 0))
        {
            Quaternion currentRot = transform.rotation;
            transform.rotation = Quaternion.Slerp(currentRot, _rotation, ROTATIONSPEED);
            _rotation =Quaternion.Euler(0,0,0);
        }
        
        if (!(highScore < transform.position.y)) return;
        highScore = transform.position.y;
        OnHighScoreChanged?.Invoke(highScore);
    }

    public void ApplyMovement(float inputX)
    {
        Rotate(inputX);
    }

    public void ApplyBoost()
    {
        _rb2d.AddForce(transform.up * SPEED, ForceMode2D.Impulse);
    }

    private void Rotate(float inputX)
    {
        // 움직임에 따라 회전을 바꿈 -> 회전을 바꾸고 그 방향으로 발사를 해야 그쪽으로 가겠죠?
        _rotation = inputX switch
        {
            1 => Quaternion.Euler(0,0,-90),
            -1 => Quaternion.Euler(0,0,90)
        };
        
    }
}