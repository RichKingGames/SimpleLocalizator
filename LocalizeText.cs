using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour {

    private string mOriginalText;
    private Text mText;

    void Start() {
        mText = GetComponent<Text>();
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
