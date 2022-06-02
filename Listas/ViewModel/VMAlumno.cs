using System;
using System.ComponentModel;
using Xamarin.Forms;
using Listas.Model;
using System.Collections.ObjectModel;

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
                             Reporte = "El alumno " + Nombre + " tiene derecho a examen.";
                         }
                         else
                         {
                             Reporte = "El alumno " + Nombre + "  perdio drecho a examen.";

                         }

                     }
                );

            Guardar = new Command(
                    () => {


                        ModelAlumno x = new ModelAlumno() {
                            nombre = Nombre,
                            identidad = Identidad,
                            cantidadFaltas=Faltas
                        };


                        listaGuardar.Add(x);

                    }

                );

            Buscar = new Command(
                    () => {

                        ModelAlumno temporal = new ModelAlumno();

                        for (int i = 0; i < listaGuardar.Count; i++) {

                            temporal = listaGuardar[i];

                            if (temporal.identidad == Identidad) {

                                Nombre = temporal.nombre;
                                Faltas = temporal.cantidadFaltas;
                                Reporte = temporal.calculoFaltas();

                            }

                        }

                    }
                );

        }

        public ObservableCollection<ModelAlumno> listaGuardar { get; set; } = new ObservableCollection<ModelAlumno>();

        String nombre;

        public String Nombre { get => nombre;
            set {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
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

        string reporte = "";
        public string Reporte {
            get => reporte;
            set {
                reporte = value;
                var args = new PropertyChangedEventArgs(nameof(Reporte));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command Guardar { get; }


        public Command Buscar { get; }

        public Command FaltarClase { get;  }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}

// MVVM:
// Model(Clases: Primer Parcial)
// View(Front END)
// ViewModel(Son Clases para Manejar el Front END)