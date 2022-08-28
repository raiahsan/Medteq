using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class File
    {
        public int ID { get; set; }
        public int fk_EntityID { get; set; }
        public int RecordID { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
        public int UploadedBy { get; set; }
        public DateTime UploadedDate { get; set; }

        public virtual Entity Entity { get; set; }
        public virtual User UploadedByUser { get; set; }
    }
}
