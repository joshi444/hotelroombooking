using HotelRoomBookingApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomBookingApi.Repositories
{
    public class Specificroom
    {
        readonly MyDbContext context;
        public Specificroom(MyDbContext roomContext)
        {
            context = roomContext;
        }

        public List<Room> GetAllRoomByhotelid(int hid)
        {
            List<Room> roomlist = context.Rooms.Where(d => d.HotelId == hid).ToList();
            return roomlist;
        }


    }
}
