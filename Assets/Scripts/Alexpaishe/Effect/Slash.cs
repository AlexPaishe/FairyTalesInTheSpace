using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    [SerializeField] private Material _slash;
    [SerializeField] private float _lenghtSpeed;
    [SerializeField] private float _alphaSpeed;
    [SerializeField] private float _speed;
    private float _lenght;
    private float _alpha;
    public float LenghtSplash
    {
        get { return _lenght; }
        set { _lenght = value; _slash.SetFloat("_Rectangle", _lenght); }
    }

    public float Alpha
    {
        get { return _alpha; }
        set { _alpha = value; _slash.SetFloat("_Alpha", _alpha); }
    }

    private void Awake()
    {
        Alpha = 0;
        LenghtSplash = 1;
    }
    public void SlashOn()
    {
        StartCoroutine(StartSlash());
    }

    IEnumerator StartSlash()
    {
        LenghtSplash = 1;
        Alpha = 1;
        while(LenghtSplash >= 0)
        {
            LenghtSplash -= _lenghtSpeed * Time.deltaTime;
            yield return new WaitForSeconds(_speed);
        }
        while (Alpha >= 0)
        {
            Alpha -= _alphaSpeed * Time.deltaTime;
            yield return new WaitForSeconds(_speed);
        }
        Alpha = 0;
    }
}
