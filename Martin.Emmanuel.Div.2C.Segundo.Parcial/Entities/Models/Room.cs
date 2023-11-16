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

        public int Number { get => _number; set => _number = value; }
        public bool Available { get => _available; set => _available = value; }
        public ERoomType Type { get => _type; set => _type = value; }

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
        public Room()
        {

        }
        public Room(int number, bool available, ERoomType type)
        {
            this._number = number;
            this._available = available;
            this._type = type;
        }

        public static explicit operator Room(DataRow row)
        {
            var number = Convert.ToInt32(row["Numero"].ToString());
            var available = Convert.ToBoolean(row["Disponible"].ToString());
            var type = Convert.ToInt32(row["Tipo"].ToString());
            var roomType = (ERoomType)type;

            Room room = new(number, available, roomType);

            return room;
            //MANEJO EXCEPCIONES
        }
        public override string ToString()
        {
            return $"- {Number} -{Available} - {Type} - ";
        }

        public override bool Equals(object obj)
        {
            return obj is Room room &&
                   Number == room.Number;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
