using UnityEngine;
using UnityEngine.Events;

public class currentComboControll : MonoBehaviour
{
   [SerializeField] explosionProgressControl progressControl;
   [SerializeField] GameObject [] comboVisualInputs; 

    public UnityEvent correctCombo; 
   private void Start()
   {
    if(progressControl != null)
    {
        progressControl.comboUpdated.AddListener(updateComboVisual);
        progressControl.comboReset.AddListener(resetComboVisual);
        progressControl.secondChallengeComplete.AddListener(passwordCorrect);
    } 
   }

    private void passwordCorrect()
    {
        correctCombo?.Invoke(); 
    }

    private void updateComboVisual()
    {
        string currentCombo = progressControl.getCurrentCombo; 

        for (int i = 0; i < currentCombo.Length; i++)
        {
            char currentChar = currentCombo[i];
            switch (currentChar)
            {
                case 'y':
                    comboVisualInputs[i].GetComponent<SpriteRenderer>().color = Color.yellow; 
                break;
                case 'r':
                    comboVisualInputs[i].GetComponent<SpriteRenderer>().color = Color.red; 
                break;
                case 'b':
                    comboVisualInputs[i].GetComponent<SpriteRenderer>().color = Color.blue; 
                break;
            }
        }
    }

    private void resetComboVisual()
    {
        foreach (var circle in comboVisualInputs)
        {
            circle.GetComponent<SpriteRenderer>().color = Color.white; 
        }
    }
}
