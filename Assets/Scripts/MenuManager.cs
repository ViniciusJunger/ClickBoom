using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField campoNome;
    public Button startButton;
    public Button FakestartButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (string.IsNullOrEmpty(campoNome.text))
        {
            startButton.gameObject.SetActive(false);
            FakestartButton.gameObject.SetActive(true);
            //Debug.Log("VAZIO");
        }
        else
        {
            // Debug.Log(campoNome.text);
            startButton.gameObject.SetActive(true);
            FakestartButton.gameObject.SetActive(false);
        }
    }
}
