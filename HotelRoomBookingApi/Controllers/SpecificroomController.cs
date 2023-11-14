using HotelRoomBookingApi.Models;
using HotelRoomBookingApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelRoomBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificroomController : ControllerBase
    {
        private readonly Specificroom Repositories;
        [Route("{hid}")]
        [HttpGet]
        public ActionResult<List<Room>> Login(int hid)
        {
            List<Room> room = Repositories.GetAllRoomByhotelid(hid);
            if (room.Count > 0)
            {
                return room;
            }
            else
            {
                return NotFound();
            }

        }
    }
}
