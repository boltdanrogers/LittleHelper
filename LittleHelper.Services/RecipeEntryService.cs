using LittleHelper.Data;
using LittleHelper.Models.RecipeEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Services
{
    public class RecipeEntryService
    {
        //crud

        //create
        public bool CreateRecipeEntry(RecipeEntryCreate model)
        {
            //take the model, instantiate a RecipeEntry, add to database
            var entity = new RecipeEntry()
            { Name = model.Name, Instructions = model.Instructions, Cooked = model.Cooked, Cooled = model.Cooled };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RecipeEntries.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }//end of method Create

        //get all
        public IEnumerable<RecipeEntryListItem> GetRecipeEntries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.RecipeEntries.Select(e => new RecipeEntryListItem { Name = e.Name, RecipeId = e.RecipeId });

                return query.ToArray();

            }//end of using context


        }//end of method getRecipeEntries

        //get one
        public RecipeEntryDetails GetRecipeEntryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.RecipeEntries.Single(e => e.RecipeId == id);

                return new RecipeEntryDetails { RecipeId = entity.RecipeId, Name = entity.Name, Instructions = entity.Instructions, Cooked = entity.Cooked, Cooled = entity.Cooled };

            }//end of using context

        }//end of method GetRecipeEntryById


        //edit
        public bool UpdateRecipeEntry(RecipeEntryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.RecipeEntries.Single(e => e.RecipeId == model.RecipeId);
                entity.Name = model.Name;
                entity.Instructions = model.Instructions;
                entity.Cooked = model.Cooked;
                entity.Cooled = model.Cooled;

                return ctx.SaveChanges() == 1;

            }//end of using context

        }//end of method UpdateRecipeEntry

        //delete
        public bool DeleteRecipeEntry(int id)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var entity = ctx.RecipeEntries.Single(e => e.RecipeId == id);

                ctx.RecipeEntries.Remove(entity);

                return ctx.SaveChanges() == 1;

            }//end of using context

        }//end of method DeleteRecipeEntry



    }//end of class RecipeEntryService
}//end of name space
