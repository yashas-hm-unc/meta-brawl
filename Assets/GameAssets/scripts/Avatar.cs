using System;
using GameAssets.scripts;
using UnityEngine;

public class Avatar: MonoBehaviour
{
    public float health;
    public float stamina;
    public PlayerTypeEnum playerType;
    public Power power1;
    public Power power2;
    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public static Avatar Singleton;

    private void Awake()
    {
        Singleton = this;
    }
    private void Start()
    {
        health = 100f;
        stamina = 100f;
        InvokeRepeating(nameof(updateStamina),0f, 1f);
    }
    
    private void updateBar(GameObject bar, float fill)
    {
        var scale = bar.GetComponent<RectTransform>().transform.localScale;
        bar.GetComponent<RectTransform>().transform.localScale = new Vector3(fill, scale.y, scale.z);
    }

    private void FixedUpdate()
    {
        healthBar.SetHealth(health);
        staminaBar.SetStamina(stamina);

    }

    private void Update()
    {
        if (health <= 0)
        {
            //TODO: do something kill player
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