using UnityEngine;

[CreateAssetMenu(fileName = "SwordEdit", menuName = "ScriptableObjects/SwordEdit")]
public class SwordEdit : ScriptableObject
{
    [Range(0, 10)] public float chargJerkTime;
    [Range(0, 200)] public float jerkMaxDistance;
    [Range(0, 200)] public float jerkMinDistance;
    [Range(0, 500000)] public float jerkSpeed;
    [Range(1, 50)] public int jerkMinDamage;
    [Range(1, 50)] public int jerkMaxDamage;
    [Range(1, 50)] public int circleAttackDamage;
    [Range(0, 1000)] public float circleAttackForce;
    [Range(0, 10)] public float waitCircleAttackTime;
}
