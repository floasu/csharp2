using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaHotel.Model;

namespace TemaHotel.DataAccess
{
    public class FacilityServiceLayer
    {
        public void AddFacility(Facility newFacility)
        {
            using (var ctx = new FriendContext())
            {
                ctx.AvailableFacilities.Add(newFacility);
                ctx.SaveChanges();
            }
        }
        public List<Facility> GetFacilities()
        {
            using (var context = new FriendContext())
            {
                var activeFacilities = from fac in context.AvailableFacilities
                                       where fac.Active == true
                                       select fac;
                return activeFacilities.ToList();

            }
        }

        internal OperationResult ModifyFacility(Facility facilityToChange)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var user = from us in context.AvailableFacilities
                               where us.Id == facilityToChange.Id
                               select us;
                    var userChanged = user.First();
                    userChanged = facilityToChange;
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


        internal OperationResult DeleteFacility(Facility facilityToDelete)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var fac = from us in context.AvailableFacilities
                               where us.Id == facilityToDelete.Id
                               select us;
                    var chuser = fac.First();
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

        internal OperationResult RestoreFacility(Facility facilityToRestore)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var user = from us in context.AvailableFacilities
                               where us.Id == facilityToRestore.Id
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
