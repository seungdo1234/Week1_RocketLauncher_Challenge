using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    private EnergySystem _energySystem;
    private RocketMovement _rocketMovement;
    
    private bool _isMoving;
    private Vector2 _movementDirection;
    private void Awake()
    {
        _energySystem = GetComponent<EnergySystem>();
        _rocketMovement = GetComponent<RocketMovement>();
    }

    // TODO : OnMove 구현
    private void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>().normalized;
        _movementDirection = direction;

        _isMoving = direction != Vector2.zero;
    }

    // TODO : OnBoost 구현
    // private void OnBoost...
    private void OnBoost(InputValue value)
    {
        _rocketMovement.ApplyBoost(value.isPressed);
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            float boostEnergy = _rocketMovement.IsBoosted ? 3f : 1f;
            float spendEnergy = Time.fixedDeltaTime * boostEnergy;
            
            if (_energySystem.UseEnergy(spendEnergy))
            {
                _rocketMovement.ApplyMovement(_movementDirection);
            }
        }
    }
}