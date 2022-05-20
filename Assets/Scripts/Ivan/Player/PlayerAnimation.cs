using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _legsAnim;
    [SerializeField] private Animator _torsoAnim;

    public void SetMoveSpeed(float _speed)
    {
        _legsAnim.SetFloat("MoveSpeed", _speed);
    }
}
