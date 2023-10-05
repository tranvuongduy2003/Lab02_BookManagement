using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataBookStore.Data;
using ODataBookStore.Models;

namespace ODataBookStore.Controllers;

public class BooksController : ODataController
{
    private readonly BookStoreContext _db;

    public BooksController(BookStoreContext db)
    {
        _db = db;
        _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        if (db.Books.Count() == 0)
        {
            foreach (var book in DataSource.GetBooks())
            {
                db.Books.Add(book);
                db.Presses.Add(book.Press);
            }

            db.SaveChanges();
        }
    }

    [EnableQuery(PageSize = 1)]
    public IActionResult Get()
    {
        return Ok(_db.Books);
    }

    [EnableQuery]
    public IActionResult Get(int key, string version)
    {
        return Ok(_db.Books.FirstOrDefault(c => c.Id == key));
    }

    [EnableQuery]
    public IActionResult Post([FromBody] Book book)
    {
        _db.Books.Add(book);
        _db.SaveChanges();
        return Created(book);
    }

    [EnableQuery]
    public IActionResult Delete(int key)
    {
        Book book = _db.Books.FirstOrDefault(c => c.Id == key);
        if (book == null)
        {
            return NotFound();
        }

        _db.Books.Remove(book);
        _db.SaveChanges();
        return Ok();
    }
    
}