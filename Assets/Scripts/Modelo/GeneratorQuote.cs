
using System.Collections.Generic;
using UnityEngine;
using System;
public class GeneratorQuote
{
    private List<string> F_Trabajo = new List<string>
   {
    "la fecha de entrega se adelantó",
    "perdí todo el trabajo del mes",
    "una reunión de 15 minutos duró todo el día",
    "toqué el enchufe que estaba en corto",
    "no pude almorzar",
    "perdí mi taza de café favorita",
    "tuve una jornada de trabajo normal. 8 horas y pal rancho",
    "la reunión de 15 minutos duró 15 minutos",
    "por mantenimiento la jornada laboral se redujo media hora",
    "almorcé gratis con la tarjeta de la empresa",
    "mi jefe me regaló una taza",
    "mi jefe me dio la razón",
    "atendí un solo cliente en todo el dia",
    "declararon asueto de medio día"
};

    private List<string> F_Ocio = new List<string>
    {
    "se suspendió el recital por lluvia",
    "manché mi remera de la suerte",
    "se olvidaron de mí jugando a la escondida. salí a las 2 horas",
    "mi equipo favorito perdió la final",
    "se cortó la luz mientras jugaba al lig of Leyend",
    "me cancelaron la cita a último momento",
    "navegué en internet mirando ",
    "me puse a ver tele",
    "salí a caminar y tomar aire",
    "tomé mate con un amigo",
    "fui al cine. Me encantó la película",
    "ganó Boca",
    "tuve una genial tarde de juegos de mesa",
    "gané el torneo de microfutbol"
};


    private List<string> F_Descanso = new List<string>
 {
    "dormí torcido. Tengo contracturas por doquier",
    "tuve una pesadilla",
    "me gano la pachorra y me tuve que tirar a no hacer nada",
    "dormí una muy buena siesta",
    "me quedé mirando por la ventana",
    "dormí 8 horas"
};

    private List<string> F_Suerte = new List<string>
    {
    "gané una apuesta en la carrera de caracoles",
    "la factura de internet estaba mal asi que no tuve que pagar",
    "la abuela me mandó morfi",
    "soñé con Messi"
};

    private List<string> F_Desastre = new List<string>
    {
    "se desbordó el río inundando toda la casa",
    "Sobreviví a un terremoto. La casa no sobrevivió",
    "perdí las llaves del auto",
    "me mordió un perro.  "
};

    private List<string> D_Trabajo = new List<string>
    {
    "quemé la computadora del trabajo",
    "olvidé la heladera desenchufada. La comida se echó a perder",
    "tuve un accidente laboral. La empresa se lavó las manos",
    "presenté los viáticos fuera de fecha",
    "llegué tarde otra vez. Me descontaron del sueldo.",
    "rompi la cafetera del trabajo",
    "me rajaron del laburo",
    "arranqué con el periodo de prueba en un laburo nuevo",
    "me salió una changuita",
    "vendí algo de la casa",
    "trabaje super duro, como esclavo. Gané platita!",
    "cumplí el objetivo semanal en el trabajo (\"palmaditas en la espalda\")",
    "cobré el Aguinaldo",
    "hice horas extra.  Las pizzas que nos dieron estaban muy buenas"
};

    private List<string> D_Ocio = new List<string>
    {
    "el casino hizo de las suyas",
    "compré un juego en Estim. Descubrí un nuevo impuesto",
    "recibi un pelotazo en la cara por una atajada épica. Necesito lentes nuevos",
    "La fuente de la compu dijo basta",
    "el cupón de descuento no descontó",
    "se venció la yerba. Al almacén de nuevo",
    "me invitaron a comer",
    "pasé por un festival en la plaza",
    "acerté todos los resultados de la liga de fútbol infantil",
    "la subasta del cromo de Estim fue reñida",
    "en el campeonato de truco gané el premio a la barba más larga",
    "mis bailes de Tikitok están generando ingresos",
    "vendí una pintura del primario a una galería",
    "gané en el bingo"
};

    private List<string> D_Descanso = new List<string>
    {
    "me descubrieron jugando en el trabajo",
    "bajó el dólar. Chau ahorros",
    "me desperté de una siesta sin saber si era Martes, Junio o Invierno",
    "no pasó nada",
    "Shitcoin subió. Ahora mis crypto valen 0,0000005% más",
    "la abuela me dio plata como si fuera droga"
};

    private List<string> D_Suerte = new List<string>
    {
    "encontré una billetera (le dejé los documentos).",
    "gané la rifa asociación de canaricultores: una bolsa de alpiste",
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
        // Añadido valor absoluto por error de indice negativo , posible parche?
        auxI = ((v - minV) * (maxI - minI) / (maxV - minV) + minI);
        auxI = Math.Clamp(auxI,minI,maxI);
         Debug.Log("Indice nuevo: "+auxI);
        return auxI;
    }
}
