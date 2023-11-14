using HotelRoomBookingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomBookingApi.Repositories
{
    public class RoomRepo : IRoomRepo
    {
        MyDbContext context;
        public RoomRepo(MyDbContext roomContext)
        {
            context = roomContext;
        }
        public string  AddNewRoom(Room room)
        {
            int count = context.Rooms.Count();
            context.Rooms.Add(room);
            context.SaveChanges();
            int newcount = context.Rooms.Count();
            if(newcount>count)
            {
                return "record inserted successfully";
            }
            else
            {
                return "oops something went wrong";
            }
        }

        public string  DeleteRoom(int id)
        {
            Room room = context.Rooms.Find(id);
            if (room != null)
            {
                context.Rooms.Remove(room);
                context.SaveChanges();
                return "room removed successfully";
            }
            else
            {
                return "room not avilable";
            }
        }
        public List<Room> GetAllRooms()
        {
            return context.Rooms.ToList();
        }
        public string  UpdateRoom(Room newroom)
        {
            Room room = context.Rooms.FirstOrDefault(d =>
            d.RoomId == newroom.RoomId);
            if (room != null)
            {
                room.RoomId = newroom.RoomId;
                room.HotelId = newroom.HotelId;
               room.AvalaibleRooms = newroom.AvalaibleRooms;
                room.Price = newroom.Price;
                room.RoomType = newroom.RoomType;
               

                context.SaveChanges();
                return "room details updated successfully";
            }
            else
            {
                return "room details not found";
            }
        }
        public Room GetRoomById(int id)
        {

            Room room = context.Rooms.Find(id);
            return room;
        }

        public List<Room> GetAllRoomsByHotelId(int  hid)

        {
           
            List<Room> roomlist = context.Rooms.Where(d => d.HotelId == hid).ToList();
            return roomlist;

        }

        
    }
}
