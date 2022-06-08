using UnityEngine;
using UnityEngine.UI;

public class JerkDirection : MonoBehaviour
{
    public float TimeCharg => _timer;
    [SerializeField] private Material _mat;

    private float _timer = 0;

    private void Start()
    {
        _mat.SetFloat("_Move", 0);
    }

    public void FillDirection(float persent)
    {
        _mat.SetFloat("_Move", persent);
    }
}
