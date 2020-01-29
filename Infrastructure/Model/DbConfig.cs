using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Model
{
    public class DbConfig
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TasksCollectionName { get; set; }
        public string TaskTemplatesCollectionName { get; set; }
    }
}
