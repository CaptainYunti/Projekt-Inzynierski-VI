using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWeapon : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Attack(int damage)
    {
        weaponDamage = HeroStats.GetStrength();
        weaponDamage += damage;

    }

    public override void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Contains("Cow"))
            Attack(HeroStats.GetCowLevel());
        if (col.gameObject.tag.Contains("Chicken"))
            Attack(HeroStats.GetChickenLevel());
        if (col.gameObject.tag.Contains("Pig"))
            Attack(HeroStats.GetPigLevel());
        if (col.gameObject.tag.Contains("Duck"))
            Attack(HeroStats.GetDuckLevel());
        if (col.gameObject.tag.Contains("Sheep"))
            Attack(HeroStats.GetSheepLevel());

        if (col.gameObject.tag.Contains("Enemy"))
            col.gameObject.GetComponent<EnemyBehaviour>().GetDamage(weaponDamage);
    }
}
