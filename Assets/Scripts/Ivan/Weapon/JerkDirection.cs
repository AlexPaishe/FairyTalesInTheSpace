using UnityEngine;
using UnityEngine.UI;

public class JerkDirection : MonoBehaviour
{
    public float TimeCharg => _timer;

    private Image _fillingImage;
    private float _timer = 0;

    private void Start()
    {
        _fillingImage = GetComponent<Image>();
        _fillingImage.fillAmount = 0;
    }

    public void FillDirection(float persent)
    {
        _fillingImage.fillAmount = persent;
    }
}
