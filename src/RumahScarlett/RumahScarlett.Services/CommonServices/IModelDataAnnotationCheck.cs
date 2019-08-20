namespace RumahScarlett.Services.Services
{
   public interface IModelDataAnnotationCheck
   {
      void ValidateModel<TDomainModel>(TDomainModel domainModel);
   }
}