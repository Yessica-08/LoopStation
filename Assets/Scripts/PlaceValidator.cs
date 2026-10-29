using UnityEngine;
using UnityEngine.Events;

public class PlaceValidator : MonoBehaviour
{
    public int maxNumberPlace;

    public int currentPlaceUsed;

    public UnityEvent onFinish;

    public void CalculatePlaces()
    {
        currentPlaceUsed++;

        if(currentPlaceUsed >= maxNumberPlace)
        {
            onFinish.Invoke();
        }
        else
        {
            
        }
    }
}
