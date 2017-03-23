using FakeBlog.Controllers.Published;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FakeBlog.DAL.Repository
{
    public class AuthorRepository : IAuthorManager, IAuthorQuery
    {
        IDbConnection _blogConnection;

        public AuthorRepository(IDbConnection blogConnection)
        {
            _blogConnection = blogConnection;
        }
        public void AddAuthor(int authorId, string fullName)
        {
            // opening a sql connection
            _blogConnection.Open();

            try
            {

                var addBoardCommand = _blogConnection.CreateCommand();
                addBoardCommand.CommandText = $"Insert into Post(Name, Owner_Id) values(@authorId, @fullname)";
                // name parameter
                var authorIdParameter = new SqlParameter("authorId", SqlDbType.Int);
                authorIdParameter.Value = authorId;
                addBoardCommand.Parameters.Add(authorIdParameter);
                // owner parameter
                var fullNameParameter = new SqlParameter("fullname", SqlDbType.VarChar);
                authorIdParameter.Value = fullName;
                addBoardCommand.Parameters.Add(fullNameParameter);

                addBoardCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _blogConnection.Close();
            }
        }

        public void DeleteAuthor(int authorId)
        {
            // opening a sql connection
            _blogConnection.Open();

            try
            {
                var removeBoardCommand = _blogConnection.CreateCommand();
                removeBoardCommand.CommandText = @"
                Delete 
                From Author
                Where AuthorId = @authorId";
                // name parameter
                var authorIdParameter = new SqlParameter("authorId", SqlDbType.Int);
                authorIdParameter.Value = authorId;
                removeBoardCommand.Parameters.Add(authorIdParameter);

                removeBoardCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _blogConnection.Close();
            }
        }

        public void EditAuthor(int authorId, string title)
        {
            // opening a sql connection
            _blogConnection.Open();

            try
            {
                var updateAuthorCommand = _blogConnection.CreateCommand();
                updateAuthorCommand.CommandText = @"
                Update Author
                Set Title = @title
                Where AuthorId = @authorId";
                // title parameter
                var titleParameter = new SqlParameter("title", SqlDbType.VarChar);
                titleParameter.Value = title;
                updateAuthorCommand.Parameters.Add(titleParameter);
                // author parameter
                var authorIdParameter = new SqlParameter("authorId", SqlDbType.Int);
                authorIdParameter.Value = authorId;
                updateAuthorCommand.Parameters.Add(authorIdParameter);

                updateAuthorCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                _blogConnection.Close();
            }
        }

        public Author GetAuthor(int authorId)
        {
            _blogConnection.Open();

            try
            {
                var getBoardCommand = _blogConnection.CreateCommand();
                getBoardCommand.CommandText = @"
                SELECT AuthorId, FullName, Email, Username
                FROM Author 
                WHERE AuthorId = @authorId ";
                var authorIdParam = new SqlParameter("authorId", SqlDbType.Int);
                authorIdParam.Value = authorId;

                getBoardCommand.Parameters.Add(authorIdParam);
                var reader = getBoardCommand.ExecuteReader();

                var author = new Author();
                if (reader.Read())
                {
                    author.AuthorId = reader.GetInt32(0);
                    author.FullName = reader.GetString(1);
                    author.Email = reader.GetString(2);
                }
                return author;
            }
            catch (Exception ex) { }
            finally
            {
                _blogConnection.Close();
            }

            return null;
        }

        public List<Post> GetPostsByAuthor(int authorId)
        {
            _blogConnection.Open();

            try
            {
                var getBoardCommand = _blogConnection.CreateCommand();
                getBoardCommand.CommandText = @"
                SELECT PostId, Title, PublishedAt, Body, IsDraft, Edited, URL
                FROM Boards 
                WHERE Owner_Id = @userId ";
                var authorIdParam = new SqlParameter("userId", SqlDbType.VarChar);
                authorIdParam.Value = authorId;

                getBoardCommand.Parameters.Add(authorIdParam);
                var reader = getBoardCommand.ExecuteReader();

                var posts = new List<Post>();
                while (reader.Read())
                {
                    var post = new Post
                    {
                        PostId = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        DateCreated = reader.GetDateTime(2),
                        PublishedAt = reader.GetDateTime(3),
                        Body = reader.GetString(4),
                        IsDraft = reader.GetBoolean(5),
                        Edited = reader.GetBoolean(6),
                        URL = reader.GetString(7)
                    };      


                    posts.Add(post);
                }
                return posts;
            }
            catch (Exception ex) { }
            finally
            {
                _blogConnection.Close();
            }

            return null;
        }
    }
}