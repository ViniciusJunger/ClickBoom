using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pera;
    public GameObject biscoito;
    public GameObject carne;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        cronometro(timer);
    }

    // Update is called once per frame
    void Update()
    {
      
       
    }

    private void SpawnObject()
    {


            Instantiate(pera);

            Instantiate(biscoito);

            Instantiate(carne);

    }

    IEnumerator cronometro(float timer)
    {
        yield return new WaitForSeconds(timer);
        SpawnObject();
    }
}
