using Api.RestFull.Data.Converters;
using Api.RestFull.Data.VO;
using Api.RestFull.Model;
using Api.RestFull.Repository.Generic;
using System.Collections.Generic;

namespace Api.RestFull.Business.Implementation
{
    public class BookBusiness : IBookBusiness
    {
        private IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusiness(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }


        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public BookVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }
    }
}
