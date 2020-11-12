using System;
using System.Collections.Generic;
using System.Text;

namespace sagamessages
{
    public class IAmlData
    {
        public Guid RemitterID { get; set; }
        public string AmlStatus { get; set; }
    }
    public interface IAmlValidationEvent
    {
         Guid RemitterID { get;  }
         string RemitterFirstName { get;  }
         string RemitterLastName { get;  }
         string RemitterCountry { get;  }
    }
}
