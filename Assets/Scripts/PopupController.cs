using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel;

    public void TogglePopup()
    {
        popupPanel.SetActive(!popupPanel.activeSelf);
    }
}
