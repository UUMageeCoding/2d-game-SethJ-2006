using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarText;
    public PlatformCharacterHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // player
        // healthSlider.value = CalculateSliderPercentage();
        // healthBarText.text = "HP " + _ + " / " + 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
