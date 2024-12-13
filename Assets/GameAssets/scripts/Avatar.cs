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
    public HealthBar _healthBar;
    public StaminaBar _staminaBar;
    private void Start()
    {
        health = 100;
        stamina = 100;
        //_healthBar = GameObject.FindWithTag("health");
        //_staminaBar = GameObject.FindWithTag("stamina");
        InvokeRepeating(nameof(updateStamina),0f, 1f);
    }
    
    private void updateBar(GameObject bar, float fill)
    {
        var scale = bar.GetComponent<RectTransform>().transform.localScale;
        bar.GetComponent<RectTransform>().transform.localScale = new Vector3(fill, scale.y, scale.z);
    }

    private void FixedUpdate()
    {
        //updateBar(_healthBar, health/100f);
        //updateBar(_staminaBar, stamina/100f);
        _healthBar.SetHealth(health);
        _staminaBar.SetStamina(stamina);

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