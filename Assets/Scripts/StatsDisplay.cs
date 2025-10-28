using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
        [SerializeField] private TMP_Text FPSdataText;
        private float deltaTime = 0.0f;

        void Update()
        {
                deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
                float fps = 1.0f / deltaTime;

                FPSdataText.text = $"{fps:0.}";
        }
}
