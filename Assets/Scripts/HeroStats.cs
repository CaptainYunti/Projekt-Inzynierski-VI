using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeroStats
{
    [SerializeField]
    static int strength;
    [SerializeField]
    static int level;
    [SerializeField]
    static int maxHP;
    [SerializeField]
    static int currentHP;
    [SerializeField]
    static int chickenLevel;
    [SerializeField]
    static int cowLevel;
    [SerializeField]
    static int pigLevel;
    [SerializeField]
    static int duckLevel;
    [SerializeField]
    static int sheepLevel;

    static int killedChicken, killedCow, killedPig, killedDuck, killedSheep;
    static int killedAllChicken, killedAllCow, killedAllPig, killedAllDuck, killedAllSheep;
    static int exp;
    static int expNextLevel;

    public static int GetStrength() { return strength; }
    public static int GetLevel() { return level; }
    public static int GetMaxHP() { return maxHP; }
    public static int GetCurrentHP() { return currentHP; }
    public static int GetExp() { return exp; }
    public static int GetNextLevel() { return expNextLevel; }
    public static int GetKilledAllChicken() { return killedAllChicken; }
    public static int GetKilledAllCow() { return killedAllCow; }
    public static int GetKilledAllPig() { return killedAllPig; }
    public static int GetKilledAllDuck() { return killedAllDuck; }
    public static int GetKilledallSheep() { return killedAllSheep; }
    public static int GetChickenLevel() { return chickenLevel; }
    public static int GetCowLevel() { return cowLevel; }
    public static int GetPigLevel() { return pigLevel; }
    public static int GetDuckLevel() { return duckLevel; }
    public static int GetSheepLevel() { return sheepLevel; }



   static HeroStats()
    {
        strength = 1;
        level = 0;
        maxHP = currentHP = 10;
        exp = 0;
        expNextLevel = 5;
        cowLevel = pigLevel = duckLevel = sheepLevel = chickenLevel = 0;
        killedChicken = killedCow = killedDuck = killedPig = killedSheep = 0;
        killedAllChicken = killedAllCow = killedAllDuck = killedAllPig = killedAllSheep = 0;
    }


    public static void LevelUp()
    {
        if (exp < expNextLevel)
            return;

        level++;
        exp = expNextLevel - exp;
        expNextLevel = (int)(expNextLevel * 1.2);
        maxHP = (int)(maxHP * 1.3);
        currentHP = maxHP;
        strength++;

    }

    public static void KilledChicken()
    {
        LevelUp();
        killedChicken++;
        killedAllChicken++;

        if (killedChicken < Mathf.Pow(chickenLevel + 1, 4))
            return;

        killedChicken = 0;
        chickenLevel++;
    }

    public static void KilledPig()
    {
        LevelUp();
        killedPig++;
        killedAllPig++;

        if (killedPig < Mathf.Pow(pigLevel + 1, 4))
            return;

        killedAllPig = 0;
        pigLevel++;
    }

    public static void KilledCow()
    {
        LevelUp();
        killedCow++;
        killedAllCow++;

        if (killedCow < Mathf.Pow(cowLevel + 1, 4))
            return;

        killedCow = 0;
        cowLevel++;
    }

    public static void KilledDuck()
    {
        LevelUp();
        killedDuck++;
        killedAllDuck++;

        if (killedDuck < Mathf.Pow(duckLevel + 1, 4))
            return;

        killedDuck = 0;
        duckLevel++;
    }

    public static void KilledSheep()
    {
        LevelUp();
        killedSheep++;
        killedAllSheep++;

        if (killedSheep < Mathf.Pow(sheepLevel + 1, 4))
            return;

        killedSheep = 0;
        sheepLevel++;
    }


}
