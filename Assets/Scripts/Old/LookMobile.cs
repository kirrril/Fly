using UnityEngine;

public class LookMobile : MonoBehaviour
{
    private Quaternion _baseRotation;

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            _baseRotation = new Quaternion(0, 0, 1, 0);
        }
        else Debug.LogWarning("Gyroscope not supported");
    }

    void Update()
    {
        if (Input.gyro.enabled)
        {
            transform.localRotation = ConvertGyroRotation(Input.gyro.attitude);
        }

    }

    private Quaternion ConvertGyroRotation(Quaternion q)
    {
        // Convertir les axes du gyroscope vers le repère Unity
        return new Quaternion(q.x, q.y, -q.z, -q.w) * _baseRotation;
    }
}
