using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
        [SerializeField] private TMP_Text FPSdataText;
        [SerializeField] private TMP_Text SugarDataText;
        [SerializeField] private TMP_Text ProteinDataText;
        [SerializeField] private TMP_Text WaterDataText;
        [SerializeField] private TMP_Text HeatDataText;
        private float deltaTime = 0.0f;

        void Update()
        {
                deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
                float fps = 1.0f / deltaTime;

                FPSdataText.text = $"{fps:0.}";
                SugarDataText.text = $"{Eater.Instance.consumedSugar}";
                ProteinDataText.text = $"{Eater.Instance.consumedProtein}";
                WaterDataText.text = $"{Eater.Instance.consumedWater}";
                HeatDataText.text = $"{Eater.Instance.consumedHeat}";
        }
}
