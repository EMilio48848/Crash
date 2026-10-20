using TMPro;
using UnityEngine;

public class Continues : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI continuesText;
    private int continuesCount;
    public bool HasContinues => continuesCount > 0;
    private void Awake()
    {
        continuesCount = PlayerPrefs.GetInt("ContinuesCount", 3);
        UpdateCOntinuesText();
    }
    private void UpdateCOntinuesText()
    {
        continuesText.text = "X" + continuesCount;
    }
    public void LoseContinue()
    {
        continuesCount--;
        PlayerPrefs.SetInt("ContinuesCount", continuesCount);
        UpdateCOntinuesText();
    }
}
