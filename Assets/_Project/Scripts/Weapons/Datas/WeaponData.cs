using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Game/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Basic")]
    public string weaponName;
    public float damage = 20f;
    public float fireRate = 5f;
    public float range = 50f;

    [Header("Ammo")]
    public int magazineSize = 30;
    public float reloadTime = 2f;

    [Header("Recoil")]
    public float recoilAmount = 1f;
}