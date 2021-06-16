using System;
using System.Collections.Generic;
using System.Text;
using VCU_ERAS_Application.Models;

namespace VCU_ERAS_Application.Data
{
    public static class DatabaseEntryData
    {
        public static List<DatabaseEntry> Databasecontent { get; private set; }
        static DatabaseEntryData()
        {

            Databasecontent = new List<DatabaseEntry>();

            Databasecontent.Add(new DatabaseEntry
            {
                id = 1,
                type = 0,
                surgeryname = "Breast Reconstruction",
                surgeryInfo = "The following information provides an introduction to the variety of techniques that may be offered for breast reconstruction. After a mastectomy, you have three main options available:  No reconstruction Implant-based reconstruction Autologous-based (using your skin and tissue) reconstruction   In some cases, implant and autologous approaches may be combined. The timing of breast reconstruction may occur in an immediate setting (at the time of your mastectomy) or a delayed setting. It is important to recognize that either reconstruction method often involves multiple procedures in a staged fashion (at different times). Ultimately, the decision of what type of reconstruction and the timing of your reconstruction will be determined between you and your surgeon. In certain patients, the use of a breast implant may be considered for breast reconstruction. This can be performed in an immediate or delayed fashion in relation to your mastectomy surgery. "
            });
            Databasecontent.Add(new DatabaseEntry
            {
                id = 2,
                type = 0,
                surgeryname = "Heart Surgery",
                surgeryInfo = "An alternative to standard bypass surgery (CABG). Small incisions ('ports') are made in the chest. Chest arteries or veins from your leg are attached to the heart to 'bypass' the clogged coronary artery or arteries. The instruments are passed through the ports to perform the bypasses. The surgeon views these operations on video monitors rather than directly. In PACAB, the heart is stopped and blood is pumped through an oxygenator or 'heart - lung' machine. MIDCAB is used to avoid the heart-lung machine. It's done while the heart is still beating. Requires several days in the hospital."
            });
            Databasecontent.Add(new DatabaseEntry
            {
                id = 3,
                type = 1,
                condition = "Smoker",
                dietinstructions = "",
                postinstructions = "Do not smoke for 14 days after your procedure."
            });
            Databasecontent.Add(new DatabaseEntry
            {
                id = 4,
                type = 1,
                condition = "Diabetic",
                dietinstructions = "Do not eat solid food for one day before the procedure.",
                postinstructions = "Take Dapagliflozin for one week after the procedure."
            });
            Databasecontent.Add(new DatabaseEntry
            {
                id = 5,
                type = 2,
                locationname = "3600 Centre",
                address = "3600 W. Broad Street, Suite 115 Richmond,VA 23230",
                phonenumber = "1-800-762-6161",
                dayofinformation = "Check into the front desk located on the third floor directly ouside of the elevator."
            });
            Databasecontent.Add(new DatabaseEntry
            {
                id = 6,
                type = 2,
                locationname = "Ambulatory Care Center",
                address = "417 N. 11th Street Richmond, VA 23219",
                phonenumber = "1-800-762-6161",
                dayofinformation = "Check into the front desk located near the llth street entrance."
            });
        }
    }
}
