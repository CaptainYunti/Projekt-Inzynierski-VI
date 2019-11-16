using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    //public int strength;
    //public float attackSpeed;
    public float range;

    public abstract void AttackHero();
    public abstract void AttackNPC();
    public abstract void DefendNPC();
    public bool IsInRange(GameObject player)
    {
        return false;
        //tu bedzie cos mondrego xD
    }
    public abstract void Run();
    public abstract void RunRandom();
    public abstract void NormalBehaviour();
    public abstract void Move();
    public bool IsDead()
    {
        if (currentHP > 0)
            return false;
        return true;
    }
    public void GetDamage(int damage)
    {
        currentHP -= damage;
        if(IsDead())
        {
            gameObject.SetActive(false);
        }
    }

}
