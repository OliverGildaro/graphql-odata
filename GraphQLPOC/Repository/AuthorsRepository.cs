using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuthorsRepository
    {
        private readonly AplicationContext aplicationContext;

        public AuthorsRepository(AplicationContext aplicationContext)
        {
            this.aplicationContext = aplicationContext;
        }

        public Task<IEnumerable<Author>> FindAuthors()
        {
            if (aplicationContext.Authors.Count() == 0)
            {
                aplicationContext.AddRange(DataSource.GetAuthors());
                aplicationContext.SaveChangesAsync();
            }
            var result = aplicationContext.Set<Author>().AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<Author> CreateAuthor(Author author)
        {
            string @Id = Guid.NewGuid().ToString();
            author.Id = @Id;
            foreach (var book in author.Books)
            {
                book.Id = Guid.NewGuid().ToString();
                book.AuthorId = @Id;
            }
            var result = aplicationContext.AddAsync<Author>(author).Result;
            aplicationContext.SaveChangesAsync();
            return Task.FromResult(result.Entity);
        }
    }
}
