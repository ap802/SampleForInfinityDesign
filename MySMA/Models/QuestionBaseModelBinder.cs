using System;
using System.Web.Mvc;
using MySMA.Services;

namespace MySMA.Models
{
    /// <summary>
    /// Custom model binder to create the correct type based on the model's QuestionDefinitionId.
    /// 
    /// Inspired by https://stackoverflow.com/questions/7222533/polymorphic-model-binding/7222639#7222639
    /// </summary>
    public class QuestionBaseModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var questionDefinitionIdResult = bindingContext.ValueProvider.GetValue("QuestionDefinitionId");

            if (null == questionDefinitionIdResult)
            {
                throw new InvalidOperationException("QuestionDefinitionId could not be retrieved from the binding context");
            }

            var questionDefinitionIdName = questionDefinitionIdResult.ConvertTo(typeof(string)).ToString();

            QuestionDefinitionId questionDefinitionId;

            Enum.TryParse(questionDefinitionIdName, out questionDefinitionId);
            
            var questionDefinition = new QuestionDefinitionService().GetDefinition(questionDefinitionId);
            var model = questionDefinition.CreateQuestion();
            var type = model.GetType();

            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);

            return model;
        }
    }
}