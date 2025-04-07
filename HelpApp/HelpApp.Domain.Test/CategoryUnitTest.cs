using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using HelpApp.Domain.Entities;

namespace HelpApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Category With Valid State")]

        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action= () => new Category(1, "Category Name") ;
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion
        #region Testes Negativos
        [Fact(DisplayName = "Create Category With Invalid ID")]

        public void CreateCategory_WithInvalidID_ResultObjectException()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Empty Name")]

        public void CreateCategory_WithEmptyName_ResultObjectException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, name is required.");
        }
        
        [Fact(DisplayName = "Create Category With Null Name")]
        public void CreateCategory_WithNullName_ResultObjectException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, name is required.");

        }
     

        [Fact(DisplayName = "Create Category With Too Short Name")]
        public void CreateCategory_WithNameTooShort_ResultObjectException()
        {
            Action action = () => new Category(1, "Vi");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }
        #endregion
    }
}
