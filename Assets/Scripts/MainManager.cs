using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScore;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;




    private string nomeMelhorJogador;
    private string nomeJogadorAtual;
    private int recorde;


    // Start is called before the first frame update
    void Start()
    {
        LoadDados();
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        nomeJogadorAtual = staticName.nomeDigitado;
        ScoreText.text = $"Placar atual \n" + nomeJogadorAtual + " | 0";
        BestScore.text = $"Melhor placar \n" + nomeMelhorJogador + " | " + recorde;




        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }


    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Placar atual \n" + nomeJogadorAtual + " | " + m_Points;
        BestScore.text = $"Melhor placar \n" + nomeMelhorJogador + " | " + recorde;

        if(m_Points > recorde)
        {
            salvarDados();
        }


    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }







    public void ZerarPlacar()
    {
        SaveData data = new SaveData();
        data.melhorJogador = "Vazio";
        data.maiorPontuacao = 0;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        SceneManager.LoadScene(1);

    }




    [System.Serializable] // Esse tipo de  atributo é necessário para classes que usam meódos JSON
    class SaveData
    {
        public int maiorPontuacao;
        public string melhorJogador;
    }

    public void salvarDados()
    {

        SaveData data = new SaveData();
        data.melhorJogador = nomeJogadorAtual;
        data.maiorPontuacao = m_Points;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadDados()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nomeMelhorJogador = data.melhorJogador;
            recorde = data.maiorPontuacao;
        }
        else
        {
            nomeMelhorJogador = "Vazio";
            recorde = 0;
        }
    }

}
