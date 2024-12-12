using System;
using GameAssets.scripts;
using UnityEngine;

public class Avatar: MonoBehaviour
{
    public int health;
    public int stamina;
    public PlayerTypeEnum playerType;
    public Power power1;
    public Power power2;

    private void Start()
    {
        health = 100;
        stamina = 100;
        InvokeRepeating(nameof(updateStamina),0f, 1f);
    }

    private void Update()
    {
       
    }

    private void OnCollisionExit(Collision other)
    {
       
    }
    
    

    private void updateStamina()
    {
        if (stamina < 100)
        {
            stamina += 1;   
        }
    }
}