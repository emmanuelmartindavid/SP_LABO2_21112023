using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Room
    {
        private int _number;
        private bool _available;
        private ERoomType _type;

        /// <summary>
        /// Propiedad Number.
        /// </summary>
        public int Number { get => _number; set => _number = value; }
        /// <summary>
        /// Propiedad Available.
        /// </summary>
        public bool Available { get => _available; set => _available = value; }
        /// <summary>
        /// Propiedad Type.
        /// </summary>
        public ERoomType Type { get => _type; set => _type = value; }
        /// <summary>
        /// Propiedad DisplayProperty.
        /// </summary>
        public string DisplayProperty
        {
            get
            {
                if (Type == ERoomType.Simple)
                {
                    return $"{Number} - {Type}: US$50 ";
                }
                return $"{Number} - {Type}: US$90";
            }
        }

        /// <summary>
        /// Constructor de la clase Room.
        /// </summary>
        public Room()
        {

        }
        /// <summary>
        /// Constructor de la clase Room.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="available"></param>
        /// <param name="type"></param>
        public Room(int number, bool available, ERoomType type)
        {
            this._number = number;
            this._available = available;
            this._type = type;
        }

        /// <summary>
        /// Convierte un DataRow en un objeto Room.
        /// </summary>
        /// <param name="row"></param>
        public static explicit operator Room(DataRow row)
        {
            var number = Convert.ToInt32(row["Numero"].ToString());
            var available = Convert.ToBoolean(row["Disponible"].ToString());
            var type = Convert.ToInt32(row["Tipo"].ToString());
            var roomType = (ERoomType)type;

            Room room = new(number, available, roomType);

            return room;
        }

        public override string ToString()
        {
            return $"- {Number} -{Available} - {Type} - ";
        }

    }
}
