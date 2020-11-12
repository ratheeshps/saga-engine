using messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace saga_state.machine
{
  public  class AmlValidationEvent: IAmlValidationEvent
    {
        private readonly RemitterStateData _remitterStateData;
        public AmlValidationEvent(RemitterStateData remitterStateData)
        {
            _remitterStateData = remitterStateData;
        }

        Guid IAmlValidationEvent.RemitterID => _remitterStateData.RemitterID;

        string IAmlValidationEvent.RemitterFirstName => _remitterStateData.RemitterFirstName;

         string IAmlValidationEvent.RemitterLastName => _remitterStateData.RemitterLastName;

         string IAmlValidationEvent.RemitterCountry => _remitterStateData.RemitterCountry;
    }
}
