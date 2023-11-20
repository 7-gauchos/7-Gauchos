
using System.Collections.Generic;
using UnityEngine;
using System;
public class GeneratorQuote
{
    private List<string> F_Trabajo = new List<string>
   {
    "Se adelant� la fecha de entrega",
    "Perd� el trabajo del mes (ese pdf estaba raro)",
    "Una reuni�n de 15min dur� todo el d�a",
    "Toqu� el enchufe que estaba en corto",
    "No pude almorzar",
    "Perd� mi taza de caf�",
    "Jornada normal, 8 horas y a al rancho",
    "La reuni�n de 15min, dur� 15min",
    "Por mantenimiento, la jornada se redujo media hora",
    "Almorc� gratis con la tarjeta de la empresa",
    "Mi jefe me regal� una taza",
    "Mi jefe me dio la raz�n",
    "Atend� un solo cliente",
    "Declararon asueto de medio d�a"
};

    private List<string> F_Ocio = new List<string>
    {
    "Se suspendi� el recital por lluvia",
    "Manch� mi remera de la suerte",
    "Se olvidaron de m� jugando a la escondida, sal� a las 2 horas",
    "Mi equipo favorito perdi� la final",
    "Se cort� la luz",
    "Me cancelaron a �ltimo momento",
    "Navegu� en el internet",
    "Me puse a ver tele",
    "Sal� a caminar",
    "Tom� mate con un amigo",
    "Fui al cine, me encant� la pel�cula",
    "Gan� Boca",
    "Tarde de juegos de mesa",
    "Gan� el torneo"
};


    private List<string> F_Descanso = new List<string>
 {
    "Dorm� torcido",
    "Tuve una pesadilla",
    "Gan� Pachorra",
    "Dorm� siesta",
    "Me qued� colgado mirando por la ventana",
    "Dorm� 8 horas"
};

    private List<string> F_Suerte = new List<string>
    {
    "Gan� una apuesta en la carrera de caracoles",
    "La factura de internet estaba mal, no tuve que pagar",
    "La abuela me mand� morfi",
    "So�� con Messi"
};

    private List<string> F_Desastre = new List<string>
    {
    "Se desbord� el r�o, se inund� la casa",
    "Terremoto, casa nueva",
    "Perd� las llaves del auto",
    "Me mordi� un perro"
};

    private List<string> D_Trabajo = new List<string>
    {
    "Quem� la computadora del trabajo",
    "Desenchuf� la heladera, la comida se ech� a perder",
    "Tuve un accidente laboral (no me lo cubren)",
    "Present� los vi�ticos fuera de fecha",
    "Llegu� tarde, me descontaron",
    "Rompi� algo en el trabajo",
    "Me rajaron",
    "Periodo de prueba en el laburo nuevo",
    "Una chang�ita",
    "Vend� algo de la casa",
    "\"Trabajo, muy duro, como un esclavo\"",
    "Cumpl� el objetivo (palmaditas en la espalda)",
    "Cobr� el Aguinaldo",
    "Hice horas extra, las pizzas estaban muy buenas"
};

    private List<string> D_Ocio = new List<string>
    {
    "El casino hizo de las suyas",
    "Compr� un juego, descubr� un nuevo impuesto",
    "Pelotazo en la cara: lentes nuevos",
    "La fuente de la compu dijo basta",
    "El cup�n de descuento no descont�",
    "Se venci� la yerba: al almac�n",
    "Me invitaron a comer",
    "Pas� por un festival en la plaza",
    "Acert� todos los resultados del f�tbol infantil",
    "La subasta del cromo de Steam fue re�ida",
    "En el campeonato de truco gan� el premio a la barba m�s larga",
    "Mis bailes de TikTok est�n generando ingresos",
    "Vend� una pintura del primario a una galer�a",
    "Gan� en el bingo"
};

    private List<string> D_Descanso = new List<string>
    {
    "Me descubrieron jugando en el trabajo.",
    "Baj� el d�lar: chau ahorros (1U$)",
    "Ac� tampoco pas�",
    "No pas� nada",
    "Bitcoin subi�, ahora mis crypto valen 0,0000005% m�s",
    "La abuela me dio plata como si fuera droga"
};

    private List<string> D_Suerte = new List<string>
    {
    "Encontr� una billetera (le dej� los documentos)",
    "Gan� la rifa asociaci�n de canaricultores: una bolsa de alpiste",
    "Le pifiaron el CBU: muchas gracias"
};

    private List<string> D_Desastre = new List<string>
    {
    "Me desbalijaron la casa",
    "Las cubiertas originales, eran originales de China",
    "AFIP: \"detectamo movimientos sospechosos\"",
    "Chapuz�n: tel�fono incluido"
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
            auxString = auxT.Felicidad[auxIndiceFelicidad] + " y " + auxT.Dinero[auxIndiceDinero];
        }
        else if ((dinero < 0 && felicidad >= 0) || (dinero >= 0 && felicidad < 0))
        {
            // tomar ambas y sumarlas con "pero"
            auxString = auxT.Felicidad[auxIndiceFelicidad] + " pero " + auxT.Dinero[auxIndiceDinero];
        }
        return auxString;
    }

    private int Mapeo(int v,int minV, int maxV,int minI,int maxI)
    {
        int auxI;
        // (n-min-n)*(maxIndice-minIndice)/(maximoN-minimoN)+minIndice
        // A�adido valor absoluto por error de indice negativo , posible parche?
        auxI = ((v - minV) * (maxI - minI) / (maxV - minV) + minI);
        auxI = Math.Clamp(auxI,minI,maxI);
        // Debug.Log("Indice nuevo: "+auxI);
        return auxI;
    }
}
