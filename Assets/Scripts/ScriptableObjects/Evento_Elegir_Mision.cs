using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Evento_Elegir_Mision", menuName = "ScriptableObjects/Events/Elegir_Mision")]
public class Evento_Elegir_Mision : ScriptableObject {
    // Evento para enviar informacion entre escena de Mision y Condicion Victoria/Derrota en Game

    // El orden deberia ser:  Dinero , Dias || Si hay mas datos, se pueden enviar modificando la Accion
    public Action<int,int> Datos_De_Mision;

}
