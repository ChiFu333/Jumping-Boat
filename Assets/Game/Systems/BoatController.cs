using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Mathematics;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public static BoatController inst;
    public float fuel = 1000;
    public float maxfuel = 1000;
    public float speed;
    public float friction, acceleration, percentFriction;
    public float fuelСonsumption;
    public float jumpForce;
    public Transform groundCheck;
    public SpriteRenderer waterRender, waterRender2;
    private float currentAcceleration;
    public Rigidbody2D body;
    public LayerMask groundLayer;
    public bool blockJump = false;
    public AudioSource engine;
    public int doubleJumpsMax = 1;
    private int doubleJumps;
    public GameObject spriteHolder;
    public GameObject cloudEffect;
    public AudioClip jumpSound;
    public void Awake()
    {
        inst = this;
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Init();
    }
    public void Init()
    {
        maxfuel = MoneyAndBoatSystem.inst.maxFuel;
        fuel = maxfuel;
        acceleration = MoneyAndBoatSystem.inst.acceleration;
        doubleJumpsMax = MoneyAndBoatSystem.inst.doubleJumpCount;
        doubleJumps = doubleJumpsMax;
    }
    public 
    void Update()
    {
        currentAcceleration = Input.GetKey(KeyCode.D) && fuel > 0 ? acceleration : 0;
        body.velocity = new Vector2(speed, body.velocity.y);
        
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if(isGrounded) doubleJumps = doubleJumpsMax;
        if (Input.GetButtonDown("Jump") && (isGrounded || doubleJumps != 0)&& !blockJump)
        {
            if(!isGrounded) doubleJumps--;
            Jump(jumpForce);
            Instantiate(cloudEffect,transform.position + Vector3.down * 1.3f,Quaternion.identity);
            AudioManager.inst.Play(jumpSound);
        }
    }
    void FixedUpdate()
    {
        float cuurentFriciton = speed >= GetMaxSpeed() ? percentFriction - 0.002f : percentFriction;
        speed = (speed + currentAcceleration - friction) * cuurentFriciton;
        if(currentAcceleration > 0) fuel -= fuelСonsumption;
        if(speed < 0) speed = 0;
        if(fuel < 0) fuel = 0;

        if(Input.GetKey(KeyCode.D) && !engine.isPlaying && fuel != 0) 
        {
            engine.Play();
            spriteHolder.transform.rotation = Quaternion.Euler(0, 0, 15);
        }
        if(fuel == 0 || (!Input.GetKey(KeyCode.D) && engine.isPlaying)) 
        {
            engine.Stop();
            spriteHolder.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public float GetMaxSpeed()
    {
        return (acceleration - friction) / (1-percentFriction);
    }
    public void Jump(float force)
    {
        body.velocity = new Vector2(body.velocity.x, 0f);
        body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

    }
}
