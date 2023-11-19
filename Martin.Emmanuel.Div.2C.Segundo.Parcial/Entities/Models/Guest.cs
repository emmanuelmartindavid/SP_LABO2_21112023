using System.Data;

namespace Entities.Models
{

    public class Guest
    {

        private string _name;
        private string _lastName;
        private int _dni;
        private long _phoneNumber;

        /// <summary>
        /// Propiedad DNI del Guest.
        /// </summary>
        public int Dni { get => _dni; set => _dni = value; }
        /// <summary>
        /// Propiedad Nombre del Guest.
        /// </summary>
        public string Name { get => _name; set => _name = value; }
        /// <summary>
        /// Propiedad Apellido del Guest.
        /// </summary>
        public string LastName { get => _lastName; set => _lastName = value; }
        /// <summary>
        /// Propiedad Número de teléfono del Guest.
        /// </summary>
        public long PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        /// <summary>
        /// Propiedad DisplayProperty del Guest.
        /// </summary>
        public string DisplayProperty
        {
            get => $"{Name} {LastName} - DNI: {Dni}";
        }

        /// <summary>
        /// Constructor por defecto de la clase Guest.
        /// </summary>
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
        /// <summary>
        /// Devuelve una cadena que representa al Guest.
        /// </summary>
        /// <returns>Una cadena que representa al Guest.</returns>
        public override string ToString()
        {
            return $"{Name} {LastName} - DNI: {Dni}";
        }

    }
}