using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkRedirect {
    public class Env {
        public static string RedirectURL = Environment.GetEnvironmentVariable("RedirectURL");
    }
}
