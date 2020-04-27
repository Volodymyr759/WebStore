using Domain.Models.Images;
using System.Collections.Generic;

namespace Services.ImagesService
{
    public interface IImagesService
    {
        void Add(IImagesModel imagesModel);
        void DeleteById(int id);
        List<ImagesDtoModel> GetImagesToList();
        IImagesModel GetById(int id);
        void Update(IImagesModel imagesModel);
    }
}
