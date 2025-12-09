using UnityEngine;
using TMPro;
using Unity.Burst.Intrinsics;

public class NumberSaved : MonoBehaviour
{

    public static NumberSaved instance;
    public TMP_Text woundedText;
    public int noSaved = 0;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        woundedText.text = "NO. SAVED: " + noSaved.ToString() + " / 5";
    }

    // Update is called once per frame
    public void SavedCharacter(int v)
    {
        noSaved += v;
        woundedText.text = "NO. SAVED: " + noSaved.ToString() + " / 5";
    }
}
