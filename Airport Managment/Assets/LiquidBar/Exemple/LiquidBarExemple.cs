using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidBarExemple : MonoBehaviour
{
    public List<LiquidBar> bars;
    public Text amountText;

    public void UpdateBarsValue(float value)
    {
        for (int i = 0; i < bars.Count; i++)
        {
            bars[i].targetFillAmount = value;
        }

        amountText.text = Mathf.Round(value *100).ToString();
    }
}
