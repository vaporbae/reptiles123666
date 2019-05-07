namespace ReptoRepto.Application.Comments.Queries.SearchUserComments
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using ReptoRepto.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchUserCommentsQueryHandler : IRequestHandler<SearchUserCommentsQuery, List<CommentLookupModel>>
    {
        private readonly ReptoReptoDbContext _context;
        private readonly IMapper _mapper;

        public SearchUserCommentsQueryHandler(ReptoReptoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CommentLookupModel>> Handle(SearchUserCommentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Comments.Where(x => x.User.ToLower().Contains(request.Query.ToLower())).Select(x => new CommentLookupModel
            {
                Title = x.Title,
                User = x.User,
                Content = x.Content,
                PostId = x.PostId
            }).ToListAsync();
        }
    }
}
