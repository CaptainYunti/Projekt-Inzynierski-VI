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
    void OnEnable()
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
        weapon.SetActive(false);
        doNothingTime = Random.Range(5, 10);
        Debug.Log("Zaczynam");
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
        //RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position + transform.up * 0.5f, transform.forward, 3))
            return true;

        return false;
    }
}
