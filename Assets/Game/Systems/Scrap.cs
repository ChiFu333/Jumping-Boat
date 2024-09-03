using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    public float percentMinus;
    public AudioClip gotStop;
    public GameObject boomEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        BoatController boat = other.GetComponent<BoatController>();
        if(boat != null)
        {
            Instantiate(boomEffect,transform.position,Quaternion.identity);
            AudioManager.inst.Play(gotStop);
            boat.speed *= percentMinus;
            Destroy(gameObject);
        }
    }
}
