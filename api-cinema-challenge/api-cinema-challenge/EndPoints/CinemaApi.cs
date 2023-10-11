using api_cinema_challenge.Models;
using api_cinema_challenge.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api_cinema_challenge.EndPoints
{
    public static class CinemaApi
    {

        public static void ConfigureCinemaApi(this WebApplication app)
        {
            app.MapGet("/customers", GetCustomers);
            app.MapPost("/customers", CreateCustomer);
            app.MapPut("/customers/{id}", UpdateCustomer);
            app.MapDelete("/customers/{id}", DeleteCustomer);

            app.MapPost("/movies", CreateMovie);
            app.MapGet("/movies", GetMovies);
            app.MapPut("/movies/{id}", UpdateMovie);
            app.MapDelete("/movies/{id}", DeleteMovie);

            app.MapPost("/movies/{id}/screenings", CreateScreening);

            app.MapGet("/movies/{id}/screenings", GetScreenings);

            app.MapPost("/customers/{customerId}/screenings/{screeningId}", CreateTicket);
            app.MapGet("/customers/{customerId}/screenings/{screeningId}", GetTickets);


        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateTicket(int customerId, int screeningId, TicketPost ticketPost, IRepository repository)
        {
            Ticket ticket = new Ticket();
            ticket.customerId = customerId;
            ticket.screeningId = screeningId;
            ticket.numSeats = ticketPost.numSeats;
            ticket.createdAt = DateTime.UtcNow;
            ticket.updatedAt = DateTime.UtcNow;

            TicketResponse response = new TicketResponse();
            response.data = repository.CreateTicket(ticket);
            return Results.Created("https://localhost:7195/customers/{customersId}/screenings/{screeningsId}", response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetTickets(int customerId, int screeningId, IRepository repository)
        {
            TicketCollectionResponse ticketCollectionResponse = new TicketCollectionResponse();
            ticketCollectionResponse.data = repository.GetTickets().Where(t => t.customerId == customerId && t.screeningId == screeningId).ToList();
            return Results.Ok(ticketCollectionResponse);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetScreenings(int id, IRepository repository)
        {
            ScreeningCollectionResponse screeningResponse = new ScreeningCollectionResponse();
            screeningResponse.data = repository.GetScreenings(id);
            return Results.Ok(screeningResponse);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateScreening(int id, ScreeningPost screeningPost, IRepository repository)
        {
            Screening screening = new Screening();
            screening.movieId = id;
            screening.capacity = screeningPost.capacity;
            screening.screenNumber = screeningPost.screenNumber;
            screening.startsAt = screeningPost.startsAt;
            screening.createdAt = DateTime.UtcNow;
            screening.updatedAt = DateTime.UtcNow;
            
            ScreeningResponse response = new ScreeningResponse();
            response.data = repository.CreateScreening(screening);

            return Results.Created($"https://localhost:7195/movies/{id}/screenings", response);


        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCustomer(CustomerPost NewCustomer, IRepository repository)
        {
            Customer customer = new Customer();
            customer.name = NewCustomer.name;
            customer.email = NewCustomer.email;
            customer.phone = NewCustomer.phone;
            customer.createdAt = DateTime.UtcNow;
            customer.updatedAt = DateTime.UtcNow;

            CustomerResponse customerResponse = new CustomerResponse();
            customerResponse.data = customer;
            var result = repository.CreateCustomer(customer);
            return Results.Created("https://localhost:7195/customers", customerResponse);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            
            CustomerCollectionResponse customerCollectionResponse = new CustomerCollectionResponse();
            customerCollectionResponse.data = repository.GetCustomers();

            return Results.Ok(customerCollectionResponse);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCustomer(int id, CustomerPost customer, IRepository repository)
        {

            var updatedCustomer = repository.GetCustomer(id);

            updatedCustomer.name = customer.name;
            updatedCustomer.email = customer.email;
            updatedCustomer.phone = customer.phone;
            updatedCustomer.updatedAt = DateTime.UtcNow;
            repository.UpdateCustomer(updatedCustomer);

            CustomerResponse customerResponse = new CustomerResponse();
            customerResponse.data = updatedCustomer;

            return Results.Created($"https://localhost:7195/customers", customerResponse);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCustomer(int id, IRepository repository)
        {
            CustomerResponse customerResponse = new CustomerResponse();
            customerResponse.data = repository.DeleteCustomer(id);
            return Results.Ok(customerResponse);

        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateMovie(MoviePost moviePost, IRepository repository)
        {
            Movie movie = new Movie();
            MovieResponse movieResponse = new MovieResponse();


            movie.title = moviePost.title;
            movie.description = moviePost.description;
            movie.runtimeMins = moviePost.runtimeMins;
            movie.rating = moviePost.rating;
            movie.createdAt = DateTime.UtcNow;
            movie.updatedAt = DateTime.UtcNow;

            movieResponse.data = movie;
            var result = repository.CreateMovie(movie);
            foreach (var screeningPost in moviePost.screenings)
            {
                var screening = new Screening();
                screening.movieId = result.id;
                screening.screenNumber = screeningPost.screenNumber;
                screening.capacity = screeningPost.capacity;
                screening.startsAt = screeningPost.startsAt;
                screening.createdAt = DateTime.UtcNow;
                screening.updatedAt = DateTime.UtcNow;

                repository.CreateScreening(screening);


            }
            return Results.Created($"https://localhost:7195/customers", movieResponse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetMovies(IRepository repository)
        {
            MovieCollectionResponse movieCollectionResponse = new MovieCollectionResponse();
            movieCollectionResponse.data = repository.GetMovies();

            return Results.Ok(movieCollectionResponse);

        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateMovie(int id, MoviePut moviePut, IRepository repository)
        {

            var updatedMovie = repository.GetMovie(id);

            updatedMovie.updatedAt = DateTime.UtcNow;
            updatedMovie.title = moviePut.title;
            updatedMovie.description = moviePut.description;
            updatedMovie.runtimeMins = moviePut.runtimeMins;
            updatedMovie.rating = moviePut.rating;
            
            repository.UpdateMovie(updatedMovie);

            MovieResponse movieResponse = new MovieResponse();
            movieResponse.data = updatedMovie;

            return Results.Created($"https://localhost:7195/movies", movieResponse);


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteMovie(int id, IRepository repository)
        {
            MovieResponse movieResponse = new MovieResponse();
            movieResponse.data = repository.Deletemovie(id);

            return Results.Created($"https://localhost:7195/movies", movieResponse);



        }
    }
}
