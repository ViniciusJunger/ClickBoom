using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gM;
    public ParticleSystem explosion;

    protected float minImpulse = 7.0f;
    protected float maxImpulse = 14.0f;
    protected float torqueRange = 2.0f;
    //SerializeField deixa a variável aparecer no Unity para setar valores, sem a deixar pública (disponível para outros métodos)
    [SerializeField] protected float positionRange = 4.0f;
    protected float zMin = 0f;
    protected float zMax = 2f;
    public int pontos;

    private AudioSource audioSRC;
    public AudioClip sound;


    // Start is called before the first frame update
    void Start()
    {

        audioSRC = GetComponent<AudioSource>();
        targetRb = GetComponent<Rigidbody>();
        gM = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(impulser(), ForceMode.Impulse);
        targetRb.AddRelativeTorque(torqueRanger(), torqueRanger(), torqueRanger(), ForceMode.Impulse);
        transform.position = positioner();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    float torqueRanger()
    {
        return Random.Range(-torqueRange, torqueRange);
    }

    Vector3 impulser()
    {
        return new Vector3(0, ReturnImpulse(), 0);
    }

    public void OnMouseDown()
    {


        if (gM.oJogoContinua)
        {
            AudioSource.PlayClipAtPoint(sound, new Vector3(0, 5, 0), 1.0f);
            gM.updateScore(pontos);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);

        }
    }

    public virtual Vector3 positioner()
    {  
        return new Vector3(Random.Range(-positionRange, positionRange), -1, ReturnZ());
    }

    public virtual float ReturnZ()
    {
        float Z = Random.Range(zMin, zMax);
        return Z;
    }

    public virtual float ReturnImpulse()
    {
        float max = maxImpulse;
        float min = minImpulse;
        float Imp = Random.Range(min, max);
        return Imp;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Isso só funciona pois já tem um objeto chamado SENSOR que é a única coisa com TRIGGER ativo na cena
        // SENSOR é uma linha abaixo da tela para destruir os objetos
        Destroy(gameObject);

        if(!gameObject.CompareTag("Bad"))
        {
            gM.gameOver();
        }
}

}
