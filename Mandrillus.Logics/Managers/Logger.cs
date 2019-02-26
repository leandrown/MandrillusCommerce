using System;
using Mandrillus.Contracts.Repository;

namespace Mandrillus.Logics.Managers
{
   public class Logger : ILogger
   {
      public void Log(Exception ex)
      {
         throw new Exception(ex.Message, ex.InnerException);
      }
   }
}
