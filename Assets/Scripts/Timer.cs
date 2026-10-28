using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
       public float time;

       public TextMeshProUGUI timerText;

       public bool isPaused;
      public  void Update()
    {
        if (isPaused)
        {
            
        }
        else
        {
            
            time -= Time.deltaTime;

            timerText.text = time.ToString();
        }

    }

}
