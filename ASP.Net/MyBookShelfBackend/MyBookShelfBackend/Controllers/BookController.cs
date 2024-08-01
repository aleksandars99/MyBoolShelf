﻿using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using MyBookShelfBackend.Data;
using MyBookShelfBackend.Dtos;
using MyBookShelfBackend.Interfaces;
using MyBookShelfBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBookShelfBackend.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBookRepository _bookRepository;
        public BookController(AppDbContext appDbContext, IBookRepository bookRepository)
        {
            _context = appDbContext;
            _bookRepository = bookRepository;
        }
        [HttpPost(template: "create")]
        public async Task<IActionResult> Create (AddBookDto dto)
        {
            var book = new Books
            {
                Title = dto.Title,
                Author = dto.Author,
                ReleaseDate = dto.ReleaseDate,
                ISBN = dto.ISBN
            };
            return Created("Success", _bookRepository.CreateBook(book));
        }
        [HttpGet(template:"AllBooks")]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAllBooks();
            return Ok(books);
        }
        [HttpPut(template:"edit/{id}")]
        public IActionResult Edit (int id, EditBookDto dto)
        {
            var book = _context.Books.Find(id);
            if (book is null)
            {
                return NotFound();
            }
            book.Title = dto.Title;
            book.Description = dto.Description;
            book.Author = dto.Author;
            book.Rating = dto.Rating;
            book.Price = dto.Price;
            book.Comments = dto.Comments;
            book.Categories = dto.Categories;
            book.Edition = dto.Edition;
            book.PageNumber = dto.PageNumber;
            book.Alphabet = dto.Alphabet;
            book.ReleaseDate = dto.ReleaseDate;
            book.YoutubeLink = dto.YoutubeLink;
            book.ISBN = dto.ISBN;

            _bookRepository.Save();
            return Ok(book);
        }
        [HttpDelete(template:"delete/{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);

            if (book is null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _bookRepository.Save();

            return Ok();
        }
    } 
}
