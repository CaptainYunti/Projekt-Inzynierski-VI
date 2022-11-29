using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowWeapon : Weapon
{
    public override void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Jebudu w " + col.gameObject.name);
            HeroStats.GetDamage(GetDamage());
        }

    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Jebudu");
            HeroStats.GetDamage(GetDamage());
        }

    }

    protected override void Attack(int damage)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponDamage = FindObjectOfType<CowBehaviour>().strength;
    }
}
