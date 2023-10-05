﻿using ODataBookStore.Models;

namespace ODataBookStore.Data;

public static class DataSource
{
    private static IList<Book> listBooks { get; set; }

    public static IList<Book> GetBooks()
    {
        if (listBooks != null)
        {
            return listBooks;
        }

        listBooks = new List<Book>();
        Book book = new Book
        {
            Id = 1,
            ISBN = "978-0-321-87758-1",
            Title = "Essential C#8.0",
            Author = "Mark Michaelis",
            Price = 59.99m,
            Location = new Address
            {
                City = "HCM City",
                Street = "Thu Duc City"
            },
            Press = new Press
            {
                Id = 1,
                Name = "Addison-Wesley",
                Category = Category.Book
            }
        };
        listBooks.Add(book);
        book = new Book
        {
            Id = 2,
            ISBN = "978-0-321-87758-1",
            Title = "Data Structure and Algorithm",
            Author = "Obrian",
            Price = 59.99m,
            Location = new Address
            {
                City = "Dong Ha",
                Street = "Tran Phu"
            },
            Press = new Press
            {
                Id = 2,
                Name = "Lorem ipsum",
                Category = Category.Book,
            }
        };
        listBooks.Add(book);
        book = new Book
        {
            Id = 3,
            ISBN = "978-0-321-87758-1",
            Title = "Essential C#4.0",
            Author = "Lorem ipsum",
            Price = 59.99m,
            Location = new Address
            {
                City = "Da Nang",
                Street = "Lien Chieu"
            },
            Press = new Press
            {
                Id = 3,
                Name = "Lorem ipsum biasa",
                Category = Category.Book,
            }
        };
        listBooks.Add(book);
        return listBooks;
    }
}