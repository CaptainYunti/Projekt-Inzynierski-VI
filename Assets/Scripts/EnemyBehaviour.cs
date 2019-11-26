using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyBehaviour : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public float speed;
    public int strength;
    //public float attackSpeed;
    public float range;
    public int expFromThis;
    protected GameObject weapon;
    public Image healthBar;

    private void Start()
    {

    }

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
    protected abstract void StatsUpdate();
    public bool IsDead()
    {
        if (currentHP > 0)
            return false;
        StatsUpdate();
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

    /*private void OnCollisonEnter(Collider col)
    {
        if(col.gameObject.tag == "Player Weapon")
        {
            int damage = col.gameObject.GetComponent<Weapon>().GetDamage();
            GetDamage(damage);
        }
    }*/

}
