using Samachar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Samachar.Service
{
    public class UtilityService : IUtilityService
    {
        public UtilityService()
        {
        }

        public IEnumerable<ArticleTypes> ArticleTypes()
        {
            var articleTypes = Enum.GetValues(typeof(ArticleTypes)).Cast<ArticleTypes>();
            return articleTypes;
        }
    }
}
