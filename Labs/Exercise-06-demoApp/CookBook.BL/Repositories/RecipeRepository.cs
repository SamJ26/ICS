﻿using System;
using System.Collections.Generic;
using CookBook.BL.Interfaces;
using CookBook.BL.Mapper;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;
using CookBook.DAL.Interfaces;
using CookBook.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BL.Repositories
{
    public class RecipeRepository : RepositoryBase<RecipeEntity,RecipeListModel, RecipeDetailModel>, IRecipeRepository
    {
        public RecipeRepository(IDbContextFactory dbContextFactory) 
            : base(dbContextFactory,
                RecipeMapper.MapToEntity,
                RecipeMapper.MapToListModel,
                RecipeMapper.MapToDetailModel,
                new Func<RecipeEntity, IEnumerable<IEntity>>[]{entity => entity.Ingredients},
                entities => entities.Include(entity => entity.Ingredients)
                    .ThenInclude(entity => entity.Ingredient),
                null)
        {
        }
    }
}