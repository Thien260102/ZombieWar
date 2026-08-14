using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private PlayerAmination _playerAnimation;

    public void Fire()
    {
        //weaponController.Fire();

        _playerAnimation.PlayShooting();
    }

    public void SwitchWeapon()
    {
        weaponController.SwitchWeapon();
    }

    public void SwitchWeapon(int index)
    {
        weaponController.SwitchWeapon(index);
    }
}
