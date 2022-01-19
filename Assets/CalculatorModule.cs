using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalculatorModule : MonoBehaviour
{
    [SerializeField]
    public TextMeshPro[] digits;
    public int problemDigit;
    private Vector3 originalDigits;
    private List<int> enteredDigits = new List<int>();
    [SerializeField]
    private List<Vector3> possibleProblems = new List<Vector3>();

    private void Start() {
        // 50% chance to get set the original digits from possbileProblems, 50% chance to get a random problem
        if ((int)Random.Range(0, 2) == 0) {
            int index = Random.Range(0, possibleProblems.Count);
            originalDigits = possibleProblems[index];
        } else {
            originalDigits.x = (int)Random.Range(0, 10);
            originalDigits.y = (int)Random.Range(0, 10);
            originalDigits.z = (int)Random.Range(0, 10);
        }
        displayProblem();
        // convert int array into a single number, index 0 being the one's digit
        problemDigit = (int)(originalDigits.z + (originalDigits.y * 10) + (originalDigits.x * 100));

    }

    // Update is called once per frame
    void Update()
    {
        // if enteredDigit is not null, display it in the correct digit text
        if (enteredDigits.Count >= 3) {
            checkAnswer();
            enteredDigits = new List<int>();
            displayProblem();
        }
        if (enteredDigits.Count != 0) {
            for (int i = 0; i < 3; i++)
            {
                if (i < enteredDigits.Count) {
                    digits[i].text = enteredDigits[i].ToString();
                } else {
                    digits[i].text = "";
                }
            }
        }
    }

    private void displayProblem() {
        digits[0].text = originalDigits.z.ToString();
        digits[1].text = originalDigits.y.ToString();
        digits[2].text = originalDigits.x.ToString();
    }

    private void checkAnswer() {
        // do nothing yet
    }

    public void enterDigit(int value) {
        if (value == -1) {
            // backspace
            if (enteredDigits.Count > 0) {
                enteredDigits.RemoveAt(0);
            }
        } else {
            enteredDigits.Add(value);
        }
        if (enteredDigits.Count == 0) {
            displayProblem();
        }
    }
}
