using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorDinero : MonoBehaviour
{
    
    TextMeshProUGUI textoDinero;

    public void setDinero(float dinero)
    {
        if(textoDinero != null)
            textoDinero.text = dinero.ToString();

    }
    public IEnumerator EfectoDeCambio(float monto, float dinerobase)
    {
        textoDinero.color = monto < 0 ? Color.red : Color.green;
        float suma = monto > 0 ? 1 : -1;
        monto = Mathf.Abs(monto);
        float espera = (1 / monto);
     
     

        while(monto > 0) 
        {
            print(monto);
            yield return new WaitForSecondsRealtime(espera);
            dinerobase += suma;
            textoDinero.text = (dinerobase).ToString();
          
            monto--;

        }
        textoDinero.color = Color.white;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        textoDinero = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
