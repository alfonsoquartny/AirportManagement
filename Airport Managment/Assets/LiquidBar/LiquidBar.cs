using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*  
 *  This asset have been made by Charles Grassi
 *  Follow me on twitter here: https://twitter.com/charles_grassi
 *  Feel free to message me if you have any suggestion / question
 */

[ExecuteInEditMode]
public class LiquidBar : MonoBehaviour
{

    private void Start()
    {
        angryImage.SetActive(false);
    }
    public GameObject angryImage;

    public bool loseCust;
    #region Fields
    [Tooltip("Bar-Z material")]
    public Material material;
    private Image mask;

    [Header("--- Bar Script Parameters ---")]

    [Tooltip("Do the transition effect automaticaly when the fill amount reach 1")]
    public bool automaticTransitionEffect;

    [Tooltip("Amount of the bar shown, (f.ex: 0.5 is 50%), the bar go to this value more or less quickly depending of the smoothness.")]
    [Range(0, 1)]
    public float targetFillAmount;

    [Tooltip("Defines how fast the bar will go to its target fill amount value")]
    public float smoothness;

    [HideInInspector]
    public float currentFillAmount;

    [Header("--- Shader Parameters ---")]

#if UNITY_EDITOR
    [Tooltip("Only compile in editor, tick to apply all the changes to the material")]
    public bool EDITORUpdateMaterial = true;
#endif

    [Space]
    [Tooltip("Tick this if you'll have more than one instance of this bar. Otherwise the parameters like the fill amount will be shared")]
    public bool instanciatedMaterial = false;

    [Header("Colors")]
    [Tooltip("The bar color, handles transparency too")]
    [ColorUsage(true, true)]
    public Color barColor;

    [Tooltip("The background color, handles transparency too")]
    public Color backgroundColor;

    [Header("UVs")]

    [Range(0.01f, 1)]
    [Tooltip("The resolution of the bar, try 0.2 for a pixelated result")]
    public float resolution = 1;

    [Tooltip("Spherize the UV, usefull with a circle mask")]
    public bool spherize = false;

    [Tooltip("Bar rotation")]
    public Rotation rotation;
    public enum Rotation
    {
        Right,
        Left,
        Up,
        Down
    }

    [Header("Inside Noise")]
    [Tooltip("The scale of the noise inside of the bar")]
    [Range(1, 200)]
    public float insideNoiseScale = 25;

    [Tooltip("Defines how visible is the noise inside the bar")]
    [Range(0, 1)]
    public float insideNoiseIntensity = 0.25f;

    [Tooltip("Defines how detailed is the noise inside the bar")]
    [Range(1, 255)]
    public float insideNoiseColorVariation = 50;

    [Header("Border")]
    [Tooltip("The scale of the noise applied to the border, set to 0 for a straight line")]
    [Range(0, 50)]
    public float borderNoiseScale = 3;

    [Tooltip("The amount of distortion applied to the border, set to 0 for a straight line")]
    [Range(0, 0.3f)]
    public float borderDistortionAmount = 0.1f;

    [Tooltip("Defines how reactive the border light is to the fill amount changes. (f.ex: 100 makes the bar lights up to small value variation)")]
    public float borderLightReactivity = 10;


    private Vector2 pixelSize;
    private Vector2 ratio;
    private bool onTransition;
    #endregion

    #region Start & Update

    private void Awake()
    {
        if (instanciatedMaterial)
        {
            material = new Material(Shader.Find("Shader Graphs/Bar"));
            UpdateMaterial();
            GetComponent<Image>().material = material;
        }
        else material = GetComponent<Image>().material;

        mask = GetComponent<Image>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (EDITORUpdateMaterial)
        {
            UpdateMaterial();
        }
#endif

        if (currentFillAmount < 0.2)
        {
            loseCust = true;
            currentFillAmount = 0;
            angryImage.SetActive(true);
            Debug.Log("Müşteri Kaybettin!");
        }

        if (automaticTransitionEffect)
        {
            if (currentFillAmount >= 0.99f && !onTransition)
            {
                StartTransition();
            }
        }

        float fillAmountDif = Mathf.Abs(currentFillAmount - targetFillAmount);

        material.SetFloat("_MovingAmount", fillAmountDif * borderLightReactivity);

        if (!onTransition)
            currentFillAmount = Mathf.Lerp(currentFillAmount, targetFillAmount, Time.deltaTime * smoothness);

        material.SetFloat("_Amount", currentFillAmount);
    }

    #endregion

    #region Methods
    public void StartTransition()
    {
        onTransition = true;
        currentFillAmount = 1;

        StopAllCoroutines();
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            material.SetFloat("_DissolveTransition", t);
            yield return null;
        }

        currentFillAmount = 0;
        targetFillAmount = 0;

        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            material.SetFloat("_DissolveAmount", t);
            yield return null;
        }

        material.SetFloat("_DissolveAmount", 0);
        material.SetFloat("_DissolveTransition", 0);

        onTransition = false;
    }

    private void UpdateMaterial()
    {
        if (mask == null) mask = GetComponent<Image>();

        switch (rotation)
        {
            case Rotation.Down:
                material.SetFloat("_Rotation", 270);
                break;
            case Rotation.Up:
                material.SetFloat("_Rotation", 90);
                break;
            case Rotation.Left:
                material.SetFloat("_Rotation", 180);
                break;
            case Rotation.Right:
                material.SetFloat("_Rotation", 0);
                break;
        }

        pixelSize = mask.preserveAspect ? mask.sprite.rect.size * resolution : GetComponent<RectTransform>().sizeDelta * resolution;
        ratio = spherize ? Vector2.one : pixelSize.normalized;

        material.SetVector("_PixelSize", pixelSize);
        material.SetVector("_Ratio", ratio);
        material.SetFloat("_BorderNoiseScale", borderNoiseScale);
        material.SetColor("_Color", barColor);
        material.SetFloat("_InsideNoiseScale", insideNoiseScale);
        material.SetFloat("_Spherize", spherize ? 1 : 0);
        material.SetFloat("_InsideNoiseIntensity", insideNoiseIntensity);
        material.SetFloat("_BorderDistortionAmount", borderDistortionAmount);
        material.SetColor("_BackgroundColor", backgroundColor);
        material.SetFloat("_InsideNoiseRoundFactor", insideNoiseColorVariation);
    }

    private void OnApplicationQuit()
    {
        // If the transition occurs and the game is stopped, reset the transition effect.

        material.SetFloat("_DissolveAmount", 0);
        material.SetFloat("_DissolveTransition", 0);
    }

    #endregion

}
