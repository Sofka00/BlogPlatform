﻿using BlogPlatform.DAL.DTOs;
using BlogPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.DAL.Repositorys
{
    public class CommentRepository : ICommentRepository
    {
        private Context _context;

        public CommentRepository(Context context)
        {
            _context = context;

        }

        public async Task<string> AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment.Content;
        }

        private async Task<Comment> GetCommentById(Guid id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Guid> UpdateComment(Comment comment)
        {
            var commentToUpdate = await GetCommentById(comment.Id);
            commentToUpdate.Content = comment.Content;

            await _context.SaveChangesAsync();
            return commentToUpdate.Id;
        }

        public async Task<Guid> RemoveComment(Guid id)
        {
            var commentToDelete = await GetCommentById(id);
            _context.Comments.Remove(commentToDelete);
            await _context.SaveChangesAsync();
            return commentToDelete.Id;
        }

    }
}
