using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmination : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetAnimation(Vector2 inputDirection)
    {
        _animator.SetFloat("MoveX", inputDirection.x);
        _animator.SetFloat("MoveZ", inputDirection.y);
    }

    public void PlayShooting()
    {
        _animator.SetTrigger("Shoot");
    }

}
