using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTOs.Animal.Requests;

namespace TerraCloud.Application.Interfaces.Animal
{
    public interface IAddAnimal
    {
        Task Execute(AddAnimalRequest request);
    }
}
