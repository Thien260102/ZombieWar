using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Game/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Basic")]
    public string WeaponName;
    public float Damage = 20f;
    public float FireRate = 5f;
    public float Range = 50f;
    public float BulletSpeed;

    [Header("Ammo")]
    public int MagazineSize = 30;
    public float ReloadTime = 2f;

    [Header("Recoil")]
    public float RecoilAmount = 1f;
}