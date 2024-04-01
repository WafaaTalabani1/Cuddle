using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLoad : MonoBehaviour
{
    [SerializeField] private SaveLoad saveload;
    void Start()
    {
        saveload.LoadFile();
    }

}
