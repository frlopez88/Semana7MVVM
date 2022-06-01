using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Listas.ViewModel
{
    public class VMAlumno : INotifyPropertyChanged
    {
        public VMAlumno()
        {
            FaltarClase = new Command(
                     () => {
                        Faltas = Faltas + 1;

                        if (Faltas <= 8) {
                            Reporte = "El alumno "+ Nombre +" tiene derecho a examen.";
                        }
                        else
                        {
                            Reporte = "El alumno "+ Nombre +"  perdio drecho a examen.";

                        }

                    }
                );
        }

        String nombre;

        public String Nombre { get => nombre;
            set {
                nombre = value;
                var args = new PropertyChangedEventArgs( nameof(Nombre) );
                PropertyChanged?.Invoke(this, args);
            }
        }

        String identidad;

        public String Identidad {
            get => identidad;
            set {

                identidad = value;
                var args = new PropertyChangedEventArgs(nameof(Identidad));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int faltas = 0;
        public int Faltas {

            get => faltas;
            set {

                faltas = value;
                var args = new PropertyChangedEventArgs(nameof(Faltas));
                PropertyChanged?.Invoke(this, args);

            }

        }

        string reporte="";
        public string Reporte {
            get => reporte;
            set  {
                reporte = value;
                var args = new PropertyChangedEventArgs(nameof(Reporte));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command FaltarClase { get;  }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
