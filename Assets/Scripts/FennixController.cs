using UnityEngine;

public class FennixController : MonoBehaviour
{
    [SerializeField] private Transform fenixTransform;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private CanvasGroup foxPanel;

    [SerializeField] private float minDistance;

    [SerializeField] bool isNear;

   private void Update()
    {
        CalculateDistance();
    }

    public void CalculateDistance()
    {
        float distance = Vector3.Distance(playerTransform.position,fenixTransform.position);

        if(distance < minDistance && !isNear)
        {
            isNear = true; 
            foxPanel.alpha = 1;
            Debug.Log("Se acerco");
        }
        if(distance > minDistance && isNear)
        {
            isNear = false;
            foxPanel.alpha = 0;
            Debug.Log("Se aleja");
        }
    }
}
