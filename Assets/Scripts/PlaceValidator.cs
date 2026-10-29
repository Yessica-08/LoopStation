using UnityEngine;
using UnityEngine.Events;

public class PlaceValidator : MonoBehaviour
{
    int maxNumberPlace;

    int currentPlaceUsed;

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
