using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatsBuyerAndUpdater : MonoBehaviour
{
    public List<int> fuels;
    public List<int> fuelCosts;
    public List<float> accelerations;
    public List<int> acclerationCosts;
    public List<int> jumps;
    public List<int> jumpCosts;
    public Slider[] sliders;
    public TMP_Text[] costes;
    public AudioClip buySound;
    void Start()
    {
        UpdateFuel();
        UpdateAcc();
        UpdateJump();
    }

    public void UpdateFuel()
    {
        FindAnyObjectByType<StatUpdate>().UpdateUI();
        for(int i = 0; i < fuelCosts.Count; i++)
        {
            if(MoneyAndBoatSystem.inst.maxFuel == fuels[i] && i+1 != fuels.Count)
            {
                sliders[0].value = (float)(i+1)/fuels.Count;
                costes[0].text = fuelCosts[i+1].ToString() + "$";
                break;
            }
            else if(MoneyAndBoatSystem.inst.maxFuel == fuels[i] && i+1 == fuels.Count)
            {
                sliders[0].value = (float)(i+1)/fuels.Count;
                costes[0].text = "Все!";
                break;
            }
            sliders[0].value = 0;
            costes[0].text = fuelCosts[0].ToString() + "$";
        }
    }
    public void BuyFuel()
    {
        int id = 0;
        for(int i = 0; i < fuelCosts.Count; i++)
        {
            if(MoneyAndBoatSystem.inst.maxFuel == fuels[i] && i+1 != fuelCosts.Count)
            {
                id = i+1;
                break;
            }
            else if(MoneyAndBoatSystem.inst.maxFuel == fuels[i] && i+1 == fuelCosts.Count)
            {
                return;
            }
        }
        if(MoneyAndBoatSystem.inst.money >= fuelCosts[id])
        {
            MoneyAndBoatSystem.inst.money -= fuelCosts[id];
            AudioManager.inst.Play(buySound);
            MoneyAndBoatSystem.inst.maxFuel = fuels[id];
            UpdateFuel();
        }
    }
    public void UpdateAcc()
    {
        FindAnyObjectByType<StatUpdate>().UpdateUI();
        for(int i = 0; i < accelerations.Count; i++)
        {
            if(MoneyAndBoatSystem.inst.acceleration == accelerations[i] && i+1 != accelerations.Count)
            {
                sliders[1].value = (float)(i+1)/accelerations.Count;
                costes[1].text = acclerationCosts[i+1].ToString() + "$";
                break;
            }
            else if(MoneyAndBoatSystem.inst.acceleration == accelerations[i] && i+1 == accelerations.Count)
            {
                sliders[1].value = (float)(i+1)/accelerations.Count;
                costes[1].text = "Все!";
                break;
            }
            sliders[1].value = 0;
            costes[1].text = acclerationCosts[0].ToString() + "$";
        }
    }
    public void BuyAcc()
    {
        int id = 0;
        for(int i = 0; i < accelerations.Count; i++)
        {
            if(MoneyAndBoatSystem.inst.acceleration == accelerations[i] && i+1 != accelerations.Count)
            {
                id = i+1;
                break;
            }
            else if(MoneyAndBoatSystem.inst.acceleration == accelerations[i] && i+1 == accelerations.Count)
            {
                return;
            }
        }
        if(MoneyAndBoatSystem.inst.money >= acclerationCosts[id])
        {
            MoneyAndBoatSystem.inst.money -= acclerationCosts[id];
            AudioManager.inst.Play(buySound);
            MoneyAndBoatSystem.inst.acceleration = accelerations[id];
            UpdateAcc();
        }
    }
    public void UpdateJump()
    {
        FindAnyObjectByType<StatUpdate>().UpdateUI();
        for(int i = 0; i < jumps.Count; i++)
        {
            if(MoneyAndBoatSystem.inst.doubleJumpCount == jumps[i] && i+1 != jumps.Count)
            {
                sliders[2].value = (float)(i+1)/jumps.Count;
                costes[2].text = jumpCosts[i+1].ToString() + "$";
                break;
            }
            else if(MoneyAndBoatSystem.inst.doubleJumpCount == jumps[i] && i+1 == jumps.Count)
            {
                sliders[2].value = (float)(i+1)/jumps.Count;
                costes[2].text = "Все!";
                break;
            }
            sliders[2].value = 0;
            costes[2].text = jumpCosts[0].ToString() + "$";
        }
    }
    public void BuyJump()
    {
        int id = 0;
        for(int i = 0; i < jumps.Count; i++)
        {
            if(MoneyAndBoatSystem.inst.doubleJumpCount == jumps[i] && i+1 != jumps.Count)
            {
                id = i+1;
                break;
            }
            else if(MoneyAndBoatSystem.inst.doubleJumpCount == jumps[i] && i+1 == jumps.Count)
            {
                return;
            }
        }
        if(MoneyAndBoatSystem.inst.money >= jumpCosts[id])
        {
            MoneyAndBoatSystem.inst.money -= jumpCosts[id];
            AudioManager.inst.Play(buySound);
            MoneyAndBoatSystem.inst.doubleJumpCount = jumps[id];
            UpdateJump();
        }
    }
}

