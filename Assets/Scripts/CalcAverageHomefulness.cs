using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class CalcAverageHomefulness : MonoBehaviour {
    private Text text;

    private void Awake() {
        text = GetComponent<Text>();
    }

    private void FixedUpdate() {
        float sum = 0;
        Interest[] ints = FindObjectsOfType<Interest>();
        for (int i = 0; i < ints.Length; i++) {
            sum += ints[i].Homefulness;
        }
        text.text = Mathf.FloorToInt(sum / ints.Length) + "%";
    }
}
