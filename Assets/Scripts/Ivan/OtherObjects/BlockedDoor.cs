using UnityEngine;

public class BlockedDoor : MonoBehaviour
{
    [SerializeField] private KeyDoorType _keyType;

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
                    //_keyStorage.RemoveKey(_keyType); //��������������, ���� �����, ���� ����� ������������ ��� �������� ������
                    Open();
                }
                else
                {
                    _message.DisplayMessage($"� ��� ��� {ColourKey(_keyType)} �����");
                }
            }
        }
    }

    private void Open()
    {
        _animator.Play("Open");
        _isOpen = true;
    }

    private string ColourKey (KeyDoorType key)
    {
        switch (key)
        {
            case KeyDoorType.Red:
                return "��������";
            case KeyDoorType.Green:
                return "��������";
            case KeyDoorType.Blue:
                return "������";
            case KeyDoorType.Yellow:
                return "�������";
                default: return "";
        }
    }
}