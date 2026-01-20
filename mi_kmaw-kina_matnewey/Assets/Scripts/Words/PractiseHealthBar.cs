using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PractiseHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    protected int health;
    [SerializeField] private int damage = 20;

    public void setHealth() {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public int getHealth() {
        return health;
    }

    public void takeDamage() {
        health -= damage;
        setHealth();
    }

    public void setMaxHealth(int health) {
        this.health = health;
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

}
