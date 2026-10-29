using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    public float time;
    [SerializeField] float deadTime;
    [SerializeField] UnityEvent onEndTime;
    public TextMeshProUGUI timerText;

    public bool isPaused;
    public void Update()
    {
        if (isPaused)
        {

        }
        else
        {
            if (time > deadTime)
            {
                time -= Time.deltaTime;

            }
            else
            {
                if (!isPaused)
                {
                    onEndTime.Invoke();
                }
                isPaused = true;
            }
            if (timerText != null)
                timerText.text = time.ToString("F0");
        }

    }

}
