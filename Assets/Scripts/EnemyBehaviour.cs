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
    [SerializeField]
    protected float fieldOfViewAngle;
    protected bool inSight;
    public float range;
    public int expFromThis;
    protected GameObject weapon;
    protected GameObject player;
    public Image healthBar;
    protected int doNothingTime, goSomewhereTime;
    protected bool isWait, isMove, isRun, isFight;
    protected bool changeState;

    [SerializeField] protected float attackRange = 5;
    [SerializeField] protected float attackSpeed = 5;

    private void Start()
    {

    }

    public abstract IEnumerator AttackHero();
    //public abstract void AttackNPC();
    //public abstract void DefendNPC();
    public bool IsPlayerSeen()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);



        if (angle < fieldOfViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, range) && hit.collider.gameObject.tag == "Player")
            {
                //Debug.Log("Did Hit");
                inSight = true;
            }
            else
                inSight = false;
        }


        return inSight;
    }
    public abstract IEnumerator Run();
    public abstract IEnumerator NormalBehaviour();
    public abstract IEnumerator Move();
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
        if (currentHP <= 0)
            return;
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
