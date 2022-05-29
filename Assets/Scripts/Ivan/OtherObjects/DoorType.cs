using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorType : MonoBehaviour
{
    [SerializeField] private BlockedDoor _door;
    [SerializeField] private Texture[] _textureDoor;
    [SerializeField] private Texture[] _centreTextureDoor;
    [SerializeField] private Renderer[] _mesh;

    private void Awake()
    {
        int door = _door.ColorDoor();
        for(int i = 0; i < _mesh.Length - 2; i++)
        {
            if(i < 2)
            {
                _mesh[i].material.mainTexture = _textureDoor[door];
            }
            else 
            {
                _mesh[i].material.mainTexture = _centreTextureDoor[door];
            }
        }

        for(int i = _mesh.Length - 2; i < _mesh.Length; i++)
        {
            EmissionMesh(i, door);
        }
    }

    private void EmissionMesh(int var, int door)
    {
        Color col = new Color(0,0,0);
        float intensity = 0;
        switch(door)
        {
            case 0: col = Color.red; intensity = 9; break;
            case 1: col = Color.blue; intensity = 9; break;
            case 2: col = Color.yellow; intensity = 8.7f; break;
        }
        _mesh[var].material.SetColor("_EmissionColor", col * Mathf.Pow(2, intensity));
    }
}
