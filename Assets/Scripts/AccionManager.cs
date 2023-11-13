using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AccionManager : MonoBehaviour
{
    public List<Accion> acciones = new List<Accion>();

    public void CrearAcciones()
    {
        acciones.Add(new Accion());
        acciones.Add(new Accion());
        acciones.Add(new Accion());
    }

    public void LimpiarAcciones()
    {
        acciones = new List<Accion>();
    }

    public void DefinirValoresAcciones(List<Personaje> personajes)
    {
        /*
        if (valoresFelicidad.Count == listaAcciones_.Count)
        {
            for (int i = 0; i < listaAcciones_.Count; i++)
            {
                listaAcciones_[i].AutoDefinirse(valoresFelicidad[i]);
            }

        }*/
        Debug.Log(personajes.Count.ToString());
        for (int i = 0; i < acciones.Count; i++)
        {
            acciones[i].AutoDefinirse(personajes[i].felicidad);
        }

    }

    /*public AccionesManager()
    {
        listaAcciones_ = new List<Accion>();
    }

    public void AgregarALaLista(Accion a)
    {
        listaAcciones_.Add(a);
    }



    public void DefinirValoresAcciones(List<int> valoresFelicidad)
    {
        if (valoresFelicidad.Count == listaAcciones_.Count)
        {
            for (int i = 0; i<listaAcciones_.Count;i++) 
            {
                listaAcciones_[i].AutoDefinirse(valoresFelicidad[i]);
            }

        }

    }

    public void DefinirValoresAcciones(int valoresFelicidad,int indice)
    {
       
      listaAcciones_[indice].AutoDefinirse(valoresFelicidad);
            

    }
    */
}
