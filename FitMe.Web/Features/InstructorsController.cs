namespace FitMe.Web.Features
{
    using System.Threading.Tasks;
    using FitMe.Application.Common;
    using FitMe.Application.Exrercising.Instructors.Commands.Edit;
    using FitMe.Application.Exrercising.Instructors.Queries.Details;
    using Microsoft.AspNetCore.Mvc;

    public class InstructorsController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<InstructorDetailsOutputModel>> Details(
            [FromRoute] InstructorDetailsQuery query)
            => await this.Send(query);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditInstructorCommand command)
            => await this.Send(command.SetId(id));
    }
}
