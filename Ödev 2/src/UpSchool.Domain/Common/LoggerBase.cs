using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Domain.Common
{
    public abstract class LoggerBase
    {
        private string titanicFluteUrl;

        protected LoggerBase(string titanicFluteUrl)
        {
            this.titanicFluteUrl = titanicFluteUrl;
        }

        public virtual void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
