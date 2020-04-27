using Domain.Models.Parameters;
using System.Collections.Generic;

namespace Services.ParametersService
{
    public interface IParametersRepository
    {
        void Add(IParametersModel parametersModel);
        void Update(IParametersModel parametersModel);
        void DeleteById(int id);
        IEnumerable<ParametersDtoModel> GetAll();
        ParametersModel GetById(int id);
    }
}
