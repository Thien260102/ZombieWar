using System.Collections;
using System.Collections.Generic;
using PinePie.SimpleJoystick;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerAmination _playerAmination;

    private JoystickController _joystickController;
    private Vector3 _inputDirection;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovingRoutine());
    }


    IEnumerator MovingRoutine()
    {
        _inputDirection = Vector3.zero;
        Vector2 inputDirection;
        while (true)
        {
            inputDirection = _joystickController.InputDirection;
            ConvertJoystickInput(inputDirection);
            transform.position += 5 * Time.deltaTime * _inputDirection;

            CheckRunning(inputDirection);
            yield return null;
        }
    }

    void ConvertJoystickInput(Vector2 input)
    {
        _inputDirection.x = input.x;
        _inputDirection.z = input.y;
    }

    private void OnEnable()
    {
        _joystickController = FindObjectOfType<JoystickController>();

        _joystickController.OnTouchRemoved += OnTouchRemoveHandler;
    }

    private void OnDisable()
    {
        _joystickController.OnTouchRemoved -= OnTouchRemoveHandler;
    }

    private void CheckRunning(Vector2 inputDirection)
    {
        if (Mathf.Approximately(inputDirection.x, 0) && Mathf.Approximately(inputDirection.y, 0))
        {
            _playerAmination.SetIdle();
            return;
        }

        _playerAmination.SetRunning();
    }

    private void OnTouchRemoveHandler()
    {
        _playerAmination.SetIdle();
    }

}
