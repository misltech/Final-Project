using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_Quartos
{
    class Room
    {
        private int _roomID;
        private string _roomNumber;
        private int _roomCapacity;
        private int _status;
        private Boolean _occupied;

        //// in this section, we define the getchers for our project:

        ////get room number publicly:
        //public string roomnumber
        //{
        //    get
        //    {
        //        return _roomnumber;
        //    }
        //}

        ////get room capacity publicly:
        //public int roomcapacity
        //{
        //    get
        //    {
        //        return _roomcapacity;
        //    }
        //}

        ////get room status publicly:
        //public int status
        //{
        //    get
        //    {
        //        return _status;
        //    }
        //}

        //Now, in this section we will define the constructor and the proper functions needed to return the proper functions.

        //Constructor:
        public Room(int RoomID)
        {
            _roomID = RoomID;
        }

        //Methods (Functions): 

        // Room reservation:
        public Boolean setReserved()
        {
            return true;
        }

        // Room Occupancy:
        public Boolean getOccupied()
        {
            return _occupied;
        }

        // Room Capacity:
        public int getRoomCapacity()
        {
            return _roomCapacity;
        }

    }
}
