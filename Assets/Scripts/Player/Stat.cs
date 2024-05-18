using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stat
{
    public string name { get; set; }
    public float minVal { get; set; }
    public float maxVal { get; set; }
    public float currVal { get; set; }
    private float Ratio;

    public Stat(string _name, float _minVal, float _maxVal, float _initialVal)
    {
        name = _name;
        minVal = _minVal;
        maxVal = _maxVal;
        currVal = _initialVal;
    }

    /// <summary>
    /// Ratio of current value to max value.
    /// Used for UI elements like progress bars.
    /// </summary>

    public void IncreaseCurrentValue(float amount)
    {
        currVal += amount;
        ClampCurrentValue();
    }

    public void DecreaseCurrentValue(float amount)
    {
        currVal -= amount;
        ClampCurrentValue();
    }

    public void IncreaseMaxValue(int amount)
    {
        maxVal += amount;
        ClampCurrentValue();
    }

    public void DecreaseMaxValue(int amount)
    {
        maxVal -= amount;
        if (maxVal < minVal)
            maxVal = minVal;
        ClampCurrentValue();
    }

    public void SetVal(int amount)
    {
        currVal = amount;
        ClampCurrentValue();
    }

    public void SetMaxVal(int amount)
    {
        maxVal = amount;
        ClampCurrentValue();
    }

    private void ClampCurrentValue()
    {
        currVal = Mathf.Clamp(currVal, minVal, maxVal);
        Ratio = currVal / maxVal;
        // publish statChange event when clamp function is called
        EventBus.Publish(new StatChangeEvent(this));
    }
}