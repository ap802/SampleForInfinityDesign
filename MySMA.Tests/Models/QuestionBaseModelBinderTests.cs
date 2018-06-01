using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using MySMA.Controllers;
using NUnit.Framework;
using MySMA.Models;
using NUnit.Core;

namespace MySMA.Tests.Models
{
    class QuestionBaseModelBinderTests
    {
        [Test]
        public void CreateModel_CreatesModelOfCorrectType_CreatesModelMetaDataOfCorrectQuestionType()
        {
            // Arrange
            var formCollection = new NameValueCollection
            {
                // MaritalStatus here provides better test experience over CurrentLienHolder 
                // since CurrentLienHolder is a default value for Enum.TryParse(questionDefinitionIdName
                { "QuestionDefinitionId", "MaritalStatus"}
            };

            var valueProvider = new NameValueCollectionValueProvider(formCollection, null);
            var modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(QuestionBase));

            var bindingContext = new ModelBindingContext
            {
                ModelName = "",
                ValueProvider = valueProvider,
                ModelMetadata = modelMetadata
            };

            QuestionBaseModelBinder b = new QuestionBaseModelBinder();            
            ControllerContext controllerContext = new ControllerContext();

            // Act
            QuestionBase result = (QuestionBase) b.BindModel(controllerContext, bindingContext);

            // Assert
            Assert.AreEqual(result.QuestionDefinitionId, QuestionDefinitionId.MaritalStatus);
        }

        [Test]
        public void CreateModel_QuestionDefinitionIdNotInBindingContext_ThrowsInvalidOperationException()
        {
            // Arrange
            var formCollection = new NameValueCollection
            {
                { "NonExistingProperty", ""}
            };

            var valueProvider = new NameValueCollectionValueProvider(formCollection, null);
            var modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(QuestionBase));

            var bindingContext = new ModelBindingContext
            {
                ModelName = "",
                ValueProvider = valueProvider,
                ModelMetadata = modelMetadata
            };

            QuestionBaseModelBinder b = new QuestionBaseModelBinder();
            ControllerContext controllerContext = new ControllerContext();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => b.BindModel(controllerContext, bindingContext));
        }

    }
}
