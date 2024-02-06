using System;

internal static class ProgramHelpers
{

    //Validar el ingreso
    public static bool ValidarJugada(int ingreso, char[,] tableroJuego, bool validarIngreso)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int i = 0; i < tableroJuego.GetLength(0); i++)
            {
                for (int j = 0; j < tableroJuego.GetLength(0); j++)
                {

                    if (ingreso == Convert.ToInt32(x.ToString()) && tableroJuego[i, j] == Convert.ToChar(x.ToString()))
                    {
                        validarIngreso = true;
                        Console.WriteLine(Convert.ToInt32(x.ToString()) + " == " + tableroJuego[i, j]);
                        return validarIngreso;
                        break;
                    }
                    else
                    {
                        validarIngreso = false;
                    }
                }
                if (validarIngreso) break;
            }
            if (validarIngreso) break;
        }
        if (!validarIngreso)
        {

            Console.WriteLine("\nEse numero ya esta ocupado, ingrese otro valor");
        }
        return true;
    }
}