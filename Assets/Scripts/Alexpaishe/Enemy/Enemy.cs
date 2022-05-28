using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IHaveHealth
{
    public int Health;

    public int Damage;

    public bool Death = false;

    public Desolve Desolver;

    public CapsuleCollider Collider;

    public Rigidbody Rb;

    public NavMeshAgent Agent;

    public Animator Anima;

    /// <summary>
    /// ���������� ��������� �����
    /// </summary>
    /// <param name="damage"></param>
    public void Impact(int damage)
    {
        if (damage < Health)
        {
            Health -= damage;
            //�������� �������� ��������� �����
        }
        else if (Death == false && damage >= Health)
        {
            Dead();
        }
    }

    /// <summary>
    /// ���������� ������ � ������������
    /// </summary>
    private void Dead()
    {
        //�������� ������

        Death = true;
        Desolver.DesolveEnemy();
        Collider.isTrigger = true;
        Rb.isKinematic = true;
        Agent.destination = transform.position;
        Anima.SetTrigger("Dead");
    }
}
