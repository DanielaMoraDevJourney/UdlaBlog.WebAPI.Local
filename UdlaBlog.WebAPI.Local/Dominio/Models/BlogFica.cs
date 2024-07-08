using System;
using System.Collections.Generic;

namespace UdlaBlog.Domain.Entities
{
    public class BlogFica
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Contenido { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
