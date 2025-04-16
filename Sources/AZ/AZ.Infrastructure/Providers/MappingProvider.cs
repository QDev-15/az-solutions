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

namespace AZ.Infrastructure.Providers
{
    public class MappingProvider : IMappingProvider
    {
        private readonly ITimeZoneProvider _timeZoneProvider;

        public MappingProvider(ITimeZoneProvider timeZoneProvider)
        {
            _timeZoneProvider = timeZoneProvider;
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
                UpdatedAt = ToLocal(user.UpdatedAt)
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
                Role = ReturnRoleModel(userRole.Role),
                User = ReturnUserModel(userRole.User)
            };
            return dtoUserRole;
        }

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
                Language = ReturnLanguageModel(articleTranslation.Language),
                MetaDescription = articleTranslation.MetaDescription,
                MetaKeywords = articleTranslation.MetaKeywords,
                MetaTitle = articleTranslation.MetaTitle,
                OgImage = ReturnMediaModel(articleTranslation.OgImage),
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
                RatingResult = article.RatingResult,
                Ratings = article.Ratings.Any() ? new List<DTO_Rating>() : article.Ratings.Select(x => ReturnRatingModel(x)).ToList(),
                ArticleTranslations = article.ArticleTranslations.Any() 
                    ? new List<DTO_ArticleTranslation>() 
                    : article.ArticleTranslations.Select(x => ReturnArticleTranslation(x)).ToList(),
                Author = ReturnUserModel(article.Author),
                Category = 
            };
        }


        public DateTime ToLocal(DateTime time)
        {
            return DateTimeHelper.ConvertUtcToLocal(time, _timeZoneProvider.GetTimeZoneId());
        }

        public DateTime ToUTC(DateTime time)
        {
            return DateTimeHelper.ConvertLocalToUtc(time, _timeZoneProvider.GetTimeZoneId());
        }
    }
}
