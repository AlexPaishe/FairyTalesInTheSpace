using UnityEngine;

[CreateAssetMenu(fileName = "IzlarEdit", menuName = "ScriptableObjects/IzlarEdit")]
public class IzlarEdit : ScriptableObject
{
    [Range(0, 0.2f)] public float shootFrequency;
    [Range(0, 0.2f)] public float changeGunsFrequency;
    [Range(0, 10)] public float waitJerkTime;
    [Range(0, 1000)] public float jerkForce;
    [Range(1, 50)] public int jerkDamage;
}
