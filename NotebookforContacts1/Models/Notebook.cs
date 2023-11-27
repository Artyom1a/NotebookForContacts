using System.ComponentModel.DataAnnotations;

namespace NotebookforContacts1.Models
{
        public class Notebook
        {
            public int Id { get; set; }
            [Required(ErrorMessage ="This is not empty")]
            public string Name { get; set; }
            public string MobilePhone { get; set; }
            public string JobTitle { get; set; }
            public string BirthDate { get; set; }
        }

}
