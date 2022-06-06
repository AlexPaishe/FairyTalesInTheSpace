using UnityEngine;

public class BlockedDoor : MonoBehaviour
{
    [SerializeField] private KeyDoorType _keyType;
    [SerializeField] private Sound _sound;
    [SerializeField] private GameObject _triggerDoor;

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
                    _message.DisplayMessage($"Нужен {TextColorKey(_keyType)} ключ", ColorKey(_keyType));
                    _sound.SoundPlay(1);
                }
            }
        }
    }

    public virtual void Open()
    {
        _animator.Play("Open");
        _sound.SoundPlay(0);
        _triggerDoor.SetActive(false);
        _isOpen = true;
    }

    private string TextColorKey (KeyDoorType key)
    {
        switch (key)
        {
            case KeyDoorType.Red:
                return "красный";
            case KeyDoorType.Green:
                return "зеленый";
            case KeyDoorType.Blue:
                return "синий";
            case KeyDoorType.Yellow:
                return "желтый";
                default: return "";
        }
    }

    private Color ColorKey(KeyDoorType key)
    {
        switch (key)
        {
            case KeyDoorType.Red:
                return Color.red;
            case KeyDoorType.Green:
                return Color.green;
            case KeyDoorType.Blue:
                return Color.blue;
            case KeyDoorType.Yellow:
                return Color.yellow;
            default: return Color.white;
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
