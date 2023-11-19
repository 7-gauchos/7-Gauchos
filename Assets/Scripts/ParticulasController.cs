using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum PosicionCarta { Carta_1, Carta_2, Carta_3 }
public class ParticulasController : MonoBehaviour
{
    [Header("Referencias Carta")]
    
    [SerializeField]
    PosicionCarta posicion_Carta;
    Dictionary<float, float> dic_Posiciones = new Dictionary<float, float>();
    [SerializeField]
    Transform cartaTransform;
    [Header("Particulas")]
    ParticleSystem particulas;
    // Start is called before the first frame update
    void Start()
    {
        dic_Posiciones = new Dictionary<float, float>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
