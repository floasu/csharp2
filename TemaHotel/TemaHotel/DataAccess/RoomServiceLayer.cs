using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaHotel.Model;

namespace TemaHotel.DataAccess
{
    public class RoomServiceLayer
    {
        public void AddRoom(Room newRoom)
        {
            using (var ctx = new FriendContext())
            {
                ctx.Rooms.Add(newRoom);
                ctx.SaveChanges();
            }
        }
        public List<Room> GetRooms()
        {
            using (var context = new FriendContext())
            {
                var activeRooms = from us in context.Rooms
                                  where us.Active == true
                                  select us;
                return activeRooms.ToList();

            }
        }

        internal OperationResult ModifyRoom(Room roomToChange)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var room = from us in context.Rooms
                               where us.Id == roomToChange.Id
                               select us;
                    var userChanged = room.First();
                    userChanged = roomToChange;
                    context.SaveChanges();
                    return OperationResult.OkResult;
                }
            }
            catch (Exception e)
            {
                return new OperationResult
                {
                    OperationSucceeded = false,
                    Messages = ExceptionMessageComposer.GetMessages(e)
                };
            }
        }


        internal OperationResult DeleteRoom(Room roomToDelete)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var room = from us in context.Rooms
                               where us.Id == roomToDelete.Id
                               select us;
                    var chuser = room.First();
                    chuser.Active = false;
                    context.SaveChanges();
                    return OperationResult.OkResult;
                }
            }
            catch (Exception e)
            {
                return new OperationResult
                {
                    OperationSucceeded = false,
                    Messages = ExceptionMessageComposer.GetMessages(e)
                };
            }
        }

        internal OperationResult RestoreRoom(Room roomToRestore)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var room = from us in context.Rooms
                               where us.Id == roomToRestore.Id
                               select us;
                    var chuser = room.First();
                    chuser.Active = true;
                    context.SaveChanges();
                    return OperationResult.OkResult;
                }
            }
            catch (Exception e)
            {
                return new OperationResult
                {
                    OperationSucceeded = false,
                    Messages = ExceptionMessageComposer.GetMessages(e)
                };
            }
        }

    }
}
