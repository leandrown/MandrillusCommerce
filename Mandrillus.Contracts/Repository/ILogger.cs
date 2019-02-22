using System;

namespace Mandrillus.Contracts.Repository
{
   public interface ILogger
   {
      void Log(Exception ex);
   }
}
