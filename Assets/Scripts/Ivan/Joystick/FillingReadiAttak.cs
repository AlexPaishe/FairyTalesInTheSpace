using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FillingReadiAttak : MonoBehaviour
{
    [SerializeField] private WeaponLoader _weaponLoader;
    [SerializeField] private Material _kosMat;
    [SerializeField] private DashEffect _dash;

    private Image _fillingImage;
    private float _timeReadyFastAttack;
    private float _timer = 0;
    private bool _isReady = true;

    public bool IsReady => _isReady;

    private void Start()
    {
        _fillingImage = GetComponent<Image>();
        _timeReadyFastAttack = _weaponLoader.CurrentWeapon.TimeReadyFastAttack;
        _kosMat.SetFloat("_Edge", 0);
    }

    void Update()
    {
        if(_isReady == false)
        {
            _timer += Time.deltaTime;

            _fillingImage.fillAmount = _timer / _timeReadyFastAttack;
            _kosMat.SetFloat("_Edge", _timer / _timeReadyFastAttack);
            if(_timer >= _timeReadyFastAttack)
            {
                _isReady = true;
                _timer = 0;
                _kosMat.SetFloat("_Edge", _timer);
            }
            else if(_timer > _timeReadyFastAttack / 3f)
            {
                _dash.DashOff();
            }
        }
    }

    public void StartReadiness()
    {
        _timeReadyFastAttack = _weaponLoader.CurrentWeapon.TimeReadyFastAttack;
        _isReady = false;
        _dash.DashOn();
    }
}
