﻿using MyBookShelfBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBookShelfBackend.Dtos
{
    public class EditBookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string Author { get; set; }
        [Range(0, 10)]
        public decimal Rating { get; set; }
        public string Price { get; set; }
        public string[]? Comments { get; set; }
        public string[]? Categories { get; set; }
        public BookEdition? Edition { get; set; }
        public string? PageNumber { get; set; }
        public string? Alphabet { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public string? YoutubeLink { get; set; }
        public string? ISBN { get; set; }
    }
}
