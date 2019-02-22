using System;

namespace Mandrillus.Contracts.Handlers
{
   public interface IExceptionHandler
   {
      T Run<T>(Func<T> func);
   }
}
