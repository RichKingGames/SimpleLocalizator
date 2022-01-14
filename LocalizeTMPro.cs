using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LocalizeTMPro : MonoBehaviour
{
    private string mOriginalText;
    private TMP_Text mText;

    void Start()
    {
        mText = GetComponent<TMP_Text>();
        mOriginalText = mText.text;
        UpdateTranslation();

        Localizator.OnLanguageChanged += UpdateTranslation;
    }

    public void UpdateTranslation()
    {
        mText.text = Localizator.GetString(mOriginalText);
    }

    private void OnDestroy()
    {
        Localizator.OnLanguageChanged -= UpdateTranslation;
    }
}
