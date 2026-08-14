
public interface IWeapon
{
    WeaponData Data { get; }

    void Fire();
    void Reload();

    string WeaponName { get; }
}
