using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected int weaponDamage;

    // Start is called before the first frame update
    void Start()
    {
        weaponDamage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void Attack(int damage);
    public int GetDamage()
    {
        Attack(weaponDamage);
        return weaponDamage;
    }

    public abstract void OnCollisionEnter(Collision col);
}
