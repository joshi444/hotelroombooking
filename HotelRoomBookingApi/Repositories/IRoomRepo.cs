﻿using HotelRoomBookingApi.Models;
using System.Collections.Generic;

namespace HotelRoomBookingApi.Repositories
{
    public interface IRoomRepo
    {
        List<Room> GetAllRooms();
        List<Room> GetAllRoomsByHotelId(int  hid);
        string  AddNewRoom(Room room);
        string  UpdateRoom(Room room);

        string  DeleteRoom(int id);
        Room GetRoomById(int id);

       
    }
}
