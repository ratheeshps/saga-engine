using System;

namespace sagamessages
{
    public class IRemitterMessage
    {
        public Guid RemitterID { get; set; }
        public string RemitterFirstName { get; set; }
        public string RemitterLastName { get; set; }
        public string RemitterCountry { get; set; }
        public string RemitterStatus { get; set; }
    }
    public interface IRemitterSaveEvent
    {
        Guid RemitterID { get;  }
        string RemitterFirstName { get; }
        string RemitterLastName { get;  }
        string RemitterCountry { get;  }
        string RemitterStatus { get;  }
    }
}
