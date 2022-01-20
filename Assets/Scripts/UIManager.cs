using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public bool IsMenuShown;
    public UnityEvent OnShowMenu;
    public UnityEvent OnHideMenu;

    public void Toggle()
    {
        IsMenuShown = !IsMenuShown;

        if (IsMenuShown)
            OnShowMenu.Invoke();
        else
            OnHideMenu.Invoke();
    }
}
