using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsController : MonoBehaviour
{
    [SerializeField] private List<Button> tabs;
    [SerializeField] private List<GameObject> tabsDetails;
    [SerializeField] private Color selectedColor = Color.white;

    private Image weaponsTabImage;
    private Image pointsTabImage;
    private Image instrumentsTabImage;

    public int selectedTabIndex = 0;

    private void Awake()
    {
        weaponsTabImage = tabs[0].GetComponent<Image>();
        pointsTabImage = tabs[1].GetComponent<Image>();
        instrumentsTabImage = tabs[2].GetComponent<Image>();
        OnInstrumentsTabPressed();
    }

    public void OnWeaponsTabPressed()
    {
        if (selectedTabIndex != 0)
        {
            tabsDetails[selectedTabIndex].SetActive(false);
            tabs[selectedTabIndex].GetComponent<Image>().color = Color.white;
            selectedTabIndex = 0;
            tabs[selectedTabIndex].GetComponent<Image>().color = selectedColor;
            tabsDetails[selectedTabIndex].SetActive(true);
        }
    }
    public void OnPointsTabPressed()
    {
        if (selectedTabIndex != 1)
        {
            tabsDetails[selectedTabIndex].SetActive(false);
            tabs[selectedTabIndex].GetComponent<Image>().color = Color.white;
            selectedTabIndex = 1;
            tabs[selectedTabIndex].GetComponent<Image>().color = selectedColor;
            tabsDetails[selectedTabIndex].SetActive(true);
        }
    }
    public void OnInstrumentsTabPressed()
    {
        if (selectedTabIndex != 2)
        {
            tabsDetails[selectedTabIndex].SetActive(false);
            tabs[selectedTabIndex].GetComponent<Image>().color = Color.white;
            selectedTabIndex = 2;
            tabs[selectedTabIndex].GetComponent<Image>().color = selectedColor;
            tabsDetails[selectedTabIndex].SetActive(true);
        }
    }
}
