using System;
using System.Collections.Generic;
using Domain.Models.Images;
using Services.ImagesService;

namespace DataAccess.RepositoriesSqlCE
{
    public class ImagesRepository : IImagesRepository
    {
        public void Add(IImagesModel imagesModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImagesDtoModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ImagesModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IImagesModel imagesModel)
        {
            throw new NotImplementedException();
        }
    }
}
