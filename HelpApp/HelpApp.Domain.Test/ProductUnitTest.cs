using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HelpApp.Domain.Entities;
using Xunit;

namespace HelpApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Product With Valid State")]

        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Batata", "Tuberculo", 5.00m, 10, "https://superprix.vteximg.com.br/arquivos/ids/178620/Batata-Especial-1kg.png?v=636857520320030000");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion
        #region Testes Negativos
        [Fact(DisplayName = "Create Product With Invalid ID")]

        public void CreateProduct_WithInvalidID_ResultObjectException()
        {
            Action action = () => new Product(-1, "Product Name", "Description", 5.00m, 5, "Image.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Update Invalid Id value");
        }
        [Fact(DisplayName = "Create Product With Empty Name")]

        public void CreateProduct_WithEmptyName_ResultObjectException()
        {
            Action action = () => new Product(0, "", "Description", 5.00m, 5, "Image.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, name is required.");
        }
        [Fact(DisplayName = "Create Product With Null Name")]

        public void CreateProduct_WithNullName_ResultObjectException()
        {
            Action action = () => new Product(0, null, "Description", 5.00m, 5, "Image.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, name is required.");
        }
        [Fact(DisplayName = "Create Product With Too Short Name")]

        public void CreateProduct_WithTooShortName_ResultObjectException()
        {
            Action action = () => new Product(0, "Vi", "Description", 5.00m, 5, "Image.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Empty Description")]

        public void CreateProduct_WithEmptyDescription_ResultObjectException()
        {
            Action action = () => new Product(0, "Product Name", "", 5.00m, 5, "Image.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, name is required.");
        }
        [Fact(DisplayName = "Create Product With Null Description")]

        public void CreateProduct_WithNullDescription_ResultObjectException()
        {
            Action action = () => new Product(0, "Product Name", null, 5.00m, 5, "Image.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, name is required.");
        }
        [Fact(DisplayName = "Create Product With Too Short Description")]

        public void CreateProduct_WithTooShortDescription_ResultObjectException()
        {
            Action action = () => new Product(0, "Product Name", "null", 5.00m, 5, "Image.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters.");
        }
        [Fact(DisplayName = "Create Product With Negative Price Value")]

        public void CreateProduct_WithNegativePriceValue_ResultObjectException()
        {
            Action action = () => new Product(0, "Product Name", "Description", -5.00m, 5, "Image.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price negative value.");
        }
        [Fact(DisplayName = "Create Product With Negative Stock Value")]

        public void CreateProduct_WithNegativeStockValue_ResultObjectException()
        {
            Action action = () => new Product(0, "Product Name", "Description", 5.00m, -5, "Image.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock negative value.");

        }
        [Fact(DisplayName = "Create Product With Image Name Too Long")]

        public void CreateProduct_WithImageNameTooLong_ResultObjectException()
        {
            Action action = () => new Product(0, "Product Name", "Description", 5.00m, 5, "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZzAaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZzAaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZzAaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZzAaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZzAaB.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters.");

        }
        [Fact(DisplayName = "Create Product With Image Name Empty")]

        public void CreateProduct_WithImageNameEmpty_ResultObjectException()
        {
            Action action = () => new Product(0, "Product Name", "Description", 5.00m, 5, "");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, name is required.");

        }
        #endregion
    }
}