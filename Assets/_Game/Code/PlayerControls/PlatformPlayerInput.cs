using UnityEngine;

public class PlatformPlayerInput : MonoBehaviour
{
    public static UserInput instance;

    [HideInInspector] public Controls controls;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
