using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticName : MonoBehaviour
{
    public static string nomeDigitado;
    public static staticName Instance;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //Debug.Log(nome);
        //  LoadColor();
    }
}
