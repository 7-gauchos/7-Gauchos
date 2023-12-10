
using System.Collections.Generic;
using UnityEngine;
using System;
public class GeneratorQuote
{
    private List<string> F_Trabajo = new List<string>
   {
    "la fecha de entrega se adelant�",
    "perd� todo el trabajo del mes",
    "una reuni�n de 15 minutos dur� todo el d�a",
    "toqu� el enchufe que estaba en corto",
    "no pude almorzar",
    "perd� mi taza de caf� favorita",
    "tuve una jornada de trabajo normal. 8 horas y pal rancho",
    "la reuni�n de 15 minutos dur� 15 minutos",
    "por mantenimiento la jornada laboral se redujo media hora",
    "almorc� gratis con la tarjeta de la empresa",
    "mi jefe me regal� una taza",
    "mi jefe me dio la raz�n",
    "atend� un solo cliente en todo el dia",
    "declararon asueto de medio d�a"
};

    private List<string> F_Ocio = new List<string>
    {
    "se suspendi� el recital por lluvia",
    "manch� mi remera de la suerte",
    "se olvidaron de m� jugando a la escondida. sal� a las 2 horas",
    "mi equipo favorito perdi� la final",
    "se cort� la luz mientras jugaba al lig of Leyend",
    "me cancelaron la cita a �ltimo momento",
    "navegu� en internet mirando ",
    "me puse a ver tele",
    "sal� a caminar y tomar aire",
    "tom� mate con un amigo",
    "fui al cine. Me encant� la pel�cula",
    "gan� Boca",
    "tuve una genial tarde de juegos de mesa",
    "gan� el torneo de microfutbol"
};


    private List<string> F_Descanso = new List<string>
 {
    "dorm� torcido. Tengo contracturas por doquier",
    "tuve una pesadilla",
    "me gano la pachorra y me tuve que tirar a no hacer nada",
    "dorm� una muy buena siesta",
    "me qued� mirando por la ventana",
    "dorm� 8 horas"
};

    private List<string> F_Suerte = new List<string>
    {
    "gan� una apuesta en la carrera de caracoles",
    "la factura de internet estaba mal asi que no tuve que pagar",
    "la abuela me mand� morfi",
    "so�� con Messi"
};

    private List<string> F_Desastre = new List<string>
    {
    "se desbord� el r�o inundando toda la casa",
    "Sobreviv� a un terremoto. La casa no sobrevivi�",
    "perd� las llaves del auto",
    "me mordi� un perro.  "
};

    private List<string> D_Trabajo = new List<string>
    {
    "quem� la computadora del trabajo",
    "olvid� la heladera desenchufada. La comida se ech� a perder",
    "tuve un accidente laboral. La empresa se lav� las manos",
    "present� los vi�ticos fuera de fecha",
    "llegu� tarde otra vez. Me descontaron del sueldo.",
    "rompi la cafetera del trabajo",
    "me rajaron del laburo",
    "arranqu� con el periodo de prueba en un laburo nuevo",
    "me sali� una changuita",
    "vend� algo de la casa",
    "trabaje super duro, como esclavo. Gan� platita!",
    "cumpl� el objetivo semanal en el trabajo (\"palmaditas en la espalda\")",
    "cobr� el Aguinaldo",
    "hice horas extra.  Las pizzas que nos dieron estaban muy buenas"
};

    private List<string> D_Ocio = new List<string>
    {
    "el casino hizo de las suyas",
    "compr� un juego en Estim. Descubr� un nuevo impuesto",
    "recibi un pelotazo en la cara por una atajada �pica. Necesito lentes nuevos",
    "La fuente de la compu dijo basta",
    "el cup�n de descuento no descont�",
    "se venci� la yerba. Al almac�n de nuevo",
    "me invitaron a comer",
    "pas� por un festival en la plaza",
    "acert� todos los resultados de la liga de f�tbol infantil",
    "la subasta del cromo de Estim fue re�ida",
    "en el campeonato de truco gan� el premio a la barba m�s larga",
    "mis bailes de Tikitok est�n generando ingresos",
    "vend� una pintura del primario a una galer�a",
    "gan� en el bingo"
};

    private List<string> D_Descanso = new List<string>
    {
    "me descubrieron jugando en el trabajo",
    "baj� el d�lar. Chau ahorros",
    "me despert� de una siesta sin saber si era Martes, Junio o Invierno",
    "no pas� nada",
    "Shitcoin subi�. Ahora mis crypto valen 0,0000005% m�s",
    "la abuela me dio plata como si fuera droga"
};

    private List<string> D_Suerte = new List<string>
    {
    "encontr� una billetera (le dej� los documentos).",
    "gan� la rifa asociaci�n de canaricultores: una bolsa de alpiste",
    "Le pifiaron el CBU: muchas gracias"
};

    private List<string> D_Desastre = new List<string>
    {
    "me desvalijaron la casa.",
    "las cubiertas originales eran originales pero de China.",
    "Recibi un mail de la AFIP: \"detectamos movimientos sospechosos\"",
    "me tire a la pileta con ropa. El telefono venia conmigo."
};


    private Dictionary<string, (List<string> Felicidad, List<string> Dinero)> tipo_Accion;
    public GeneratorQuote()
    {
        tipo_Accion = new Dictionary<string, (List<string> Felicidad, List<string> Dinero)>
        {

            { "Trabajo", (F_Trabajo, D_Trabajo) },
            { "Ocio", (F_Ocio, D_Ocio) },
            { "Descanso", (F_Descanso, D_Descanso) },
            { "Suerte", (F_Suerte, D_Suerte) },
            { "Catastrofe", (F_Desastre, D_Desastre) }
            
        };
    }

    public string DevolverFrase(string tipo, int dinero, int minimoDinero, int maximoDinero,
        int felicidad, int minimoFelicidad, int maximoFelicidad)
    {
      
        var auxT = tipo_Accion[tipo];

        string auxString ="";
        int auxIndiceDinero = Mapeo(dinero, minimoDinero, maximoDinero, 0, auxT.Dinero.Count-1);
        int auxIndiceFelicidad = Mapeo(felicidad,minimoFelicidad,maximoFelicidad,0,auxT.Felicidad.Count-1);

        // Tabla de verdad para signos de costo y ganancia
        // - - se suman con un "y"
        // + + se suman con un "y"
        // - + se suman con un "pero"
        // + - se suman con un "pero"

        
        if ((dinero < 0 && felicidad < 0) || (dinero >= 0 && felicidad >= 0))
        {
            // tomar ambas y sumarlas con "y"
            auxString = auxT.Felicidad[auxIndiceFelicidad] + ". Ademas " + auxT.Dinero[auxIndiceDinero];
        }
        else if ((dinero < 0 && felicidad >= 0) || (dinero >= 0 && felicidad < 0))
        {
            // tomar ambas y sumarlas con "pero"
            auxString = auxT.Felicidad[auxIndiceFelicidad] + ". Pero  " + auxT.Dinero[auxIndiceDinero];
        }
        return string.Concat(auxString[0].ToString().ToUpper(), auxString.Substring(1));
    }

    private int Mapeo(int v,int minV, int maxV,int minI,int maxI)
    {
        int auxI;
        // (n-min-n)*(maxIndice-minIndice)/(maximoN-minimoN)+minIndice
        // A�adido valor absoluto por error de indice negativo , posible parche?
        auxI = ((v - minV) * (maxI - minI) / (maxV - minV) + minI);
        auxI = Math.Clamp(auxI,minI,maxI);
         Debug.Log("Indice nuevo: "+auxI);
        return auxI;
    }
}
