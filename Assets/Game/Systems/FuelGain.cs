using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelGain : MonoBehaviour
{
    public AudioClip gain;
    public float percentFuel;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BoatController boat = other.GetComponent<BoatController>();
        if(boat != null)
        {
            AudioManager.inst.Play(gain);
            boat.fuel += boat.maxfuel * percentFuel;
            if(boat.fuel/boat.maxfuel > 1) boat.fuel = boat.maxfuel;
            Destroy(gameObject);
        }
    }
}
