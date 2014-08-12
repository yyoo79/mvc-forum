﻿using System;
using System.Collections.Generic;
using MVCForum.Domain.DomainModel;

namespace MVCForum.Domain.Interfaces.Services
{
    public partial interface ILuceneService
    {
        void UpdateIndex();
        bool CheckIndexExists();
        void AddUpdate(LuceneSearchModel luceneSearchModel);
        void DeleteEntireIndex();
        void Delete(Guid id);
        void OptimiseIndex();
        LuceneSearchModel MapToModel(Post post);
        LuceneSearchModel MapToModel(Topic topic);
        IEnumerable<LuceneSearchModel> Search(string searchTerm, string fieldName, bool doFuzzySearch = false);
        IEnumerable<LuceneSearchModel> Search(string searchTerm, string fieldName, int amountToTake, bool doFuzzySearch = false);
        IEnumerable<LuceneSearchModel> Search(string searchTerm, bool doFuzzySearch = false);
        IEnumerable<LuceneSearchModel> GetAll();
        PagedList<LuceneSearchModel> Search(string searchTerm, int pageIndex, int pageSize, bool doFuzzySearch = false);

   }
}
