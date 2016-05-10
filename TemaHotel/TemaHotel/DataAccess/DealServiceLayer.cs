using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaHotel.Model;

namespace TemaHotel.DataAccess
{
    public class DealServiceLayer
    {
        public void AddDeal(Deal newDeal)
        {
            using (var ctx = new FriendContext())
            {
                ctx.Deals.Add(newDeal);
                ctx.SaveChanges();
            }
        }
        public List<Deal> GetDeals()
        {
            using (var context = new FriendContext())
            {
                var activeDeals = from deal in context.Deals
                                  where deal.Active == true
                                  select deal;
                return activeDeals.ToList();

            }
        }

        internal OperationResult ModifyDeal(Deal dealToModify)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var deals = from dl in context.Deals
                               where dl.Id == dealToModify.Id
                               select dl;
                    var dlChanged = deals.First();
                    dlChanged = dealToModify;
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


        internal OperationResult DeleteDeal(Deal dealToDelete)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var deal = from us in context.Deals
                               where us.Id == dealToDelete.Id
                               select us;
                    var chuser = deal.First();
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

        internal OperationResult RestoreDeal(Deal dealToRestore)
        {
            try
            {
                using (var context = new FriendContext())
                {
                    var deal = from us in context.Deals
                               where us.Id == dealToRestore.Id
                               select us;
                    var chuser = deal.First();
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
