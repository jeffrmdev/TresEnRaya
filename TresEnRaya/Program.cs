using System;
using System.Runtime.Remoting.Messaging;


namespace TresEnRaya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Ajustes de ventana de consola
            const int anchoVentana = 50;
            const int altoVentana = 25;

            Console.WindowHeight = altoVentana;
            Console.WindowWidth = anchoVentana;

            int jugador = 2;
            int jugadorActual = 2;
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
                    Console.WriteLine("\n  Jugador {0}, por favor elija un casillero: ", jugador);
                    Console.Write("  ");
                    try
                    {
                        ingreso = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("  Solo debe ingresar números");
                    }
                    /*
                    if      ((ingreso == 1) && tableroJuego[0, 0] == '1')   validarIngreso = true;
                    else if ((ingreso == 2) && tableroJuego[0, 1] == '2')   validarIngreso = true;
                    else if ((ingreso == 3) && tableroJuego[0, 2] == '3')   validarIngreso = true;
                    else if ((ingreso == 4) && tableroJuego[1, 0] == '4')   validarIngreso = true;
                    else if ((ingreso == 5) && tableroJuego[1, 1] == '5')   validarIngreso = true;
                    else if ((ingreso == 6) && tableroJuego[1, 2] == '6')   validarIngreso = true;
                    else if ((ingreso == 7) && tableroJuego[2, 0] == '7')   validarIngreso = true;
                    else if ((ingreso == 8) && tableroJuego[2, 1] == '8')   validarIngreso = true;
                    else if ((ingreso == 9) && tableroJuego[2, 2] == '9')   validarIngreso = true;
                    else
                    {
                        Console.WriteLine("Por Favor ingrese otro número");
                        validarIngreso = false;
                    }
                    */

                    for (int x = 0; x < 10; x++)
                    {   
                        for (int i = 0; i < tableroJuego.GetLength(0); i++)
                        {
                            for (int j = 0; j < tableroJuego.GetLength(0); j++)
                            {
                                if(ingreso == Convert.ToInt32(x.ToString()) && tableroJuego[i,j] == Convert.ToChar(x.ToString()))
                                {
                                    validarIngreso = true;
                                    Console.WriteLine(Convert.ToInt32(x.ToString()) + " == " + tableroJuego[i, j]);
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
                        dibujarTablero();
                        Console.WriteLine("\n  Ese numero ya esta ocupado por el jugador {0}\n  Ingresa otro valor", jugadorActual = (jugador == 1) ? 2 : 1);
                    }
                }
                while (!validarIngreso);
                #endregion
            }
            while (true);



        }

        static char[,] tableroJuego = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

        public static void centrarTexto(string texto)
        {
            int anchoVentana = Console.WindowWidth;
            int longitudTexto = texto.Length;

            int espaciosAlInicio = (anchoVentana - longitudTexto) / 2;

            Console.Write(new string(' ', espaciosAlInicio) + texto);
        }


        //Creación de tablero
        public static void dibujarTablero()
        {

            //Para centrar tablero
            int ventana = Console.WindowWidth;
            int espacioMargen = ("  |  ").Length;
            int centroReferencia = ("._________________.").Length;
            int espacioTotal = (ventana - (centroReferencia + espacioMargen)) / 2;

            Console.Clear();
            Console.WriteLine("");
            centrarTexto("Juego 3 en Raya\n\n");
            centrarTexto("Ronda: " + 1 + "          Ganador Anterior: " + "Jeff\n\n");


            centrarTexto("._________________.\n");
            for (int j = 0; j < 3; j++)
            {
                centrarTexto("|     |     |     |\n");
                Console.Write(new string(' ', espacioTotal));
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("  |  ");
                    Console.Write(""+ tableroJuego[j, i].ToString()+ "");
                     
                } 
                Console.Write("  |\n");
                centrarTexto("|_____|_____|_____|\n");
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
