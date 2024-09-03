using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUpdate : MonoBehaviour
{
    public TMP_Text[] texts;
    public void Start()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        MoneyAndBoatSystem manager = MoneyAndBoatSystem.inst;
        texts[0].text = "   Кошелек: " + manager.money.ToString() + " $";
        texts[1].text = "   Бензобак: " + manager.maxFuel.ToString() + " ед.";
        texts[2].text = "   Ускорение: " + manager.acceleration.ToString() + " ед.";
        texts[3].text = "   Прыжки в воздухе: " + manager.doubleJumpCount.ToString() + " раз(а)";
    }
}
