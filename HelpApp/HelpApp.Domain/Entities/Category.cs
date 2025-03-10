using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpApp.Domain.Entities;
using HelpApp.Domain.Validation;

namespace HelpApp.Domain.Entities
{
    internal class Category
    {
        #region Atributos
        public Category Id { get; set; }
        public string Name { get; set; }
        #endregion
        #region Constructors
        public Category(string name)
        {
            Name = name;
        }
        public ICollection<Category> Products { get; set;}
        #endregion
        #region Validação
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.when(string.IsNullOrEmpty(name),
                "invalid name, name is required");
            DomainExceptionValidation.when(name.Length < 3,
                "Invalid name, too short, minimun 3 characters.");

            Name = name;
        }
        #endregion
    }
}
