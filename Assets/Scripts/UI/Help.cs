using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    [SerializeField] GameObject[] helpPanels;
    private int helpPanelIndex = 0;
    [SerializeField] Button backButton;
    [SerializeField] Button nextButton;
    public void Ok()
    {
        gameObject.SetActive(false);
        MenuManager.Instance.UpdateMenuState(MenuState.MAIN_MENU);
        SoundManager.Instance.PlaySound("menu_select");
    }
    public void Next()
    {
        if (helpPanelIndex != helpPanels.Length - 1)
        {
            helpPanels[helpPanelIndex].SetActive(false);
            helpPanelIndex++;
            helpPanels[helpPanelIndex].SetActive(true);
            if (!backButton.interactable)
            {
                backButton.interactable = true;
            }
            if (helpPanelIndex == helpPanels.Length - 1)
            {
                nextButton.interactable = false;
            }
            SoundManager.Instance.PlaySound("menu_select");
        }
    }
    public void Back()
    {
        if (helpPanelIndex != 0)
        {
            helpPanels[helpPanelIndex].SetActive(false);
            helpPanelIndex--;
            helpPanels[helpPanelIndex].SetActive(true);
            if (!nextButton.interactable)
            {
                nextButton.interactable = true;
            }
            if (helpPanelIndex == 0)
            {
                backButton.interactable = false;
            }
            SoundManager.Instance.PlaySound("menu_select");
        }
    }
}
