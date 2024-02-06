using System;
using System.Runtime.Remoting.Messaging;


namespace TresEnRaya
{
    internal class Program
    {
        static string[] jugadorActual = { "", "Jugador 1", "Jugador 2" };
        static string jugadorGanadorAnterior = jugadorActual[0];
        static int ganador = 0;
        static int jugador = 2;

        static void Main(string[] args)
        {
            //Ajustes de ventana de consola
            ventanaTamaño(25,55);

            
            int ingreso = 0;
            bool validarIngreso = true;
            //bool validarNombres = true;
            string respuestaNombres = "N";


            Console.Write("  ¿Escribir nombres de los jugadores?\n  Si (y/yes)      No (Enter): ");
            respuestaNombres = Console.ReadLine();
            Console.WriteLine("");
            if (respuestaNombres.ToLower().Contains("y"))
            {
                for(int i = 1; i < jugadorActual.Length; i++)
                {
                    Console.Write("  Nombre del jugador {0}: ", i);
                    jugadorActual[i] = Console.ReadLine().ToString();
                } 
            }


            do
            {

                if (jugador == 2)
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
                    for (int i = 0; i < tableroJuego.GetLength(0); i++)
                    {
                        if (tableroJuego[0,i] == signo && tableroJuego[1,i] == signo && tableroJuego[2,i] == signo)
                        {
                            ganador = (signo == 'X') ? 1 : 2;
                        } 
                        else if (tableroJuego[i, 0] == signo && tableroJuego[i, 1] == signo && tableroJuego[i, 2] == signo)
                        {
                            ganador = (signo == 'X') ? 1 : 2;
                        }

                    }

                    if (tableroJuego[0, 0] == signo && tableroJuego[1, 1] == signo && tableroJuego[2, 2] == signo)
                    {
                        ganador = (signo == 'X') ? 1 : 2;
                    }
                    else if (tableroJuego[0, 2] == signo && tableroJuego[1, 1] == signo && tableroJuego[2, 0] == signo)
                    {
                        ganador = (signo == 'X') ? 1 : 2;
                    }

                }

                if (ganador != 0)
                {
                    jugadorGanador(ganador);
                    nuevoJuego();
                    
                }
                else if (ganador == 0 && turnos == 10)
                {
                    jugadorGanador(ganador);
                    nuevoJuego(); 
                }

                #endregion


                //Verifica si el valor ingresado es correcto
                #region
                do
                {
                    Console.WriteLine("\n  {0}, por favor elija un casillero: ", jugadorActual[jugador]);
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
                        Console.WriteLine("\n  La casilla {1} ocupado por {0}\n  Ingresa otro número",
                             (jugador == 1) ? jugadorActual[2] : jugadorActual[1], ingreso);
                    }
                }
                while (!validarIngreso);
                #endregion
            }
            while (true);
        }

        static char[,] tableroJuego = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        static char[,] reset = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

        static int turnos = 0;
        static int rondas = 1;

        //Centrar texto en pantalla
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            
            string gui = "Ronda: " + rondas + "          Ganador Anterior: " + jugadorGanadorAnterior;
            Console.WriteLine((new string(' ', (ventana - gui.Length)/2) + gui) + new string(' ', (ventana - gui.Length+1) / 2));
            Console.ResetColor();


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
            Console.WriteLine("");
            turnos++;
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

        //Tamaño de la ventana
        public static void ventanaTamaño(int altoVentana, int anchoVentana)
        {
            Console.WindowHeight = altoVentana;
            Console.WindowWidth = anchoVentana;
        }


        //Declarar ganador
        public static void jugadorGanador(int jugador)
        {
            centrarTexto("!Hay ganador!\n");
            jugadorGanadorAnterior = jugadorActual[jugador];
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n  Ha ganado "+ (jugadorActual[jugador])+new string(' ', Console.WindowWidth)+"\n\n");
            Console.ResetColor();
            ganador = 0;
        }

        public static void nuevoJuego()
        {
            rondas++;
            Array.Copy(reset, tableroJuego, reset.Length);
            string nuevo = "N";
            if(turnos == 10)
            {
                centrarTexto("¡Empate!\n\n");
            }
            Console.Write("  ¿Quieres jugar de nuevo?\n");
            Console.Write("  Si (y)      No (Enter)\n");
            Console.Write("  ");
            nuevo = Console.ReadLine();
            
            if (nuevo.Contains("y"))
            {
                turnos = 0;
                dibujarTablero();
            } 
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
