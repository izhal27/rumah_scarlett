namespace RumahScarlett.CommonComponents
{
   public interface IAccessTypeEventArgs
   {
      AccessTypeEventArgs.AccessType AccessTypeValue { get; set; }
      bool ValuesWereChanged { get; set; }
   }
}