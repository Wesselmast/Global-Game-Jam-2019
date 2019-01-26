using UnityEngine;
using UnityEngine.UI;

public class Personalizer : MonoBehaviour {
    //private enum Gender { Male, Female };
    //private Gender gen;
    private Text text;
    private Interest inte;

    //private string[] firstMaleNames = {
    //    "James", "David", "Christopher", "George",
    //    "Ronald", "John", "Richard", "Daniel", "Kenneth",
    //    "Antony", "Robert", "Charles", "Paul", "Steven",
    //    "Kevin", "Michael", "Joseph", "Mark", "Edward", "Jason"
    //};

    //private string[] firstFemaleNames = {
    //    "Mary", "Jennifer", "Lisa", "Sandra",
    //    "Michelle", "Patricia", "Maria", "Nancy", "Donna",
    //    "Laura", "Linda", "Susan", "Karen", "Carol",
    //    "Sarah", "Barbara", "Margaret", "Betty", "Ruth", "Kimberly"
    //};

    //private string[] lastNames = {
    //    "Smith", "Hall", "Steward", "Price",
    //    "Johnson", "Allen", "Sanchez", "Bennett", "Williams",
    //    "Young", "Morris", "Wood", "Jones", "Brown",
    //    "King", "Wright", "Thompson", "Howard", "Washington", "Butler"
    //};

    private void Awake () {
        text = GetComponentInChildren<Text>();
        inte = GetComponent<Interest>();
    }

    private void Start() {
        //texts[1].text = Random.Range(0, 2) == 1 ?
        //firstMaleNames[Random.Range(0, firstMaleNames.Length - 1)] + " " + lastNames[Random.Range(0, lastNames.Length - 1)] :
        //firstFemaleNames[Random.Range(0, firstFemaleNames.Length - 1)] + " " + lastNames[Random.Range(0, lastNames.Length - 1)];
    }

    private void FixedUpdate() {
        text.text = "I'd like to " + inte.CurrentNeed.ToString();
    }
}