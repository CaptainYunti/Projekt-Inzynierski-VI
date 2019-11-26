using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{

    Animator anim;
    bool eat, attackReady;
    GameObject beak;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        eat = false;
        beak = GameObject.Find("Toon Chicken/Beak");
        beak.SetActive(false);
        attackReady = true;
    }

    private void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0) && attackReady)
        {
            eat = true;
            beak.SetActive(true);
            //print("dziób");
            StartCoroutine(PlayerAttack());
            attackReady = false;
        }
        else
        {
            eat = false;
            beak.SetActive(false);
        }
    }


    private void LateUpdate()
    {
        anim.SetBool("Eat", eat);
    }

    private IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(HeroStats.GetAttackSpeed());
        attackReady = true;
    }

   /* private void OnCollisonEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy Weapon")
        {
            int damage = col.gameObject.GetComponent<Weapon>().GetDamage();
            HeroStats.GetDamage(damage);
        }
    }*/
}
