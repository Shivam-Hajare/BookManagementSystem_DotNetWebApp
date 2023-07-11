using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace Book_Management_System.Models
{
    public class BookCRUD
    {
        public static int count = 1;
        public int BookID
        {
            get; set;
        }
        [Required]
        public string BookName { set; get; }
        [Required]
        public string BookAuthor { set; get; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal BookPrice { set; get; }

        public BookCRUD()
        {

        }
        public BookCRUD(int BookID, string BookName, string BookAuthor, decimal BookPrice)
        {
            this.BookID = BookID;
            this.BookName = BookName;
            this.BookAuthor = BookAuthor;
            this.BookPrice = BookPrice;
        }
        public static List<BookCRUD> GetAllBookList()
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BookMVC; Integrated Security = True;";
            List<BookCRUD> BookList = new List<BookCRUD>();


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Books";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                int BookID = (int)dr["BookID"];
                                string BookName = (string)dr["BookName"];
                                string BookAuthor = (string)dr["BookAuthor"];
                                decimal BookPrice = (decimal)dr["BookPrice"];

                                BookCRUD b = new BookCRUD(BookID, BookName, BookAuthor, BookPrice);

                                BookList.Add(b);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return BookList;
        }

        public static void AddBook(BookCRUD obj)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BookMVC; Integrated Security = True;";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    int id = count++;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO Books (BookName, BookAuthor, BookPrice) VALUES (@BookName, @BookAuthor, @BookPrice)";
                      //  cmd.Parameters.AddWithValue("@BookID", id);
                        cmd.Parameters.AddWithValue("@BookName", obj.BookName);
                        cmd.Parameters.AddWithValue("@BookAuthor", obj.BookAuthor);
                        cmd.Parameters.AddWithValue("@BookPrice", obj.BookPrice);

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void UpdateBook(BookCRUD obj)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BookMVC; Integrated Security = True;";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Books SET BookName=@BookName, BookAuthor=@BookAuthor, BookPrice=@BookPrice WHERE BookID=@BookID";
                        cmd.Parameters.AddWithValue("@BookID", obj.BookID);
                        cmd.Parameters.AddWithValue("@BookName", obj.BookName);
                        cmd.Parameters.AddWithValue("@BookAuthor", obj.BookAuthor);
                        cmd.Parameters.AddWithValue("@BookPrice", obj.BookPrice);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static BookCRUD GetBookById(int id)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BookMVC; Integrated Security = True;";
            BookCRUD b = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Books where BookID=@BookID";
                        cmd.Parameters.AddWithValue("@BookID", id);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                int BookID = (int)dr["BookID"];
                                string BookName = (string)dr["BookName"];
                                string BookAuthor = (string)dr["BookAuthor"];
                                decimal BookPrice = (decimal)dr["BookPrice"];

                                b = new BookCRUD(BookID, BookName, BookAuthor, BookPrice);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return b;
        }

        public static void Delete(int id)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BookMVC; Integrated Security = True;";


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM books WHERE BookID=@BookID";
                        cmd.Parameters.AddWithValue("@BookID", id);
                       
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

