using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehaviour : EnemyBehaviour
{
    public override void AttackHero()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator Move()
    {
        Vector3 rotate;
        print("Krowa idzie");
        rotate = new Vector3(0, Random.Range(0, 360), 0);
        for (int i = 0; i < goSomewhereTime*60; i++)
        {

            if (isMove)
            {
                StartCoroutine(MoveForward());
                yield return new WaitForSeconds(0.015f);
            }
            if (IsPlayerSeen())
            {
                isFight = true;
                break;
            }
            if (IsObstacleOnRoad())
            {
                StopCoroutine(MoveForward());
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

    public override IEnumerator NormalBehaviour()
    {
        
        for(int i = 0; i < doNothingTime; i++)
        {
            if (isWait)
            {
                yield return new WaitForSeconds(1f);
            }
            if(IsPlayerSeen())
            {
                isFight = true;
                break;
            }

        }

        isWait = false;
        if(!isFight)
            isMove = true;
        changeState = true;
        print("Krowa konczy czekac");
        yield return null;
    }

    public override void Run()
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
        changeState = false;
        isWait = true;
        isFight = isMove = isRun = false;
        inSight = false;
        player = GameObject.FindGameObjectWithTag("Player");
        strength = 4;
        expFromThis = 5;
        currentHP = maxHP = 4;
        weapon = this.transform.Find("Cow Weapon").gameObject;
        doNothingTime = Random.Range(5, 10);
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

        if (Physics.Raycast(transform.position + transform.up, transform.forward, 1))
            return true;

        return false;
    }
}
