using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legrand.ViewModels {

    public class Program {

        public int ID { get; set; }
        public String Title { get; set; }

        public Program(String title) {

            this.Title = title;
        }
    }
}
