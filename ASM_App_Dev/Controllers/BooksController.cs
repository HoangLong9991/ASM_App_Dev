﻿using ASM_App_Dev.Data;
using ASM_App_Dev.Models;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

namespace ASM_App_Dev.Controllers
{
    public class BooksController : Controller
    {
        // 1 - Declare ApplicationDbContext
        private ApplicationDbContext _context;
        public  BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 2 - View Book Data
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Book> books = _context.Books.ToList();
            return View(books);
        }

        // 3 - Create Book Data
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            var newBook = new Book
            {
                NameBook = book.NameBook,
                QuantityBook = book.QuantityBook,
                Price = book.Price,
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // 4 - Delete Book Data
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(t => t.Id == id);
            if (bookInDb is null)
            {
                return NotFound();
            }
            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // 5 - Edit Book Data
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(t => t.Id == id);
            if (bookInDb is null)
            {
                return NotFound();
            }

            return View(bookInDb);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            var bookInDb = _context.Books.SingleOrDefault(t => t.Id == book.Id);
            if (bookInDb is null)
            {
                return BadRequest();
            }

            bookInDb.NameBook = book.NameBook;
            bookInDb.QuantityBook = book.QuantityBook;
            bookInDb.Price = book.Price;
            bookInDb.InformationBook = book.InformationBook;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // 6 - View Book Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(t => t.Id==id);
            if (bookInDb is null)
            {
                return NotFound();
            }
            return View(bookInDb);
        }


    }
}
