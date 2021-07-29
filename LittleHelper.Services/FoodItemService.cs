using LittleHelper.Data;
using LittleHelper.Models.FoodItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Services
{
    public class FoodItemService
    {
        //this is for our crud, to interact with the database using different models

        //create a FoodItem in the database with FoodItemCreate model

        public bool CreateFoodItem(FoodItemCreate model)
        {
            var entity = new FoodItem()
            {
                Name = model.Name,
                Unit = model.Unit
            };//end of new FoodItem setting

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FoodItems.Add(entity);

                return ctx.SaveChanges() == 1;

            }//end of using context

        }//end of method createFoodItem


        //get all FoodItems from the database with FoodItemListItem

        public IEnumerable<FoodItemListItem> GetFoodItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //create a query to be filled and returned
                var query = ctx.FoodItems.Select(e => new FoodItemListItem { Name = e.Name });//our model is simple and the command 

                return query.ToArray();
            }//end of using context

        }//end of method getFoodItems

        //get one particular foodItem from the database with the FoodItemDetail model

        public FoodItemDetail GetFoodItemById(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.FoodItems.Single(e => e.FoodId == id);
                return new FoodItemDetail { FoodId = entity.FoodId, Name = entity.Name, Unit = entity.Unit};

            }//end of using context

        }//end of method GetFoodItemById

        //update a particular foodItem in the database with the FoodItemEdit model
        public bool UpdateFoodItem(FoodItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.FoodItems.Single(e => e.FoodId == model.FoodId);

                entity.Name = model.Name;
                entity.Unit = model.Unit;
                return ctx.SaveChanges() == 1;

            }//end of using context

        }//end of method UpdateFoodItem


        //delete a particular foodItem from the database
        public bool DeleteFoodItem(int id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var entity = ctx.FoodItems.Single(e => e.FoodId == id);

                ctx.FoodItems.Remove(entity);

                return ctx.SaveChanges() == 1;

            }//end of using context


        }//end of method DeleteFoodItem


    }//end of class FoodItemService
}//end of name space
