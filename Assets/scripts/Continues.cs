using TMPro;
using UnityEngine;

public class Continues : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI continuesText;
    [SerializeField]
    private int initialContinues = 3;
    private int continuesCount;
    public bool HasContinues => continuesCount > 0;
    public void Initialize()
    {
        continuesCount = PlayerPrefs.GetInt("ContinuesCount", 3);
        if(continuesCount <= 0)
        {
            continuesCount = initialContinues;
            SetContinues(continuesCount);
        }
        UpdateContinuesText();
    }
    private void UpdateContinuesText()
    {
        if(continuesText == null)return;
        continuesText.text = "X" + continuesCount;
    }
    public void LoseContinue()
    {
        continuesCount--;
        PlayerPrefs.SetInt("ContinuesCount", continuesCount);
        UpdateContinuesText();
    }
    public void SetContinues(int count)
    {
        PlayerPrefs.SetInt("ContinuesCount", count);
    }
}
