using UnityEngine;

public class SaveWoundedText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 moveSpeed = Vector3.up;
    RectTransform textTransform;


    private void Awake()
    {
        textTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        textTransform.position += moveSpeed * Time.deltaTime;
    }
}
