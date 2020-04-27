using Domain.Models.Images;
using System.Collections.Generic;

namespace Services.ImagesService
{
    public interface IImagesRepository
    {
        void Add(IImagesModel imagesModel);
        void Update(IImagesModel imagesModel);
        void DeleteById(int id);
        IEnumerable<ImagesDtoModel> GetAll();
        ImagesModel GetById(int id);
    }
}
