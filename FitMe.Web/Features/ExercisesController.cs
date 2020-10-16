namespace FitMe.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FitMe.Application.Common;
    using FitMe.Application.Exrercising.Exercises.Commands.Create;
    using FitMe.Application.Exrercising.Exercises.Commands.Delete;
    using FitMe.Application.Exrercising.Exercises.Commands.Edit;
    using FitMe.Application.Exrercising.Exercises.Queries.Details;
    using FitMe.Application.Exrercising.Exercises.Queries.Muscle;
    using FitMe.Application.Exrercising.Exercises.Queries.Search;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ExercisesController :ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchExercisesOutputModel>> Search(
            [FromQuery] SearchExercisesQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ExerciseDetailsOutputModel>> Details(
            [FromRoute] ExerciseDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateExerciseOutputModel>> Create(
            CreateExerciseCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditExerciseCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteExerciseCommand command)
            => await this.Send(command);

        //[HttpGet]
        //[Authorize]
        //[Route(nameof(Mine))]
        //public async Task<ActionResult<MineCarAdsOutputModel>> Mine(
        //    [FromQuery] MineCarAdsQuery query)
        //    => await this.Send(query);

        [HttpGet]
        [Route(nameof(Muscles))]
        public async Task<ActionResult<IEnumerable<GetExerciseMuscleOutputModel>>> Muscles(
            [FromQuery] GetExerciseMusclesQuery query)
            => await this.Send(query);

        //[HttpPut]
        //[Authorize]
        //[Route(Id + PathSeparator + nameof(ChangeAvailability))]
        //public async Task<ActionResult> ChangeAvailability(
        //    [FromRoute] ChangeAvailabilityCommand query)
        //    => await this.Send(query);
    }
}
