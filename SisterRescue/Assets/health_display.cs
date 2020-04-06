using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_display : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health) // This code allows the slider to move with the health set by programmer
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) // this code allows the player to keep the current health of damage
    {
        slider.value = health;
    }

}
