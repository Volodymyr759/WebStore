using Domain.Models.Parameters;
using System.Collections.Generic;

namespace Services.ParametersService
{
    public interface IParametersService
    {
        void Add(IParametersModel parametersModel);
        void DeleteById(int id);
        List<ParametersDtoModel> GetParametersToList();
        IParametersModel GetById(int id);
        void Update(IParametersModel parametersModel);
    }
}
