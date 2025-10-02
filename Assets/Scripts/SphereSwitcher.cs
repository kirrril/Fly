using UnityEngine;

public class SphereSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] spheres;

    [SerializeField]
    private GameObject selfSphere;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            selfSphere.GetComponent<MeshRenderer>().enabled = true;

            foreach (GameObject sphere in spheres)
            {
                sphere.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}