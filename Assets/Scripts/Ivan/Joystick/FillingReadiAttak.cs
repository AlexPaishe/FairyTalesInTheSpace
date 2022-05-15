using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FillingReadiAttak : MonoBehaviour
{
    [SerializeField] private WeaponLoader _weaponLoader;

    private Image _fillingImage;
    private float _timeReadyFastAttack;
    private float _timer = 0;
    private bool _isReady = true;

    public bool IsReady => _isReady;

    private void Start()
    {
        _fillingImage = GetComponent<Image>();
        _timeReadyFastAttack = _weaponLoader.CurrentWeapon.TimeReadyFastAttack;
    }

    void Update()
    {
        if(_isReady == false)
        {
            _timer += Time.deltaTime;
            _fillingImage.fillAmount = _timer / _timeReadyFastAttack;
            if(_timer >= _timeReadyFastAttack)
            {
                _isReady = true;
                _timer = 0;
            }
        }
    }

    public void StartReadiness()
    {
        _isReady = false;
    }
}
