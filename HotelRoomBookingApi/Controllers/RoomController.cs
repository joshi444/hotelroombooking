using HotelRoomBookingApi.Models;
using HotelRoomBookingApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HotelRoomBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepo Repositories = null;
        public RoomController(IRoomRepo repo)
        {
            Repositories = repo;
        }
        [HttpGet]
        public ActionResult<List<Room>> Get()
        {
            List<Room> rooms= Repositories.GetAllRooms();
          //  List<Room> room =Repositories.Where(m=>m.HotelId = 1).ToList();
            if (rooms.Count > 0)
            {
                return rooms;
            }
            else
            {
                return NotFound();
            }
        }
        

        [Route("{id:int}")]
        [HttpGet]
        public ActionResult<List<Room>> Get(int id)
        {
            List<Room> room  = Repositories.GetAllRoomsByHotelId(id);
            if (room.Count >0)
            {
                return room;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public string Post(Room  room)
        {
            string Response = Repositories.AddNewRoom(room);
            return Response;
        }
        [HttpPut]
        public string Put(Room room)
        {
            string Response = Repositories.UpdateRoom(room);
            return Response;
        }

        [Route("{id:int}")]
        [HttpDelete]
        public string Delete(int id)
        {
            string Response = Repositories.DeleteRoom(id);
            return Response;
        }
    }
}
