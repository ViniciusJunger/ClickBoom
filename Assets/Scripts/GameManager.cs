using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> props;

    public TextMeshProUGUI placar;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titulo;
    private AudioSource gmAudio;


    public float spawnRate = 1.5f;
    public int numPlacar;
    public int propNumber;
    public bool oJogoContinua;




    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (numPlacar < 0)
        {
            gameOver();
        }
    }

    IEnumerator spawnProps()
    {
        while (oJogoContinua)
        {

            float realSpawnRate = spawnRate;
            yield return new WaitForSeconds(spawnRate);
            propNumber = Random.Range(0, props.Count);
            Instantiate(props[propNumber]);
        }
    }
    //Só dá para chamar o método abaixo no Target.cs pois ele foi declarado como público
    public void updateScore(int addScore)
    {
        if (oJogoContinua)
        {
            numPlacar += addScore;
        }
        placar.text = "Placar: " + numPlacar;
    }

    public void gameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        oJogoContinua = false;
    }

    public void restartGame()
    {
        //Após puxar a CLASSE SCENE MANAGER com USING o NAMESPACE UNITYENGINE.SCENEMANAGER
        //Usamos o GetActiveScene para pegar a cena atual e o .name para pegar o nome dessa cena
        //A função LoadScene funciona com o nome da cena atual. Em vez de escrevermos o nome com string
        //usamos  a classe SceneManager, a função GetActiveScene e o método .name para pegar o nome da cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        gmAudio = GetComponent<AudioSource>();
        titulo.gameObject.SetActive(false);
        gmAudio.Play();
        oJogoContinua = true;
        StartCoroutine(spawnProps());
        updateScore(0);
     
    }
}
