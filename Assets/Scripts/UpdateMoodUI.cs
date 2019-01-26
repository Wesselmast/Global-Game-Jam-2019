using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UpdateMoodUI : MonoBehaviour {
    private Image img;
    private Interest inte;

    private void Awake() {
        img = GetComponent<Image>();
        inte = GetComponentInParent<Interest>();
    }

    private void FixedUpdate() {
        img.fillAmount = inte.Homefulness / 100f;
    }
}