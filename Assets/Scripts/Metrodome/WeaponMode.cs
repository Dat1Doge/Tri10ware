using UnityEngine;

[CreateAssetMenu(fileName = "WeaponMode", menuName = "Scriptable Objects/WeaponMode")]
public class WeaponMode : ScriptableObject
{
    public float coolDown;
    public Sprite sprite;
    public GameObject projectile;
}
