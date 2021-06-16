using System;
using System.Collections.Generic;
using System.Text;
using VCU_ERAS_Application.Models;
using System.Threading.Tasks;

namespace VCU_ERAS_Application.Services
{
    public interface IRestService
	{
		Task<List<DatabaseEntry>> RefreshDataAsync();

		Task SaveTodoItemAsync(DatabaseEntry item, bool isNewItem);

		Task DeleteTodoItemAsync(string id);
	}
}
