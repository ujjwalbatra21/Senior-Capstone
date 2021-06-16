using System;
using System.Collections.Generic;
using System.Text;
using VCU_ERAS_Application.Models;

namespace VCU_ERAS_Application.Data
{
    public class ConditionData
    {
        public List<Condition> _Conditions { get; private set; }
        public ConditionData(List<DatabaseEntry> Databasecontent)
        {
            List<Condition> Conditions = new List<Condition>();
            foreach (DatabaseEntry entry in Databasecontent)
            {
                if (entry.type == 1)//entry is a condition
                {
                    Condition newCondition = new Condition
                    {
                        conditionname = entry.condition,
                        dietinstructions = entry.dietinstructions,
                        postinstructions = entry.postinstructions
                    };
                    Conditions.Add(newCondition);
                }
            }
            _Conditions = Conditions;
        }
    }
}
