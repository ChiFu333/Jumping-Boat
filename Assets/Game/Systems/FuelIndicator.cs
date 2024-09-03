using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelIndicator : MonoBehaviour
{
    public TMP_Text text;
    public Slider slider;
    void Update()
    {
        text.text = ((int)(BoatController.inst.fuel * 100/ BoatController.inst.maxfuel)).ToString() + "%";
        slider.value = BoatController.inst.fuel / BoatController.inst.maxfuel;
    }
}
