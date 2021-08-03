using LittleHelper.Data;
using LittleHelper.Models.StorageArea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Services
{
 
    public class StorageAreaService
    {
        //crud

        //create
        public bool CreateStorageArea(StorageAreaCreate model)
        {
            var entity = new StorageArea { Name = model.Name, Size = model.Size, Powered = model.Powered, Spaces = model.Spaces, SpaceNames = model.SpaceNames };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.StorageAreas.Add(entity);

                return ctx.SaveChanges() == 1;

            }//end of using context


        }//end of method CreateStorageArea

        //get all
        public IEnumerable<StorageAreaListItem> GetStorageAreas()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.StorageAreas.Select(e => new StorageAreaListItem { StorageId = e.StorageId, Name = e.Name, Powered = e.Powered });

                return query.ToArray();

            }//end of using context


        }//end of method GetStorageItems


        public StorageAreaDetails GetStorageAreaById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx.StorageAreas.Single(e => e.StorageId == id);

                return new StorageAreaDetails { StorageId = entity.StorageId, Name = entity.Name, Size = entity.Size, Powered = entity.Powered, Spaces = entity.Spaces, SpaceNames = entity.SpaceNames };

            }//end of using context

        }//end of method getStorageAreaById


        //edit
        public bool UpdateStorageArea(StorageAreaEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.StorageAreas.Single(e => e.StorageId == model.StorageId);

                entity.Name = model.Name;
                entity.Size = model.Size;
                entity.Powered = model.Powered;
                entity.Spaces = model.Spaces;
                entity.SpaceNames = model.SpaceNames;

                return ctx.SaveChanges() == 1;

            }//end of using context



        }//end of method UpdateStorageArea

        //delete
        public bool DeleteStorageArea(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.StorageAreas.Single(e => e.StorageId == id);

                ctx.StorageAreas.Remove(entity);

                return ctx.SaveChanges() == 1;

            }//end of using context

        }//end of method DeleteStoarageArea


    }//end of class StorageFoodService
}//end of name space
