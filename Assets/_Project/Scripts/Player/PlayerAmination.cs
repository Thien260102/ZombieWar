using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmination : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private State _currentState = State.None;

    public void SetIdle()
    {
        if (_currentState == State.Idle)
        {
            return;
        }
        _currentState = State.Idle;

        animator.SetTrigger("Idle");
    }

    public void SetRunning()
    {
        if (_currentState == State.Running)
        {
            return;
        }
        _currentState = State.Running;

        animator.SetTrigger("Run");
    }

    public void SetShooting()
    {
        animator.SetTrigger("Shoot");
    }

    public enum State
    {
        None = 0,
        Idle,
        Running,
        Shooting
    }
}
