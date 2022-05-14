using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FillingReadiAttak : MonoBehaviour
{
    [SerializeField] private WeaponLoader _weaponLoader;
    [SerializeField] private Events _events;

    private Image _fillingImage;
    private float _timeReadyFastAttack;
    private float _timer = 0;
    private bool _isReady = true;

    private void Start()
    {
        _fillingImage = GetComponent<Image>();
        _timeReadyFastAttack = _weaponLoader.CurrentWeapon.TimeReadyFastAttack;
        _events.OnJerkEvent += SetReady;
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
            }
        }
    }

    private void SetReady(bool isStartedAttak)
    {
        if(isStartedAttak == false)
        {
            if (_isReady == true)
            {
                _timer = 0;
                _isReady = false;
            }
        }
    }

    private void OnDisable()
    {
        _events.OnJerkEvent -= SetReady;
    }
}
