using System;
using System.Collections.Generic;
using System.Text;
using VCU_ERAS_Application.Models;
using System.Threading.Tasks;

namespace VCU_ERAS_Application.Services
{
    public class DatabaseEntryManager
	{
		IRestService restService;

		public DatabaseEntryManager(IRestService service)
		{
			restService = service;
		}

		public Task<List<DatabaseEntry>> GetTasksAsync()
		{
			return restService.RefreshDataAsync();
		}

		public Task SaveTaskAsync(DatabaseEntry item, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync(item, isNewItem);
		}

		public Task DeleteTaskAsync(DatabaseEntry item)
		{
			return restService.DeleteTodoItemAsync(item.id.ToString());
		}
	}
}
