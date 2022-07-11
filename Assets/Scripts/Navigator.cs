using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class Navigator : MonoBehaviour
{


    public InputField campoNome;

    public void StartScene()
    {
        string Nome = campoNome.GetComponent<InputField>().text;
        staticName.nomeDigitado = Nome;
        //Debug.Log(Nome+" e " + staticName.nomeDigitado);
        SceneManager.LoadScene(1);

   }




}
