using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class WaterStaying : MonoBehaviour
{
    public Transform player;
    public float offset;
    public float yoffset;
    public bool andYClamp = false;
    private Material mat;
    private Vector2 currenOffset;
    public float baseSpeed = 2;
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        currenOffset = mat.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + offset,yoffset + (andYClamp ? player.position.y : 0),transform.position.z);
        currenOffset += new Vector2((BoatController.inst.speed + baseSpeed)* Time.fixedDeltaTime * 0.1f,math.sin(Time.time) * 0.0003f);
        mat.SetVector("_Offset", currenOffset);
    }
}
