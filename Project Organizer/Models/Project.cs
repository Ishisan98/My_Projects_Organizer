namespace Project_Organizer.Models
{
    public class Project
    {
        public int Project_Id { get; set; }

        public string Project_Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool ProjectStatus { get; set; }
    }
}
