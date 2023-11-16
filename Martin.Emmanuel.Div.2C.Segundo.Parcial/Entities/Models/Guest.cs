using System.Data;

namespace Entities.Models
{

    public class Guest
    {

        private string _name;
        private string _lastName;
        private int _dni;
        private long _phoneNumber;

        public int Dni { get => _dni; set => _dni = value; }
        public string Name { get => _name; set => _name = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public long PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

        public string DisplayProperty
        {
            get => $"{Name} {LastName} - DNI: {Dni}";
        }

        public Guest() { }

        /// <summary>
        /// Constructor para la clase Guest.
        /// </summary>
        /// <param name="name">Nombre del Guest.</param>
        /// <param name="lastName">Apellido del Guest.</param>
        /// <param name="dni">DNI del Guest.</param>
        /// <param name="phoneNumber">Número de teléfono del Guest.</param>
        public Guest(int dni, string name, string lastName, long phoneNumber)
        {
            this._dni = dni;
            this._name = name;
            this._lastName = lastName;
            this._phoneNumber = phoneNumber;
        }

        /// <summary>
        /// Devuelve una cadena que representa al Guest.
        /// </summary>
        /// <returns>Una cadena que representa al Guest.</returns>
        public override string ToString()
        {
            return $"{Name} {LastName} - DNI: {Dni}";
        }

        /// <summary>
        /// Determina si el objeto especificado es igual a este objeto.
        /// </summary>
        /// <param name="obj">El objeto para comparar con este objeto.</param>
        /// <returns>Verdadero si el objeto especificado es igual a este objeto; de lo contrario, falso.</returns>
        public override bool Equals(object obj)
        {
            return obj is Guest patient &&
                   Dni == patient.Dni;
        }

        /// <summary>
        /// Sirve como la función hash predeterminada.
        /// </summary>
        /// <returns>Un código hash que se puede usar para buscar este objeto en una colección.</returns>
        public override int GetHashCode()
        {
            return Dni.GetHashCode();
        }


        /// <summary>
        /// Convierte un DataRow en un Guest.
        /// </summary>
        /// <param name="line"></param>
        public static explicit operator Guest(DataRow row)
        {
            var dni = Convert.ToInt32(row["Dni"].ToString());
            var name = row["Nombre"].ToString();
            var lastName = row["Apellido"].ToString();
            var phoneNumber = Convert.ToInt64(row["NumeroTelefono"].ToString());

            Guest guest = new(dni, name, lastName, phoneNumber);

            return guest;
        }

    }
}