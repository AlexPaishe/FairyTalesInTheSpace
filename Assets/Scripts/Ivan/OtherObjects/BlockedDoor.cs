using UnityEngine;

public class BlockedDoor : MonoBehaviour
{
    [SerializeField] private KeyDoorType _keyType;
    [SerializeField] private Sound _sound;

    private Animator _animator;
    private KeyStorage _keyStorage;
    private PopupMessage _message;
    private bool _isOpen;

    private void Start()
    {
        _isOpen = false;
        _keyStorage = FindObjectOfType<KeyStorage>();
        _message = FindObjectOfType<PopupMessage>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isOpen == false)
        {
            if (other.transform.GetComponent<Player>())
            {
                if (_keyStorage.IsContainsKey(_keyType))
                {
                    //_keyStorage.RemoveKey(_keyType); //Разблокировать, если нужно, чтоб ключи уничтожались при открытии дверей
                    Open();
                }
                else
                {
                    _message.DisplayMessage($"У Вас нет {ColourKey(_keyType)} ключа");
                    _sound.SoundPlay(1);
                }
            }
        }
    }

    private void Open()
    {
        _animator.Play("Open");
        _sound.SoundPlay(0);
        _isOpen = true;
    }

    private string ColourKey (KeyDoorType key)
    {
        switch (key)
        {
            case KeyDoorType.Red:
                return "красного";
            case KeyDoorType.Green:
                return "зеленого";
            case KeyDoorType.Blue:
                return "синего";
            case KeyDoorType.Yellow:
                return "желтого";
                default: return "";
        }
    }

    public int ColorDoor()
    {
        int door = 0;
        switch(_keyType)
        {
            case KeyDoorType.Red: door = 0;break;
            case KeyDoorType.Blue: door = 1; break;
            case KeyDoorType.Yellow: door = 2; break;
        }
        return door;
    }
}
