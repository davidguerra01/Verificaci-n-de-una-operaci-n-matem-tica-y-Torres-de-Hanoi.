using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    private List<string> movimientos;

    public TorresDeHanoi()
    {
        movimientos = new List<string>();
    }

    public void ResolverIterativo(int numeroDiscos)
    {
        Stack<(int, char, char, char)> pila = InicializarPila(numeroDiscos);

        while (pila.Count > 0)
        {
            var (discos, origen, destino, auxiliar) = pila.Pop();

            if (discos == 1)
            {
                RegistrarMovimiento(discos, origen, destino);
            }
            else
            {
                AgregarMovimientoAlaPila(pila, discos, origen, destino, auxiliar);
            }
        }
    }

    private Stack<(int, char, char, char)> InicializarPila(int numeroDiscos)
    {
        Stack<(int, char, char, char)> pila = new Stack<(int, char, char, char)>();
        pila.Push((numeroDiscos, 'A', 'C', 'B')); // A = Origen, C = Destino, B = Auxiliar
        return pila;
    }

    private void AgregarMovimientoAlaPila(Stack<(int, char, char, char)> pila, int discos, char origen, char destino, char auxiliar)
    {
        pila.Push((discos - 1, auxiliar, destino, origen)); // Paso 3: n-1 discos de auxiliar a destino
        pila.Push((1, origen, destino, auxiliar));          // Paso 2: mover el disco grande
        pila.Push((discos - 1, origen, auxiliar, destino)); // Paso 1: n-1 discos de origen a auxiliar
    }

    private void RegistrarMovimiento(int disco, char origen, char destino)
    {
        movimientos.Add($"Mover disco {disco} de {origen} a {destino}");
    }

    public void MostrarMovimientos()
    {
        Console.WriteLine("Movimientos necesarios:");
        foreach (string movimiento in movimientos)
        {
            Console.WriteLine(movimiento);
        }

        // Mostrar el n mero total de movimientos realizados
        Console.WriteLine($"\nTotal de movimientos realizados: {movimientos.Count}");
    }
}

class AplicacionHanoi
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese el n mero de discos: ");
        int numeroDiscos = int.Parse(Console.ReadLine());

        TorresDeHanoi hanoi = new TorresDeHanoi();
        hanoi.ResolverIterativo(numeroDiscos);
        hanoi.MostrarMovimientos();
    }
}