using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stat
{
    public string name { get; set; }
    public float minVal { get; set; }
    public float maxVal { get; set; }
    public float currVal { get; set; }
    public bool displayOn { get; set; }
    public Color barColor { get; set; }

    // TODO UI styling info
    public float Ratio = 1;


    //signal for UI
    [Signal]
    public delegate void stat_change(string stat_name);

    public Stat(string _name, float _minVal, float _maxVal, float _initialVal, bool _displayOn)
    {
        name = _name;
        minVal = _minVal;
        maxVal = _maxVal;
        currVal = _initialVal;
        displayOn = _displayOn;
    }

    /// <summary>
    /// Example defualt stat constructor
    /// </summary>
    public Stat()
    {
        name = "health";
        minVal = 0;
        maxVal = 100;
        currVal = 100;
        displayOn = true;
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

    public void toggleUI()
    {
        if (displayOn)
        {
            displayOn = false;
        }

        else
        {
            displayOn = true;
        }
    }

    private void ClampCurrentValue()
    {
        currVal = Mathf.Clamp(currVal, minVal, maxVal);
        Ratio = currVal / maxVal;
        // publish statChange event when clamp function is called
        EventBus.Publish<StatChangeEvent>(new StatChangeEvent(this));
    }
}