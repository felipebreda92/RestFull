using Api.RestFull.Data.Converter;
using Api.RestFull.Data.VO;
using Api.RestFull.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.RestFull.Data.Converters
{
    public class BookConverter : IParser<Book, BookVO>, IParser<BookVO, Book>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null) return new BookVO();

            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LauchDate = origin.LauchDate
            };
        }

        public Book Parse(BookVO origin)
        {
            if (origin == null) return new Book();

            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LauchDate = origin.LauchDate
            };
        }

        public List<BookVO> ParseList(List<Book> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }

        public List<Book> ParseList(List<BookVO> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
