using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class EndPanelInfoCollector : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text[] texts;
    public int bonuses;
    public float metreToMoney = 0.1f;
    void Start()
    {
        
    }
    public void StartDo() => StartCoroutine(WaitAndShow());
    public IEnumerator WaitAndShow()
    {
        yield return new WaitForSeconds(1);
        panel.SetActive(true);
        texts[0].text = "Пройдено: " + ((int)BoatController.inst.transform.position.x).ToString() + " м";
        texts[1].text = "Собрано бонусов: " + bonuses.ToString() + "$";

        int result = (int)((int)BoatController.inst.transform.position.x * metreToMoney) + bonuses;
        texts[2].text = "Итог: " + result.ToString() + "$";
        MoneyAndBoatSystem.inst.money += result;
    }
}
