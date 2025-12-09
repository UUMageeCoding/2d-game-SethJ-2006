using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SaveWounded : MonoBehaviour
{
    public int value;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            NumberSaved.instance.SavedCharacter(value);
            Debug.Log("Mine Worker Saved.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}