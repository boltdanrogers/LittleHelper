using LittleHelper.Data;
using LittleHelper.Models.StorageFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Services
{
    public class StorageFoodService
    {
        //crud

        //create
        public bool CreateStorageFood(StorageFoodCreate model)
        {
            var entity = new StorageFood() { StorageId = model.StorageId, FoodId = model.FoodId, Quantity = model.Quantity, Unit = model.Unit };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.StorageFoods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }//end of method createStorageFood


        //get all
        public IEnumerable<StorageFoodListItem> GetStorageFoods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.StorageFoods.Select(e => new StorageFoodListItem { StorageFoodId = e.StorageFoodId, StorageId = e.StorageId, FoodId = e.FoodId });
                return query.ToArray();
            }//end of using context

        }//End of method GetStorageFoods


        //get one
        public StorageFoodDetails GetStoraegFoodById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx.StorageFoods.Single(e => e.StorageFoodId == id);
                return new StorageFoodDetails { StorageId = entity.StorageId, FoodId = entity.FoodId, Quantity = entity.Quantity, Unit = entity.Unit };

            }//end of using context

        }//end of method getStorageFoodById


        //edit
        public bool UpdateStorageFood(StorageFoodEdit model)
        {
            using (var ctx = new ApplicationDbContext()) 
            {
                var entity = ctx.StorageFoods.Single(e => e.StorageFoodId == model.StorageFoodId);
                entity.StorageId = model.StorageId;
                entity.FoodId = model.FoodId;
                entity.Quantity = model.Quantity;
                entity.Unit = model.Unit;

                return ctx.SaveChanges() == 1;
            
            }//end of using context

        }//end of method updateStorageFood

        //delete
        public bool DeleteStorageFood(int id)
        {
            using(var ctx = new ApplicationDbContext()) 
            {
                var entity = ctx.StorageFoods.Single(e => e.StorageFoodId == id);
                ctx.StorageFoods.Remove(entity);
                return ctx.SaveChanges() == 1;

            }//end of using context

        }//end of method deleteStorageFood



    }//end of class StorageFoodService
}//end of name space
