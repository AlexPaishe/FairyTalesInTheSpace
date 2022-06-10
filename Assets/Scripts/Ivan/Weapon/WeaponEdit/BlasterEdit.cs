using UnityEngine;

[CreateAssetMenu(fileName = "BlasterEdit", menuName = "ScriptableObjects/BlasterEdit")]
public class BlasterEdit : ScriptableObject
{
    [SerializeField] private float angelAttack;
    [SerializeField] private float timeCharging;
    [SerializeField] private int damage;
}
