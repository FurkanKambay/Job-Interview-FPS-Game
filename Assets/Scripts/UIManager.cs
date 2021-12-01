using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public bool IsMenuShown;
    public UnityEvent OnShowMenu;
    public UnityEvent OnHideMenu;

    private void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            IsMenuShown = !IsMenuShown;
            if (IsMenuShown)
                OnShowMenu.Invoke();
            else
                OnHideMenu.Invoke();
        }
    }
}
