using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControllerC : MonoBehaviour
{
    private EnergySystemC _energySystem;
    private RocketMovementC _rocketMovement;
    
    private bool _isMoving;
    private float _movementDirection;
    
    private readonly float ENERGY_TURN = 1f;
    private readonly float ENERGY_BURST = 2f;

    private bool _boostKeyPress = false;
    
    private void Awake()
    {
        _energySystem = GetComponent<EnergySystemC>();
        _rocketMovement = GetComponent<RocketMovementC>();
    }
    
    private void FixedUpdate()
    {
        if (!_isMoving) return;
        
        if(!_energySystem.UseEnergy(Time.fixedDeltaTime * ENERGY_TURN)) return;
        
        _rocketMovement.ApplyMovement(_movementDirection);
    }

    // OnMove 구현
    private void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>().normalized;
        _movementDirection = direction.x;
        _isMoving = direction != Vector2.zero;
    }
    

    // OnBoost 구현
    private void OnBoost(InputValue value)
    {
        if (!_boostKeyPress)
        {
            _boostKeyPress = true;
        }
        else
        {
            _boostKeyPress = false;
            if (_energySystem.UseEnergy(ENERGY_BURST))
            {
                _rocketMovement.ApplyBoost();
            }
        }
    }
    
}