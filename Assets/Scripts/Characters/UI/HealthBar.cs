using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    
    private Action<float> onHealthChanged;

    #region PROPERTIES
    public Action<float> OnHealthChanged => onHealthChanged;
    #endregion

    public void Setup(float currentValue, float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = currentValue;
    }

    private void Awake()
    {
        onHealthChanged += HealthChange;
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void HealthChange(float value)
    {
        slider.value = value;
    }
}
