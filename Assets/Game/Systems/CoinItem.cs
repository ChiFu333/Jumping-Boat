using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    public int value;
    public AudioClip GiveMoney; 
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BoatController boat = other.GetComponent<BoatController>();
        if(boat != null)
        {
            AudioManager.inst.Play(GiveMoney);
            FindObjectOfType<EndPanelInfoCollector>(). bonuses += value;
            Destroy(gameObject);
        }
    }
}
