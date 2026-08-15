using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float CurrentHealth => _currentHealth;

    public event Action<float> OnHealthChanged;
    public event Action OnDamaged;
    public event Action OnDeath;

    private float _currentHealth;

    public void SetMaxHealth(float maxHealth)
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0f)
            return;

        if (_currentHealth <= 0f)
            return;

        _currentHealth -= damage;

        OnHealthChanged?.Invoke(_currentHealth);
        OnDamaged?.Invoke();

        if (_currentHealth <= 0f)
        {
            _currentHealth = 0f;
            OnDeath?.Invoke();
        }
    }
}