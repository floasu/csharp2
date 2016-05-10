using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaHotel.Model;

namespace TemaHotel.DataAccess
{
    public class UserServiceLayer
    {
        public void AddUser(User newUser)
        {
            using (var ctx = new FriendContext())
            {
                ctx.Users.Add(newUser);
                ctx.SaveChanges();
            }
        }
        public List<User> GetUsers()
        {
            using (var context = new FriendContext())
            {
                var activeUsers = from user in context.Users
                                  where user.Active == true
                                  select user;
                return activeUsers.ToList();

            }
        }

        internal OperationResult ModifyUser(User userToChange)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var user = from us in context.Users
                               where us.Id == userToChange.Id
                               select us;
                    var userChanged = user.First();
                    userChanged = userToChange;
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


        internal OperationResult DeleteUser(User userToDelete)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var user = from us in context.Users
                               where us.Id == userToDelete.Id
                               select us;
                    var chuser = user.First();
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

        internal OperationResult RestoreUser(User userToRestore)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var user = from us in context.Users
                               where us.Id == userToRestore.Id
                               select us;
                    var chuser = user.First();
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
