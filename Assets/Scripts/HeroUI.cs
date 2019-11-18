using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroUI : MonoBehaviour
{
    public Image healthBar;
    public GameObject backround;
    public Text health;
    public Text strength;
    public Text level;
    public Text exp, expNextLevel;
    public Text chickenLevel, cowLevel, pigLevel, duckLevel, sheepLevel;
    public Text killedChicken, killedCow, killedPig, killedDuck, killedSheep;
    [SerializeField]
    bool isUIActive;
    [SerializeField]
    bool isUIStatsActive;

    // Start is called before the first frame update
    void Start()
    {
        backround = GameObject.Find("Stats Background");
        isUIActive = false;
        isUIStatsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = HeroStats.GetCurrentHP() / HeroStats.GetMaxHP();
        health.text = "Punkty życia: " + HeroStats.GetCurrentHP().ToString() + " / " + HeroStats.GetMaxHP().ToString();
        strength.text = "Siła: " + HeroStats.GetStrength().ToString();
        level.text = "Poziom: " + HeroStats.GetLevel().ToString();
        exp.text = "Exp: " + HeroStats.GetExp().ToString();
        expNextLevel.text = "Exp do następnego poziomu: " + HeroStats.GetNextLevel().ToString();
        chickenLevel.text = "Poziom walki - kurczak: " + HeroStats.GetChickenLevel().ToString();
        cowLevel.text = "Poziom walki - krowa: " + HeroStats.GetCowLevel().ToString();
        pigLevel.text = "Poziom walki - świnia: " + HeroStats.GetPigLevel().ToString();
        duckLevel.text = "Poziom walki - kaczka: " + HeroStats.GetDuckLevel().ToString();
        sheepLevel.text = "Poziom walki - owca: " + HeroStats.GetSheepLevel().ToString();
        killedChicken.text = "Kura: " + HeroStats.GetKilledAllChicken().ToString();
        killedCow.text = "Krowa: " + HeroStats.GetKilledAllCow().ToString();
        killedPig.text = "Świnia: " + HeroStats.GetKilledAllPig().ToString();
        killedDuck.text = "Kaczka: " + HeroStats.GetKilledAllDuck().ToString();
        killedSheep.text = "Owca: " + HeroStats.GetKilledAllSheep().ToString();

        InputUI();

        if (isUIActive)
            backround.SetActive(true);
        else
            backround.SetActive(false);

        if(isUIStatsActive)
        {
            killedChicken.enabled = true;
            killedCow.enabled = true;
            killedDuck.enabled = true;
            killedPig.enabled = true;
            killedSheep.enabled = true;
        }
        else
        {
            killedChicken.enabled = false;
            killedCow.enabled = false;
            killedDuck.enabled = false;
            killedPig.enabled = false;
            killedSheep.enabled = false;
        }
    }


    private void InputUI()
    {
        if(Input.GetKeyDown("k"))
        {

                isUIActive = !isUIActive;
        }

        if(Input.GetKeyDown("j"))
        {
            isUIStatsActive = !isUIStatsActive;
        }
    }
}
