using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text FPSdataText;
    [SerializeField] private TMP_Text BatchesDataText;
    [SerializeField] private TMP_Text TrisDataText;
    [SerializeField] private TMP_Text VertsDataText;
    private float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

#if UNITY_EDITOR
        int tris = UnityEditor.UnityStats.triangles;
        int verts = UnityEditor.UnityStats.vertices;
        int batches = UnityEditor.UnityStats.drawCalls;

        FPSdataText.text = $"{fps:0.}";
        BatchesDataText.text = $"{batches:0.}";
        TrisDataText.text = $"{tris:0.}";
        VertsDataText.text = $"{verts:0.}";
#else
        FPSdataText.text = $"{fps:0.}";
        BatchesDataText.text = $"-----";
        TrisDataText.text = $"-----";
        VertsDataText.text = $"-----";
#endif
    }
}
