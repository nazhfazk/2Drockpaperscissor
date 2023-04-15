using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float countdownTime = 3f;
    public Text countdownText;

    private float currentTime = 0f;

    void Update()
    {
        currentTime += Time.deltaTime;
        int secondsLeft = Mathf.RoundToInt(countdownTime - currentTime);
        countdownText.text = secondsLeft.ToString();

        if (currentTime >= countdownTime)
        {
            BeginGameplay();
        }
    }

    public void BeginGameplay()
    {
        SceneManager.LoadScene("Gameplay"); 
    }
}