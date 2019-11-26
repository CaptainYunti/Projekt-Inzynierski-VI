using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowWeapon : Weapon
{
    public override void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
            HeroStats.GetDamage(GetDamage());
    }

    protected override void Attack(int damage)
    {
        weaponDamage = GetComponent<CowBehaviour>().strength;
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponDamage = GetComponent<CowBehaviour>().strength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
