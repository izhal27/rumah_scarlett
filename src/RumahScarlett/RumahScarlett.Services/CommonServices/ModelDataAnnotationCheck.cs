using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services
{
   public class ModelDataAnnotationCheck : IModelDataAnnotationCheck
   {
      public void ValidateModel<TDomainModel>(TDomainModel model)
      {
         var validationResultList = new List<ValidationResult>();
         ValidationContext validationContext = new ValidationContext(model);
         StringBuilder stringBuilder = new StringBuilder();

         if (!Validator.TryValidateObject(instance: model,
                                          validationContext: validationContext,
                                          validationResults: validationResultList,
                                          validateAllProperties: true))
         {
            foreach (var validationResult in validationResultList)
            {
               stringBuilder.Append(validationResult.ErrorMessage)
                            .AppendLine();
            }
         }

         if (validationResultList.Count > 0)
         {
            throw new ArgumentException(stringBuilder.ToString());
         }
      }
   }
}
