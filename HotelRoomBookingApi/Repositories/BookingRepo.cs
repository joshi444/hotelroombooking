using HotelRoomBookingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace HotelRoomBookingApi.Repositories
{
    public class BookingRepo : IBookingRepo
    {
        MyDbContext context;
      //  MyDbContext context1;
        public BookingRepo(MyDbContext bookingContext)
        {
            context = bookingContext;
        }
        public string AddNewBooking(Booking booking)
        {
            int count = context.Bookings.Count();

            context.Bookings.Add(booking);
            context.SaveChanges();
            int newCount=context.Bookings.Count();
            
            if(newCount > count)
            {

                List<Booking> bookings = new List<Booking>();
                bookings = context.Bookings.ToList();
                Booking booking1 =  bookings.Last();
                int rid = booking1.RoomId;
                Room room = context.Rooms.Find(rid);

                if (room.AvalaibleRooms < 1)
                {
                    return "oops something went wrong";
                }
                else
                {

                    if (room != null)
                    {
                        int a = room.AvalaibleRooms;
                        a = a - 1;
                        room.AvalaibleRooms = a;
                        context.SaveChanges();
                    }
                }
                return "record inserted successfully";
            }
            else 
            {
                return "oops something went wrong";
            }
        }

        public string DeletBooking(int id)
        {
            Booking booking = context.Bookings.Find(id);
           
            if (booking != null)
            {
                int rid = booking.RoomId;
                Room room = context.Rooms.Find(rid);
                if (room != null)
                {
                    int a = room.AvalaibleRooms;
                    a = a + 1;
                    room.AvalaibleRooms = a ;
                    context.SaveChanges();
                }
                context.Bookings.Remove(booking);
                context.SaveChanges();
                return "Booking is deleted";
            }
            else
            {
                return "booking is not available";
            }
        }
        public List<Booking> GetAllBookings()
        {
            return context.Bookings.ToList();
        }
        public string UpdateBooking(Booking newbooking)
        {
            Booking booking = context.Bookings.FirstOrDefault(d =>
            d.BookingId == newbooking.BookingId);
            if (booking != null)
            {
                booking.BookingId = newbooking.BookingId;
                booking.HotelId = newbooking.HotelId;
                booking.RoomId = newbooking.RoomId;
                booking.UserId = newbooking.UserId;
                booking.CheckInDate = newbooking.CheckInDate;
                booking.CheckOutDate = newbooking.CheckOutDate;
                booking.NoOfPeople = newbooking.NoOfPeople;
                context.SaveChanges();
                return "booking details are updated";

            }
            else
            {
                return "Booking details are not avaialable";
            }
        }
        public List<Booking> GetBookingById(int id)
        {
            //Booking booking = context.Bookings.Find(id);
            //return booking;
            List<Booking> bookinglist = context.Bookings.Where(d => d.UserId == id).ToList();
            return bookinglist;


        }

        //public List<Booking> GetByUserId(string email)
        //{
        //   List<User> users = new List<User>();
        //  users = context.Users.ToList();
        //    User user1 = null;
        //    foreach (User user in users) { 
        //        if(user.Email == email)
        //        {
        //            user1 = user;
        //            break;
        //        }
        //    }
        //    int userid = user1.UserId;
           
         

        //    List<Booking> bookinglist = context.Bookings.Where(d => d.UserId == userid).ToList();
        //    return bookinglist;
        //}

    }
}
