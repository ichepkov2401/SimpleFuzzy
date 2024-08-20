﻿using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Models.SimulatorCrane
{
    public class CraneSimulator : ISimulator
    {
        public bool Active { get; set; }
        public string Name { get; } = "Crane simulator";

        public double m = 1; // Масса маятника (кг)
        public double M = 5; // Масса каретки (кг)
        public double l = 2; // Длина маятника (м)
        public const double g = 9.8; // Ускорение свободного падения (м/с^2)
        public double k1 = 0.1; // Коэффициент торможения каретки
        public double k2 = 0.1; // Коэффициент затухания колебаний
        public double x = 0; // Положение каретки (м)
        public double y = 0; // Угол отклонения маятника (рад)
        public double f = 0; // Сила, действующая на каретку (Н)
        public double dx = 0;
        public double dy = 0;
        public double t = 0.01;
        public double beamSize = 20; // по умолчанию размер балки 20
        public double platformPosition = 0;
        public const double MAX_ANGLE = Math.PI / 2;
        private bool cargoLoaded = false;

        public object GetVisualObject() => new FromOfSimulator(this);

        public void Step()
        {
            double ax = (m * l * l * dy * dy * Math.Sin(y) + l * f - m * g * l * Math.Sin(y) * Math.Cos(y) - (k1 * dx)) / (l * M + l * m * Math.Sin(y) * Math.Sin(y));
            double ay = (-(M + m) * g * Math.Sin(y) - m * l * dy * dy * Math.Sin(y) * Math.Cos(y) - f * Math.Cos(y) - (k2 * dy)) / (l * M + l * m * Math.Sin(y) * Math.Sin(y));
            dx += ax * t;
            dy += ay * t;
            x += dx * t;
            y += dy * t;

            // Ограничение движения каретки
            x = Math.Max(0, Math.Min(beamSize, x));
        }
    }
}
