using System;
using System.Collections.Generic;
using System.Text;
using VCU_ERAS_Application.Models;

namespace VCU_ERAS_Application.Data
{
    public class SurgeryData
    {
        public List<Surgery> Surgeries { get; private set; }
        public SurgeryData(List<DatabaseEntry> Databasecontent)
        {
            List<Surgery> Surgeries = new List<Surgery>();
            foreach (DatabaseEntry entry in Databasecontent)
            {
                if (entry.type == 0)//entry is a surgery
                {
                    Surgery newSurgery = new Surgery
                    {
                        surgeryname = entry.surgeryname,
                        surgeryInfo = entry.surgeryInfo
                    };
                    Surgeries.Add(newSurgery);
                }
            }
            this.Surgeries = Surgeries;
        }
    }
}
