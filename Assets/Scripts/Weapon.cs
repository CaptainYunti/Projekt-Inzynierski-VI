using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected int WeaponDamage;

    // Start is called before the first frame update
    void Start()
    {
        WeaponDamage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void Attack(int damage);
    public abstract void GetDamage();
}
