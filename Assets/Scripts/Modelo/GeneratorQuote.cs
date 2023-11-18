
using System.Collections.Generic;
using UnityEngine;
using System;
public class GeneratorQuote
{
    private List<string> F_Trabajo = new List<string>
   {
    "Se adelantó la fecha de entrega",
    "Perdí el trabajo del mes (ese pdf estaba raro)",
    "Una reunión de 15min duró todo el día",
    "Toqué el enchufe que estaba en corto",
    "No pude almorzar",
    "Perdí mi taza de café",
    "Jornada normal, 8 horas y a al rancho",
    "La reunión de 15min, duró 15min",
    "Por mantenimiento, la jornada se redujo media hora",
    "Almorcé gratis con la tarjeta de la empresa",
    "Mi jefe me regaló una taza",
    "Mi jefe me dio la razón",
    "Atendí un solo cliente",
    "Declararon asueto de medio día"
};

    private List<string> F_Ocio = new List<string>
    {
    "Se suspendió el recital por lluvia",
    "Manché mi remera de la suerte",
    "Se olvidaron de mí jugando a la escondida, salí a las 2 horas",
    "Mi equipo favorito perdió la final",
    "Se cortó la luz",
    "Me cancelaron a último momento",
    "Navegué en el internet",
    "Me puse a ver tele",
    "Salí a caminar",
    "Tomé mate con un amigo",
    "Fui al cine, me encantó la película",
    "Ganó Boca",
    "Tarde de juegos de mesa",
    "Gané el torneo"
};


    private List<string> F_Descanso = new List<string>
 {
    "Dormí torcido",
    "Tuve una pesadilla",
    "Ganó Pachorra",
    "Dormí siesta",
    "Me quedé colgado mirando por la ventana",
    "Dormí 8 horas"
};

    private List<string> F_Suerte = new List<string>
    {
    "Gané una apuesta en la carrera de caracoles",
    "La factura de internet estaba mal, no tuve que pagar",
    "La abuela me mandó morfi",
    "Soñé con Messi"
};

    private List<string> F_Desastre = new List<string>
    {
    "Se desbordó el río, se inundó la casa",
    "Terremoto, casa nueva",
    "Perdí las llaves del auto",
    "Me mordió un perro"
};

    private List<string> D_Trabajo = new List<string>
    {
    "Quemé la computadora del trabajo",
    "Desenchufé la heladera, la comida se echó a perder",
    "Tuve un accidente laboral (no me lo cubren)",
    "Presenté los viáticos fuera de fecha",
    "Llegué tarde, me descontaron",
    "Rompió algo en el trabajo",
    "Me rajaron",
    "Periodo de prueba en el laburo nuevo",
    "Una changüita",
    "Vendí algo de la casa",
    "\"Trabajo, muy duro, como un esclavo\"",
    "Cumplí el objetivo (palmaditas en la espalda)",
    "Cobré el Aguinaldo",
    "Hice horas extra, las pizzas estaban muy buenas"
};

    private List<string> D_Ocio = new List<string>
    {
    "El casino hizo de las suyas",
    "Compré un juego, descubrí un nuevo impuesto",
    "Pelotazo en la cara: lentes nuevos",
    "La fuente de la compu dijo basta",
    "El cupón de descuento no descontó",
    "Se venció la yerba: al almacén",
    "Me invitaron a comer",
    "Pasé por un festival en la plaza",
    "Acerté todos los resultados del fútbol infantil",
    "La subasta del cromo de Steam fue reñida",
    "En el campeonato de truco gané el premio a la barba más larga",
    "Mis bailes de TikTok están generando ingresos",
    "Vendí una pintura del primario a una galería",
    "Gané en el bingo"
};

    private List<string> D_Descanso = new List<string>
    {
    "Me descubrieron jugando en el trabajo.",
    "Bajó el dólar: chau ahorros (1U$)",
    "Acá tampoco pasó",
    "No pasó nada",
    "Bitcoin subió, ahora mis crypto valen 0,0000005% más",
    "La abuela me dio plata como si fuera droga"
};

    private List<string> D_Suerte = new List<string>
    {
    "Encontré una billetera (le dejé los documentos)",
    "Gané la rifa asociación de canaricultores: una bolsa de alpiste",
    "Le pifiaron el CBU: muchas gracias"
};

    private List<string> D_Desastre = new List<string>
    {
    "Me desbalijaron la casa",
    "Las cubiertas originales, eran originales de China",
    "AFIP: \"detectamo movimientos sospechosos\"",
    "Chapuzón: teléfono incluido"
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
        // Añadido valor absoluto por error de indice negativo , posible parche?
        auxI = ((v - minV) * (maxI - minI) / (maxV - minV) + minI);
        auxI = Math.Clamp(auxI,minI,maxI);
        // Debug.Log("Indice nuevo: "+auxI);
        return auxI;
    }
}
