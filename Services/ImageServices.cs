using MyVote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVote.Services
{
    public class ImageServices
    {
        private VoteDBContext _voteDBContext { get; set; }

        public ImageServices(VoteDBContext voteDBContext)
        {
            _voteDBContext = voteDBContext;
        }

        public void SaveImage(ImageModel imageModel)
        {
            _voteDBContext.Images.Add(imageModel);
            _voteDBContext.SaveChangesAsync();
        }

    }
}
