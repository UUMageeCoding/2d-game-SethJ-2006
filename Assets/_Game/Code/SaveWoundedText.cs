using UnityEngine;

public class SaveWoundedText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 moveSpeed = new Vector3(0, 75, 0);
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
