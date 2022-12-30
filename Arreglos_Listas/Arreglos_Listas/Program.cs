#region ejercicio_1
//1.Dado que se tiene almacenado en una lista, los resultados de los últimos 10
//exámenes de un alumno, calcular su promedio y mostrar por pantalla las 10
//notas de los exámenes y el promedio resultante.
List<int> examen = new List<int> { 5, 8, 10, 8, 6, 1, 7, 9, 4, 6 };

int sumaNotas = examen.Sum();
int cantNotas = examen.Count;
double result = sumaNotas / cantNotas;
Console.WriteLine("EJERCICIO 1");
Console.WriteLine("El promedio de notas es: " + result);
#endregion

#region ejercicio_2
//2. Dada las edades de 20 personas guardadas en una lista, imprimir por
//pantalla cuántos son mayores de edad y cuántos no.
List<int> edades = new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
int menores = 0;
int mayores = 0;

Console.WriteLine("EJERCICIO 2");
edades.ForEach(edad =>
{
    if (edad >= 18) mayores++;
    else menores++;
});
Console.WriteLine($"Hay {mayores} mayores de edad y {menores} menores de edad.");

//no correspondia
//Persona persona = new Persona("juan", "Gonzales", new DateTime(1980, 01, 01));
//Console.WriteLine(persona.isMayorEdad());

#endregion

#region ejercicio_3
//3. Dado una lista de nombres de estudiantes, imprimir el que tenga más letras, y
//el que tenga menos letras de todos.
List<string> nombres = new List<string> { "juan", "martin", "damian", "ana", "marcela" };
string masLargo = "";
string masCorto = "";

Console.WriteLine("EJERCICIO 3");
nombres.ForEach(nom =>
{
    if (nom.Length > masLargo.Length)
        masLargo = nom;

    if (nom.Length < masCorto.Length || masCorto.Length == 0)
        masCorto = nom;
});

Console.WriteLine($"El nombre más largo es: {masLargo}; y el más corto es: {masCorto}");





#endregion

#region ejercicio_4
//4. Crear una variable para guardar los nombres de elementos para una “lista de
//supermercado”. Solicitar al usuario que ingrese el nombre de un elemento
//que va a comprar en el super y verificar que el elemento esté en la lista. Si no
//está, agregarlo e indicar que no estaba. Si está, quitarlo de la lista, y avisar
//que sí estaba. Al finalizar mostrar por pantalla los elementos que no compró y
//los que compró, pero no estaban en la lista. Si se quiere, mostrar también
//todos los elementos que el usuario compró. Para salir el usuario debe
//ingresar “fin”.
bool continuar = true;
string elemento = "";
bool buscado = false;
List<string> listaSuper = new List<string>();
List<string> noCompro = new List<string>();
Console.WriteLine("EJERCICIO 4");
do
{
    Console.WriteLine("Ingrese elemento a la lista (ingrese 'fin' para terminar)");
    elemento = Console.ReadLine();

    buscado = listaSuper.Contains(elemento);

    if (elemento == "fin")
        continuar = false;
    else
    {
        if (!buscado)
        {
            listaSuper.Add(elemento);
            noCompro.Remove(elemento);
            Console.WriteLine($"El {elemento} se agrega a la lista porque no estaba");
        }
        else
        {
            Console.WriteLine($"El {elemento} ya existe en la lista, se quitará");
            listaSuper.Remove(elemento);
            noCompro.Add(elemento);
        }
    }


} while (continuar);


listaSuper.ForEach(nom =>
    Console.WriteLine("compra: " + nom));

noCompro.ForEach(nom =>
    Console.WriteLine("no compra: " + nom));



#endregion

#region ejercicio_5
//5. Crear una matriz de 5 x 5. Almacenar una ‘I’ en lugares impares y una ‘P’ en
//lugares pares. Imprimir la matriz por pantalla
char[,] matriz = new char[5, 5];
//int dimensiones = matriz.Rank;

Console.WriteLine("EJERCICIO 5");
for (int i = 0; i < matriz.GetLength(0); i++)
{
    for (int j = 0; j < matriz.GetLength(1); j++)
    {
        if ((i + j - 1) % 2 == 0) matriz[i, j] = 'P';
        else matriz[i, j] = 'I';
        Console.Write(matriz[i, j]);
    }
    Console.WriteLine();
}



#endregion

#region ejercicio_6
//6. Se tiene una matriz de 5x7, donde 5 representa la semana de un mes y 7 los
//días de la semana. La estructura es para registrar la temperatura diaria de
//una cabina de pago, estos oscilan entre los 7 y 38 grados. Deberá llenar la
//matriz de forma aleatoria para el mes de mayo donde el primer día inicia en
//lunes y el último (31) se ubica en el miércoles (la matriz puede ser inicializada
//con valores aleatorios desde el principio del programa, no es necesario pedir
//los valores al usuario para cada posición). Se nos pide hacer lo siguiente:

int[,] tempCabina = new int[5, 7];
Random rand = new Random();
string espacio = "";
int cont = 31;

Console.WriteLine("EJERCICIO 6");
for (int i = 0; i < tempCabina.GetLength(0); i++)
{
    for (int j = 0; j < tempCabina.GetLength(1); j++)
    {
        if ((i + j) == 0 || cont == 0)
            Console.Write("  --");
        else
            if (cont != 0)
        {
            tempCabina[i, j] = (int)rand.NextInt64(7, 39);
            espacio = tempCabina[i, j] < 10 ? "   " : "  ";
            Console.Write(espacio + tempCabina[i, j]);
            cont--;
        }
    }
    Console.WriteLine();
}

//a.Obtener la temperatura más alta y baja de la semana y que día se
//produjo (lunes, martes, etc.)
//b.Promedio de temperatura de la semana.
//c. Temperatura más alta del mes y su día.

int diaMax = 0, max = diaMax;
int diaMin = 100, min = diaMin;
int sumaSemana = 0, countDiasSemana = sumaSemana;
List<Tuple<int, int, int>> ListDiaAlta = new List<Tuple<int, int, int>>();

for (int i = 0; i < tempCabina.GetLength(0); i++)
{
    for (int j = 0; j < tempCabina.GetLength(1); j++)
    {
        if (tempCabina[i, j] != 0)
        {
            if (tempCabina[i, j] > max)
            {
                max = tempCabina[i, j];
                diaMax = j;

                if (ListDiaAlta.Count == 0)
                    ListDiaAlta.Add(new Tuple<int, int, int>(i, j, max));
                else if (max >= ListDiaAlta[0].Item3)
                {
                    ListDiaAlta.Add(new Tuple<int, int, int>(i, j, max));
                }

                for (int k = 0; k < ListDiaAlta.Count; k++)
                {
                    if (ListDiaAlta[k].Item3 < max)
                        ListDiaAlta.RemoveAt(k);
                }
                //ListDiaAlta.ForEach(x =>
                //{
                //    Console.WriteLine($"i: {x.Item1}; j:{x.Item2}, max:{x.Item3}");
                //});

            }

            if (tempCabina[i, j] < min)
            {
                min = tempCabina[i, j];
                diaMin = j;
            }

            sumaSemana += tempCabina[i, j];
            countDiasSemana += 1;
        }
    }
    Console.WriteLine($"a) La temperatura máx.de la semana {i + 1} fue {max}ºC y se produjo el {(DIAS)diaMax}; y la mín. fue {min}ºC y sucedió el {(DIAS)diaMin}");
    Console.WriteLine($"b) El promedio de temperatura de la semana {i + 1} fue {sumaSemana / countDiasSemana}°C");

    sumaSemana = countDiasSemana = diaMax = max = 0;
    diaMin = min = 100;

}
ListDiaAlta.ForEach(x =>
{
    Console.WriteLine($"c) La temperatura más alta del mes fue de {x.Item3} el día {(DIAS)x.Item2}, {x.Item1 * 7 + x.Item2} de mayo");
});

#endregion

#region ejercicio_7
//7. Almacenar en una matriz las tablas del 1 al 9, teniendo en cuenta que en la
//primera fila y la primera columna se debe guardar los números (de 0 a 9),
//estando el cero en la primera posición (fila 0, columna 0). El resto de los
//lugares debe ser calculado usando los números que se dispone, por ejemplo,
//en la fila 1, calcular 1*1, 1*2, 1*3, etc. usando las posiciones del array o
//arreglo. Al finalizar el cálculo, mostrar la matriz por pantalla

Console.WriteLine("EJERCICIO 7");

int[,] matrizTabla = new int[10, 10];

for (int i = 0; i < matrizTabla.GetLength(0); i++)
{
    matrizTabla[i, 0] = i;
    for (int j = 0; j < matrizTabla.GetLength(1); j++)
    {
        if ((j == 0) || (i == 0))
            matrizTabla[0, j] = j;
        else
            matrizTabla[i, j] = matrizTabla[0, j] * matrizTabla[i, 0];

        espacio = matrizTabla[i, j] < 10 ? "   " : "  ";
        Console.Write(espacio + matrizTabla[i, j]);
    }
    Console.WriteLine();
}

#endregion


#region ejercicio_8
//8. Crear una matriz de 10 x 10, y “esconder” varias ‘X’ en lugares aleatorios (la
//cantidad que el programador decida, pero no más de la mitad de los lugares
//disponibles en la matriz). El usuario deberá ingresar el lugar donde cree que
//hay una X, ingresando la fila y la columna por separado. Informar si acertó o
//no por cada ingreso. Se debe pedir al usuario ingresar valores por tantas X
//que se haya guardado. El usuario tiene 3 intentos para fallar. Al finalizar (Ya
//sea porque se terminaron los 3 intentos, o el jugador acertó todas las X)
//imprimir por pantalla la matriz con sus correspondientes X, mostrando un *
//donde no haya nada.

Console.WriteLine("EJERCICIO 8");
int tamañoTablero = 10;
char[,] tablero = new char[tamañoTablero, tamañoTablero];
int cantDeEquis = 5;
List<int> aciertos = new List<int>();
espacio = " ";
int casilla;
int fila;
int columna;
bool isFila;
bool isCol;
int intentosRealizados = 0;
int fallos = 3;
int filasTablero = tablero.GetLength(0);
int colTablero = tablero.GetLength(1);
int[] posRandom = Valor(cantDeEquis, tablero);

Console.WriteLine($"El tablero es un tablero {tamañoTablero}x{tamañoTablero}, comienza en 1 y termina en {tamañoTablero}");

DibujadorDeMatriz();
Proceso();
Resultados();

void DibujadorDeMatriz()
{
    for (int i = 0; i < filasTablero; i++)
    {

        for (int j = 0; j < colTablero; j++)
        {
            casilla = (i * colTablero) + j;

            if (posRandom.Contains(casilla))
                tablero[i, j] = 'X';
            else
                tablero[i, j] = '*';

            Console.Write(espacio + tablero[i, j]);
        }
        Console.WriteLine();
    }
}
void Proceso()
{
    do
    {
        do
        {
            Console.WriteLine("ingrese una fila: ");
            espacio = Console.ReadLine();
            isFila = int.TryParse(espacio, out fila);

        } while (!isFila);

        do
        {
            Console.WriteLine("ingrese una columna: ");
            espacio = Console.ReadLine();
            isCol = int.TryParse(espacio, out columna);

        } while (!isCol);

        if (columna <= colTablero && fila <= filasTablero && fila > 0 && columna > 0)
        {

            if (tablero[fila - 1, columna - 1].Equals('X'))
            {
                if (!aciertos.Contains(fila * columna + columna))
                {
                    Console.WriteLine("ACERTASTE!!!");
                    aciertos.Add(fila * columna + columna);
                    intentosRealizados += 1;
                } else
                {
                    Console.WriteLine("REPETISTE!!!");
                    fallos -= 1;
                }
            }
            else
            {
                Console.WriteLine("FALLASTE!!!");
                fallos -= 1;
            }
        }
        else
            Console.WriteLine($"la matriz tiene {filasTablero} x {colTablero}, solo se admiten esos valores");


    } while ((fallos != 0) && (cantDeEquis > intentosRealizados));
}



void Resultados()
{
    aciertos.ForEach((x) => Console.WriteLine(x));
    Console.WriteLine(aciertos.Count);
    string textResultado = "Fallaste las TRES veces permitidas y quedaste afuera mi gente";
    if (fallos > 0)
        textResultado = (cantDeEquis == aciertos.Count) ? "GANASTE!!!!!" : "PERDISTE, TE QUEDASTE SIN INTENTOS";

    Console.WriteLine(textResultado);
}

#endregion

int[] Valor(int repeticion, char[,] table)
{
    Random random = new Random();
    int[] posicion = new int[repeticion];
    int casillas = filasTablero * colTablero;
    int valor;

    for (int i = 0; i < repeticion; i++)
    {
        do
        {
            valor = random.Next(0, casillas + 1);
        } while (posicion.Contains(valor));
        posicion[i] = valor;
    }

    return posicion;
}

int PesoCasilla(int filaCasilla, int colCasilla)
{
    return filaCasilla * colCasilla + filaCasilla;
}



enum DIAS
{
    domingo,
    lunes,
    martes,
    miercoles,
    jueves,
    viernes,
    sabado
};
