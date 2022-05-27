using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _legsAnim;
    [SerializeField] private Animator _torsoAnim;

    public void SetMoveSpeed(float _speed)
    {
        _legsAnim.SetFloat("MoveSpeed", _speed);
        _torsoAnim.SetFloat("MoveSpeed", _speed);
    }

    public void WeaponChange(int number)
    {
        _torsoAnim.SetInteger("WeaponNumber", number);
    }

    public void StartShoot(bool isShoot)
    {
        _torsoAnim.SetBool("IsShooting", isShoot);
    }

    public void SwordCircleAttack()
    {
        _torsoAnim.SetTrigger("SwordCircleAttack");
    }

    public void SwordChargeJerk()
    {
        _torsoAnim.SetTrigger("SwordChargJerk");
    }

    public void Shoot (bool isLeftShoot)
    {
        if (isLeftShoot)
        {
            _torsoAnim.SetTrigger("LeftShoot");
        }
        else
        {
            _torsoAnim.SetTrigger("RightShoot");
        }
    }

    public void Jerk()
    {
        _torsoAnim.SetTrigger("Jerk");
        _legsAnim.SetTrigger("Jerk");
    }

    public void Dead()
    {
        _torsoAnim.SetTrigger("Dead");
        _legsAnim.SetTrigger("Dead");
    }
}
