using System;


namespace TresEnRaya
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int jugador = 2;
            int ingreso = 0;
            bool validarIngreso = true;
      
            do
            {

                if(jugador == 2)
                {
                    jugador = 1;
                    logicaJuego(jugador, ingreso);
                } 
                else if (jugador == 1)
                {
                    jugador = 2;
                    logicaJuego(jugador, ingreso);
                }
                dibujarTablero();

                #region
                char[] cadaSigno = { 'X', 'O' };
                foreach (char signo in cadaSigno)
                {

                }
                #endregion


                //Verifica si el valor ingresado es correcto
                #region
                do
                {
                    Console.WriteLine("\nJugador {0}, por favor elija un casillero: ", jugador);
                    try
                    {
                        ingreso = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Solo debe ingresar números");
                    }
                    if ((ingreso == 1) && tableroJuego[0, 0] == '1')
                        validarIngreso = true;
                    else if ((ingreso == 2) && tableroJuego[0, 1] == '2')
                        validarIngreso = true;
                    else if ((ingreso == 3) && tableroJuego[0, 2] == '3')
                        validarIngreso = true;
                    else if ((ingreso == 4) && tableroJuego[1, 0] == '4')
                        validarIngreso = true;
                    else if ((ingreso == 5) && tableroJuego[1, 1] == '5')
                        validarIngreso = true;
                    else if ((ingreso == 6) && tableroJuego[1, 2] == '6')
                        validarIngreso = true;
                    else if ((ingreso == 7) && tableroJuego[2, 0] == '7')
                        validarIngreso = true;
                    else if ((ingreso == 8) && tableroJuego[2, 1] == '8')
                        validarIngreso = true;
                    else if ((ingreso == 9) && tableroJuego[2, 2] == '9')
                        validarIngreso = true;
                    else
                    {
                        Console.WriteLine("Por Favor ingrese otro número");
                        validarIngreso = false;
                    }

                }
                while (!validarIngreso);
                #endregion
            }
            while (true);



        }

        static char[,] tableroJuego = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

        //Creación de tablero
        public static void dibujarTablero()
        {
            Console.Clear();
            Console.WriteLine("._________________.");
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("|     |     |     |");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("| ");
                    Console.Write(" {0}  ", tableroJuego[j, i]);
                }
                Console.Write("|\n");
                Console.WriteLine("|_____|_____|_____|");
            }
        }


        //Identificar jugador 
        public static void logicaJuego(int jugador, int ingreso)
        {

            char simbolo = ' ';

            if (jugador == 2) { simbolo = 'X';}
            else if (jugador == 1) { simbolo = 'O'; }


            switch (jugador)
            {
                case 1:
                    switch (ingreso)
                    {
                        case 1: tableroJuego[0, 0] = simbolo; break;
                        case 2: tableroJuego[0, 1] = simbolo; break;
                        case 3: tableroJuego[0, 2] = simbolo; break;
                        case 4: tableroJuego[1, 0] = simbolo; break;
                        case 5: tableroJuego[1, 1] = simbolo; break;
                        case 6: tableroJuego[1, 2] = simbolo; break;
                        case 7: tableroJuego[2, 0] = simbolo; break;
                        case 8: tableroJuego[2, 1] = simbolo; break;
                        case 9: tableroJuego[2, 2] = simbolo; break;
                    }
                    break;

                case 2:
                    switch (ingreso)
                    {
                        case 1: tableroJuego[0, 0] = simbolo; break;
                        case 2: tableroJuego[0, 1] = simbolo; break;
                        case 3: tableroJuego[0, 2] = simbolo; break;
                        case 4: tableroJuego[1, 0] = simbolo; break;
                        case 5: tableroJuego[1, 1] = simbolo; break;
                        case 6: tableroJuego[1, 2] = simbolo; break;
                        case 7: tableroJuego[2, 0] = simbolo; break;
                        case 8: tableroJuego[2, 1] = simbolo; break;
                        case 9: tableroJuego[2, 2] = simbolo; break;
                    }
                    break;

                default: break;
            }
        }

    }
}
