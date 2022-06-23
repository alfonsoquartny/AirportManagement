using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bar : MonoBehaviour
{

    private Image image;
    public aiController ai;
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        ai = GetComponentInParent<aiController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (image.fillAmount < 0.05)
        {
            ai.loseCust = true;
        }
    }
}
