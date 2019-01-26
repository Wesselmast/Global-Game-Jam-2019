using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    private Text timerText;

    private void Awake() {
        timerText = GetComponent<Text>();
    }

    private void Start() {
        GlobalCountDown.StartCountUp();
    }

    private void FixedUpdate() {
        int mins = (int)GlobalCountDown.GetTime.TotalMinutes;
        int secs = Mathf.FloorToInt((float)GlobalCountDown.GetTime.TotalSeconds % 60f);
        timerText.text = mins.ToString("00") + ":" + secs.ToString("00");
    }
}
