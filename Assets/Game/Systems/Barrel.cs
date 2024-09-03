using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public AudioClip boom;
    public float speedBoost;
    public float jumpForce;
    public GameObject boomEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        BoatController boat = other.GetComponent<BoatController>();
        if(boat != null)
        {
            Instantiate(boomEffect,transform.position,Quaternion.identity);
            AudioManager.inst.Play(boom);
            boat.speed *= speedBoost;
            boat.Jump(jumpForce);
            Destroy(gameObject);
        }
    }
}
