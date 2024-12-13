using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;


    public void SetStamina(float stamina)
    {
        slider.value = stamina;
    }


    // Start is called before the first frame update
    void Start()
    {
        SetStamina(100);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
