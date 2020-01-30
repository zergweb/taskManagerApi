using Infrastructure.Entitys;
using Infrastructure.Model.Enums;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TaskManagerService
    {

        private readonly TaskTemplatesRepository templateRep;

        private readonly TaskRepository taskRep;
        public TaskManagerService( TaskTemplatesRepository teRep, TaskRepository taRep)
        {
            templateRep = teRep;
            taskRep = taRep;
        }

        public async Task InitDbAsync()
        {
            var st1 = new TaskFieldEnum()
            {
                Indicator = "status",
                Values = new Dictionary<string, string> {
                    {"1" , "Proposed" },
                    {"2" , "Active" },
                    {"3" , "Resolved"}
                },
                Order = 1
            };
            var st2 = new TaskFieldEnum()
            {
                Indicator = "status2",
                Values = new Dictionary<string, string> {
                    {"1" , "Open" },
                    {"2" , "Complete" },
                    {"3" , "In progress"}
                },
                Order = 2
            };
            var temp = new TaskTemplate()
            {
                EnumFields = new TaskFieldEnum[] { st1, st2 },
                Fields = new TaskField[] {
                new TaskField() {Indicator = "description", Type = TaskFieldType.String, Value = "default value" },
                new TaskField() {Indicator = "date", Type = TaskFieldType.Date, Value = "12.12.2019" },
                new TaskField() {Indicator = "hours", Type = TaskFieldType.Number, Value = "0" }
                }
                
            };

            await this.templateRep.AddItemAsync(temp);

            var template = (await templateRep.GetAllItemsAsync()).FirstOrDefault();

            var taskItem = new TaskItem()
            {
                TemplateId = template?.Id,
                Fields = new TaskField[] {
                new TaskField() {Indicator = "description", Type = TaskFieldType.String, Value = "some task value" },
                new TaskField() {Indicator = "date", Type = TaskFieldType.Date, Value = "12.12.2019" },
                new TaskField() {Indicator = "hours", Type = TaskFieldType.Number, Value = "16" },
                new TaskField() {Indicator = "status", Type = TaskFieldType.Enum, Value = "1" },
                new TaskField() {Indicator = "status2", Type = TaskFieldType.Enum, Value = "3" }
                }
            };

            await taskRep.AddItemAsync(taskItem);
        }
        
        public async Task<(TaskTemplate template, IEnumerable<TaskItem> tasks)> GetDataAsync()
        {
            var template = (await templateRep.GetAllItemsAsync()).FirstOrDefault();

            var items = await taskRep.GetItemsAsync(template?.Id);
            return (template, items);
        }

    }
}
