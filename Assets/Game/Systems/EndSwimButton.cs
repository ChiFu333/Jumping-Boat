using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSwimButton : MonoBehaviour
{
    public GameObject endButton, two;
    public bool t = true;
    void Update()
    {
        if(t && BoatController.inst.body.velocity.magnitude == 0 && BoatController.inst.fuel == 0)
        {
            BoatController.inst.blockJump = true;
            endButton.SetActive(true);
            two.SetActive(true);
            this.enabled = false;
        }
    }
}
