using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] weaponObjects;

    private IWeapon[] weapons;
    private int currentIndex;

    public IWeapon CurrentWeapon => weapons[currentIndex];

    private void Awake()
    {
        weapons = new IWeapon[weaponObjects.Length];

        for (int i = 0; i < weaponObjects.Length; i++)
        {
            weapons[i] = weaponObjects[i] as IWeapon;

            if (weapons[i] == null)
            {
                Debug.LogError(
                    $"{weaponObjects[i].name} does not implement IWeapon."
                );
            }
        }
    }

    public void Fire()
    {
        CurrentWeapon.Fire();
    }

    public void SwitchWeapon()
    {
        currentIndex++;

        if (currentIndex >= weapons.Length)
        {
            currentIndex = 0;
        }
    }

    public void SwitchWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length)
            return;

        currentIndex = index;
    }
}
