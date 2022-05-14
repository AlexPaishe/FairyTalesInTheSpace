using UnityEngine;

[CreateAssetMenu(fileName = "BulletEdit", menuName = "ScriptableObjects/BulletEdit")]
public class BulletEdit : ScriptableObject
{
    [Range(1, 100f)] public float speed;
    [Range(0.1f, 5)] public float liveTime;
    [Range(1, 100)] public int damage;
    [Range(1, 100)] public float force;
}
