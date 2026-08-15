using UnityEngine;
using System.Collections;

public class Rifle : Weapon
{
    [SerializeField] Bullet _bulletPrefab;

    protected override void OnFire()
    {
        Bullet bullet = Instantiate(
            _bulletPrefab,
            _firePoint.position,
            _firePoint.rotation
        );
        bullet.transform.up = (_firePoint.position - _startPoint.position).normalized;
        
        bullet.Initialize(_data.Damage, _data.BulletSpeed, _data.Range);
    }
}