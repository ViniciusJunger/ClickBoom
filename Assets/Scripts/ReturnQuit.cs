using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ReturnQuit : MonoBehaviour
{
    // Start is called before the first frame update

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {

#if UNITY_EDITOR    //ESSE # É PARA O COMPILADOR, ELE VAI LER A CONDIÇÃO, COMPILAR UM, DESCARTAR OUTRO
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player --> LINHA CINZA É BUG DO VISUAL STUDIO, MAS FUNCIONA
#endif
    }
}
