﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Data
{
    public class Post
    {

        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Body { get; set; } = "";

        public string Description { get; set; } = "";

        public string Author { get; set; } = "";

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
