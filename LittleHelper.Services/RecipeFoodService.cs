using LittleHelper.Data;
using LittleHelper.Models.RecipeFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Services
{
    public class RecipeFoodService
    {
        //crud

        //create
        public bool CreateRecipeFood(RecipeFoodCreate model)
        {
            var entity = new RecipeFood() { FoodId = model.FoodId, RecipeId = model.RecipeId, Quantity = model.Quantity, Unit = model.Unit };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RecipeFoods.Add(entity);
                return ctx.SaveChanges() == 1;

            }//end of using context


        }//end of method createRecipeFood
        
        
        //get all
        public IEnumerable<RecipeFoodListItem> GetRecipeFoods()
        {
            using (var ctx= new ApplicationDbContext())
            {
                var query = ctx.RecipeFoods.Select(e => new RecipeFoodListItem { RecipeFoodId = e.RecipeFoodId, FoodId = e.FoodId, RecipeId = e.RecipeId });

                return query.ToArray();

            }//end of using context

        }//end of method GetRecipeFoods


        //get one
        public RecipeFoodDetails GetRecipeFoodById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.RecipeFoods.Single(e => e.FoodId == id);
                return new RecipeFoodDetails { RecipeFoodId = entity.RecipeFoodId, FoodId = entity.FoodId, RecipeId = entity.RecipeId, Quantity = entity.Quantity, Unit = entity.Unit };


            }//end of using context


        }//end of method GetRecipeFoodById


        //edit
        public bool UpdateRecipeFood(RecipeFood model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.RecipeFoods.Single(e => e.RecipeFoodId == model.RecipeFoodId);
                entity.RecipeId = model.RecipeId;
                entity.FoodId = model.FoodId;
                entity.Quantity = model.Quantity;
                entity.Unit = model.Unit;

                return ctx.SaveChanges() == 1;
            }//end of using context



        }//end of method UpdateRecipeFood


        //delete
        public bool DeleteRecipeFood(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.RecipeFoods.Single(e => e.RecipeFoodId == id);

                ctx.RecipeFoods.Remove(entity);
                return ctx.SaveChanges() == 1;
            }//end of using


        }//end of method DeleteRecipeFood



    }//end of class RecipeFoodService
}//end of name space
