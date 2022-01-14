using UnityEngine.UI;
using UnityEngine;

public class LocalizeImage : MonoBehaviour {

    private Image img;

    void Awake() {
        img = GetComponent<Image>();
        LanguageChanged();
        Localizator.OnLanguageChanged += LanguageChanged;
    }

    void LanguageChanged() {
        img.sprite = Localizator.GetImage();
    }

    void OnDestroy() {
        Localizator.OnLanguageChanged -= LanguageChanged;
    }
}