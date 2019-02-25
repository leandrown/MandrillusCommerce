using System;
using Mandrillus.Contracts.Handlers;
using Mandrillus.Contracts.Repository;

namespace Mandrillus.Logics.Handlers
{
   public class ExceptionHandler : IExceptionHandler
   {
      private ILogger _logger;

      public ExceptionHandler(ILogger logger)
      {
         _logger = logger;
      }

      public T Run<T>(Func<T> func)
      {
         try
         {
            return func.Invoke();
         }
         catch (Exception e)
         {
            _logger.Log(e);
         }

         return default(T);
      }
   }
}
