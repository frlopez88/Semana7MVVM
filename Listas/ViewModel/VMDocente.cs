using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Listas.ViewModel
{
    public class VMDocente : INotifyPropertyChanged
    {
        public VMDocente()
        {

            DarClase = new Command(
                    () => {
                        HorasClaseAcumulada = HorasClaseAcumulada + HorasClase;
                        Reporte = "El docente " + Nombre + " Tiene por Salario: " + HorasClaseAcumulada * 300;
                    }
                );

            ResetHorasClase = new Command
                (

                    () => {

                        HorasClaseAcumulada = 0;
                        Reporte = "El docente " + Nombre + " Tiene por Salario: " + HorasClaseAcumulada * 300;
                    }

                );

        }

        String nombre;

        public String Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        String identidad;

        public String Identidad
        {
            get => identidad;
            set
            {

                identidad = value;
                var args = new PropertyChangedEventArgs(nameof(Identidad));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int horasClase = 0;
        public int HorasClase
        {

            get => horasClase;
            set
            {
                horasClase = value;
                var args = new PropertyChangedEventArgs(nameof(HorasClase));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int horasClaseAcumulada = 0;
        public int HorasClaseAcumulada {
            get => horasClaseAcumulada;
            set {

                horasClaseAcumulada = value;
                var args = new PropertyChangedEventArgs(nameof(HorasClaseAcumulada));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string reporte = "";
        public string Reporte
        {
            get => reporte;
            set
            {
                reporte = value;
                var args = new PropertyChangedEventArgs(nameof(Reporte));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command DarClase { get; }
        public Command ResetHorasClase { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
