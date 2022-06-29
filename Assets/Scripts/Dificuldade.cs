using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dificuldade : MonoBehaviour
{
    public Button botao;
    public GameManager gM;
    public int dificuldade;

    // Start is called before the first frame update
    void Start()
    {

        botao = GetComponent<Button>();
        gM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        botao.onClick.AddListener(definirDificuldade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void definirDificuldade()
    {
        Debug.Log("Dificuldade " + botao.gameObject.name + " foi escolhida.");
        gM.StartGame(dificuldade);
    }


}
