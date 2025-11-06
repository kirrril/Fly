using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject stats;

    public event Action<bool> activateUI;

    // public void ToggleButton()
    // {
    //     if (showStatsButton.activeSelf)
    //     {
    //         showStatsButton.SetActive(false);
    //         stats.SetActive(false);
    //         activateUI?.Invoke(false);
    //     }
    //     else
    //     {
    //         showStatsButton.SetActive(true);
    //         activateUI?.Invoke(true);
    //     }
    // }

    public void ToggleStats()
    {
        if (stats.activeSelf)
        {
            stats.SetActive(false);
        }
        else if (!stats.activeSelf)
        {
            stats.SetActive(true);
        }
    }
}
