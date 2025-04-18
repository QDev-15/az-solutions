using AZ.Core.DTOs;
using AZ.Infrastructure.Entities;
using AZ.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZ.Infrastructure.Interfaces.IProviders;
using AZ.Core.DTOs.Roles;
using AZ.Core.DTOs.Articles;
using AZ.Core.DTOs.Languges;
using AZ.Core.DTOs.Medias;
using AZ.Core.DTOs.Categories;
using AZ.Infrastructure.Interfaces.IRepositories;
using AZ.Infrastructure.Extentions;

namespace AZ.Infrastructure.Providers
{
    public class MappingProvider : IMappingProvider
    {
        private readonly ITimeZoneProvider _timeZoneProvider;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILogQueueProvider _logQueueProvider;
        private string languageCode = "vi";

        public MappingProvider(ITimeZoneProvider timeZoneProvider,
            ILanguageRepository languageRepository,
            ILogQueueProvider logQueueProvider)
        {
            _languageRepository = languageRepository;
            _timeZoneProvider = timeZoneProvider;
            languageCode = _timeZoneProvider.GetLanguageCode();
            _logQueueProvider = logQueueProvider;
        }

        private async Task<string> GetLanguage()
        {
            return await _languageRepository.GetLanguageCodeDefault();
        }
        public DateTime ToLocal(DateTime time)
        {

            try
            {
                var timeZone = Helper.GetTimeZone(_timeZoneProvider.GetTimeZoneId());
                return DateTimeHelper.ConvertUtcToLocal(time, timeZone);
            } catch (Exception ex)
            {
                _logQueueProvider.LogError(ex.Message, ex.Source, ex.StackTrace);
                return DateTimeHelper.ConvertUtcToLocal(time, DateTimeHelper.defaultZone);
            }            
        }

        public DateTime ToUTC(DateTime time)
        {
            try
            {
                var timeZone = Helper.GetTimeZone(_timeZoneProvider.GetTimeZoneId());
                return DateTimeHelper.ConvertLocalToUtc(time, timeZone);
            }
            catch (Exception ex)
            {
                _logQueueProvider.LogError(ex.Message, ex.Source, ex.StackTrace);
                return DateTimeHelper.ConvertLocalToUtc(time, DateTimeHelper.defaultZone);
            }
        }
        public DTO_Language ReturnLanguageModel(Language lan)
        {
            if (lan == null) return null;
            var dtoLang = new DTO_Language()
            {
                IsDefault = lan.IsDefault,
                Code = lan.Code,
                DisplayName = lan.DisplayName,
                IsEnabled = lan.IsEnabled,
                NativeName = lan.NativeName
            };
            return dtoLang;
        }

        public DTO_Media ReturnMediaModel(Media media)
        {
            if (media == null) return null;
            var dtoMedia = new DTO_Media()
            {
                Id = media.Id,
                AltText = media.AltText,
                CreatedAt = ToLocal(media.CreatedAt),
                FilePath = media.FilePath,
                Thumbnail = media.Thumbnail,
                UpdatedAt = ToLocal(media.UpdatedAt)
            };
            return dtoMedia;
        }

        // users
        public UserResponse ReturnUserModel(User user)
        {
            if (user == null) return new UserResponse();
            var uresponse = new UserResponse()
            {
                Id = user.Id,
                Avatar = user.Avatar?.FilePath,
                Thumbnail = user.Avatar?.Thumbnail,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status.ToString(),
                CreatedAt = ToLocal(user.CreatedAt),
                UpdatedAt = ToLocal(user.UpdatedAt),
                UserRoles= user.UserRoles.Select(x => ReturnUserRoleModel(x)).ToList()
            };
            return uresponse;
        }
        public DTO_Role ReturnRoleModel(Role role)
        {
            if (role == null)
            {
                return null;
            }
            var dtoRole = new DTO_Role()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                RoleType = role.RoleType
            };
            return dtoRole;

        }
        public DTO_UserRole ReturnUserRoleModel(UserRole userRole)
        {
            if (userRole == null) return null;
            var dtoUserRole = new DTO_UserRole()
            {
                Id = userRole.Id,
                Role = new DTO_Role() { 
                    Id = userRole.Role.Id,
                    Name = userRole.Role.Name,
                    RoleType = userRole.Role.RoleType,
                    Description = userRole.Role.Description
                },
                User = new UserResponse()
                {
                    Id = userRole.User.Id,
                    Username = userRole.User.Username,
                    Email = userRole.User.Email
                }
            };
            return dtoUserRole;
        }

        // Articles
        public DTO_Tag ReturnTagModel(Tag tag)
        {
            if (tag == null) return null;
            var dtoTag = new DTO_Tag()
            {
                Id = tag.Id,
                Name = tag.Name,
                Slug = tag.Slug
            };
            return dtoTag;
        }
        public DTO_Like ReturnLikeModel(Like like)
        {
            if (like == null) return null;
            var dtoLike = new DTO_Like()
            {
                Id = like.Id,
                IpAddress = like.IpAddress,
                LikedDate = like.LikedDate
            };
            return dtoLike;
        }
        public DTO_Rating ReturnRatingModel(Rating rating)
        {
            if (rating == null) return null;
            var dtoRating = new DTO_Rating()
            {
                Id = rating.Id,
                IpAddress = rating.IpAddress,
                RatedDate = ToLocal(rating.RatedDate),
                Score = rating.Score,
            };
            return dtoRating;
        }

        public DTO_ArticleTranslation ReturnArticleTranslation(ArticleTranslation articleTranslation)
        {
            if (articleTranslation == null) return null;
            var dtoArticleTranslation = new DTO_ArticleTranslation()
            {
                Id = articleTranslation.Id,
                Content = articleTranslation.Content,
                Language = new DTO_Language()
                {
                    Code = articleTranslation.Language.Code,
                    DisplayName = articleTranslation.Language.DisplayName
                },
                MetaDescription = articleTranslation.MetaDescription,
                MetaKeywords = articleTranslation.MetaKeywords,
                MetaTitle = articleTranslation.MetaTitle,
                OgImage = new DTO_Media()
                {
                    Id = articleTranslation.OgImage.Id,
                    AltText = articleTranslation.OgImage.AltText,
                    FilePath = articleTranslation.OgImage.FilePath,
                    Thumbnail = articleTranslation.OgImage.Thumbnail
                },
                Slug = articleTranslation.Slug,
                Title = articleTranslation.Title
            };
            return dtoArticleTranslation;
        }

        public DTO_Article ReturnArticleModel(Article article)
        {
            if (article == null) return null;
            var dtoArticle = new DTO_Article()
            {
                Id = article.Id,
                Alias = article.Alias,
                Thumbnail = ReturnMediaModel(article.Thumbnail),
                IsOriginal = article.IsOriginal,
                Source = article.Source,
                RatingResult = article.RatingResult,
                Views = article.Views,
                Description = article.Description,
                CreatedAt = ToLocal(article.CreatedAt),
                UpdatedAt = ToLocal(article.UpdatedAt),
                PublishedAt = ToLocal(article.PublishedAt),
                Ratings = article.Ratings.Any() ? new List<DTO_Rating>() : article.Ratings.Select(x => ReturnRatingModel(x)).ToList(),
                ArticleTranslations = article.ArticleTranslations.Any() 
                    ? new List<DTO_ArticleTranslation>() 
                    : article.ArticleTranslations.Select(x => ReturnArticleTranslation(x)).ToList(),
                Author = ReturnUserModel(article.Author),
                Category = new DTO_Category()
                {
                    Id = article.Category.Id,
                },
                Tags = article.Tags.Select(x => ReturnTagModel(x)).ToList(),
                Likes = article.Likes.Select(x => ReturnLikeModel(x)).ToList(),
                Status = article.Status,
                Title = article.Title
                
            };
            return dtoArticle;
        }

        // categories
        public DTO_Category ReturnCategoryModel(Category category)
        {
            throw new NotImplementedException();
        }

        public DTO_CategoryPermission ReturnCategoryPermission(CategoryPermission categoryPermission)
        {
            throw new NotImplementedException();
        }

        public DTO_CategoryTranslation ReturnCategoryTranslation(CategoryTranslation categoryTranslation)
        {
            throw new NotImplementedException();
        }
    }
}
