using UnityEngine;

public class CardPlacer : MonoBehaviour
{
    public Transform targetZone;

    void OnMouseDown()
    {
        if (targetZone != null)
        {
            transform.position = targetZone.position;
        }
    }
}
