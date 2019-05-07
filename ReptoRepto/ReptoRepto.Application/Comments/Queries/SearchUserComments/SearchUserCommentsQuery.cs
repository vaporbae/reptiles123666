namespace ReptoRepto.Application.Comments.Queries.SearchUserComments
{
    using MediatR;
    using System.Collections.Generic;

    public class SearchUserCommentsQuery : IRequest<List<CommentLookupModel>>
    {
        public string Query { get; set; }
    }
}
