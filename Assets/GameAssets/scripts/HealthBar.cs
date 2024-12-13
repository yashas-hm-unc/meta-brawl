using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


    // Start is called before the first frame update
    void Start()
    {
        SetHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
