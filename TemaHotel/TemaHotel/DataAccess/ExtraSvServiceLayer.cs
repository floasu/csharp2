using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaHotel.Model;

namespace TemaHotel.DataAccess
{
    public class ExtraSvServiceLayer
    {
        public void AddExtraSvIntoDb(ExtraServices newSv)
        {
            using (var ctx = new FriendContext())
            {
                ctx.Services.Add(newSv);
                ctx.SaveChanges();
            }
        }
        public List<ExtraServices> GetServices()
        {
            using (var context = new FriendContext())
            {
                var activeSv = from user in context.Services
                               where user.Active == true
                               select user;
                return activeSv.ToList();

            }
        }

        internal OperationResult ModifyService(ExtraServices svToChange)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var user = from us in context.Services
                               where us.Id == svToChange.Id
                               select us;
                    var userChanged = user.First();
                    userChanged = svToChange;
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


        internal OperationResult DeleteService(ExtraServices svToDelete)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var user = from us in context.Services
                               where us.Id == svToDelete.Id
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

        internal OperationResult RestoreService(ExtraServices svToRestore)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var user = from us in context.Services
                               where us.Id == svToRestore.Id
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
