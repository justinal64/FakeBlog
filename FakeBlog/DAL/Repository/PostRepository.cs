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
    public class PostRepository : IPostManager, IPostQuery
    {
        IDbConnection _blogConnection;

        public PostRepository(IDbConnection blogConnection)
        {
            _blogConnection = blogConnection;
        }

        public void AddPost(int boardId, string title)
        {
            // opening a sql connection
            _blogConnection.Open();

            try
            {
                var addPostCommand = _blogConnection.CreateCommand();
                addPostCommand.CommandText = $"Insert into Post(Name, Title) values(@boardId, @title)";
                // name parameter
                var boardIdParameter = new SqlParameter("boardId", SqlDbType.Int);
                boardIdParameter.Value = boardId;
                addPostCommand.Parameters.Add(boardIdParameter);
                // owner parameter
                var titleParameter = new SqlParameter("title", SqlDbType.VarChar);
                boardIdParameter.Value = title;
                addPostCommand.Parameters.Add(titleParameter);

                addPostCommand.ExecuteNonQuery();
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

        public void DeletePost(int boardId)
        {
            // opening a sql connection
            _blogConnection.Open();

            try
            {
                var removePostCommand = _blogConnection.CreateCommand();
                removePostCommand.CommandText = @"
                Delete 
                From Author
                Where BoardId = @boardId";
                // name parameter
                var boadIdParameter = new SqlParameter("boardId", SqlDbType.Int);
                boadIdParameter.Value = boardId;
                removePostCommand.Parameters.Add(boadIdParameter);

                removePostCommand.ExecuteNonQuery();
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

        public void EditPost(int boardId, string title)
        {
            // opening a sql connection
            _blogConnection.Open();

            try
            {
                var updatePostCommand = _blogConnection.CreateCommand();
                updatePostCommand.CommandText = @"
                Update Post
                Set Title = @title
                Where BoardId = @boardId";
                // title parameter
                var titleParameter = new SqlParameter("title", SqlDbType.VarChar);
                titleParameter.Value = title;
                updatePostCommand.Parameters.Add(titleParameter);
                // author parameter
                var boardIdParameter = new SqlParameter("boardId", SqlDbType.Int);
                boardIdParameter.Value = boardId;
                updatePostCommand.Parameters.Add(boardIdParameter);

                updatePostCommand.ExecuteNonQuery();
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

        public Post GetPost(int postId)
        {
            _blogConnection.Open();

            try
            {
                var getPostCommand = _blogConnection.CreateCommand();
                getPostCommand.CommandText = @"
                SELECT PostId, Title, DateCreated, PublishedAt, Body, IsDraft, Edited, URL
                FROM Post 
                WHERE PostId = @postId ";
                var postIdParam = new SqlParameter("postId", SqlDbType.Int);
                postIdParam.Value = postId;

                getPostCommand.Parameters.Add(postIdParam);
                var reader = getPostCommand.ExecuteReader();

                var post = new Post();
                if (reader.Read())
                {
                    post.PostId = reader.GetInt32(0);
                    post.Title = reader.GetString(1);
                    post.DateCreated = reader.GetDateTime(2);
                    post.PublishedAt = reader.GetDateTime(3);
                    post.Body = reader.GetString(4);
                    post.IsDraft = reader.GetBoolean(5);
                    post.Edited = reader.GetBoolean(6);
                    post.URL = reader.GetString(7);
                }
                return post;
            }
            catch (Exception ex) { }
            finally
            {
                _blogConnection.Close();
            }

            return null;
        }

        public List<Post> GetPostsByUser(int authorId)
        {
            _blogConnection.Open();

            try
            {
                var getPostCommand = _blogConnection.CreateCommand();
                getPostCommand.CommandText = @"
                SELECT PostId, Title, DateCreated, PublishedAt, Body, IsDraft, Edited, URL
                FROM Post 
                WHERE PostId = @postId ";
                var postIdParam = new SqlParameter("postId", SqlDbType.Int);
                postIdParam.Value = postId;

                getPostCommand.Parameters.Add(postIdParam);
                var reader = getPostCommand.ExecuteReader();

                var post = new Post();
                if (reader.Read())
                {
                    post.PostId = reader.GetInt32(0);
                    post.Title = reader.GetString(1);
                    post.DateCreated = reader.GetDateTime(2);
                    post.PublishedAt = reader.GetDateTime(3);
                    post.Body = reader.GetString(4);
                    post.IsDraft = reader.GetBoolean(5);
                    post.Edited = reader.GetBoolean(6);
                    post.URL = reader.GetString(7);
                }
                return post;
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