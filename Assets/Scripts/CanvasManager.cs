using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject stats;
    [SerializeField] private TMP_Text debugText;
    [SerializeField] private GameObject showStatsButton;
    [SerializeField] private TMP_Text buttonText;

    public event Action<bool> activateUI;

    public void ToggleButton()
    {
        if (showStatsButton.activeSelf)
        {
            showStatsButton.SetActive(false);
            activateUI?.Invoke(false);
        }
        else
        {
            showStatsButton.SetActive(true);
            activateUI?.Invoke(true);
        }
    }

    public void ToggleStats()
    {
        if (stats.activeSelf)
        {
            Debug.Log("Click !!!!!!!!!!!!");
            stats.SetActive(false);
            buttonText.text = "Show stats";
            debugText.text = "Stats set inactive";
        }
        else if (!stats.activeSelf)
        {
            Debug.Log("Click !!!!!!!!!!!!");
            stats.SetActive(true);
            buttonText.text = "Hide stats";
            debugText.text = "Stats set active";
        }

    }
}
