using AZ.Core.DTOs;
using AZ.Core.DTOs.Articles;
using AZ.Core.DTOs.Categories;
using AZ.Core.DTOs.Languges;
using AZ.Core.DTOs.Medias;
using AZ.Core.DTOs.Roles;
using AZ.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IProviders
{
    public interface IMappingProvider
    {
        DateTime ToLocal(DateTime time);
        DateTime ToUTC(DateTime time);

        Task<string> GetLanguageCode();
        Task<ICollection<string>> GetLanguageCodes();
        Task<Language> GetLanguage();

        // system
        DTO_Language ReturnLanguageModel(Language lan);
        DTO_Media ReturnMediaModel(Media media);
        // User
        UserResponse ReturnUserModel(User user);
        DTO_UserRole ReturnUserRoleModel(UserRole userRole);
        DTO_Role ReturnRoleModel(Role role);
        
        // Artticle
        DTO_Tag ReturnTagModel(Tag tag);
        DTO_Like ReturnLikeModel(Like like);
        DTO_Rating ReturnRatingModel(Rating rating);
        DTO_ArticleTranslation ReturnArticleTranslation(ArticleTranslation articleTranslation);
        DTO_Article ReturnArticleModel(Article article);

        // Categories
        DTO_Category ReturnCategoryModel(Category category);
        DTO_CategoryPermission ReturnCategoryPermission(CategoryPermission categoryPermission);
        DTO_CategoryTranslation ReturnCategoryTranslation(CategoryTranslation categoryTranslation);

    }
}
