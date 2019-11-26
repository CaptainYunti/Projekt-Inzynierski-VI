using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehaviour : EnemyBehaviour
{
    public override void AttackHero()
    {
        throw new System.NotImplementedException();
    }

    public override void AttackNPC()
    {
        throw new System.NotImplementedException();
    }

    public override void DefendNPC()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void NormalBehaviour()
    {
        throw new System.NotImplementedException();
    }

    public override void Run()
    {
        throw new System.NotImplementedException();
    }

    public override void RunRandom()
    {
        throw new System.NotImplementedException();
    }

    protected override void StatsUpdate()
    {
        HeroStats.AddExp(expFromThis);
        HeroStats.KilledCow();
    }

    // Start is called before the first frame update
    void Start()
    {
        strength = 4;
        expFromThis = 5;
        currentHP = maxHP = 4;
        weapon = this.transform.Find("Cow Weapon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)currentHP / maxHP;
    }
}
