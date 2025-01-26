using System;
using System.Collections.Generic;

class ValidadorDeFormula
{
    public bool EsFormulaBalanceada(string formula)
    {
        Stack<char> pila = new Stack<char>();
        int posicion = 0;

        while (posicion < formula.Length)
        {
            char caracterActual = formula[posicion];

            if (EsApertura(caracterActual))
            {
                pila.Push(caracterActual);
            }
            else if (EsCierre(caracterActual))
            {
                if (pila.Count == 0 || !EsParCorrespondiente(pila.Pop(), caracterActual))
                {
                    return false;
                }
            }

            posicion++;
        }

        return pila.Count == 0;
    }

    private bool EsApertura(char caracter)
    {
        return caracter == '(' || caracter == '{' || caracter == '[';
    }

    private bool EsCierre(char caracter)
    {
        return caracter == ')' || caracter == '}' || caracter == ']';
    }

    private bool EsParCorrespondiente(char apertura, char cierre)
    {
        if (EsParentesis(apertura, cierre)) return true;
        if (EsLlave(apertura, cierre)) return true;
        if (EsCorchete(apertura, cierre)) return true;

        return false;
    }

    private bool EsParentesis(char apertura, char cierre)
    {
        return apertura == '(' && cierre == ')';
    }

    private bool EsLlave(char apertura, char cierre)
    {
        return apertura == '{' && cierre == '}';
    }

    private bool EsCorchete(char apertura, char cierre)
    {
        return apertura == '[' && cierre == ']';
    }
}

class AplicacionBalanceo
{
    static void Main(string[] args)
    {
        ValidadorDeFormula validador = new ValidadorDeFormula();
        string opcion;

        do
        {
            Console.WriteLine("Ingrese una f rmula para verificar si est  balanceada:");
            string formula = Console.ReadLine();

            if (validador.EsFormulaBalanceada(formula))
            {
                Console.WriteLine("La f rmula est  balanceada.");
            }
            else
            {
                Console.WriteLine("La f rmula no est  balanceada.");
            }

            Console.WriteLine(" Desea verificar otra f rmula? (s/n):");
            opcion = Console.ReadLine()?.ToLower();
        }
        while (opcion == "s");

        Console.WriteLine("Gracias por usar el programa.");
    }
}