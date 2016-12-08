using DefaultMvcControllersAndAlternatives.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DefaultMvcControllersAndAlternatives.DAL
{
    public class BookInitializer : CreateDatabaseIfNotExists<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            var categoryScience = new Category { Name = "Science" };
            var categoryLiterature = new Category { Name = "Literature" };
            var categoryEducation = new Category { Name = "Education" };
            context.Categories.Add(categoryScience);
            context.Categories.Add(categoryLiterature);
            context.Categories.Add(categoryEducation);
            context.SaveChanges();

            List<Book> books = new List<Book>
            {

                new  Book { CategoryId = categoryScience.Id, Name = "Beyin Senin Hikayen", ISBN=9786054729692, Author="David Eagleman ", Publisher="Domingo Yayınevi", PublicationDate=2016, Price="25,00"},
                new  Book { CategoryId = categoryScience.Id, Name = "Zamanın Kısa Tarihi", ISBN=9786051067582, Author="Stephen Hawking", Publisher="Alfa Yayıncılık ", PublicationDate=2016, Price="18,00"},
                new  Book { CategoryId = categoryScience.Id, Name = "Incognito - Beynin Gizli Hayatı", ISBN=9786054729074, Author="David Eagleman", Publisher="Domingo Yayınevi", PublicationDate=2013, Price="25,00"},

                new  Book { CategoryId = categoryLiterature.Id, Name = "Kırık Kuşlar", ISBN=9786051850788, Author="Ayşe Kulin", Publisher="Everest Yayınları", PublicationDate=2016, Price="24,00"},
                new  Book { CategoryId = categoryLiterature.Id, Name = "Harry Potter ve Lanetli Çocuk", ISBN=9789750837609, Author=" J. K. Rowling", Publisher="Yapı Kredi Yayınları ", PublicationDate=2016, Price="22,00"},
                new  Book { CategoryId = categoryLiterature.Id, Name = "Müptezeller", ISBN=9789750520976, Author=" Emrah Serbes", Publisher="İletişim Yayıncılık", PublicationDate=2016, Price="14,50"},

                new  Book { CategoryId = categoryEducation.Id, Name = "Mutluluk Kürleri", ISBN=9786059841658, Author="Ümit Aktaş", Publisher="Hayykitap ", PublicationDate=2016, Price="22,00"},
                new  Book { CategoryId = categoryEducation.Id, Name = "Beni Ödülle Cezalandırma", ISBN=9786050937022, Author="Özgür Bolat", Publisher="Doğan Kitap ", PublicationDate=2016, Price="19,00"},
                new  Book { CategoryId = categoryEducation.Id, Name = "Geliştiren Anne - Baba", ISBN=9789751417480, Author="Doğan Cüceloğlu", Publisher="Remzi Kitabevi", PublicationDate=2016, Price="15,00"}
            };
            books.ForEach(book => context.Books.Add(book));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}