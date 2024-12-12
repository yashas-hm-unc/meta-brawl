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
        if (health <= 0)
        {
            //TODO: do something kill player
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name is "Avatar")
        {
            Power hit = other.gameObject.GetComponent<Power>();
            if (hit.powerType is PowerTypeEnum.THROWABLE)
            {
                health -= hit.damageCost;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.name is "Avatar")
        {
            Power hit = other.gameObject.GetComponent<Power>();
            if (hit.powerType is PowerTypeEnum.COMBAT)
            {
                health -= hit.damageCost;
            }
        }
    }
    
    

    private void updateStamina()
    {
        if (stamina < 100)
        {
            stamina += 10;   
        }
    }
}