using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected WeaponData _data;
    [SerializeField] protected Transform _startPoint;
    [SerializeField] protected Transform _firePoint;


    public WeaponData Data => _data;
    public string WeaponName => "Weapon";


    protected float _nextFireTime;

    public virtual void Fire()
    {
        if (!CanFire())
            return;

        _nextFireTime = Time.time + 1f / _data.FireRate;
        
        OnFire();
    }

    protected virtual bool CanFire()
    {
        return Time.time >= _nextFireTime;
    }

    protected abstract void OnFire();

    public virtual void Reload()
    {
    }
}
