using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMoodEmoji : MonoBehaviour {

    [SerializeField]
    private Image meterValue;
    [SerializeField]
    private Sprite veryHappy, happy, neutral, sad, verySad;
	
	// Update is called once per frame
	private void Update () {
        if (meterValue.fillAmount <= 1f && meterValue.fillAmount >= 0.8f) {
            gameObject.GetComponent<Image>().sprite = veryHappy;
            meterValue.color = new Color32(139, 195, 74, 255);
        }

        if (meterValue.fillAmount <= 0.8f && meterValue.fillAmount >= 0.6f) {
            gameObject.GetComponent<Image>().sprite = happy;
            meterValue.color = new Color32(203, 215, 84, 255);
        }

        if (meterValue.fillAmount <= 0.6f && meterValue.fillAmount >= 0.4f) {
            gameObject.GetComponent<Image>().sprite = neutral;
            meterValue.color = new Color32(255, 209, 46, 255);
        }

        if (meterValue.fillAmount <= 0.4f && meterValue.fillAmount >= 0.2f) {
            gameObject.GetComponent<Image>().sprite = sad;
            meterValue.color = new Color32(255, 163, 46, 255);
        }

        if (meterValue.fillAmount <= 0.2f && meterValue.fillAmount >= 0f) {
            gameObject.GetComponent<Image>().sprite = verySad;
            meterValue.color = new Color32(255, 76, 76, 255);
        }
	}
}
