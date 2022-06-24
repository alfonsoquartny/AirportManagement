using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class value : MonoBehaviour
{
    public int valueMoney = 0;

    private TextMesh text;
    void Start()
    {
        text = gameObject.GetComponentInChildren<TextMesh>();
        text.text = valueMoney + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
