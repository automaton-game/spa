﻿using AutomataNETjuegos.Contratos.Entorno;
using AutomataNETjuegos.Contratos.Robots;
using System.Linq;

namespace AutomataNETjuegos.Contratos.Helpers
{
    public static class TableroHelper
    {
        public static Casillero GetPosition(this Tablero tablero, IRobot robot)
        {
            return tablero.Filas.SelectMany(f => f.Casilleros).First(c => c.ContieneRobot(robot));
        }

        public static Casillero GetPosition(this IRobot robot, Tablero tablero)
        {
            return tablero.Filas.SelectMany(f => f.Casilleros).First(c => c.ContieneRobot(robot));
        }

        public static Casillero GetPosition(this Tablero tablero, int x, int y)
        {
            var fila = tablero.Filas.FirstOrDefault(f => f.NroFila == y);
            if (fila == null)
            {
                return null;
            }

            return fila.Casilleros.FirstOrDefault(c => c.NroColumna == x);
        }

        public static Casillero GetMax(this Tablero tablero)
        {
            return tablero.Filas.Last().Casilleros.Last();
        }
    }
}
