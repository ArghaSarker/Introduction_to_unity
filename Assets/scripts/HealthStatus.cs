using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStatus : MonoBehaviour
{
    

    [SerializeField] private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;

    }

    public void setHealth(int health)
    {
        _slider.value = health; 
    }
}
