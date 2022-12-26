using Arreglos_Listas.Class;

#region ejercicio_1
//1.Dado que se tiene almacenado en una lista, los resultados de los últimos 10
//exámenes de un alumno, calcular su promedio y mostrar por pantalla las 10
//notas de los exámenes y el promedio resultante.


List<int> examen = new List<int> { 5, 8, 10, 8, 6, 1, 7, 9, 4, 6 };

int sumaNotas = examen.Sum();
int cantNotas = examen.Count;
double result = sumaNotas / cantNotas;
Console.WriteLine("El promedio de notas es: " + result);
#endregion

#region ejercicio_2
//2. Dada las edades de 20 personas guardadas en una lista, imprimir por
//pantalla cuántos son mayores de edad y cuántos no.

List<int> edades = new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
int menores = 0;
int mayores = 0;

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
do
{
    Console.WriteLine("Ingrese elemento a la lista");
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
//5. Crear una matriz de 5 x 5. Almacenar una ‘I’ en lugares impares y una ‘P’ en
//lugares pares. Imprimir la matriz por pantalla
//6. Se tiene una matriz de 5x7, donde 5 representa la semana de un mes y 7 los
//días de la semana. La estructura es para registrar la temperatura diaria de
//una cabina de pago, estos oscilan entre los 7 y 38 grados. Deberá llenar la
//matriz de forma aleatoria para el mes de mayo donde el primer día inicia en
//lunes y el último (31) se ubica en el miércoles (la matriz puede ser inicializada
//con valores aleatorios desde el principio del programa, no es necesario pedir
//los valores al usuario para cada posición). Se nos pide hacer lo siguiente:
//a.Obtener la temperatura más alta y baja de la semana y que día se
//produjo (lunes, martes, etc.)
//b.Promedio de temperatura de la semana.
//c. Temperatura más alta del mes y su día.
//7. Almacenar en una matriz las tablas del 1 al 9, teniendo en cuenta que en la
//primera fila y la primera columna se debe guardar los números (de 0 a 9),
//estando el cero en la primera posición (fila 0, columna 0). El resto de los
//lugares debe ser calculado usando los números que se dispone, por ejemplo,
//en la fila 1, calcular 1*1, 1*2, 1*3, etc. usando las posiciones del array o
//arreglo. Al finalizar el cálculo, mostrar la matriz por pantalla
//8. Crear una matriz de 10 x 10, y “esconder” varias ‘X’ en lugares aleatorios (la
//cantidad que el programador decida, pero no más de la mitad de los lugares
//disponibles en la matriz). El usuario deberá ingresar el lugar donde cree que
//hay una X, ingresando la fila y la columna por separado. Informar si acertó o
//no por cada ingreso. Se debe pedir al usuario ingresar valores por tantas X
//que se haya guardado. El usuario tiene 3 intentos para fallar. Al finalizar (Ya
//sea porque se terminaron los 3 intentos, o el jugador acertó todas las X)
//imprimir por pantalla la matriz con sus correspondientes X, mostrando un *
//donde no haya nada.