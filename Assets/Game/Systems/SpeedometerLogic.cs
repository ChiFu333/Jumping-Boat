using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpeedometerLogic : MonoBehaviour
{
    public BoatController player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Lerp(0f, -90f, player.speed / (player.GetMaxSpeed() * 1.5f));
        float fAngle = GetComponent<RectTransform>().eulerAngles.z - 360.05f;
        GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,Mathf.Lerp(fAngle, angle,0.4f));
    }
}
