using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Models
{
    public class Visit
    {
        public int Id { get; set; }

        public DateTime BeginTime { get; set; } = DateTime.Now;

        public DateTime EndTime { get; set; }

        public int StatementId { get; set; }
        public Statement Statement { get; set; }
        
    }
}
