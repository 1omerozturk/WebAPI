﻿using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        // GET işlemi ile tüm verileri getirme
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }



        // belirli bir id değerine sahip veri çekme işlemi.

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();
            if (book is null)
            {
                return NotFound(); //404
            }
            return Ok(book);
        }

        // POST işlemi ile yeni kitap ekleme.

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest(); // 400

                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] 
        int id,[FromBody] Book book)
        {
            // check book
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound(); // 404

            // check id
            if (id != book.Id)
                return BadRequest(); // 400

            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }

        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name ="id")] int id)
        {
            var entity=ApplicationContext
                .Books
                .Find(b=>b.Id.Equals(id));

            // check book
            if (entity is null)
                return NotFound(
                    new
                    {
                        stausCode=404,
                        message=$"Book with id:{id} could not found."
                    }
                    );// 404
            ApplicationContext.Books.Remove(entity);
            return NoContent();
        }

        [HttpPatch]
        public IActionResult 

    }
}
