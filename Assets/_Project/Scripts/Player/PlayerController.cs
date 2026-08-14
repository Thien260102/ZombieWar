using System.Collections;
using System.Collections.Generic;
using PinePie.SimpleJoystick;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerAmination _playerAmination;
    [SerializeField] PlayerCombat _playerCombat;

    private JoystickController _joystickController;
    private Vector3 _inputDirection;

    void Start()
    {
        _joystickController = FindObjectOfType<JoystickController>();
        StartCoroutine(MovingRoutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerCombat.Fire();
        }
    }

    IEnumerator MovingRoutine()
    {
        _inputDirection = Vector3.zero;
        Vector2 joystickInputDirection;
        while (true)
        {
            joystickInputDirection = _joystickController.InputDirection;
            ConvertJoystickInput(joystickInputDirection);
            transform.position += 5 * Time.deltaTime * _inputDirection;

            _playerAmination.SetAnimation(joystickInputDirection);
            yield return null;
        }
    }

    void ConvertJoystickInput(Vector2 input)
    {
        _inputDirection.x = input.x;
        _inputDirection.z = input.y;
    }

}
