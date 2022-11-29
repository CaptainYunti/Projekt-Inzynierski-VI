using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehaviour : EnemyBehaviour
{

    [SerializeField] CowWeapon cowWeapon;

    public override IEnumerator AttackHero()
    {
        Debug.Log("Walczę");

        while(IsPlayerSeen())
        {
            if(currentHP / maxHP < 0.1)
            {
                isRun = true;
                break;
            }

            transform.LookAt(player.transform);

            cowWeapon.enabled = true;

            while(IsPlayerSeen())
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            cowWeapon.enabled = false;

            //cowWeapon.enabled = false;

            yield return new WaitForSeconds(attackSpeed);


        }

        isFight = false;
        if(!isRun)
        {
            isWait = true;
        }
        changeState = true;

        yield return null;

    }

    public override IEnumerator Move()
    {
        Coroutine move;
        Vector3 rotate;
        Debug.Log("Krowa idzie");
        rotate = new Vector3(0, Random.Range(0, 360), 0);
        for (int i = 0; i < goSomewhereTime*60; i++)
        {

            if (isMove)
            {
                move = StartCoroutine(MoveForward());
                yield return new WaitForSeconds(0.015f);
                StopCoroutine(move);
            }
            if (IsPlayerSeen())
            {
                isFight = true;
                break;
            }
            if (IsObstacleOnRoad())
            {
                rotate += new Vector3(0, 30, 0);
                transform.Rotate(rotate);
                yield return new WaitForSeconds(1f);
                
            }
            
        }

        isMove = false;
        if (!isFight)
            isWait = true;
        changeState = true;
        yield return null;
    
    }    
    public override IEnumerator Run()
    {
        Coroutine move;
        Vector3 rotate;
        Debug.Log("Krowa ucieka");
        rotate = new Vector3(0, 180, 0);
        for (int i = 0; i < goSomewhereTime*60; i++)
        {

            if (isRun)
            {
                move = StartCoroutine(MoveForward());
                yield return new WaitForSeconds(0.015f);
                StopCoroutine(move);
            }
            if (IsObstacleOnRoad())
            {
                rotate += new Vector3(0, 30, 0);
                transform.Rotate(rotate);
                yield return new WaitForSeconds(1f);
                
            }
            
        }

        isRun = false;
        isWait = true;
        changeState = true;
        yield return null;
    }

    public override IEnumerator NormalBehaviour()
    {
        
        for(int i = 0; i < doNothingTime; i++)
        {
            if (isWait)
            {
                Debug.Log("Czekam " + this.name);
                yield return new WaitForSeconds(1f);
            }
            if(IsPlayerSeen())
            {
                isFight = true;
                Debug.Log("Widzę Cię");
                break;
            }

        }

        isWait = false;
        if(!isFight)
            isMove = true;
        changeState = true;
        Debug.Log("Krowa konczy czekac");
        yield return null;
    }

    protected override void StatsUpdate()
    {
        HeroStats.AddExp(expFromThis);
        HeroStats.KilledCow();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        attackRange = 5f;
        changeState = false;
        isWait = true;
        isFight = isMove = isRun = false;
        inSight = false;
        player = GameObject.FindGameObjectWithTag("Player");
        strength = 4;
        expFromThis = 5;
        currentHP = maxHP = 4;
        doNothingTime = Random.Range(5, 10);
        //Debug.Log("Zaczynam");
        StartCoroutine(NormalBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)currentHP / maxHP;

        if(changeState)
        {
            if (isWait)
            {
                doNothingTime = Random.Range(5, 30);
                StartCoroutine(NormalBehaviour());
            }
             
            if (isMove)
            {
                goSomewhereTime = Random.Range(10, 60);
                StartCoroutine(Move());
            }
            if (isRun)
            {
                goSomewhereTime = Random.Range(10, 60);
                StartCoroutine(Run());
            }
            if (isFight)
            {
                StartCoroutine(AttackHero());
            }
                

            changeState = false;
        }
        
    }

    private IEnumerator MoveForward()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        yield return new WaitForFixedUpdate();
    }

    private bool IsObstacleOnRoad()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        //RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position + transform.up * 0.5f, transform.forward, 3))
            return true;

        return false;
    }
}
