using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IHaveHealth
{
    public Events Events;

    public int Health;

    public int Damage;

    public bool Death = false;

    public Desolve Desolver;

    public CapsuleCollider Collider;

    public Rigidbody Rb;

    public NavMeshAgent Agent;

    public Animator Anima;

    public Sound Sounds;

    public bool DoorOpen;

    /// <summary>
    /// Реализация получения урона
    /// </summary>
    /// <param name="damage"></param>
    public void Impact(int damage)
    {
        if (damage < Health)
        {
            Health -= damage;
            //включить анимацию получения урона
        }
        else if (Death == false && damage >= Health)
        {
            Dead();
        }
    }

    /// <summary>
    /// Реализация смерти и исчезновения
    /// </summary>
    private void Dead()
    {
        //анимация смерти

        Death = true;
        Desolver.DesolveEnemy();
        Collider.isTrigger = true;
        Rb.isKinematic = true;
        Agent.destination = transform.position;
        Anima.SetTrigger("Dead");
        Events.EnemyDead();
    }
}
