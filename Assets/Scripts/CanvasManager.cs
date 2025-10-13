using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject stats;
    [SerializeField] private GameObject showStatsButton;
    [SerializeField] private TMP_Text buttonText;

    public event Action<bool> activateUI;

    public void ToggleButton()
    {
        if (showStatsButton.activeSelf)
        {
            showStatsButton.SetActive(false);
            stats.SetActive(false);
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
            stats.SetActive(false);
            buttonText.text = "Show stats";
        }
        else if (!stats.activeSelf)
        {
            stats.SetActive(true);
            buttonText.text = "Hide stats";
        }

    }
}
