using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DiareeMeter : MonoBehaviour {

    private Image img;
    private Player player;

    private void Awake() {
        img = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }

    private void Update () {
        img.fillAmount = player.diareeeee / player.maxDiaree;
	}
}
