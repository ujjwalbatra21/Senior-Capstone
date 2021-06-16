using System;
using System.Collections.Generic;
using System.Text;
using VCU_ERAS_Application.Models;

namespace VCU_ERAS_Application.Data
{
    class LocationData
    {
        public List<Location> _Locations { get; private set; }
        public LocationData(List<DatabaseEntry> Databasecontent)
        {
            List<Location> Locations = new List<Location>();
            foreach (DatabaseEntry entry in Databasecontent)
            {
                if(entry.type == 2)//entry is a location
                {
                    Location newLocation = new Location
                    {
                        locationname = entry.locationname,
                        address = entry.address,
                        phonenumber = entry.phonenumber,
                        dayofinformation = entry.dayofinformation
                    };
                    Locations.Add(newLocation);
                }
            }
            _Locations = Locations;
        }
    }
}
