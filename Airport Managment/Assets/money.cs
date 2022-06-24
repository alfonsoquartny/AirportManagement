using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class money : MonoBehaviour
{

    public int moneyInt = 50;
    private Text text;
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        text.text=moneyInt+"$";
    }
}
