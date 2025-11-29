using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Menu _menu;

    public void Toggle()
    {
        _menu.ToggleSound();
    }
}