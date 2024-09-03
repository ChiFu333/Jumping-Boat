using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    public float maxDistanceToWin;
    public Slider posIndicator;
    public 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posIndicator.value = BoatController.inst.transform.position.x/maxDistanceToWin;
    }
}
