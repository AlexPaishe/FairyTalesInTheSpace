using UnityEngine;

[CreateAssetMenu(fileName = "BlasterEdit", menuName = "ScriptableObjects/BlasterEdit")]
public class BlasterEdit : ScriptableObject
{
    [SerializeField] public float angelAttack;
    [SerializeField] public float timeCharging;
    [SerializeField] public int shootDamage;
    [SerializeField] public float Shootdistanse;
}
