using Repository.Models;
using System;
using System.Collections.Generic;

namespace Repository
{
    public static class DataSource
    {
        private static List<Author> authors { get; set; }
        public static List<Author> GetAuthors()
        {
            string id1 = Guid.NewGuid().ToString();
            string id2 = Guid.NewGuid().ToString();
            string id3 = Guid.NewGuid().ToString();
            if (authors != null)
            {
                return authors;
            }

            authors = new List<Author>();

            var author1 = new Author
            {
                Id = id1,
                Name = "Friedrich",
                LastName = "RaNietzschend",
                Books = new List<Book>
                {
                    new Book
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Twilight of the Idols",
                        Price = 29.3,
                        AuthorId = id1
                    },
                    new Book
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Philosophy in the Tragic Age of the Greeks",
                        Price = 33.3,
                        AuthorId = id1
                    }
                }
            };

            var author2 = new Author
            {
                Id = id2,
                Name = "Ayn",
                LastName = "Rand",
                Books = new List<Book>
                {
                    new Book
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "We the Living",
                        Price = 8.22,
                        AuthorId = id2
                    },
                                        new Book
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "The Fountainhead",
                        Price = 13.45,
                        AuthorId = id2
                    }
                }
            };

            var author3 = new Author
            {
                Id = id3,
                Name = "William",
                LastName = "Blake",
                Books = new List<Book>
                {
                    new Book
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "The tiger",
                        Price = 15.45,
                        AuthorId = id3
                    },
                    new Book
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Poems",
                        Price = 23.45,
                        AuthorId = id3
                    }
                }
            };
            authors.Add(author1);
            authors.Add(author2);
            authors.Add(author3);
            return authors;
        }
    }
}
