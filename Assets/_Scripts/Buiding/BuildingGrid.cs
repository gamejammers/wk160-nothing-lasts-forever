using UnityEngine;

public class BuildingGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject alertVisual = null;
    public GameObject AlertVisual => alertVisual;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) alertVisual.SetActive(true);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground") && !alertVisual.activeSelf) alertVisual.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) alertVisual.SetActive(false);
    }
}